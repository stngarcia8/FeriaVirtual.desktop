-- Archivo: script_fv-popul.sql
--      Inserta los registros iniciales a feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.
-- Descripcion: Genera la base en oracle para el aplicativo de feria virtual.
-- Instrucciones:
--  Usar la cuenta de sysdba.
--  conectarse desde la consola y ejecutar el script:
--  conn / as sysdba;
--  @<rutaDelScript>/<scriptFeriaVirtual.sql;
--  esperar que termine.
--  conectar con docker
--  docker exec -it oraclexe sqlplus sys/avaras08@//localhost:1521/xe as sysdba
SET ECHO OFF;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
prompt insertando registros iniciales.;


prompt Insertando categorias de productos.;
INSERT INTO fv_user.categoria_producto VALUES (1,'Exportación');
INSERT INTO fv_user.categoria_producto VALUES (2,'Venta nacional');


prompt Insertando medios de transportes.;
INSERT INTO fv_user.tipo_transporte VALUES (1,'Aereo');
INSERT INTO fv_user.tipo_transporte VALUES (2,'Terrestre');
INSERT INTO fv_user.tipo_transporte VALUES (3,'Maritimo');


prompt Insertando condiciones de pago.;
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion) VALUES (1, 'Contado');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion) VALUES (2, '30 días');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion) VALUES (3, '60 días');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion) VALUES (4, '90 días');
INSERT INTO fv_user.condicion_pago (id_condicion, desc_condicion) VALUES (5, '120 días');


prompt Insertando estado de pedido.;
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado) VALUES (1, 'Recepcionado');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado) VALUES (2, 'En proceso');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado) VALUES (3, 'Finalizado');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado) VALUES (4, 'Cancelado');
INSERT INTO fv_user.estado_pedido (id_estado, desc_estado) VALUES (5, 'Anulado');


prompt Insertando procesos de pedidos.;
INSERT INTO fv_user.proceso_pedido (id_proceso, desc_proceso) VALUES (1, 'Negociación');
INSERT INTO fv_user.proceso_pedido (id_proceso, desc_proceso) VALUES (2, 'Recolección');
INSERT INTO fv_user.proceso_pedido (id_proceso, desc_proceso) VALUES (3, 'Despacho');
INSERT INTO fv_user.proceso_pedido (id_proceso, desc_proceso) VALUES (4, 'Embarque');


prompt Insertando paises.;
INSERT INTO fv_user.pais VALUES (1,'Alemania','+54');
INSERT INTO fv_user.pais VALUES (2,'Argentina','+49');
INSERT INTO fv_user.pais VALUES (3,'Australia','+61');
INSERT INTO fv_user.pais VALUES (4,'Austria','+43');
INSERT INTO fv_user.pais VALUES (5,'Belgica','+32');
INSERT INTO fv_user.pais VALUES (6,'Brasil','+55');
INSERT INTO fv_user.pais VALUES (7,'Bulgaria','+359');
INSERT INTO fv_user.pais VALUES (8,'Canada','+1');
INSERT INTO fv_user.pais VALUES (9,'Chile','+56');
INSERT INTO fv_user.pais VALUES (10,'China','+86');
INSERT INTO fv_user.pais VALUES (11,'Colombia','+57');
INSERT INTO fv_user.pais VALUES (12,'Croacia','+385');
INSERT INTO fv_user.pais VALUES (13,'Dinamarca','+45');
INSERT INTO fv_user.pais VALUES (14,'Egipto','+20');
INSERT INTO fv_user.pais VALUES (15,'España','+34');
INSERT INTO fv_user.pais VALUES (16,'Francia','+33');
INSERT INTO fv_user.pais VALUES (17,'Grecia','+30');
INSERT INTO fv_user.pais VALUES (18,'Holanda','+31');
INSERT INTO fv_user.pais VALUES (19,'India','+91');
INSERT INTO fv_user.pais VALUES (20,'Italia','+39');
INSERT INTO fv_user.pais VALUES (21,'Japon','+81');
INSERT INTO fv_user.pais VALUES (22,'Mexico','+52');
INSERT INTO fv_user.pais VALUES (23,'Noruega','+47');
INSERT INTO fv_user.pais VALUES (24,'Peru','+51');
INSERT INTO fv_user.pais VALUES (25,'Portugal','+351');
INSERT INTO fv_user.pais VALUES (26,'Qatar','+974');
INSERT INTO fv_user.pais VALUES (27,'Rusia','+7');
INSERT INTO fv_user.pais VALUES (28,'Reino Unido','+44');
INSERT INTO fv_user.pais VALUES (29,'Sudafrica','+27');
INSERT INTO fv_user.pais VALUES (30,'Suecia','+46');
INSERT INTO fv_user.pais VALUES (31,'Suiza','+41');
INSERT INTO fv_user.pais VALUES (32,'Tailandia','+66');
INSERT INTO fv_user.pais VALUES (33,'Turquia','+90');
INSERT INTO fv_user.pais VALUES (34,'Usa','+1');
INSERT INTO fv_user.pais VALUES (35,'Uruguay','+598');
INSERT INTO fv_user.pais VALUES (36,'Vietnam','+84');


prompt Insertando ciudades.;
INSERT INTO fv_user.ciudad VALUES (1,1,'Berlin');
INSERT INTO fv_user.ciudad VALUES (2,1,'Munich');
INSERT INTO fv_user.ciudad VALUES (3,2,'Buenos Aires');
INSERT INTO fv_user.ciudad VALUES (4,2,'Cordoba');
INSERT INTO fv_user.ciudad VALUES (5,3,'Sidney');
INSERT INTO fv_user.ciudad VALUES (6,3,'Melbourne');
INSERT INTO fv_user.ciudad VALUES (7,3,'Canberra');
INSERT INTO fv_user.ciudad VALUES (8,4,'Viena');
INSERT INTO fv_user.ciudad VALUES (9,5,'Bruselas');
INSERT INTO fv_user.ciudad VALUES (10,5,'Brujas');
INSERT INTO fv_user.ciudad VALUES (11,6,'Brasilia');
INSERT INTO fv_user.ciudad VALUES (12,6,'Rio de janeiro');
INSERT INTO fv_user.ciudad VALUES (13,6,'Sao Paulo');
INSERT INTO fv_user.ciudad VALUES (14,7,'Sofia');
INSERT INTO fv_user.ciudad VALUES (15,8,'Ottawa');
INSERT INTO fv_user.ciudad VALUES (16,8,'Toronto');
INSERT INTO fv_user.ciudad VALUES (17,8,'Montreal');
INSERT INTO fv_user.ciudad VALUES (18,9,'Santiago');
INSERT INTO fv_user.ciudad VALUES (19,9,'Valparaiso');
INSERT INTO fv_user.ciudad VALUES (20,9,'Valdivia');
INSERT INTO fv_user.ciudad VALUES (21,9,'Concepcion');
INSERT INTO fv_user.ciudad VALUES (22,10,'Pekin');
INSERT INTO fv_user.ciudad VALUES (23,10,'Shanghai');
INSERT INTO fv_user.ciudad VALUES (24,11,'Bogota');
INSERT INTO fv_user.ciudad VALUES (25,11,'Medellin');
INSERT INTO fv_user.ciudad VALUES (26,12,'Zagreb');
INSERT INTO fv_user.ciudad VALUES (27,13,'Copenhague');
INSERT INTO fv_user.ciudad VALUES (28,14,'El cairo');
INSERT INTO fv_user.ciudad VALUES (29,15,'Madrid');
INSERT INTO fv_user.ciudad VALUES (30,15,'Barcelona');
INSERT INTO fv_user.ciudad VALUES (31,16,'Paris');
INSERT INTO fv_user.ciudad VALUES (32,17,'Atenas');
INSERT INTO fv_user.ciudad VALUES (33,18,'Amsterdam');
INSERT INTO fv_user.ciudad VALUES (34,19,'Nueva Delhi');
INSERT INTO fv_user.ciudad VALUES (35,19,'Bombay');
INSERT INTO fv_user.ciudad VALUES (36,20,'Roma');
INSERT INTO fv_user.ciudad VALUES (37,20,'Milan');
INSERT INTO fv_user.ciudad VALUES (38,21,'Tokio');
INSERT INTO fv_user.ciudad VALUES (39,22,'Ciudad de Mexico');
INSERT INTO fv_user.ciudad VALUES (40,22,'Monterrey');
INSERT INTO fv_user.ciudad VALUES (41,23,'Oslo');
INSERT INTO fv_user.ciudad VALUES (42,24,'Lima');
INSERT INTO fv_user.ciudad VALUES (43,25,'Lisboa');
INSERT INTO fv_user.ciudad VALUES (44,25,'Oporto');
INSERT INTO fv_user.ciudad VALUES (45,26,'Doha');
INSERT INTO fv_user.ciudad VALUES (46,27,'Moscu');
INSERT INTO fv_user.ciudad VALUES (47,27,'San Petersburgo');
INSERT INTO fv_user.ciudad VALUES (48,28,'Londres');
INSERT INTO fv_user.ciudad VALUES (49,29,'Manchester');
INSERT INTO fv_user.ciudad VALUES (50,30,'Estocolmo');
INSERT INTO fv_user.ciudad VALUES (51,31,'Berna');
INSERT INTO fv_user.ciudad VALUES (52,31,'Zurich');
INSERT INTO fv_user.ciudad VALUES (53,32,'Bangkok');
INSERT INTO fv_user.ciudad VALUES (54,33,'Ankara');
INSERT INTO fv_user.ciudad VALUES (55,33,'Estambul');
INSERT INTO fv_user.ciudad VALUES (56,34,'Washington');
INSERT INTO fv_user.ciudad VALUES (57,34,'Los Angeles');
INSERT INTO fv_user.ciudad VALUES (58,34,'New York');
INSERT INTO fv_user.ciudad VALUES (59,34,'Miami');
INSERT INTO fv_user.ciudad VALUES (60,35,'Montevideo');
INSERT INTO fv_user.ciudad VALUES (61,36,'Hanoi');


prompt Insertando tipos de contratos.;
INSERT INTO fv_user.tipo_contrato (id_tipo_contrato, desc_tipo_contrato) VALUES(1, 'Externo');
INSERT INTO fv_user.tipo_contrato (id_tipo_contrato, desc_tipo_contrato) VALUES(2, 'Interno');
INSERT INTO fv_user.tipo_contrato (id_tipo_contrato, desc_tipo_contrato) VALUES(3, 'Externo/Interno');


prompt Insertando roles de usuario.;
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol) VALUES (1, 'Administrador');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol) VALUES (2, 'Consultor');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol) VALUES (3, 'Cliente externo');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol) VALUES (4, 'Cliente interno');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol) VALUES (5, 'Productor');
INSERT INTO fv_user.rol_usuario (id_rol, nombre_rol) VALUES (6, 'Transportista');


prompt Creando usuarios de ejemplo.
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro) VALUES ('1', 'd.garcial', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'd.garcial@alumnos.duoc.cl', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro) VALUES ('2', 'c.arenas', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'c.arenas@alumnos.duoc.cl', 1, TO_DATE('2020/09/07', 'yyyy/mm/dd'));
INSERT INTO fv_user.usuario(id_usuario, username, password, email, is_active, registro) VALUES ('3', 'l.repetto', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'l.repetto@alumnos.duoc.cl', 0, TO_DATE('2020/09/07', 'yyyy/mm/dd'));


prompt Insertando empleados de prueba.;
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado) VALUES ('1', '1', 1, 'Daniel', 'Garcia Asathor');
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado) VALUES ('2', '2', 2, 'Claudio', 'Arenas Carril');
INSERT INTO fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado) VALUES ('3', '3', 2, 'Lucas', 'Repetto Asencio');



prompt Aceptando cambios.;
commit;

