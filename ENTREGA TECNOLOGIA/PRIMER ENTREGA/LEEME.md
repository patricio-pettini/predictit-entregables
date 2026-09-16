# Primera entrega · Solución tecnológica

> PredictIT · Trabajo Final de Ingeniería · Patricio Pettini · B00072710-T1
> Entrega del 15 de septiembre de 2026

## Qué hay en esta carpeta

- **Solución tecnológica - Entrega 1** (Word y PDF). El capítulo 10 del
  documento del Trabajo Final, con la portada y el mismo formato: arquitectura,
  modelo de datos, casos de uso, diagramas, pantallas y casos de prueba.
- **Código fuente - PredictIT.zip**. La solución completa, sin binarios ni
  dependencias descargables. 249 archivos, 669 KB.
- **Log de prompts - Sistema** (Word y PDF). Las consultas asistidas por IA que
  produjeron el sistema: qué decidí, qué corregí y qué no se delegó.
- **Documentación técnica**, cinco documentos: decisiones de arquitectura,
  patrones y principios, diagramas, verificación y el anexo de trazabilidad.

## El sistema, andando

**https://predictit-uai.mexicocentral.cloudapp.azure.com**

Está desplegado en Microsoft Azure y se puede entrar y usar desde cualquier
navegador, sin instalar nada. La documentación de la API está en
[`/swagger`](https://predictit-uai.mexicocentral.cloudapp.azure.com/swagger).

**Usuarios de prueba.** Cada uno ve un sistema distinto: los permisos se
resuelven por patentes y familias, así que conviene entrar con más de uno para
ver la diferencia.

| Usuario | Contraseña | Qué perfil es |
|---|---|---|
| `admin` | `Admin.2026` | Administrador: ve y configura todo |
| `tecnico1` | `Tecnico.2026` | Responsable Técnico: atiende incidencias y mantenimientos |
| `tecnico2` | `Tecnico.2026` | Responsable Técnico |
| `tecnico3` | `Tecnico.2026` | Responsable Técnico |
| `solicitante` | `Usuario.2026` | Usuario Solicitante: reporta y sigue sus pedidos |
| `partner` | `Partner.2026` | Partner: administra varias organizaciones |

Los datos son de demostración y se pueden modificar sin problema: se
reconstruyen desde los scripts de la base cuando haga falta.

**Si la dirección no responde**, la máquina está apagada para no consumir
crédito. Escribime y la enciendo: tarda unos minutos.

## El repositorio

**El código fuente** está en el `.zip` de esta carpeta, completo y sin binarios,
y también **navegable sin descargar nada** en
`https://github.com/patricio-pettini/predictit-entregables/tree/main/codigo-fuente`.
Es el mismo contenido: la copia navegable se extrae de ese propio `.zip`.

El repositorio de trabajo —con el historial de commits que respalda lo que
afirma el log de prompts— es **privado**; se puede pedir acceso. Aparte hay uno
público con estos mismos entregables, para descargarlos sin cuenta de GitHub:
`https://github.com/patricio-pettini/predictit-entregables`.

## Qué pide esta entrega y dónde está

La consigna pide la base del sistema construida y funcionando. Esta es la
correspondencia, para que no haya que buscarla:

| Lo que se pide | Dónde está |
|---|---|
| Arquitectura por capas | Seis proyectos: `Domain`, `DAO`, `BLL`, `Service`, `Api` y `Tests`. Capítulo 10.3 y ADR 0001 |
| La base de 3.º año, llevada a web | `IGenericDao`, `IObjectMapper`, Abstract Factory (`FactoryDao` y `FactoryBusiness`), Unit of Work (`SqlTransactRepository`) y `SqlHelper` con ADO.NET parametrizado |
| Seguridad | `SeguridadService`: PBKDF2 con 600.000 iteraciones, usuarios, roles, patentes y familias anidadas resueltas con Composite. Capítulo 10.3.3 |
| Bitácora | `BitacoraService` y tabla inmutable: la base tiene un disparador que rechaza cualquier UPDATE o DELETE, así que la garantía no depende de la aplicación. Capítulo 10.3.2.3 |
| Logs | `LoggerService`, con los errores del sistema en su propia vista, separados de la actividad de los usuarios |
| Trazabilidad | La bitácora, más el anexo de trazabilidad del uso de IA |
| Multiidioma | Tabla `Traduccion` en la base de servicio, `IdiomaBusiness`, `IdiomasController` y `IdiomaContext` en el frontend. Español e inglés |
| Respaldos | `RespaldoService`, con `BACKUP` y `RESTORE DATABASE` nativos |
| Algo funcionando | El sistema completo. Ver más abajo cómo levantarlo |

## Lo que está más allá de lo pedido

Esta entrega **no se recortó**. La consigna pide un piso y el sistema lo supera,
así que se entrega completo. Lo que sigue es adelanto de la segunda entrega y se
marca para que no se confunda el alcance:

- Motor de análisis predictivo con cinco reglas configurables y score ponderado.
- Integración con inteligencia artificial, con proveedor conmutable: tres
  funciones —clasificación del reporte, recomendación de asignación y guía de
  reparación paso a paso—, todas como sugerencia editable.
- Dashboard con indicadores, reportes exportables a PDF y el ciclo de vida
  completo de la incidencia.

## Cómo levantarlo

**Con Docker y nada más.** No hace falta .NET ni Node: el `docker compose`
levanta la base, le aplica el esquema y los datos de demostración, compila la
API y sirve el frontend.

```bash
cp .env.ejemplo .env      # y generar las dos claves que el archivo explica
docker compose up --build
```

| | |
|---|---|
| Aplicación | http://localhost:8080 |
| API y Swagger | http://localhost:8081/swagger |

El `.env` pide cuatro valores y el `.env.ejemplo` explica cada uno: la
contraseña de `sa`, la del usuario con el que se conecta la aplicación —que no
es `sa`, y ésa es la idea— y dos claves distintas, una para firmar los tokens y
otra para el cifrado reversible. Son dos a propósito: quien pueda firmar tokens
no tiene por qué poder leer las credenciales de los clientes.

Los scripts de base son idempotentes —`MERGE` e `IF NOT EXISTS`—, así que volver
a levantar el stack reaplica y sale sin duplicar nada.

Usuarios de demostración: `admin / Admin.2026` · `tecnico1 / Tecnico.2026` ·
`solicitante / Usuario.2026` · `partner / Partner.2026`. Los tres primeros
muestran perfiles distintos: el administrador ve todo, el técnico no ve la
configuración y el solicitante sólo sus equipos.

**Para desarrollar**, con recarga en caliente, está `arrancar.ps1`: corre la API
y Vite en la máquina contra la base del contenedor.

Las pruebas, con el stack arriba:

```bash
dotnet test backend/PredictIT.Tests     # unitarias y de integración
cd frontend && npm test                 # componentes
```

## Sobre el despliegue

Esta entrega corre **localmente**, que es lo que la consigna pide. El despliegue
en servidor queda para la entrega final: el `docker-compose.yml` y la
configuración por variables de entorno ya están preparados para eso, así que es
un paso de infraestructura y no un cambio del sistema.
