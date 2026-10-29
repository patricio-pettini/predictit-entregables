using PredictIT.DAO.Contracts;
using PredictIT.Domain.Seguridad;
using PredictIT.Service.Seguridad;

namespace PredictIT.BLL.Implementations;

/// <summary>
/// La bitácora vista desde el negocio: completa quién y sobre qué organización
/// cuando el asiento no lo dice (Decorator sobre <see cref="IBitacoraService"/>).
///
/// Quince asientos se escribían con el tipo y el texto y nada más —el alta de
/// una incidencia, la reasignación manual, el cambio de una regla del motor,
/// los cambios de roles—. Quedaban en la tabla sin usuario ni organización: la
/// bitácora de la organización no los mostraba y el filtro por usuario no los
/// encontraba, que es justamente la pregunta que la bitácora tiene que
/// contestar (capítulo 10.3.2.3).
///
/// Se resuelve acá y no asiento por asiento porque el negocio siempre opera con
/// un contexto de sesión, y la omisión vuelve a pasar en el próximo asiento que
/// alguien escriba. Lo que el asiento sí dice explícitamente se respeta: el
/// login, el cambio de organización y el respaldo automático pasan los suyos.
/// </summary>
public sealed class BitacoraDeLaSesion(IBitacoraService interna, IContextoSesion contexto)
    : IBitacoraService
{
    public void Registrar(string codigoTipoEvento, string descripcion, Guid? idUsuario = null,
                          Guid? idOrganizacion = null, string? entidad = null, Guid? idEntidad = null,
                          string? ip = null, string? traza = null) =>
        interna.Registrar(codigoTipoEvento, descripcion,
                          idUsuario ?? Valor(contexto.IdUsuario),
                          idOrganizacion ?? Valor(contexto.IdOrganizacion),
                          entidad, idEntidad, ip, traza);

    public void RegistrarAccesoExitoso(Usuario usuario, Guid idOrganizacion, string? ip) =>
        interna.RegistrarAccesoExitoso(usuario, idOrganizacion, ip);

    public void RegistrarIntentoFallido(string username, string? ip, string motivo, Guid? idUsuario = null) =>
        interna.RegistrarIntentoFallido(username, ip, motivo, idUsuario);

    public void RegistrarAccesoDenegado(string username, string dataKey, Guid? idUsuario, Guid? idOrganizacion) =>
        interna.RegistrarAccesoDenegado(username, dataKey, idUsuario, idOrganizacion);

    public void RegistrarExcepcion(Exception ex, string? contextoDelError, Guid? idUsuario, Guid? idOrganizacion) =>
        interna.RegistrarExcepcion(ex, contextoDelError,
                                   idUsuario ?? Valor(contexto.IdUsuario),
                                   idOrganizacion ?? Valor(contexto.IdOrganizacion));

    public IList<Bitacora> Consultar(DateTime desde, DateTime hasta, Guid? idOrganizacion,
                                     string? codigo, Guid? idUsuario = null) =>
        interna.Consultar(desde, hasta, idOrganizacion, codigo, idUsuario);

    public IList<Bitacora> ConsultarErrores(DateTime desde, DateTime hasta, Guid? idOrganizacion,
                                            bool incluirAdvertencias) =>
        interna.ConsultarErrores(desde, hasta, idOrganizacion, incluirAdvertencias);

    /// <summary>Los procesos automáticos operan sin usuario: eso no es un dato.</summary>
    private static Guid? Valor(Guid id) => id == Guid.Empty ? null : id;
}
