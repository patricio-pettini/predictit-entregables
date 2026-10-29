using PredictIT.BLL.Contracts;
using PredictIT.BLL.DTO;
using PredictIT.DAO.Contracts;
using PredictIT.DAO.Factory;
using PredictIT.Domain.Negocio;
using PredictIT.Domain.Seguridad;
using PredictIT.Service.IA;
using PredictIT.Service.Respaldos;
using PredictIT.Service.Seguridad;

namespace PredictIT.BLL.Implementations;

/// <summary>
/// Usuarios, roles y bloqueos (RF-02, CU-002).
///
/// Toda búsqueda de usuario pasa por la organización de la sesión y no por el
/// identificador: si no, alcanzaría con tener un id para operar sobre el
/// usuario de otro cliente.
/// </summary>
public class UsuarioBusiness(
    IFactoryDaoSeguridad seguridad,
    IContextoSesion contexto,
    IFactoryDao dao,
    IBitacoraService bitacora)
    : BaseAdministracion(seguridad, contexto), IUsuarioBusiness
{
    // ------------------------------------------------------------- usuarios

    public IReadOnlyList<UsuarioListaDto> Usuarios()
    {
        Exigir(Patentes.UsuarioGestionar);

        var usuarios = Seguridad.Usuarios.PorOrganizacion(Contexto.IdOrganizacion);

        // La carga de trabajo sale de negocio; los usuarios, de servicio. Se
        // cruzan en memoria (ADR 0003).
        var carga = dao.Tecnicos.CandidatosPara(idEquipo: null)
            .ToDictionary(t => t.IdUsuario, t => t.IncidenciasAbiertas);

        return usuarios.Select(u => ADto(u, carga)).ToList();
    }

    public UsuarioDetalleDto Usuario(Guid id)
    {
        Exigir(Patentes.UsuarioGestionar);

        var usuario = BuscarDeLaOrganizacion(id);
        var carga = dao.Tecnicos.CandidatosPara(idEquipo: null)
            .ToDictionary(t => t.IdUsuario, t => t.IncidenciasAbiertas);

        // De dónde viene cada patente: es lo que hace explicable el permiso.
        // Sin esto, «por qué este usuario puede hacer esto» no tiene respuesta.
        var concedidas = new List<PatenteConcedidaDto>();
        foreach (var rol in usuario.Roles)
        {
            foreach (var patente in rol.ObtenerPatentes())
            {
                concedidas.Add(new PatenteConcedidaDto(
                    patente.DataKey, patente.Nombre, rol.Nombre,
                    patente.TipoAcceso.ToString().ToUpperInvariant()));
            }
        }

        var unicas = concedidas
            .GroupBy(p => p.DataKey)
            .Select(g => g.Count() == 1
                ? g.First()
                // Una patente puede llegar por más de un rol. Se dice, en lugar
                // de mostrar el primero y ocultar el resto.
                : new PatenteConcedidaDto(g.Key, g.First().Nombre,
                    string.Join(", ", g.Select(x => x.Origen).Distinct()),
                    g.First().TipoAcceso))
            .OrderBy(p => p.DataKey)
            .ToList();

        return new UsuarioDetalleDto(ADto(usuario, carga), unicas);
    }

    public IReadOnlyList<RolDto> Roles()
    {
        Exigir(Patentes.UsuarioGestionar);

        return Seguridad.Permisos.TodosLosRoles()
            .Select(r => new RolDto(r.Id, r.Nombre, r.Descripcion, r.EsSistema,
                                    r.ObtenerPatentes().Count))
            .ToList();
    }

    public void CambiarEstadoUsuario(Guid id, bool activo)
    {
        Exigir(Patentes.UsuarioGestionar);

        var usuario = BuscarDeLaOrganizacion(id);

        // Nadie se desactiva a sí mismo: quedaría afuera del sistema sin nadie
        // que pueda volver a habilitarlo si es el único administrador.
        if (id == Contexto.IdUsuario && !activo)
            throw new BusinessException("No podés desactivar tu propio usuario.");

        Seguridad.Usuarios.CambiarEstado(id, activo);

        bitacora.Registrar(TipoEvento.Codigos.Modificacion,
            $"Usuario {usuario.Username} " + (activo ? "activado" : "desactivado") + ".");
    }

    public void DesbloquearUsuario(Guid id)
    {
        Exigir(Patentes.UsuarioGestionar);

        var usuario = BuscarDeLaOrganizacion(id);
        Seguridad.Usuarios.Desbloquear(id);

        bitacora.Registrar(TipoEvento.Codigos.Modificacion,
            $"Usuario {usuario.Username} desbloqueado tras {usuario.IntentosFallidos} intentos fallidos.");
    }

    public void AsignarRoles(Guid id, IReadOnlyList<Guid> idsRol)
    {
        Exigir(Patentes.RolGestionar);

        var usuario = BuscarDeLaOrganizacion(id);
        var roles = Seguridad.Permisos.TodosLosRoles();

        var desconocidos = idsRol.Where(r => roles.All(x => x.Id != r)).ToList();
        if (desconocidos.Count > 0)
            throw BusinessException.De("roles", "Alguno de los roles indicados no existe.");

        // Un usuario sin rol no puede hacer nada, ni siquiera ver una pantalla.
        // Es más probable que sea un error del formulario que una intención.
        if (idsRol.Count == 0)
        {
            throw BusinessException.De("roles",
                "El usuario tiene que tener al menos un rol. Para quitarle el acceso, desactivalo.");
        }

        // Quitarse a sí mismo la gestión de usuarios deja el sistema sin nadie
        // que pueda volver a otorgarla.
        if (id == Contexto.IdUsuario)
        {
            var nuevas = roles.Where(r => idsRol.Contains(r.Id))
                .SelectMany(r => r.ObtenerPatentes())
                .Select(p => p.DataKey)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (!nuevas.Contains(Patentes.UsuarioGestionar))
            {
                throw new BusinessException(
                    "Con esos roles perderías la gestión de usuarios y no podrías revertirlo.");
            }
        }

        Seguridad.Usuarios.AsignarRoles(id, idsRol);

        var nombres = roles.Where(r => idsRol.Contains(r.Id)).Select(r => r.Nombre);
        bitacora.Registrar(TipoEvento.Codigos.Modificacion,
            $"Roles de {usuario.Username} cambiados a: {string.Join(", ", nombres)}.");
    }

    public UsuarioCreadoDto CrearUsuario(UsuarioEntradaDto entrada)
    {
        // Dar de alta es también asignar roles: sin las dos patentes, alguien
        // que sólo gestiona usuarios podría crear uno con más permisos que él.
        Exigir(Patentes.UsuarioGestionar);
        Exigir(Patentes.RolGestionar);

        var datos = Validar(entrada.Nombre, entrada.Apellido, entrada.Email, entrada.Telefono);

        var username = (entrada.Username ?? string.Empty).Trim().ToLowerInvariant();
        if (username.Length < 3 || username.Length > 60 ||
            !username.All(ch => char.IsAsciiLetterOrDigit(ch) || ch is '.' or '_' or '-'))
        {
            throw BusinessException.De("username",
                "El usuario va de 3 a 60 caracteres, sin espacios ni acentos: letras, números, punto, guion o guion bajo.");
        }

        if (Seguridad.Usuarios.Existe(username, null))
            throw BusinessException.De("username", $"Ya existe un usuario «{username}».");
        if (Seguridad.Usuarios.Existe(null, datos.Email))
            throw BusinessException.De("email", "Ya hay un usuario con ese correo.");

        ValidarRoles(entrada.IdsRol);

        var temporal = PoliticaDeContrasena.GenerarTemporal();
        var usuario = new Usuario
        {
            Nombre = datos.Nombre,
            Apellido = datos.Apellido,
            Email = datos.Email,
            Username = username,
            Telefono = datos.Telefono,
            PasswordHash = HashContrasena.Derivar(temporal),
            IdOrganizacion = Contexto.IdOrganizacion,
            DebeCambiarContrasena = true
        };

        Seguridad.Usuarios.Insert(usuario);
        Seguridad.Usuarios.AsignarRoles(usuario.Id, entrada.IdsRol);

        // La contraseña no va a la bitácora: la bitácora es inmutable, y una
        // contraseña escrita ahí no se podría borrar nunca.
        var roles = Seguridad.Permisos.TodosLosRoles()
            .Where(r => entrada.IdsRol.Contains(r.Id)).Select(r => r.Nombre);
        bitacora.Registrar(TipoEvento.Codigos.Alta,
            $"Alta del usuario {usuario.Username} ({usuario.NombreCompleto}) con los roles " +
            $"{string.Join(", ", roles)}. Debe cambiar la contraseña al entrar.",
            entidad: "Usuario", idEntidad: usuario.Id);

        return new UsuarioCreadoDto(usuario.Id, usuario.Username, temporal);
    }

    public void ActualizarUsuario(Guid id, DatosUsuarioDto entrada)
    {
        Exigir(Patentes.UsuarioGestionar);

        var usuario = BuscarDeLaOrganizacion(id);
        var datos = Validar(entrada.Nombre, entrada.Apellido, entrada.Email, entrada.Telefono);

        if (Seguridad.Usuarios.Existe(null, datos.Email, excepto: id))
            throw BusinessException.De("email", "Ya hay otro usuario con ese correo.");

        usuario.Nombre = datos.Nombre;
        usuario.Apellido = datos.Apellido;
        usuario.Email = datos.Email;
        usuario.Telefono = datos.Telefono;
        Seguridad.Usuarios.ActualizarDatos(usuario);

        bitacora.Registrar(TipoEvento.Codigos.Modificacion,
            $"Datos del usuario {usuario.Username} modificados.",
            entidad: "Usuario", idEntidad: id);
    }

    // ------------------------------------------------------------- privados

    private static DatosUsuarioDto Validar(string? nombre, string? apellido, string? email, string? telefono)
    {
        var n = (nombre ?? string.Empty).Trim();
        var a = (apellido ?? string.Empty).Trim();
        var e = (email ?? string.Empty).Trim().ToLowerInvariant();
        var t = string.IsNullOrWhiteSpace(telefono) ? null : telefono.Trim();

        if (n.Length is 0 or > 100) throw BusinessException.De("nombre", "El nombre es obligatorio y no puede pasar de 100 caracteres.");
        if (a.Length is 0 or > 100) throw BusinessException.De("apellido", "El apellido es obligatorio y no puede pasar de 100 caracteres.");

        // Una validación de forma, no de existencia: que el correo exista sólo
        // lo confirmaría mandarle algo, y el sistema no envía correos.
        var arroba = e.IndexOf('@');
        if (e.Length > 150 || arroba < 1 || e.LastIndexOf('.') < arroba + 2 || e.EndsWith('.') || e.Contains(' '))
            throw BusinessException.De("email", "El correo no tiene un formato válido.");

        if (t is { Length: > 50 }) throw BusinessException.De("telefono", "El teléfono no puede pasar de 50 caracteres.");

        return new DatosUsuarioDto { Nombre = n, Apellido = a, Email = e, Telefono = t };
    }

    private void ValidarRoles(IReadOnlyList<Guid> idsRol)
    {
        var roles = Seguridad.Permisos.TodosLosRoles();

        if (idsRol.Count == 0)
            throw BusinessException.De("roles", "El usuario tiene que tener al menos un rol.");

        if (idsRol.Any(r => roles.All(x => x.Id != r)))
            throw BusinessException.De("roles", "Alguno de los roles indicados no existe.");

        // El Partner trabaja sobre varias organizaciones, y eso lo habilita la
        // plataforma: si una organización pudiera otorgarlo, cualquier cliente
        // podría crear a alguien con alcance sobre los demás.
        var partner = roles.Where(r => idsRol.Contains(r.Id))
            .Any(r => r.ObtenerPatentes().Any(p => p.DataKey == Patentes.OrganizacionCambiar));
        if (partner)
            throw BusinessException.De("roles", "El perfil Partner lo habilita la plataforma, no una organización.");
    }


    private Usuario BuscarDeLaOrganizacion(Guid id)
    {
        var usuario = Seguridad.Usuarios.PorOrganizacion(Contexto.IdOrganizacion)
            .FirstOrDefault(u => u.Id == id);

        // Se busca dentro de la organización y no por identificador: si no,
        // alcanzaría el id para operar sobre un usuario de otro cliente.
        if (usuario is null)
            throw new BusinessException("El usuario no existe o no pertenece a tu organización.");

        usuario.Roles.Clear();
        foreach (var rol in Seguridad.Permisos.RolesDe(usuario.Id)) usuario.Roles.Add(rol);

        return usuario;
    }

    private UsuarioListaDto ADto(Usuario u, IDictionary<Guid, int> carga)
    {
        var roles = u.Roles.Count > 0 ? u.Roles : Seguridad.Permisos.RolesDe(u.Id);

        return new UsuarioListaDto(
            u.Id, u.Username, u.NombreCompleto, u.Email, u.Telefono,
            u.Activo, u.Bloqueado, u.IntentosFallidos, u.FechaAlta, u.UltimoAcceso,
            roles.Select(r => r.Nombre).ToList(),
            roles.SelectMany(r => r.ObtenerPatentes()).Select(p => p.Id).Distinct().Count(),
            carga.TryGetValue(u.Id, out var n) ? n : 0,
            u.Nombre, u.Apellido);
    }
}
