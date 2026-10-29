using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PredictIT.Tests.Infraestructura;

namespace PredictIT.Tests.Seguridad;

/// <summary>
/// CP-02 · El alta de un usuario de punta a punta, por la API.
///
/// Lo que las pruebas del negocio no ven: que la contraseña temporal sirva
/// para entrar, que con ella la sesión no tenga ninguna patente —la garantía
/// del lado del servidor, no de la pantalla— y que cambiarla devuelva los
/// permisos de los roles.
///
/// Crea un usuario de verdad en la base de demostración, con un nombre que no
/// se repite, y lo desactiva al terminar: los usuarios no se borran, porque la
/// bitácora los referencia.
/// </summary>
[Trait("Categoria", "Integracion")]
[Trait("CP", "CP-02")]
public class AltaDeUsuarioPorLaApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _api;

    public AltaDeUsuarioPorLaApiTests(WebApplicationFactory<Program> api) => _api = api;

    private async Task<(HttpClient Cliente, JsonElement Sesion)> Entrar(string usuario, string contrasena)
    {
        var cliente = _api.CreateClient();
        var r = await cliente.PostAsJsonAsync("/api/auth/login", new { username = usuario, contrasena });
        r.StatusCode.Should().Be(HttpStatusCode.OK, $"{usuario} tiene que poder entrar");

        var sesion = JsonDocument.Parse(await r.Content.ReadAsStringAsync()).RootElement;
        cliente.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", sesion.GetProperty("token").GetString());
        return (cliente, sesion);
    }

    [Fact]
    public async Task El_usuario_nuevo_entra_con_la_temporal_y_opera_recien_cuando_la_cambia()
    {
        var (admin, _) = await Entrar("admin", "Admin.2026");

        var roles = JsonDocument.Parse(await admin.GetStringAsync("/api/usuarios/roles")).RootElement;
        var tecnico = roles.EnumerateArray()
            .First(r => r.GetProperty("nombre").GetString() == "RESPONSABLE_TECNICO")
            .GetProperty("id").GetGuid();

        var sufijo = Guid.NewGuid().ToString("N")[..8];
        var alta = await admin.PostAsJsonAsync("/api/usuarios", new
        {
            nombre = "Prueba", apellido = "Alta " + sufijo,
            email = $"prueba.{sufijo}@ejemplo.com", username = $"prueba.{sufijo}",
            idsRol = new[] { tecnico }
        });
        alta.StatusCode.Should().Be(HttpStatusCode.Created);

        var creado = JsonDocument.Parse(await alta.Content.ReadAsStringAsync()).RootElement;
        var id = creado.GetProperty("id").GetGuid();
        var temporal = creado.GetProperty("contrasenaTemporal").GetString()!;

        try
        {
            // Con la temporal entra, pero la sesión no tiene patentes.
            var (nuevo, sesion) = await Entrar($"prueba.{sufijo}", temporal);
            sesion.GetProperty("debeCambiarContrasena").GetBoolean().Should().BeTrue();
            sesion.GetProperty("patentes").GetArrayLength().Should().Be(0);
            (await nuevo.GetAsync("/api/equipos")).StatusCode.Should().Be(HttpStatusCode.Forbidden);

            // La actual equivocada no alcanza para cambiarla.
            (await nuevo.PostAsJsonAsync("/api/auth/contrasena",
                new { actual = "otra cosa 123", nueva = "una clave nueva 2026" }))
                .StatusCode.Should().Be(HttpStatusCode.BadRequest);

            (await nuevo.PostAsJsonAsync("/api/auth/contrasena",
                new { actual = temporal, nueva = "una clave nueva 2026" }))
                .StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Con la nueva, la sesión trae las patentes del rol.
            var (operando, despues) = await Entrar($"prueba.{sufijo}", "una clave nueva 2026");
            despues.GetProperty("debeCambiarContrasena").GetBoolean().Should().BeFalse();
            (await operando.GetAsync("/api/equipos")).StatusCode.Should().Be(HttpStatusCode.OK);

            // Y la temporal dejó de servir.
            var cliente = _api.CreateClient();
            (await cliente.PostAsJsonAsync("/api/auth/login",
                new { username = $"prueba.{sufijo}", contrasena = temporal }))
                .StatusCode.Should().NotBe(HttpStatusCode.OK);
        }
        finally
        {
            await admin.PutAsync($"/api/usuarios/{id}/estado?activo=false", null);
        }
    }

    [Fact]
    public async Task Un_tecnico_no_puede_dar_de_alta_usuarios()
    {
        var (tecnico, _) = await Entrar("tecnico1", "Tecnico.2026");

        var r = await tecnico.PostAsJsonAsync("/api/usuarios", new
        {
            nombre = "No", apellido = "Debería", email = "no@ejemplo.com",
            username = "no.deberia", idsRol = Array.Empty<Guid>()
        });

        r.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
}
