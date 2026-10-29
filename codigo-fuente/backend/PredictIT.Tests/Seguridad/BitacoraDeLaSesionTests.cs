using FluentAssertions;
using PredictIT.BLL.Implementations;
using PredictIT.Tests.Dobles;

namespace PredictIT.Tests.Seguridad;

/// <summary>
/// Todo asiento del negocio sale con quién y con qué organización (capítulo
/// 10.3.2.3). Quince asientos se escribían sin esos dos datos y no aparecían en
/// la bitácora de la organización ni en el filtro por usuario.
/// </summary>
public class BitacoraDeLaSesionTests
{
    private readonly BitacoraFalsa _interna = new();

    [Fact]
    public void Un_asiento_sin_usuario_ni_organizacion_toma_los_de_la_sesion()
    {
        var sesion = new ContextoFalso();

        new BitacoraDeLaSesion(_interna, sesion)
            .Registrar("REGLA_MODIFICADA", "Regla «Recurrencia» con peso 30.");

        var asiento = _interna.Eventos.Should().ContainSingle().Subject;
        asiento.IdUsuario.Should().Be(sesion.IdUsuario);
        asiento.IdOrganizacion.Should().Be(sesion.IdOrganizacion);
    }

    [Fact]
    public void Lo_que_el_asiento_dice_explicitamente_se_respeta()
    {
        // El cambio de organización del Partner asienta en la organización a la
        // que entra, no en la que estaba.
        var destino = Guid.NewGuid();
        var usuario = Guid.NewGuid();

        new BitacoraDeLaSesion(_interna, new ContextoFalso())
            .Registrar("MODIFICACION", "partner cambió de organización.", usuario, destino);

        var asiento = _interna.Eventos.Should().ContainSingle().Subject;
        asiento.IdUsuario.Should().Be(usuario);
        asiento.IdOrganizacion.Should().Be(destino);
    }

    [Fact]
    public void Un_proceso_automatico_no_se_atribuye_a_nadie()
    {
        // El barrido y el respaldo programado corren sin usuario: el asiento
        // tiene que decir «el sistema», no un identificador vacío.
        var sistema = new ContextoFalso { IdUsuario = Guid.Empty, IdOrganizacion = Guid.Empty };

        new BitacoraDeLaSesion(_interna, sistema).Registrar("BACKUP", "Respaldo programado.");

        var asiento = _interna.Eventos.Should().ContainSingle().Subject;
        asiento.IdUsuario.Should().BeNull();
        asiento.IdOrganizacion.Should().BeNull();
    }
}
