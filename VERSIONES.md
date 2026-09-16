# Versiones de los entregables

Generado el 16/09/2026, sobre el commit `192f112`.

**Esta carpeta es lo que se entrega.** Todo lo que esta en `docs/` es la fuente
con la que se arma: se trabaja ahi, pero no se entrega desde ahi. Si un archivo
de `docs/` y uno de `ENTREGABLES/` dicen cosas distintas, el bueno es el de aca,
porque es el que salio de la ultima corrida de `_armar-entregables.py`.

**Como comprobar que lo que se abrio es esta version.** Las fechas de archivo no
sirven: `git clone` le pone a todo la fecha en que se clono. El sha-256 si.

```bash
cd ENTREGABLES
sha256sum -c <(awk -F'|' '/^\| `/ {gsub(/[` ]/,"",$2); gsub(/ /,"",$4); print $4"  "$2}' VERSIONES.md)
```

En PowerShell, para un archivo suelto:

```powershell
Get-FileHash -Algorithm SHA256 "ENTREGA FINAL\01 - Documento del Trabajo Final v2.pdf"
```

## Los 58 archivos

| Archivo | KB | sha-256 |
|---|---|---|
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.docx` | 32607 | f237cb7f06bd8d44c5ded58a72407fc167ff8b9b40ad19f34b2f538533582932 |
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.pdf` | 6632 | 513467f7194166881f5d0bf8e752e9618e2b8bf40ac8615391392e13df718115 |
| `ENTREGA FINAL/02 - Presupuesto financiero.xlsx` | 96 | e1b08be76f609212d7e2921e9665affee5d25dd1464be847ca5f6bc55f20c618 |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.docx` | 72 | fd9bdd66e9f4ea078fcaf9ebc962bbbfa9b1f97ff3f1cd35f65cb2e41a3a320e |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.pdf` | 954 | c2651f08f1d2c7cccffe0f92317d50a38af02741e708333485a02e675fe4ea13 |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.docx` | 449 | 830acdca7c74ba01174ec626dd11addc6c3b82c091d5db686418ea214af54146 |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.pdf` | 945 | c17cb9f65413042a0de6d3f6751fc4e2f35a6055ad33e030d2fd8d2fe019f949 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.docx` | 4273 | d961cdc7572cfdb953c6b870f28c1372bf0c2e0ae82f41dffbdfc9e6c70c5f31 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.pdf` | 2450 | 3c22aa94d2dde6da32e9b96e3d19b289bd2ca311f8189f4f0f191d601801c05c |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.docx` | 2043 | 448994b0d37856ba57b9b5c319d73b239bafac089daa26b026c3f79b309a0102 |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.pdf` | 1595 | 8f4c2ca31063e9998b3e7ce36eb7c4cecb2e1bd163f972d317a23c37a00142ea |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.docx` | 379 | d2f36c0c8bce69867000fcd13734fcf7684e619cbefd447afec95171e08e4228 |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.pdf` | 866 | 4a7f746f4b846dd1855397cd8b180114bad660b500ffaf5d2d1f4d62bae2af5f |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.docx` | 258 | a98795abaf6bc2715664751b83791e10c50f2d28834a9b77d03a2f6dd64f147f |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.pdf` | 1021 | 5bc2a353adfb00f13d7fd75768cba8d3a47604ed87da46a040435f806e1566be |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.docx` | 52 | 851ee1bf9dfb2089d37af2fb71ee5c7724001ebd41349a25ffeeaa84817e94ee |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.pdf` | 892 | dcdbc6e5b69ed973ed1c4849e8b1359a4bf16d00ef2015f9eefff01e86328ebd |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.docx` | 53 | 9a1f116248c8495818fc54f1cd356064099a60d2a79f65ecb649b57f26a13a30 |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.pdf` | 878 | 09246bb10a8ba8830a4ac29becc916b2d2a9b3305f9fd372e7467a4dd388f68c |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.docx` | 600 | 735bfa796a7ef62866c880bf5369b50b7437d74485d0b0553c5f3fd3e76bc8c5 |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.pdf` | 1154 | 11fafa874641d78a9a09f5e2509ac33a027d6cc272505913a7ccc96f751d0d12 |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.docx` | 56 | 47cd76c9cc88674356e62833b3b64db1438beae827a4d488a77d5e9f9203d076 |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.pdf` | 759 | 28f8f7c08b0a6315386ad46d221fbaaaa71456bd2bfa09dc46e40b264579c537 |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).docx` | 84 | e140cb904f4cb4f424b6739c46c846c92d12c01375cf280c4e6259c7986bae94 |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).pdf` | 1064 | fa59bb8eedf8760c0bb92652010b35dbcc5633e3e6882e14f80a9f7856f2309b |
| `ENTREGA FINAL/05 - Documentación técnica/6 - Verificación` | 0 | e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855 |
| `ENTREGA FINAL/05 - Documentación técnica/7 - Modelo Enterprise Architect.eap` | 1966 | d834a9c0ebca27601b052af77485b8d5758e4fe858c9fa602f8fc07b1fa6ae45 |
| `ENTREGA FINAL/06 - Panel de obra.html` | 45 | d7ee3fb227c920836f31af5e37b95ca96aebef96ec4a2f0b6f45c39cc221c68f |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.docx` | 143 | a2d69b3a7b4394c73b944fb9f143f7ec887d52e2967b7a614206809a5aa44525 |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.pdf` | 1723 | 406d83d03c75987c6673dc38ab26fbc02f06985d2a92d7a2ed36c1bde4f5dc3e |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.docx` | 54 | f810c143d1eb59fed870b0d19bee5315b9a229bca0167998aab968192bb0e294 |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.pdf` | 728 | 6e1438af7941b81a7a6db2dfe879335045a2be1c3faeeef6942255d47e0ed399 |
| `ENTREGA FINAL/08 - Presentación de la defensa.pdf` | 989 | f208283db2243e8d846bb10ad68ceaa6f98638952b560c0f07e07d8b965c89f4 |
| `ENTREGA FINAL/08 - Presentación de la defensa.pptx` | 1092 | cd192a5748a616af264d955559d9b7c0b4ef26db3e5d6cc778198fa568c4d888 |
| `ENTREGA FINAL/LEEME.md` | 9 | 5be689a429a211228e6562c595f6c270c79bb452f162038cea5c65f7c6e6eb87 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/LEEME.md` | 5 | 38b7be3ab9cd927da327d2e8aba1745e070bdbd94cf5ddd3a5eb80086222864f |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.docx` | 80 | 2d8eda6f4e5e3e46210a1013736e1e76f342c7ebb05f047172f82e9fc595e6ad |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.pdf` | 892 | cdb009ea5205f8f10b70ec37f8b8558368fac49e330d49cff385fc2edb6baedc |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.docx` | 75 | 54f4cb8873af650ab6719cd9d596f62ef0c827321c02e37e7628496c9f087e28 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.pdf` | 844 | c895197e79af8cdbe59588eef7290bb0f277a1e688af66be5ff89978f92a3c6a |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Presupuesto financiero - Entrega 1.xlsx` | 61 | ab0317d85515f45a487bb63d78a39cbecb0ad0a12a29661aa69ae71633765c6b |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/version con color/Plan de negocio - Entrega 1.docx` | 62 | 712c264507cf258b8ad1c57a04fad0f0d8e3ea6cb0f116f245d93b49ba7e08e5 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/version con color/Plan de negocio - Entrega 1.pdf` | 711 | a1eced15e98295e4bf25f5441a281ebfcafb289e7ead3e1e7b585c02a1947876 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/version con color/Presupuesto financiero - Entrega 1.xlsx` | 50 | eb977bf7c13ab7a9007ad39f957ae75b514689c1313c401f6b859bc7dff9e8c8 |
| `ENTREGA NEGOCIO/SEGUNDA ENTREGA/LEEME.md` | 2 | a8504c1298669724e89a7043edee4bc82697defa01668a0c26de02db2d461fb2 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/1 - Decisiones de arquitectura (ADR).pdf` | 1064 | 7ad4afd488c8433068f8bba1a4ff9dc2f7a14fb6da52e41bec3c6378ea9004b3 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/2 - Patrones y principios.pdf` | 759 | 18e10452f71e1b837b74db513d081ea6b93b1fb4816750e7fcc49e8b64a930bf |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/3 - Diagramas del sistema.pdf` | 1154 | d7fdf771d897656835c79e85cddcd9a0defc09a480f8dc59ce4a4d8e64879ac5 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/4 - Verificacion OWASP, cobertura y carga.pdf` | 1100 | 81f63853d7fe8e8138dace43d2b82562d5cff5de97046c811437ff27ffc785b3 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/5 - Anexo de trazabilidad del uso de IA.pdf` | 954 | bb05e28211427274b0a949d93b20c41186ca38af7ba3fdfbed8afdf30ab1264a |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Codigo fuente - PredictIT.zip` | 668 | c0338757b98250c0a428d71434ac71559f189c746056710a3d58ce8a0d13903d |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/LEEME.md` | 5 | fa5d5df9bca08c522e677a161994159f3ed57c9e8bc761e3cebdafaeb7088005 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.docx` | 78 | dfcfcea73372c76ce18e3a416183322b0e48337bc140f4e0e99201c6f115b908 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.pdf` | 900 | 45bc9502ba9e57e8426ccaeba6ba3d732d8c24e12416ef19cfb617bc7cf0403f |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.docx` | 32525 | 9c7c050dd2db09c5594342dcd91098b385018c622c3783635a97e174d092cc84 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.pdf` | 5790 | 413996196537e4dd519fafb24aa06730abadeb8890102c080d962f7120c7d0c5 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/LEEME.md` | 1 | a09c637570d3ad15c1ce55d67e5dc673a883b0a50798eb6ac57801bafb7e6140 |
| `LEEME.md` | 2 | 9696eb7cfc20eda7023fdd82408fdffd16949daadfd48e049d3aed517d46953b |
