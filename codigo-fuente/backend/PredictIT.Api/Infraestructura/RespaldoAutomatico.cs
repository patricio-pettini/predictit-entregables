using PredictIT.BLL;
using PredictIT.DAO.Contracts;
using PredictIT.DAO.Factory;
using PredictIT.DAO.Helpers;
using PredictIT.Domain.Seguridad;
using PredictIT.Service.IA;
using PredictIT.Service.Prediccion;
using PredictIT.Service.Reportes;
using PredictIT.Service.Respaldos;
using PredictIT.Service.Seguridad;

namespace PredictIT.Api.Infraestructura;

/// <summary>
/// Respaldo automático de las dos bases (Req. Arq. 003, capítulo 10.3.2.2).
///
/// El respaldo manual depende de que alguien se acuerde, y el valor del
/// sistema es el historial acumulado: perderlo es perder la capacidad de
/// anticipar fallas. Por eso hay un segundo camino que no depende de nadie.
///
/// Pasa por el mismo business que el manual, con un contexto que sólo tiene la
/// patente de respaldos: el registro, la verificación del archivo y el asiento
/// en bitácora son los mismos, y la pantalla de Respaldos lo muestra como
/// «automático».
/// </summary>
public class RespaldoAutomatico(
    IServiceScopeFactory ambitos,
    ILogger<RespaldoAutomatico> log,
    OpcionesRespaldoAutomatico opciones) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancelacion)
    {
        if (opciones.Intervalo <= TimeSpan.Zero)
        {
            log.LogInformation("Respaldo automático desactivado por configuración.");
            return;
        }

        // La espera inicial es larga a propósito: un reinicio de la API no
        // tiene por qué disparar un respaldo, y al arrancar la base todavía
        // está aplicando migraciones.
        try
        {
            await Task.Delay(opciones.EsperaInicial, cancelacion);
        }
        catch (OperationCanceledException) { return; }

        while (!cancelacion.IsCancellationRequested)
        {
            try
            {
                Respaldar();
            }
            catch (Exception ex)
            {
                // Igual que el barrido: una excepción que escapara de acá
                // apagaría el servicio hasta el próximo reinicio.
                log.LogError(ex, "Falló el respaldo automático.");
            }

            try
            {
                await Task.Delay(opciones.Intervalo, cancelacion);
            }
            catch (OperationCanceledException) { return; }
        }
    }

    private void Respaldar()
    {
        using var ambito = ambitos.CreateScope();
        var sp = ambito.ServiceProvider;

        var conexiones = sp.GetRequiredService<ConexionesSql>().ParaSegundoPlano();
        var logger = sp.GetRequiredService<ILoggerService>();
        var contexto = ContextoSesion.SistemaDeRespaldos();

        var daoSeguridad = new FactoryDaoSeguridad(conexiones);
        var negocio = new FactoryBusiness(
            new FactoryDao(conexiones, contexto), daoSeguridad, contexto,
            new BitacoraService(daoSeguridad, logger),
            sp.GetRequiredService<ISeguridadService>(),
            sp.GetRequiredService<ITokenService>(),
            new ProveedorIASimulado(() => 0),
            sp.GetRequiredService<MotorPredictivo>(),
            sp.GetRequiredService<IRespaldoService>(),
            sp.GetRequiredService<ICifradoService>(),
            sp.GetRequiredService<IReporteService>());

        foreach (var r in negocio.Respaldos.RespaldoProgramado())
        {
            if (r.Ok)
                log.LogInformation("Respaldo automático de {Base}: {Archivo}.", r.Base, r.NombreArchivo);
            else
                log.LogWarning("Respaldo automático de {Base} fallido: {Detalle}.", r.Base, r.Detalle);
        }
    }
}

/// <summary>Cada cuánto se respalda y cuánto se espera antes del primero.</summary>
public class OpcionesRespaldoAutomatico
{
    public TimeSpan Intervalo { get; init; } = TimeSpan.FromHours(24);
    public TimeSpan EsperaInicial { get; init; } = TimeSpan.FromMinutes(30);
}
