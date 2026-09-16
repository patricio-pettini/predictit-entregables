# PredictIT — entregables

Sistema de mantenimiento predictivo de equipos informáticos para PyMEs.

Trabajo Final de Ingeniería — Universidad Abierta Interamericana, Facultad de
Tecnología Informática. Alumno: **Pettini, Patricio Ezequiel** · Legajo
B00072710-T1 · Grupo 2.

## Qué es este repositorio

**Sólo los entregables.** Es una copia de la carpeta `ENTREGABLES/` del
repositorio de trabajo, sin el código fuente, sin la documentación intermedia y
sin el historial de desarrollo.

Cada carpeta corresponde a una entrega. El detalle de qué va en cada una y con
qué fecha está en [`LEEME.md`](LEEME.md).

| Carpeta | Qué contiene |
|---|---|
| `ENTREGA FINAL/` | El documento del Trabajo Final, el presupuesto, los cinco manuales, la documentación técnica, la gestión del proyecto y el material de defensa |
| `ENTREGA TECNOLOGIA/` | Las entregas parciales de la mitad de tecnología |
| `ENTREGA NEGOCIO/` | Las entregas parciales del plan de negocio |

## Cómo saber que se está leyendo la última versión

[`VERSIONES.md`](VERSIONES.md) lista cada archivo con su **sha-256** y el commit
del repositorio de trabajo del que salió.

Las fechas de archivo no sirven para esto: `git clone` le pone a todos la fecha
en que se clonó. El sha-256 sí, porque viaja con el contenido. Para comprobar un
archivo suelto:

```powershell
Get-FileHash -Algorithm SHA256 "ENTREGA FINAL\01 - Documento del Trabajo Final v2.pdf"
```

Si el resultado no coincide con el que figura en `VERSIONES.md`, el archivo no es
el de esa versión.

## Qué no está acá, y dónde está

El código fuente, los scripts que generan estos documentos, los registros de
decisiones de arquitectura y el historial de commits viven en el repositorio de
trabajo, que es privado. Parte de la trazabilidad del trabajo se apoya en ese
historial —el log de prompts referencia commits, y los días de trabajo sin
consultas se verifican mirándolo—, así que si hace falta auditar el proceso y no
sólo el resultado, el acceso se pide por ahí.

Este repositorio se rehace entero desde el de trabajo cada vez que cambia algo:
no se edita a mano.
