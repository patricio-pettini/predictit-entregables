#!/usr/bin/env bash
# Deja la demostracion como recien instalada. Version para Linux.
#
# El equivalente en PowerShell -restaurar-demo.ps1- sirve para la maquina de
# desarrollo. Este es para el servidor: la VM de Azure es Ubuntu y no tiene
# PowerShell, y es ahi donde mas hace falta, porque es la instancia que abre
# el profesor.
#
# Hace de una las dos cosas que alla hacen dos scripts: borra las dos bases y
# vuelve a aplicar esquemas y datos iniciales. No existe un `aplicar.sh`, asi
# que los seis scripts se aplican aca.
#
# POR QUE HACE FALTA, y no alcanza con reaplicar: los scripts de datos solo
# insertan lo que falta, de modo que no reponen lo que alguien borro ni
# refrescan lo que quedo viejo. Y las fechas de la demostracion se calculan con
# DATEADD contra el momento de la carga: a las pocas semanas el equipo que el
# seed disena con cuatro incidencias en treinta dias se queda con dos, y el
# analisis predictivo deja de mostrar la recurrencia que esta puesta para que
# se vea.
#
# ES DESTRUCTIVO Y A PROPOSITO. Sin --si no hace nada: muestra el plan y sale.
# Nunca se corre contra una base que no sea la de demostracion.
#
# Uso:   ./db/restaurar-demo.sh         muestra el plan, no toca nada
#        ./db/restaurar-demo.sh --si    borra y rehace
#
# Necesita: docker, y las dos contrasenas en el entorno o en el .env del
# proyecto -MSSQL_SA_PASSWORD y PREDICTIT_DB_PASSWORD-.
#
# Probado el 20/10/2026 contra el contenedor local desde git-bash, con
# MSYS_NO_PATHCONV=1 para que Docker Desktop no reescriba las rutas. Las dos
# bases se borraron y volvieron con sus 20 incidencias, 54 equipos y 6
# usuarios, y el equipo PC-ADM-014 volvio a tener sus cuatro incidencias en la
# ventana de treinta dias. Falta probarlo en la VM, que es Linux de verdad y
# no tiene el problema de rutas.

set -euo pipefail

CONTENEDOR="${CONTENEDOR:-predictit-sql}"
AQUI="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
BASES=(PredictIT_Negocio PredictIT_Servicio)
ESQUEMAS=(01-negocio-schema.sql 02-servicio-schema.sql)
DATOS=(03-seed-servicio.sql 04-seed-negocio.sql 05-seed-traducciones.sql)

# Docker Desktop sobre git-bash convierte /tmp/db en una ruta de Windows y el
# copiado falla antes de llegar a la base. En Linux la variable no molesta.
export MSYS_NO_PATHCONV=1

# Docker Desktop no entiende las rutas de git-bash -/c/Users/... le llega como
# C:\c- asi que en Windows el origen del copiado se traduce. En Linux cygpath
# no existe y la ruta se usa tal cual, que es lo correcto alla.
ruta_local() {
    if command -v cygpath >/dev/null 2>&1; then cygpath -w "$1"; else printf '%s' "$1"; fi
}

leer_del_env() {
    [ -f "$AQUI/../.env" ] || return 0
    grep -E "^$1=" "$AQUI/../.env" | head -1 | cut -d= -f2- || true
}

[ -n "${MSSQL_SA_PASSWORD:-}" ]     || MSSQL_SA_PASSWORD="$(leer_del_env MSSQL_SA_PASSWORD)"
[ -n "${PREDICTIT_DB_PASSWORD:-}" ] || PREDICTIT_DB_PASSWORD="$(leer_del_env PREDICTIT_DB_PASSWORD)"

if [ -z "${MSSQL_SA_PASSWORD:-}" ]; then
    echo "Falta MSSQL_SA_PASSWORD (en el entorno o en .env)." >&2
    exit 1
fi

sql() {
    docker exec "$CONTENEDOR" /opt/mssql-tools18/bin/sqlcmd \
        -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -b -I "$@"
}

if [ "${1:-}" != "--si" ]; then
    cat <<TEXTO

RESTAURAR LA DEMOSTRACION

  Esto BORRA las dos bases del contenedor y las vuelve a crear desde los
  scripts de db/. Se pierde todo lo que haya cargado cualquiera desde la
  ultima restauracion.

    Contenedor : $CONTENEDOR
    Bases      : ${BASES[*]}

  No se hizo nada. Para hacerlo de verdad:
      ./db/restaurar-demo.sh --si

TEXTO
    exit 0
fi

if [ "$(docker inspect -f '{{.State.Running}}' "$CONTENEDOR" 2>/dev/null)" != "true" ]; then
    echo "El contenedor $CONTENEDOR no esta corriendo." >&2
    exit 1
fi

# SINGLE_USER con rollback: si queda una sesion abierta -la API- el DROP se
# cuelga esperando. Asi se corta lo que haya y se borra igual.
for b in "${BASES[@]}"; do
    echo "-> borrando $b"
    sql -Q "IF DB_ID(N'$b') IS NOT NULL
            BEGIN
                ALTER DATABASE [$b] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                DROP DATABASE [$b];
            END" >/dev/null
done

echo
echo "Bases borradas. Rehaciendo esquemas y datos..."
echo

docker exec "$CONTENEDOR" mkdir -p /tmp/db >/dev/null

# -f 65001: los scripts tienen acentos y estan en UTF-8.
# -I: QUOTED_IDENTIFIER ON, que sqlcmd deja en OFF y rompe los indices
#     filtrados (WHERE ... IS NOT NULL).
for s in "${ESQUEMAS[@]}" "${DATOS[@]}"; do
    [ -f "$AQUI/$s" ] || { echo "No existe $AQUI/$s" >&2; exit 1; }
    docker cp "$(ruta_local "$AQUI/$s")" "$CONTENEDOR:/tmp/db/$s" >/dev/null
    echo "-> $s"
    sql -f 65001 -i "/tmp/db/$s" >/dev/null
done

# El usuario de la aplicacion va al final: necesita que las dos bases existan.
# La contrasena viaja como variable de sqlcmd y nunca escrita en el .sql. Si
# alguna vez contiene un "$" seguido de letras, sqlcmd la va a interpretar como
# otra variable: el sintoma seria un login que falla con la clave correcta.
if [ -n "${PREDICTIT_DB_PASSWORD:-}" ]; then
    s=06-usuario-de-aplicacion.sql
    docker cp "$(ruta_local "$AQUI/$s")" "$CONTENEDOR:/tmp/db/$s" >/dev/null
    echo "-> $s"
    sql -f 65001 -v APP_PASSWORD="$PREDICTIT_DB_PASSWORD" -i "/tmp/db/$s" >/dev/null
else
    echo "Sin PREDICTIT_DB_PASSWORD: no se creo el usuario de aplicacion." >&2
fi

echo
echo "Demostracion restaurada."
echo "Reinicia la API para que tome las bases nuevas:"
echo "    docker compose restart api"
echo
echo "El barrido predictivo vuelve a generar las alertas en unos minutos."
