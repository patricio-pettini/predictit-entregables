import { useState, type FormEvent } from 'react';
import { useNavigate } from 'react-router-dom';
import { api, ErrorApi } from '../api/cliente';
import { useT } from '../idioma/IdiomaContext';
import { Encabezado } from '../componentes/Layout';
import { useCerrarSiExpiro, useSesion } from '../sesion/SesionContext';

/** El largo mínimo es el mismo que valida la API (PoliticaDeContrasena). */
const MINIMO = 10;

/**
 * Cambio de la contraseña propia (RF-02).
 *
 * Tiene dos usos y una sola pantalla. Después del alta es **obligatoria**: la
 * persona entró con la contraseña temporal que le pasó el administrador, la
 * sesión no tiene ningún permiso hasta que la cambie, y esta pantalla
 * reemplaza a toda la aplicación. El resto del tiempo es una opción del menú.
 *
 * La regla se explica antes de escribir y no después de fallar: largo, letras
 * y números, y que no contenga el nombre de usuario. Es la que valida la API;
 * acá se repite sólo para avisar a tiempo.
 */
export function CambiarContrasena({ obligatoria = false }: { obligatoria?: boolean }) {
  const t = useT();
  const { sesion, refrescar, salir } = useSesion();
  const cerrarSiExpiro = useCerrarSiExpiro();
  const navegar = useNavigate();

  const [actual, setActual] = useState('');
  const [nueva, setNueva] = useState('');
  const [repetida, setRepetida] = useState('');
  const [error, setError] = useState<string | null>(null);
  const [listo, setListo] = useState(false);
  const [enviando, setEnviando] = useState(false);

  const noCoinciden = repetida.length > 0 && nueva !== repetida;
  const corta = nueva.length > 0 && nueva.length < MINIMO;

  function enviar(e: FormEvent) {
    e.preventDefault();
    if (noCoinciden || corta) return;

    setEnviando(true);
    setError(null);
    api.auth
      .cambiarContrasena(actual, nueva)
      .then(async () => {
        setActual('');
        setNueva('');
        setRepetida('');
        setListo(true);
        // La sesión se vuelve a pedir: con la temporal no traía patentes, y
        // ahora trae las de los roles.
        await refrescar();
        // Después del cambio obligatorio se entra por la raíz, que lleva a la
        // primera pantalla que el rol puede ver: la dirección con la que llegó
        // puede ser una que no le corresponde.
        if (obligatoria) navegar('/', { replace: true });
      })
      .catch((ex) => {
        cerrarSiExpiro(ex);
        setError(ex instanceof ErrorApi ? ex.message : t('contrasena.noSePudo', 'No se pudo cambiar la contraseña.'));
      })
      .finally(() => setEnviando(false));
  }

  const formulario = (
    <form
      className="tarjeta"
      onSubmit={enviar}
      style={obligatoria
        ? { padding: 'var(--esp-6)', borderRadius: 'var(--radio-modal)', boxShadow: 'var(--elev-flotante)' }
        : { padding: 'var(--esp-5)', maxWidth: 520 }}
    >
      <h1 style={{ fontSize: 'var(--txt-seccion)', fontWeight: 'var(--peso-seccion)', marginBottom: 'var(--esp-2)' }}>
        {obligatoria
          ? t('contrasena.tituloObligatoria', 'Elegí tu contraseña')
          : t('contrasena.titulo', 'Cambiar la contraseña')}
      </h1>

      <p className="sub" style={{ marginBottom: 'var(--esp-4)', lineHeight: 'var(--interlineado-parrafo)' }}>
        {obligatoria
          ? t('contrasena.explicacionObligatoria',
              'Entraste con la contraseña temporal que te dio el administrador. Para usar el sistema tenés que reemplazarla por una propia: hasta entonces la cuenta no tiene ningún permiso.')
          : t('contrasena.explicacion',
              'Al menos {n} caracteres, con letras y números, y sin tu nombre de usuario. Una frase larga es más segura que una palabra con símbolos.',
              { n: MINIMO })}
      </p>

      {obligatoria ? (
        <p className="sub" style={{ marginBottom: 'var(--esp-4)' }}>
          {t('contrasena.explicacion',
            'Al menos {n} caracteres, con letras y números, y sin tu nombre de usuario. Una frase larga es más segura que una palabra con símbolos.',
            { n: MINIMO })}
        </p>
      ) : null}

      <div style={{ marginBottom: 'var(--esp-3)' }}>
        <label className="etiqueta" htmlFor="actual">
          {obligatoria
            ? t('contrasena.temporal', 'Contraseña temporal')
            : t('contrasena.actual', 'Contraseña actual')}
        </label>
        <div className="campo">
          <input id="actual" type="password" autoComplete="current-password" autoFocus
                 value={actual} onChange={(e) => setActual(e.target.value)} />
        </div>
      </div>

      <div style={{ marginBottom: 'var(--esp-3)' }}>
        <label className="etiqueta" htmlFor="nueva">{t('contrasena.nueva', 'Contraseña nueva')}</label>
        <div className="campo">
          <input id="nueva" type="password" autoComplete="new-password"
                 value={nueva} onChange={(e) => setNueva(e.target.value)} />
        </div>
        {corta ? (
          <div className="sub" style={{ marginTop: 4 }}>
            {t('contrasena.faltan', 'Faltan {n} caracteres.', { n: MINIMO - nueva.length })}
          </div>
        ) : null}
      </div>

      <div style={{ marginBottom: 'var(--esp-4)' }}>
        <label className="etiqueta" htmlFor="repetida">{t('contrasena.repetir', 'Repetila')}</label>
        <div className="campo">
          <input id="repetida" type="password" autoComplete="new-password"
                 value={repetida} onChange={(e) => setRepetida(e.target.value)} />
        </div>
        {noCoinciden ? (
          <div className="sub" style={{ marginTop: 4, color: 'var(--alto-tx)' }}>
            {t('contrasena.noCoinciden', 'No coincide con la nueva.')}
          </div>
        ) : null}
      </div>

      {error ? (
        <div className="aviso error" role="alert" style={{ marginBottom: 'var(--esp-4)' }}>{error}</div>
      ) : null}
      {listo && !obligatoria ? (
        <div className="aviso info" role="status" style={{ marginBottom: 'var(--esp-4)' }}>
          {t('contrasena.cambiada', 'Listo: la contraseña quedó cambiada.')}
        </div>
      ) : null}

      <div style={{ display: 'flex', gap: 8 }}>
        <button type="submit" className="btn pri"
                disabled={enviando || !actual || !nueva || !repetida || noCoinciden || corta}>
          {enviando ? t('comun.guardando', 'Guardando…') : t('contrasena.guardar', 'Guardar la contraseña')}
        </button>
        {obligatoria ? (
          <button type="button" className="btn plano" onClick={salir}>
            {t('nav.salir', 'Cerrar sesión')}
          </button>
        ) : null}
      </div>
    </form>
  );

  if (obligatoria) {
    return (
      <div style={{ minHeight: '100%', display: 'flex', alignItems: 'center', justifyContent: 'center',
                    padding: 'var(--esp-6)' }}>
        <div style={{ width: 440, maxWidth: '100%' }}>
          <div style={{ marginBottom: 'var(--esp-4)', textAlign: 'center' }}>
            <div style={{ fontSize: 28, fontWeight: 'var(--peso-cifra)', letterSpacing: '-0.5px' }}>
              {t('app.nombre', 'PredictIT')}
            </div>
            <div className="sub" style={{ marginTop: 'var(--esp-1)' }}>
              {sesion?.nombreCompleto} · <span className="mono">{sesion?.username}</span>
            </div>
          </div>
          {formulario}
        </div>
      </div>
    );
  }

  return (
    <>
      <Encabezado titulo={t('contrasena.titulo', 'Cambiar la contraseña')}
                  contexto={sesion ? `${sesion.nombreCompleto} · ${sesion.username}` : undefined} />
      <div className="cuerpo">{formulario}</div>
    </>
  );
}
