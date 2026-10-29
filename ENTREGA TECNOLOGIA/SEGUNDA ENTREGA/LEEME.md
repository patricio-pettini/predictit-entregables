# Segunda entrega · Solución tecnológica

> PredictIT · Trabajo Final de Ingeniería · Patricio Pettini · B00072710-T1
> Entrega del 20 de octubre de 2026

## Qué hay en esta carpeta

- **Solución tecnológica - Entrega 2** (Word y PDF). El capítulo 10 del
  documento del Trabajo Final, con la portada y el mismo formato: arquitectura,
  modelo de datos, los 23 casos de uso con sus fichas y sus secuencias,
  los diagramas, las pantallas y los 21 casos de prueba.
- **Código fuente - PredictIT.zip**. La solución completa, sin binarios ni
  dependencias descargables. 264 archivos, 721 KB.
- **Log de prompts - Sistema** (Word y PDF). Las consultas asistidas por IA del
  período: qué decidí, qué corregí y qué no se delegó.
- **Documentación técnica**, seis documentos: decisiones de arquitectura,
  patrones y principios, diagramas, verificación, la **matriz de trazabilidad de
  requisitos** y el anexo de trazabilidad del uso de IA.

## Qué cambió desde la primera entrega

La primera entrega pedía la base construida y andando. Esta cierra el sistema:
lo que queda hasta la defensa son ajustes, no funcionalidad nueva.

| | |
|---|---|
| **Está desplegado** | Ya no corre sólo en local: hay una instancia pública en Azure con HTTPS y certificado propio |
| **Alta de usuarios** | El sistema no sabía crear usuarios, sólo modificar los del seed. Ahora da de alta con contraseña temporal de un solo uso y cambio obligatorio al entrar |
| **La IA caída ya no deja la pantalla vacía** | Con el proveedor externo sin responder, la clasificación y la guía salen de reglas propias, marcadas como tales y con el motivo |
| **Planificación y facturación** | Planes de mantenimiento, agenda y facturación del servicio, con sus casos de uso CU-019 a CU-021 |
| **Capítulo 10 contra el código** | Las secuencias eran diagramas de casos de uso y se rehicieron; el diagrama de clases pasa de tres vistas dibujadas a cinco leídas del fuente; se corrigieron las afirmaciones que el código desmentía. El detalle está en D-98 a D-104 del registro de cambios |
| **Matriz de trazabilidad** | Documento nuevo: cada requisito con su caso de uso, la clase donde vive la regla y el caso de prueba que lo demuestra. No se escribe a mano y se niega a generarse si algo no cierra |
| **Pruebas** | De 362 a **403** de backend y de 91 a **95** de frontend, todas en verde |

## El sistema, andando

**https://predictit-uai.mexicocentral.cloudapp.azure.com**

Está desplegado en Microsoft Azure —Standard_B2ls_v2, Ubuntu 24.04, región
Mexico Central— y se entra desde cualquier navegador, sin instalar nada. La
documentación de la API está en
[`/swagger`](https://predictit-uai.mexicocentral.cloudapp.azure.com/swagger).

**Las credenciales de los usuarios de prueba van en el mensaje de la entrega y
no en este archivo**, porque esta carpeta se publica en un repositorio público y
el sistema está expuesto en internet. Hay cuatro perfiles —administrador,
responsable técnico, usuario solicitante y partner— y conviene entrar con más
de uno: los permisos se resuelven por patentes y familias, así que cada uno ve
un sistema distinto.

Los datos son de demostración y se pueden modificar sin problema: un comando los
reconstruye desde cero (`db/restaurar-demo.ps1`).

**Si la dirección no responde**, la máquina está apagada para no consumir
crédito. Escribime y la enciendo: tarda un minuto.

## El repositorio

**El código fuente** está en el `.zip` de esta carpeta, completo y sin binarios.

El repositorio de trabajo —con el historial de commits que respalda lo que
afirma el log de prompts— es **privado**; se puede pedir acceso.

## Cómo levantarlo

**Con Docker y nada más.** No hace falta .NET ni Node: el `docker compose`
levanta la base, le aplica el esquema y los datos de demostración, compila la
API y sirve el frontend.

```bash
cp .env.ejemplo .env      # y generar las claves que el archivo explica
docker compose up --build
```

| | |
|---|---|
| Aplicación | http://localhost:8080 |
| API y Swagger | http://localhost:8081/swagger |

Los scripts de base son idempotentes —`MERGE` e `IF NOT EXISTS`—, así que
volver a levantar el stack reaplica y sale sin duplicar nada.

Las pruebas, con el stack arriba:

```bash
dotnet test backend/PredictIT.Tests     # 403, unitarias y de integración
cd frontend && npm test                 # 95 de componentes
```

Las de integración levantan la API en proceso y piden la contraseña de la base:
sin `PREDICTIT_DB_PASSWORD` en el entorno fallan todas juntas, y el mensaje lo
dice.
