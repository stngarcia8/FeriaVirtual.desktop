-- Archivo: script_fv-popul.sql
--      Inserta los registros iniciales a feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
ALTER SESSION SET CURRENT_SCHEMA = fv_user;
ALTER SESSION SET NLS_LANGUAGE= 'SPANISH' NLS_TERRITORY= 'Spain' NLS_CURRENCY= '$' NLS_ISO_CURRENCY= 'AMERICA' NLS_NUMERIC_CHARACTERS= '.,' NLS_CALENDAR= 'GREGORIAN' NLS_DATE_FORMAT= 'DD-MON-RR' NLS_DATE_LANGUAGE= 'SPANISH' NLS_SORT= 'BINARY';


prompt;
prompt insertando registros iniciales.;
prompt ----------------------------------------;


prompt Insertando categorias de productos.;
INSERT INTO fv_user.categoria_producto
VALUES (1, 'Exportación');
INSERT INTO fv_user.categoria_producto
VALUES (2, 'Venta nacional');


prompt Insertando medios de transportes.;
INSERT INTO fv_user.tipo_transporte
VALUES (1, 'Aereo');
INSERT INTO fv_user.tipo_transporte
VALUES (2, 'Terrestre');
INSERT INTO fv_user.tipo_transporte
VALUES (3, 'Maritimo');


prompt Insertando condiciones de pago.;
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion)
VALUES (1, 'CONTADO');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion)
VALUES (2, '1 MES');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion)
VALUES (3, '2 MESES');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion)
VALUES (4, '3 MESES');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion)
VALUES (5, '4 MESES');


prompt Insertando estados de las ordenes de compra.;
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (1, 'RECEPCIONADO');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (2, 'PROPUESTA GENERADA');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (3, 'SUBASTA PUBLICADA');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (4, 'SUBASTADO');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (5, 'DESPACHADO');
insert into fv_user.estado_pedido 
values (6, 'ENTREGADO');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (7, 'ACEPTADO');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (8, 'RECHAZADO');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado)
VALUES (9, 'CANCELADO');


prompt Insertando paises.;
INSERT INTO fv_user.pais
VALUES (1, 'Alemania', '+54');
INSERT INTO fv_user.pais
VALUES (2, 'Argentina', '+49');
INSERT INTO fv_user.pais
VALUES (3, 'Australia', '+61');
INSERT INTO fv_user.pais
VALUES (4, 'Austria', '+43');
INSERT INTO fv_user.pais
VALUES (5, 'Belgica', '+32');
INSERT INTO fv_user.pais
VALUES (6, 'Brasil', '+55');
INSERT INTO fv_user.pais
VALUES (7, 'Bulgaria', '+359');
INSERT INTO fv_user.pais
VALUES (8, 'Canada', '+1');
INSERT INTO fv_user.pais
VALUES (9, 'Chile', '+56');
INSERT INTO fv_user.pais
VALUES (10, 'China', '+86');
INSERT INTO fv_user.pais
VALUES (11, 'Colombia', '+57');
INSERT INTO fv_user.pais
VALUES (12, 'Croacia', '+385');
INSERT INTO fv_user.pais
VALUES (13, 'Dinamarca', '+45');
INSERT INTO fv_user.pais
VALUES (14, 'Egipto', '+20');
INSERT INTO fv_user.pais
VALUES (15, 'España', '+34');
INSERT INTO fv_user.pais
VALUES (16, 'Francia', '+33');
INSERT INTO fv_user.pais
VALUES (17, 'Grecia', '+30');
INSERT INTO fv_user.pais
VALUES (18, 'Holanda', '+31');
INSERT INTO fv_user.pais
VALUES (19, 'India', '+91');
INSERT INTO fv_user.pais
VALUES (20, 'Italia', '+39');
INSERT INTO fv_user.pais
VALUES (21, 'Japon', '+81');
INSERT INTO fv_user.pais
VALUES (22, 'Mexico', '+52');
INSERT INTO fv_user.pais
VALUES (23, 'Noruega', '+47');
INSERT INTO fv_user.pais
VALUES (24, 'Peru', '+51');
INSERT INTO fv_user.pais
VALUES (25, 'Portugal', '+351');
INSERT INTO fv_user.pais
VALUES (26, 'Qatar', '+974');
INSERT INTO fv_user.pais
VALUES (27, 'Rusia', '+7');
INSERT INTO fv_user.pais
VALUES (28, 'Reino Unido', '+44');
INSERT INTO fv_user.pais
VALUES (29, 'Sudafrica', '+27');
INSERT INTO fv_user.pais
VALUES (30, 'Suecia', '+46');
INSERT INTO fv_user.pais
VALUES (31, 'Suiza', '+41');
INSERT INTO fv_user.pais
VALUES (32, 'Tailandia', '+66');
INSERT INTO fv_user.pais
VALUES (33, 'Turquia', '+90');
INSERT INTO fv_user.pais
VALUES (34, 'Usa', '+1');
INSERT INTO fv_user.pais
VALUES (35, 'Uruguay', '+598');
INSERT INTO fv_user.pais
VALUES (36, 'Vietnam', '+84');


prompt Insertando ciudades.;
INSERT INTO fv_user.ciudad
VALUES (1, 1, 'Berlin');
INSERT INTO fv_user.ciudad
VALUES (2, 1, 'Munich');
INSERT INTO fv_user.ciudad
VALUES (3, 2, 'Buenos Aires');
INSERT INTO fv_user.ciudad
VALUES (4, 2, 'Cordoba');
INSERT INTO fv_user.ciudad
VALUES (5, 3, 'Sidney');
INSERT INTO fv_user.ciudad
VALUES (6, 3, 'Melbourne');
INSERT INTO fv_user.ciudad
VALUES (7, 3, 'Canberra');
INSERT INTO fv_user.ciudad
VALUES (8, 4, 'Viena');
INSERT INTO fv_user.ciudad
VALUES (9, 5, 'Bruselas');
INSERT INTO fv_user.ciudad
VALUES (10, 5, 'Brujas');
INSERT INTO fv_user.ciudad
VALUES (11, 6, 'Brasilia');
INSERT INTO fv_user.ciudad
VALUES (12, 6, 'Rio de janeiro');
INSERT INTO fv_user.ciudad
VALUES (13, 6, 'Sao Paulo');
INSERT INTO fv_user.ciudad
VALUES (14, 7, 'Sofia');
INSERT INTO fv_user.ciudad
VALUES (15, 8, 'Ottawa');
INSERT INTO fv_user.ciudad
VALUES (16, 8, 'Toronto');
INSERT INTO fv_user.ciudad
VALUES (17, 8, 'Montreal');
INSERT INTO fv_user.ciudad
VALUES (18, 9, 'Santiago');
INSERT INTO fv_user.ciudad
VALUES (19, 9, 'Valparaiso');
INSERT INTO fv_user.ciudad
VALUES (20, 9, 'Valdivia');
INSERT INTO fv_user.ciudad
VALUES (21, 9, 'Concepcion');
INSERT INTO fv_user.ciudad
VALUES (22, 10, 'Pekin');
INSERT INTO fv_user.ciudad
VALUES (23, 10, 'Shanghai');
INSERT INTO fv_user.ciudad
VALUES (24, 11, 'Bogota');
INSERT INTO fv_user.ciudad
VALUES (25, 11, 'Medellin');
INSERT INTO fv_user.ciudad
VALUES (26, 12, 'Zagreb');
INSERT INTO fv_user.ciudad
VALUES (27, 13, 'Copenhague');
INSERT INTO fv_user.ciudad
VALUES (28, 14, 'El cairo');
INSERT INTO fv_user.ciudad
VALUES (29, 15, 'Madrid');
INSERT INTO fv_user.ciudad
VALUES (30, 15, 'Barcelona');
INSERT INTO fv_user.ciudad
VALUES (31, 16, 'Paris');
INSERT INTO fv_user.ciudad
VALUES (32, 17, 'Atenas');
INSERT INTO fv_user.ciudad
VALUES (33, 18, 'Amsterdam');
INSERT INTO fv_user.ciudad
VALUES (34, 19, 'Nueva Delhi');
INSERT INTO fv_user.ciudad
VALUES (35, 19, 'Bombay');
INSERT INTO fv_user.ciudad
VALUES (36, 20, 'Roma');
INSERT INTO fv_user.ciudad
VALUES (37, 20, 'Milan');
INSERT INTO fv_user.ciudad
VALUES (38, 21, 'Tokio');
INSERT INTO fv_user.ciudad
VALUES (39, 22, 'Ciudad de Mexico');
INSERT INTO fv_user.ciudad
VALUES (40, 22, 'Monterrey');
INSERT INTO fv_user.ciudad
VALUES (41, 23, 'Oslo');
INSERT INTO fv_user.ciudad
VALUES (42, 24, 'Lima');
INSERT INTO fv_user.ciudad
VALUES (43, 25, 'Lisboa');
INSERT INTO fv_user.ciudad
VALUES (44, 25, 'Oporto');
INSERT INTO fv_user.ciudad
VALUES (45, 26, 'Doha');
INSERT INTO fv_user.ciudad
VALUES (46, 27, 'Moscu');
INSERT INTO fv_user.ciudad
VALUES (47, 27, 'San Petersburgo');
INSERT INTO fv_user.ciudad
VALUES (48, 28, 'Londres');
INSERT INTO fv_user.ciudad
VALUES (49, 29, 'Manchester');
INSERT INTO fv_user.ciudad
VALUES (50, 30, 'Estocolmo');
INSERT INTO fv_user.ciudad
VALUES (51, 31, 'Berna');
INSERT INTO fv_user.ciudad
VALUES (52, 31, 'Zurich');
INSERT INTO fv_user.ciudad
VALUES (53, 32, 'Bangkok');
INSERT INTO fv_user.ciudad
VALUES (54, 33, 'Ankara');
INSERT INTO fv_user.ciudad
VALUES (55, 33, 'Estambul');
INSERT INTO fv_user.ciudad
VALUES (56, 34, 'Washington');
INSERT INTO fv_user.ciudad
VALUES (57, 34, 'Los Angeles');
INSERT INTO fv_user.ciudad
VALUES (58, 34, 'New York');
INSERT INTO fv_user.ciudad
VALUES (59, 34, 'Miami');
INSERT INTO fv_user.ciudad
VALUES (60, 35, 'Montevideo');
INSERT INTO fv_user.ciudad
VALUES (61, 36, 'Hanoi');


prompt Insertando tipos de contratos.;
INSERT INTO fv_user.tipo_contrato (id_tipo_contrato, desc_tipo_contrato)
VALUES (1, 'Externo');
INSERT INTO fv_user.tipo_contrato (id_tipo_contrato, desc_tipo_contrato)
VALUES (2, 'Interno');


prompt Insertando roles de usuario.;
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol)
VALUES (1, 'Administrador');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol)
VALUES (2, 'Consultor');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol)
VALUES (3, 'Cliente externo');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol)
VALUES (4, 'Cliente interno');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol)
VALUES (5, 'Productor');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol)
VALUES (6, 'Transportista');


prompt Insertando seguros de ejemplo.;
insert into fv_user.seguro
values (1, 'COBERTURA CARGA TRANSPORTES MENORES', 'AXA Seguros', 21665);
insert into fv_user.seguro
values (2, 'COBERTURA CARGA TERRESTRE (CAMIONES)', 'Mapfre', 77853);
insert into fv_user.seguro
values (3, 'SEGURO CARGA MARITIMA', 'Mapfre', 33166);
insert into fv_user.seguro
values (4, 'SEGURO CARGA AEREA', 'Mapfre', 33895);
insert into fv_user.seguro
values (5, 'SEGURO DE DAÑOS POR CAUSA EXTERNA', 'AXA Seguros', 53427);


prompt Insertando usuarios de ejemplo.;
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('71113D3D-D65B-8A8E-6694-F48292F59A3C', 'e.sampson_1', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'mattis@Donecfringilla.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('A83D9F11-548D-C290-1D2C-716554C8CCC9', 'n.oliver_2', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'quis.urna.Nunc@metusAliquam.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('60F811E9-26CF-1CE1-0373-0BF907702BC1', 'h.cote_3', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'non.dui.nec@nec.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('CFD7A815-723C-1A73-D745-2C1C0894B7EC', 'a.rich_4', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'varius.et@temporbibendumDonec.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('3275EDE5-8837-71C8-286E-046C7F45E3C7', 'a.rasmussen_5', '6f57196fd9309e992379d3c90fec691531219eea',
        'diam.dictum.sapien@parturient.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('AF8C6E47-89B9-5ED6-1788-6481E67FA825', 'k.oliver_6', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'eu@Maecenas.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('B65CD187-801F-B7EA-8054-4263B0944820', 'j.holden_7', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'orci.quis.lectus@felispurusac.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('0A8E7B9E-16A5-3423-9FA3-5C6771E10AAF', 'x.mcpherson_8', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'sociis.natoque.penatibus@nuncsed.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('9DE276CB-2BFC-B171-A54F-394E2DF4E3AB', 'a.collier_9', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'ac.fermentum.vel@penatibusetmagnis.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('BDFB5196-450B-54B6-C0AD-05BA07C001A6', 't.fuentes_10', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'ornare.facilisis.eget@Nulla.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('FA309828-BA8C-C46F-89D2-E777C9B0A3A8', 'g.oneal_11', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'magna@egetodio.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('7AB2F2F4-80D1-9310-4285-D3031B6FCDC0', 'j.singleton_12', '6f57196fd9309e992379d3c90fec691531219eea',
        'laoreet.ipsum@Sed.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('02DDBDE3-C0D7-A61F-2D24-300B19752496', 'z.cobb_13', '6f57196fd9309e992379d3c90fec691531219eea',
        'gravida@magnisdis.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('06B528A2-5E7E-3D36-3509-73423E8E7FB4', 'k.foreman_14', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'sociis.natoque.penatibus@eu.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('0178AEF4-A201-1207-FB15-AE7E6678BEB4', 'm.gregory_15', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'scelerisque@rutrum.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('A350743B-F9FF-6DB3-A2D6-260951DC6B5D', 't.wood_16', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'iaculis.odio@eleifendvitae.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('CE2DB363-9DED-B445-6388-89F93B2D98D3', 'j.dillon_17', '6f57196fd9309e992379d3c90fec691531219eea',
        'faucibus.id.libero@netuset.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('2D5259EA-B23F-B1DE-046D-913121F34F14', 'a.haynes_18', '6f57196fd9309e992379d3c90fec691531219eea',
        'pretium@Donecat.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('611DD38A-4D3A-4297-11ED-BCF2F38DF072', 'a.gibson_19', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'facilisis.Suspendisse.commodo@vehicula.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('39E6EB7E-1084-4C6A-AD92-4472FE1A8214', 'z.morton_20', '6f57196fd9309e992379d3c90fec691531219eea',
        'Quisque@volutpatornare.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('05041BA1-4CB9-F982-93A6-A74848D3704E', 'j.conrad_21', '6f57196fd9309e992379d3c90fec691531219eea',
        'mi.Aliquam.gravida@nullaInteger.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('12C8F79E-A481-B703-1754-6B8D6887DAF6', 'a.wise_22', '6f57196fd9309e992379d3c90fec691531219eea',
        'dictum.Phasellus.in@maurisut.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('F09777DC-4CAA-8E7D-442B-D49683A722CE', 'k.michael_23', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'dui.Fusce@turpis.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('98617B24-C1B6-4ADD-8F99-7E835DB80E6E', 'v.sharpe_24', '6f57196fd9309e992379d3c90fec691531219eea',
        'mus@nunc.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('516C9049-0409-B0AD-5C40-CF73AEF7CBEB', 'a.gates_25', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'quis.accumsan@massalobortisultrices.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('3C10A7DA-9F9E-AACE-9D01-24A33C88347C', 'k.craft_26', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'mauris@ipsumportaelit.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('5A02C2E0-A4C9-F384-3D31-F0123C690341', 'r.reeves_27', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'at.fringilla.purus@elitEtiamlaoreet.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('7B9E6D7C-10F7-48A2-225D-BF222EC3A6CB', 'r.pearson_28', '6f57196fd9309e992379d3c90fec691531219eea',
        'sollicitudin@Phasellus.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('B45D5253-AE77-2122-19B2-1D5FDDDB8CD2', 's.sloan_29', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'Maecenas.mi.felis@montesnascetur.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('2ACEC887-5C53-1D96-7A51-FCC2C597F6C3', 'b.navarro_30', '6f57196fd9309e992379d3c90fec691531219eea',
        'Lorem.ipsum.dolor@tinciduntDonec.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('767CB491-5963-215A-DC0A-9C048A16BCD8', 'z.carey_31', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'egestas.hendrerit@ac.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('F2299F75-86FC-6122-DEF1-7A64DABDDA98', 'n.schmidt_32', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'nunc@velit.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('1CC2E7EB-8827-725A-3219-9F319B549A8E', 'k.fuentes_33', '6f57196fd9309e992379d3c90fec691531219eea',
        'aliquet.sem.ut@magna.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('2A71700F-4CDF-8F15-01E6-7CA5A6C35E75', 's.cooke_34', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'Morbi.non@egestas.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('353383E4-2EAB-90E9-3A0A-419F17659CD0', 'b.jacobs_35', '6f57196fd9309e992379d3c90fec691531219eea',
        'Sed.eget.lacus@rutrum.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('B16E666C-DAFE-D20E-2B5E-EC00E3D0D99B', 'k.rasmussen_36', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'augue@Namacnulla.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('05BCEFBC-711C-01C7-E072-1F42763886B0', 'h.hughes_37', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'nunc@Suspendisse.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('D3FB2057-96F9-01B7-5690-2CE0ABDD8F61', 'a.york_38', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'metus.In.lorem@lectusrutrum.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('DA097448-5611-551E-F4E0-18A90D22BE26', 'k.mendez_39', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'justo.sit@imperdiet.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('74ACC626-32D7-575D-6C51-2FE435CFADE2', 'w.harding_40', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'ipsum@Proinvelarcu.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('4D3FF80C-2A11-7FCD-DBEC-BB9C27033B43', 'h.francis_41', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'purus@accumsanlaoreetipsum.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('97924568-6740-650D-447E-9C6552BA3468', 'l.hudson_42', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'Curabitur.vel@velit.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('88B6EA46-A605-7230-EDCB-A936BDF32CA2', 'c.vargas_43', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'a.sollicitudin@elitNullafacilisi.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('4E662759-D5E6-B165-ACF3-4D0E3593474C', 'a.knowles_44', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'Maecenas.mi.felis@lorem.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('E052F8C4-27CC-E236-AA53-8CD222447BF9', 'l.moss_45', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'ipsum@metus.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('3CE5D794-7FB9-93F4-C19E-0631204B2172', 'a.bird_46', '6f57196fd9309e992379d3c90fec691531219eea',
        'id@nonluctussit.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('81CD34E0-46AB-1892-B8DC-D9FA80E06AC9', 'p.garrett_47', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'pellentesque.eget.dictum@tinciduntorci.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('E60C8F5B-3795-6D83-1F60-17644C6D6627', 'h.hensley_48', '6f57196fd9309e992379d3c90fec691531219eea',
        'augue@Donecfelisorci.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('0430E484-F943-F80D-60BE-324F3ADFB04F', 'a.colon_49', '6f57196fd9309e992379d3c90fec691531219eea',
        'velit.in.aliquet@vitae.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('C27AB4F3-6884-2991-0D4D-953F33D9381B', 'a.barr_50', '6f57196fd9309e992379d3c90fec691531219eea',
        'at.sem@enimEtiamgravida.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('17D7E8ED-5709-F4DD-2F50-D0C9ED232270', 'h.gould_51', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'commodo.hendrerit.Donec@Naminterdum.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('584A4262-1066-23BE-452C-E1A5EB784D51', 'o.harper_52', '6f57196fd9309e992379d3c90fec691531219eea',
        'pede.Cras@Phaselluselitpede.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('257CCC1B-4B59-A9CF-72BC-5653CF8ECEC4', 'g.frazier_53', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'commodo.hendrerit.Donec@a.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('D93BE04B-5AD1-67E1-CE70-0BCB44FC08E9', 'm.castillo_54', '6f57196fd9309e992379d3c90fec691531219eea',
        'turpis@nuncsed.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('0A8CF376-6CAF-D454-BE56-D576991843D3', 'c.wyatt_55', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'aliquam.enim@pede.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('17E5BE75-BD7D-DAD1-1D73-C3CD8892E4F3', 'j.lindsay_56', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'vulputate.nisi.sem@leoin.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('AE5404FB-55D6-06C0-624F-A562E329E1CC', 'h.hancock_57', '6f57196fd9309e992379d3c90fec691531219eea',
        'tellus@tempus.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('AD094C59-BEB6-B61C-74FA-B2B5EF9E61D0', 's.christensen_58', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'euismod@dictumaugue.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('35279A9C-5150-C86A-5E6A-A9409E2FE1BD', 's.barber_59', '6f57196fd9309e992379d3c90fec691531219eea',
        'rutrum.magna@Donecegestas.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('7B41AA6B-3CF4-8D08-C1C3-EE6EC5DEB67B', 'h.stephens_60', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'pede@noncursus.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('C8E6E770-6B9B-49AE-9187-FBA4BB29127A', 'y.reese_61', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'morbi.tristique.senectus@cursusa.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('FAE5B888-B7B7-BF21-7D7F-B0B765C9FB14', 'k.cleveland_62', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'dictum.ultricies.ligula@scelerisque.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('AFB70A28-758F-830E-9B36-1AF9638884F7', 'k.luna_63', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'Donec.felis@nasceturridiculus.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('ABC40374-F915-49FA-1606-4FE709CD49C3', 'w.conley_64', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'et.ipsum.cursus@convallisligula.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('BB852354-92E1-498E-092E-D95A607FF082', 'a.frye_65', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'risus.Nunc.ac@risus.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('B684C627-CB6E-CE32-FA4C-5F1F066245DA', 'a.gillespie_66', '6f57196fd9309e992379d3c90fec691531219eea',
        'lectus.ante@sitamet.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('F0315162-9FA7-C3B9-A637-753FEEA649DE', 'r.adkins_67', '6f57196fd9309e992379d3c90fec691531219eea',
        'et@lobortistellus.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('012CC128-0925-5E94-80D7-2FA0DCECA3C1', 'a.randolph_68', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'mollis@iaculisenim.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('A448D3E4-566E-7DDA-5E2F-32B1817E67B6', 'j.huffman_69', '6f57196fd9309e992379d3c90fec691531219eea',
        'erat.neque@ullamcorpereu.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('AE4A88A0-29EF-046A-E220-9F2E166071D3', 'b.lee_70', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'dolor.egestas.rhoncus@et.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('B27E5BD8-481E-8C86-3FFC-86EB6E5C04FA', 'a.lucas_71', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'felis.adipiscing.fringilla@Inscelerisquescelerisque.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('E6AA3BA9-4400-EE96-60EF-F9D9D1CA9A0F', 't.stanley_72', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'primis.in@purusinmolestie.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('2DCF754A-95F6-3ED8-598B-22981FA9087F', 'a.osborn_73', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'elementum@ornare.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('BE49D8F8-963C-0A68-8F21-8DCCDC34572B', 'a.glenn_74', '6f57196fd9309e992379d3c90fec691531219eea',
        'enim.Sed.nulla@velitCras.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('CC6E6823-B965-8478-3DB6-2C66B70D17C4', 'l.higgins_75', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'vitae.posuere@neque.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('7213F6A4-9A6F-7CA5-1B98-3D641920A09A', 'j.weiss_76', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'dolor.dapibus@nequeseddictum.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('C65B9D65-7BB9-7B8D-1D49-167D309D205C', 's.bright_77', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'Quisque.imperdiet.erat@vestibulumMaurismagna.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('28C419E1-4467-9865-6EFF-17E35D37117A', 'f.williamson_78', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'tincidunt@lorem.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('CCB84760-13D1-DAF2-6AB1-7DBD5E05C130', 'a.wilcox_79', '6f57196fd9309e992379d3c90fec691531219eea',
        'Duis@antedictumcursus.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('0634281B-37B8-F867-6B16-E5980F8E91F9', 'j.marshall_80', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'orci.Ut.semper@ullamcorper.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('EA6DFD9A-529C-2C6E-BF9E-53075F4CDD70', 'c.mcmahon_81', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'Integer.in.magna@per.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('A2BEB802-D419-7460-0962-A801444D9D0A', 'a.meyer_82', '6f57196fd9309e992379d3c90fec691531219eea',
        'et@volutpatNullafacilisis.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('C961CBEB-F528-9933-6497-B791BF006D06', 'd.hanson_83', '6f57196fd9309e992379d3c90fec691531219eea',
        'odio@eget.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('171CC34B-309F-5B84-3F72-4D318C172757', 'f.trevino_84', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'vulputate.lacus.Cras@loremvitae.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('1E3173D0-003E-6DED-7645-1F1B9E7C6ECA', 'c.sanders_85', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'Aenean@nec.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('5955B205-B8C8-3335-106D-37C2D2D4CB3F', 'r.frazier_86', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'molestie.in.tempus@auctorquistristique.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('BD230695-68B4-7740-7C2D-40A2E65907BF', 'c.miller_87', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'laoreet@Duisrisusodio.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('133E679C-F570-35BA-029D-99D7FA54CEF7', 'k.parsons_88', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'ac.eleifend.vitae@vitae.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('42CF3DE3-707B-7054-7251-D27A0856A18A', 'b.ayers_89', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'ullamcorper.eu@Vestibulumaccumsanneque.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('1696A6A8-24C5-EBB2-04FD-70434FEC5CEF', 'a.meyer_90', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'Nunc.laoreet.lectus@urnaUttincidunt.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('A6B456DC-E1B0-C0F4-99B7-0A1BA399282A', 'g.greene_91', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'eu.placerat@Sedegetlacus.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('719D5D38-97C4-7FB9-D095-C1A299B61321', 'h.warner_92', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'vehicula@lectusNullam.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('700FD20E-E48F-FC5A-DE6B-091098FC2C55', 'b.wallace_93', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'et.rutrum@acsemut.edu', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('E272C111-811D-1041-E3C6-ED181CF07287', 'f.gutierrez_94', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'Mauris@aliquetdiamSed.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('1446FC62-9D46-1F3F-AAAA-88FA0348D10E', 'r.knight_95', '6f57196fd9309e992379d3c90fec691531219eea',
        'scelerisque.sed@insodaleselit.ca', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('80F7F7A8-DCCF-55A1-9AB1-5DC14A0CF114', 'q.richmond_96', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'placerat@Quisque.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('8017C170-3EA7-4261-9945-52D04FB0B70C', 'k.mccarty_97', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'mauris@aliquamadipiscing.org', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('531144BA-BAA4-8949-0F52-8EBE68F4A801', 'r.small_98', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'ac@pellentesquetellus.net', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('93FB9F17-2670-AB05-575B-5096F30AB71F', 'l.lambert_99', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'molestie@nec.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('D8B1B280-4496-9553-1B39-F411126ECF29', 'p.flowers_100', '6f57196fd9309e992379d3c90fec691531219eea',
        'augue.ut@auctorullamcorper.co.uk', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));


update fv_user.usuario
set email = 'stngarcia8@gmail.com';


prompt Insertando clientes de ejemplo.;
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', '71113D3D-D65B-8A8E-6694-F48292F59A3C', 5, 'Eliana', 'Sampson',
        '6592006-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('FB2F21E5-47F4-1788-C177-6C112B0E0677', 'A83D9F11-548D-C290-1D2C-716554C8CCC9', 4, 'Neville', 'Oliver',
        '31308688-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('5E99EE33-E0F7-A74F-A1BA-D6670F57DEDB', '60F811E9-26CF-1CE1-0373-0BF907702BC1', 4, 'Hoyt', 'Cote',
        '33797716-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('2EB967B8-8D60-BA31-99CC-C77C060180F2', 'CFD7A815-723C-1A73-D745-2C1C0894B7EC', 4, 'Alexander', 'Rich',
        '9898809-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('03F6B49B-E999-55B1-8A14-7D8AB3AFF8FC', '3275EDE5-8837-71C8-286E-046C7F45E3C7', 3, 'Adrienne', 'Rasmussen',
        '8102910-5');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('DC5F45E8-83F6-C054-3FFD-193D13F6779F', 'AF8C6E47-89B9-5ED6-1788-6481E67FA825', 5, 'Kaye', 'Oliver',
        '13607951-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('CE234B46-DD54-0E88-53BC-0B6495C910B6', 'B65CD187-801F-B7EA-8054-4263B0944820', 6, 'Jermaine', 'Holden',
        '36198816-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('E3AC99B6-9944-1171-41E9-31B10390255E', '0A8E7B9E-16A5-3423-9FA3-5C6771E10AAF', 5, 'Xavier', 'Mcpherson',
        '15268726-5');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('DA90D3BD-551D-ED37-A2B2-189A0B15F204', '9DE276CB-2BFC-B171-A54F-394E2DF4E3AB', 6, 'Amena', 'Collier',
        '26222503-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 'BDFB5196-450B-54B6-C0AD-05BA07C001A6', 6, 'Tate', 'Fuentes',
        '6387754-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('FEF17043-B6B1-70F0-0D5B-A702E8083054', 'FA309828-BA8C-C46F-89D2-E777C9B0A3A8', 4, 'Gareth', 'Oneal',
        '23195480-5');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('DE6467D5-CDF0-DE45-2854-1FD5BF32D199', '7AB2F2F4-80D1-9310-4285-D3031B6FCDC0', 3, 'Jelani', 'Singleton',
        '29745888-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('1BD3B0BA-8887-A13C-2A9F-5B5D8C6F3B2C', '02DDBDE3-C0D7-A61F-2D24-300B19752496', 3, 'Zena', 'Cobb',
        '21424975-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('3CFE902A-252D-7661-F09D-838D426F06B6', '06B528A2-5E7E-3D36-3509-73423E8E7FB4', 4, 'Kenyon', 'Foreman',
        '5550539-K');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('B1D65B14-1BF0-B8A8-BE21-AEE4D6CEF118', '0178AEF4-A201-1207-FB15-AE7E6678BEB4', 4, 'Mark', 'Gregory',
        '42145441-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('ABF92493-B3A5-A69F-B855-638C8E97943E', 'A350743B-F9FF-6DB3-A2D6-260951DC6B5D', 5, 'Thomas', 'Wood',
        '20148368-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('4D03AF9E-039C-818D-7FDF-32E318573A78', 'CE2DB363-9DED-B445-6388-89F93B2D98D3', 3, 'Jemima', 'Dillon',
        '31352495-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('F1044EE8-F5D2-F671-6411-F0F128520DA9', '2D5259EA-B23F-B1DE-046D-913121F34F14', 3, 'Abdul', 'Haynes',
        '40659011-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('8780BE17-7D4E-7871-D595-B623110B33CA', '611DD38A-4D3A-4297-11ED-BCF2F38DF072', 6, 'Armando', 'Gibson',
        '24599224-6');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('7345A92A-1BAD-ECD2-79C0-21171D436FE4', '39E6EB7E-1084-4C6A-AD92-4472FE1A8214', 3, 'Zahir', 'Morton',
        '19866318-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('7577F044-80C6-0AAC-11C5-201D82103AC1', '05041BA1-4CB9-F982-93A6-A74848D3704E', 3, 'Jason', 'Conrad',
        '15544090-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('0DC1D3BF-5DF7-B8BA-7D80-9524A9898EF9', '12C8F79E-A481-B703-1754-6B8D6887DAF6', 3, 'Alice', 'Wise',
        '7674581-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('AA4BA0C1-2A06-DB9D-8821-72EF7E6C2BA0', 'F09777DC-4CAA-8E7D-442B-D49683A722CE', 4, 'Kylie', 'Michael',
        '35566605-0');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('6F334378-50EE-82BE-C6EE-1198834F4F5A', '98617B24-C1B6-4ADD-8F99-7E835DB80E6E', 3, 'Vernon', 'Sharpe',
        '23718164-6');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('23503EED-AD11-8B76-5874-B73DBE0813B1', '516C9049-0409-B0AD-5C40-CF73AEF7CBEB', 6, 'Alexis', 'Gates',
        '12444844-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('367ACDA1-E000-3AE5-F70C-9EED14F8F2FE', '3C10A7DA-9F9E-AACE-9D01-24A33C88347C', 4, 'Kylie', 'Craft',
        '10776692-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', '5A02C2E0-A4C9-F384-3D31-F0123C690341', 6, 'Ronan', 'Reeves',
        '26198703-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('1982FFAE-AE7D-F5A5-620B-472918916F1F', '7B9E6D7C-10F7-48A2-225D-BF222EC3A6CB', 3, 'Regina', 'Pearson',
        '31515108-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 'B45D5253-AE77-2122-19B2-1D5FDDDB8CD2', 5, 'Shay', 'Sloan',
        '9862432-5');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('4689BD45-68E1-75F0-8E63-49CD7BC67E1D', '2ACEC887-5C53-1D96-7A51-FCC2C597F6C3', 3, 'Brenna', 'Navarro',
        '10758061-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('C08AD0B2-078A-DB01-A5C5-BB1066D862CB', '767CB491-5963-215A-DC0A-9C048A16BCD8', 6, 'Zoe', 'Carey',
        '35865563-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('64C3D8D6-ABF2-483E-F49C-A51E21A542AC', 'F2299F75-86FC-6122-DEF1-7A64DABDDA98', 6, 'Nathan', 'Schmidt',
        '32366284-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('C992CD9C-F0E6-7FFE-3429-CE94B64B0644', '1CC2E7EB-8827-725A-3219-9F319B549A8E', 3, 'Kimberly', 'Fuentes',
        '12675144-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('12D60502-FBD5-3A47-440F-6E3EA0E5BF74', '2A71700F-4CDF-8F15-01E6-7CA5A6C35E75', 4, 'Sylvester', 'Cooke',
        '39487322-5');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('2518FFFF-0137-CF55-4C17-A241F5ADCCCF', '353383E4-2EAB-90E9-3A0A-419F17659CD0', 3, 'Breanna', 'Jacobs',
        '32472562-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('AF0132BD-FC3B-4863-6CC3-6F7D39061403', 'B16E666C-DAFE-D20E-2B5E-EC00E3D0D99B', 6, 'Kaseem', 'Rasmussen',
        '32432918-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('59E9EDB7-872A-BAB4-64EF-CE795C522389', '05BCEFBC-711C-01C7-E072-1F42763886B0', 4, 'Henry', 'Hughes',
        '12890921-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('7F3BF2FE-30CA-B6BA-AA35-A381C64A51BD', 'D3FB2057-96F9-01B7-5690-2CE0ABDD8F61', 4, 'Ava', 'York', '25301180-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('E538C425-17A7-5E54-7005-6B0A3362F76A', 'DA097448-5611-551E-F4E0-18A90D22BE26', 4, 'Kiona', 'Mendez',
        '45046085-0');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('93E57380-FE5C-2935-3791-261E8CE4E504', '74ACC626-32D7-575D-6C51-2FE435CFADE2', 6, 'Wayne', 'Harding',
        '14454990-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('F2203EBF-6610-0BFD-5EEA-330AFA1C5364', '4D3FF80C-2A11-7FCD-DBEC-BB9C27033B43', 4, 'Hedwig', 'Francis',
        '48699229-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('022DA8FA-7D31-A8CF-86D4-634AA7DF584E', '97924568-6740-650D-447E-9C6552BA3468', 5, 'Lara', 'Hudson',
        '43490169-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('A5C11DC3-667D-DAD1-B953-42C5AEC36D72', '88B6EA46-A605-7230-EDCB-A936BDF32CA2', 6, 'Charity', 'Vargas',
        '5255230-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('E78C0C53-359F-367B-18E4-70CE59C86790', '4E662759-D5E6-B165-ACF3-4D0E3593474C', 5, 'Amir', 'Knowles',
        '12606119-6');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('849D8880-4DE9-34D8-52D7-B276B12A5732', 'E052F8C4-27CC-E236-AA53-8CD222447BF9', 6, 'Lani', 'Moss',
        '32552999-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('213C6B17-44FE-C2CA-433D-58FE5B76C456', '3CE5D794-7FB9-93F4-C19E-0631204B2172', 3, 'Alden', 'Bird',
        '23408865-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('94474AB6-CEFC-6021-F63E-902A8237FC24', '81CD34E0-46AB-1892-B8DC-D9FA80E06AC9', 5, 'Portia', 'Garrett',
        '19514181-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('AF6F7981-034E-878E-8E7D-E1AA6B5C8875', 'E60C8F5B-3795-6D83-1F60-17644C6D6627', 3, 'Hasad', 'Hensley',
        '24134695-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('F48F8C29-7ACD-BA77-957B-963AD3D0E4B4', '0430E484-F943-F80D-60BE-324F3ADFB04F', 3, 'Anne', 'Colon',
        '42836330-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('5BF6A50A-7551-611A-2E72-E9DB4530E047', 'C27AB4F3-6884-2991-0D4D-953F33D9381B', 3, 'Adrienne', 'Barr',
        '45404924-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('87E3997E-A548-2E7B-F1A2-32EAE852C990', '17D7E8ED-5709-F4DD-2F50-D0C9ED232270', 6, 'Holmes', 'Gould',
        '16010479-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('DA270437-F17F-D407-F96D-62F25184BB5A', '584A4262-1066-23BE-452C-E1A5EB784D51', 3, 'Orlando', 'Harper',
        '19352536-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('18617AC0-E801-3E0B-C12E-61D01FE4339E', '257CCC1B-4B59-A9CF-72BC-5653CF8ECEC4', 5, 'Gregory', 'Frazier',
        '40006022-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('01E0F1DA-57DE-6E55-96EC-5FEAE3404A0F', 'D93BE04B-5AD1-67E1-CE70-0BCB44FC08E9', 3, 'Murphy', 'Castillo',
        '26748477-5');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('968B493A-973A-DA71-D390-578A9E3DA972', '0A8CF376-6CAF-D454-BE56-D576991843D3', 4, 'Chester', 'Wyatt',
        '30727118-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('A7B3C85B-80D2-1887-1B90-0C415292AB9D', '17E5BE75-BD7D-DAD1-1D73-C3CD8892E4F3', 4, 'Jescie', 'Lindsay',
        '33322563-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('68532DB8-6249-3281-26F8-B1545141DC86', 'AE5404FB-55D6-06C0-624F-A562E329E1CC', 3, 'Hedy', 'Hancock',
        '6437939-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('29B03BCF-F643-3B3D-D51C-4288DB2D480C', 'AD094C59-BEB6-B61C-74FA-B2B5EF9E61D0', 6, 'Steven', 'Christensen',
        '8048325-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('56AE3E25-131F-FB67-ACA4-BFBE5C01B618', '35279A9C-5150-C86A-5E6A-A9409E2FE1BD', 3, 'Signe', 'Barber',
        '10723509-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('0BE7F31F-27BE-B0B1-F988-65EA5898D0EC', '7B41AA6B-3CF4-8D08-C1C3-EE6EC5DEB67B', 6, 'Hayes', 'Stephens',
        '43894123-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('805C1C90-61AC-6401-1BEC-EC1AA19B2215', 'C8E6E770-6B9B-49AE-9187-FBA4BB29127A', 5, 'Yvonne', 'Reese',
        '25708889-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('A5E73437-2C89-8AEC-177F-AA991E062FD2', 'FAE5B888-B7B7-BF21-7D7F-B0B765C9FB14', 6, 'Kelly', 'Cleveland',
        '16945674-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('AFCE0767-6C6D-2503-7CA4-1783456F9E86', 'AFB70A28-758F-830E-9B36-1AF9638884F7', 5, 'Kermit', 'Luna',
        '38088133-0');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('E73ADDFD-E4FC-F39E-01B4-09A30FAC2A4A', 'ABC40374-F915-49FA-1606-4FE709CD49C3', 4, 'Wilma', 'Conley',
        '16585799-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('61024E5C-4972-5DBF-B994-7BB46838C9BF', 'BB852354-92E1-498E-092E-D95A607FF082', 5, 'Adara', 'Frye',
        '23723151-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('98B238C5-F716-9AC7-10B9-585EEA0A29A8', 'B684C627-CB6E-CE32-FA4C-5F1F066245DA', 3, 'Axel', 'Gillespie',
        '47390687-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('DAF41C60-E4EE-F5F8-0884-E5D42901C68E', 'F0315162-9FA7-C3B9-A637-753FEEA649DE', 3, 'Ruby', 'Adkins',
        '31394591-K');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('CFBD312C-959D-2D2A-BA88-2D5CD5AE90B9', '012CC128-0925-5E94-80D7-2FA0DCECA3C1', 6, 'Abdul', 'Randolph',
        '15323401-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('312408A4-EFDB-C7CA-6B93-0A666A136A13', 'A448D3E4-566E-7DDA-5E2F-32B1817E67B6', 3, 'Jessica', 'Huffman',
        '21245061-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('C299319F-7A2D-AF6F-9FBD-E87096D6E592', 'AE4A88A0-29EF-046A-E220-9F2E166071D3', 6, 'Breanna', 'Lee',
        '21050475-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('871B88C8-5717-D40A-D63A-8AE0EA455EB0', 'B27E5BD8-481E-8C86-3FFC-86EB6E5C04FA', 5, 'Avye', 'Lucas',
        '18290073-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('4F337ABF-094D-2862-3F74-154FCAE0ABC8', 'E6AA3BA9-4400-EE96-60EF-F9D9D1CA9A0F', 4, 'Tyler', 'Stanley',
        '21442767-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('7942D66B-48F3-7D46-C0A5-35438E884FCA', '2DCF754A-95F6-3ED8-598B-22981FA9087F', 6, 'Alma', 'Osborn',
        '23406503-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('4AFBAF51-0F15-67A3-F8C4-3516ADDFFBCD', 'BE49D8F8-963C-0A68-8F21-8DCCDC34572B', 3, 'Allen', 'Glenn',
        '13525728-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 'CC6E6823-B965-8478-3DB6-2C66B70D17C4', 6, 'Leo', 'Higgins',
        '41540322-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('E2F01091-1E05-84A3-6151-DF9C6D57F3D5', '7213F6A4-9A6F-7CA5-1B98-3D641920A09A', 5, 'Jolene', 'Weiss',
        '47175787-K');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('67F5F3B0-5F37-70F0-8F77-B73D55050685', 'C65B9D65-7BB9-7B8D-1D49-167D309D205C', 6, 'Sandra', 'Bright',
        '21941527-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('52FEB6E9-5A05-0F92-6660-68F735E1F420', '28C419E1-4467-9865-6EFF-17E35D37117A', 6, 'Forrest', 'Williamson',
        '45203660-6');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('6DE633EE-1DE7-9F2B-56EE-A425D4639160', 'CCB84760-13D1-DAF2-6AB1-7DBD5E05C130', 3, 'Abraham', 'Wilcox',
        '41608711-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', '0634281B-37B8-F867-6B16-E5980F8E91F9', 5, 'Jamal', 'Marshall',
        '30044912-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('57E4B237-0A80-F863-82B1-03F79448ECF9', 'EA6DFD9A-529C-2C6E-BF9E-53075F4CDD70', 4, 'Chaim', 'Mcmahon',
        '6662998-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('61412D09-4B46-0EC1-70D2-011A939E6D64', 'A2BEB802-D419-7460-0962-A801444D9D0A', 3, 'Avye', 'Meyer',
        '19072696-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('7483EE78-95A3-F3BF-24C2-A80FCFA20FBC', 'C961CBEB-F528-9933-6497-B791BF006D06', 3, 'David', 'Hanson',
        '34747315-4');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('276AB396-5F07-5021-C48D-132C3511491B', '171CC34B-309F-5B84-3F72-4D318C172757', 6, 'Flavia', 'Trevino',
        '6533263-9');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('E2C5C22D-C684-5B12-E5CC-D85AD03167CA', '1E3173D0-003E-6DED-7645-1F1B9E7C6ECA', 4, 'Colin', 'Sanders',
        '19237820-6');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('AE2A05FB-D2F9-AF86-FE2D-C6128EAAFE2F', '5955B205-B8C8-3335-106D-37C2D2D4CB3F', 6, 'Rana', 'Frazier',
        '28910818-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('8B6DE622-56A7-B8F8-799D-F94FB9707A53', 'BD230695-68B4-7740-7C2D-40A2E65907BF', 4, 'Cody', 'Miller',
        '9753452-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('FEE20ADE-F5B6-34FB-93D8-440524364C15', '133E679C-F570-35BA-029D-99D7FA54CEF7', 4, 'Kyra', 'Parsons',
        '14071039-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('9524DD38-0255-24E8-0D0F-BD984D167543', '42CF3DE3-707B-7054-7251-D27A0856A18A', 6, 'Brady', 'Ayers',
        '25557797-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('D58E722D-E117-9188-D846-2709D6CB4A51', '1696A6A8-24C5-EBB2-04FD-70434FEC5CEF', 6, 'Aurelia', 'Meyer',
        '40742113-2');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('F5EBCFB9-A97F-ABC2-369C-752595093003', 'A6B456DC-E1B0-C0F4-99B7-0A1BA399282A', 6, 'Gary', 'Greene',
        '20461211-0');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('94B68D21-A50A-A98A-5FF1-D5B2D9E74F1D', '719D5D38-97C4-7FB9-D095-C1A299B61321', 4, 'Howard', 'Warner',
        '27791934-6');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('500746E6-20FD-1AD4-8268-425438D51A2E', '700FD20E-E48F-FC5A-DE6B-091098FC2C55', 4, 'Brynn', 'Wallace',
        '14699411-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('3F338E43-49C5-0331-BF79-5B9494C974CA', 'E272C111-811D-1041-E3C6-ED181CF07287', 6, 'Flavia', 'Gutierrez',
        '40748341-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('805B0AED-9575-75F8-71F9-D9752DEA9BA8', '1446FC62-9D46-1F3F-AAAA-88FA0348D10E', 3, 'Raya', 'Knight',
        '12064616-8');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('4D454509-2548-F6DD-1B33-731A13282402', '80F7F7A8-DCCF-55A1-9AB1-5DC14A0CF114', 5, 'Quon', 'Richmond',
        '43390122-3');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('DCE12ECE-2277-2ED6-DF9C-3C6EFDE7D83A', '8017C170-3EA7-4261-9945-52D04FB0B70C', 4, 'Kelly', 'Mccarty',
        '31330240-7');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', '531144BA-BAA4-8949-0F52-8EBE68F4A801', 6, 'Rogan', 'Small',
        '36052100-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', '93FB9F17-2670-AB05-575B-5096F30AB71F', 6, 'Leah', 'Lambert',
        '42699897-1');
INSERT INTO fv_user.cliente (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
VALUES ('074C78B2-E23D-F253-5B8D-A756628D13B5', 'D8B1B280-4496-9553-1B39-F411126ECF29', 3, 'Phoebe', 'Flowers',
        '25413313-2');


prompt Insertando datos comerciales.;
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('F77A828D-7D04-2453-0CE8-870C714F7979', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 18,
        'Scelerisque Institute S.A.', 'Scelerisque Institute', 'Ventas de frutos y hortalizas',
        'mattis@Donecfringilla.org', '6592006-9', 'Ap #647-4514 Luctus Ave', '337162-2303');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('2F0411F7-04F9-86D2-1DC9-402B3D8F46D7', 'FB2F21E5-47F4-1788-C177-6C112B0E0677', 49,
        'Fermentum Risus At Consulting S.A.', 'Fermentum Risus At Consulting', 'Ventas de frutos y hortalizas',
        'quis.urna.Nunc@metusAliquam.ca', '31308688-7', '595 Luctus St.', '328984-3595');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('B44CF105-AFD8-FD69-EFB9-844942D3C944', '5E99EE33-E0F7-A74F-A1BA-D6670F57DEDB', 48,
        'Mattis Integer Eu Limited S.A.', 'Mattis Integer Eu Limited', 'Ventas de frutos y hortalizas',
        'non.dui.nec@nec.ca', '33797716-2', '794 Lorem, Rd.', '029112-0459');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('FC0EC869-A1F9-B93A-CDA1-2B10B8442EEA', '2EB967B8-8D60-BA31-99CC-C77C060180F2', 52,
        'Iaculis Quis Foundation S.A.', 'Iaculis Quis Foundation', 'Ventas de frutos y hortalizas',
        'varius.et@temporbibendumDonec.ca', '9898809-2', 'P.O. Box 916, 8308 Eu, St.', '232451-0938');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('7245A93F-A5FF-C407-0A52-E99B04D9669C', '03F6B49B-E999-55B1-8A14-7D8AB3AFF8FC', 31,
        'Semper Cursus Integer Limited S.A.', 'Semper Cursus Integer Limited', 'Ventas de frutos y hortalizas',
        'diam.dictum.sapien@parturient.org', '8102910-5', 'P.O. Box 752, 1108 Odio Avenue', '085256-0630');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('3B4E0B43-3517-2CE1-14A0-4CEA5E75DEA2', 'DC5F45E8-83F6-C054-3FFD-193D13F6779F', 19, 'Risus Duis A Inc. S.A.',
        'Risus Duis A Inc.', 'Ventas de frutos y hortalizas', 'eu@Maecenas.co.uk', '13607951-4', '6490 Diam. Rd.',
        '374842-0761');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('744EFC09-0E3B-0E95-880B-F4F0223A0EF9', 'CE234B46-DD54-0E88-53BC-0B6495C910B6', 53, 'Quisque Libero Corp. S.A.',
        'Quisque Libero Corp.', 'Ventas de frutos y hortalizas', 'orci.quis.lectus@felispurusac.co.uk', '36198816-7',
        '7510 Egestas Avenue', '018606-1099');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('58CD2437-778C-FEDF-4D16-48E2BA4902CB', 'E3AC99B6-9944-1171-41E9-31B10390255E', 4, 'Fringilla LLP S.A.',
        'Fringilla LLP', 'Ventas de frutos y hortalizas', 'sociis.natoque.penatibus@nuncsed.com', '15268726-5',
        '389-7667 Malesuada Avenue', '285672-7819');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('079F108B-7103-C897-FB0D-DE6D1A971FC4', 'DA90D3BD-551D-ED37-A2B2-189A0B15F204', 35,
        'Lacus Nulla Tincidunt Consulting S.A.', 'Lacus Nulla Tincidunt Consulting', 'Ventas de frutos y hortalizas',
        'ac.fermentum.vel@penatibusetmagnis.org', '26222503-8', '752-246 Erat. Avenue', '723705-0062');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('EE20B428-8B13-D1E6-FBA5-923DBF47A44D', 'A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 41,
        'Massa Non Ante Limited S.A.', 'Massa Non Ante Limited', 'Ventas de frutos y hortalizas',
        'ornare.facilisis.eget@Nulla.ca', '6387754-9', 'P.O. Box 991, 7612 Volutpat. Street', '707767-2520');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('A78C8DBB-9019-1065-EE8D-C8F605941CB2', 'FEF17043-B6B1-70F0-0D5B-A702E8083054', 25, 'Aliquet Magna Corp. S.A.',
        'Aliquet Magna Corp.', 'Ventas de frutos y hortalizas', 'magna@egetodio.org', '23195480-5',
        'P.O. Box 603, 5742 Egestas. Ave', '302495-9938');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('B9D12CE0-A426-0767-986F-A0B97C664D40', 'DE6467D5-CDF0-DE45-2854-1FD5BF32D199', 24, 'Luctus Consulting S.A.',
        'Luctus Consulting', 'Ventas de frutos y hortalizas', 'laoreet.ipsum@Sed.net', '29745888-4',
        '9342 Eleifend Road', '955998-3201');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('B53D7B59-6DB3-D88D-6069-E080B1FC6BBE', '1BD3B0BA-8887-A13C-2A9F-5B5D8C6F3B2C', 49, 'Nunc Corporation S.A.',
        'Nunc Corporation', 'Ventas de frutos y hortalizas', 'gravida@magnisdis.net', '21424975-8',
        'P.O. Box 286, 9537 Lectus Ave', '515872-9193');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('D86A4998-A5B4-8DF8-9627-E74E3DC05621', '3CFE902A-252D-7661-F09D-838D426F06B6', 50,
        'Ullamcorper Duis At Incorporated S.A.', 'Ullamcorper Duis At Incorporated', 'Ventas de frutos y hortalizas',
        'sociis.natoque.penatibus@eu.org', '5550539-K', '316-2768 Dui. Street', '645876-6042');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('ED49F641-ABD1-429F-6327-2356C2986DC3', 'B1D65B14-1BF0-B8A8-BE21-AEE4D6CEF118', 56, 'Nulla Limited S.A.',
        'Nulla Limited', 'Ventas de frutos y hortalizas', 'scelerisque@rutrum.com', '42145441-8', '7065 Dui Rd.',
        '866390-8112');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('C1302BA9-5105-4ED9-4B67-C991D9E523E4', 'ABF92493-B3A5-A69F-B855-638C8E97943E', 2,
        'Mi Lacinia Incorporated S.A.', 'Mi Lacinia Incorporated', 'Ventas de frutos y hortalizas',
        'iaculis.odio@eleifendvitae.ca', '20148368-9', 'Ap #871-657 Suspendisse Rd.', '394490-6134');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('3DB71840-45B1-E5C2-E6E7-7AA935C158A6', '4D03AF9E-039C-818D-7FDF-32E318573A78', 7,
        'Odio Sagittis Foundation S.A.', 'Odio Sagittis Foundation', 'Ventas de frutos y hortalizas',
        'faucibus.id.libero@netuset.edu', '31352495-7', '864-4163 Semper Ave', '537211-0089');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('4CBD4D34-578C-D862-EB91-0586B1FA6547', 'F1044EE8-F5D2-F671-6411-F0F128520DA9', 27,
        'Libero Mauris Aliquam LLP S.A.', 'Libero Mauris Aliquam LLP', 'Ventas de frutos y hortalizas',
        'pretium@Donecat.edu', '40659011-9', '2436 Id, Road', '042641-6723');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('E0457AE2-B40B-BE90-E0B9-09F50EA1C5DD', '8780BE17-7D4E-7871-D595-B623110B33CA', 47,
        'Dolor Vitae Associates S.A.', 'Dolor Vitae Associates', 'Ventas de frutos y hortalizas',
        'facilisis.Suspendisse.commodo@vehicula.org', '24599224-6', 'P.O. Box 913, 6618 Cursus Street', '183404-4156');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('F35FD2E4-AAD9-F300-ECDB-EDD90CA2A9D5', '7345A92A-1BAD-ECD2-79C0-21171D436FE4', 6, 'Sapien Aenean Ltd S.A.',
        'Sapien Aenean Ltd', 'Ventas de frutos y hortalizas', 'Quisque@volutpatornare.ca', '19866318-2',
        'Ap #992-3010 Bibendum Rd.', '379378-7478');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('CB60D06A-367E-0C86-C32B-0652DDFC9742', '7577F044-80C6-0AAC-11C5-201D82103AC1', 42,
        'Nibh Enim Gravida LLC S.A.', 'Nibh Enim Gravida LLC', 'Ventas de frutos y hortalizas',
        'mi.Aliquam.gravida@nullaInteger.ca', '15544090-2', '932-9650 Mi Street', '475137-5413');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('68D4F2C2-0303-CF54-DFB1-4F546B9F89DA', '0DC1D3BF-5DF7-B8BA-7D80-9524A9898EF9', 47, 'Nisi Incorporated S.A.',
        'Nisi Incorporated', 'Ventas de frutos y hortalizas', 'dictum.Phasellus.in@maurisut.org', '7674581-1',
        'P.O. Box 514, 375 Amet, Street', '245388-2280');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('E6823479-B121-9124-C3A9-A6072550492C', 'AA4BA0C1-2A06-DB9D-8821-72EF7E6C2BA0', 41,
        'Hymenaeos Mauris Consulting S.A.', 'Hymenaeos Mauris Consulting', 'Ventas de frutos y hortalizas',
        'dui.Fusce@turpis.net', '35566605-0', '3281 Non, Road', '399966-9645');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('E12B33C5-8D7C-FE97-1987-6E0D32704092', '6F334378-50EE-82BE-C6EE-1198834F4F5A', 44, 'Eu Industries S.A.',
        'Eu Industries', 'Ventas de frutos y hortalizas', 'mus@nunc.org', '23718164-6',
        'P.O. Box 723, 6846 Tincidunt Street', '464615-8040');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('0B04641A-AE23-082E-4B91-0AE0E88F83AA', '23503EED-AD11-8B76-5874-B73DBE0813B1', 19, 'Nec Limited S.A.',
        'Nec Limited', 'Ventas de frutos y hortalizas', 'quis.accumsan@massalobortisultrices.net', '12444844-1',
        'Ap #839-9991 Arcu Rd.', '748011-1819');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('ADDAD6C3-82A8-E0C1-FAE9-679777C575EC', '367ACDA1-E000-3AE5-F70C-9EED14F8F2FE', 22, 'Sit Amet Corporation S.A.',
        'Sit Amet Corporation', 'Ventas de frutos y hortalizas', 'mauris@ipsumportaelit.org', '10776692-8',
        'Ap #916-2074 Mattis Av.', '265597-7656');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('54D6C80B-7291-B40D-F7AD-C9D02F4FA8BD', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 56,
        'Tincidunt Pede Company S.A.', 'Tincidunt Pede Company', 'Ventas de frutos y hortalizas',
        'at.fringilla.purus@elitEtiamlaoreet.ca', '26198703-1', 'Ap #247-7236 Mauris St.', '192443-5801');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('68921928-B8C8-1DB1-8512-416D79273060', '1982FFAE-AE7D-F5A5-620B-472918916F1F', 34,
        'Arcu Curabitur Foundation S.A.', 'Arcu Curabitur Foundation', 'Ventas de frutos y hortalizas',
        'sollicitudin@Phasellus.edu', '31515108-2', '215-4957 Commodo St.', '146404-2256');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('842C9986-2D4E-F363-5DDD-9384BE437B3B', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 25, 'Eget Lacus Mauris PC S.A.',
        'Eget Lacus Mauris PC', 'Ventas de frutos y hortalizas', 'Maecenas.mi.felis@montesnascetur.edu', '9862432-5',
        'P.O. Box 358, 4692 Eu Avenue', '174734-9742');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('6315C808-E789-D4CF-0904-E3380E3B0A98', '4689BD45-68E1-75F0-8E63-49CD7BC67E1D', 6,
        'Nullam Suscipit Est Corporation S.A.', 'Nullam Suscipit Est Corporation', 'Ventas de frutos y hortalizas',
        'Lorem.ipsum.dolor@tinciduntDonec.ca', '10758061-1', 'P.O. Box 566, 2199 Rhoncus St.', '186719-6451');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('95DDB747-F4BD-D9B7-2967-04EE217EB2E8', 'C08AD0B2-078A-DB01-A5C5-BB1066D862CB', 35,
        'Aliquet Phasellus Fermentum Limited S.A.', 'Aliquet Phasellus Fermentum Limited',
        'Ventas de frutos y hortalizas', 'egestas.hendrerit@ac.co.uk', '35865563-7', '737-7514 Urna. Av.',
        '425604-5123');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('937EBFAC-F033-AB9F-2025-33EB8ACEDA40', '64C3D8D6-ABF2-483E-F49C-A51E21A542AC', 26,
        'Natoque Penatibus Et Industries S.A.', 'Natoque Penatibus Et Industries', 'Ventas de frutos y hortalizas',
        'nunc@velit.com', '32366284-3', '8193 Aenean Rd.', '074390-7727');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('F16A1BD2-0095-2970-FF98-2A80138F59E8', 'C992CD9C-F0E6-7FFE-3429-CE94B64B0644', 24, 'Amet Corp. S.A.',
        'Amet Corp.', 'Ventas de frutos y hortalizas', 'aliquet.sem.ut@magna.net', '12675144-3', '5660 In Av.',
        '808288-5065');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('8FBCEE38-E8C7-94B4-1A31-AEA4AE84D573', '12D60502-FBD5-3A47-440F-6E3EA0E5BF74', 9, 'Etiam Laoreet Corp. S.A.',
        'Etiam Laoreet Corp.', 'Ventas de frutos y hortalizas', 'Morbi.non@egestas.org', '39487322-5',
        '725-9206 Ipsum. Av.', '885464-1381');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('7A28A2A4-A419-9DF8-7EB4-D0DBF125C0F9', '2518FFFF-0137-CF55-4C17-A241F5ADCCCF', 19, 'Duis Ltd S.A.', 'Duis Ltd',
        'Ventas de frutos y hortalizas', 'Sed.eget.lacus@rutrum.com', '32472562-8', 'P.O. Box 143, 8235 Nec, Ave',
        '266789-9500');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('5E2BBEC0-9F7F-7840-4F43-40A6B73F69BD', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 36,
        'Aliquam Gravida Foundation S.A.', 'Aliquam Gravida Foundation', 'Ventas de frutos y hortalizas',
        'augue@Namacnulla.org', '32432918-8', 'Ap #129-3041 Duis St.', '865224-0758');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('348EA626-96F8-271E-D3EB-94301AB0246F', '59E9EDB7-872A-BAB4-64EF-CE795C522389', 27,
        'Facilisis Incorporated S.A.', 'Facilisis Incorporated', 'Ventas de frutos y hortalizas',
        'nunc@Suspendisse.co.uk', '12890921-4', '7293 Curabitur Av.', '417036-8197');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('C2A75114-6256-31C7-71B9-752DD7CD1C99', '7F3BF2FE-30CA-B6BA-AA35-A381C64A51BD', 47,
        'Ullamcorper Velit In Foundation S.A.', 'Ullamcorper Velit In Foundation', 'Ventas de frutos y hortalizas',
        'metus.In.lorem@lectusrutrum.org', '25301180-7', 'Ap #623-4801 Aliquam Rd.', '198405-1035');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('FD08F4A2-345A-CB2C-FE0E-9986540D72A6', 'E538C425-17A7-5E54-7005-6B0A3362F76A', 14, 'Pulvinar Inc. S.A.',
        'Pulvinar Inc.', 'Ventas de frutos y hortalizas', 'justo.sit@imperdiet.net', '45046085-0',
        'P.O. Box 868, 890 Dignissim. St.', '723468-4582');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('1E263136-49B8-3276-FB4F-457D6C64FB01', '93E57380-FE5C-2935-3791-261E8CE4E504', 41, 'Faucibus Orci Inc. S.A.',
        'Faucibus Orci Inc.', 'Ventas de frutos y hortalizas', 'ipsum@Proinvelarcu.edu', '14454990-2',
        'P.O. Box 863, 3342 Magna St.', '154315-4056');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('E59EF916-478C-ED78-6774-1DD9ACE24D88', 'F2203EBF-6610-0BFD-5EEA-330AFA1C5364', 8,
        'Ut Tincidunt Consulting S.A.', 'Ut Tincidunt Consulting', 'Ventas de frutos y hortalizas',
        'purus@accumsanlaoreetipsum.co.uk', '48699229-8', '9220 Consequat Avenue', '117536-1631');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('994248A5-1A59-E34A-97EC-8E50C8ACE5DB', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 24, 'Nec Eleifend Inc. S.A.',
        'Nec Eleifend Inc.', 'Ventas de frutos y hortalizas', 'Curabitur.vel@velit.edu', '43490169-3',
        'Ap #934-9482 At Av.', '352285-9754');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('91D7867B-E4FF-4495-0628-7DA4BF5D2993', 'A5C11DC3-667D-DAD1-B953-42C5AEC36D72', 29, 'Sed Nunc Est Company S.A.',
        'Sed Nunc Est Company', 'Ventas de frutos y hortalizas', 'a.sollicitudin@elitNullafacilisi.edu', '5255230-3',
        '4869 Vel Avenue', '173159-5300');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('ABC085E3-7E36-6B0B-E90B-ECCCC85F13ED', 'E78C0C53-359F-367B-18E4-70CE59C86790', 20,
        'Vel Sapien Imperdiet Limited S.A.', 'Vel Sapien Imperdiet Limited', 'Ventas de frutos y hortalizas',
        'Maecenas.mi.felis@lorem.org', '12606119-6', 'Ap #819-1833 Molestie Street', '714725-2295');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('52469273-707F-180F-7B96-EC8177ED9A65', '849D8880-4DE9-34D8-52D7-B276B12A5732', 27, 'Sit Amet Consulting S.A.',
        'Sit Amet Consulting', 'Ventas de frutos y hortalizas', 'ipsum@metus.net', '32552999-7', 'Ap #204-1292 Est St.',
        '719174-1227');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('0521EADD-2240-18C8-9B35-0C63873800D9', '213C6B17-44FE-C2CA-433D-58FE5B76C456', 39,
        'Scelerisque Dui Suspendisse Incorporated S.A.', 'Scelerisque Dui Suspendisse Incorporated',
        'Ventas de frutos y hortalizas', 'id@nonluctussit.com', '23408865-3', 'P.O. Box 790, 8336 Ornare. Ave',
        '174100-9995');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('C2C95BC3-40B8-4D54-2486-3847C4F6F0DE', '94474AB6-CEFC-6021-F63E-902A8237FC24', 4, 'Nisi Industries S.A.',
        'Nisi Industries', 'Ventas de frutos y hortalizas', 'pellentesque.eget.dictum@tinciduntorci.edu', '19514181-9',
        'P.O. Box 886, 6566 In Rd.', '926232-0352');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('1F4211F8-241A-EBBE-2600-261269454394', 'AF6F7981-034E-878E-8E7D-E1AA6B5C8875', 4,
        'Semper Egestas Foundation S.A.', 'Semper Egestas Foundation', 'Ventas de frutos y hortalizas',
        'augue@Donecfelisorci.org', '24134695-1', 'P.O. Box 189, 1642 Luctus Rd.', '989604-9823');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('CE061429-FFF3-8F7D-348C-3E1908FF2720', 'F48F8C29-7ACD-BA77-957B-963AD3D0E4B4', 33, 'Pharetra Nam Ac LLP S.A.',
        'Pharetra Nam Ac LLP', 'Ventas de frutos y hortalizas', 'velit.in.aliquet@vitae.net', '42836330-2',
        '655-1450 Bibendum. Ave', '179159-8939');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('F9E0B66E-F3A4-653C-D076-A94BADD94482', '5BF6A50A-7551-611A-2E72-E9DB4530E047', 25,
        'Eu Nulla Incorporated S.A.', 'Eu Nulla Incorporated', 'Ventas de frutos y hortalizas',
        'at.sem@enimEtiamgravida.org', '45404924-1', 'Ap #719-8314 Vestibulum Rd.', '649562-5847');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('D3EE7616-2A17-BCDD-3E16-D33FA9C07032', '87E3997E-A548-2E7B-F1A2-32EAE852C990', 45,
        'Adipiscing Ligula Associates S.A.', 'Adipiscing Ligula Associates', 'Ventas de frutos y hortalizas',
        'commodo.hendrerit.Donec@Naminterdum.co.uk', '16010479-1', '7787 Posuere St.', '586189-3583');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('2D1F2CD0-0998-8756-5A4B-01E968FA41CF', 'DA270437-F17F-D407-F96D-62F25184BB5A', 49,
        'Vulputate Dui Company S.A.', 'Vulputate Dui Company', 'Ventas de frutos y hortalizas',
        'pede.Cras@Phaselluselitpede.edu', '19352536-9', '192-9023 Amet Road', '173048-7822');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('BC18AF03-2564-8F44-8D9D-B3276FBFBAA0', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 39, 'Mauris Ltd S.A.',
        'Mauris Ltd', 'Ventas de frutos y hortalizas', 'commodo.hendrerit.Donec@a.com', '40006022-3',
        'Ap #315-753 Magna. Avenue', '243270-5677');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('35E88185-DF88-BD9C-7A9B-D698E833E93F', '01E0F1DA-57DE-6E55-96EC-5FEAE3404A0F', 7, 'Eu Corp. S.A.', 'Eu Corp.',
        'Ventas de frutos y hortalizas', 'turpis@nuncsed.net', '26748477-5', 'Ap #583-1496 Lectus, Road',
        '418637-1565');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('F69BDB10-1371-9987-2F07-24B2457ED03A', '968B493A-973A-DA71-D390-578A9E3DA972', 49, 'Pede Et Risus LLP S.A.',
        'Pede Et Risus LLP', 'Ventas de frutos y hortalizas', 'aliquam.enim@pede.co.uk', '30727118-4',
        'Ap #720-6474 Integer Rd.', '966578-3453');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('70D5FB7E-DD91-36E7-1A65-94E62AFDFB76', 'A7B3C85B-80D2-1887-1B90-0C415292AB9D', 6, 'Vitae Corporation S.A.',
        'Vitae Corporation', 'Ventas de frutos y hortalizas', 'vulputate.nisi.sem@leoin.net', '33322563-8',
        '2263 Pede. St.', '233966-4829');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('E1236C2C-DD46-CBCD-DF9F-8659DE8A12E7', '68532DB8-6249-3281-26F8-B1545141DC86', 34, 'Enim Industries S.A.',
        'Enim Industries', 'Ventas de frutos y hortalizas', 'tellus@tempus.net', '6437939-9', 'Ap #348-6901 Cras St.',
        '345000-7384');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('7E197B29-E75E-7357-C54E-B83F90C2977F', '29B03BCF-F643-3B3D-D51C-4288DB2D480C', 7,
        'Dictum Mi Ac Industries S.A.', 'Dictum Mi Ac Industries', 'Ventas de frutos y hortalizas',
        'euismod@dictumaugue.com', '8048325-2', '651-2874 Augue St.', '002353-8457');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('A2A1BD19-D23D-0E0D-77BB-F0604A2A759F', '56AE3E25-131F-FB67-ACA4-BFBE5C01B618', 19,
        'Curabitur Dictum Foundation S.A.', 'Curabitur Dictum Foundation', 'Ventas de frutos y hortalizas',
        'rutrum.magna@Donecegestas.co.uk', '10723509-4', 'P.O. Box 420, 4007 Vestibulum Rd.', '785788-3172');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('5B30C6CF-1D7C-0E8F-7D25-E1719541EA7B', '0BE7F31F-27BE-B0B1-F988-65EA5898D0EC', 12,
        'Sem Egestas Institute S.A.', 'Sem Egestas Institute', 'Ventas de frutos y hortalizas', 'pede@noncursus.net',
        '43894123-1', 'P.O. Box 124, 5088 Tortor Avenue', '025814-1043');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('452955DC-38DD-8A6B-86C6-0A69752792DD', '805C1C90-61AC-6401-1BEC-EC1AA19B2215', 47,
        'Neque Nullam Nisl Foundation S.A.', 'Neque Nullam Nisl Foundation', 'Ventas de frutos y hortalizas',
        'morbi.tristique.senectus@cursusa.edu', '25708889-8', '947-8815 Justo Ave', '564998-5172');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('36FB5F01-D9B7-D515-D8CB-10608DBD022E', 'A5E73437-2C89-8AEC-177F-AA991E062FD2', 10, 'Sed LLP S.A.', 'Sed LLP',
        'Ventas de frutos y hortalizas', 'dictum.ultricies.ligula@scelerisque.edu', '16945674-7',
        '748-2696 Suspendisse Ave', '892123-5688');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('35A319FC-4B16-F6FD-4D7D-6118EFB85A5D', 'AFCE0767-6C6D-2503-7CA4-1783456F9E86', 2, 'Amet Incorporated S.A.',
        'Amet Incorporated', 'Ventas de frutos y hortalizas', 'Donec.felis@nasceturridiculus.net', '38088133-0',
        '522-125 Massa St.', '639375-4707');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('A4AF061A-5347-3C4A-A0FA-7DB31FBD7AD2', 'E73ADDFD-E4FC-F39E-01B4-09A30FAC2A4A', 23,
        'Aliquam Arcu Aliquam Corporation S.A.', 'Aliquam Arcu Aliquam Corporation', 'Ventas de frutos y hortalizas',
        'et.ipsum.cursus@convallisligula.edu', '16585799-2', '1249 Amet Rd.', '589408-6890');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('4F3776D4-D406-450B-44B7-2A8911BCFEEB', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 15, 'Arcu Corp. S.A.',
        'Arcu Corp.', 'Ventas de frutos y hortalizas', 'risus.Nunc.ac@risus.com', '23723151-1', '7120 Ornare Rd.',
        '354348-3345');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('54ABC497-B915-538A-6504-F2780F0EAB85', '98B238C5-F716-9AC7-10B9-585EEA0A29A8', 19,
        'Posuere Cubilia Corporation S.A.', 'Posuere Cubilia Corporation', 'Ventas de frutos y hortalizas',
        'lectus.ante@sitamet.edu', '47390687-2', 'P.O. Box 668, 3818 Vehicula Rd.', '842505-0740');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('34908AB9-2F74-94B5-3EAB-5843FC1FE718', 'DAF41C60-E4EE-F5F8-0884-E5D42901C68E', 37, 'Urna Nec Limited S.A.',
        'Urna Nec Limited', 'Ventas de frutos y hortalizas', 'et@lobortistellus.ca', '31394591-K',
        '170-4317 Eros. Road', '025617-3097');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('CD159274-561E-6FE5-FA46-F8854E56C3CE', 'CFBD312C-959D-2D2A-BA88-2D5CD5AE90B9', 34, 'Cras PC S.A.', 'Cras PC',
        'Ventas de frutos y hortalizas', 'mollis@iaculisenim.net', '15323401-9', 'P.O. Box 563, 1256 Eu Ave',
        '066179-9056');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('8853FCF7-ABA3-CCB5-68D8-30ABF35DA9BF', '312408A4-EFDB-C7CA-6B93-0A666A136A13', 38,
        'A Ultricies Consulting S.A.', 'A Ultricies Consulting', 'Ventas de frutos y hortalizas',
        'erat.neque@ullamcorpereu.org', '21245061-8', '9961 Lorem Avenue', '012726-0248');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('90F30FB7-14E6-2B83-8B29-EAE2824616E8', 'C299319F-7A2D-AF6F-9FBD-E87096D6E592', 21,
        'Natoque Penatibus Et Foundation S.A.', 'Natoque Penatibus Et Foundation', 'Ventas de frutos y hortalizas',
        'dolor.egestas.rhoncus@et.org', '21050475-3', '3422 Egestas Ave', '919865-8685');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('780B697F-F397-7D94-7DC2-04DFC9D9FFE8', '871B88C8-5717-D40A-D63A-8AE0EA455EB0', 22, 'Pellentesque A PC S.A.',
        'Pellentesque A PC', 'Ventas de frutos y hortalizas', 'felis.adipiscing.fringilla@Inscelerisquescelerisque.org',
        '18290073-7', '5443 Id, Street', '522357-6017');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('8E20C526-3E40-ED10-4537-0CF6DDE12F7C', '4F337ABF-094D-2862-3F74-154FCAE0ABC8', 13, 'Vitae Company S.A.',
        'Vitae Company', 'Ventas de frutos y hortalizas', 'primis.in@purusinmolestie.com', '21442767-2',
        'Ap #679-5627 Ante. Street', '252406-9107');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('0E530712-87A5-1B84-8F40-8E6AF9D200D7', '7942D66B-48F3-7D46-C0A5-35438E884FCA', 23,
        'Aenean Eget Foundation S.A.', 'Aenean Eget Foundation', 'Ventas de frutos y hortalizas',
        'elementum@ornare.co.uk', '23406503-3', 'Ap #199-3379 Massa. St.', '332003-6696');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('1AFE3D42-7D30-50ED-13A4-010FDB0A2D41', '4AFBAF51-0F15-67A3-F8C4-3516ADDFFBCD', 6,
        'Eu Odio Phasellus Associates S.A.', 'Eu Odio Phasellus Associates', 'Ventas de frutos y hortalizas',
        'enim.Sed.nulla@velitCras.co.uk', '13525728-1', '832-375 Parturient Road', '863150-4373');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('49C4CDC6-2D02-2F7E-8795-BEC81BEC514A', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 28,
        'Pellentesque Ut Ipsum Associates S.A.', 'Pellentesque Ut Ipsum Associates', 'Ventas de frutos y hortalizas',
        'vitae.posuere@neque.co.uk', '41540322-4', 'Ap #108-3578 Nunc St.', '674729-6470');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('47FB3D81-26C3-4D5A-4B04-42EB00DB02EC', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 56,
        'Interdum Incorporated S.A.', 'Interdum Incorporated', 'Ventas de frutos y hortalizas',
        'dolor.dapibus@nequeseddictum.net', '47175787-K', 'P.O. Box 135, 4809 Interdum. Avenue', '164347-7274');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('2344D411-83B2-628A-5979-C65A7F79555C', '67F5F3B0-5F37-70F0-8F77-B73D55050685', 19, 'Gravida Corporation S.A.',
        'Gravida Corporation', 'Ventas de frutos y hortalizas', 'Quisque.imperdiet.erat@vestibulumMaurismagna.co.uk',
        '21941527-3', '417-5837 Aliquet. Rd.', '819993-1372');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('71D93BEB-06B5-1396-2966-9BE06E5F7EA0', '52FEB6E9-5A05-0F92-6660-68F735E1F420', 29, 'Pharetra PC S.A.',
        'Pharetra PC', 'Ventas de frutos y hortalizas', 'tincidunt@lorem.net', '45203660-6', '307-2551 Non, St.',
        '443091-2842');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('2BC24472-4D83-CFFD-8557-E8FC43AA7BEA', '6DE633EE-1DE7-9F2B-56EE-A425D4639160', 37, 'In Consulting S.A.',
        'In Consulting', 'Ventas de frutos y hortalizas', 'Duis@antedictumcursus.co.uk', '41608711-3', '7981 Sed Road',
        '814835-6861');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('DA8FCB1F-A2AC-4C6D-A86C-14F61873699B', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 43, 'Cras Consulting S.A.',
        'Cras Consulting', 'Ventas de frutos y hortalizas', 'orci.Ut.semper@ullamcorper.edu', '30044912-3',
        'P.O. Box 871, 8660 Viverra. St.', '244604-8361');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('47D14F65-A51A-21B9-B09C-BE45603EB53E', '57E4B237-0A80-F863-82B1-03F79448ECF9', 8,
        'Mauris Quis Turpis Corp. S.A.', 'Mauris Quis Turpis Corp.', 'Ventas de frutos y hortalizas',
        'Integer.in.magna@per.co.uk', '6662998-8', 'P.O. Box 116, 2290 Lobortis St.', '493757-3923');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('27605B76-BD3F-266E-5017-1EB3781B975C', '61412D09-4B46-0EC1-70D2-011A939E6D64', 42,
        'Mauris Integer Sem Corporation S.A.', 'Mauris Integer Sem Corporation', 'Ventas de frutos y hortalizas',
        'et@volutpatNullafacilisis.net', '19072696-7', 'P.O. Box 771, 4316 Egestas Street', '374204-9202');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('01DEFE3D-5DAA-B31A-8019-B14F3A7A06FB', '7483EE78-95A3-F3BF-24C2-A80FCFA20FBC', 20, 'Leo Limited S.A.',
        'Leo Limited', 'Ventas de frutos y hortalizas', 'odio@eget.com', '34747315-4', 'Ap #684-8508 Metus. St.',
        '955063-3144');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('ED142BFC-8F32-587E-BA49-4C6D5D5121E1', '276AB396-5F07-5021-C48D-132C3511491B', 37, 'Purus Foundation S.A.',
        'Purus Foundation', 'Ventas de frutos y hortalizas', 'vulputate.lacus.Cras@loremvitae.org', '6533263-9',
        '927-9939 Cras Road', '988485-8789');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('CE5C8BF0-BC89-CAF4-A5F9-A709E62AC075', 'E2C5C22D-C684-5B12-E5CC-D85AD03167CA', 35,
        'Faucibus Morbi Corporation S.A.', 'Faucibus Morbi Corporation', 'Ventas de frutos y hortalizas',
        'Aenean@nec.com', '19237820-6', '473-7691 Mollis Av.', '189155-8437');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('DB57FE05-7794-BFD0-E0EB-BE4856B0BF81', 'AE2A05FB-D2F9-AF86-FE2D-C6128EAAFE2F', 3,
        'Eu Odio Phasellus Corp. S.A.', 'Eu Odio Phasellus Corp.', 'Ventas de frutos y hortalizas',
        'molestie.in.tempus@auctorquistristique.org', '28910818-1', '7498 Vitae Rd.', '844199-6876');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('7E73EDDE-0C28-5568-D7C0-343FEA8ACB2B', '8B6DE622-56A7-B8F8-799D-F94FB9707A53', 58, 'Et Rutrum LLP S.A.',
        'Et Rutrum LLP', 'Ventas de frutos y hortalizas', 'laoreet@Duisrisusodio.net', '9753452-7',
        'Ap #481-1686 Eget, Rd.', '196818-8555');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('08C01F34-2C93-341E-CC98-DA3CAC75210B', 'FEE20ADE-F5B6-34FB-93D8-440524364C15', 19, 'At Industries S.A.',
        'At Industries', 'Ventas de frutos y hortalizas', 'ac.eleifend.vitae@vitae.edu', '14071039-3',
        '6553 Vivamus Av.', '902247-4119');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('55ED76E3-C1AB-EBAA-21E9-DE6505F56E61', '9524DD38-0255-24E8-0D0F-BD984D167543', 34, 'Sem Corporation S.A.',
        'Sem Corporation', 'Ventas de frutos y hortalizas', 'ullamcorper.eu@Vestibulumaccumsanneque.com', '25557797-2',
        'P.O. Box 585, 1853 Montes, Rd.', '643231-2111');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('4BEF55BC-5795-41BB-43AB-4564C6FD4226', 'D58E722D-E117-9188-D846-2709D6CB4A51', 51, 'Amet Orci Consulting S.A.',
        'Amet Orci Consulting', 'Ventas de frutos y hortalizas', 'Nunc.laoreet.lectus@urnaUttincidunt.com',
        '40742113-2', 'P.O. Box 887, 5176 Ultricies Road', '748045-4508');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('0ACBAD6F-252F-7EC5-4B9B-69FA45D73871', 'F5EBCFB9-A97F-ABC2-369C-752595093003', 40,
        'Etiam Ligula Tortor Associates S.A.', 'Etiam Ligula Tortor Associates', 'Ventas de frutos y hortalizas',
        'eu.placerat@Sedegetlacus.org', '20461211-0', '6007 Dictum Street', '922236-7261');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('BBC7E090-7A14-1313-0ED5-740F93441452', '94B68D21-A50A-A98A-5FF1-D5B2D9E74F1D', 51, 'Sed Dui Institute S.A.',
        'Sed Dui Institute', 'Ventas de frutos y hortalizas', 'vehicula@lectusNullam.net', '27791934-6',
        '5964 Dictum Rd.', '043361-7453');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('CA0F1FD4-7BBC-798A-D434-32D6D0C21370', '500746E6-20FD-1AD4-8268-425438D51A2E', 46,
        'Non Cursus Non Incorporated S.A.', 'Non Cursus Non Incorporated', 'Ventas de frutos y hortalizas',
        'et.rutrum@acsemut.edu', '14699411-3', '901-8179 Risus Rd.', '924089-0609');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('5B49A638-DF25-F70A-1ADF-C8284863167F', '3F338E43-49C5-0331-BF79-5B9494C974CA', 22,
        'Eu Lacus Quisque Corporation S.A.', 'Eu Lacus Quisque Corporation', 'Ventas de frutos y hortalizas',
        'Mauris@aliquetdiamSed.ca', '40748341-3', 'P.O. Box 491, 839 Nec Rd.', '327501-3393');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('0B496212-DD5C-9C4B-10C7-8A12CCD38025', '805B0AED-9575-75F8-71F9-D9752DEA9BA8', 41, 'Molestie PC S.A.',
        'Molestie PC', 'Ventas de frutos y hortalizas', 'scelerisque.sed@insodaleselit.ca', '12064616-8',
        '561-1015 Ad Road', '049817-1768');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('34F2D4D5-5EC9-EA93-EF90-35EEA613979F', '4D454509-2548-F6DD-1B33-731A13282402', 5, 'Sociosqu Foundation S.A.',
        'Sociosqu Foundation', 'Ventas de frutos y hortalizas', 'placerat@Quisque.com', '43390122-3',
        'P.O. Box 525, 9357 Proin St.', '724923-4886');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('B5425359-5805-043C-4426-1BB567F7CE03', 'DCE12ECE-2277-2ED6-DF9C-3C6EFDE7D83A', 28,
        'Sagittis Lobortis Mauris Foundation S.A.', 'Sagittis Lobortis Mauris Foundation',
        'Ventas de frutos y hortalizas', 'mauris@aliquamadipiscing.org', '31330240-7', '594-7102 Magna Road',
        '957152-6244');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('C75BD819-079B-D3B0-E735-D04AAF270107', '13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', 28,
        'Pede Suspendisse Dui Incorporated S.A.', 'Pede Suspendisse Dui Incorporated', 'Ventas de frutos y hortalizas',
        'ac@pellentesquetellus.net', '36052100-1', '1302 Aliquam Rd.', '676080-8870');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('06A1A89E-E335-A997-4DFE-78B2AF492173', '3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', 3, 'Donec LLC S.A.',
        'Donec LLC', 'Ventas de frutos y hortalizas', 'molestie@nec.co.uk', '42699897-1', 'Ap #492-7836 Dui Ave',
        '685161-3536');
INSERT INTO fv_user.dato_comercial (id_comercial, id_cliente, id_ciudad, rsocial_comercial, fantasia_comercial,
                                    giro_comercial, email_comercial, dni_comercial, dir_comercial, fono_comercial)
VALUES ('CA3372EE-B90C-42FC-F957-AB449738F141', '074C78B2-E23D-F253-5B8D-A756628D13B5', 5, 'At Iaculis Quis LLP S.A.',
        'At Iaculis Quis LLP', 'Ventas de frutos y hortalizas', 'augue.ut@auctorullamcorper.co.uk', '25413313-2',
        '5477 Dictum Road', '413180-8406');

prompt Insertando productos de ejemplo.;
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('02C35A6B-1AFB-2D1A-49E6-55DC47905991', '4D454509-2548-F6DD-1B33-731A13282402', 2, 'Duraznos conserveros',
        'faucibus leo, in lobortis tellus justo', 406, 1405);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('04D80EA3-1DC1-F81F-BDFA-9F46F80F8256', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Limones',
        'lorem fringilla ornare placerat, orci lacus vestibulum lorem,', 325, 708);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('0BAE4235-2E3A-970B-FCE7-038C3BDAC63D', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 1, 'Manzanas Rojas',
        'eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at,', 398, 519);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('1329BB8B-5034-C6AF-D747-11AFF19B3D2C', 'E78C0C53-359F-367B-18E4-70CE59C86790', 1, 'Almendras',
        'Nunc ut erat. Sed nunc est, mollis', 292, 1460);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('14D1B266-EF2B-17B6-5DBF-1D1FCFDAF803', 'E78C0C53-359F-367B-18E4-70CE59C86790', 1, 'Peras',
        'mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate,', 251, 749);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('151110BF-2037-9CFE-F79C-4579DDE2F098', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 1, 'Mandarinas',
        'vulputate ullamcorper magna. Sed eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec f', 238,
        1960);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('159DA73C-BECB-9954-F6CE-E147CF64E4D1', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Limones',
        'tellus, imperdiet non, vestibulum nec, euismod in, dolor. Fusce feugiat.', 172, 2825);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('171AAC70-2F40-8AEB-0D4D-A11929088926', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Manzanas Rojas',
        'vel quam dignissim pharetra. Nam ac nulla. In tincidunt congue', 385, 1682);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('17D2899E-5C1A-C2E6-91A8-6D34F6D8D656', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Duraznos',
        'molestie in, tempus eu, ligula. Aenean', 192, 1082);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('1C395555-BC0A-D4BC-CC5E-4D1C77B6AA2D', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 2, 'Naranjas',
        'ultrices posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede blandit congue. In scele', 272,
        2568);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('1DDCBB9C-8092-E9F6-5BE7-8B1A7A276DBB', '94474AB6-CEFC-6021-F63E-902A8237FC24', 2, 'Frutillas',
        'auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet', 518, 2160);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('1EA23B0E-DBFB-93AF-1CAB-3DDB4BDE1CFB', '94474AB6-CEFC-6021-F63E-902A8237FC24', 1, 'Almendras',
        'enim diam vel arcu. Curabitur ut odio vel est tempor bibendum. Donec felis orci, adipiscing non, lu', 285,
        2342);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('1F3949E0-1AAF-EEB0-8336-A15034AEC430', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Manzanas Verdes',
        'imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac facilisis', 93, 2324);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('22219FE8-C666-934F-98F0-4DE99E98F961', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 1, 'Naranjas',
        'dui. Suspendisse ac metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc', 497,
        2108);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('2259BE6B-5362-BDF7-7B8A-1BA211DBFBDF', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Ciruelas',
        'leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod in, dolor. Fusce feugiat. Lorem ips', 208,
        615);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('23A7478D-795E-17B1-382B-5798F4D73E4E', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 1, 'Manzanas Rojas',
        'eleifend vitae, erat. Vivamus nisi. Mauris nulla.', 103, 3064);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('26E6E453-F0DF-11B7-238E-03110BFC7E1A', '94474AB6-CEFC-6021-F63E-902A8237FC24', 2, 'Mandarinas',
        'rutrum eu, ultrices sit amet, risus. Donec nibh enim, gravida', 465, 3359);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('29089A41-1458-88F1-4054-D8509D54259C', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Ciruelas',
        'hendrerit consectetuer, cursus et, magna. Praesent interdum ligula eu enim. Etiam imperdiet dictum ', 432,
        381);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('2C683931-BF16-028B-819A-997CED5D86DF', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 2, 'Uva Negra',
        'odio vel est tempor bibendum. Donec felis orci, adipiscing non, luctus sit amet, faucibus ut, nulla', 520,
        3511);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('30D7C129-B011-E29F-CBB9-EF415248F461', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 1, 'Damascos',
        'auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer', 363, 681);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('325190E8-89F5-2D70-40AC-848E0447407E', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 2, 'Frutillas',
        'dis parturient montes, nascetur ridiculus mus. Donec dignissim', 303, 1570);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('32A4F745-6121-22DE-885C-7DA728E6159D', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Uva Blanca',
        'mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum', 444, 1011);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('35FCCE1A-950E-DA84-EFCB-83BEEAEEFAC9', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Guindas',
        'ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant', 233,
        3142);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('3770279F-D1EE-D1A9-69F4-861B4D68B65C', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Paltas',
        'aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida.', 357, 3140);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('39453707-6A0D-EDB5-A84E-31E97B0A2FF5', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Ciruelas',
        'dictum sapien. Aenean massa. Integer', 341, 1477);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('3DE36F1D-7C35-9661-4142-4F2E030C9D30', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 1, 'Manzanas Verdes',
        'ornare, lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi', 373, 1403);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('3DE9C8B1-B1ED-3564-98C9-AF66010B10F4', '4D454509-2548-F6DD-1B33-731A13282402', 2, 'Paltas',
        'velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla vulputate dui, nec tempus ', 94, 845);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('3E08EE9D-E5D9-3748-C2F4-12F826D28672', '94474AB6-CEFC-6021-F63E-902A8237FC24', 1, 'Cerezas',
        'in aliquet lobortis, nisi nibh lacinia', 356, 1820);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('3FE91E33-D74D-B4E3-21F8-71AC50876E0F', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 1, 'Paltas',
        'pulvinar arcu et pede. Nunc sed orci lobortis augue scelerisque', 238, 2925);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('40076B7D-4069-B151-2A53-6FEA3CE3DBF8', 'E78C0C53-359F-367B-18E4-70CE59C86790', 1, 'Manzanas Rojas',
        'hendrerit neque. In ornare sagittis felis. Donec tempor, est ac mattis semper,', 413, 1530);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('42AB987E-5FC1-A8CA-67B8-F413951A289B', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Kiwis',
        'Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue ut lacus. Nulla', 127, 1056);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('457FCF5A-A430-70BC-1105-02D4A4055B0A', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Mandarinas',
        'fringilla. Donec feugiat metus sit amet ante. Vivamus non lorem vitae', 271, 1728);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('4914EB74-547D-E623-F136-540CE6C9EA87', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 2, 'Almendras',
        'tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morbi non sapien molestie orci', 453, 2484);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('4A835BF5-F81C-CEA9-F012-828D68CF59F4', 'ABF92493-B3A5-A69F-B855-638C8E97943E', 2, 'Cerezas',
        'felis ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis, tristique ac', 455,
        1166);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('4FECEB92-61EC-BF60-2546-EE37A11B2AAD', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Uva Negra',
        'consectetuer euismod est arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis arcu vel', 214,
        427);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('5171DDA9-C6DC-4E20-7591-661688FE4B80', 'DC5F45E8-83F6-C054-3FFD-193D13F6779F', 1, 'Damascos',
        'urna et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin ', 404,
        3454);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('5569CAB5-E6FF-DDF4-789F-35815EF3D49B', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 2, 'Naranjas',
        'egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla', 322, 1771);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('5657509F-A28B-FC03-11C8-21B32D3569BD', '94474AB6-CEFC-6021-F63E-902A8237FC24', 1, 'Guindas',
        'nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. C', 521,
        1696);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('58805828-7AFC-FD1E-7E09-04B872414A97', '94474AB6-CEFC-6021-F63E-902A8237FC24', 1, 'Kiwis',
        'Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae', 455, 3504);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('59D083C1-1F73-7473-312F-06B0DDF37719', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Guindas',
        'nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis d', 387,
        3215);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('5C4D1706-C352-6892-E0CB-E865477BD4AC', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 2, 'Guindas',
        'Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies', 459, 3398);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('5D293D16-98B7-C8D9-375F-F7EA1E5B484D', '871B88C8-5717-D40A-D63A-8AE0EA455EB0', 2, 'Ciruelas',
        'mauris erat eget ipsum. Suspendisse sagittis. Nullam vitae diam.', 176, 1160);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('61C38E36-1611-71A8-6099-D2BFEE6A2B5A', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 1, 'Almendras',
        'Donec egestas. Duis ac arcu. Nunc', 524, 2306);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('622851AC-2068-83F4-0B4B-CC08FFCE5C24', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Frutillas',
        'Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod', 121,
        3368);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('63E7AE50-A888-0AE5-DCBA-D06EF20034C6', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Uva Blanca',
        'quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.', 499,
        3281);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('6953D8B3-A691-4C18-437F-E18CAB587FCE', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Uva Blanca',
        'eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetu', 391,
        1029);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('6CA37E37-1D0A-B1DA-DE88-2CC99432B4F7', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 1, 'Naranjas',
        'Aliquam auctor, velit eget laoreet posuere, enim nisl elementum purus, accumsan', 317, 1583);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('6E03983B-26A8-22F9-29DA-5DBEFABF2244', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Peras',
        'vitae diam. Proin dolor. Nulla semper tellus id nunc interdum feugiat.', 414, 1897);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('6F665A60-B347-2B1E-C2E7-CB13E85ED0FA', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Frutillas',
        'Cras pellentesque. Sed dictum. Proin', 451, 2740);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('733D8D79-C4B5-0628-9D49-50FCF33FCA66', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 1, 'Almendras',
        'neque sed dictum eleifend, nunc risus varius orci, in consequat enim diam vel arcu. Curabitur ut od', 430,
        1140);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('73DE53A3-3ADE-B2F3-810F-9FB786254FB4', '805C1C90-61AC-6401-1BEC-EC1AA19B2215', 2, 'Limones',
        'justo sit amet nulla. Donec non justo.', 506, 1685);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('745D8774-665F-47D1-E8A6-F12A8831BA82', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 1, 'Uva Blanca',
        'non justo. Proin non massa non ante bibendum ullamcorper. Duis', 363, 2134);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('75172AFD-C350-C5EB-E9C7-71D7E8B46239', '871B88C8-5717-D40A-D63A-8AE0EA455EB0', 1, 'Frutillas',
        'interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convall', 413,
        1122);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('76221531-8938-E3A2-6F40-20B85D31BBBD', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 2, 'Kiwis',
        'vitae mauris sit amet lorem semper auctor. Mauris vel turpis. Aliquam adipiscing', 405, 3071);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('779901C0-8483-4891-AEF8-A73E5CC4323C', '871B88C8-5717-D40A-D63A-8AE0EA455EB0', 1, 'Almendras',
        'justo. Proin non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet,', 413, 3409);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8254A6F5-6CD6-CA5E-DD39-BCAFEC00A5DA', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 1, 'Frutillas',
        'malesuada fringilla est. Mauris eu turpis. Nulla aliquet.', 434, 303);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('847D694E-E746-1232-DFD9-7AE1113681B0', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Cerezas',
        'mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum enim', 329, 3036);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('89995AEF-95A7-CB52-A0CA-BFAFA866F976', 'E78C0C53-359F-367B-18E4-70CE59C86790', 1, 'Duraznos',
        'vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras', 434, 3095);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('89B8C80D-2813-4BA3-E5EA-80664A6F583F', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 1, 'Manzanas Rojas',
        'ipsum dolor sit amet, consectetuer adipiscing elit. Etiam laoreet, libero et tristique pellentesque', 491,
        3394);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8A1BE843-2713-7266-2482-B6857B9246F9', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Cerezas',
        'magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc', 245, 2817);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8A919305-10EE-44FF-A3C7-F18BD1DF84FD', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 1, 'Ciruelas',
        'Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam nisl. Maecen', 152,
        2156);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8AB51F30-F701-840C-3805-929C15B76110', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 2, 'Frutillas',
        'Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed, est. Nunc', 453, 3694);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8B086708-0C1E-31E5-D569-F2EB00E7D228', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 1, 'Peras',
        'at auctor ullamcorper, nisl arcu iaculis enim, sit amet', 84, 1246);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8DEDD079-DFC6-87CC-3E55-9C53B7CF3120', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 1, 'Limones',
        'purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis', 526,
        2862);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('8EB2405B-9192-5B16-E880-79E7526CFB2A', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 1, 'Ciruelas',
        'convallis convallis dolor. Quisque tincidunt pede ac urna. Ut tincidunt vehicula risus. Nulla', 100, 3615);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('9013BFD9-E904-E27C-641B-CCB4CD669725', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Guindas',
        'posuere at, velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum placerat, augue. Sed mole', 264,
        1947);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('91977501-39E8-75D4-C81B-CE68C39E2F38', '805C1C90-61AC-6401-1BEC-EC1AA19B2215', 2, 'Paltas',
        'metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh.', 427, 969);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('94DBC293-3008-EECC-F5A2-7E42AE2B65DE', '4D454509-2548-F6DD-1B33-731A13282402', 1, 'Manzanas Verdes',
        'neque sed sem egestas blandit. Nam nulla magna, malesuada', 267, 3114);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('99165AD8-632C-4062-8BBB-E51F8C28D96F', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Palta Hass',
        'at lacus. Quisque purus sapien, gravida non, sollicitudin', 140, 2729);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('9D988EBE-36CB-E360-EE73-3EA323513B66', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 1, 'Kiwis',
        'congue. In scelerisque scelerisque dui. Suspendisse ac metus vitae velit', 371, 3585);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('9E58C54E-A1D0-C412-3288-B0463E8CA226', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 2, 'Almendras',
        'et magnis dis parturient montes, nascetur ridiculus', 291, 2811);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('9F3173AC-ABB9-7412-2FA8-70B5667711F2', '871B88C8-5717-D40A-D63A-8AE0EA455EB0', 1, 'Guindas',
        'fringilla cursus purus. Nullam scelerisque', 441, 2631);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('9F8A78CA-8FB8-92AA-F95C-85AC5907A075', '94474AB6-CEFC-6021-F63E-902A8237FC24', 1, 'Frutillas',
        'in aliquet lobortis, nisi nibh lacinia orci,', 518, 1612);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('A0F588C4-03FC-5C02-C5AE-3C77AD48B7AA', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Palta Hass',
        'mauris erat eget ipsum. Suspendisse', 253, 1497);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('A133F286-E98B-9032-CE93-2D5EB009FF90', '94474AB6-CEFC-6021-F63E-902A8237FC24', 2, 'Ciruelas',
        'arcu. Sed eu nibh vulputate', 505, 402);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('A4805CF4-A0DB-BD52-240C-2B5D0F67F5AE', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 2, 'Uva Blanca',
        'lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac r', 426,
        1465);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('A52D9C22-EBB1-01C6-7811-920333BFCCEE', '94474AB6-CEFC-6021-F63E-902A8237FC24', 2, 'Kiwis',
        'sit amet massa. Quisque porttitor eros nec tellus. Nunc lectus pede, ultrices a, auctor non, feugia', 142,
        1705);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('A69E2FDF-A680-8BF2-873E-94B309E2D0EE', '4D454509-2548-F6DD-1B33-731A13282402', 2, 'Frutillas',
        'Suspendisse sed dolor. Fusce mi lorem, vehicula et, rutrum eu, ultrices sit amet, risus. Donec nibh', 398,
        830);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('A9A7369D-1918-8903-480B-3C4653C0CEA5', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 2, 'Manzanas Verdes',
        'natoque penatibus et magnis dis', 312, 2020);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('AA73A3B9-2350-7F70-B252-3E57962F02B7', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 1, 'Peras',
        'in consequat enim diam vel arcu. Curabitur ut odio', 277, 384);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('AAF173FB-3587-0E1F-002B-4906EECAA1CB', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 2, 'Guindas',
        'est arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis', 381, 2148);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('ABEF22F7-6C33-8595-5F44-E0F8A0DA2ECE', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 2, 'Ciruelas',
        'vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod ', 382,
        3147);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('B42330D9-488F-5137-19D4-F8DB4F6560A2', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 2, 'Peras',
        'varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In', 531, 666);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('B606F927-B611-B5CB-9783-0721C34F2571', 'ABF92493-B3A5-A69F-B855-638C8E97943E', 1, 'Cerezas',
        'eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna.', 497, 2820);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('B7BF59A2-BCCC-4E00-D072-0B10CDB3AF73', 'AFCE0767-6C6D-2503-7CA4-1783456F9E86', 1, 'Peras',
        'neque vitae semper egestas, urna justo', 360, 3272);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('B9B95B51-25C9-CFC0-7066-F9B34BAB6299', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Naranjas',
        'dui. Cras pellentesque. Sed dictum.', 357, 1725);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('BA6F08A1-EF43-047D-7C41-C4CFF13B6B3D', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 1, 'Naranjas',
        'lectus. Nullam suscipit, est ac facilisis facilisis, magna tellus', 519, 2268);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('BE004C11-C659-1092-6DF7-DB7D160775A3', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 1, 'Ciruelas',
        'et, rutrum non, hendrerit id, ante. Nunc mauris sapien, cursus in,', 443, 2259);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('BE3801B9-9ED0-4C73-1681-D803E474EE7B', '18617AC0-E801-3E0B-C12E-61D01FE4339E', 1, 'Duraznos conserveros',
        'Phasellus vitae mauris sit amet lorem semper auctor. Mauris vel turpis. Aliquam adipiscing lobortis', 249,
        1250);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('BEB4ACDE-931F-002C-259F-6B5E8D71C8EE', '4D454509-2548-F6DD-1B33-731A13282402', 2, 'Uva Blanca',
        'hymenaeos. Mauris ut quam vel sapien', 244, 3014);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('BF9604D5-B5F8-2412-776A-FCE29BBDDFD6', '871B88C8-5717-D40A-D63A-8AE0EA455EB0', 1, 'Ciruelas',
        'nisl. Nulla eu neque pellentesque massa', 312, 2918);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('BFE4C1D8-2C9B-1710-1102-BC7C817AF9D0', '805C1C90-61AC-6401-1BEC-EC1AA19B2215', 2, 'Kiwis',
        'adipiscing elit. Etiam laoreet, libero et tristique', 479, 978);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('C3027746-7DC0-0D25-0499-C7ACAFD7EBA8', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 2, 'Peras',
        'ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui', 190, 3462);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('C3BFDB52-4F43-D4E1-D477-D41E4DFA298E', 'AFCE0767-6C6D-2503-7CA4-1783456F9E86', 1, 'Damascos',
        'id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus', 112, 3363);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('C45BAD45-AC27-7B2E-78A5-EA55508A779A', 'AFCE0767-6C6D-2503-7CA4-1783456F9E86', 1, 'Manzanas Verdes',
        'nascetur ridiculus mus. Proin vel arcu eu odio tristique', 196, 613);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('C55EF7A4-4160-9DAA-66F7-6B4F374881A6', 'E78C0C53-359F-367B-18E4-70CE59C86790', 1, 'Kiwis',
        'primis in faucibus orci luctus et ultrices', 244, 2192);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('C8760FF4-47D2-84E1-9ABD-6CF9F20E7725', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 1, 'Uva Negra',
        'bibendum sed, est. Nunc laoreet lectus quis massa. Mauris vestibulum,', 89, 1276);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('C9229F8F-801A-2B26-42D1-F5BFBA6D31B3', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 1, 'Paltas',
        'vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh', 112,
        2846);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('CBD73072-491F-1A79-05D1-71AE1FB893C0', '022DA8FA-7D31-A8CF-86D4-634AA7DF584E', 1, 'Uva Negra',
        'Nulla tincidunt, neque vitae semper egestas, urna justo faucibus', 262, 1846);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('CD9088FD-3C5B-A3A1-B40F-A58CE7E5C640', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 2, 'Limones',
        'mi. Aliquam gravida mauris ut mi. Duis', 154, 2771);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('D0E90EDF-F2A4-C8E8-E748-F12244FAC28F', 'ABF92493-B3A5-A69F-B855-638C8E97943E', 1, 'Frutillas',
        'dui augue eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec ', 325,
        2896);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('D211F793-887C-9DBA-580C-D0AEC79E3224', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 2, 'Limones',
        'ut, pellentesque eget, dictum placerat, augue. Sed molestie. Sed id', 331, 2050);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('D482A9A6-27C7-973A-F6D5-4A64D08E34D7', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Almendras',
        'sem ut dolor dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac m', 345,
        3567);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('D4EF5CE1-4669-D240-4A16-C04C5BB88901', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Almendras',
        'nulla. In tincidunt congue turpis. In condimentum. Donec at arcu. Vestibulum ante', 220, 2863);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('D4F3E3F8-B016-20A0-84C6-DA920A1422A3', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Duraznos conserveros',
        'Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis', 179, 1227);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('D979ED6A-1A35-F0D4-B673-BB2AA59CF53A', 'ABF92493-B3A5-A69F-B855-638C8E97943E', 1, 'Guindas',
        'Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morb', 91,
        3675);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('DD60FDAB-CEF8-185E-34AE-8DB0368593E0', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 2, 'Mandarinas',
        'Etiam ligula tortor, dictum eu, placerat eget,', 249, 714);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('DD6710AF-0FA9-2CDB-ED77-0548580550D7', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 1, 'Duraznos',
        'gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas', 500, 3578);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('DFE2D881-61E5-ADD6-F78A-4CA8DF08934F', '94474AB6-CEFC-6021-F63E-902A8237FC24', 2, 'Almendras',
        'libero mauris, aliquam eu, accumsan sed, facilisis vitae, orci. Phasellus dapibus', 167, 1559);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('E2D98869-5B65-DEB4-B016-276A5D2689E0', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 1, 'Manzanas Verdes',
        'molestie arcu. Sed eu nibh vulputate mauris sagittis', 186, 1875);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('E2FEFD62-C609-8BB3-AB89-F6F199D2CC74', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 1, 'Manzanas Verdes',
        'in, dolor. Fusce feugiat. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aliquam auctor,', 151,
        3089);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('E59513E2-57AA-2185-82ED-310780A31F09', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 1, 'Duraznos',
        'volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt', 477,
        3116);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('EB8F0300-2E84-D73E-40A2-AB248626D450', 'E3AC99B6-9944-1171-41E9-31B10390255E', 2, 'Kiwis',
        'lorem, luctus ut, pellentesque eget, dictum placerat, augue. Sed molestie. Sed id risus quis diam l', 411,
        413);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('EBE309BA-20B8-A11B-267D-33BD865598C3', '61024E5C-4972-5DBF-B994-7BB46838C9BF', 1, 'Limones',
        'aliquet. Phasellus fermentum convallis ligula. Donec luctus aliquet odio. Etiam ligula tortor, dict', 397,
        1302);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('EE285487-798F-6DE2-C874-C24CAAA2089A', 'E2F01091-1E05-84A3-6151-DF9C6D57F3D5', 2, 'Naranjas',
        'non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis quis, pede. Suspendisse dui. Fusce d', 416,
        2733);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('EF0D49FB-86D5-858E-18CC-8FDD0AEE3AA1', 'AFCE0767-6C6D-2503-7CA4-1783456F9E86', 1, 'Duraznos',
        'aliquet, metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede,', 135, 3430);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F0368139-6EB4-1C0C-2022-601917BA40C8', '4D454509-2548-F6DD-1B33-731A13282402', 2, 'Almendras',
        'venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus n', 291,
        2604);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F204920A-3D88-FFA6-E845-2D4F2D41D8B2', 'EA32BD09-1E4B-1664-740B-05A6AAC6B6D1', 1, 'Kiwis',
        'ligula consectetuer rhoncus. Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellent', 145,
        3215);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F5194AB5-88B0-6AF4-BD0C-9862EC99A053', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 2, 'Manzanas Rojas',
        'Duis ac arcu. Nunc mauris. Morbi non', 309, 2591);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F59F6755-3F6F-8AAE-5BFA-E0DD5A448B99', '805C1C90-61AC-6401-1BEC-EC1AA19B2215', 2, 'Manzanas Rojas',
        'felis. Donec tempor, est ac mattis semper, dui lectus', 288, 1471);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F658EE0A-FD62-9196-B08E-39AB13343885', '4B168A97-ABF4-F4C6-4654-6E4DAF0FC1E7', 1, 'Duraznos',
        'eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis,', 377, 2370);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F66F102D-721B-B8C7-DDC0-71ED311BCFD6', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 1, 'Mandarinas',
        'sem eget massa. Suspendisse eleifend. Cras', 393, 691);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F8556A23-1010-6BE7-2F7F-3A785C0FA445', 'CF76A0C9-59FC-666E-B24D-B3FA519FFAF2', 2, 'Mandarinas',
        'aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant mo', 201,
        1875);
INSERT INTO fv_user.producto (id_producto, id_cliente, id_categoria, nombre_producto, obs_producto, valor_producto,
                              cantidad_producto)
VALUES ('F8E7572A-8C1C-9856-FF79-2EBEDDFF0F2D', '4D454509-2548-F6DD-1B33-731A13282402', 2, 'Damascos',
        'sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec eg', 216,
        1872);


prompt Insertando transportes de ejemplo.;
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('87D9C349-4426-3C4F-D75A-F346DBB8B18A', 'CE234B46-DD54-0E88-53BC-0B6495C910B6', 1, 'A3-C0O6', 'Avioneta cargo',
        39345, 1, 'quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu nulla at');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('030B758F-0E53-DDD7-D0EC-C81EB112C77D', '3F338E43-49C5-0331-BF79-5B9494C974CA', 2, 'S4-H5E4',
        'Camión acoplado refrigerado', 4753, 1, 'sem mollis dui, in sodales elit erat');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('038B4085-F9DE-5395-B5B0-D08E088C23D3', '3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', 2, 'W8-C0N4', 'Camión acoplado',
        295, 1, 'mauris. Integer sem elit, pharetra ut, pharetra sed, hendrerit a,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C7BC59A0-2FCE-6BF2-49F2-F3AE06B7BEF1', '23503EED-AD11-8B76-5874-B73DBE0813B1', 1, 'A8-Q5P2', 'Avioneta cargo',
        23336, 1, 'dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('45A530D2-C739-DC0F-530C-FFBCD518DE15', 'C08AD0B2-078A-DB01-A5C5-BB1066D862CB', 1, 'B1-Z4I8', 'Avión cargo',
        16509, 1, 'mauris a nunc. In at pede. Cras vulputate velit eu sem. Pellentesque ut');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('0670BD29-F9A2-5CCE-D25B-4E1E2A4565C7', '29B03BCF-F643-3B3D-D51C-4288DB2D480C', 2, 'R5-D4H7',
        'Furgon refrigerado', 282, 1, 'fringilla mi lacinia mattis. Integer eu lacus. Quisque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('070A9128-306B-8607-C409-8AB5644F4B19', '64C3D8D6-ABF2-483E-F49C-A51E21A542AC', 2, 'E7-L3O8',
        'Furgon refrigerado', 316, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('08328164-D628-0588-E9D8-35B264CC9E44', '0BE7F31F-27BE-B0B1-F988-65EA5898D0EC', 2, 'Z2-M0F7', 'Motocicleta', 25,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('7CD04F33-C044-7A62-B8D4-32F66EB6CB41', '849D8880-4DE9-34D8-52D7-B276B12A5732', 1, 'C0-G3O4', 'Avión cargo',
        12700, 1, 'natoque penatibus et magnis dis parturient montes, nascetur');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('0DEBD18B-B5F8-9DB6-EE55-1B58F8EBE165', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 2, 'M9-J5K8',
        'Camión acoplado refrigerado', 972, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('0E774EE9-904C-1008-6BD6-43606A3C08AA', '87E3997E-A548-2E7B-F1A2-32EAE852C990', 2, 'U6-I1G5', 'Camión', 1310, 1,
        'sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc est,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('0F9F146F-9E71-1C0E-48E4-2517144B465D', 'CE234B46-DD54-0E88-53BC-0B6495C910B6', 2, 'M1-Q5D9', 'Camión acoplado',
        831, 1, 'natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('108787DE-1DA5-921A-D108-315DC632BA5E', 'CFBD312C-959D-2D2A-BA88-2D5CD5AE90B9', 2, 'Z3-T9K9',
        'Camión acoplado refrigerado', 2118, 1,
        'Donec est mauris, rhoncus id, mollis nec, cursus a, enim. Suspendisse aliquet, sem ut');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('140825DC-3313-E375-ADDA-29BC850753B4', 'C299319F-7A2D-AF6F-9FBD-E87096D6E592', 2, 'R8-X7Q3',
        'Camión acoplado refrigerado', 458, 1,
        'Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque vitae semper');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('172ED48B-B148-AC95-EDDB-B79DB4B28034', '29B03BCF-F643-3B3D-D51C-4288DB2D480C', 2, 'N8-N3D6',
        'Camión refrigerado', 2961, 1, 'magna sed dui. Fusce aliquam, enim nec');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('19565766-E514-7A28-1FD2-159C7D9F6201', '52FEB6E9-5A05-0F92-6660-68F735E1F420', 2, 'G4-C8E0', 'Motocicleta',
        118, 1, 'mi eleifend egestas. Sed pharetra, felis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('1C4E371A-6CA3-67AF-4583-E9E7410D27EF', '276AB396-5F07-5021-C48D-132C3511491B', 2, 'K6-D9P9', 'Camioneta', 99,
        1, 'lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('2352E7AF-E911-CAEA-4B54-D09F9E1D0BD8', '67F5F3B0-5F37-70F0-8F77-B73D55050685', 2, 'O6-Y0U5',
        'Camión acoplado refrigerado', 3125, 1, 'ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('235313B2-F1F5-A409-97F5-F749AAAC5F8C', 'A5E73437-2C89-8AEC-177F-AA991E062FD2', 2, 'G0-P1B8', 'Camioneta', 420,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('90FB5F2C-5A58-E0E2-5317-B1E3FFB0E01B', '9524DD38-0255-24E8-0D0F-BD984D167543', 1, 'D4-X2S6', 'Avión cargo',
        45020, 1, 'ligula tortor, dictum eu, placerat eget, venenatis a, magna.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('267879B9-14B7-BF42-2811-98B812CD71E9', '67F5F3B0-5F37-70F0-8F77-B73D55050685', 2, 'R9-Z0U8', 'Camión acoplado',
        862, 1, 'In nec orci. Donec nibh. Quisque nonummy ipsum non arcu. Vivamus');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('6DC91025-187F-D0D3-B509-31F0747F1FF0', '13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', 3, 'D7-T6P5', 'Barcaza', 37778,
        1, 'tempus, lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet ultricies sem magna');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('379D51C9-31A7-32B1-B829-806F02E3EE4C', 'CE234B46-DD54-0E88-53BC-0B6495C910B6', 3, 'E2-J8L0', 'Barcaza', 17818,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('2A64F2D7-1646-98A1-69D7-A5A0FB1AE42B', '64C3D8D6-ABF2-483E-F49C-A51E21A542AC', 2, 'H8-R7G4', 'Camión acoplado',
        4916, 1, 'Aenean massa. Integer vitae nibh.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('7A28D549-90C1-DD89-712D-524D98BAF203', '8780BE17-7D4E-7871-D595-B623110B33CA', 1, 'E3-J8O6', 'Avioneta cargo',
        29509, 1, 'fringilla mi lacinia mattis. Integer eu lacus. Quisque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('32F88163-BA79-E12A-8D19-855C3572579A', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 2, 'H5-I6A4',
        'Furgon refrigerado', 573, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('87331D3A-4390-2A1E-BD44-205AD7FA0656', 'C08AD0B2-078A-DB01-A5C5-BB1066D862CB', 1, 'E6-M6Y4', 'Avioneta cargo',
        34412, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('045A8199-2383-DFED-E059-A0314839F19C', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 3, 'F3-S6S5', 'Barcaza', 19953,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('36E8E4E9-F965-2E23-8BB9-E5807BFE22CF', '8780BE17-7D4E-7871-D595-B623110B33CA', 2, 'H2-B4E6', 'Motocicleta',
        117, 1, 'eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('37A4D068-AE0E-C0B6-DDD3-BA6C35B09B0A', '276AB396-5F07-5021-C48D-132C3511491B', 2, 'V7-Y4L2',
        'Furgon refrigerado', 267, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('37AFAC11-9807-071B-29A3-9A6F28031A86', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 2, 'B2-L0P1', 'Camioneta', 900,
        1, 'cursus luctus, ipsum leo elementum sem, vitae aliquam eros turpis non enim. Mauris');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('3A258EF0-E3DB-DD9A-7651-50842C0CC550', 'A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 2, 'Q0-G0O2',
        'Camión refrigerado', 1063, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('BF879DAE-9C42-0C1E-C5D0-110FFAD19391', '0BE7F31F-27BE-B0B1-F988-65EA5898D0EC', 1, 'F9-O1C7', 'Avión cargo',
        21982, 1, 'scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FB15110D-0055-EF31-85B9-838B01356861', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 1, 'G3-I0R1', 'Avioneta cargo',
        15462, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('3CE64CD5-5BA8-4526-89A8-C4CA5F79CE28', 'A5E73437-2C89-8AEC-177F-AA991E062FD2', 2, 'Z2-T3F0', 'Camión acoplado',
        23, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('4464F8B8-71FE-78FE-1B86-C3985A27D1D1', '87E3997E-A548-2E7B-F1A2-32EAE852C990', 2, 'F8-M9B8',
        'Camión refrigerado', 1676, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('4A4163AE-93C2-ADCC-36B8-1D387011BD18', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 2, 'Q2-U3D9', 'Automóvil', 413,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('16168CA3-27C4-27D7-0AFC-EF04F94D0D50', '9524DD38-0255-24E8-0D0F-BD984D167543', 1, 'G5-O6O4', 'Avión cargo',
        24743, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('608703D6-0CF4-2479-E907-5F07FCA3687B', 'F5EBCFB9-A97F-ABC2-369C-752595093003', 3, 'G6-N3I0', 'Barcaza', 30133,
        1, 'Vivamus sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('4E729098-ED37-10F1-126C-3968895D37C3', '276AB396-5F07-5021-C48D-132C3511491B', 2, 'D3-G6T4', 'Motocicleta', 90,
        1, 'ut mi. Duis risus odio, auctor vitae, aliquet');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('4FEA5B1F-3871-4025-09A8-319DAA7E543B', 'A5C11DC3-667D-DAD1-B953-42C5AEC36D72', 2, 'B6-M6L9', 'Automóvil', 100,
        1, 'dis parturient montes, nascetur ridiculus mus. Donec');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('4FEBCA9C-602B-41FA-6EBF-569C1B1B0C5E', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 2, 'N2-U2O1', 'Camión', 436, 1,
        'consectetuer adipiscing elit. Aliquam auctor, velit eget laoreet posuere, enim nisl');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('50496134-F66A-B7B7-3430-CEB6409A1F03', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 2, 'Z9-H1U7', 'Camión acoplado',
        220, 1, 'scelerisque sed, sapien. Nunc pulvinar arcu et pede. Nunc sed orci lobortis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('1C02BA2A-0CC0-C854-62E9-7CFFE51E14C0', 'A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 3, 'H1-Y5Z5', 'Barco', 20153, 1,
        'blandit enim consequat purus. Maecenas libero');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('51ADEB87-9717-F9C1-8DE8-2FBC604FA878', '0BE7F31F-27BE-B0B1-F988-65EA5898D0EC', 2, 'U8-R3V7', 'Camión', 1672, 1,
        'Sed malesuada augue ut lacus.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('550004B5-B99B-B79C-7AF1-BBF39C6D5552', 'C299319F-7A2D-AF6F-9FBD-E87096D6E592', 2, 'C4-K3T4',
        'Camión acoplado refrigerado', 18291, 1,
        'quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('EB38B41F-7EEF-DFA7-9F8A-44695A554965', 'C08AD0B2-078A-DB01-A5C5-BB1066D862CB', 1, 'H5-U9E2', 'Avioneta cargo',
        43107, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('62802775-293E-867A-C16E-F716248D3C9E', '9524DD38-0255-24E8-0D0F-BD984D167543', 2, 'S2-L4S9',
        'Furgon refrigerado', 772, 1, 'pede blandit congue. In scelerisque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('65F84D59-EE08-2F87-9687-72603B6B8D4E', '3F338E43-49C5-0331-BF79-5B9494C974CA', 2, 'G6-S3Q3', 'Camión acoplado',
        3588, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('663B8075-88DD-F400-1637-FCF588E9D30A', '276AB396-5F07-5021-C48D-132C3511491B', 2, 'G5-B1Z2', 'Camión acoplado',
        3111, 1, 'Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum enim non');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('78D52BC3-6AA9-ACB7-78CA-64D758D4989F', '29B03BCF-F643-3B3D-D51C-4288DB2D480C', 1, 'J2-Y7D7', 'Avioneta cargo',
        11325, 1, 'interdum. Curabitur dictum. Phasellus in felis.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C3E32299-FBEB-6326-FF57-79A953B162CF', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 3, 'K2-E2Z9', 'Barcaza', 34022,
        1, 'vel quam dignissim pharetra. Nam ac nulla. In tincidunt');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('86E339E0-F020-5BD2-689E-3F0AF3C07A78', '52FEB6E9-5A05-0F92-6660-68F735E1F420', 1, 'K4-S8Y6', 'Avioneta cargo',
        20030, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('780D069B-CE3A-ABF9-2001-D88BFABB8DF8', '9524DD38-0255-24E8-0D0F-BD984D167543', 1, 'L0-G5G6', 'Avioneta cargo',
        25782, 1, 'Donec tempus, lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet ultricies');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('6EC798B1-557D-570C-040D-30552E46B37D', '3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', 2, 'E0-E7A9', 'Motocicleta',
        100, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('710B2CF1-00F0-EDE4-ED76-556B3E75B857', '23503EED-AD11-8B76-5874-B73DBE0813B1', 2, 'E5-A1X8', 'Automóvil', 205,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('7144243C-D860-EDE1-1365-B3039A2BB86C', '7942D66B-48F3-7D46-C0A5-35438E884FCA', 2, 'R9-V9H4',
        'Camión refrigerado', 424, 1,
        'tempor augue ac ipsum. Phasellus vitae mauris sit amet lorem semper auctor. Mauris');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('71EAA441-7C89-87E4-FAEE-4E125855FE28', '9524DD38-0255-24E8-0D0F-BD984D167543', 2, 'W1-C1H4', 'Automóvil', 126,
        1, 'erat neque non quam. Pellentesque habitant morbi tristique senectus');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('72EE0BF2-3262-31E1-94F4-19A0B0B52EC7', 'A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 2, 'S5-Q6I0',
        'Camión acoplado refrigerado', 3630, 1, 'luctus et ultrices posuere cubilia Curae; Phasellus ornare. Fusce');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('74011ACF-C6EB-9419-78D5-59EC4A25CC33', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 2, 'O6-R3A4',
        'Furgon refrigerado', 264, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FB19F2A1-142E-1320-7CCA-E5A8361C3DD6', 'A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 3, 'M5-J4B3', 'Barco', 78824, 1,
        'sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('752D3F5E-B43F-4EA2-5F92-21E6EF439712', 'C299319F-7A2D-AF6F-9FBD-E87096D6E592', 2, 'V2-C0K5', 'Camioneta', 441,
        1, 'dolor vitae dolor. Donec fringilla.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('767DC7FC-C80D-37D8-A6BE-75CA809D8416', '13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', 2, 'W7-N2F8', 'Motocicleta',
        299, 1, 'Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed, est. Nunc');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('321321B5-6FB9-EA6B-40C8-007ADC00FE0C', 'C08AD0B2-078A-DB01-A5C5-BB1066D862CB', 1, 'N1-O1B2', 'Avión cargo',
        28822, 1, 'ut quam vel sapien imperdiet ornare. In faucibus. Morbi vehicula.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('78F00854-41CB-9E78-D803-40DCA039894F', '7942D66B-48F3-7D46-C0A5-35438E884FCA', 2, 'Z5-K4X4', 'Motocicleta', 42,
        1, 'egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae, posuere at, velit. Cras lorem lorem,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('79F37388-1915-EF8E-3355-0145C8C93E5D', '23503EED-AD11-8B76-5874-B73DBE0813B1', 2, 'M9-I5O0', 'Camión acoplado',
        1484, 1, 'pede, nonummy ut, molestie in,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('2DC2A7B9-7675-A2A9-F0C0-5035E5EF4C68', '87E3997E-A548-2E7B-F1A2-32EAE852C990', 3, 'N8-L0N0', 'Barco', 11549, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('33560406-16ED-264A-CBE1-51EE512BC85F', 'CFBD312C-959D-2D2A-BA88-2D5CD5AE90B9', 1, 'O3-V9V1', 'Avión cargo',
        30695, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('8256EBF2-81CD-30C3-CC2D-BE8242332DD8', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 2, 'C7-C6I8',
        'Camión acoplado refrigerado', 4870, 1,
        'Fusce dolor quam, elementum at, egestas a, scelerisque sed, sapien. Nunc pulvinar arcu et');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('841A32A0-5B81-D0FC-2ED6-6CCE45F19FB6', '849D8880-4DE9-34D8-52D7-B276B12A5732', 2, 'F7-X7K9', 'Camión acoplado',
        2145, 1, 'nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('84ECBECB-292A-3476-23F9-16D4B41CFB07', '3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', 2, 'P9-M6V5',
        'Camión acoplado refrigerado', 2058, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('138FC94E-63AC-34D4-BFEC-C0809B15EC31', '276AB396-5F07-5021-C48D-132C3511491B', 1, 'O9-X6S9', 'Avión cargo',
        46006, 1, 'dapibus quam quis diam. Pellentesque habitant morbi');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('68CFCFDD-EB95-68E1-003A-D5E65DAA5B4E', '9524DD38-0255-24E8-0D0F-BD984D167543', 1, 'P3-V8F3', 'Avioneta cargo',
        31026, 1, 'tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac mattis velit justo');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('8B45FAFC-F1CE-8F8C-8357-4D6E533EDB07', 'AE2A05FB-D2F9-AF86-FE2D-C6128EAAFE2F', 2, 'P0-B7H8', 'Camión acoplado',
        4688, 1, 'a, malesuada id, erat. Etiam vestibulum massa rutrum magna. Cras convallis convallis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('3E945A31-7879-B4DE-FA8A-A9CB147A6D28', '3F338E43-49C5-0331-BF79-5B9494C974CA', 1, 'P7-Z3Q8', 'Avioneta cargo',
        19086, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('8BEA1C14-393C-CD06-3070-3B6078E82396', '67F5F3B0-5F37-70F0-8F77-B73D55050685', 2, 'D0-J0A3',
        'Furgon refrigerado', 3323, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FD72B11A-1379-7BBD-328D-9820CCC47B57', 'CE234B46-DD54-0E88-53BC-0B6495C910B6', 3, 'P9-N9T7', 'Barcaza', 21029,
        1, 'Etiam laoreet, libero et tristique pellentesque, tellus sem mollis dui, in sodales');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('91A17A60-D753-AAD8-6A8A-1A8EAB1AD3F7', 'AE2A05FB-D2F9-AF86-FE2D-C6128EAAFE2F', 2, 'G5-E8L0',
        'Camión acoplado refrigerado', 2749, 1, 'Phasellus ornare. Fusce mollis. Duis sit amet');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('E1252E69-0B46-FD52-5B2E-21BC8F14608F', '23503EED-AD11-8B76-5874-B73DBE0813B1', 1, 'Q2-D9L6', 'Avión cargo',
        36473, 1, 'Praesent luctus. Curabitur egestas nunc sed libero. Proin sed turpis nec mauris');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('946F6853-1930-49D3-5FA1-3209A942EA7D', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 2, 'X5-R8X2', 'Camión acoplado',
        205, 1, 'Mauris non dui nec urna suscipit nonummy. Fusce fermentum');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('A7E83A79-E2F4-82CA-FF1D-9A03848884A7', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 1, 'Q7-C2I7', 'Avioneta cargo',
        47903, 1, 'eget lacus. Mauris non dui');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('98571803-C8B6-6ECB-E435-BC3250D21DE8', 'DA90D3BD-551D-ED37-A2B2-189A0B15F204', 2, 'P9-Y4J0',
        'Camión acoplado refrigerado', 4084, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('0E5C8ED0-1030-C95E-8E43-BD18FEE9A0A2', '849D8880-4DE9-34D8-52D7-B276B12A5732', 3, 'R2-B0N1', 'Barcaza', 18904,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('9D347A27-B5A3-6365-A0BE-70614B3AD3C9', '7942D66B-48F3-7D46-C0A5-35438E884FCA', 2, 'C5-U9J6', 'Camión', 7673, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('ABFD1304-32F0-DFBC-67F9-9AC7DEE1B16A', '0BE7F31F-27BE-B0B1-F988-65EA5898D0EC', 1, 'R5-I6E3', 'Avioneta cargo',
        17063, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('A1352D69-576D-A7DB-A8FC-57F4625E0B51', '3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', 2, 'G7-D4J1', 'Camión acoplado',
        1462, 1, 'ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('A4CAB28B-F709-2F67-D71C-3A4DE19EFEAD', 'DA90D3BD-551D-ED37-A2B2-189A0B15F204', 2, 'G9-O6W0', 'Automóvil', 269,
        1, 'vehicula risus. Nulla eget metus eu erat');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('AD0432A4-8EFA-AECB-8CB5-2536748B8ADF', 'D58E722D-E117-9188-D846-2709D6CB4A51', 2, 'P4-Q1T6',
        'Camión acoplado refrigerado', 1178, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('EF4966CC-A3E9-4FD6-CCAD-4932B71D5CBC', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 1, 'R9-Y8X5', 'Avión cargo',
        43103, 1, 'dolor. Donec fringilla. Donec feugiat metus sit amet ante. Vivamus non lorem vitae odio');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FEFF4ED9-B947-EFC4-7D55-BC6580CDAB91', 'AE2A05FB-D2F9-AF86-FE2D-C6128EAAFE2F', 3, 'S1-Y3E2', 'Barco', 42040, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('548FBD46-F3AA-A877-3487-82A207A141F3', 'D58E722D-E117-9188-D846-2709D6CB4A51', 3, 'S3-O1D9', 'Barco', 26364, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('B3CF1299-2986-50B8-77B6-0B392DF9B46D', '64C3D8D6-ABF2-483E-F49C-A51E21A542AC', 2, 'N2-H7F5',
        'Camión acoplado refrigerado', 465, 1,
        'risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('B65B4016-E435-F3E3-5D57-39AA7922F480', '3F338E43-49C5-0331-BF79-5B9494C974CA', 2, 'W7-J6P6',
        'Camión acoplado refrigerado', 138, 1, 'tempor arcu. Vestibulum ut eros non enim commodo');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('B0968DF4-12D6-0313-7A2E-E48427ACB7D3', '3BD61D0E-5CFF-5A2A-5181-295E1E3ABF80', 1, 'S4-M9D1', 'Avioneta cargo',
        47873, 1, 'et malesuada fames ac turpis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('EBB159F5-5EE1-DD1B-3AF6-1C67826431E6', 'DA90D3BD-551D-ED37-A2B2-189A0B15F204', 1, 'S5-C1A9', 'Avión cargo',
        41143, 1, 'urna justo faucibus lectus, a sollicitudin orci sem eget');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C0F64F65-D91F-CA80-DFA4-3099333402BB', '93E57380-FE5C-2935-3791-261E8CE4E504', 2, 'N2-Y4L0', 'Camión acoplado',
        498, 1, 'leo. Vivamus nibh dolor, nonummy ac, feugiat non,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C132EA16-B12E-3D27-F8AE-F7F3E9AB975F', '13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', 2, 'L6-W9C3',
        'Furgon refrigerado', 1092, 1, 'magna, malesuada vel, convallis in,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C325968A-70A2-D9F5-5644-6EC4E0077DAC', '3F338E43-49C5-0331-BF79-5B9494C974CA', 2, 'L6-N4Q0', 'Camión', 337, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C39895F3-462F-F013-568C-8A5310598023', 'F5EBCFB9-A97F-ABC2-369C-752595093003', 2, 'S3-U1S2', 'Camión acoplado',
        3887, 1, 'auctor. Mauris vel turpis. Aliquam adipiscing lobortis risus.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('BE4B3071-1505-5C25-1AE5-F7723A1F8366', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 1, 'T7-S3J7', 'Avioneta cargo',
        16824, 1, 'ligula eu enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('D730EBEB-A612-3AFF-E73C-7CEA3C40FB33', 'A5C11DC3-667D-DAD1-B953-42C5AEC36D72', 2, 'U3-L7V9', 'Camioneta', 1625,
        1, 'vulputate, nisi sem semper erat,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('832D061D-C27A-1968-9FF3-EC3CA7B22802', '849D8880-4DE9-34D8-52D7-B276B12A5732', 1, 'U5-M6B4', 'Avioneta cargo',
        10234, 1, 'Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('C6977C67-CB47-EB19-4939-D3468385CA8A', '29B03BCF-F643-3B3D-D51C-4288DB2D480C', 1, 'U8-F9K4', 'Avión cargo',
        47352, 1, 'ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('DB246B99-0D11-8978-79D6-2CA15E385A92', '93E57380-FE5C-2935-3791-261E8CE4E504', 2, 'I6-G8Z2', 'Camión', 1886, 1,
        'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('BE19383C-A527-7495-5639-9EE915F2AC70', 'CFBD312C-959D-2D2A-BA88-2D5CD5AE90B9', 3, 'V1-X2J4', 'Barcaza', 51879,
        1, 'aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac orci. Ut semper');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('06007CE8-5F06-2386-18FF-06704E3ED41D', '1FB0F1D7-1FFC-17C5-1B92-46A377724A63', 3, 'V4-Z5P9', 'Barcaza', 21487,
        1, 'nulla. Donec non justo. Proin non massa non');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('DE36885C-5385-5963-C892-DFD9400BF413', '93E57380-FE5C-2935-3791-261E8CE4E504', 2, 'F4-U6U4', 'Camión acoplado',
        3218, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('DF1E8ED5-9099-437F-D088-C4A20B50E455', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 2, 'S8-X2H1', 'Camioneta', 3322,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('E0D6A174-2BB5-FF12-EC0B-0DBDDD8292E2', '52FEB6E9-5A05-0F92-6660-68F735E1F420', 2, 'D1-N0G2',
        'Camión acoplado refrigerado', 24155, 1, 'tellus. Aenean egestas hendrerit neque. In ornare sagittis felis.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('E1E99AFB-DD6D-F2A3-B04B-E6095AFBC076', '23503EED-AD11-8B76-5874-B73DBE0813B1', 2, 'X5-K0H1', 'Automóvil', 208,
        1, 'Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('AEB3621C-8F69-F570-E1A6-5B6C63A46CED', 'F5EBCFB9-A97F-ABC2-369C-752595093003', 1, 'W4-G7E8', 'Avión cargo',
        35928, 1, 'libero mauris, aliquam eu, accumsan sed, facilisis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('E99C4504-6264-F7E9-863F-D566520ADFE7', 'A65387AE-136B-1012-7E0D-F5F1A3C34EAF', 2, 'X1-P7N1', 'Automóvil', 320,
        1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('EAAD86C8-D831-9859-AA8F-4014496DDB8C', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 2, 'I4-T2R6', 'Motocicleta',
        174, 1, 'ut lacus. Nulla tincidunt, neque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('39F09AC7-A24B-95D5-0FB9-C42A11AB93C0', 'DA90D3BD-551D-ED37-A2B2-189A0B15F204', 3, 'X0-Z3P0', 'Barco', 46643, 1,
        'accumsan convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('32E2C56F-A9DF-239D-3EEC-3195B3E14196', '8780BE17-7D4E-7871-D595-B623110B33CA', 1, 'X4-X7Q6', 'Avión cargo',
        14295, 1, 'dolor, tempus non, lacinia at, iaculis quis, pede. Praesent eu dui. Cum sociis natoque');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('F2C9A843-F2C6-6148-2AE3-3916C800409C', '13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', 2, 'P8-L8U5', 'Camioneta', 484,
        1, 'Sed nunc est, mollis non, cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('62694D86-D14F-362D-5F38-E1B0FD7D6027', 'AF0132BD-FC3B-4863-6CC3-6F7D39061403', 1, 'X8-Z7Y0', 'Avión cargo',
        31584, 1, 'Mauris blandit enim consequat purus. Maecenas libero');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('F6618CC2-077C-BEB9-100F-42A8D96DAD2A', '52FEB6E9-5A05-0F92-6660-68F735E1F420', 2, 'V6-W1B5', 'Camión acoplado',
        4207, 1, 'Proin vel arcu eu odio tristique pharetra. Quisque ac libero nec ligula consectetuer rhoncus.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('75F8CA54-1DED-6D3B-66B4-E3B7BE828EC2', '849D8880-4DE9-34D8-52D7-B276B12A5732', 1, 'Y7-Y5B8', 'Avioneta cargo',
        26926, 1, 'tellus, imperdiet non, vestibulum nec, euismod in,');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('F8E026E2-0C0D-CBE3-2458-A9003C41D0A2', '29B03BCF-F643-3B3D-D51C-4288DB2D480C', 2, 'Z1-K9O3', 'Camión acoplado',
        558, 1, 'quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('F9364FC3-EADB-1C2D-F6ED-C8056160B1D9', 'F5EBCFB9-A97F-ABC2-369C-752595093003', 2, 'D5-P9Z5', 'Motocicleta',
        111, 1, 'sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat. Sed nunc est, mollis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FA9AE342-8E63-62AA-C5F7-4D14D1FD3DAF', '8A9FE185-00A9-E2CD-E34B-C28221AEDFB1', 2, 'E5-R8M5', 'Automóvil', 364,
        1, 'id nunc interdum feugiat. Sed nec metus facilisis lorem tristique');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FAC92730-8C90-75C8-B1F9-30F8328C8F38', '67F5F3B0-5F37-70F0-8F77-B73D55050685', 2, 'G3-J8S8', 'Camioneta', 375,
        1, 'Aliquam ornare, libero at auctor ullamcorper, nisl arcu iaculis');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FB478B81-06D1-D5D3-65CB-0CBFBC29F9AD', 'C08AD0B2-078A-DB01-A5C5-BB1066D862CB', 2, 'Q3-Z5U4', 'Automóvil', 39,
        1, 'ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi.');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FB6EB1FB-6087-A034-B0ED-33CAF9392558', '13BFCE5C-5137-CB6A-EF09-BC8B76ACD717', 2, 'G6-T7Y1',
        'Camión acoplado refrigerado', 1901, 1, 'lectus convallis est, vitae sodales nisi magna');
INSERT INTO fv_user.vehiculo (id_vehiculo, id_cliente, id_tipo_transporte, patente_vehiculo, modelo_vehiculo,
                              capacidad_vehiculo, disponibilidad_vehiculo, observacion_vehiculo)
VALUES ('FBF8C876-91D9-993F-64BD-76BC51C47528', 'F5EBCFB9-A97F-ABC2-369C-752595093003', 2, 'P7-I3T9', 'Camión', 313, 1,
        'Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque vitae semper egestas, urna');


prompt Creando usuarios de ejemplo.
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro) VALUES ('1', 'd.garcial', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'd.garcial@alumnos.duoc.cl', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('2', 'c.arenas', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'c.arenas@alumnos.duoc.cl', 1,
        TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro)
VALUES ('3', 'l.repetto', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'l.repetto@alumnos.duoc.cl', 0,
        TO_DATE('2020/09/07', 'yyyy/mm/dd'));
Insert into fv_user.usuario (ID_USUARIO, USERNAME, PASSWORD, EMAIL, IS_ACTIVE, REGISTRO)
values ('d124fdef-6956-460f-9873-1953fe29f81b', 'l.garciar', '552668dcde69cd6c10aebb8e5ee4e61dfb54050a',
        'stngarcia8@gmail.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
Insert into fv_user.usuario (ID_USUARIO, USERNAME, PASSWORD, EMAIL, IS_ACTIVE, REGISTRO)
values ('a3220c48-ddb2-4fe8-8e80-8bc832fb80d5', 'f.garciar', '92d52f9c820e4e291318819f2ab5514dd8a389ea',
        'stngarcia8@gmail.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
Insert into fv_user.usuario (ID_USUARIO, USERNAME, PASSWORD, EMAIL, IS_ACTIVE, REGISTRO)
values ('d78ee803-2e99-4c87-a684-d600e6540564', 'd.garciar', '6f57196fd9309e992379d3c90fec691531219eea',
        'stngarcia8@gmail.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
Insert into fv_user.usuario (ID_USUARIO, USERNAME, PASSWORD, EMAIL, IS_ACTIVE, REGISTRO)
values ('e7d1d546-84ad-4420-bb05-169aebc376a5', 'l.romanq', '7a4013826e6cbb73d29cbea95ce32abcba60aa6e',
        'stngarcia8@gmail.com', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));


prompt Insertando clientes conocidos de prueba.;
Insert into fv_user.cliente (ID_CLIENTE, ID_USUARIO, ID_ROL, NOMBRE_CLIENTE, APELLIDO_CLIENTE, DNI_CLIENTE)
values ('5f950227-a59a-48ec-a358-a403ede00bca', 'd124fdef-6956-460f-9873-1953fe29f81b', '6', 'lolita', 'Garcia Roman',
        '12345678-9');
Insert into fv_user.cliente (ID_CLIENTE, ID_USUARIO, ID_ROL, NOMBRE_CLIENTE, APELLIDO_CLIENTE, DNI_CLIENTE)
values ('aa3ed254-ff6d-4c3c-97b6-048efdedaf69', 'd78ee803-2e99-4c87-a684-d600e6540564', '3', 'Daniela', 'Garcia Roman',
        '12345678-9');
Insert into fv_user.cliente (ID_CLIENTE, ID_USUARIO, ID_ROL, NOMBRE_CLIENTE, APELLIDO_CLIENTE, DNI_CLIENTE)
values ('729d6773-a60c-4dd5-9e39-9629e44c98b2', 'e7d1d546-84ad-4420-bb05-169aebc376a5', '4', 'Loreto', 'Roman Quiroz',
        '12345678-9');
Insert into fv_user.cliente (ID_CLIENTE, ID_USUARIO, ID_ROL, NOMBRE_CLIENTE, APELLIDO_CLIENTE, DNI_CLIENTE)
values ('08daae9c-d977-4234-a054-0b83918ed3e7', 'a3220c48-ddb2-4fe8-8e80-8bc832fb80d5', '5', 'Flo', 'Garcia Roman',
        '12345678-9');


prompt Insertando empleados de prueba.;
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
VALUES ('1', '1', 1, 'Daniel', 'Garcia Asathor');
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
VALUES ('2', '2', 2, 'Claudio', 'Arenas Carril');
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
VALUES ('3', '3', 2, 'Lucas', 'Repetto Asencio');


prompt Aceptando cambios.;
commit;

