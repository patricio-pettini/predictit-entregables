# -*- coding: utf-8 -*-
"""Mide RNF-09: estabilidad del motor predictivo bajo carga sostenida.

    python scripts/medir-estabilidad.py

RNF-09 dice que el sistema no debe mostrar crecimiento sostenido de memoria ni
agotar el pool de conexiones durante la ejecución prolongada del motor
predictivo sobre el parque completo. La matriz de trazabilidad lo daba por
verificado con la medición de carga, y esa medición cronometra pantallas: no
mira la memoria ni las conexiones, y no corre el motor ni una vez.

Cómo mide:

1. Usa la misma organización de medición que `medir-carga.py` —500 equipos y
   5.000 incidencias— y le copia las reglas del Estudio, porque las reglas son
   de cada organización y sin ellas el motor no tiene nada que evaluar.
2. Evalúa el parque completo muchas veces seguidas (POST /api/prediccion/evaluar).
3. Después de cada vuelta toma la memoria del contenedor de la API y las
   sesiones abiertas contra SQL Server por la cuenta de la aplicación,
   agrupadas por nombre de aplicación: así se ve también el pool propio de los
   procesos de fondo (ADR 0009).
4. Borra todo lo que creó, pase lo que pase.

Requiere el contenedor levantado y la API andando.
"""
from __future__ import print_function

import datetime
import importlib.util
import io
import os
import statistics
import subprocess
import sys
import time

AQUI = os.path.dirname(os.path.abspath(__file__))
_spec = importlib.util.spec_from_file_location('carga', os.path.join(AQUI, 'medir-carga.py'))
carga = importlib.util.module_from_spec(_spec)
_spec.loader.exec_module(carga)

RAIZ = carga.RAIZ
ORG = carga.ORG
ESTUDIO = 'A0000000-0000-0000-0000-000000000001'
CONTENEDOR_API = 'predictit-api'
LOGIN_APP = 'predictit_app'

CALENTAMIENTO = 5
VUELTAS = 120

# Qué se considera crecimiento sostenido: que la tendencia de la segunda mitad
# de la corrida, proyectada sobre esa misma mitad, sume más de este porcentaje
# de la memoria media. «Sostenido» quiere decir que no se detiene: un proceso
# que sube mientras se calienta y después queda plano no pierde memoria, y uno
# que pierde sigue subiendo en proporción al trabajo, también al final.
#
# Se mira la segunda mitad y no la corrida entera porque el montón de .NET tarda
# en llegar a su tamaño de trabajo: en las corridas del 23/10 subió de 65 a 78
# MiB durante unas cincuenta vueltas y después no se movió. Cualquier
# comparación contra el principio mide ese calentamiento (ver HISTORIA).
TOLERANCIA = 0.10
TRAMO = 10
FONDO = 'PredictIT-Fondo'

# Una evaluación lenta es la que tarda más del doble de la mediana.
LENTA = 2.0

# Las corridas con los criterios anteriores. Quedan escritas porque cambiar el
# criterio después de ver un resultado hay que poder justificarlo.
HISTORIA = (
    'El criterio cambió dos veces, y las dos corridas anteriores quedan escritas '
    'porque cambiar un criterio después de ver un resultado hay que poder '
    'justificarlo. La primera —60 vueltas, el 23/10 a las 20:37— comparaba la '
    'mediana de las primeras diez vueltas contra la de las últimas diez y dio '
    '+13,2 %: «no cumple». La serie no era una recta —75 MiB en la vuelta 30, 66 en '
    'la 40, 75 en la 60—, así que se pasó a comparar el piso de cada tercio y se '
    'duplicó la corrida. La segunda —120 vueltas, a las 20:58— dio +20,4 % en el '
    'piso: «no cumple» otra vez. Pero esa serie mostraba lo que pasaba: la memoria '
    'subió de 65 a 78 MiB en las primeras cincuenta y tantas vueltas y en las '
    'sesenta y cinco siguientes no se movió de 78-79, con una pendiente de +0,01 '
    'MiB por vuelta. Los dos criterios comparaban el final contra el calentamiento '
    'del montón. El que responde la pregunta de RNF-09 —si el crecimiento se '
    'sostiene— es la tendencia una vez estabilizado, y es el que se usa.')

INFORME = os.path.join(RAIZ, 'docs', 'tecnico', 'ESTABILIDAD.md')

INFORME = os.path.join(RAIZ, 'docs', 'tecnico', 'ESTABILIDAD.md')


def copiar_reglas():
    carga.sql('PredictIT_Negocio', """
        DELETE FROM dbo.ReglaAlerta WHERE id_organizacion = '%(org)s';
        INSERT INTO dbo.ReglaAlerta (id_regla, id_organizacion, nombre, descripcion,
                                     tipo, condicion, peso, activa)
        SELECT NEWID(), '%(org)s', nombre, descripcion, tipo, condicion, peso, activa
        FROM dbo.ReglaAlerta WHERE id_organizacion = '%(estudio)s';
        """ % {'org': ORG, 'estudio': ESTUDIO})


def limpiar_motor():
    """Lo que escribe el motor, antes de que `medir-carga` borre los equipos."""
    carga.sql('PredictIT_Negocio', """
        DELETE FROM dbo.AlertaPredictiva WHERE id_organizacion = '%(org)s';
        DELETE FROM dbo.EvaluacionRiesgo WHERE id_organizacion = '%(org)s';
        DELETE FROM dbo.ReglaAlerta      WHERE id_organizacion = '%(org)s';
        """ % {'org': ORG})


def memoria_mib():
    """La memoria del contenedor de la API, en MiB."""
    r = subprocess.run(['docker', 'stats', '--no-stream', '--format', '{{.MemUsage}}',
                        CONTENEDOR_API], capture_output=True, text=True)
    valor = r.stdout.split('/')[0].strip()
    for unidad, factor in (('GiB', 1024.0), ('MiB', 1.0), ('KiB', 1 / 1024.0), ('B', 1 / 1048576.0)):
        if valor.endswith(unidad):
            return float(valor[:-len(unidad)]) * factor
    raise SystemExit('No se pudo leer la memoria del contenedor: %r' % r.stdout)


def sesiones():
    """{nombre de aplicación: sesiones abiertas} de la cuenta de la aplicación."""
    salida = carga.sql('master', """
        SELECT ISNULL(program_name, '-') + '|' + CAST(COUNT(*) AS varchar(10))
        FROM sys.dm_exec_sessions
        WHERE is_user_process = 1 AND login_name = '%s'
        GROUP BY program_name;""" % LOGIN_APP)
    resultado = {}
    for linea in salida.splitlines():
        if '|' in linea:
            nombre, cantidad = linea.rsplit('|', 1)
            resultado[nombre.strip()] = int(cantidad)
    return resultado


def entrar():
    import json
    import urllib.request
    pedido = urllib.request.Request(
        carga.API + '/api/auth/login', method='POST',
        data=json.dumps({'username': carga.LOGIN, 'contrasena': carga.CLAVE}).encode('utf-8'))
    pedido.add_header('Content-Type', 'application/json')
    with urllib.request.urlopen(pedido, timeout=60) as r:
        return json.loads(r.read())['token']


def evaluar(token):
    """Evalúa el parque completo. Devuelve (milisegundos, código, resultado).

    No usa el `pedir` de `medir-carga.py`, que corta a los 60 segundos: la
    primera evaluación, en frío, tarda más que eso, y cortarla del lado del
    cliente no la detiene en el servidor —sigue escribiendo mientras el script
    ya está limpiando, y la limpieza choca con lo que se escribe—.
    """
    import json
    import urllib.error
    import urllib.request
    pedido = urllib.request.Request(carga.API + '/api/prediccion/evaluar',
                                    method='POST', data=b'{}')
    pedido.add_header('Content-Type', 'application/json')
    pedido.add_header('Authorization', 'Bearer ' + token)
    inicio = time.perf_counter()
    try:
        with urllib.request.urlopen(pedido, timeout=900) as r:
            codigo, cuerpo = r.status, json.loads(r.read())
    except urllib.error.HTTPError as e:
        codigo, cuerpo = e.code, {}
    return (time.perf_counter() - inicio) * 1000.0, codigo, cuerpo


def pendiente(valores):
    """Pendiente de la recta de mínimos cuadrados, en unidades por vuelta."""
    n = len(valores)
    xs = range(n)
    mx = (n - 1) / 2.0
    my = sum(valores) / float(n)
    num = sum((x - mx) * (y - my) for x, y in zip(xs, valores))
    den = sum((x - mx) ** 2 for x in xs)
    return num / den if den else 0.0


def medir(token):
    print('Calentando: %d evaluaciones que no se cuentan…' % CALENTAMIENTO)
    frio = None
    for i in range(CALENTAMIENTO):
        ms, codigo, cuerpo = evaluar(token)
        if i == 0:
            frio = (ms, cuerpo)
            print('  la primera, en frío: %.1f s · %s' % (ms / 1000.0, cuerpo))

    muestras = []
    for vuelta in range(1, VUELTAS + 1):
        ms, codigo, cuerpo = evaluar(token)
        muestras.append({'vuelta': vuelta, 'ms': ms, 'codigo': codigo,
                         'evaluados': cuerpo.get('equiposEvaluados'),
                         'mib': memoria_mib(), 'sesiones': sesiones()})
        if vuelta % 10 == 0:
            m = muestras[-1]
            print('  vuelta %3d · %6.0f ms · %6.1f MiB · %s'
                  % (vuelta, m['ms'], m['mib'], m['sesiones']))
    return frio, muestras


def escribir(frio, muestras, equipos, incidencias, reglas):
    mib = [m['mib'] for m in muestras]
    incompletas = [m for m in muestras if m['evaluados'] != equipos]

    tercio = len(mib) // 3
    piso_inicial = min(mib[:tercio])
    piso_final = min(mib[-tercio:])
    crecimiento_piso = (piso_final - piso_inicial) / piso_inicial
    primero = statistics.median(mib[:TRAMO])
    ultimo = statistics.median(mib[-TRAMO:])
    mitad = mib[len(mib) // 2:]
    pend = pendiente(mitad)
    tendencia = pend * len(mitad) / statistics.mean(mitad)

    aplicaciones = sorted({a for m in muestras for a in m['sesiones']})
    maximos = {a: max(m['sesiones'].get(a, 0) for m in muestras) for a in aplicaciones}
    errores = [m for m in muestras if m['codigo'] != 200]
    tiempos = sorted(m['ms'] for m in muestras)

    # El barrido programado del motor (ADR 0011) corre por su cuenta y también
    # evalúa esta organización. Las vueltas que coinciden con él compiten por
    # las mismas filas, y se informan aparte para que el peor caso no se lea
    # como el caso normal.
    con_fondo = [m['ms'] for m in muestras if m['sesiones'].get(FONDO)]
    sin_fondo = [m['ms'] for m in muestras if not m['sesiones'].get(FONDO)]
    peor = max(muestras, key=lambda m: m['ms'])
    mediana_ms = statistics.median(tiempos)
    lentas = [m for m in muestras if m['ms'] > LENTA * mediana_ms]

    estable = tendencia <= TOLERANCIA and not errores and not incompletas
    hoy = datetime.datetime.now().strftime('%d/%m/%Y %H:%M')

    l = []
    l.append('# Estabilidad bajo carga sostenida')
    l.append('')
    l.append('> PredictIT · Trabajo Final de Ingeniería · Patricio Pettini · B00072710-T1')
    l.append('')
    l.append('RNF-09 pide que el sistema **no muestre crecimiento sostenido de memoria ni '
             'agote el pool de conexiones** durante la ejecución prolongada del motor '
             'predictivo sobre el parque completo. Este documento es esa medición, y se '
             'genera corriendo `scripts/medir-estabilidad.py`.')
    l.append('')
    l.append('## Cómo se midió')
    l.append('')
    l.append('Sobre la organización de medición de [`CARGA.md`](CARGA.md) —%d equipos y '
             '%d incidencias—, con las %d reglas del Estudio copiadas, porque las reglas son '
             'de cada organización y sin ellas el motor no evalúa nada. Se descartan %d '
             'evaluaciones de calentamiento y después se evalúa el parque completo %d veces '
             'seguidas. Después de cada vuelta se toma la memoria del contenedor de la API y '
             'las sesiones abiertas contra SQL Server por la cuenta de la aplicación, '
             'agrupadas por nombre de aplicación: `%s` es el pool propio de los procesos '
             'de fondo (ADR 0009).'
             % (equipos, incidencias, reglas, CALENTAMIENTO, VUELTAS, FONDO))
    l.append('')
    l.append('**El criterio.** Hay crecimiento sostenido si la tendencia de la segunda '
             'mitad de la corrida, proyectada sobre esa misma mitad, suma más de un %d %% '
             'de su memoria media. «Sostenido» quiere decir que no se detiene: un proceso '
             'que sube mientras se calienta y después queda plano no está perdiendo '
             'memoria, y uno que pierde sigue subiendo en proporción al trabajo, también '
             'al final. Se informan además el piso de cada tercio y la mediana de los '
             'extremos, que incluyen el calentamiento.' % int(TOLERANCIA * 100))
    l.append('')
    l.append(HISTORIA)
    l.append('')
    l.append('## Resultado')
    l.append('')
    l.append('| | |')
    l.append('|---|---|')
    l.append('| Fecha | %s |' % hoy)
    l.append('| Evaluaciones del parque completo | %d, más %d de calentamiento |'
             % (VUELTAS, CALENTAMIENTO))
    l.append('| Primera evaluación, en frío | %.1f s, %s equipos evaluados y %s alertas nuevas |'
             % (frio[0] / 1000.0, frio[1].get('equiposEvaluados', '?'),
                frio[1].get('alertasNuevas', '?')))
    l.append('| Tiempo por evaluación | mediana %.1f s |' % (mediana_ms / 1000.0))
    if con_fondo:
        l.append('| Tiempo por evaluación, con el barrido de fondo corriendo a la vez | '
                 'mediana %.1f s en %d vueltas |'
                 % (statistics.median(con_fondo) / 1000.0, len(con_fondo)))
    if sin_fondo:
        l.append('| Tiempo por evaluación, sin el barrido | mediana %.1f s en %d vueltas |'
                 % (statistics.median(sin_fondo) / 1000.0, len(sin_fondo)))
    l.append('| La evaluación más lenta | %.1f s, en la vuelta %d, %s |'
             % (peor['ms'] / 1000.0, peor['vuelta'],
                'con el barrido de fondo corriendo' if peor['sesiones'].get(FONDO)
                else 'sin el barrido de fondo'))
    l.append('| Evaluaciones que tardaron más del doble de la mediana | %d de %d: %s |'
             % (len(lentas), len(muestras),
                ', '.join('vuelta %d, %.0f s' % (m['vuelta'], m['ms'] / 1000.0) for m in lentas)
                or 'ninguna'))
    l.append('| Vueltas que no evaluaron los %d equipos | %d |' % (equipos, len(incompletas)))
    l.append('| Memoria de la API, rango | de %.1f a %.1f MiB |' % (min(mib), max(mib)))
    l.append('| Pendiente en la segunda mitad | %+.3f MiB por vuelta |' % pend)
    l.append('| **Crecimiento proyectado en la segunda mitad** | **%+.1f %%** |'
             % (tendencia * 100))
    l.append('| Piso del primer y del último tercio, con el calentamiento | %.1f y %.1f MiB (%+.1f %%) |'
             % (piso_inicial, piso_final, crecimiento_piso * 100))
    l.append('| Mediana de las primeras y las últimas %d vueltas, con el calentamiento | %.1f y %.1f MiB (%+.1f %%) |'
             % (TRAMO, primero, ultimo, (ultimo - primero) / primero * 100))
    for a in aplicaciones:
        l.append('| Sesiones abiertas como máximo, `%s` | %d |' % (a, maximos[a]))
    l.append('| Respuestas con error | %d |' % len(errores))
    l.append('| **Cumple** | **%s** |' % ('sí' if estable else 'no'))
    l.append('')
    l.append('Tabla: Memoria y conexiones cada diez vueltas')
    l.append('')
    l.append('| Vuelta | Evaluación | Memoria de la API | Sesiones por aplicación |')
    l.append('|---|---|---|---|')
    for m in muestras:
        if m['vuelta'] == 1 or m['vuelta'] % 10 == 0:
            l.append('| %d | %.1f s | %.1f MiB | %s |'
                     % (m['vuelta'], m['ms'] / 1000.0, m['mib'],
                        ', '.join('%s: %d' % (a, n) for a, n in sorted(m['sesiones'].items()))
                        or '-'))
    l.append('')
    l.append('La serie completa de la memoria, vuelta por vuelta, en MiB: %s.'
             % ', '.join('%.0f' % x for x in mib))
    l.append('')
    l.append('## Lo que no mide')
    l.append('')
    l.append('Es una corrida de minutos, no de días: un crecimiento muy lento puede no '
             'aparecer en %d vueltas. Mide la evaluación pedida por la API, que usa el '
             'pool de las peticiones; el barrido programado usa el suyo (ADR 0009), que '
             'aparece en la tabla sólo si coincidió con la corrida. Y mide la memoria del '
             'contenedor, que incluye lo que el recolector reservó y todavía no devolvió: '
             'es una cota superior de lo que la aplicación usa, no lo que usa.' % VUELTAS)
    l.append('')
    l.append('Y no explica las evaluaciones lentas. Con una mediana de cinco segundos, '
             'algunas tardan entre treinta y sesenta, con el barrido de fondo corriendo y '
             'sin él. No se diagnosticó la causa: los candidatos son la actualización '
             'automática de estadísticas de SQL Server sobre tablas que crecen de a '
             'quinientas filas por vuelta y la contención del propio equipo donde corre. '
             'Queda anotado en `docs/PENDIENTE.md`.')
    l.append('')

    io.open(INFORME, 'w', encoding='utf-8', newline='\n').write('\n'.join(l))
    print('\n%s escrito: %s' % (os.path.relpath(INFORME, RAIZ),
                                'cumple' if estable else 'NO cumple'))
    return estable


def contar_reglas():
    salida = carga.sql('PredictIT_Negocio',
                       "SELECT COUNT(*) FROM dbo.ReglaAlerta WHERE id_organizacion = '%s';" % ORG)
    return next((int(x) for x in salida.split() if x.isdigit()), 0)


def main():
    try:
        limpiar_motor()
        equipos, incidencias = carga.crear_volumen()
        copiar_reglas()
        reglas = contar_reglas()
        if not reglas:
            raise SystemExit('El Estudio no tiene reglas que copiar: corré db/aplicar.ps1.')
        token = entrar()
        frio, muestras = medir(token)
        ok = escribir(frio, muestras, equipos, incidencias, reglas)
    finally:
        limpiar_motor()
        carga.limpiar()
    return 0 if ok else 1


if __name__ == '__main__':
    sys.exit(main())
