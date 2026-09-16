# Versiones de los entregables

Generado el 16/09/2026, sobre el commit `59c6d52`.

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
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.docx` | 32524 | b79fa16391f41c92a0fc7605c88749a9a004c6b12d32688905cb200f9c8cb93e |
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.pdf` | 6671 | b2e3973eae486b43da0330114cdc6747ad6924f10177d8d3ee59ec9e729ac351 |
| `ENTREGA FINAL/02 - Presupuesto financiero.xlsx` | 96 | a87b4db3baddc7d7f3089987fdf0f75b7b0b2cc10052d32ffcfffd1e125b113e |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.docx` | 72 | bd4641160a653e834263479b5fb8aa10e1f3863466838c89eaa32cc7cbb37ca2 |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.pdf` | 954 | 9ba6d8f03a2e046a9bff02d364344b691146085f2cc81afb34aa8b7d404b8c4c |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.docx` | 449 | 2e1cd9dd35413189c30045c91ce5e55d27c620c21738c17cbd190b4153dd84bd |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.pdf` | 945 | 0061c7402ad5a4d25fee44660017e275bdd189d71d20a0144ecf42cdbaabf1c6 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.docx` | 4273 | 8ff413f9600108ea7d958da238957e554f5840050890b1983e407fa2b7af3029 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.pdf` | 2450 | af223adf5034d441990d84a6cdecc12bea3df00cf0cad5954d74bb62a87289b8 |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.docx` | 2043 | d805285129822d1f735a2240429b1c3ce7eb43ee7c4998bb9141d8941c6dd009 |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.pdf` | 1595 | 49aea320c7fd6b4798f776bfcf2998e9d7858330d4d98533c0f328f529352a48 |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.docx` | 379 | c3af68d5bde1e356ffb99ee65d7bf8f30883917430e9a51ebad65fbc482d40d5 |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.pdf` | 866 | 9f18376394f90bff9cdd084deb6f926510122402829f1272abe308d9c4b8b3b0 |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.docx` | 258 | 9d31cbc919ecaabd3c8314ba3bb40accea06f7622d15f6d50d4cf750adc6dfba |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.pdf` | 1021 | 6c65bfb4f4d09ad4090a7b7060f7e77fc95e2d6939a88ce2cfb436b2759e813d |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.docx` | 52 | 9aca9fc081c6a00d0a6c13e66c9e4359d4845f90512c739655f5a0c776ebae2e |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.pdf` | 892 | c342a7c1158cc05b93b5a6174bc2bf341cac1a4074550635e32df19359b0fc58 |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.docx` | 53 | cd3207cd1ec79cfd928f6d2af37aedf75a8651c95e55bd410705df57ea769bbe |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.pdf` | 878 | 2ba0666ae20ff9df8aa0bc920029334d0467be2b436cdae01d1ce478be448ec8 |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.docx` | 517 | 52cc923fc48185e1b83fb744eb98693ade98a73e9eff582788c6b85f7eac9f3f |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.pdf` | 1158 | 78c350cad61f161efd85b51abc2b6f05550fd3ea66d639aa0cd5dc5075a6e2ba |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.docx` | 56 | 244b762bd25e5fceb7d0b06a6a3af892eb785bbc2cdc54a166b48e4198c4ca0c |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.pdf` | 759 | df798585dac4df399a41f68a738102b9625f7ee66e163afb5b4280e26e4a6fea |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).docx` | 84 | dfc184de3d92c81baa517f95520bf77b6ab0360c123be868d4b1a13fbcca7cdc |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).pdf` | 1064 | 2ee17453c8bb1d657338fb605d3e2b9b138f55b25c2014629cd1420400c98252 |
| `ENTREGA FINAL/05 - Documentación técnica/6 - Verificación` | 0 | e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855 |
| `ENTREGA FINAL/05 - Documentación técnica/7 - Modelo Enterprise Architect.eap` | 1968 | 57ab17402c4c42cb52eef55ebcefed700646897bcc94b25349f0bac36205ca7f |
| `ENTREGA FINAL/06 - Panel de obra.html` | 45 | d7ee3fb227c920836f31af5e37b95ca96aebef96ec4a2f0b6f45c39cc221c68f |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.docx` | 146 | e578f5c5af434c9a10579adcb64b48dda38637bd209acbdad3387d54b0ca2a12 |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.pdf` | 1740 | e6792645323a0a21bbfe5713e80713ee4d0157ca320f78bda134e8addac5e136 |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.docx` | 54 | 9380ec53a9047babcade6ea53183f03e3d598847f776d14da810fcb463b9a8e4 |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.pdf` | 728 | c12da1f25749be23172ce18cdf3929b611ca67185b321f5d3bed95b08e45a864 |
| `ENTREGA FINAL/08 - Presentación de la defensa.pdf` | 989 | 6c46a7599d551030a99b8774f62a72dfecc3a2949b2906a11aad87d1731efb92 |
| `ENTREGA FINAL/08 - Presentación de la defensa.pptx` | 1092 | e1eb8fe5554b6b44a23f2c8f60ec8d31dfa3985924bcf6cbf798ac56fb132bb6 |
| `ENTREGA FINAL/LEEME.md` | 9 | 5be689a429a211228e6562c595f6c270c79bb452f162038cea5c65f7c6e6eb87 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/LEEME.md` | 5 | 38b7be3ab9cd927da327d2e8aba1745e070bdbd94cf5ddd3a5eb80086222864f |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.docx` | 80 | 463dbc5dbb16f9d816755b78274448499a8035a865f305f1364e67c03cef3d23 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.pdf` | 892 | 92dac42e6efe8827350cf446f1bdfc1c429344b4c818eeef446bfaaca578804a |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.docx` | 75 | 895d95dd0e21f7d03dfcff9f9a00fcefe18a6c6113f1d7466656d530c92ae89b |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.pdf` | 844 | e7af27282b19d8e630e8ac670cc60b090d924f9d767ad72eb53cfbdb35be060d |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Presupuesto financiero - Entrega 1.xlsx` | 61 | 40ab2273352ae7610c07927087dfadbe217d71ff2621726795afd51ef3d6631d |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/version con color/Plan de negocio - Entrega 1.docx` | 62 | 712c264507cf258b8ad1c57a04fad0f0d8e3ea6cb0f116f245d93b49ba7e08e5 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/version con color/Plan de negocio - Entrega 1.pdf` | 711 | d2503e8ecbdc6f783c56cceb2701fe0845aa2c18f43a39330dc01b2a2f9d4498 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/version con color/Presupuesto financiero - Entrega 1.xlsx` | 50 | eb977bf7c13ab7a9007ad39f957ae75b514689c1313c401f6b859bc7dff9e8c8 |
| `ENTREGA NEGOCIO/SEGUNDA ENTREGA/LEEME.md` | 2 | a8504c1298669724e89a7043edee4bc82697defa01668a0c26de02db2d461fb2 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/1 - Decisiones de arquitectura (ADR).pdf` | 1064 | fa59bb8eedf8760c0bb92652010b35dbcc5633e3e6882e14f80a9f7856f2309b |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/2 - Patrones y principios.pdf` | 759 | 28f8f7c08b0a6315386ad46d221fbaaaa71456bd2bfa09dc46e40b264579c537 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/3 - Diagramas del sistema.pdf` | 1154 | 11fafa874641d78a9a09f5e2509ac33a027d6cc272505913a7ccc96f751d0d12 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/4 - Verificacion OWASP, cobertura y carga.pdf` | 1100 | 52b08b0da7ff759c8e07a0c74d9590b4a4c198a1be208b67aac45e80496b2777 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/5 - Anexo de trazabilidad del uso de IA.pdf` | 954 | c2651f08f1d2c7cccffe0f92317d50a38af02741e708333485a02e675fe4ea13 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Codigo fuente - PredictIT.zip` | 670 | 91680372ecb2294324512e31c7f649c9492ed4f6301e6edbbeac43182b87a70d |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/LEEME.md` | 7 | 0a69409edcf33b2a0f36fe539c20590c284544d6fd3845d898966fe1410bf8d0 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.docx` | 71 | f1b4d856c9baa660328f79af604939471ac18392f40b42774d1c70b12a936cae |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.pdf` | 761 | f954b3a2fce17fe2d8f7150f4bab2ce27314fa01fab484510ef294e984f24ecf |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.docx` | 32442 | 7061c89eaae3fc3f5c4e9e521e0016c04e1e8041c74aebbac1caca908fae0eef |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.pdf` | 5829 | f67fc4e74ab87728e8245094d3c2ac04cd5ce802da4ab48548618501e42a5988 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/LEEME.md` | 1 | a09c637570d3ad15c1ce55d67e5dc673a883b0a50798eb6ac57801bafb7e6140 |
| `LEEME.md` | 2 | 9696eb7cfc20eda7023fdd82408fdffd16949daadfd48e049d3aed517d46953b |
