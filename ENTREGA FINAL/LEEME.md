# Entregables · PredictIT

**Trabajo Final de Ingeniería en Sistemas** · Universidad Abierta Interamericana
Pettini, Patricio Ezequiel · Legajo B00072710-T1

---

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

Armado el %s. Esta carpeta se **genera**: no se edita a mano. Para
reconstruirla, desde la raíz del repositorio:

```
python _armar-entregables.py
```

Cada documento se regenera desde su fuente antes de copiarse. Si un generador
falla, el armado se detiene: entregar un documento sin saber si está al día es
peor que no entregarlo.

Todo viene en **Word y en PDF**. El Word es para quien quiera comentar o
corregir; el PDF conserva la paginación y los índices, y se abre en cualquier
lado. Los dos salen del mismo archivo, así que no pueden diferir.

Los documentos comparten el formato del documento principal —Calibri 12,
justificado, interlineado 1,15, márgenes de 3 cm— y cada uno lleva portada,
índice, encabezado, numeración de páginas y sus fuentes en normas APA.

---

## En qué orden leerlos

### 01 · Documento del Trabajo Final
El documento principal. Las dos mitades del trabajo: el plan de negocio
(capítulos 1 a 9) y el sistema (capítulo 10).

Los diagramas del capítulo 10 salen de Enterprise Architect —el DER en notación
pata de gallo con ruteo ortogonal, el de clases en tres vistas por capa— y el
modelo nativo va aparte, en la carpeta 05, para que se puedan abrir y modificar
y no sólo mirar.

### 05 · Documentación técnica
Seis documentos y el modelo. El séptimo archivo es el **modelo nativo de
Enterprise Architect**: los diagramas del capítulo 10 no vienen sólo como
imagen, vienen como modelo, así que se pueden abrir, recorrer y modificar.

### 02 · Presupuesto financiero
Diecisiete hojas. Nada está escrito a mano aguas abajo: cada número que se puede
discutir vive en la hoja de Hipótesis y el resto se calcula. La hoja **Flujo de
Fondos** cierra con los indicadores, la sensibilidad del valor terminal y una
lectura del resultado **generada con fórmulas**, para que no pueda quedar
afirmando algo que las hipótesis ya no sostienen.

### 03 · Anexo de trazabilidad del uso de IA
Qué se consultó a herramientas de inteligencia artificial, con qué criterio, y
cómo se validó cada respuesta. Incluye las propuestas que **se descartaron** y
por qué, que es la parte que hace verificable al resto.

### 04 · Manuales
Cinco, uno por audiencia:

1. **Instalación** — para quien despliega el sistema.
2. **Usuario · Administrador** — el perfil que ve y configura todo.
3. **Usuario · Responsable Técnico** — quien atiende las incidencias.
4. **Usuario · Usuario Solicitante** — quien reporta las fallas. Cuatro pantallas.
5. **Programador** — para quien va a mantener el código.

### 05 · Documentación técnica
1. **Diccionario de datos** — 37 tablas y 233 campos. Se genera **leyendo las dos
   bases**, no los scripts: el script dice lo que se quiso crear y la base dice
   lo que existe.
2. **Casos de prueba y evidencia** — se genera **corriendo la suite**. Una tabla
   escrita a mano dice que todo pasó incluso el día que dejó de pasar.
3. **Diagramas del sistema** — paquetes, dominio, secuencia, estados,
   componentes, despliegue y casos de uso. En Mermaid, para que se corrijan en el
   mismo commit que el cambio que los invalida.
4. **Patrones y principios** — dónde vive cada patrón, con archivo y línea. Y lo
   que **no** está aplicado, declarado.
5. **Decisiones de arquitectura** — los quince ADR en formato Nygard, cada uno
   con sus alternativas descartadas y sus consecuencias en contra, reunidos en
   un solo documento con su índice.

Los diagramas y las capturas de pantalla **no se dibujan ni se recortan a
mano**. Los diagramas se escriben una vez en Mermaid y se convierten a imagen
con un script; las capturas las saca un navegador automatizado que entra con
cada perfil y recorre las pantallas. Cuando algo cambia, se rehacen todas con un
comando, que es lo que evita la captura vieja que nadie vuelve a mirar.

### 06 · Panel de obra
Una página. Avance, cobertura de los requisitos de la cátedra con **cómo se
comprobó cada uno**, la cadena de trazabilidad con fechas de commit, y el origen
real de cada defecto del proyecto. Se abre con doble clic en cualquier navegador.

### 07 · Gestión del proyecto
Un documento con las tres partes:

1. **Plan de sprints** — nueve sprints, con los defectos y la retrospectiva de
   cada uno.
2. **Hoja de ruta** — la vista de calendario y avance.
3. **Cambios sobre el documento original** — los 27 deltas: sección exacta, qué
   decía, qué tiene que decir y por qué.

### 08 · Presentación de la defensa
Veinte diapositivas para veinte minutos, con el guion de cada una en las **notas
del orador**. Las cifras no están escritas: se leen del backlog, de la corrida
de pruebas y del registro de cambios, así la presentación no puede quedar
diciendo un número que ya no es. La penúltima diapositiva es el recorrido de la
demostración en vivo, paso por paso.

Al lado va el **guión de ensayo**: qué comprobar media hora antes, el minutado
de las dos mitades, el recorrido de la demostración paso por paso, y las ocho
preguntas que más probablemente vengan con su respuesta corta. Es para ensayar
con el reloj, no para leer el día de la defensa.

---

## El sistema

El código está en el repositorio, no en esta carpeta. Para levantarlo en una
máquina que sólo tenga Docker:

```
cp .env.ejemplo .env      # y generar las dos claves como indica el archivo
docker compose up --build
```

| | |
|---|---|
| Aplicación | http://localhost:8080 |
| API y Swagger | http://localhost:8081/swagger |

Usuarios de demostración:

| Usuario | Contraseña | Perfil |
|---|---|---|
| `admin` | `Admin.2026` | Administrador |
| `tecnico1` · `tecnico2` · `tecnico3` | `Tecnico.2026` | Responsable Técnico |
| `solicitante` | `Usuario.2026` | Usuario Solicitante |
| `partner` | `Partner.2026` | Partner (multi-organización) |

Para la demostración de la caída del servicio de IA, poner
`PREDICTIT_IA_FALLAR_CADA=1` en el `.env` y recrear el contenedor de la API.

---

## Qué mirar si hay poco tiempo

Tres cosas, en este orden:

1. **El panel de obra** (06). Es el proyecto en una página, y el gráfico del
   medio dice lo que más cuesta admitir: ninguno de los defectos de este trabajo
   lo encontró una prueba automatizada, y explica por qué eso no es un fracaso
   de la suite sino una propiedad de lo que una prueba puede encontrar.
2. **Los ADR** (05.5). Quince decisiones, cada una con lo que se descartó y lo
   que costó. Dos de ellas documentan errores propios y cómo se corrigieron.
3. **La hoja Flujo de Fondos del presupuesto** (02). El valor actual neto es
   negativo con el supuesto conservador y está dicho así, con la sensibilidad al
   lado.
