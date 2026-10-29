# Versiones de los entregables

Generado el 29/10/2026. `codigo-fuente/` y `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/` salen del commit `08b2b2a` del repositorio de trabajo; el resto, del `6e73ad2` (17/09).

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

## Los 328 archivos

| Archivo | KB | sha-256 |
|---|---|---|
| `.gitattributes` | 1 | cde1e1f7ca111320200c5291d579ee3815bfd5726c350c83e15f7ef7ca383cb1 |
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.docx` | 32535 | 5154bbc7c58d8f5076777316d6dcd0cd96ded4cbf880b13f2fd76299797599f0 |
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.pdf` | 5969 | 88d89a9408a25f9b153c196e491785ef630a2a225463b92fd04a63cc224e19d4 |
| `ENTREGA FINAL/02 - Presupuesto financiero.xlsx` | 121 | 9cba8e93fdc7ed5c4f3fdeef5af656f55830d14d605717c9d288478d36a680f5 |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.docx` | 72 | 6714997d8b8384655033a5a04b8b9d7fc6660ba242b31c23dd92a65fe43b6a61 |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.pdf` | 954 | a7ae08b7423cbf8a232275a581fc54c5d3b3269038c9e6d0819ddc4e536af7fc |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.docx` | 449 | 4bfe72940a48659f437354cd5e719e3b897e67f47f95f0bd448ade362a157422 |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.pdf` | 945 | 2f85eaff974c02e78d0fe27e54a20e2191fdd4d23e4648f6748aa770fbe1ec48 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.docx` | 4273 | 1302d99f5cd23a434068afe298c02c8f2491adbfa3360f774076c592e77922e4 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.pdf` | 2452 | 819c57ad9e35d11e5607f391e7d9bf7851146dc0ae29404be7952f2e8ec0af9c |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.docx` | 2043 | ad46516f754f9ea410f83664e80d1125d20856ac4d793361a6eb198a6ee08494 |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.pdf` | 1596 | 9e7827017874997b1355e580150d8ff8b13b767d79afe10e99f398898a4cda0d |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.docx` | 379 | 791caf95f15486ea6fbe99abb077ddcd8352aaf76e56fa56d891b154a2a628ad |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.pdf` | 866 | 910a62a0b0afe442d13d41790e23a5a037744dc913632d30a18ea47b4bbcd516 |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.docx` | 258 | 6dbf6dfe7b62582aedd61d395b38043dc851926a0d940a032e88ab528879afc9 |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.pdf` | 1022 | cd30ed45375e73f866579eff7160b688930642b5cf65f3ff339514b3c881476d |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.docx` | 52 | 28b7ab2c7afe98e437388134f9cc0ebbd093cc63fc291c29804ffc4a619de21e |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.pdf` | 892 | 615c49b27c082e2d745ce58c9877ffe845b294e192a90befb1ee07aabbaf6baa |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.docx` | 53 | c897eb9f6061249c0fcfb0813e22ae689200a03cd0986e1b93da370ab5ac8046 |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.pdf` | 879 | 75f9b89138c2482bea0780d3d6ed544d9e0a1154e73414dd51bda44698fb4677 |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.docx` | 517 | 6c7d1dd22377acaa9e93c2a0cc1ff9091f70f8f3965c85e7f27bf6fcae159483 |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.pdf` | 1158 | b4a350614f03eff2de4ba336c8c51ecee9d8430e74fea39906bd334caf46a8f5 |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.docx` | 56 | d4bda2de07431a65d7a9d210e0acd22a1db0aaf8d93bb85e011dd344abfd5ba9 |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.pdf` | 759 | 4541ef79004b97030211daa615ffada6f9a07ab3c68711954f020cab665829ef |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).docx` | 84 | 2d541142e0bd2a158a31fdaacd7cb871a1f3c95b7f90d6d3893012a1de077d78 |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).pdf` | 1064 | 3e868dccf82ac860a69498eb62df234b208dff4accb2af4eafd3f3d4093c3ffb |
| `ENTREGA FINAL/05 - Documentación técnica/6 - Verificación` | 0 | e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855 |
| `ENTREGA FINAL/05 - Documentación técnica/7 - Modelo Enterprise Architect.eap` | 1972 | c1d5851e325ef9b25048fa22c2d0a94097a4c956b3d529f8ffa0cf9cc01c9e0d |
| `ENTREGA FINAL/06 - Panel de obra.html` | 45 | d7ee3fb227c920836f31af5e37b95ca96aebef96ec4a2f0b6f45c39cc221c68f |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.docx` | 153 | 6ecce4569da7f85db7a00dd1dd7f5a5572ceab555abfe6355ab35febbd5e43ba |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.pdf` | 1787 | d3393e3910f607ca9c7e79abac9d9f8f61eecb721245830a295c3d370162b359 |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.docx` | 54 | fd10f3137bb2ee7661eb5c47201f57389b5b27c6e235a0f4489c88f0dc34ffb1 |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.pdf` | 728 | f730a4cc2ce5503baa42c497eb4018f4ac4a327d9fcc22edcf18b35cb003e296 |
| `ENTREGA FINAL/08 - Presentación de la defensa.pdf` | 989 | 16c947654c34695e60eca093b9b5ad6453fa53582d13d9735a522a5cb291435c |
| `ENTREGA FINAL/08 - Presentación de la defensa.pptx` | 1092 | e002bd32280c042fc72cd4ad46d14b0b5fdd81d5696f1c149ed4bc0d9fba4b38 |
| `ENTREGA FINAL/LEEME.md` | 9 | 5be689a429a211228e6562c595f6c270c79bb452f162038cea5c65f7c6e6eb87 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Documento del Trabajo Final - capitulos 1 a 8.docx` | 221 | e9972a9baacd9b181566e77b40a98f2b72bb9911d485ea33aa35ae123e83b4f5 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Documento del Trabajo Final - capitulos 1 a 8.pdf` | 1142 | 166e586ee7face9313e3069919deeb18c375bda30348257325553bf0600c7b41 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/LEEME.md` | 6 | 5d2e580484dc3d8af859f51e1aacf22c44d30a431c61a166173ed5e7cde343be |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.docx` | 88 | ef709724a8a5dd0ef81ea3be07c494586ef54eeb3109be9db934b80441dfafdd |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.pdf` | 655 | c1a8c25334470ae3ae43440cb67268db39a70451b2150b2d53202de925d485c0 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.docx` | 76 | d6ba0ad2d291e1cd5b8cb781f3edd3cae61ad0c56e1e718df12f7dd9e5b1b16e |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.pdf` | 514 | e124cc92f24bc21eaa076448a739426af14269de8ba5f5a2f4019f98aaf41061 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Presupuesto financiero - Entrega 1.xlsx` | 74 | 2f9961243c0ce94b35da263707f317d61f17218dce436c22d5df1df7028a43b0 |
| `ENTREGA NEGOCIO/SEGUNDA ENTREGA/LEEME.md` | 2 | a8504c1298669724e89a7043edee4bc82697defa01668a0c26de02db2d461fb2 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/3 - Diagramas del sistema.pdf` | 1158 | c24d4a49f43f452eed80c351a513728f096a94c190de206e9adc4bdc912c6b3c |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/5 - Anexo de trazabilidad del uso de IA.pdf` | 954 | c39dd1292fd29a1d5f530ad3f7cad97dfd852ebc6fe8d3d37eb6be087140365a |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.docx` | 72 | 81329870f4fd24f3347882cd1bb4255d2b98c33197d09c9b7bdb830fdb7c2f19 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.pdf` | 504 | 61a40b989582fe043c123cfc1fa4c4f02a51d5947c7b15ab8a8974c438611677 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.docx` | 32442 | 0bedd9a5942efdc82933e75cd4a16387bf3d012331f637607e12a577292729bb |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.pdf` | 5833 | 854c526f812a53367e5aa3f7f7fd83f509d30c647aac0804942c2c0426fa37b1 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/1 - Decisiones de arquitectura (ADR).pdf` | 924 | c5e569114a0a0334c9f6bb3c32cf78713ab4642b39f54550aabff97b3e52fda7 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/2 - Patrones y principios.pdf` | 435 | f69982bb4271755bb56c5315ba992a3142a9f704edec172696aa0512bead1989 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/3 - Diagramas del sistema.pdf` | 781 | 114479f44e58706e4efa8923063a037c0ef74e87b18addfa2b2b7e061b1824f5 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/4 - Verificacion OWASP, cobertura y carga.pdf` | 869 | 5bd599c7c2d4c9f2be290fa913bd1375541c50b0dc191bfc0c2688d8fcf726f0 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/5 - Matriz de trazabilidad de requisitos.pdf` | 376 | f02d627e617f3e541ef2a481b3e9c6b75fb6d0dd8879e7339af35559fec909e7 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/6 - Anexo de trazabilidad del uso de IA.pdf` | 806 | fcf73d9775bf80f959c848a5d83b083167b7e4edc82afa20a36d5eb9985e2090 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/LEEME.md` | 5 | 2b6ba08d1466fc79ba052b76f08df6aa0cb372d73209e74635cc87b90495a229 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/Log de prompts - Sistema.docx` | 88 | 36793e39b767e1bd248ca1461b2433bd231fbd36fd560af068ac74038b5562ec |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/Log de prompts - Sistema.pdf` | 504 | dc64e45859f60237f1ad1a15b72591a1dfc6e430a7014c798d254c0fdfd5f6f8 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/Solucion tecnologica - Entrega 2.docx` | 9433 | e1254621c228a8b01575b95a8c5f5596c1394745b514cca62575418444973309 |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/Solucion tecnologica - Entrega 2.pdf` | 5717 | aa6e2b1cfa868413ed5e9ecd87d81860348a50b8f0f3dadedd1a4586648a7c18 |
| `LEEME.md` | 2 | 8997b520407838d0709598b331006e430b763a4009d5f317538ec49ce3df6535 |
| `README.md` | 4 | c17f654e18b6eb94c8dc93b9cc7fde30f2060c74a38087f1184fdd25e4048c01 |
| `codigo-fuente/.env.ejemplo` | 3 | 4ac8ec59c70836a9d7fdf82775d50234b53c03aa0f7294b59b71703796187acb |
| `codigo-fuente/.github/workflows/ci.yml` | 13 | 0251b84ad5d3ffc2665296a3f64469cd9e72446702c9a0fdffd833aae713542d |
| `codigo-fuente/.gitignore` | 2 | b55d227691346d89e06938907d67be1977a7f60d51dc2edee80d51779bc735f4 |
| `codigo-fuente/CLAUDE.md` | 8 | a1db5fd0784125d797b71f0a5ae9f3d588dbe4797a26ec8342118608678f3f5c |
| `codigo-fuente/COMO-EJECUTAR.md` | 5 | cf99f8490ba61675245c14e88ccb16135559126b5d918354e020fed258d014cf |
| `codigo-fuente/LICENSE` | 3 | 9ab8d5e1fc980b18ebcb57196025695a7e7068a095b104f5324f4aa4f53bb9e0 |
| `codigo-fuente/README.md` | 10 | 0b6a7e919e48cc525a4268679c741098cd6e354edbc8b8c769ab7cf1e5d72b39 |
| `codigo-fuente/arrancar.ps1` | 9 | 18d8088f7b0665d7c5e88dfbedf8f7234c31de68b26c002e826a48d7d25e144e |
| `codigo-fuente/backend/.dockerignore` | 1 | b2c85e253a5a83149f1105486c01e2f11d1296d65ab73dd2e6aaecb379ce36e7 |
| `codigo-fuente/backend/Backup/PredictIT.sln` | 8 | 6390bb17760bfb6c38301138a4c8f229f2b9640c1080324a1d4cf8dd30059528 |
| `codigo-fuente/backend/Directory.Build.props` | 2 | 4903ed9fa3b8ac318dec4a186ea9960a07249d7c37ee34ad3a79fa860271dbdd |
| `codigo-fuente/backend/Dockerfile` | 4 | 013262616b9987fd78377c319d7b30ab59c8d73aeb0e566c0868fda314af3d68 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/AdministracionController.cs` | 15 | 65104c0149c6174a0de221256f0ec7d19fcbda6c1968f23a44906a34ae86fba3 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/AutenticacionController.cs` | 4 | 8116ede87093b1bbe6da3c92453fa920635ef798c1635349a11adf8bae929125 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/EquiposController.cs` | 7 | 952026e01c62acd5bbf1661ee5679cb731eae6a61ec22b5d5eb30842b7b46941 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/IdiomasController.cs` | 3 | dd9e21bf5f3cb5ea7b34ff763033450b461e315867a314cf7b3c81c23097844b |
| `codigo-fuente/backend/PredictIT.Api/Controllers/IncidenciasController.cs` | 9 | e8951ec8c8d6bf427a25db374ce43773b365b0f2a7b21cdca4a3d85cb9e729d6 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/ReportesController.cs` | 2 | 285e8f21c724f26f4de80298c02d1952b84e5b337fa029e09d85d3d1c6d9a5dc |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/BarridoPredictivo.cs` | 6 | 6a3e62289b47b879b9022c2bb7dcbdc0de0b0ae52e11511750f0fae8e0a807b2 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/CabecerasDeSeguridad.cs` | 3 | 3e14ea2b8cd9cab21f41169e07b21306aa695fc9cf9d724e9532106703e7ba54 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/ManejadorDeExcepciones.cs` | 4 | 647c193310891d45c2a54970bd174eddb2ab246dcc26efb6dfe5e9ac52a66467 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/Metricas.cs` | 4 | f31a5dad9e4d589b0f8535cf0f563e236268c38dae692f121f9429d948621d34 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/Politicas.cs` | 1 | 13249001c954c4543132ca2fb96df4aa22afb9c9ec3db3c29ddc8efd32fe43da |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/RequierePatenteAttribute.cs` | 3 | 91c657449a06173ce10cc62462899c4f9d54944debf384c292fc382613034f4f |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/RespaldoAutomatico.cs` | 4 | 8068f8c1b97e6aa56d7772a40ab5e53256c2e1215f70793fe778a240710c8659 |
| `codigo-fuente/backend/PredictIT.Api/PredictIT.Api.csproj` | 2 | a7a4b15cecc04b05bd689096c822810ad1ce0e094822619e7fa43b0a960b9821 |
| `codigo-fuente/backend/PredictIT.Api/PredictIT.Api.http` | 1 | 6559e079440f78716de6f39d385177e54b23fdeebe60e9835209df040f966b47 |
| `codigo-fuente/backend/PredictIT.Api/Program.cs` | 22 | 9188222ef52db34dc7bc10da78d6843fafcae734138a60fb451023c2fe1a0c3f |
| `codigo-fuente/backend/PredictIT.Api/Properties/launchSettings.json` | 1 | 97073825a96ae8fb5c1b090685defabc66c17367a667a87cd127a8c1883a9dfe |
| `codigo-fuente/backend/PredictIT.Api/appsettings.Development.json.ejemplo` | 2 | 0763855fa29cb1628c3f9edd95c67685b4aa8451cc75e5499881d11aa4d41ee4 |
| `codigo-fuente/backend/PredictIT.Api/appsettings.json` | 2 | f456e44842baee8dfc2e7ae5b68fea34b49b86e4cee11f62f4f18ed85c3bd492 |
| `codigo-fuente/backend/PredictIT.Api/packages.lock.json` | 17 | 9804403e4a2ad4ebb8cfa5951cb85f9ad814bebf02ea275dd589059ec6657b20 |
| `codigo-fuente/backend/PredictIT.BLL/BusinessException.cs` | 2 | b477cb568aedf101e7aceeb88afb1657c125ca0d16d979494bf64e7d9229d3c4 |
| `codigo-fuente/backend/PredictIT.BLL/Contracts/Contratos.cs` | 17 | 0852ee369146d2921a22f8b790c673cf579656ec7a4cbc5627ba8060c14af855 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/Dtos.cs` | 8 | 9ca173f1ca8f0b0996d7e0ee6499b3f6ec3eb2fbb8c14f50ccb4e0d725da160b |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosAdministracion.cs` | 10 | f3414427677097419f69cc49182ed6aced009bcec86bc89ba3505d887d186ae7 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosFacturacion.cs` | 3 | 8f749bb75d752ff0a1f161135191c0f8c476f52d5379c9f978fa33f31714da39 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosIdioma.cs` | 2 | 2835282f974d8f33f675a0be95c4a661d6c43145edce91b07270d7fd602a4cdf |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosIncidencia.cs` | 11 | 2c81a667caf4e5d92babe94782b71b7ae05a52545584e62696346322e38f1a1b |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosMantenimientoProgramado.cs` | 3 | 422b41031f475b9e0305396415e9766bb341648c97aa5557ed9e1cd5fae237b0 |
| `codigo-fuente/backend/PredictIT.BLL/FactoryBusiness.cs` | 7 | 9c00932ce8c37970a457e9a569316e6c0de0f150c7d138592ae1c087dac44c13 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/AuditoriaBusiness.cs` | 4 | 537da9fd014c9dd1b72ca3ed696c5506e92b08b1f774302d7b387919ea3010b0 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/AutenticacionBusiness.cs` | 8 | a4a352aae7c7131e88f0b12df4c359f28484dd0c178eb893fd7e9104789fc2bc |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/BaseAdministracion.cs` | 3 | 5c351e09901cdb3ab8f6b4569ebe89bf2c41d449fb1781dfdfe9e952b8cc7dca |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/BitacoraDeLaSesion.cs` | 4 | a09ed3b251a50465c87957faf0873176892eb19c5e3d902f21c180bbbcc8b86b |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/EquipoBusiness.cs` | 14 | 8beef7e2ca606c222dd6ad2d587d61d7fa9c98221585d7fd8d08dece42e00a1d |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/FacturacionBusiness.cs` | 15 | 768af482f4c8d5729095b475cb905366269b896e3e91c95fc64070a93c8832ea |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/IdiomaBusiness.cs` | 5 | 3d24a0fcf38005b04a3c563d21198424146fe29b069e729a52eb9f1834d61771 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/IncidenciaBusiness.cs` | 41 | 9d495845403806d092f3468771ba9b73d8fdab7f4564cdb63a649ca49ff57f99 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/IntegracionIaBusiness.cs` | 8 | ace447eb07adf3d7072c0303c443ed02f3a7f2e5774c312e1835cdeca8b07d06 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/MantenimientoBusiness.cs` | 10 | 5b42ea0042d12ae2b16c43f2ea793aa1735508127b0d532c2f7c9086ef9f3958 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/MantenimientoProgramadoBusiness.cs` | 14 | 77828e3c7f2e2f785ff6703977d76132b89aea53e8782a8b5beeb2afaeafd6fd |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/OrganizacionBusiness.cs` | 9 | ef3152804fd7267cbe45fef836a6b8c45ddd2145f92cbf2bd7101002b6bd7235 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/PrediccionBusiness.cs` | 21 | b5061d0028fb4dc6d203bd7b1e00a258f4d20551f7ee9a0a66c36c09d536a633 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/ReporteBusiness.cs` | 12 | baa16b647efadd255442e7f57f6eff2e112e77be9d5bf38b692a5cae499c15c3 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/RespaldoBusiness.cs` | 8 | e6930d5b5201b531d33f15781d988ed6a2a5c3232f32c6fec20b99d080186738 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/UsuarioBusiness.cs` | 13 | 99ae330c65c6c8a05074e7e7a4b79eeb0f21f68a06a1dd7946796b23ae082256 |
| `codigo-fuente/backend/PredictIT.BLL/PredictIT.BLL.csproj` | 2 | ea94ef03c3cb5bd0be0f9ea516b0180d796de68f486309c47626d3b824d72fb4 |
| `codigo-fuente/backend/PredictIT.BLL/packages.lock.json` | 14 | 45bb435e931786259759fa72155a062baf2c5ed1541bf87aa85494643c0fd25a |
| `codigo-fuente/backend/PredictIT.DAO/Contracts/Contratos.cs` | 24 | b19160362ce3807ab5c84b9b39d24f984fbd162b52c0b8eb704a27e12a119246 |
| `codigo-fuente/backend/PredictIT.DAO/Factory/FactoryDao.cs` | 8 | 2ceb39726c03dfeb8cbeddb468e95292c36fbbd3e1256c8d79d0851ce4014719 |
| `codigo-fuente/backend/PredictIT.DAO/Helpers/LectorExtensiones.cs` | 4 | 70165f11998a04943ba5c0852098149eb4a88253f6e9ede460bacfbc807a8915 |
| `codigo-fuente/backend/PredictIT.DAO/Helpers/Reloj.cs` | 2 | 1274919cb8b868098aeaed43fa70e251fd552d633e448447e310e5d744fdad10 |
| `codigo-fuente/backend/PredictIT.DAO/Helpers/SqlHelper.cs` | 7 | 4b726c04b956ef15d583d2861019e5e744687d1977009bd387e60878247f6ac0 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/CatalogoDao.cs` | 7 | 8de928851406e792e6bee167e20e464b45934dfb122a0f8cc9ac745570989ec9 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/EquipoDao.cs` | 15 | d896ad0945612a302903acd40747fd95a84fe3bf083b9a2f137dbeae4ba1bb7a |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/FacturacionDao.cs` | 10 | 2886342ca677fdafcf820310c3e0bb745f1fd5b1c47a1c5a7f37bf7421ae4449 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/IdiomaDao.cs` | 4 | a0d7a2da22278a501ee1fe21d43fba332abc6b460ef194f6c5a9071bc2e9e3de |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/IncidenciaDao.cs` | 20 | 24c6b7ff9a461a589fb3804d77f3c27fd6c802e84414729c8dca419e32759016 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/MantenimientoProgramadoDao.cs` | 11 | 6be7df19c45457b46fce2158d365e3b68f74b6db1bc59f161a2546835ff7b593 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/PrediccionDao.cs` | 18 | c72016126a0fa5f809bd8c43474ed03febdc509358a6473cfeddaa27a4093a20 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/SeguridadDao.cs` | 22 | 05b4d0ff0078dc473b81551bee1741cdc8abc0974ee674995abf42dc8987e181 |
| `codigo-fuente/backend/PredictIT.DAO/Mappers/Mappers.cs` | 6 | 4cf070a4eeec53ce1783fe9f08dca6d8fa3109fc324cce97df645e88332675a9 |
| `codigo-fuente/backend/PredictIT.DAO/Mappers/MappersIncidencia.cs` | 10 | a65db623de8e474d03c1ce4fa30781ca7965dfe41e44c9ca5c048336d96d019c |
| `codigo-fuente/backend/PredictIT.DAO/PredictIT.DAO.csproj` | 1 | 765f377bddc3b1de614ea176da73a3cf25491a30ee2c7cf305e8420bf87b5f69 |
| `codigo-fuente/backend/PredictIT.DAO/packages.lock.json` | 8 | 326361c27c82611b01033a01601cdaed4afa8f6858f4bc16e8a81dbd3b84caf6 |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Equipo.cs` | 5 | 77b7754be1a3cf4e29408cfe5df3fcee59e90913173d7ae89e3461eb8701e9d0 |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Facturacion.cs` | 7 | 6dd01988dd53ea9523b5cbbf55d05c126beca14d664a5ac20a6f9d4e3ed62fde |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Incidencia.cs` | 8 | 413837cf0be1f413fd01c9410c3bab501bff6b5bb385ef3653c3d872c560b53e |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/MantenimientoProgramado.cs` | 4 | 1791852bff86557c2b6113db0f35510a9f386f39f9855022ae1abcd379dc63ba |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Prediccion.cs` | 6 | 0b848caca54f9bd55533f92fcb3e5cc5a70beaa39aa81e8a67ad3bebb33ddc2a |
| `codigo-fuente/backend/PredictIT.Domain/PredictIT.Domain.csproj` | 1 | 4d29c3a189c0733e1a32b231953bc515877a4a26f81b22bca995551a432b2c61 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Bitacora.cs` | 5 | 2868e6e2a814084c5123b0f9fe8dd0a6d24407a56a683e00866af574ad01bbdf |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/ComponenteSeguridad.cs` | 2 | 368605bc74ca9bb683e453efddf82df1b7f9afbfbb71c7fae13ef9f462b1fdbb |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Familia.cs` | 2 | 13b7bffdcb8b2f0b9b9f84499316acb6b5482551c8996286e1c1030aaed92fe7 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Idioma.cs` | 2 | 9d06c68091064798cfef6504ba5a3dd572d61b34b63829601f489187c9b32cca |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Patente.cs` | 2 | b57168add65a61c89f27e20155b5f7bef8be740a1e8a833b56f6922ab05e6d07 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Rol.cs` | 2 | b349f9493da12885a8aa90766ce6507b141c734cf55977af100b92e794eaa01e |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Usuario.cs` | 3 | fc78949235e6aee4b652b567d50a61f3992b486e70fdb28f7a265be8fd3c778d |
| `codigo-fuente/backend/PredictIT.Domain/packages.lock.json` | 1 | 21309355e77d26df68664ac0899fbbacb314b0354d4a65cf8406751d68bd5ad8 |
| `codigo-fuente/backend/PredictIT.Service/Bitacora/BitacoraService.cs` | 9 | c344c8f7ecde32402bb1e81dc09f68d4d5957dfa3abb9fec65cb23a4dd5561dd |
| `codigo-fuente/backend/PredictIT.Service/Bitacora/LoggerService.cs` | 2 | 73ff9dc125aa989e44d13ec8b809547aa24de6baa98c3d46441db93cf894178d |
| `codigo-fuente/backend/PredictIT.Service/IA/Disyuntor.cs` | 8 | 5c9b04ce7099ca8ab494f00d22e0c6673e02988f4ed5134fa14ccdf3020c9edc |
| `codigo-fuente/backend/PredictIT.Service/IA/EstadoProveedor.cs` | 3 | 4e3ba3b9689a4374684de455e15087db5cb1b5be661debe18ea32ce75b11ffc3 |
| `codigo-fuente/backend/PredictIT.Service/IA/ProveedorIA.cs` | 9 | f0b489666c5072f8e1d139c947a2d52388da785aeaa2b4f23d287f00f1604b09 |
| `codigo-fuente/backend/PredictIT.Service/IA/ProveedorIAClaude.cs` | 14 | 62a8d8e4e058e69b865b656b6c93dc505c19512bb3726da6ddb55e5cff6499bc |
| `codigo-fuente/backend/PredictIT.Service/IA/ProveedorIASimulado.cs` | 22 | d610c0f905583dc1a97bcfc9e347dc12647edb04a9cda4d81c3893997cef8376 |
| `codigo-fuente/backend/PredictIT.Service/IA/RegistroDisyuntores.cs` | 2 | ac921acac4246e1ba55e0cac74efacabacfcefc858e6a2c358e9161015f61138 |
| `codigo-fuente/backend/PredictIT.Service/Prediccion/MotorPredictivo.cs` | 18 | f5edbafc1692948b6ec47575e17ab1353bf3763cacfbfcfb618129170f87a600 |
| `codigo-fuente/backend/PredictIT.Service/PredictIT.Service.csproj` | 1 | 134f15b6c555842cf00fa9013bd3bbc053eee38e7d2255560dc28b38b9d68d98 |
| `codigo-fuente/backend/PredictIT.Service/Reportes/ReporteService.cs` | 10 | b19321e9f9d234ef32d0d70259a6d52acefeca91ae3eda13da2f73a431b81017 |
| `codigo-fuente/backend/PredictIT.Service/Respaldos/RespaldoService.cs` | 9 | affd5097c41baf3b2bd8cb7d25cd30fc8027849d330869b13af887e777ec0105 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/CifradoService.cs` | 7 | c560a3a52ad4d1e9660cff18c5f33cd158291af0d6c4c119403f1c613ed0563b |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/ContextoSesion.cs` | 3 | bda8b94042c2168318f9804f94a110decba30bcfe6bd0ccda34eac7110335ca2 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/HashContrasena.cs` | 4 | 308037cf4cac05f3e81f7447a4ffa371690c69446c07e7fbf150fb5aa1f431f8 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/PoliticaDeContrasena.cs` | 3 | a1edf664f8bc59c721ce81e5077bfd7465b27d6b5fd0bcb3bb769f6d515abf13 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/SeguridadService.cs` | 9 | 9fb209f957360e2bc3ee142c0890916fc783547f9ac40180cda7f2c0ade92e0f |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/TokenService.cs` | 3 | 6f5b0ea2edfe205a025c4b66dcf11e58533934f285df785b117d0a95808bb2bb |
| `codigo-fuente/backend/PredictIT.Service/packages.lock.json` | 13 | 9dc28072f19a950207a9dd716b2eedf5ef2567d28ed931bde6915e00d990d2fb |
| `codigo-fuente/backend/PredictIT.Tests/Dao/AislamientoOrganizacionTests.cs` | 7 | 5344821cffb2591d299fcbab92cc1abee835f05957ba6a574a654201ef23add4 |
| `codigo-fuente/backend/PredictIT.Tests/Dao/BitacoraConsultaTests.cs` | 5 | 504faa8a180d6c89015456101d4c71dbe2452affd3a11f8181543fefd2f9da07 |
| `codigo-fuente/backend/PredictIT.Tests/Dao/IncidenciaDaoTests.cs` | 14 | 95f5854795810fb709ed9d9b5968cdba4b82cc74dab3e395363929d05ca8eff5 |
| `codigo-fuente/backend/PredictIT.Tests/Dao/RelojUnicoTests.cs` | 3 | 6769f17482f07b55095422fda83a492d3ce94722f1f2657c1ce263344b20ecfc |
| `codigo-fuente/backend/PredictIT.Tests/Dobles/Dobles.cs` | 21 | d8d7ead53374402fc9a5b02d0c52e017d569d0e408d776b41ecae3794ea3f2ca |
| `codigo-fuente/backend/PredictIT.Tests/Dobles/EquipoDaoFalso.cs` | 3 | 24eb9769aaeb04a5fd1e1371603f15752605c62f18d01dad3da75c98fa4565bc |
| `codigo-fuente/backend/PredictIT.Tests/IA/DisyuntorTests.cs` | 5 | cf933790bf06f96bc0ca7cd76a80abbc29ea7ab6d11409c6d214cd61bedbda53 |
| `codigo-fuente/backend/PredictIT.Tests/IA/GuiaConProveedorCaidoTests.cs` | 7 | 047b5ac653ce078d3cc32210cd2bb6b81e589757c1cf0ee0834f16aeddbdd4bf |
| `codigo-fuente/backend/PredictIT.Tests/IA/GuiaReparacionTests.cs` | 7 | 2d781b807d23778649532957ad1d22a5bc86149a4f4ec2c9a99fa070a3e896c3 |
| `codigo-fuente/backend/PredictIT.Tests/IA/ProveedorIATests.cs` | 13 | ec12bca1b5ec76a713aad58fab30c838f059731522f3df64105b346bdcc68763 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/BaseDatosSmokeTests.cs` | 6 | eae15891154618e3fcb0a2d5f649d886134b85b1135f2408cb0105d9e2c44cac |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/BulkheadTests.cs` | 3 | f46a2d5f79d5ffb4220e477afda8372c75a5dcff1a2c301d0ec7901395f641aa |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/ClaveDeFirmaDePrueba.cs` | 2 | 14e2c9fe5e1a1ed8ef831009347c6224ca2980ceaa030acf69d94837fa1c4409 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/ContextoDePrueba.cs` | 7 | 650b768dad437f3aa953fa7f47ed2508d3b976e955d94f81b9f286f183eca5a6 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/EntornoPruebas.cs` | 2 | e92a5a987bd2c3432614aca37edc258c5802108465525d4041947d22845a6dd6 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/MetricasTests.cs` | 5 | 6fba41505ad55d564005846c5918a0741249e692445e00c0312b097d15e2a2b6 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/UsuarioSolicitante.cs` | 2 | 8479571e990cbcd8062b6051c824fb819be2ff5496491aec86b286b030d4d9bd |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/AltaDeEquipoTests.cs` | 8 | fbb71305b95c45b3dd46badc3e79f753104be39fb48449700e0940cbe3b094a4 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/AltaDeIncidenciaTests.cs` | 4 | 654dc81d7b22b8a642e390bdd2ddc010d180b3dd2f033eb005adc4173583f401 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/CasosDeUsoPorLaApiTests.cs` | 10 | 96576b715ae0d1c756dce1f8be02be0c74b8422389ac356856121e0e34d55b93 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/CatalogoFalsoEspejaLaBaseTests.cs` | 2 | 92da67b825da06c2d0e00450a70728bfc7f86b7f0c938c04804744143c32df42 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/CicloDelComprobanteTests.cs` | 13 | 92a2943b47516178615198274018cdfc7f63edd1763a26221610b0a3ac9c7654 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/EstadoOperativoDelEquipoTests.cs` | 7 | 2947b7ed374ccadb8c5126291a49a37887269c46923365dac2534782aeff37c4 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/FacturacionExtremoAExtremoTests.cs` | 9 | 599086cff90162c59ed61eba5e10bbcf863fe161b391b6dbf07f33f1ae169f14 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/FiltroDesdeElContextoTests.cs` | 3 | 4277a67b4627913b9d2881e110a235d67e93319e3cfc2a2b331484481b2a1c5d |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/IndicadoresConClaveTests.cs` | 4 | 09e9a19dd0ee3ae3af9f56f3a9310abea16bd61b44eec9bb1c1eb157bb52fea0 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/MaquinaDeEstadosIncidenciaTests.cs` | 12 | ff08635485ff54377c44a638d9e303554933f772cd4ee0674267bbddc9abe668 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/PeriodoFacturableTests.cs` | 4 | 44c6a861dd125e4e668a2e899390d938cabd489bb11bc27a7b07df9c8ecc3865 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/ReasignacionPorLaApiTests.cs` | 7 | c049c4709e7ea1a112f290d2e83f6db66320edc4003d77a23d6b6ce95bc78a12 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/RespaldoAutomaticoTests.cs` | 5 | 863fec7212d7d370014b591c3e514601267b6a4992b5ddb720b72c070e8b05ef |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/ResumenDeNavegacionTests.cs` | 8 | 208f90f1bc72f09d53bb63b6246528ad37bb45709520ab59c343e936f646b12f |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/SegmentosDelInventarioTests.cs` | 6 | b5b2d534356947fa93b1bf934990378e1fcff41ec546e384930c490d7be65373 |
| `codigo-fuente/backend/PredictIT.Tests/Prediccion/MantenimientoContraElPlanTests.cs` | 6 | 8c4a66e8c71278bd889d8c94e2674f1f3aecf1ab7bbeaf1b7ea9dd1a5ff8bab3 |
| `codigo-fuente/backend/PredictIT.Tests/Prediccion/MotorPredictivoTests.cs` | 17 | 8b0a543129206f51d8754ab398928854cdc103f28de15bee3ae399c3bb8b1d1e |
| `codigo-fuente/backend/PredictIT.Tests/PredictIT.Tests.csproj` | 2 | f0db0172546c11b8038e827a26b50685a80e504ca9984ec19c943438316c74ac |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/AltaDeUsuarioPorLaApiTests.cs` | 5 | 8902c879dcb63f0bd4bc3462e1d396cdb218c3078c83967f969b8b955025787f |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/AltaDeUsuarioTests.cs` | 7 | bcbe4c0017ba9075c1a3c40569b4d4aca6076de5394eff492a60f119ee020e5d |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BitacoraCatalogoTests.cs` | 4 | b25b72bd66746a2530644a283abc16939aa6bed61910727c076aae7504546135 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BitacoraDeLaSesionTests.cs` | 3 | 4f7daec483cc0752b6895bb5c5452b75780ba4a831149680270b8e011fa67b55 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BitacoraNoPierdeAsientosTests.cs` | 4 | 3be7ab4a57a806a8934066c546937f05309b1fb8b327ddf8a8968f4941a7bf4d |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BloqueoPorIntentosTests.cs` | 4 | 6d40f8b546f1f0edc04e17dcebcf7e0bdce8b26d11cbfc403a9de07eac331eff |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/CifradoTests.cs` | 5 | 94af3bbe8731fb747b3ba2311597dd4052654214e461cc2603084335ca990518 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/CodigoDeFalloDeLoginTests.cs` | 5 | 0ebfd07ac4f603708c6ada789ceb3d9e52800aef233761aee45cfd5a41f28a00 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/CompositePermisosTests.cs` | 8 | 1de2f4b79ab14013361939f6622ad5d7ae3146ee36151f2781f65867d94911ae |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/HashContrasenaTests.cs` | 6 | 32c1e2ffcedb8ecf9cf3473db2fc82a60efba8c070b7d5b51ed47a63aa852d2f |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/LimitePorOrigenTests.cs` | 3 | 123742f07a336e1629e4a824cd932b3244c73a698b4dbf43d31d99c07728a5b2 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/ReglaDeReasignacionTests.cs` | 5 | 4b6d4eab23430901306af95313ce1575395f5d51f6ed20d54f06c9d61232093d |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/RehashAlEntrarTests.cs` | 4 | 1ba103a1ea4bae9ef55479aae53806f89978720c9d7e62feee48a9baca6c4004 |
| `codigo-fuente/backend/PredictIT.Tests/packages.lock.json` | 32 | a903398eb6f4793ddeea2229e1e6e0b02c12dcf039f2e5c3d063be96594290ac |
| `codigo-fuente/backend/PredictIT.sln` | 8 | 99b28d6d7072cfeb1f326d3fecf026263c889c4c5c38a17521b43708b4235c65 |
| `codigo-fuente/backend/UpgradeLog.htm` | 20 | ba44aea8fc12d29e4c83606a8b7c5cb67643db21f0ab3dfc4d9f97628009eed5 |
| `codigo-fuente/backend/analizadores.globalconfig` | 1 | 21c2454c3d414b0a53c12a0ed2a8557655aa1a90a1af06376dac3bdaed4b2acb |
| `codigo-fuente/db/01-negocio-schema.sql` | 40 | cbaa55e034925a04738b72f651d07956e2002c737ddf8cf4865bd1789eb201db |
| `codigo-fuente/db/02-servicio-schema.sql` | 15 | 9805096534e5c60e6e7f8af97eaa3eb0e6a64998b5a5a7d78d12bf0f2662c584 |
| `codigo-fuente/db/03-seed-servicio.sql` | 25 | 5047dcfdc1bfb57a411d4cb948f7c0928f5c64a57ea7dd8ce4e8bc98b03c5b4d |
| `codigo-fuente/db/04-seed-negocio.sql` | 45 | 5e2ee1064ef9bb52766a84da4204babc47b4ed16f72a88b13d3e7fd116d98d40 |
| `codigo-fuente/db/05-seed-traducciones.sql` | 117 | 989ef033ba0abc10e4109031107aeb5c2418abaea34a2746c483e2256fd87201 |
| `codigo-fuente/db/06-usuario-de-aplicacion.sql` | 5 | efa8a40d7242a8a6149b61c08a41ae585724be7de5dda1a188f6110a1df99fe0 |
| `codigo-fuente/db/aplicar.ps1` | 3 | 27a9d67999ea6a51aa730c92ecb78ae526f2faa6c0e7f56ed8cf527406934bfe |
| `codigo-fuente/db/cambiar-contrasenas-demo.ps1` | 9 | 8ca7c89390c1fa7b2ddfa2d4315df01de5bb78ab058a379f139648d6fb95939f |
| `codigo-fuente/db/cambiar-contrasenas-demo.sh` | 6 | 81567d2661b77f29adb5aa8275ae2c7c2b5b7079c8a680479288ee92fd8e427e |
| `codigo-fuente/db/restaurar-demo.ps1` | 5 | 3a11337b47acb38731b2e4b4651cd241bd7cbd5696325d722a17a66544aa29eb |
| `codigo-fuente/db/restaurar-demo.sh` | 6 | fe49f8d5d10d4a3c4f97d57830a8279f8fe9879cfad49bfa34327d638e184d04 |
| `codigo-fuente/docker-compose.yml` | 9 | 2716b9e15587d537ded665b68a5c24696e1e95105522844b881cf24617e0151f |
| `codigo-fuente/frontend/.dockerignore` | 1 | 33577f96b7dbefcae9e1d0349c446f436a65f5011415b5db9e32608497fa9f30 |
| `codigo-fuente/frontend/.gitignore` | 1 | 76f1520910bb98de61cf854c87d1a1ec16ba0c6ab657e94bb5f9be7651a23273 |
| `codigo-fuente/frontend/Dockerfile` | 2 | 571d443f727881747043b99fd9e80c248cb698cbf90a3a72e78acc2fce0c4630 |
| `codigo-fuente/frontend/cabeceras-de-seguridad.conf` | 2 | e8cfc9555bd4df2300842bb5a7acfa6ac8692e9c7a8719ce631549b30f4423a1 |
| `codigo-fuente/frontend/index.html` | 1 | 2bc79b2b1a4045d2b20968bc8e458df1b7fbde4262910fa5e0e9fdae925ed5cd |
| `codigo-fuente/frontend/nginx-tls.conf` | 5 | f86efad1c50eb1c93211cd8093a65c66bc489df367804af4f8f717d9227b4edc |
| `codigo-fuente/frontend/nginx.conf.template` | 4 | e35ca563d72a7a1659a64a15e4b8fccb5eb977587386dd83603090e7532dae00 |
| `codigo-fuente/frontend/package-lock.json` | 99 | ead4433cc015851256c9f422559ee5982dc8879c0b978bbb72333686429e30d3 |
| `codigo-fuente/frontend/package.json` | 1 | 6ed1c3f8558fdc124ff0063d75fcc2f30da3793d76ad76e478d273626ee084f1 |
| `codigo-fuente/frontend/scripts/capturar-pantallas.mjs` | 16 | 6841fa392637b543f10e63ef115cf3e1ecaf1b500ed5b448b2cd35fa68ec0c63 |
| `codigo-fuente/frontend/scripts/idioma-en-pantalla.mjs` | 6 | c5df9a4d2afe3ca60914860d2134c6368e2112daaffa2ec35a5fef4c89d0e66a |
| `codigo-fuente/frontend/src/App.tsx` | 6 | 5293bc6d2b9c6ce76c0d96269297e788bf1417f6e7545fb3115b9cbea64c31c1 |
| `codigo-fuente/frontend/src/api/cliente.ts` | 20 | 105edba20deeb13018676af6a58f5770a9c7ffc1b8676d67b5f108ecbb983b80 |
| `codigo-fuente/frontend/src/api/tipos.ts` | 21 | dc9e8a797c2436f5fc5defeb6ac33cc1c5ca537bc32569fbb3066e60d3f47a9e |
| `codigo-fuente/frontend/src/componentes/Estados.tsx` | 6 | 7157720a608367e04f17bab8c68883bd0336e4518c023e33e06527e8ad7f9982 |
| `codigo-fuente/frontend/src/componentes/FormularioEquipo.tsx` | 12 | 921dec8c7fba6f65e4ded9497cec12ed47e4ef2907f5d18a8a2e08d1fdb425b5 |
| `codigo-fuente/frontend/src/componentes/GuiaReparacion.tsx` | 9 | 92858cf6139bf97c5d6293da4021fd8f6c5e85bea884fcce127aaf4c5bc390d5 |
| `codigo-fuente/frontend/src/componentes/Iconos.tsx` | 3 | 54f0479a2aa86dcd9d3594ae1f04dd9e0f5e0bbc423fb5f9b9f1c385da13dce0 |
| `codigo-fuente/frontend/src/componentes/Indicador.tsx` | 2 | 9394bbcae43c7075d878c015c6cdc3377c05b6a7293821bf0b6d82c68af48e7b |
| `codigo-fuente/frontend/src/componentes/Layout.tsx` | 14 | 12107c9c1131f20696e943a16af6cad7c8ac15702f11e4cd84e1d8cc6442b427 |
| `codigo-fuente/frontend/src/componentes/NivelRiesgo.tsx` | 4 | 61a0e6f0680b0aa8e39da0422a885a4b6a26ad1507f1a55a6740ce68603d15c3 |
| `codigo-fuente/frontend/src/componentes/PanelAtencion.tsx` | 8 | 9f9d6c51807ce11c89e78077eaab038b42adb04fc34f59e67bab3c626ad3253d |
| `codigo-fuente/frontend/src/componentes/PanelCalibracion.tsx` | 7 | 2f52fe6eb6b3ef289622f421e0e2dd5d6a641a70cb44af104e792b07940a422b |
| `codigo-fuente/frontend/src/componentes/Semantica.tsx` | 10 | 2338a877f50ee4b7d4bdee63da4554d008062b59c0c896f6535c606366a3bf59 |
| `codigo-fuente/frontend/src/componentes/SenalPredictiva.tsx` | 3 | 00cef4fe161e590687fb73fea2b7acef98d69c536d9a94c2dea9cc9587eb13b4 |
| `codigo-fuente/frontend/src/estilos/app.css` | 40 | 4c1f04d953298b498d059aba35ceb9eb9fcf35160e9e10bae2a6668dd89fe4a6 |
| `codigo-fuente/frontend/src/estilos/base.css` | 2 | 42e819e3637e354e2a88a26a685853dd3604853c9ca0e21ab0c70626f3a8b380 |
| `codigo-fuente/frontend/src/estilos/responsive.css` | 10 | 4cd19946567f135c32c45ec3bb0c62dee9aa0ab7f3687a080eb4b5aac9e94a3b |
| `codigo-fuente/frontend/src/estilos/temas.css` | 1 | eb324d7e4302ef15942370067725e70bd1c3207f331a207008b9426f2cfa097a |
| `codigo-fuente/frontend/src/estilos/tokens.css` | 6 | 5ad37aa98e10bdfdf70df3642540fcea301f23ece7c17206bd8c14a1d1fa396b |
| `codigo-fuente/frontend/src/idioma/IdiomaContext.tsx` | 7 | 0136440454c039b861015d003243aabd2627c0c2cc351abea0729a28f136f8d8 |
| `codigo-fuente/frontend/src/idioma/formato.ts` | 4 | 217e3dcd444a507db55cdec27660d61c272574aceaf78b311f6767747b074162 |
| `codigo-fuente/frontend/src/idioma/hace.ts` | 2 | 5c16abdb553372880da70fc0a801635950d16b483b6294bffa857f36d43a35ff |
| `codigo-fuente/frontend/src/idioma/plural.ts` | 2 | 2de2b46820bf204a222c3486acb506c1c77b6f61da55a1243097b6e82b86d885 |
| `codigo-fuente/frontend/src/main.tsx` | 2 | b31bd008f686359a1e04c142c8a8f70cb207b27c6b95d57211ce2b0db7107d4f |
| `codigo-fuente/frontend/src/paginas/Activos.tsx` | 16 | 17e163fa028cc4903bde253b571f673e864a6c1a879c229d1c5afcd0b99bdbe3 |
| `codigo-fuente/frontend/src/paginas/Agenda.tsx` | 21 | b5904ab19bcfe413cbc1012019501c12646ebae6cef3324d5c6656c5b4d7459a |
| `codigo-fuente/frontend/src/paginas/Apariencia.tsx` | 18 | 7d1642bb9294bf6bc2a383dcb03f00925196759f95e1af085cde8cc8c221c355 |
| `codigo-fuente/frontend/src/paginas/Bitacora.tsx` | 12 | c03fc2b0660cff5628a9667f4dc9437f44d6b99aef10bbb6b42853cb43ade281 |
| `codigo-fuente/frontend/src/paginas/CambiarContrasena.tsx` | 8 | c15ed27e448319c9ff41b54e39fb8763dcf6342920ec1c20f374fdf7d4169087 |
| `codigo-fuente/frontend/src/paginas/Dashboard.tsx` | 12 | 4e26bc3ab329221a821d0f2c04e28eaf170a32417563e901f254243953d46a3c |
| `codigo-fuente/frontend/src/paginas/EquipoDetalle.tsx` | 24 | 04159948ee3b9fa145075901b693c470b10abd55b8cfafad7007368126670e4f |
| `codigo-fuente/frontend/src/paginas/Errores.tsx` | 11 | 886ff8afd1fd82b3990dd8d61c57551c3540bc8ebbc12ea94ff38f7cf58ad8c8 |
| `codigo-fuente/frontend/src/paginas/Facturacion.tsx` | 19 | d38f613331e4f0ac179c685876d51201519d6500ba65078e8291c4e47cad7f6e |
| `codigo-fuente/frontend/src/paginas/FueraDeAlcance.tsx` | 6 | c749abf03e73b6f9748058f92ab7d760fae4fc2b46513f3c2f994c9f32504b1c |
| `codigo-fuente/frontend/src/paginas/Historial.tsx` | 8 | 54fb23e0d2b509a56ddae97a1993703fe0cedcc9c9fb1c34c1c328f8d60082bb |
| `codigo-fuente/frontend/src/paginas/IncidenciaDetalle.tsx` | 15 | 5fe57cf6cf52f6296ac4b9dec035d5a2a4bd4ef601ac478e9aff73976e10a440 |
| `codigo-fuente/frontend/src/paginas/IncidenciaNueva.tsx` | 13 | b2e19149cffacce29a024339f7a6700ac0ecb400390bc5ab1fad211db8c43aa6 |
| `codigo-fuente/frontend/src/paginas/Incidencias.tsx` | 22 | 6438f22813bbb32e30e52d692d60316e5852515bae454137b96ea95d5c9eec2d |
| `codigo-fuente/frontend/src/paginas/IntegracionIa.tsx` | 21 | 100c03c58981654f06977f576496b3b4b2a5d0ed0c49dab40da680278411e8d0 |
| `codigo-fuente/frontend/src/paginas/Login.tsx` | 11 | a715505d185c0bf96e9a96a729e510cf59122feba74e21f1bfe4b92875cd898e |
| `codigo-fuente/frontend/src/paginas/Mantenimientos.tsx` | 16 | 0b476ab06a5b2ac05e112e2fe008d1237f17d94b5f1000879bbe86cb0c343763 |
| `codigo-fuente/frontend/src/paginas/MisEquipos.tsx` | 5 | b671c7a5de373b1480c79f84ddaffeeaf71fa2688475eb3775518e4e9bf9bc61 |
| `codigo-fuente/frontend/src/paginas/NoEncontrada.tsx` | 3 | 516bb3629eec3cd183e0d67c0167cda548f66e39bf996689578307c6f6b6525a |
| `codigo-fuente/frontend/src/paginas/Organizacion.tsx` | 14 | e83c622321c88c0d1d47b9ab98a10013ada7f399b99403045468304e57c04d0f |
| `codigo-fuente/frontend/src/paginas/Planes.tsx` | 16 | 11442015db6760bc3475f8d3376552b0ab025835daf8b46df99549bf2a767881 |
| `codigo-fuente/frontend/src/paginas/Predictivo.tsx` | 17 | bc8ed77bbfba28f53877ef3de0974dd9c7dcf98b4fcced75f721311ad544e1e2 |
| `codigo-fuente/frontend/src/paginas/Reglas.tsx` | 14 | aff433d4fcb93681cc4c82a9a72d2a9a7da8c298f6a26a923e9e8be81d5f0602 |
| `codigo-fuente/frontend/src/paginas/Reportes.tsx` | 9 | df3aad9bfcdaa12105bf4adc75aa66a8dd401cccc89ff180e1f3bb60592bd1ee |
| `codigo-fuente/frontend/src/paginas/Respaldos.tsx` | 13 | e4601997af789cb559d13dddf1efd86fe3d5c0f060abf483e3c0b5727bc8ba39 |
| `codigo-fuente/frontend/src/paginas/Usuarios.tsx` | 26 | 6a591840fd54ce9e9653a2494bd882a74558c13be9ee61a7183266a1a0091430 |
| `codigo-fuente/frontend/src/paginas/cliente/MisPedidos.tsx` | 6 | 802e2bceb5e4a842c0696c8b8d11246738e85dd4879de132f9308f4cacc78eaf |
| `codigo-fuente/frontend/src/paginas/cliente/PedidoDetalle.tsx` | 9 | a22da591718b705a45b53808a454626d2c3113cc15bc2664f78c46eef0610fa1 |
| `codigo-fuente/frontend/src/paginas/cliente/Reportar.tsx` | 17 | 58e53fe555dcfe535cace3b9cccbb3bfd6023badffbb5079f3fa2bc6e480f77f |
| `codigo-fuente/frontend/src/paginas/cliente/avance.ts` | 3 | 645f5cea85e014d6b1c315bd48c0b35f44a9291fa55bc91ba71a759b00bc5a28 |
| `codigo-fuente/frontend/src/pruebas/Activos.test.tsx` | 10 | 565a127adb0e3dbf84f96620f2fdb50f648273541cb74210278426bbeba98241 |
| `codigo-fuente/frontend/src/pruebas/Agenda.test.tsx` | 7 | 60d228451e5a09c140adadcf4c3b3c6e95de3550a47962f2b601251f6cd8f071 |
| `codigo-fuente/frontend/src/pruebas/ContrasenaTemporal.test.tsx` | 2 | 05d65df0c28e09a3f39c072eff0318e06def938ea3740370c8d6ba4d31aa60d1 |
| `codigo-fuente/frontend/src/pruebas/ErroresDeFormulario.test.tsx` | 4 | b72f2d0d6e4195e6f9aab6ee6e2fab57424e5b73af3b0d219a42dc60b9175d16 |
| `codigo-fuente/frontend/src/pruebas/Facturacion.test.tsx` | 10 | 2a6a77f0fb121efae4d1f6b3fc91df046dc9337fdcb898655e3a1f154588fc74 |
| `codigo-fuente/frontend/src/pruebas/Idioma.test.tsx` | 5 | f3b9aaff44f40b84585c2382a97fb707851ddde017c9a445f7903a932a7a47e6 |
| `codigo-fuente/frontend/src/pruebas/InsigniasDeNavegacion.test.tsx` | 5 | b645962d5e96c848c99500aad4119dae30a01a93a56d4ce6fbb3935d01f954e6 |
| `codigo-fuente/frontend/src/pruebas/Mantenimientos.test.tsx` | 6 | 08ad858aa1b031b507b1be43c8edb32e3f98cd56d09fff89cb8b9c9efd5fdb3d |
| `codigo-fuente/frontend/src/pruebas/Organizacion.test.tsx` | 7 | fd51936742b67762cc6e291b4d175c83881c806fb3714f6dce45b339de204a81 |
| `codigo-fuente/frontend/src/pruebas/Planes.test.tsx` | 7 | c35ac37f59bfdc8c92b9df191a8fc92bc4761c584f21327df764c467705ba68a |
| `codigo-fuente/frontend/src/pruebas/Rutas.test.tsx` | 6 | 784d920185fccde7dffeafb5a8db6eff0c8c00a130571f696b1bd48dd70c4416 |
| `codigo-fuente/frontend/src/pruebas/SegmentosDelInventario.test.tsx` | 6 | 88bb804cc565b806f1778eb225c9c155d6cabf1e226dfd1f360ae69758120701 |
| `codigo-fuente/frontend/src/pruebas/SenalPredictiva.test.tsx` | 2 | 7e5a8b49dabaee7e532742ca2831a12909a6c22f2d602ce25a7ac46136a0c35f |
| `codigo-fuente/frontend/src/pruebas/TableroDeIncidencias.test.tsx` | 9 | 4567e4e5eb0d08a5a1a71d2fc8046223ec9a2d8be3f761336cb8a3427c56629b |
| `codigo-fuente/frontend/src/pruebas/cliente.test.ts` | 5 | 020aab3d632b35accb8342a585489a8d6d558d963ad1cd88a450c124640d4475 |
| `codigo-fuente/frontend/src/pruebas/preparar.ts` | 1 | f71ca1cf640eac1977e9a2c151d989dbaebb2eaea41c87bfee752c8734520fc9 |
| `codigo-fuente/frontend/src/sesion/SesionContext.tsx` | 4 | 3d3219474c7adc45a15df418009c153b44211117ddda3148a428c85b0fb56c4c |
| `codigo-fuente/frontend/src/tema/TemaContext.tsx` | 10 | 8b5c7d7ee8a3f27219ae8bd7d96e9efb876ff780978eeed209027be07539c32f |
| `codigo-fuente/frontend/tsconfig.json` | 1 | f7a7e2e3efd4796bd0abea9bc88e56210c7af08416ef4f190f2a58853f566c70 |
| `codigo-fuente/frontend/vite.config.ts` | 2 | 4bad11cbbbb03e9697f1cb9f9110f91eb5c451dbd9b470132117e66a3c9193bd |
| `codigo-fuente/scripts/_textos-sin-traducir.json` | 1 | e27e2025461b5ed4e17976e7c946d4ec4f5218a8a481feb70ac4c1d23192123c |
| `codigo-fuente/scripts/cobertura.py` | 9 | 08000ff419a91a2f93cccc591bea19c3a118f8e73180b67d12d1d79b8f7e4d0e |
| `codigo-fuente/scripts/medir-carga.py` | 20 | b04a53d2437c21e8b9c3a2cb12fc1c8aa21fbbd6165481513798950b0d9401f0 |
| `codigo-fuente/scripts/medir-estabilidad.py` | 18 | 53080df1c797d06c883c73066ece02065caad30d53465874b1ed247c83585c03 |
| `codigo-fuente/scripts/residuo-de-las-pruebas.py` | 5 | 76b1e57c90effb9e5aa871b7948fab03ecc34336f5648171a6c7bb4400670a1c |
| `codigo-fuente/scripts/textos-sin-traducir.py` | 19 | 2424a12e92a4046c27053749cfc07a1ee04ccfb48a7bf5457835cd2a66e9cc88 |
