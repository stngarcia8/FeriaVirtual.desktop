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


prompt Insertando tipos de cierre de pedido.;
INSERT INTO fv_user.tipo_cierre (id_tipo_cierre, desc_tipo_cierre)
VALUES (7, 'ACEPTADO');
INSERT INTO fv_user.tipo_cierre (id_tipo_cierre, desc_tipo_cierre)
VALUES (8, 'RECHAZADO');
INSERT INTO fv_user.tipo_cierre (id_tipo_cierre, desc_tipo_cierre)
VALUES (9, 'CANCELADO');


prompt  Insertando metodos de pago.;
INSERT INTO fv_user.metodo_pago (id_metpago, desc_metpago)
VALUES (1, 'VISA');
INSERT INTO fv_user.metodo_pago (id_metpago, desc_metpago)
VALUES (2, 'MASTERCARD');
INSERT INTO fv_user.metodo_pago (id_metpago, desc_metpago)
VALUES (3, 'TRANSFERENCIA BANCARIA');
INSERT INTO fv_user.metodo_pago (id_metpago, desc_metpago)
VALUES (4, 'WEBPAY');
INSERT INTO fv_user.metodo_pago (id_metpago, desc_metpago)
VALUES (5, 'PAYPAL');


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


prompt Insertando datos comerciales de clientes conocidos.;
INSERT INTO FV_USER.DATO_COMERCIAL (ID_COMERCIAL, ID_CLIENTE, ID_CIUDAD, RSOCIAL_COMERCIAL, FANTASIA_COMERCIAL, GIRO_COMERCIAL, EMAIL_COMERCIAL,
                                    DNI_COMERCIAL, DIR_COMERCIAL, FONO_COMERCIAL)
VALUES ('f3a97648-7fe8-40a7-afce-007aed69dcb8', 'aa3ed254-ff6d-4c3c-97b6-048efdedaf69', 29, 'Frutos de Exportación Ltda.', 'Frutas El Torero',
        'Venta de Frutas', 'cl.arenasc@alumnos.duoc.cl', '9477546-4', 'Calle Betis 8900', '720761221');
INSERT INTO FV_USER.DATO_COMERCIAL (ID_COMERCIAL, ID_CLIENTE, ID_CIUDAD, RSOCIAL_COMERCIAL, FANTASIA_COMERCIAL, GIRO_COMERCIAL, EMAIL_COMERCIAL,
                                    DNI_COMERCIAL, DIR_COMERCIAL, FONO_COMERCIAL)
VALUES ('39b073b1-0022-42ed-84df-9996056a22f3', '08daae9c-d977-4234-a054-0b83918ed3e7', 18, 'VerdeSur S.A', 'FRUTAS VERDESUR', 'VENTA DE FRUTAS',
        'cl.arenasc@alumnos.duoc.cl', '18634788-5', 'AV LAS PALMAS 2342', '8873664');
INSERT INTO FV_USER.DATO_COMERCIAL (ID_COMERCIAL, ID_CLIENTE, ID_CIUDAD, RSOCIAL_COMERCIAL, FANTASIA_COMERCIAL, GIRO_COMERCIAL, EMAIL_COMERCIAL,
                                    DNI_COMERCIAL, DIR_COMERCIAL, FONO_COMERCIAL)
VALUES ('ea5713da-7421-467c-b5b4-b39cf219a844', '5f950227-a59a-48ec-a358-a403ede00bca', 19, 'Ferrisur S.A', 'TRANSPORTES FERRISUR',
        'SERVICIO DE TRANSPORTE', 'cl.arenasc@alumnos.duoc.cl', '17374955-0', 'AV JOSE PEDRO ALESSANDRI 2784', '6678332');
INSERT INTO FV_USER.DATO_COMERCIAL (ID_COMERCIAL, ID_CLIENTE, ID_CIUDAD, RSOCIAL_COMERCIAL, FANTASIA_COMERCIAL, GIRO_COMERCIAL, EMAIL_COMERCIAL,
                                    DNI_COMERCIAL, DIR_COMERCIAL, FONO_COMERCIAL)
VALUES ('6a0f6a1e-f661-4400-b039-13a5a59c3446', '729d6773-a60c-4dd5-9e39-9629e44c98b2', 20, 'La Canastita S.A', 'La Canastita Económica',
        'Venta de frutas', 'cl.arenasc@alumnos.duoc.cl', '17846733-5', 'Los Aromos 987', '8872993');

prompt  Insertando productos de ejemplo.;
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('639c2606-62ba-428d-ac8f-3336f723d92b', '08daae9c-d977-4234-a054-0b83918ed3e7', 1, 'Naranja', 'Despacho en mallas de 30 kg.', 450, 800);
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('75e09051-b581-4cbb-bd10-97a1cccdcfc9', '08daae9c-d977-4234-a054-0b83918ed3e7', 1, 'Limon', 'Despacho en mallas de 30 kg.', 490, 950);
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('42a780aa-e467-4f99-ae8f-e9e24f1811e2', '08daae9c-d977-4234-a054-0b83918ed3e7', 2, 'Almendra', 'Despacho en cajas de 15 kg.', 300, 500);
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('d297e54b-a395-4b33-93c0-35b77e4b8e75', '08daae9c-d977-4234-a054-0b83918ed3e7', 1, 'Frutilla', 'Despacho en cajas de 10 kg.', 300, 900);
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('f5582361-08f3-4cfe-8935-3f8539b26c99', '08daae9c-d977-4234-a054-0b83918ed3e7', 2, 'Kiwi', 'Despacho en mallas de 25 kg.', 300, 600);
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('a0eff913-703f-407d-90a8-25f5ff39e78d', '08daae9c-d977-4234-a054-0b83918ed3e7', 1, 'Papaya', 'DESPACHO EN MALLAS DE 30 KG.', 470, 750);
Insert into FV_USER.PRODUCTO (ID_PRODUCTO, ID_CLIENTE, ID_CATEGORIA, NOMBRE_PRODUCTO, OBS_PRODUCTO, VALOR_PRODUCTO, CANTIDAD_PRODUCTO)
values ('c70e5e92-b747-4e35-b0e8-77f82e1d83cc', '08daae9c-d977-4234-a054-0b83918ed3e7', 2, 'Manzana', 'Despacho en cajas de 20 kg.', 450, 790);

prompt  Insertando contratos de ejemplo a los clientes conocidos de ejemplo.;
INSERT INTO FV_USER.CONTRATO (ID_CONTRATO, ID_TIPO_CONTRATO, INICIO_CONTRATO, TERMINO_CONTRATO, ESTA_VIGENTE, DESC_CONTRATO, COMISION_CONTRATO,
                              PERFIL_CONTRATO, FECHA_REGISTRO)
VALUES ('d8831914-2d65-4104-83ad-008e95d0db15', 1, TO_DATE('26/11/20', 'DD/MM/RR'), TO_DATE('26/05/21', 'DD/MM/RR'), 1,
        'CONTRATO DE TRANSPORTISTA CAMIONERO', 15, 6, TO_DATE('26/11/20', 'DD/MM/RR'));
INSERT INTO FV_USER.CONTRATO (ID_CONTRATO, ID_TIPO_CONTRATO, INICIO_CONTRATO, TERMINO_CONTRATO, ESTA_VIGENTE, DESC_CONTRATO, COMISION_CONTRATO,
                              PERFIL_CONTRATO, FECHA_REGISTRO)
VALUES ('109c8566-24d0-4812-b234-3966a5e08d1d', 1, TO_DATE('26/11/20', 'DD/MM/RR'), TO_DATE('26/05/21', 'DD/MM/RR'), 1,
        'CONTRATO PRODUCTORES DE VALPARAISO', 20, 5, TO_DATE('26/11/20', 'DD/MM/RR'));

prompt Insertando detalle de contratos.;
INSERT INTO FV_USER.CONTRATO_CLIENTE (ID, ID_CONTRATO, ID_CLIENTE, FECHA_ACEPTACION, FECHA_REGISTRO, OBS_CONTRATO, OBS_CLIENTE, VALOR_ADICIONAL,
                                      VALOR_MULTA, ESTADO_ACEPTACION)
VALUES ('B4FE1569D7740756E053020011AC2878', '109c8566-24d0-4812-b234-3966a5e08d1d', '08daae9c-d977-4234-a054-0b83918ed3e7', NULL,
        TO_DATE('26/11/20', 'DD/MM/RR'), NULL, NULL, 0, 0, 0);
INSERT INTO FV_USER.CONTRATO_CLIENTE (ID, ID_CONTRATO, ID_CLIENTE, FECHA_ACEPTACION, FECHA_REGISTRO, OBS_CONTRATO, OBS_CLIENTE, VALOR_ADICIONAL,
                                      VALOR_MULTA, ESTADO_ACEPTACION)
VALUES ('B4FE1924C991074EE053020011ACCC0E', 'd8831914-2d65-4104-83ad-008e95d0db15', '5f950227-a59a-48ec-a358-a403ede00bca', NULL,
        TO_DATE('26/11/20', 'DD/MM/RR'), NULL, NULL, 0, 0, 0);



prompt Insertando empleados de prueba.;
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
VALUES ('1', '1', 1, 'Daniel', 'Garcia Asathor');
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
VALUES ('2', '2', 2, 'Claudio', 'Arenas Carril');
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
VALUES ('3', '3', 2, 'Lucas', 'Repetto Asencio');


prompt Aceptando cambios.;
commit;

