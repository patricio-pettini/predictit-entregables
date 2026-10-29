import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import { describe, expect, it, vi } from 'vitest';

/**
 * Con la contraseña temporal del alta no hay aplicación (RF-02, CU-002).
 *
 * La API ya garantiza lo importante: esa sesión no trae ninguna patente, así
 * que cualquier pantalla respondería 403. Lo que fija esta prueba es la otra
 * mitad: que la persona no vea un menú vacío y pantallas de error, sino el
 * cambio de contraseña como continuación del ingreso, sea cual sea la
 * dirección a la que entró.
 */

vi.mock('../sesion/SesionContext', () => ({
  useSesion: () => ({
    sesion: {
      idUsuario: 'u1',
      username: 'jperez',
      nombreCompleto: 'Juana Pérez',
      roles: ['RESPONSABLE_TECNICO'],
      patentes: [],
      organizacion: { id: 'o1', razonSocial: 'Estudio', nombreCorto: 'Estudio', cuit: '30-1-4' },
      organizacionesDisponibles: [],
      debeCambiarContrasena: true,
    },
    cargando: false,
    puede: () => false,
    salir: () => {},
    refrescar: async () => {},
    cambiarOrganizacion: async () => {},
  }),
  useCerrarSiExpiro: () => () => {},
}));

import { App } from '../App';

function montar(direccion: string) {
  render(
    <MemoryRouter initialEntries={[direccion]}>
      <App />
    </MemoryRouter>,
  );
}

describe('Ingreso con la contraseña temporal', () => {
  it.each(['/', '/incidencias', '/usuarios'])('en «%s» muestra sólo el cambio de contraseña', (direccion) => {
    montar(direccion);

    expect(screen.getByRole('heading', { name: /Elegí tu contraseña/i })).toBeTruthy();
    expect(screen.getByLabelText(/Contraseña temporal/i)).toBeTruthy();
    // Sin barra lateral: no hay a dónde ir hasta cambiarla.
    expect(screen.queryByRole('navigation')).toBeNull();
  });

  it('ofrece salir, para quien entró con la cuenta equivocada', () => {
    montar('/');
    expect(screen.getByRole('button', { name: /Cerrar sesión/i })).toBeTruthy();
  });
});
