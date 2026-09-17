# Versiones de los entregables

Generado el 17/09/2026, sobre el commit `35aeea9`.

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

## Los 302 archivos

| Archivo | KB | sha-256 |
|---|---|---|
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.docx` | 32534 | a1bdd9da7367b985f9fdbe03e37a8ba11f37771200d191720ff204b3bfae479e |
| `ENTREGA FINAL/01 - Documento del Trabajo Final v2.pdf` | 6774 | 02a5b2a56f31b37448439e598485249468877d7706b4ecbe363f66a35b4def92 |
| `ENTREGA FINAL/02 - Presupuesto financiero.xlsx` | 122 | c1d2d1d71d3863f155126e25fa347f1c38cf787164868e4614c800586c131a26 |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.docx` | 72 | 48a4064b9c3ee410a1558b3eeb0d973c2e6441853b67743fd0f11a261aaf3cb4 |
| `ENTREGA FINAL/03 - Anexo de trazabilidad del uso de IA.pdf` | 954 | e5a6a4498f7a142ca04db0f071d54a309e58f89095b40e78d67f66b7d41d2487 |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.docx` | 449 | faf3d14c08cad84bb69ed53b351413161eaf0830bf084bdd7815ac2cda12bb30 |
| `ENTREGA FINAL/04 - Manuales/1 - Manual de instalación.pdf` | 945 | 40d3d90e63f1c44ed50c395b59261800153bb760a3564ef553757f865e768be6 |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.docx` | 4273 | 4ec436611b44e60a7758b7a0308e34b0d242b87468297c15f414c309c38e9a2e |
| `ENTREGA FINAL/04 - Manuales/2 - Manual de usuario - Administrador.pdf` | 2452 | fb212824c7162435f4605beaeadfd54e7a1eca1d7b890e0c12f72da423cd874c |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.docx` | 2043 | a5cee516cdb8d0f11cc9d034b6695addc06d707f2a3faea5496424544428e7df |
| `ENTREGA FINAL/04 - Manuales/3 - Manual de usuario - Responsable Técnico.pdf` | 1596 | cb75f889a6a45689998c07f915769246247a443ab68a1903bcabc8b9095ac23f |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.docx` | 379 | b7c55b60d397cac45f752690604c2f60bb675ae87cf711e84b49a1b93c6661ed |
| `ENTREGA FINAL/04 - Manuales/4 - Manual de usuario - Usuario Solicitante.pdf` | 866 | 90d7ea86827f090a05ae0dd58cc3adde55a1379445da0003090970dd15f50c02 |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.docx` | 258 | da7d021a2b1f20038e7ef2e2d2dc7b744251fba92a7cf64c12a61414b30492ea |
| `ENTREGA FINAL/04 - Manuales/5 - Manual de programador.pdf` | 1022 | e709f4d15408302fab32433be71dcbfbb1707c302125e7df9cad0f9305482a35 |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.docx` | 52 | b2e66cda58766d19895aa176ecbf36e218bb3b98c91b4019d0f1b8732fce8d39 |
| `ENTREGA FINAL/05 - Documentación técnica/1 - Diccionario de datos.pdf` | 892 | 11a43d22a40366a1b0ffdfaf7794401c33c20c43dc0c7922b94e62845be9ea47 |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.docx` | 53 | c0fc2369aadc588138099fe484ba2197f2b1f4f7748533f794c86dbf210c405f |
| `ENTREGA FINAL/05 - Documentación técnica/2 - Casos de prueba y evidencia.pdf` | 878 | 955d789312d827014843c4c144393c105abc8e69d33339ebb9f52622d0a1bd0d |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.docx` | 517 | 73b42bef8a1d6731e1bb7ee44602f4b9849ba33bca27c53ac5d51a9df8abae29 |
| `ENTREGA FINAL/05 - Documentación técnica/3 - Diagramas del sistema.pdf` | 1158 | 3ca21ef9136469761d4f8b8a9d4a8b7867dc9f8c6d323cc7210e2253e5f3bc2f |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.docx` | 56 | a36b184d293e7199234409036ae277a69b93e65769cf490693b999c095d0bbe6 |
| `ENTREGA FINAL/05 - Documentación técnica/4 - Patrones y principios, con su archivo.pdf` | 759 | 4784baf463234f289e6fc239c85b1a3da088f9172db006d7c9b13e6a8316b3e1 |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).docx` | 84 | 9c28654958114fd169863bef2fe9b9fcd5d784a9208fcaf38d61d98a1add0c8d |
| `ENTREGA FINAL/05 - Documentación técnica/5 - Decisiones de arquitectura (ADR).pdf` | 1064 | 0ec1d828c6292a23a7f9cfd773d1d3b2d7f34a223084f5c29403cb9a580e19e1 |
| `ENTREGA FINAL/05 - Documentación técnica/6 - Verificación` | 0 | e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855 |
| `ENTREGA FINAL/05 - Documentación técnica/7 - Modelo Enterprise Architect.eap` | 1972 | b5fdc81e99d229753f01b0c496123d0778b3cda6f998ae912f5bcfe82c461bf7 |
| `ENTREGA FINAL/06 - Panel de obra.html` | 45 | d7ee3fb227c920836f31af5e37b95ca96aebef96ec4a2f0b6f45c39cc221c68f |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.docx` | 151 | 5e54121bcd7e1b7bf1e0c2042ee9e19bb7d193851a06d35c8ddbbe7ce07c7774 |
| `ENTREGA FINAL/07 - Gestión del proyecto/1 - Plan de sprints, hoja de ruta y cambios.pdf` | 1772 | 4acbc8d06678fe994676ef7aeeea40cfd6d0e5200fcce21d15b9c7d971334abb |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.docx` | 54 | 078281ac0acab2a4d37fe2035c6d96c5814e0537c13cfd4b6ccc07fda3fadadf |
| `ENTREGA FINAL/08 - Guión de ensayo de la defensa.pdf` | 728 | aba6d6c1ac3a3f4b15cbf140516ca2dce43aa233cbfc8bb1fd6725d62e17ca7f |
| `ENTREGA FINAL/08 - Presentación de la defensa.pdf` | 989 | 3e043a6384e12e95d5da26cb0d3c0d02be202d0166a7b0023d7383ad10d9c03f |
| `ENTREGA FINAL/08 - Presentación de la defensa.pptx` | 1092 | 8c99be4bffafed6844bbcd4f6287d32b73a5ddd18329b3fda7c480113f992e09 |
| `ENTREGA FINAL/LEEME.md` | 9 | 5be689a429a211228e6562c595f6c270c79bb452f162038cea5c65f7c6e6eb87 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Documento del Trabajo Final - capitulos 1 a 8.docx` | 32454 | 74f5d8e11bdf7561811978098744262de383617b6346c7e7801dd0e4ac4957c4 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Documento del Trabajo Final - capitulos 1 a 8.pdf` | 1661 | 1895de8f11a7b009eb00aabdfb60d96e2968a9f439c851e005d78cb8b85479fb |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/LEEME.md` | 5 | ad87d1831d46e1ab9d37e8e9bac1e23defbbbdfacd43a423d8cb10a4d15ae629 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.docx` | 86 | 356f3e33bffb1787b97d208ad431e8fb138c712fdf6a23e055335b8e8163fc42 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Log de prompts - Negocio.pdf` | 974 | 411a0f801eb979ff61a204c6de2414795a5abd3932b039d20130239e3c62a630 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.docx` | 75 | 6c171666a5180e6834100ae76a5f3c14c320104c802225cda26fc7e5ce40bdf3 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Plan de negocio - Entrega 1.pdf` | 858 | 9fe8635104ef83ecf4529f179857c4075517d71d022ed3412bc57af3991bcd61 |
| `ENTREGA NEGOCIO/PRIMER ENTREGA/Presupuesto financiero - Entrega 1.xlsx` | 74 | 6bc58a2808975c9f577582243e83bee16a5906f7bb10e886f2a4d3edbf9a7ec2 |
| `ENTREGA NEGOCIO/SEGUNDA ENTREGA/LEEME.md` | 2 | a8504c1298669724e89a7043edee4bc82697defa01668a0c26de02db2d461fb2 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/3 - Diagramas del sistema.pdf` | 1158 | a173e1f75e254fa4ae1690df63ed44469728dde5fb4f01db7b63b1488e18c90b |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/5 - Anexo de trazabilidad del uso de IA.pdf` | 954 | a497c69f080481a2d1ecf0d0b23461f73c66a35e0a41637d73bd943881757f97 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.docx` | 71 | a52eb8a7724a762ecc0d8ccf2ffdb0acc489d2e616d247038a92288ad8ea5986 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Log de prompts - Sistema.pdf` | 764 | 32dae91a8bb598440c1c06c7e826e24f1546fc69aaa88943f7dd0aeb68eda19f |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.docx` | 32442 | 08d445c01ad7fb6afc72668ff05ab1db9a291c5c3588e3bddcec1821f4cb7553 |
| `ENTREGA TECNOLOGIA/PRIMER ENTREGA/Solucion tecnologica - Entrega 1.pdf` | 5833 | fbf6c2b656c6da175b2763842aa3b1c34919d3fd041195205af9c8a134f837eb |
| `ENTREGA TECNOLOGIA/SEGUNDA ENTREGA/LEEME.md` | 1 | a09c637570d3ad15c1ce55d67e5dc673a883b0a50798eb6ac57801bafb7e6140 |
| `LEEME.md` | 2 | 9696eb7cfc20eda7023fdd82408fdffd16949daadfd48e049d3aed517d46953b |
| `README.md` | 4 | c17f654e18b6eb94c8dc93b9cc7fde30f2060c74a38087f1184fdd25e4048c01 |
| `codigo-fuente/.env.ejemplo` | 3 | 1183c477b0b1ca4ec8df302d42508b1681b84d133cfaa2d35380403872bd15e1 |
| `codigo-fuente/.github/workflows/ci.yml` | 12 | 685708e07dba7980f87129ebd2ce211ada24867e17dd328596554ce88dc490ad |
| `codigo-fuente/.gitignore` | 2 | 6129d93d92f7a15434fd1be22be6578cb88cbb3652bf054191ecce5a72969749 |
| `codigo-fuente/CLAUDE.md` | 6 | 12fa54af1e90ae23df476b155c5e4b13264100e048650db90c33d5cc0ea85325 |
| `codigo-fuente/COMO-EJECUTAR.md` | 5 | 36fd41900f1d26e86e92993b046b86f4b20defd963a7e66e502ed3490315e56f |
| `codigo-fuente/LICENSE` | 3 | 5b01ebad8c3eccb45ad5eff8a22c24be93c4c2fbfc631abc7aae1a8a65d7e0d7 |
| `codigo-fuente/README.md` | 10 | 0711e421911b1e77847595af7349ff4bd7d8dacc91b82ffe530745f5ce9137a5 |
| `codigo-fuente/arrancar.ps1` | 9 | dffba52b3c39bafda13c2bad9345e32d576f0eb102031ab2ae1b1a778a21a628 |
| `codigo-fuente/backend/.dockerignore` | 1 | 2949d3431c47f97c6eb921b8b25da46cf082392ee1a49925f0b4453d03ba6c37 |
| `codigo-fuente/backend/Backup/PredictIT.sln` | 8 | 6390bb17760bfb6c38301138a4c8f229f2b9640c1080324a1d4cf8dd30059528 |
| `codigo-fuente/backend/Directory.Build.props` | 1 | 6087e2278f3a0a3fc5830a8517568699650d189cdb56381cdb0092fd46551ac4 |
| `codigo-fuente/backend/Dockerfile` | 4 | 98b84c2512f63c364b29cc63c1b040c03263532ae169336a065fdf1bbbd08703 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/AdministracionController.cs` | 14 | cb5e79e569580a968f58907e17c3d825a849118de9fae4df8174716d478fe3e4 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/AutenticacionController.cs` | 4 | e67e392df4f08249ed7f5752fed162500975c62ad3ae9b58e088bd8dfe97ced1 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/EquiposController.cs` | 7 | 97ac4de40cd93b48da1fa81bdc40538cc9581993e4aa7a4cb5ab6a5b34feedd8 |
| `codigo-fuente/backend/PredictIT.Api/Controllers/IdiomasController.cs` | 3 | dd9e21bf5f3cb5ea7b34ff763033450b461e315867a314cf7b3c81c23097844b |
| `codigo-fuente/backend/PredictIT.Api/Controllers/IncidenciasController.cs` | 8 | 016969f660fe2049eb9a0229f28ba5339dbe7f2402c2ae994d89793349503ebd |
| `codigo-fuente/backend/PredictIT.Api/Controllers/ReportesController.cs` | 2 | d1f15f048ae94f0b8dd9ba74c9d4f96564b4ef63a700b2e75b31ab12b0a2734b |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/BarridoPredictivo.cs` | 6 | 6a3e62289b47b879b9022c2bb7dcbdc0de0b0ae52e11511750f0fae8e0a807b2 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/CabecerasDeSeguridad.cs` | 2 | 02c43e678e0ff2fdf8764f9bb1f12390d982ece5f33b188f87e93ce60868c081 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/ManejadorDeExcepciones.cs` | 4 | 12a23fea8868f07f0a3dedec4f620ce77ec45aab8fc803b308ec2d216b118840 |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/Metricas.cs` | 4 | 9b419d99a5b3c08278a6c0f464f1801ae5c6a752e73c4c5acdc3c8adcd5172ac |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/Politicas.cs` | 1 | 4230ded9f79c913ee67705f3d6ff5193c100a438f2b0cd7af66c54aff7b591ac |
| `codigo-fuente/backend/PredictIT.Api/Infraestructura/RequierePatenteAttribute.cs` | 3 | 91c657449a06173ce10cc62462899c4f9d54944debf384c292fc382613034f4f |
| `codigo-fuente/backend/PredictIT.Api/PredictIT.Api.csproj` | 2 | 24f3a25bf47078b5b3c639599ed0b55c23e2b0fb63799527a99681f761698f62 |
| `codigo-fuente/backend/PredictIT.Api/PredictIT.Api.http` | 1 | 6559e079440f78716de6f39d385177e54b23fdeebe60e9835209df040f966b47 |
| `codigo-fuente/backend/PredictIT.Api/Program.cs` | 21 | ea02658b98455d3213bb7fd893c213af19a8c53cccbcb2c74b421b7056d13813 |
| `codigo-fuente/backend/PredictIT.Api/Properties/launchSettings.json` | 1 | 97073825a96ae8fb5c1b090685defabc66c17367a667a87cd127a8c1883a9dfe |
| `codigo-fuente/backend/PredictIT.Api/appsettings.Development.json.ejemplo` | 2 | 0763855fa29cb1628c3f9edd95c67685b4aa8451cc75e5499881d11aa4d41ee4 |
| `codigo-fuente/backend/PredictIT.Api/appsettings.json` | 2 | 917b53c2fe1dabfc2a3aa9337fc52e2de4afe30b5ead408f1c27afb5b93aeedc |
| `codigo-fuente/backend/PredictIT.Api/packages.lock.json` | 17 | 2e0474a3b73b0b64ff7d86261f0876fe77b0a4de069d336e14e6dd168e47a134 |
| `codigo-fuente/backend/PredictIT.BLL/BusinessException.cs` | 2 | 223f5bb4e3d612232d301f75b6af0e1b7dc631198e6c65bc2f7f5a7f3261b725 |
| `codigo-fuente/backend/PredictIT.BLL/Contracts/Contratos.cs` | 16 | c1c596fe274ac8bf840ccc4a3fbc9a575c9c41d46fef2a6eac2f3b26a1d1d7ef |
| `codigo-fuente/backend/PredictIT.BLL/DTO/Dtos.cs` | 7 | 7729145911214bd5db3d6b452cdcb33053a630754d7fde099fea335ba5cfaab7 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosAdministracion.cs` | 9 | 71c344522307e1faa95acae03a6df99fc77f2a722350037a3b50ade1b81060d4 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosFacturacion.cs` | 3 | d58cd51ee9cba19a658ab7f865fcf851f21bee9e7b34c0ea494d9c3f12973454 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosIdioma.cs` | 2 | 2835282f974d8f33f675a0be95c4a661d6c43145edce91b07270d7fd602a4cdf |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosIncidencia.cs` | 11 | 885c74d5b9937a4ac18283bd071c3a71da3d31b084a615d50dfff3262fcfb3c4 |
| `codigo-fuente/backend/PredictIT.BLL/DTO/DtosMantenimientoProgramado.cs` | 3 | 7d8b39ea275b0d4921ec85eb9b5506c0636023f08940ebeaea4627076658926d |
| `codigo-fuente/backend/PredictIT.BLL/FactoryBusiness.cs` | 7 | 24b8fe7c6e586d30bf92c8075ae5a9b3b924752ea449dd3ce88b02c0a3f07805 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/AuditoriaBusiness.cs` | 4 | 38b744f5cb765595789975a1504e5a4a9f0da0bcd1f52aad84c0e3f482798a42 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/AutenticacionBusiness.cs` | 6 | 3cc63ba0eab1df4e42e3a19163956b491ab86dbd302e97975fecf4464acf04e0 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/BaseAdministracion.cs` | 3 | 0b4733123f72c9d449da743b6a90bc318c18d8163dfded2761a3a695f11c1d55 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/EquipoBusiness.cs` | 13 | d7b84343c347911bca74b16a31a3b649cad1006d81389d9f0c15038f2f88e839 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/FacturacionBusiness.cs` | 15 | 627993ef49698f80c2cb6fe52f7ac18d5c95feff6a6224d1159438d4749a583c |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/IdiomaBusiness.cs` | 5 | 6f9e0b94120e4394af21ff2175a6839996e636d7edd37aea8013d24123520354 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/IncidenciaBusiness.cs` | 38 | a3ecaf86de17dfd3ea78c8d5ea041eb478f9192f61fda8d6e78ba8fc137fc0ab |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/IntegracionIaBusiness.cs` | 8 | ad70f686469a07b0b4f32c9b4e541f053a7627d4a097c6489d78ebb125846296 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/MantenimientoBusiness.cs` | 10 | b4360796ba7279e05d25acc344d13aec6426ce1942521e73368476e6d48901f6 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/MantenimientoProgramadoBusiness.cs` | 14 | f381278df9c9ecefca8acc883ce9aef58aee346250c62bbed0f93597e2fe1b0c |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/OrganizacionBusiness.cs` | 8 | 296b514bf87628b9459772edf6496b89c693ac57a4c11acdc42acef7855e886e |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/PrediccionBusiness.cs` | 21 | da5c5c4b7364d7be8d5444b61862177277cb5d0478e646c17b82187897003487 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/ReporteBusiness.cs` | 12 | baa16b647efadd255442e7f57f6eff2e112e77be9d5bf38b692a5cae499c15c3 |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/RespaldoBusiness.cs` | 6 | 2b9ef483c1855fecc613c738ef3ac5ccfd20bc8ade45ed7b2ebd8edf04204eff |
| `codigo-fuente/backend/PredictIT.BLL/Implementations/UsuarioBusiness.cs` | 8 | 1f0a24b28ad27f11c7f50a5f9ce795ebc1ff64186d7d694ceff41faca85d69a2 |
| `codigo-fuente/backend/PredictIT.BLL/PredictIT.BLL.csproj` | 2 | 93e03f40e4fe8e0c48b0c79084289ed030c0f5e4063e4bcb8aa338a593de711d |
| `codigo-fuente/backend/PredictIT.BLL/packages.lock.json` | 14 | 315a8ef17d98f2524f79d9ee0bd1c7d02a69a87d54b2a284d3a4808590279a17 |
| `codigo-fuente/backend/PredictIT.DAO/Contracts/Contratos.cs` | 23 | 9ed711409f7b070ffe49699e26e8c5f400176a364ff2260d4061a82347500f13 |
| `codigo-fuente/backend/PredictIT.DAO/Factory/FactoryDao.cs` | 8 | 18d9554b17c62e4e8b5082ba4e4e4afd66d097d28824f47773524b6b53709e81 |
| `codigo-fuente/backend/PredictIT.DAO/Helpers/LectorExtensiones.cs` | 4 | 70165f11998a04943ba5c0852098149eb4a88253f6e9ede460bacfbc807a8915 |
| `codigo-fuente/backend/PredictIT.DAO/Helpers/Reloj.cs` | 2 | d241c7e7998297e6942c019606334a2bef41f21b27a04f0feaf4f0f000a2ef3c |
| `codigo-fuente/backend/PredictIT.DAO/Helpers/SqlHelper.cs` | 6 | 3c0fa8b6402cf22af9aecd022f2fef02a03609c66e2b7ca40a22a3f75a53e7a5 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/CatalogoDao.cs` | 7 | 8de928851406e792e6bee167e20e464b45934dfb122a0f8cc9ac745570989ec9 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/EquipoDao.cs` | 15 | 139ea265b88959fe7da7c483012f87d3e5ccf88f4f5d0d9825778f2fcbc6050a |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/FacturacionDao.cs` | 10 | 010cdf10d91fe0de5cd38d63cc98aa1fddb9547be110900caa9009d38c5da6d1 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/IdiomaDao.cs` | 4 | d6cbc5c3fc97aba2ff07bc5693f8332f13d2738f288d95e4b108342b7e4d1c45 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/IncidenciaDao.cs` | 19 | 5c703eaa360e8a03a18db106a83ef42e3317067006b1e799ff45f5c7eb66ad13 |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/MantenimientoProgramadoDao.cs` | 11 | 7d51c10731f5369784603b6b8fac0140a0408e622ac201104e2c33348df3659b |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/PrediccionDao.cs` | 17 | 08351165a672835f99578d5db90cb897cd8a78f40068689dc3e162175df606db |
| `codigo-fuente/backend/PredictIT.DAO/Implementations/SeguridadDao.cs` | 19 | 038426e911c945dee9dae788cfd865afa9a9dddd8e60a7d94053e6da679cbfc3 |
| `codigo-fuente/backend/PredictIT.DAO/Mappers/Mappers.cs` | 6 | 70d50b8a3400e1764c030e2cf54ab3339bc7d123ae96ada789408f330e6791a9 |
| `codigo-fuente/backend/PredictIT.DAO/Mappers/MappersIncidencia.cs` | 10 | 2b8528508d5a73844f03cffb235c903796cab3e3d9bd0ab4b8c8bf7e91bddf95 |
| `codigo-fuente/backend/PredictIT.DAO/PredictIT.DAO.csproj` | 1 | a52030fcfb3ac5e276e94cc923f9e20add75b6c49fa6945f5ee18dde424fee17 |
| `codigo-fuente/backend/PredictIT.DAO/packages.lock.json` | 8 | 1ffa0a37c7cd2db01364d7de2dbd8d0198c5528f172892129252528574384e6f |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Equipo.cs` | 5 | 381e76673d00ee1636701466f4b4b3312d9272a0c7a18f1cc4af9521e57fec73 |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Facturacion.cs` | 7 | f73516f06ad5561a2e38d511ec3fc873c0785561824a676abf448a72c89f9978 |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Incidencia.cs` | 8 | 413837cf0be1f413fd01c9410c3bab501bff6b5bb385ef3653c3d872c560b53e |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/MantenimientoProgramado.cs` | 4 | c92a895f3de058d7e43f43411524b87dc0b80621dfaec5a4d7c6888469f918bc |
| `codigo-fuente/backend/PredictIT.Domain/Negocio/Prediccion.cs` | 6 | e3816096c4b350f4f86c1ffd2915ccd2bc8c89fca21a6a3ae260d80197d95dba |
| `codigo-fuente/backend/PredictIT.Domain/PredictIT.Domain.csproj` | 1 | 4d29c3a189c0733e1a32b231953bc515877a4a26f81b22bca995551a432b2c61 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Bitacora.cs` | 5 | 10ba53540365f6c183803f6773b896b4e6c6b90fce7ffdc4cf1587dc60a233a3 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/ComponenteSeguridad.cs` | 2 | c5c3c484d2785a7f4b73660e20d9b5d22769c29c796611460d0677a051862cd5 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Familia.cs` | 2 | 970a1e6086c7ec265e8f336d89349e7cccc26b648564c52b0544c25feb2fef10 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Idioma.cs` | 2 | 9d06c68091064798cfef6504ba5a3dd572d61b34b63829601f489187c9b32cca |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Patente.cs` | 2 | b57168add65a61c89f27e20155b5f7bef8be740a1e8a833b56f6922ab05e6d07 |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Rol.cs` | 2 | 04df9be6b62d9b14c0647fd7494aae35a06a839d7be0e9e66434bb5ad00e072a |
| `codigo-fuente/backend/PredictIT.Domain/Seguridad/Usuario.cs` | 3 | 2b04179137fd8e47fe912772be8193caf097226b390cebd62baff4a4844fb3c7 |
| `codigo-fuente/backend/PredictIT.Domain/packages.lock.json` | 1 | 21309355e77d26df68664ac0899fbbacb314b0354d4a65cf8406751d68bd5ad8 |
| `codigo-fuente/backend/PredictIT.Service/Bitacora/BitacoraService.cs` | 9 | 33d31fcc40cb0b4b421e775e3f26e38245826b14c4723f9ddf38fd5c7db42f2a |
| `codigo-fuente/backend/PredictIT.Service/Bitacora/LoggerService.cs` | 2 | 45c5674f95d448ac9c6ab795bd408d4c0a661162587f58604dd07d6e1d9925c5 |
| `codigo-fuente/backend/PredictIT.Service/IA/Disyuntor.cs` | 8 | 5c9b04ce7099ca8ab494f00d22e0c6673e02988f4ed5134fa14ccdf3020c9edc |
| `codigo-fuente/backend/PredictIT.Service/IA/EstadoProveedor.cs` | 3 | 1b73b174a3ee79f68647b8758d93657408d9e3a5cebd106603bdbfb73b94fcb4 |
| `codigo-fuente/backend/PredictIT.Service/IA/ProveedorIA.cs` | 9 | f0b489666c5072f8e1d139c947a2d52388da785aeaa2b4f23d287f00f1604b09 |
| `codigo-fuente/backend/PredictIT.Service/IA/ProveedorIAClaude.cs` | 14 | 62a8d8e4e058e69b865b656b6c93dc505c19512bb3726da6ddb55e5cff6499bc |
| `codigo-fuente/backend/PredictIT.Service/IA/ProveedorIASimulado.cs` | 22 | d610c0f905583dc1a97bcfc9e347dc12647edb04a9cda4d81c3893997cef8376 |
| `codigo-fuente/backend/PredictIT.Service/IA/RegistroDisyuntores.cs` | 2 | 097051bdda09c7b94d3244c7769a0e62bdbd59315e8bdd1a218cd4bb4b931a22 |
| `codigo-fuente/backend/PredictIT.Service/Prediccion/MotorPredictivo.cs` | 18 | f8f137417cb747c0c2e7cd2e905f7d37b973ddfe3e377f9cae5435bca2abe6bc |
| `codigo-fuente/backend/PredictIT.Service/PredictIT.Service.csproj` | 1 | 134f15b6c555842cf00fa9013bd3bbc053eee38e7d2255560dc28b38b9d68d98 |
| `codigo-fuente/backend/PredictIT.Service/Reportes/ReporteService.cs` | 10 | b19321e9f9d234ef32d0d70259a6d52acefeca91ae3eda13da2f73a431b81017 |
| `codigo-fuente/backend/PredictIT.Service/Respaldos/RespaldoService.cs` | 9 | 06fca223f0073747624ae715b2afb9b0fdd5d42fb20cc4e7384f565f666c3423 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/CifradoService.cs` | 7 | 640ae2638caa4e0c862d88f24dc052d7efcdec826e60281fb6e8b04a1a64eb27 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/ContextoSesion.cs` | 3 | a8a76381ed1fbffe301300b6ef9b453e308d6d799c3f74ee94ec53c41290b6b3 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/HashContrasena.cs` | 4 | f79d49c6cf6481251869296025fa8f1c062eff4205d001bad5bba5a87b7577cd |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/SeguridadService.cs` | 8 | 97643fcbd9decbdcca74790dfed86b2c6c8a7325ae8192456d5abcc234413802 |
| `codigo-fuente/backend/PredictIT.Service/Seguridad/TokenService.cs` | 3 | 9b8cd5bb3aba998ef47b316ba5e32a429a3db0564de126ab488f5201a22d98d5 |
| `codigo-fuente/backend/PredictIT.Service/packages.lock.json` | 13 | b460262e377e00c4fe6928f6320045abc3848d2ed0c9170eead6b842331a7004 |
| `codigo-fuente/backend/PredictIT.Tests/Dao/AislamientoOrganizacionTests.cs` | 5 | 4727a44b6f3b89d5efa7f74dd6edcaa82ec0f85f7f215ac46781fcfdb4bfcdba |
| `codigo-fuente/backend/PredictIT.Tests/Dao/BitacoraConsultaTests.cs` | 5 | 196201aa995fd81b5e77da6de817e141555826a38c230c968558c89fb732b8ed |
| `codigo-fuente/backend/PredictIT.Tests/Dao/IncidenciaDaoTests.cs` | 14 | b9960ca827db8b136fdcf091629216654fe0cb3dc1000c8c25436c8bfb812960 |
| `codigo-fuente/backend/PredictIT.Tests/Dao/RelojUnicoTests.cs` | 3 | 7a609a97b525fed5c6af82418d5e0d7bb27eef547ce667726660b69721ffe963 |
| `codigo-fuente/backend/PredictIT.Tests/Dobles/Dobles.cs` | 20 | 65bb7d77f29feefc75047793174030b21041ab1010223ecec988f3fd52b55853 |
| `codigo-fuente/backend/PredictIT.Tests/Dobles/EquipoDaoFalso.cs` | 3 | 1a250b69537cc4c1b195c33dff288c0f13234fa1a3952f9c722b3e38bfef58f3 |
| `codigo-fuente/backend/PredictIT.Tests/IA/DisyuntorTests.cs` | 5 | ea57fc13a6b34337d727367177557ec61df0e196d59d7b4a7de411a5fd263ca6 |
| `codigo-fuente/backend/PredictIT.Tests/IA/GuiaConProveedorCaidoTests.cs` | 7 | 4d10e3153390b65b3f1333bb613c682e9180f93e970d1925ca4bb4bf2eb2208d |
| `codigo-fuente/backend/PredictIT.Tests/IA/GuiaReparacionTests.cs` | 7 | f895812d3b6f5a9d83617b05fda28397ab8361cf17da725d3509b1f178c59a35 |
| `codigo-fuente/backend/PredictIT.Tests/IA/ProveedorIATests.cs` | 13 | ec12bca1b5ec76a713aad58fab30c838f059731522f3df64105b346bdcc68763 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/BaseDatosSmokeTests.cs` | 5 | ab0519e834e4c32f7a2f2d827871937c6e7bd629329d198e6452ba906a38eb78 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/BulkheadTests.cs` | 3 | 6fe32179880e8c5a97a75288d2d54e734d742c5123333b159360916614802cd4 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/ClaveDeFirmaDePrueba.cs` | 2 | 52ad860a0fccab4f8b15375da1eb7abe697f53e5f187eeb865d02fa69e0a9a35 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/ContextoDePrueba.cs` | 7 | 3e74cb8cd77b8f0680c5b46f050c43478bd3c13f24103fa04feaa4494d9c8edf |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/EntornoPruebas.cs` | 2 | 0df7bbe7cf9b0839571f693843ea8fbf534f6f546a7d0929f91789b7416a77d5 |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/MetricasTests.cs` | 5 | ccc66cb8d1eaf96fa30185a447cbfe2dea02aba8fccd022be1ad9538700db9dd |
| `codigo-fuente/backend/PredictIT.Tests/Infraestructura/UsuarioSolicitante.cs` | 2 | 8479571e990cbcd8062b6051c824fb819be2ff5496491aec86b286b030d4d9bd |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/AltaDeEquipoTests.cs` | 8 | 02a955dbc3315e696394926a8664db126236b3296bdab9b4eea4a86bb2faa118 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/AltaDeIncidenciaTests.cs` | 4 | 600ed5b93cd5d5cae565afe9532bb9f559b0df16f8f230f254740850e98da94c |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/CatalogoFalsoEspejaLaBaseTests.cs` | 2 | f6ee2ff2006a6c74e79b0675a2f0dee2d142fc0c2bc9b7bff787f59722a44da5 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/CicloDelComprobanteTests.cs` | 12 | b2ca3ad42616377905ea0a4f44bbb088b325357fe5d1b0ef87c051e7d5c39462 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/EstadoOperativoDelEquipoTests.cs` | 6 | a9fbf8fe9363b43aa9894beeea15aac9e4689cc63d5a34df0cf4f46748996c10 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/FacturacionExtremoAExtremoTests.cs` | 9 | 3c665fa1ea8c3639f4306433d85c9e54d8e1ca6e1c4d7943444d74f5a6018a26 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/FiltroDesdeElContextoTests.cs` | 3 | 1f213cb5c4ebbc748630bbefcc5b52546b128cbf0d20a752bef2b57a0f35bd63 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/IndicadoresConClaveTests.cs` | 4 | 74bc1d56967261b82e21fe8bf86617cd2d02849c3759a7b6c0c067d0c2beaa3f |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/MaquinaDeEstadosIncidenciaTests.cs` | 11 | 4201e73afef6ddaea5cd312b7c6e25f92fb53c2d733b087b18c5cf8085c4a1a1 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/PeriodoFacturableTests.cs` | 4 | 10fd680844c3e725445bcb82b2c78ea7e7e74542f417fc487edc237354fbf111 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/ReasignacionPorLaApiTests.cs` | 7 | c049c4709e7ea1a112f290d2e83f6db66320edc4003d77a23d6b6ce95bc78a12 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/ResumenDeNavegacionTests.cs` | 6 | 171636db39351f88214dba3d980f0d0ad059854237169117620c4b27409a5eb4 |
| `codigo-fuente/backend/PredictIT.Tests/Negocio/SegmentosDelInventarioTests.cs` | 6 | b5b2d534356947fa93b1bf934990378e1fcff41ec546e384930c490d7be65373 |
| `codigo-fuente/backend/PredictIT.Tests/Prediccion/MantenimientoContraElPlanTests.cs` | 6 | 85d73c89cd56a993c5a29d3765b47036b4e65401cebe1f066e2eafb8e10a5e5c |
| `codigo-fuente/backend/PredictIT.Tests/Prediccion/MotorPredictivoTests.cs` | 17 | 8b0a543129206f51d8754ab398928854cdc103f28de15bee3ae399c3bb8b1d1e |
| `codigo-fuente/backend/PredictIT.Tests/PredictIT.Tests.csproj` | 2 | d5a7ccd0e0f22af7a5fc969ed81fe8eb31d153640d73e6ae83059514b157e23c |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BitacoraCatalogoTests.cs` | 4 | f82387480c0663b51bf232f261b3ceae0445453648a560d08b2504a7a08ae470 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BitacoraNoPierdeAsientosTests.cs` | 4 | 599deb13a0e32373995e378a8ab4255bdd330196429dd4982138459c826242b1 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/BloqueoPorIntentosTests.cs` | 4 | 7876a6849c0c30400ba0c1642761139e833212cece9459b0c365422b4b530a6b |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/CifradoTests.cs` | 5 | e9e9ce2a05152d6365d07b7105be93cdf5f470e09bd045709057decc711b4d3b |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/CodigoDeFalloDeLoginTests.cs` | 4 | c6d75b019e432231edb6ac3858091d333d7287d4cfdacb72af6f81160927df43 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/CompositePermisosTests.cs` | 7 | e5c30e3415eaadd07da1aa1d8d5d60893e53b1efd53880bdc3caf7296e84f68d |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/HashContrasenaTests.cs` | 6 | 86216901106729978679864e34fb527ed9a47aaa3eb34eaaf3bff4ab1e588ecc |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/LimitePorOrigenTests.cs` | 3 | 5a49538f8c85d6d2e7d40815ffa3ba900d98c7467bbbd131f7cce3dfdd8773cd |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/ReglaDeReasignacionTests.cs` | 5 | 16441dbae87525ea779089c11df4e1b7522439d7cc8ee2c587e3563debe18d89 |
| `codigo-fuente/backend/PredictIT.Tests/Seguridad/RehashAlEntrarTests.cs` | 4 | 3d3df0ef02b717918c882e7fb3434925a6e1541080955d98170ec5d05ae8bb46 |
| `codigo-fuente/backend/PredictIT.Tests/packages.lock.json` | 31 | 62bd9438ba0f8754d947c7f2ff7b33301a489a1b745e9a1e72399b062b3cfd76 |
| `codigo-fuente/backend/PredictIT.sln` | 8 | 99b28d6d7072cfeb1f326d3fecf026263c889c4c5c38a17521b43708b4235c65 |
| `codigo-fuente/backend/UpgradeLog.htm` | 20 | ba44aea8fc12d29e4c83606a8b7c5cb67643db21f0ab3dfc4d9f97628009eed5 |
| `codigo-fuente/db/01-negocio-schema.sql` | 39 | 71f18c85ba3e9ffb8d9edeb000e44cdd8f72ca7a35b906049bab530906d9b594 |
| `codigo-fuente/db/02-servicio-schema.sql` | 14 | a4a48d8e2aa39458c3601658813d395f529d255c07a495f750a7decfcf95a8fc |
| `codigo-fuente/db/03-seed-servicio.sql` | 24 | f26c2280a4f64a126fabab0ef37ace8c30d7357b21e2f22e674ee8e6f7d18492 |
| `codigo-fuente/db/04-seed-negocio.sql` | 44 | 929ab42b9fa6ad1e47e74b04f47642177a8dd00d3d24493a4673ed472a2d2917 |
| `codigo-fuente/db/05-seed-traducciones.sql` | 112 | 9c8b40d94f7a96e62c5299d2214d0450d697d9f3cac7af1ce1c353a72408181a |
| `codigo-fuente/db/06-usuario-de-aplicacion.sql` | 4 | 49e79ddf35fc90c64277df333eb0700cb181dc02132f8215b29ca04c722cd172 |
| `codigo-fuente/db/aplicar.ps1` | 3 | 27a9d67999ea6a51aa730c92ecb78ae526f2faa6c0e7f56ed8cf527406934bfe |
| `codigo-fuente/docker-compose.yml` | 8 | e440d1d2909247b5f36901d74a00ebcd54c5bf3e57245aeee5c62f250eb47f54 |
| `codigo-fuente/frontend/.dockerignore` | 1 | 152ff6a76d9487a05a70969999493b9487a2e98cfbc9d40b323941b5068ce35a |
| `codigo-fuente/frontend/.env.local` | 1 | 194e44d8fa48d82c0e2ccb59f6d0838bc9253dbcefe462e491575dfd8acdec40 |
| `codigo-fuente/frontend/.gitignore` | 1 | b72f5f72d9038fd0c4b4a56730560aac98ad898e48b63c63db145e33c355f431 |
| `codigo-fuente/frontend/Dockerfile` | 2 | 9efe793c4b332ca50c1ea0336bc2d5a08a0f48f4d241f3884898ff841dca674d |
| `codigo-fuente/frontend/cabeceras-de-seguridad.conf` | 2 | bf5fb0c8e58bdd90df524a2f99cfd02effd7903b80cd9a6aef8de0a3011e46a2 |
| `codigo-fuente/frontend/index.html` | 1 | 0ce1a48e9ff0a063629eec45a36ba8b667d397e77e03dd8aca8f034e7b61c07e |
| `codigo-fuente/frontend/nginx-tls.conf` | 4 | 0515d642b7c62f2344ca8a72d9d6287666bc7ab58c1f1a3d1928c76d4b391c6f |
| `codigo-fuente/frontend/nginx.conf.template` | 4 | 577b468b102d5ac2bb840c41f0eb0ed993ef495c5090455bbced91ba3ace9295 |
| `codigo-fuente/frontend/package-lock.json` | 96 | 0d0f6916229fb342178544c110bd6d3ad63630cc2c4cf856854ca6028f822aaf |
| `codigo-fuente/frontend/package.json` | 1 | 4e0f213312e560819c71f57b6aec6661a069dd420487f6d4ef4d6ce5dc87fd68 |
| `codigo-fuente/frontend/scripts/capturar-pantallas.mjs` | 14 | 36752e056191cabf5c3d06f7e0a90e1cc5da4de5501f8ffedc4a696bc580068b |
| `codigo-fuente/frontend/scripts/idioma-en-pantalla.mjs` | 6 | f90d75feada1ab240b14f6fa4232750e3c584da7502e7b3e3f5c761af38b1406 |
| `codigo-fuente/frontend/src/App.tsx` | 6 | fcfcc16bbc53de4af3c504ed5df61f9c6e575ef513839af88ea1e6c9f2b1a55b |
| `codigo-fuente/frontend/src/api/cliente.ts` | 19 | 830b449aa9f1c372bb36b71768d34759669437a49982ac5ad28706814444a116 |
| `codigo-fuente/frontend/src/api/tipos.ts` | 20 | 34ff6c399fed69e97e4b106723eefe60796a3acc1c808401bd88510b0f7c6616 |
| `codigo-fuente/frontend/src/componentes/Estados.tsx` | 5 | 1b927e5b1ce0810c19bdd504b83e4086e573a5c3266ab32023d56d71eaf4a28a |
| `codigo-fuente/frontend/src/componentes/FormularioEquipo.tsx` | 12 | 71c6f5fd676fc4e5ffdbed345847ba76e8b083e4fe771d914fb059dbc392e0a2 |
| `codigo-fuente/frontend/src/componentes/GuiaReparacion.tsx` | 9 | e8f74628419fe1d90b9ff4b06a6135e3f258800db71c49adfa35e1b7041d7f23 |
| `codigo-fuente/frontend/src/componentes/Iconos.tsx` | 3 | e2fe3a4831551f6177f09c0c0fe15a60ca8e8bbfc410f36fde9ef4671359fb8e |
| `codigo-fuente/frontend/src/componentes/Indicador.tsx` | 2 | 466fe3406e2e574cb536e6308253c83ca5affed31f06d79b4d93a915934852a2 |
| `codigo-fuente/frontend/src/componentes/Layout.tsx` | 14 | 266797a5e0d01c8d90d1619fd397908f82f3151524857334155ece218d92d2e6 |
| `codigo-fuente/frontend/src/componentes/NivelRiesgo.tsx` | 4 | d738c9c1b9a9b6f5dc5b009c322944ef26174d1e36204bef470e10d246be9479 |
| `codigo-fuente/frontend/src/componentes/PanelAtencion.tsx` | 8 | 04b19ab28f5f0146dc7b90eacf1f916ca7ec3404eab4dc86d8bdfc6bc99ce4b1 |
| `codigo-fuente/frontend/src/componentes/PanelCalibracion.tsx` | 6 | 4a2086f9f573699a99394d5041658756d36dadf8fcc5733d606bab2aafc26001 |
| `codigo-fuente/frontend/src/componentes/Semantica.tsx` | 10 | 1caffca4057b9400f91b467494e1ead9931e5ef5c30d0a6db94e92c53d2d740b |
| `codigo-fuente/frontend/src/componentes/SenalPredictiva.tsx` | 3 | 0d43a63714f2234108f9f087e2ba90dff27c871eba62c1cc02dee775c8f7d785 |
| `codigo-fuente/frontend/src/estilos/app.css` | 39 | ce3e934f537995c7554345caf56641d4b948fca856395cc38c2fe06584158053 |
| `codigo-fuente/frontend/src/estilos/base.css` | 2 | e565a121e4d74650b595b861345b8d3f8325c2cdb066abea2d83ac36743d7654 |
| `codigo-fuente/frontend/src/estilos/responsive.css` | 10 | 02cf959c5bb1b8973b778e5247da28c3b19618bd1e92a367c84c1db139302886 |
| `codigo-fuente/frontend/src/estilos/temas.css` | 1 | 038135e36b1a8b6a254beefe1793a341d5125de9b86b74db825868150345c103 |
| `codigo-fuente/frontend/src/estilos/tokens.css` | 6 | 077e22131c50a3ed08d5e23317cb17935b70ca8fa16c96ac91118a2eb34848b1 |
| `codigo-fuente/frontend/src/idioma/IdiomaContext.tsx` | 7 | 60c6b481e8292e76795a65ecf00a950b15a74871d5fe748c9297e33f948138a5 |
| `codigo-fuente/frontend/src/idioma/formato.ts` | 4 | 486cfce9973ad923cfcf128b2f7c8db0a64330ed5c407fe44860779b7e072de8 |
| `codigo-fuente/frontend/src/idioma/hace.ts` | 2 | 7c41e1c67feaeec61c5259b16a5070029c39bbd036b873ad601f8f4310e855e2 |
| `codigo-fuente/frontend/src/idioma/plural.ts` | 2 | df13875f8574c0266b2bc082f52bcd3d461c58ce900b9d7c5d7b70a56e420b80 |
| `codigo-fuente/frontend/src/main.tsx` | 2 | e53bec206fc74962319723f038b382c138826c6f7257e0440224d51d122035fe |
| `codigo-fuente/frontend/src/paginas/Activos.tsx` | 16 | 5a947561a31e2271c211a0da2ce75c7ad0bb510e148be19873fcfe7d9b0ac4ee |
| `codigo-fuente/frontend/src/paginas/Agenda.tsx` | 20 | 99d5d161e125d4a1b27864c531694f3acbeefac45b6a61803a2f81c4cfacd77e |
| `codigo-fuente/frontend/src/paginas/Apariencia.tsx` | 18 | 99af8dbd1a895f9b6e9ea1777903ac5f907afa6a709656b1e282ac85b1ee90bc |
| `codigo-fuente/frontend/src/paginas/Bitacora.tsx` | 11 | 10f0701d5c71ac14a6dabb5f36ffd5be2a5faa8b81adec7f1e495d4be255607a |
| `codigo-fuente/frontend/src/paginas/Dashboard.tsx` | 12 | 8726ebd66c9afd71793484c1a4b2fd5e1d2703daaadf8f010772f04d49d1bd9d |
| `codigo-fuente/frontend/src/paginas/EquipoDetalle.tsx` | 23 | 4ee7ec491aa661629077a4160e38eaad1bf319b42311d5ac68eb735021afa9d9 |
| `codigo-fuente/frontend/src/paginas/Errores.tsx` | 11 | 32c0581902f01d2e1f581b02b02a5c6cbd8cc4ad666e7bec66e15917f94eb33a |
| `codigo-fuente/frontend/src/paginas/Facturacion.tsx` | 19 | a7e2cbc92e9949f88849597f282b24efa8f9c7f5de171310574a1358a41a45c2 |
| `codigo-fuente/frontend/src/paginas/FueraDeAlcance.tsx` | 6 | 6dc16939b3d18c227844ce01eb8028b2ab7dae4fef751b52c27cdeb1ff6a667f |
| `codigo-fuente/frontend/src/paginas/Historial.tsx` | 8 | 28ae022eba031f952cea204e9a0e6615ddb87a4c5f90595511e31fbfc493873c |
| `codigo-fuente/frontend/src/paginas/IncidenciaDetalle.tsx` | 14 | 5c1cffa7dd4778ccc41c77847bd91ca197a0c05f1491cf7bcdfe505739c24088 |
| `codigo-fuente/frontend/src/paginas/IncidenciaNueva.tsx` | 12 | 268f9082240a9163811d6be4e0bca8bd838fdc2b8274e9f2d0cb0072daacf3df |
| `codigo-fuente/frontend/src/paginas/Incidencias.tsx` | 21 | 1d2a78f1d7dd6fce39b4f1b49e5db0805e85ec43caaf5d891b32a5c0d4071d89 |
| `codigo-fuente/frontend/src/paginas/IntegracionIa.tsx` | 20 | ecffc0191471e3ac1b1f60782bf0cca45d8bc1fc639c25f6f8ea2557553db9e7 |
| `codigo-fuente/frontend/src/paginas/Login.tsx` | 11 | 0d4835c1b8acf7fee81aed138a6dcd972e1362ffc0ec941a3ab97eb292977fe7 |
| `codigo-fuente/frontend/src/paginas/Mantenimientos.tsx` | 16 | f3450bde567a304471b638a310e1629bb0708290d800bddc39ab6a33e3fd759c |
| `codigo-fuente/frontend/src/paginas/MisEquipos.tsx` | 5 | 1d425cbd59712db3f903a3839365c90e6f9852d37fc28f86fbfc812af3bea5c9 |
| `codigo-fuente/frontend/src/paginas/NoEncontrada.tsx` | 3 | 1098867c0da6c22145ea394300b5b51f6068665007734d7d06e75b6a38bf5ff2 |
| `codigo-fuente/frontend/src/paginas/Organizacion.tsx` | 13 | 0d2771c56bc0b41cb19cb5d2a0e7b37d705d2adec184c2acd2daaa5e7835e8ba |
| `codigo-fuente/frontend/src/paginas/Planes.tsx` | 16 | fbb510a825a1284dc6a7738a93552739f3b4286cc80cbd6f740c0c2edf6a086a |
| `codigo-fuente/frontend/src/paginas/Predictivo.tsx` | 17 | 582e05fff096a60888bf38537df6a713d1742d299dab41e228be2ece51b7d3a2 |
| `codigo-fuente/frontend/src/paginas/Reglas.tsx` | 14 | e5948da4b71fbb4d2af1fc78668a0b6200f4a068b2ff4600b25815f059c35a8f |
| `codigo-fuente/frontend/src/paginas/Reportes.tsx` | 9 | fb279f532e2963ee99d87347c2afea69db5edd8cc6d980004e6842c748fa8352 |
| `codigo-fuente/frontend/src/paginas/Respaldos.tsx` | 13 | 299c661a8d7ec87d25de9119bcf3f928729d47bbe31e94f56c0328dff310e5d0 |
| `codigo-fuente/frontend/src/paginas/Usuarios.tsx` | 16 | de5a7a2cad5d3bb88aab986a1f18519557acce4e0e6dd689e471ccca234c18b7 |
| `codigo-fuente/frontend/src/paginas/cliente/MisPedidos.tsx` | 6 | 84ac1df6b4319d1ae4211ea1147231782274add721b4474e2709abe34abf0660 |
| `codigo-fuente/frontend/src/paginas/cliente/PedidoDetalle.tsx` | 9 | ccc723edca9a2aab20c250f84e441c7ab9550a5255ce1329f7292b8f97b8eac6 |
| `codigo-fuente/frontend/src/paginas/cliente/Reportar.tsx` | 16 | d233dc43fd481341391809d2906ffe22a488cc05e04cdb8cb5fdcd6032e4ea92 |
| `codigo-fuente/frontend/src/paginas/cliente/avance.ts` | 3 | 1872cbbcf11fb01e91bfca5c06b0d0b9aa7af20d9ecaf9052a73571df6ba9019 |
| `codigo-fuente/frontend/src/pruebas/Activos.test.tsx` | 10 | c6088cb5a105da3e4d1279b66d48df43d4e7e2a3ac8e7d2e450a2982fccc52d0 |
| `codigo-fuente/frontend/src/pruebas/Agenda.test.tsx` | 7 | bd123214e69a8398e2ca03928a96bdb13b1192c7edcc7fd1c1f5adb81c613048 |
| `codigo-fuente/frontend/src/pruebas/ErroresDeFormulario.test.tsx` | 4 | 3f497ca08128c5ec4147179ea45033dcbe5aac7807230d5807a745e3a02aff41 |
| `codigo-fuente/frontend/src/pruebas/Facturacion.test.tsx` | 9 | e8948954aa9318fa8d2bc03d76e4749c6e24264412360ca10741b9003ccba347 |
| `codigo-fuente/frontend/src/pruebas/Idioma.test.tsx` | 5 | b418247708aca696083a88fe3fa6af9da8ab7d108abbe83e7f54b9b21a536754 |
| `codigo-fuente/frontend/src/pruebas/InsigniasDeNavegacion.test.tsx` | 5 | 452005f81eaab43945dfcf8a45d5c21a0030343dfa944207e3b7ca37f0768bad |
| `codigo-fuente/frontend/src/pruebas/Mantenimientos.test.tsx` | 5 | 5f5f8f0821969e7780b6a1e1b936de75fa1978ead056130744b0d6d1f2d165ec |
| `codigo-fuente/frontend/src/pruebas/Organizacion.test.tsx` | 7 | e2a85f9687f25d66ca6850c09e2393dffe6b4f834d7ba19f354e3a275dfba87d |
| `codigo-fuente/frontend/src/pruebas/Planes.test.tsx` | 7 | 0aa7819d44aa4843b7153bfe1fbda9a9720ccccfffcf33c5a905b718e943bd01 |
| `codigo-fuente/frontend/src/pruebas/Rutas.test.tsx` | 6 | 82319512205c51007c131c56bca248d2c2cb016578e829e6cd940a559184aba7 |
| `codigo-fuente/frontend/src/pruebas/SegmentosDelInventario.test.tsx` | 6 | cd3678bc5827185fb718cb3e27ffcd3181f6e27a4430be8c2a6a301cbbd5d639 |
| `codigo-fuente/frontend/src/pruebas/SenalPredictiva.test.tsx` | 2 | 40fb780347f6bdf6c4c8c5b0ba25feb9ada10cc5af6765fd4fcfd8a84968c633 |
| `codigo-fuente/frontend/src/pruebas/TableroDeIncidencias.test.tsx` | 9 | c9cd3dcc5a651192e4ea6da244ca0e3575cdea42abac6d5fb3812ee2a5f84148 |
| `codigo-fuente/frontend/src/pruebas/cliente.test.ts` | 5 | a90dd685a1eac15eec1866363ea605a443c0a456ff55cadc973f5de584d644b9 |
| `codigo-fuente/frontend/src/pruebas/preparar.ts` | 1 | 91a3c8962a0edcb956206a501d943fe99e1c78c6d4d8b5c9a948a3362c75978c |
| `codigo-fuente/frontend/src/sesion/SesionContext.tsx` | 3 | bd0dce46ea5445cdfb678a5280ab8562c8014db6904112f1c38e427c056f31a9 |
| `codigo-fuente/frontend/src/tema/TemaContext.tsx` | 10 | 210b8d0a426fed214669e96235c31a1446d1352431ede5e220e90f45303fe204 |
| `codigo-fuente/frontend/tsconfig.json` | 1 | 6d4cc44a5253630275eb37be5d2d0b32889f5b9c6c72d2579058c566650f0b61 |
| `codigo-fuente/frontend/vite.config.ts` | 2 | 2f4b7ffee46b3daae8dd471c51652206646e25a85eb2ee1070a671c170bc0177 |
| `codigo-fuente/scripts/_textos-sin-traducir.json` | 1 | 37b8d1e3dfa5a5b0568f9c86ec8b4e2e6e1ddd766c0ea81e48a7ec231df77232 |
| `codigo-fuente/scripts/cobertura.py` | 9 | e83075a575afe79015087728f0bc848b9d7460351664fad894a3db61a088407d |
| `codigo-fuente/scripts/medir-carga.py` | 19 | ee40d328dbe4a941648d0ee4e33f40183507e14f2514efad127e5bd0b1be5184 |
| `codigo-fuente/scripts/residuo-de-las-pruebas.py` | 4 | 4d83a0d7df817f8fae1b01b7d25c16445aeb248754c61571f37483d3f0423a19 |
| `codigo-fuente/scripts/textos-sin-traducir.py` | 18 | e21cbded0e0aae29d527a3be6da3ca6a93fc86eef0640ed272eb19cb17b243e2 |
