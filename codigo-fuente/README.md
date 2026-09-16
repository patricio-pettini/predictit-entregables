# PredictIT

[![CI](https://github.com/PatricioPettini/trabajo-final-ingenier-a/actions/workflows/ci.yml/badge.svg)](https://github.com/PatricioPettini/trabajo-final-ingenier-a/actions/workflows/ci.yml)

Sistema web de gestión y **mantenimiento predictivo de equipos informáticos**
para pequeñas y medianas empresas.

Trabajo Final de Ingeniería — Universidad Abierta Interamericana, Facultad de
Tecnología Informática. Alumno: Pettini, Patricio Ezequiel.

> **El sistema, funcionando:
> https://predictit-uai.mexicocentral.cloudapp.azure.com** — con Swagger en
> [`/swagger`](https://predictit-uai.mexicocentral.cloudapp.azure.com/swagger) y
> los usuarios de demostración de más abajo. Corre en Microsoft Azure con
> `docker compose`, que es la infraestructura que prevé el capítulo 10.2.5.
> Cómo está armado y por qué, en [`despliegue/LEEME.md`](despliegue/LEEME.md).
>
> **Qué se entrega, y cómo saber que es lo último.** Lo que se entrega está en
> [`ENTREGABLES/`](ENTREGABLES/). Todo lo que está en `docs/` es la fuente con la
> que se arma esa carpeta: se trabaja ahí, pero no se entrega desde ahí.
>
> [`ENTREGABLES/VERSIONES.md`](ENTREGABLES/VERSIONES.md) lista los archivos de la
> última corrida con su **sha-256** y el commit del que salieron. Es lo que hay
> que mirar después de un `git clone` o un `git pull`: las fechas de archivo no
> sirven —git le pone a todo la fecha en que se clonó— y el sha-256 sí.
>
> Para compartir sólo los entregables sin dar acceso a este repositorio, están
> publicados aparte —GitHub da acceso por repositorio y no por carpeta, así que
> no alcanza con compartir un enlace a `ENTREGABLES/`—:
>
> - [`PatricioPettini/predictit-entregables`](https://github.com/PatricioPettini/predictit-entregables),
>   privado, para invitar a los docentes como colaboradores de sólo lectura;
> - [`patricio-pettini/predictit-entregables`](https://github.com/patricio-pettini/predictit-entregables),
>   público, para quien no tenga cuenta de GitHub: en un repositorio privado el
>   enlace solo no alcanza, el acceso es por cuenta.
>
> Los dos se refrescan con `python _publicar-entregables.py`, que copia el
> contenido y no clona este repositorio: un clon seguido de borrar carpetas deja
> el historial intacto y cualquiera con acceso recupera lo borrado.

En lugar de esperar a que un equipo falle, el sistema acumula el historial
técnico de cada activo —incidencias, mantenimientos, cambios de estado— y aplica
reglas configurables sobre ese historial para calcular un nivel de riesgo por
equipo y generar alertas accionables antes de que la falla ocurra.

## Qué hace

- **Inventario de activos** con ubicación, responsable, estado y garantía.
- **Gestión de incidencias** de punta a punta, con clasificación automática del
  texto libre del solicitante y asignación del técnico responsable mediante un
  servicio externo de IA (con reasignación manual y asignación de respaldo si el
  servicio no responde).
- **Mantenimientos** preventivos, correctivos y predictivos, vinculados al
  historial del equipo.
- **Motor predictivo**: scoring de riesgo por equipo y alertas priorizadas.
- **Dashboard y reportes** sobre el estado del parque.
- **Panel de administración** y **módulo del cliente**, con permisos
  diferenciados por perfil.

## Stack

| Capa | Tecnología |
|---|---|
| Backend | ASP.NET Core 9 (Web API), C# |
| Acceso a datos | ADO.NET (`Microsoft.Data.SqlClient`) |
| Base de datos | SQL Server 2022 — dos bases: negocio y servicio |
| Frontend | React 19 + TypeScript + Vite |
| Pruebas | xUnit + FluentAssertions |
| Entorno | Docker Compose |

## Cómo levantarlo

Hay dos caminos, para dos cosas distintas.

### Para probarlo — sólo Docker

No hace falta .NET ni Node instalados.

```powershell
cp .env.ejemplo .env      # y generar las dos claves como indica el archivo
docker compose up --build
```

| | |
|---|---|
| Aplicación | http://localhost:8080 |
| API y Swagger | http://localhost:8081/swagger |

Levanta cuatro contenedores: la base, un trabajo que aplica esquema y datos y
termina, la API, y el frontend detrás de nginx. El frontend pide a `/api` y nginx
lo proxea al contenedor de la API, así que la URL del backend no queda escrita en
el código del frontend ni hay CORS que resolver.

Los scripts de base son idempotentes —`MERGE` e `IF NOT EXISTS`—, así que volver
a levantar el stack reaplica y sale, sin duplicar nada.

Para la demostración del **CP-14** —caída del servicio de IA— alcanza con poner
`PREDICTIT_IA_FALLAR_CADA=1` en el `.env` y recrear la API.

### Para desarrollar — con recarga en caliente

Requisitos: [.NET SDK 9](https://dotnet.microsoft.com/download), Docker Desktop
y Node.js 20+.

```powershell
.\arrancar.ps1
```

Levanta sólo la base en Docker y corre la API y Vite en el host, así un cambio se
ve sin reconstruir imágenes. A mano sería:

```powershell
docker compose up -d sqlserver
.\db\aplicar.ps1
cd backend
dotnet test                                  # tiene que dar todo verde
dotnet run --project PredictIT.Api
```

### Verificación

```powershell
$env:PREDICTIT_DB_PASSWORD = "la del .env"   # las de integración usan la base real
cd backend;  dotnet test                     # 284 pruebas
cd frontend; npm test; npm run build         # 34 pruebas
```

Lo mismo corre solo en cada push y en cada pull request a `main`
([workflow](.github/workflows/ci.yml)), en tres trabajos separados: backend
contra un SQL Server real, frontend, y la construcción de las dos imágenes. Están
separados a propósito: con un solo trabajo, el primer fallo esconde todo lo demás.

### Usuarios de demo

| Usuario | Contraseña | Perfil |
|---|---|---|
| `admin` | `Admin.2026` | Administrador |
| `tecnico1` · `tecnico2` · `tecnico3` | `Tecnico.2026` | Responsable Técnico |
| `solicitante` | `Usuario.2026` | Usuario Solicitante |
| `partner` | `Partner.2026` | Partner (multi-organización) |

## Entregables

Todo lo que se entrega está en [`ENTREGABLES/`](ENTREGABLES/), numerado y con un
[`LEEME.md`](ENTREGABLES/LEEME.md) que explica qué es cada cosa y en qué orden
leerla.

La carpeta **se genera**: cada documento se regenera desde su fuente antes de
copiarse, y si un generador falla el armado se detiene. Para reconstruirla:

```bash
python _armar-entregables.py
```

## Gestión del proyecto

| | |
|---|---|
| [**Panel de obra**](docs/panel/index.html) | El tablero de ingeniería en una página: avance, cobertura de los requisitos de la cátedra, patrones con su archivo, y el origen real de cada defecto |
| [Hoja de ruta](docs/gestion/ROADMAP.md) | Calendario, avance por épica y las 92 historias. Es la vista visual: se genera sola desde el backlog |
| [Plan de sprints](docs/gestion/PLAN-DE-SPRINTS.md) | El detalle: objetivos, criterios de aceptación, defectos y retrospectiva de cada sprint |
| [Patrones y principios](docs/PATRONES-Y-PRINCIPIOS.md) | Dónde vive cada patrón, con archivo y línea. Y lo que **no** está aplicado |
| [Decisiones de arquitectura](docs/adr/) | 15 ADR en formato Nygard |
| [Cambios sobre el TFI](docs/CAMBIOS-DOCUMENTO.md) | Los 72 deltas: sección exacta, qué dice hoy, qué tiene que decir y por qué |
| [**Lo que falta**](docs/PENDIENTE.md) | La respuesta a «¿qué falta?» en un solo lugar, separada por de qué depende cada cosa: lo que espera la devolución, lo que se puede hacer hoy, lo que depende de una fecha, y lo que está declarado y no es deuda |
| [Revisión de coherencia](docs/AUDITORIA-DE-COHERENCIA.md) | Leer todo lo que se entrega buscando dónde un documento desmiente a otro, o al sistema. 18 hallazgos con su evidencia, y los controles que dejó cada uno |
| [Trazabilidad de IA](docs/trazabilidad/) | Registro de uso y los 23 prompts críticos con su validación |

El backlog vive en [`docs/gestion/backlog.json`](docs/gestion/backlog.json) y es la
fuente única: de ahí salen la hoja de ruta, el tablero de Trello y los issues de
GitHub. Tres vistas, un solo backlog — una vista que se mantiene aparte se
desincroniza en la primera semana.

## Estructura

```
TFI/
├─ db/                 esquemas, datos iniciales y el script que los aplica
├─ backend/
│   ├─ PredictIT.Domain/    entidades del dominio
│   ├─ PredictIT.DAO/       acceso a datos (el único que conoce SQL)
│   ├─ PredictIT.BLL/       lógica de negocio
│   ├─ PredictIT.Service/   servicios transversales
│   ├─ PredictIT.Api/       API REST
│   └─ PredictIT.Tests/     pruebas
├─ frontend/           aplicación React
├─ docs/               documentación técnica y cambios sobre el TFI
└─ docker-compose.yml
```

## Sobre la integración de IA

El sistema **no entrena modelos propios**. Consulta un servicio externo de
lenguaje para clasificar la incidencia y recomendar el técnico, y el resultado
siempre es editable por el técnico.

La integración está detrás de una interfaz con dos implementaciones: la real
contra la API de Anthropic y una simulada determinística, que es el modo por
defecto. Esto permite demostrar el sistema completo sin conexión ni crédito de
API, y es también lo que hace verificable el caso de prueba CP-14 (comportamiento
del sistema cuando el servicio de IA se cae).
