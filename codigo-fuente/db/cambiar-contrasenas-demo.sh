#!/usr/bin/env bash
# Cambia las contrasenas de los usuarios de demostracion. Version para Linux.
#
# El equivalente en PowerShell -cambiar-contrasenas-demo.ps1- sirve para la
# maquina de desarrollo. Este es para el servidor: la VM de Azure es Ubuntu y
# no tiene PowerShell, y es ahi donde hace falta, porque las contrasenas del
# sistema publicado son las del seed y el seed esta en un repositorio publico.
#
# Genera contrasenas nuevas al azar, las hashea con el mismo algoritmo que la
# aplicacion -PBKDF2-SHA256, 600.000 iteraciones, formato
# PBKDF2$iteraciones$salt$hash- y actualiza la base.
#
# Uso:   ./db/cambiar-contrasenas-demo.sh         muestra el plan, no toca nada
#        ./db/cambiar-contrasenas-demo.sh --si    las cambia
#
# Necesita: docker, python3 (los dos vienen en Ubuntu 24.04) y la contrasena
# de sa en MSSQL_SA_PASSWORD o en el .env del directorio actual.
#
# ESTADO: escrito con las mismas lecciones que la version PowerShell -que si
# esta probada end to end- pero **no probado**. No se puede: desde git-bash en
# Windows, Docker Desktop reescribe las rutas (/tmp pasa a C:	mp) y `docker
# cp` falla antes de llegar a la base. Hay que probarlo en la VM, y el orden
# es el que el propio script sugiere: primero sin --si, que no toca nada, y
# despues con --si **sin cerrar la sesion SSH** hasta haber comprobado que el
# login anda con la contrasena nueva. Si algo sale mal, restaurar-demo.ps1
# tiene su equivalente: borrar las bases y volver a correr los seed.

set -euo pipefail

CONTENEDOR="${CONTENEDOR:-predictit-sql}"
SALIDA="${SALIDA:-credenciales-nuevas.txt}"
AQUI="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

USUARIOS=(admin tecnico1 tecnico2 tecnico3 solicitante partner)
PERFILES=("Administrador" "Responsable Tecnico" "Responsable Tecnico" \
          "Responsable Tecnico" "Usuario Solicitante" "Partner")

# La contrasena de sa: del entorno, o del .env que docker compose ya usa.
if [ -z "${MSSQL_SA_PASSWORD:-}" ] && [ -f "$AQUI/../.env" ]; then
    MSSQL_SA_PASSWORD="$(grep -E '^MSSQL_SA_PASSWORD=' "$AQUI/../.env" | cut -d= -f2- || true)"
fi
if [ -z "${MSSQL_SA_PASSWORD:-}" ]; then
    echo "Falta MSSQL_SA_PASSWORD (en el entorno o en .env)." >&2
    exit 1
fi

if [ "${1:-}" != "--si" ]; then
    cat <<FIN

CAMBIAR LAS CONTRASENAS DE DEMOSTRACION

  Genera una contrasena nueva para cada uno de estos usuarios y reemplaza su
  hash en la base. Las actuales dejan de servir.

FIN
    for i in "${!USUARIOS[@]}"; do
        printf '    %-12s %s\n' "${USUARIOS[$i]}" "${PERFILES[$i]}"
    done
    cat <<FIN

  Las nuevas se escriben en:
      $AQUI/$SALIDA

  Copialas al documento de la entrega y borra el archivo.

  No se hizo nada. Para hacerlo de verdad:
      ./db/cambiar-contrasenas-demo.sh --si

FIN
    exit 0
fi

if ! docker inspect -f '{{.State.Running}}' "$CONTENEDOR" >/dev/null 2>&1; then
    echo "No encuentro el contenedor $CONTENEDOR." >&2
    exit 1
fi

# Las contrasenas y sus hashes salen de python3: bash no tiene PBKDF2, y
# openssl kdf obliga a pasar el salt en hexadecimal y a armar el base64 a
# mano. El formato tiene que ser identico al de HashContrasena.cs o el login
# falla sin decir por que.
GENERADO="$(python3 - "${USUARIOS[@]}" <<'PY'
import base64, hashlib, secrets, sys

SILABAS = ('ba ce di fo gu la me ni ro su ta ve zu pa qui xe').split()
SIMBOLOS = '.-_#'

for usuario in sys.argv[1:]:
    clara = (''.join(secrets.choice(SILABAS) for _ in range(3)).capitalize()
             + str(secrets.randbelow(90) + 10)
             + secrets.choice(SIMBOLOS)
             + secrets.choice(SILABAS))
    salt = secrets.token_bytes(16)
    dk = hashlib.pbkdf2_hmac('sha256', clara.encode('utf-8'), salt, 600000, 32)
    hash_ = 'PBKDF2$600000$%s$%s' % (base64.b64encode(salt).decode(),
                                     base64.b64encode(dk).decode())
    # usuario<TAB>clara<TAB>hash
    print('%s\t%s\t%s' % (usuario, clara, hash_))
PY
)"

# El archivo de credenciales se escribe ANTES de tocar la base: si el UPDATE
# falla a mitad de camino, las contrasenas ya estan a salvo. Al reves se
# aplican y se pierden, y hay que restaurar la demo para recuperar el acceso.
{
    echo "Credenciales de demostracion de PredictIT"
    echo "Generadas el $(date '+%d/%m/%Y %H:%M')"
    echo
    echo "Van al documento de la entrega y al mensaje a la catedra."
    echo "Este archivo NO se versiona: copialas y borralo."
    echo
    i=0
    while IFS=$'\t' read -r usuario clara _; do
        printf '%-12s %-22s %s\n' "$usuario" "$clara" "${PERFILES[$i]}"
        i=$((i + 1))
    done <<< "$GENERADO"
} > "$AQUI/$SALIDA"
chmod 600 "$AQUI/$SALIDA"

# Los UPDATE van en un archivo y se ejecutan con -x, que apaga la sustitucion
# de variables de sqlcmd. Pasarlos con -v no sirve: el salt en base64 suele
# terminar en "==" y sqlcmd lee "==$..." como variable, asi que corta el hash
# por la mitad. El sintoma es un login que falla con la clave recien puesta.
TMP="$(mktemp)"
trap 'rm -f "$TMP"' EXIT
{
    echo "SET NOCOUNT ON;"
    while IFS=$'\t' read -r usuario _ hash_; do
        echo "UPDATE PredictIT_Servicio.dbo.Usuario SET password = '$hash_', intentos_fallidos = 0 WHERE username = '$usuario';"
    done <<< "$GENERADO"
} > "$TMP"

docker cp "$TMP" "$CONTENEDOR:/tmp/pass.sql" >/dev/null
docker exec "$CONTENEDOR" /opt/mssql-tools18/bin/sqlcmd \
    -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -b -I -x -i /tmp/pass.sql >/dev/null
docker exec -u root "$CONTENEDOR" rm -f /tmp/pass.sql >/dev/null 2>&1 || true

echo
while IFS=$'\t' read -r usuario clara _; do
    printf '  %-12s %s\n' "$usuario" "$clara"
done <<< "$GENERADO"

cat <<FIN

Escritas tambien en: $AQUI/$SALIDA

Falta, y es lo que deja el sistema inaccesible si no se hace:
  1. Copiar estas credenciales al documento de la entrega.
  2. Probar el login con una de ellas ANTES de cerrar la sesion.
  3. Borrar el archivo de arriba.
FIN
