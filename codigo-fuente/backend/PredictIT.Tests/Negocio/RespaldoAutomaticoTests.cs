using FluentAssertions;
using PredictIT.BLL;
using PredictIT.BLL.Contracts;
using PredictIT.BLL.Implementations;
using PredictIT.DAO.Contracts;
using PredictIT.Domain.Seguridad;
using PredictIT.Service.Respaldos;
using PredictIT.Service.Seguridad;
using PredictIT.Tests.Dobles;

namespace PredictIT.Tests.Negocio;

/// <summary>
/// El respaldo automático y el asiento de cualquier respaldo en la bitácora
/// (Req. Arq. 003, capítulo 10.3.2.2).
///
/// El documento prometía respaldos automáticos periódicos y el sistema sólo
/// tenía el manual. Y el manual se asentaba sin usuario ni organización, así
/// que el registro existía pero no aparecía en la bitácora de nadie.
/// </summary>
public class RespaldoAutomaticoTests
{
    private readonly RespaldoDaoFalso _registro = new();
    private readonly BitacoraFalsa _bitacora = new();
    private readonly RespaldoServiceFalso _motor = new();

    private RespaldoBusiness Negocio(IContextoSesion contexto) => new(
        new FabricaSeguridadFalsa(new UsuarioDaoFalso(), respaldos: _registro),
        contexto, _bitacora, _motor);

    [Fact]
    public void El_programado_respalda_las_dos_bases_como_automatico_y_sin_usuario()
    {
        var hechos = Negocio(ContextoSesion.SistemaDeRespaldos()).RespaldoProgramado();

        hechos.Select(h => h.Base).Should().BeEquivalentTo("PredictIT_Negocio", "PredictIT_Servicio");
        _registro.Registrados.Should().HaveCount(2)
                 .And.OnlyContain(r => r.Tipo == "AUTOMATICO" && r.IdUsuario == null);

        // Que diga que fue el sistema: atribuírselo a una persona que no
        // estaba sería falsear la bitácora.
        _bitacora.Eventos.Should().HaveCount(2)
                 .And.OnlyContain(e => e.IdUsuario == null && e.Descripcion.StartsWith("Respaldo programado"));
    }

    [Fact]
    public void El_contexto_del_programado_no_alcanza_para_restaurar_otra_cosa()
    {
        // Lleva la patente de respaldos y ninguna más: el mismo criterio que el
        // del barrido predictivo.
        var contexto = ContextoSesion.SistemaDeRespaldos();

        contexto.Patentes.Should().BeEquivalentTo(Patentes.BackupGestionar);
        contexto.IdUsuario.Should().Be(Guid.Empty);
    }

    [Fact]
    public void El_manual_queda_asentado_con_quien_lo_hizo_y_su_organizacion()
    {
        var contexto = new ContextoFalso().Con(Patentes.BackupGestionar);

        Negocio(contexto).Respaldar("PredictIT_Negocio");

        _registro.Registrados.Should().ContainSingle().Which.Tipo.Should().Be("MANUAL");
        var evento = _bitacora.Eventos.Should().ContainSingle().Subject;
        evento.IdUsuario.Should().Be(contexto.IdUsuario);
        evento.IdOrganizacion.Should().Be(contexto.IdOrganizacion);
    }

    [Fact]
    public void Un_respaldo_fallido_tambien_se_registra()
    {
        _motor.Falla = true;

        Negocio(ContextoSesion.SistemaDeRespaldos()).RespaldoProgramado();

        _registro.Registrados.Should().OnlyContain(r => r.Resultado == "ERROR");
        _bitacora.Eventos.Should().OnlyContain(e => e.Codigo == "ERROR_SISTEMA");
    }

    [Fact]
    public void Sin_la_patente_no_respalda()
    {
        Negocio(new ContextoFalso()).Invoking(n => n.RespaldoProgramado())
            .Should().Throw<PermisoDenegadoException>();

        _motor.Respaldadas.Should().BeEmpty();
    }

    private sealed class RespaldoServiceFalso : IRespaldoService
    {
        public bool Falla { get; set; }
        public List<string> Respaldadas { get; } = [];

        public IReadOnlyList<string> BasesQueRespalda { get; } = ["PredictIT_Negocio", "PredictIT_Servicio"];

        public ResultadoRespaldo Respaldar(string nombreBase)
        {
            Respaldadas.Add(nombreBase);
            return Falla
                ? new ResultadoRespaldo(false, nombreBase, "x.bak", "/r/x.bak", null, "disco lleno")
                : new ResultadoRespaldo(true, nombreBase, $"{nombreBase}.bak", $"/r/{nombreBase}.bak", 700 * 1024, null);
        }

        public ResultadoRespaldo Restaurar(string nombreBase, string rutaArchivo) =>
            throw new NotSupportedException();
    }

    private sealed class RespaldoDaoFalso : IRespaldoDao
    {
        public List<Respaldo> Registrados { get; } = [];

        public void Registrar(Respaldo respaldo)
        {
            if (respaldo.Id == Guid.Empty) respaldo.Id = Guid.NewGuid();
            Registrados.Add(respaldo);
        }

        public IList<Respaldo> Historial(int cantidad = 50) => Registrados;
        public Respaldo? PorId(Guid id) => Registrados.FirstOrDefault(r => r.Id == id);
    }
}
