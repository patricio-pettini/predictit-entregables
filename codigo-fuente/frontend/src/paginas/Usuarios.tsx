import { useCallback, useEffect, useMemo, useState, type FormEvent } from 'react';
import { useFormato } from '../idioma/formato';
import { useT } from '../idioma/IdiomaContext';
import { api, ErrorApi } from '../api/cliente';
import type { RolDto, UsuarioCreadoDto, UsuarioDetalleDto, UsuarioListaDto } from '../api/tipos';
import { Patentes } from '../api/tipos';
import { Encabezado } from '../componentes/Layout';
import { EsqueletoTabla, SinDatos } from '../componentes/Estados';
import { IconoBuscar } from '../componentes/Iconos';
import { useCerrarSiExpiro, useSesion } from '../sesion/SesionContext';

/** Los campos de un usuario, compartidos por el alta y la edición. */
function CamposDeUsuario({
  datos,
  onCambio,
  conUsuario,
}: {
  datos: { nombre: string; apellido: string; email: string; telefono: string; username?: string };
  onCambio: (d: Partial<{ nombre: string; apellido: string; email: string; telefono: string; username: string }>) => void;
  conUsuario?: boolean;
}) {
  const t = useT();
  const campo = (etiqueta: string, valor: string, cambio: (v: string) => void,
                 extra: { tipo?: string; requerido?: boolean; ayuda?: string } = {}) => (
    <label style={{ flex: '1 1 200px', display: 'flex', flexDirection: 'column', gap: 5 }}>
      <span className="sub">{etiqueta}</span>
      <input className="campo" type={extra.tipo ?? 'text'} value={valor} required={extra.requerido}
             aria-label={etiqueta} autoComplete="off" onChange={(e) => cambio(e.target.value)} />
      {extra.ayuda ? <span className="sub">{extra.ayuda}</span> : null}
    </label>
  );

  return (
    <>
      <div style={{ display: 'flex', gap: 12, flexWrap: 'wrap' }}>
        {campo(t('usuario.nombre', 'Nombre'), datos.nombre, (v) => onCambio({ nombre: v }), { requerido: true })}
        {campo(t('usuario.apellido', 'Apellido'), datos.apellido, (v) => onCambio({ apellido: v }), { requerido: true })}
      </div>
      {conUsuario
        ? campo(t('login.usuario', 'Usuario'), datos.username ?? '', (v) => onCambio({ username: v }), {
            requerido: true,
            ayuda: t('usuario.usuarioAyuda', 'Con el que entra. Sin espacios ni acentos: letras, números, punto o guion.'),
          })
        : null}
      <div style={{ display: 'flex', gap: 12, flexWrap: 'wrap' }}>
        {campo(t('comun.correo', 'Correo'), datos.email, (v) => onCambio({ email: v }), { tipo: 'email', requerido: true })}
        {campo(t('usuario.telefono', 'Teléfono'), datos.telefono, (v) => onCambio({ telefono: v }), { tipo: 'tel' })}
      </div>
    </>
  );
}

/**
 * Alta de un usuario (RF-02, CU-002).
 *
 * La contraseña no se escribe acá: la genera el sistema, se muestra una sola
 * vez y la persona la tiene que cambiar al entrar. Así quien da de alta la
 * cuenta no conoce la contraseña con la que la persona va a trabajar.
 */
function NuevoUsuario({
  roles,
  onCreado,
  onCancelar,
}: {
  roles: RolDto[];
  onCreado: (creado: UsuarioCreadoDto) => void;
  onCancelar: () => void;
}) {
  const t = useT();
  const cerrarSiExpiro = useCerrarSiExpiro();
  const [datos, setDatos] = useState({ nombre: '', apellido: '', email: '', telefono: '', username: '' });
  const [elegidos, setElegidos] = useState<string[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [enviando, setEnviando] = useState(false);

  // El perfil Partner lo habilita la plataforma y no una organización: la API
  // lo rechaza igual, pero ofrecerlo sería ofrecer algo que no se puede hacer.
  const asignables = roles.filter((r) => r.nombre !== 'PARTNER');

  function enviar(e: FormEvent) {
    e.preventDefault();
    setEnviando(true);
    setError(null);
    api.usuarios
      .crear({ ...datos, telefono: datos.telefono || null, idsRol: elegidos })
      .then(onCreado)
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('usuario.noSeCreo', 'No se pudo dar de alta el usuario.'));
      })
      .finally(() => setEnviando(false));
  }

  return (
    <form className="tarjeta" onSubmit={enviar}>
      <header>
        <h2>{t('usuario.nuevo', 'Nuevo usuario')}</h2>
      </header>
      <div style={{ padding: 16, display: 'flex', flexDirection: 'column', gap: 14 }}>
        <CamposDeUsuario datos={datos} conUsuario onCambio={(d) => setDatos({ ...datos, ...d })} />

        <div>
          <div className="sub" style={{ marginBottom: 6 }}>{t('usuario.roles', 'Roles')}</div>
          {asignables.map((r) => (
            <label key={r.id} style={{ display: 'flex', gap: 9, alignItems: 'flex-start', marginBottom: 6 }}>
              <input
                type="checkbox"
                checked={elegidos.includes(r.id)}
                onChange={(e) =>
                  setElegidos((prev) => (e.target.checked ? [...prev, r.id] : prev.filter((x) => x !== r.id)))
                }
                style={{ marginTop: 3 }}
              />
              <span>
                <span style={{ fontSize: 'var(--txt-tabla)' }}>{r.nombre}</span>
                <span className="sub" style={{ display: 'block' }}>{r.descripcion ?? ''}</span>
              </span>
            </label>
          ))}
        </div>

        <p className="sub">
          {t('usuario.altaContrasenaNota', 'La contraseña la genera el sistema y se muestra una sola vez. Al entrar, la persona tiene que cambiarla: hasta entonces la cuenta no tiene ningún permiso.')}
        </p>

        {error ? <div className="aviso error" role="alert">{error}</div> : null}

        <div style={{ display: 'flex', gap: 8 }}>
          <button type="submit" className="btn pri" disabled={enviando || elegidos.length === 0}>
            {enviando ? t('comun.guardando', 'Guardando…') : t('usuario.darDeAlta', 'Dar de alta')}
          </button>
          <button type="button" className="btn" onClick={onCancelar} disabled={enviando}>
            {t('comun.cancelar', 'Cancelar')}
          </button>
        </div>
      </div>
    </form>
  );
}

/** La contraseña temporal recién generada. Es la única vez que se ve. */
function UsuarioCreado({ creado, onListo }: { creado: UsuarioCreadoDto; onListo: () => void }) {
  const t = useT();
  const [copiada, setCopiada] = useState(false);

  function copiar() {
    navigator.clipboard?.writeText(creado.contrasenaTemporal).then(() => setCopiada(true)).catch(() => {});
  }

  return (
    <div className="tarjeta">
      <header>
        <h2>{t('usuario.creado', 'Usuario creado')}</h2>
      </header>
      <div style={{ padding: 16, display: 'flex', flexDirection: 'column', gap: 12 }}>
        <dl className="dl">
          <dt>{t('login.usuario', 'Usuario')}</dt>
          <dd className="mono">{creado.username}</dd>
          <dt>{t('contrasena.temporal', 'Contraseña temporal')}</dt>
          <dd>
            <span className="mono" style={{ fontSize: 'var(--txt-seccion)', letterSpacing: '1px' }}>
              {creado.contrasenaTemporal}
            </span>
          </dd>
        </dl>
        <div className="aviso atencion">
          {t('usuario.temporalUnaVez', 'Es la única vez que se muestra: el sistema no la guarda en claro. Pasásela a la persona por un canal seguro. Al entrar, el sistema le va a pedir que la reemplace por una propia.')}
        </div>
        <div style={{ display: 'flex', gap: 8 }}>
          <button type="button" className="btn" onClick={copiar}>
            {copiada ? t('comun.copiada', 'Copiada') : t('comun.copiar', 'Copiar')}
          </button>
          <button type="button" className="btn pri" onClick={onListo}>
            {t('comun.listo', 'Listo')}
          </button>
        </div>
      </div>
    </div>
  );
}

/** Panel lateral con el detalle del usuario y la edición de sus roles. */
function Detalle({
  id,
  roles,
  onCambio,
  onCerrar,
}: {
  id: string;
  roles: RolDto[];
  onCambio: () => void;
  onCerrar: () => void;
}) {
  const { fechaHoraSegundos: fechaHora } = useFormato();
  const t = useT();
  const { puede, sesion } = useSesion();
  const cerrarSiExpiro = useCerrarSiExpiro();

  const [detalle, setDetalle] = useState<UsuarioDetalleDto | null>(null);
  const [elegidos, setElegidos] = useState<string[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [guardando, setGuardando] = useState(false);
  const [editando, setEditando] =
    useState<{ nombre: string; apellido: string; email: string; telefono: string } | null>(null);

  const cargar = useCallback(() => {
    setError(null);
    api.usuarios
      .detalle(id)
      .then((d) => {
        setDetalle(d);
        setElegidos(roles.filter((r) => d.datos.roles.includes(r.nombre)).map((r) => r.id));
      })
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('error.cargarUsuario', 'No se pudo cargar el usuario.'));
      });
  }, [id, roles, cerrarSiExpiro]);

  useEffect(cargar, [cargar]);

  function guardarRoles() {
    setGuardando(true);
    setError(null);
    api.usuarios
      .asignarRoles(id, elegidos)
      .then(() => {
        cargar();
        onCambio();
      })
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('error.guardarRoles', 'No se pudieron guardar los roles.'));
      })
      .finally(() => setGuardando(false));
  }

  function guardarDatos(e: FormEvent) {
    e.preventDefault();
    if (!editando) return;
    setGuardando(true);
    setError(null);
    api.usuarios
      .actualizar(id, { ...editando, telefono: editando.telefono || null })
      .then(() => {
        setEditando(null);
        cargar();
        onCambio();
      })
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('error.operacion', 'No se pudo completar la operación.'));
      })
      .finally(() => setGuardando(false));
  }

  if (!detalle) {
    return (
      <div className="tarjeta">
        <div className="vacio">
          {error ?? t('usuario.cargando', 'Cargando el usuario…')}
        </div>
      </div>
    );
  }

  const u = detalle.datos;
  const esUnoMismo = u.id === sesion?.idUsuario;

  const sinCambios =
    elegidos.length === u.roles.length &&
    roles.filter((r) => elegidos.includes(r.id)).every((r) => u.roles.includes(r.nombre));

  return (
    <div style={{ display: 'flex', flexDirection: 'column', gap: 16 }}>
      <div className="tarjeta">
        <header>
          <h2>{u.nombreCompleto}</h2>
          <span style={{ display: 'inline-flex', gap: 6 }}>
            {puede(Patentes.usuarioGestionar) && !editando ? (
              <button
                type="button"
                className="btn plano"
                onClick={() =>
                  setEditando({
                    nombre: u.nombre ?? '',
                    apellido: u.apellido ?? '',
                    email: u.email,
                    telefono: u.telefono ?? '',
                  })
                }
              >
                {t('comun.editar', 'Editar')}
              </button>
            ) : null}
            <button type="button" className="btn plano" onClick={onCerrar}>
              {t('comun.cerrar', 'Cerrar')}
            </button>
          </span>
        </header>

        {editando ? (
          <form onSubmit={guardarDatos} style={{ padding: 16, display: 'flex', flexDirection: 'column', gap: 12 }}>
            <CamposDeUsuario datos={editando} onCambio={(d) => setEditando({ ...editando, ...d })} />
            {error ? <div className="aviso error" role="alert">{error}</div> : null}
            <div style={{ display: 'flex', gap: 8 }}>
              <button type="submit" className="btn pri" disabled={guardando}>
                {guardando ? t('comun.guardando', 'Guardando…') : t('comun.guardar', 'Guardar')}
              </button>
              <button type="button" className="btn" onClick={() => setEditando(null)} disabled={guardando}>
                {t('comun.cancelar', 'Cancelar')}
              </button>
            </div>
          </form>
        ) : null}

        <dl className="dl">
          <dt>{t('login.usuario', 'Usuario')}</dt>
          <dd className="mono">{u.username}</dd>
          <dt>{t('comun.correo', 'Correo')}</dt>
          <dd>{u.email}</dd>
          <dt>{t('usuario.telefono', 'Teléfono')}</dt>
          <dd>{u.telefono ?? '—'}</dd>
          <dt>{t('comun.estado', 'Estado')}</dt>
          <dd>
            <span className={u.activo ? 'chip bajo' : 'chip'}>
              {u.activo ? t('comun.activo', 'Activo') : t('comun.inactivo', 'Inactivo')}
            </span>
            {u.bloqueado ? (
              <span className="chip alto" style={{ marginLeft: 6 }}>
                {t('usuario.bloqueado', 'Bloqueado')}
              </span>
            ) : null}
          </dd>
          <dt>{t('activo.criticidadAlta', 'Alta')}</dt>
          <dd>{fechaHora(u.fechaAlta)}</dd>
          <dt>{t('usuario.ultimoAcceso', 'Último acceso')}</dt>
          <dd>{fechaHora(u.ultimoAcceso)}</dd>
          <dt>{t('dash.incidenciasAbiertas', 'Incidencias abiertas')}</dt>
          <dd className="mono">{u.incidenciasAbiertas}</dd>
        </dl>
      </div>

      {puede(Patentes.rolGestionar) ? (
        <div className="tarjeta">
          <header>
            <h2>{t('usuario.roles', 'Roles')}</h2>
            <span className="nota">{u.cantidadPatentes} permisos</span>
          </header>

          <div style={{ padding: 14, display: 'flex', flexDirection: 'column', gap: 8 }}>
            {roles.map((r) => (
              <label key={r.id} style={{ display: 'flex', gap: 9, alignItems: 'flex-start' }}>
                <input
                  type="checkbox"
                  checked={elegidos.includes(r.id)}
                  onChange={(e) =>
                    setElegidos((prev) =>
                      e.target.checked ? [...prev, r.id] : prev.filter((x) => x !== r.id),
                    )
                  }
                  style={{ marginTop: 3 }}
                />
                <span>
                  <span style={{ fontSize: 'var(--txt-tabla)' }}>{r.nombre}</span>
                  <span className="sub" style={{ display: 'block' }}>
                    {r.cantidadPatentes} permisos
                    {r.descripcion ? ` · ${r.descripcion}` : ''}
                  </span>
                </span>
              </label>
            ))}

            {esUnoMismo ? (
              <div className="aviso atencion">
                {t('usuario.propioUsuarioNota', 'Es tu propio usuario. El sistema no te va a dejar quitarte la gestión de usuarios: quedarías sin poder revertirlo.')}
              </div>
            ) : null}

            {error ? (
              <div className="aviso error" role="alert">
                {error}
              </div>
            ) : null}

            <div>
              <button
                type="button"
                className="btn pri"
                onClick={guardarRoles}
                disabled={guardando || sinCambios}
              >
                {guardando ? t('comun.guardando', 'Guardando…') : t('usuarios.guardarRoles', 'Guardar roles')}
              </button>
            </div>
          </div>
        </div>
      ) : null}

      <div className="tarjeta">
        <header>
          <h2>{t('usuario.permisosEfectivos', 'Permisos efectivos')}</h2>
          <span className="nota">{detalle.patentes.length}</span>
        </header>

        {/*
          Se muestra de qué rol viene cada permiso. Sin eso, «por qué este
          usuario puede hacer esto» no tiene respuesta, y es la pregunta que
          aparece cuando algo no funciona como se esperaba.
        */}
        <table>
          <thead>
            <tr>
              <th>{t('usuarios.permiso', 'Permiso')}</th>
              <th style={{ width: 150 }}>{t('usuario.loDa', 'Lo da')}</th>
            </tr>
          </thead>
          <tbody>
            {detalle.patentes.map((p) => (
              <tr key={p.dataKey}>
                <td>
                  <span className="mono" style={{ fontSize: 'var(--txt-tabla)' }}>
                    {p.dataKey}
                  </span>
                  <div className="sub">{p.nombre}</div>
                </td>
                <td className="sub">{p.origen}</td>
              </tr>
            ))}
          </tbody>
        </table>

        {detalle.patentes.length === 0 ? (
          <div className="vacio">{t('usuario.sinPermisos', 'Este usuario no tiene ningún permiso.')}</div>
        ) : null}
      </div>
    </div>
  );
}

export function Usuarios() {
  const { fechaHoraSegundos: fechaHora } = useFormato();
  const t = useT();
  const cerrarSiExpiro = useCerrarSiExpiro();

  const [lista, setLista] = useState<UsuarioListaDto[] | null>(null);
  const [roles, setRoles] = useState<RolDto[]>([]);
  const [texto, setTexto] = useState('');
  const [elegido, setElegido] = useState<string | null>(null);
  const [creando, setCreando] = useState(false);
  const [creado, setCreado] = useState<UsuarioCreadoDto | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [ocupado, setOcupado] = useState(false);
  const { puede } = useSesion();
  // Dar de alta es también asignar roles: hacen falta las dos patentes.
  const puedeDarDeAlta = puede(Patentes.usuarioGestionar) && puede(Patentes.rolGestionar);

  const cargar = useCallback(() => {
    setError(null);
    api.usuarios
      .listar()
      .then(setLista)
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('error.cargarListado', 'No se pudo cargar el listado.'));
      });
  }, [cerrarSiExpiro]);

  useEffect(cargar, [cargar]);

  useEffect(() => {
    api.usuarios.roles().then(setRoles).catch(cerrarSiExpiro);
  }, [cerrarSiExpiro]);

  function accion(promesa: Promise<void>) {
    setOcupado(true);
    setError(null);
    promesa
      .then(cargar)
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('error.operacion', 'No se pudo completar la operación.'));
      })
      .finally(() => setOcupado(false));
  }

  const visibles = useMemo(() => {
    if (!lista) return [];
    const t = texto.trim().toLowerCase();
    if (!t) return lista;
    return lista.filter(
      (u) =>
        u.username.toLowerCase().includes(t) ||
        u.nombreCompleto.toLowerCase().includes(t) ||
        u.email.toLowerCase().includes(t) ||
        u.roles.some((r) => r.toLowerCase().includes(t)),
    );
  }, [lista, texto]);

  const contexto = useMemo(() => {
    if (!lista) return t('comun.cargando', 'Cargando…');
    const activos = lista.filter((u) => u.activo).length;
    const bloqueados = lista.filter((u) => u.bloqueado).length;

    const partes = [
      lista.length === 1 ? '1 usuario' : `${lista.length} usuarios`,
      `${activos} activos`,
    ];
    if (bloqueados > 0) {
      partes.push(bloqueados === 1 ? '1 bloqueado' : `${bloqueados} bloqueados`);
    }
    return partes.join(' · ');
  }, [lista]);

  const bloqueados = lista?.filter((u) => u.bloqueado) ?? [];

  return (
    <>
      <Encabezado
        titulo={t('usuario.titulo', 'Usuarios')}
        contexto={contexto}
        acciones={
          puedeDarDeAlta ? (
            <button
              type="button"
              className="btn pri"
              disabled={!!creado}
              onClick={() => {
                setCreando((v) => !v);
                setElegido(null);
              }}
            >
              {creando ? t('comun.cancelar', 'Cancelar') : t('usuario.nuevo', 'Nuevo usuario')}
            </button>
          ) : null
        }
      />

      <div className="cuerpo pagina-usuarios">
        {error ? (
          <div className="aviso error" role="alert" style={{ marginBottom: 12 }}>
            {error}
          </div>
        ) : null}

        {bloqueados.length > 0 ? (
          <div className="aviso atencion" style={{ marginBottom: 12 }}>
            {bloqueados.length === 1
              ? t('usuario.unoBloqueado', '{nombre} está bloqueado por intentos fallidos.',
                  { nombre: bloqueados[0]?.nombreCompleto
                            ?? t('usuario.unUsuario', 'Un usuario') })
              : t('usuario.variosBloqueados',
                  '{n} usuarios están bloqueados por intentos fallidos.',
                  { n: bloqueados.length })}
          </div>
        ) : null}

        <div
          style={{
            display: 'grid',
            gridTemplateColumns: elegido || creando || creado ? 'minmax(0, 1fr) 400px' : '1fr',
            gap: 16,
          }}
        >
          <div>
            <div className="filtros">
              <div className="campo buscador">
                <IconoBuscar />
                <input
                  value={texto}
                  onChange={(e) => setTexto(e.target.value)}
                  placeholder="Usuario, nombre, correo o rol…"
                  aria-label={t('usuarios.buscar', 'Buscar usuarios')}
                />
              </div>
            </div>

            <div className="tarjeta">
              <table>
                <thead>
                  <tr>
                    <th style={{ width: 120 }}>{t('login.usuario', 'Usuario')}</th>
                    <th>{t('usuario.nombre', 'Nombre')}</th>
                    <th style={{ width: 175 }}>{t('usuario.roles', 'Roles')}</th>
                    <th style={{ width: 75 }}>{t('usuario.permisos', 'Permisos')}</th>
                    <th style={{ width: 120 }}>{t('usuario.ultimoAcceso', 'Último acceso')}</th>
                    <th style={{ width: 105 }}>{t('comun.estado', 'Estado')}</th>
                    <th style={{ width: 165 }} className="derecha">
                      {t('comun.acciones', 'Acciones')}
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {visibles.map((u) => (
                    <tr key={u.id}>
                      <td style={{ whiteSpace: 'nowrap' }}>
                        <button
                          type="button"
                          className="btn plano"
                          style={{ padding: 0, height: 'auto' }}
                          onClick={() => {
                            setElegido(u.id);
                            setCreando(false);
                          }}
                        >
                          <span className="mono">{u.username}</span>
                        </button>
                      </td>
                      <td>
                        <span style={{ color: 'var(--tx)' }}>{u.nombreCompleto}</span>
                        <div className="sub">{u.email}</div>
                      </td>
                      <td className="sub">{u.roles.join(', ') || '—'}</td>
                      <td className="mono">{u.cantidadPatentes}</td>
                      <td className="sub">{fechaHora(u.ultimoAcceso)}</td>
                      <td>
                        <span className={u.activo ? 'chip bajo' : 'chip'}>
                          {u.activo ? t('comun.activo', 'Activo') : t('comun.inactivo', 'Inactivo')}
                        </span>
                        {u.bloqueado ? (
                          <div style={{ marginTop: 3 }}>
                            <span className="chip alto">{t('usuario.bloqueado', 'Bloqueado')}</span>
                          </div>
                        ) : null}
                      </td>
                      <td className="derecha">
                        <span style={{ display: 'inline-flex', gap: 6 }}>
                          {u.bloqueado ? (
                            <button
                              type="button"
                              className="btn"
                              disabled={ocupado}
                              onClick={() => accion(api.usuarios.desbloquear(u.id))}
                            >
                              {t('usuario.desbloquear', 'Desbloquear')}
                            </button>
                          ) : null}
                          <button
                            type="button"
                            className="btn plano"
                            disabled={ocupado}
                            onClick={() => accion(api.usuarios.cambiarEstado(u.id, !u.activo))}
                          >
                            {u.activo ? t('comun.desactivar', 'Desactivar') : t('comun.activar', 'Activar')}
                          </button>
                        </span>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>

              {!lista ? <EsqueletoTabla columnas={5} filas={5} /> : null}
              {lista && visibles.length === 0 ? (
                <SinDatos
                  filtrado
                  titulo={t('vacio.usuarioSinCoincidencia', 'Ningún usuario coincide con la búsqueda')}
                  detalle={t('vacio.usuarioFiltroAyuda', 'Probá con parte del nombre, del usuario o del correo.')}
                />
              ) : null}
            </div>

          </div>

          {creado ? (
            <UsuarioCreado
              creado={creado}
              onListo={() => {
                setCreado(null);
                cargar();
              }}
            />
          ) : creando ? (
            <NuevoUsuario
              roles={roles}
              onCreado={(c) => {
                setCreando(false);
                setCreado(c);
                cargar();
              }}
              onCancelar={() => setCreando(false)}
            />
          ) : elegido ? (
            <Detalle
              id={elegido}
              roles={roles}
              onCambio={cargar}
              onCerrar={() => setElegido(null)}
            />
          ) : null}
        </div>
      </div>
    </>
  );
}
