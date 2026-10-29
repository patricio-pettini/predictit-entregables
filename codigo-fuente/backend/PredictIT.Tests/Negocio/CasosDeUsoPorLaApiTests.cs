using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PredictIT.Tests.Infraestructura;

namespace PredictIT.Tests.Negocio;

/// <summary>
/// Los casos de prueba del capítulo 10 que no tenían una prueba propia.
///
/// La revisión de la segunda entrega de tecnología cruzó cada CP con las pruebas
/// que lo verificaban y encontró que el anexo de evidencia usaba otros nombres
/// para los mismos números: el CP-08 «Registro de mantenimiento» figuraba
/// verificado por las pruebas de la reasignación, y el CP-12 «Generación de
/// reporte», por las de respaldos. Estas son las que faltaban, contra la API
/// real y con los usuarios del seed.
/// </summary>
[Trait("Categoria", "Integracion")]
[Collection(UsuarioSolicitante.Nombre)]
public class CasosDeUsoPorLaApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _api;

    public CasosDeUsoPorLaApiTests(WebApplicationFactory<Program> api) => _api = api;

    /// <summary>
    /// Una sesión por usuario para toda la clase. Diez ingresos seguidos desde
    /// el mismo origen chocan con el límite del login, que es justamente el
    /// control que tiene que estar.
    /// </summary>
    private static readonly ConcurrentDictionary<string, JsonElement> Sesiones = new();

    private async Task<(HttpClient Cliente, JsonElement Sesion)> Entrar(string usuario, string contrasena)
    {
        var cliente = _api.CreateClient();
        if (!Sesiones.TryGetValue(usuario, out var sesion))
        {
            var r = await cliente.PostAsJsonAsync("/api/auth/login", new { username = usuario, contrasena });
            r.StatusCode.Should().Be(HttpStatusCode.OK, $"{usuario} es un usuario del seed");
            sesion = JsonDocument.Parse(await r.Content.ReadAsStringAsync()).RootElement.Clone();
            Sesiones[usuario] = sesion;
        }

        cliente.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", sesion.GetProperty("token").GetString());
        return (cliente, sesion);
    }

    private static async Task<JsonElement> Json(HttpClient cliente, string ruta) =>
        JsonDocument.Parse(await cliente.GetStringAsync(ruta)).RootElement;

    private static IEnumerable<string> Patentes(JsonElement sesion) =>
        sesion.GetProperty("patentes").EnumerateArray().Select(p => p.GetString()!);

    // ------------------------------------------------------------- CP-01

    [Fact]
    [Trait("CP", "CP-01")]
    public async Task Inicio_de_sesion_valido_devuelve_token_y_los_permisos_de_su_perfil()
    {
        var (_, admin) = await Entrar("admin", "Admin.2026");
        var (_, tecnico) = await Entrar("tecnico1", "Tecnico.2026");

        admin.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
        admin.GetProperty("debeCambiarContrasena").GetBoolean().Should().BeFalse();

        // Cada perfil entra a una interfaz distinta porque trae otras patentes.
        Patentes(admin).Should().Contain("USUARIO_GESTIONAR");
        Patentes(tecnico).Should().Contain("INCIDENCIA_ATENDER").And.NotContain("USUARIO_GESTIONAR");
    }

    // ------------------------------------------------------------- CP-08

    [Fact]
    [Trait("CP", "CP-08")]
    public async Task Registrar_un_mantenimiento_lo_suma_al_historial_del_equipo()
    {
        var (tecnico, _) = await Entrar("tecnico1", "Tecnico.2026");

        var equipo = (await Json(tecnico, "/api/equipos?porPagina=1")).GetProperty("items")[0]
            .GetProperty("id").GetGuid();
        var correctivo = (await Json(tecnico, "/api/mantenimientos/catalogos")).GetProperty("tipos")
            .EnumerateArray().First(t => !t.GetProperty("esPreventivo").GetBoolean())
            .GetProperty("id").GetGuid();

        var marca = "Prueba CP-08 " + Guid.NewGuid().ToString("N")[..8];
        var alta = await tecnico.PostAsJsonAsync("/api/mantenimientos", new
        {
            idEquipo = equipo, idTipo = correctivo,
            descripcion = marca, resultado = "Resuelto en la prueba automatizada"
        });
        alta.StatusCode.Should().Be(HttpStatusCode.OK);

        var historial = await Json(tecnico, $"/api/mantenimientos?equipo={equipo}");
        historial.EnumerateArray()
                 .Should().Contain(m => m.GetProperty("descripcion").GetString() == marca);
    }

    [Fact]
    [Trait("CP", "CP-08")]
    public async Task Un_mantenimiento_sin_descripcion_se_rechaza()
    {
        var (tecnico, _) = await Entrar("tecnico1", "Tecnico.2026");
        var equipo = (await Json(tecnico, "/api/equipos?porPagina=1")).GetProperty("items")[0]
            .GetProperty("id").GetGuid();
        var tipo = (await Json(tecnico, "/api/mantenimientos/catalogos")).GetProperty("tipos")[0]
            .GetProperty("id").GetGuid();

        var r = await tecnico.PostAsJsonAsync("/api/mantenimientos",
            new { idEquipo = equipo, idTipo = tipo, descripcion = "" });

        r.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // ------------------------------------------------------------- CP-09

    [Fact]
    [Trait("CP", "CP-09")]
    public async Task El_historial_de_un_equipo_trae_solo_lo_de_ese_equipo()
    {
        var (tecnico, _) = await Entrar("tecnico1", "Tecnico.2026");

        // Un equipo que tenga incidencias: es el caso en que el filtro importa.
        var incidencias = await Json(tecnico, "/api/incidencias?porPagina=50");
        var codigo = incidencias.GetProperty("items")[0].GetProperty("codigoEquipo").GetString();
        var equipo = (await Json(tecnico, $"/api/equipos?texto={codigo}&porPagina=5"))
            .GetProperty("items").EnumerateArray()
            .First(e => e.GetProperty("codigo").GetString() == codigo);
        var id = equipo.GetProperty("id").GetGuid();

        var propias = await Json(tecnico, $"/api/incidencias?equipo={id}&porPagina=50");
        propias.GetProperty("items").GetArrayLength().Should().BeGreaterThan(0);
        propias.GetProperty("items").EnumerateArray()
               .Should().OnlyContain(i => i.GetProperty("codigoEquipo").GetString() == codigo);

        var mantenimientos = await Json(tecnico, $"/api/mantenimientos?equipo={id}");
        mantenimientos.EnumerateArray()
                      .Should().OnlyContain(m => m.GetProperty("codigoEquipo").GetString() == codigo);
    }

    // ------------------------------------------------------------- CP-12

    [Theory]
    [Trait("CP", "CP-12")]
    [InlineData("parque")]
    [InlineData("incidencias")]
    [InlineData("mantenimientos")]
    public async Task Cada_reporte_sale_en_pdf_generado_en_el_servidor(string reporte)
    {
        var (tecnico, _) = await Entrar("tecnico1", "Tecnico.2026");

        var r = await tecnico.GetAsync($"/api/reportes/{reporte}");

        r.StatusCode.Should().Be(HttpStatusCode.OK);
        r.Content.Headers.ContentType!.MediaType.Should().Be("application/pdf");
        var bytes = await r.Content.ReadAsByteArrayAsync();
        System.Text.Encoding.ASCII.GetString(bytes, 0, 5).Should().Be("%PDF-");
    }

    [Fact]
    [Trait("CP", "CP-12")]
    public async Task El_solicitante_no_genera_reportes()
    {
        var (solicitante, _) = await Entrar("solicitante", "Usuario.2026");

        (await solicitante.GetAsync("/api/reportes/parque"))
            .StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }

    // ------------------------------------------------------------- CP-19

    [Fact]
    [Trait("CP", "CP-19")]
    public async Task El_partner_cambia_de_organizacion_y_ve_los_datos_de_la_nueva()
    {
        var (partner, sesion) = await Entrar("partner", "Partner.2026");
        var actual = sesion.GetProperty("organizacion").GetProperty("id").GetGuid();
        var otra = sesion.GetProperty("organizacionesDisponibles").EnumerateArray()
            .Select(o => o.GetProperty("id").GetGuid())
            .First(id => id != actual);

        var r = await partner.PostAsJsonAsync("/api/auth/organizacion", new { idOrganizacion = otra });
        r.StatusCode.Should().Be(HttpStatusCode.OK);

        var nueva = JsonDocument.Parse(await r.Content.ReadAsStringAsync()).RootElement;
        nueva.GetProperty("organizacion").GetProperty("id").GetGuid().Should().Be(otra);

        // La organización viaja en el token: con el nuevo, la sesión es de la otra.
        partner.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", nueva.GetProperty("token").GetString());
        (await Json(partner, "/api/auth/sesion")).GetProperty("organizacion").GetProperty("id")
            .GetGuid().Should().Be(otra);
    }

    [Fact]
    [Trait("CP", "CP-19")]
    public async Task Quien_no_es_partner_no_cambia_de_organizacion()
    {
        var (tecnico, sesion) = await Entrar("tecnico1", "Tecnico.2026");

        var r = await tecnico.PostAsJsonAsync("/api/auth/organizacion",
            new { idOrganizacion = Guid.NewGuid() });

        r.IsSuccessStatusCode.Should().BeFalse();
        sesion.GetProperty("organizacionesDisponibles").GetArrayLength().Should().Be(1);
    }
}
