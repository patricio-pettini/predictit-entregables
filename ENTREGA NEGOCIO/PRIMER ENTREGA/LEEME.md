# Primera entrega de negocio

> PredictIT · Trabajo Final de Ingeniería · Patricio Pettini · B00072710-T1

Tres archivos:

- **Plan de negocio - Entrega 1** (Word y PDF). Explica cada uno de los siete
  puntos pedidos y deja escrita la fuente de cada supuesto.
- **Presupuesto financiero - Entrega 1** (Excel). Diez hojas: las nueve del
  modelo más una de gráficos. Las celdas recuadradas son las que se cargan a
  mano; todo lo demás se calcula.
- **Log de prompts - Negocio** (Word y PDF). Las consultas asistidas por IA que
  produjeron este material: qué decidí, qué corregí, cómo validé cada número y
  qué no se delegó.

Esta carpeta es **sólo la mitad de negocio**. El sistema es otra entrega y está
en `ENTREGABLES/ENTREGA TECNOLOGIA/PRIMER ENTREGA/`, con su propio log de prompts; ahí van después el código,
sus manuales y la documentación técnica.

Los tres salen con el formato del documento del Trabajo Final: misma tipografía,
mismos tamaños, mismos márgenes y el mismo encabezado con los datos de la
cátedra. Ninguno de esos valores se copió a mano —el Word se escribe sobre una
plantilla que sale del propio documento, y de ahí sale también el logo—, así
que si el documento cambia de formato, esta entrega lo sigue.

Con una diferencia buscada: van **a un solo color**. Todo el texto en negro,
negrita sólo en los títulos y tablas sin relleno, en el documento y en el
libro. La versión con los colores del documento quedó en `version con color/`.

**Los cuatro años van uno abajo del otro y no al costado.** Cada hoja mensual
tiene un bloque por año, con los doce meses en las columnas C a N y el total del
año en la O. Antes los cuarenta y ocho meses iban en cincuenta y cuatro
columnas, hasta la BB: para leer diciembre de 2030 había que barrer media
pantalla a la derecha, y en papel no entraba de ninguna manera.

Con eso el libro queda listo para imprimir sin trucos: apaisado, cada hoja
ajustada al ancho de una página y creciendo hacia abajo lo que haga falta,
repitiendo las columnas de rótulo en cada página. Cada bloque lleva su propio
encabezado con el año, así que ninguna página queda como una columna de números
sueltos.

## Qué cubre

Hipótesis · proyección de ventas con sus líneas de producto y servicio · modelo
de ingresos · modelo de egresos · costos fijos · costos variables · costos de
recursos humanos.

## Qué no

Esta carpeta se armó **recortando** el trabajo, no completándolo. El libro
completo tiene veintiuna hojas; acá van diez. Se quitaron las once que siguen:

- Modelo de Inversión
- Amortizaciones
- Impuestos
- Métricas SaaS
- Gráficos de la evaluación
- Flujo de Fondos
- Matriz de riesgos
- Escenario base
- Escenario optimista
- Escenario pesimista
- Planes de contingencia

Las cuatro primeras corresponden a la Entrega 2. Las siete restantes —de los
gráficos de la evaluación en adelante— son de la entrega final: son las que
evalúan el proyecto, y evaluarlo es justamente lo que esta entrega todavía no
hace.

Sin flujo de fondos no hay valor actual neto, ni tasa interna de retorno, ni
período de repago. Por eso esta entrega **no afirma que el proyecto sea
viable**: establece con qué supuestos se va a evaluar, cuánto cuesta operarlo y
cuánto capital hace falta hasta que se sostenga solo.

## El calendario de las tres entregas

El autor cursa en el **Grupo 2**: las fechas que aplican son las de esa columna.

| Mitad | Entrega | Contenido | Grupo 2 | Grupo 1 |
|---|---|---|---|---|
| Tecnología | 1 | El capítulo 10, hasta donde pide su consigna | **15 de septiembre de 2026** | — |
| Negocio | 1 | Hasta costos de RRHH (esta carpeta) | **18 de septiembre de 2026** | 11 de septiembre |
| Negocio | 2 | Modelo de inversión, flujo de fondos, amortizaciones, matriz de riesgos | **16 de octubre** | 23 de octubre |
| Tecnología | 2 | A confirmar | a confirmar | — |
| Ambas | Final | Los tres escenarios completos con sus planes de contingencia, la carpeta actualizada y el video pitch | 11 de noviembre | 11 de noviembre |

## Cómo se regenera

    python docs/negocio/_entrega-1.py
    python docs/_a-pdf.py "ENTREGABLES/ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.docx"

Dos verificaciones corren solas en cada armado:

- Que ninguna de las diez hojas que quedan tenga una fórmula que apunte a una
  de las que se borran. Si la tuviera, el script se detiene en lugar de
  entregar un libro con `#REF!`.
- Que el libro recalculado no tenga ninguna celda de error.
