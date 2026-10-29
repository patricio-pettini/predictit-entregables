using FluentAssertions;
using PredictIT.BLL;
using PredictIT.BLL.Contracts;
using PredictIT.BLL.DTO;
using PredictIT.BLL.Implementations;
using PredictIT.DAO.Contracts;
using PredictIT.Domain.Seguridad;
using PredictIT.Service.Seguridad;
using PredictIT.Tests.Dobles;

namespace PredictIT.Tests.Seguridad;

/// <summary>
/// CP-02 · Alta de usuario (RF-02, CU-002).
///
/// Hasta la segunda entrega de tecnología el sistema no tenía alta: la pantalla
/// decía que se hacía desde la base, y el CP-02 figuraba aprobado con pruebas
/// que eran de otra cosa. El motivo que daba —que la contraseña inicial
/// quedaba en manos de quien creaba la cuenta— se resuelve con una temporal
/// que el sistema genera, devuelve una sola vez y obliga a cambiar.
/// </summary>
[Trait("CP", "CP-02")]
public class AltaDeUsuarioTests
{
    private static readonly Rol Tecnico = UnRol("RESPONSABLE_TECNICO", Patentes.IncidenciaAtender);
    private static readonly Rol Partner = UnRol("PARTNER", Patentes.OrganizacionCambiar);

    private readonly UsuarioDaoFalso _usuarios = new();
    private readonly BitacoraFalsa _bitacora = new();
    private readonly ContextoFalso _contexto =
        new ContextoFalso().Con(Patentes.UsuarioGestionar, Patentes.RolGestionar);

    private UsuarioBusiness Negocio() => new(
        new FabricaSeguridadFalsa(_usuarios, permisos: new PermisoDaoFalso(Tecnico, Partner)),
        _contexto, new FabricaFalsa(new IncidenciaDaoFalso(), new CatalogoDaoFalso(), new EquipoDaoFalso()),
        _bitacora);

    private static UsuarioEntradaDto Alta(string username = "jperez", string email = "jperez@pyme.com.ar") => new()
    {
        Nombre = " Juana ", Apellido = "Pérez", Email = email, Username = username,
        IdsRol = [Tecnico.Id]
    };

    [Fact]
    public void El_alta_crea_el_usuario_en_la_organizacion_con_sus_roles()
    {
        var creado = Negocio().CrearUsuario(Alta());

        var usuario = _usuarios.Usuarios.Should().ContainSingle().Subject;
        usuario.Username.Should().Be("jperez");
        usuario.Nombre.Should().Be("Juana", "los espacios de los costados no son parte del nombre");
        usuario.IdOrganizacion.Should().Be(_contexto.IdOrganizacion);
        _usuarios.RolesAsignados[creado.Id].Should().Equal(Tecnico.Id);
    }

    [Fact]
    public void La_contrasena_temporal_se_guarda_derivada_y_obliga_a_cambiarla()
    {
        var creado = Negocio().CrearUsuario(Alta());
        var usuario = _usuarios.Usuarios.Single();

        usuario.PasswordHash.Should().NotContain(creado.ContrasenaTemporal);
        HashContrasena.Verificar(creado.ContrasenaTemporal, usuario.PasswordHash).Should().BeTrue();
        usuario.DebeCambiarContrasena.Should().BeTrue();
        PoliticaDeContrasena.Validar(creado.ContrasenaTemporal, usuario.Username).Should().BeNull(
            "con la temporal se tiene que poder entrar");
    }

    [Fact]
    public void La_contrasena_temporal_no_queda_en_la_bitacora()
    {
        var creado = Negocio().CrearUsuario(Alta());

        _bitacora.Eventos.Should().ContainSingle()
                 .Which.Descripcion.Should().NotContain(creado.ContrasenaTemporal);
    }

    [Fact]
    public void Un_usuario_o_un_correo_repetidos_se_rechazan()
    {
        Negocio().CrearUsuario(Alta());

        Negocio().Invoking(n => n.CrearUsuario(Alta(email: "otra@pyme.com.ar")))
                 .Should().Throw<BusinessException>().Which.Campo.Should().Be("username");
        Negocio().Invoking(n => n.CrearUsuario(Alta(username: "otra")))
                 .Should().Throw<BusinessException>().Which.Campo.Should().Be("email");
    }

    [Theory]
    [InlineData("ab")]
    [InlineData("juana perez")]
    [InlineData("juañ")]
    public void Un_nombre_de_usuario_invalido_se_rechaza(string username)
    {
        Negocio().Invoking(n => n.CrearUsuario(Alta(username: username)))
                 .Should().Throw<BusinessException>().Which.Campo.Should().Be("username");
    }

    [Fact]
    public void Un_correo_sin_forma_de_correo_se_rechaza()
    {
        Negocio().Invoking(n => n.CrearUsuario(Alta(email: "juana@pyme")))
                 .Should().Throw<BusinessException>().Which.Campo.Should().Be("email");
    }

    [Fact]
    public void Una_organizacion_no_puede_crear_un_partner()
    {
        var alta = Alta() with { IdsRol = [Partner.Id] };

        Negocio().Invoking(n => n.CrearUsuario(alta))
                 .Should().Throw<BusinessException>().Which.Message.Should().Contain("Partner");
        _usuarios.Usuarios.Should().BeEmpty();
    }

    [Fact]
    public void Sin_roles_no_hay_alta()
    {
        Negocio().Invoking(n => n.CrearUsuario(Alta() with { IdsRol = [] }))
                 .Should().Throw<BusinessException>().Which.Campo.Should().Be("roles");
    }

    [Fact]
    public void Gestionar_usuarios_sin_gestionar_roles_no_alcanza_para_dar_de_alta()
    {
        // Dar de alta es también asignar roles.
        _contexto.Patentes.Remove(Patentes.RolGestionar);

        Negocio().Invoking(n => n.CrearUsuario(Alta()))
                 .Should().Throw<PermisoDenegadoException>();
    }

    private static Rol UnRol(string nombre, string patente)
    {
        var rol = new Rol { Id = Guid.NewGuid(), Nombre = nombre };
        rol.PatentesDirectas.Add(new Patente { Id = Guid.NewGuid(), Nombre = patente, DataKey = patente });
        return rol;
    }

    private sealed class PermisoDaoFalso(params Rol[] roles) : IPermisoDao
    {
        public IList<Rol> TodosLosRoles() => roles;
        public IList<Rol> RolesDe(Guid idUsuario) => [];
        public IList<Guid> OrganizacionesDe(Guid idUsuario) => [];
    }
}

/// <summary>
/// La política de contraseñas y la sesión sin patentes mientras la contraseña
/// sea la temporal del alta.
/// </summary>
public class PoliticaDeContrasenaTests
{
    [Theory]
    [InlineData("corta123", "al menos 10")]
    [InlineData("soloLetrasSinNumeros", "letras y números")]
    [InlineData("12345678901", "letras y números")]
    [InlineData("jperez2026xyz", "nombre de usuario")]
    public void Lo_que_no_cumple_se_rechaza_con_el_motivo(string contrasena, string motivo)
    {
        PoliticaDeContrasena.Validar(contrasena, "jperez").Should().Contain(motivo);
    }

    [Fact]
    public void Una_contrasena_larga_con_letras_y_numeros_se_acepta()
    {
        PoliticaDeContrasena.Validar("mate y bizcochos 1986", "jperez").Should().BeNull();
    }

    [Fact]
    public void La_temporal_cumple_siempre_la_politica()
    {
        for (var i = 0; i < 200; i++)
            PoliticaDeContrasena.Validar(PoliticaDeContrasena.GenerarTemporal(), "jperez").Should().BeNull();
    }

    [Fact]
    public void Dos_temporales_no_se_repiten()
    {
        Enumerable.Range(0, 50).Select(_ => PoliticaDeContrasena.GenerarTemporal())
                  .Distinct().Should().HaveCount(50);
    }
}
