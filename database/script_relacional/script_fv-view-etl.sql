-- Archivo: script_fv-view-etl.sql
--      Crea las vistas para el ETL de feria virtual.
-- Alumno: Daniel Garcia

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;


prompt;
prompt Creando vistas para ETL.;
prompt ------------------------;


prompt Creando vista de dimension de clientes.;
CREATE OR REPLACE VIEW fv_user.vwETL_clientes AS
SELECT cli.id_cliente                                                                                         AS "id_cliente",
       cli.nombre_cliente                                                                                     AS "nombre_cliente",
       cli.apellido_cliente                                                                                   AS "apellido_cliente",
       cli.nombre_cliente || ' ' || cli.apellido_cliente                                                      AS "nombre_completo",
       (SELECT COUNT(ped.id_pedido)
        FROM fv_user.pedido ped
                 INNER JOIN fv_user.seguimiento_pedido seg ON ped.id_pedido = seg.id_pedido
        WHERE cli.id_cliente = ped.id_cliente
          AND seg.id_estado = 7
       )                                                                                                      AS "cantidad_compras",
       (SELECT COUNT(ped.id_pedido)
        FROM fv_user.pedido ped
                 INNER JOIN fv_user.seguimiento_pedido seg ON ped.id_pedido = seg.id_pedido
        WHERE cli.id_cliente = ped.id_cliente
          AND seg.id_estado = 8
       )                                                                                                      AS "cantidad_rechazos",
       usu.is_active                                                                                          AS "is_activo",
       CASE usu.is_active
           WHEN 1 THEN 'Activo'
           WHEN 0 THEN 'Inactivo'
           END                                                                                                AS "Estado_usuario",
       (to_number(to_char(usu.registro, 'j')) - to_number(to_char(TO_DATE('1900-01-01', 'yyyy-MM-dd'), 'j'))) AS "fecha_registro"
FROM fv_user.cliente cli
         INNER JOIN fv_user.usuario usu ON cli.id_usuario = usu.id_usuario
WHERE cli.id_rol = 3
   OR cli.id_rol = 4
ORDER BY cli.id_rol, cli.apellido_cliente, cli.nombre_cliente;


prompt Creando vista de dimension de productores.;
CREATE OR REPLACE VIEW fv_user.vwETL_productores AS
SELECT cli.id_cliente                                                                                         AS "id_productor",
       cli.nombre_cliente                                                                                     AS "nombre_productor",
       cli.apellido_cliente                                                                                   AS "apellido_productor",
       cli.nombre_cliente || ' ' || cli.apellido_cliente                                                      AS "nombre_completo",
       usu.is_active                                                                                          AS "is_activo",
       CASE usu.is_active
           WHEN 1 THEN 'Activo'
           WHEN 0 THEN 'Inactivo'
           END                                                                                                AS "Estado_productor",
       (to_number(to_char(usu.registro, 'j')) - to_number(to_char(TO_DATE('1900-01-01', 'yyyy-MM-dd'), 'j'))) AS "fecha_registro"
FROM fv_user.cliente cli
         INNER JOIN fv_user.usuario usu ON cli.id_usuario = usu.id_usuario
WHERE cli.id_rol = 5
ORDER BY cli.id_rol, cli.apellido_cliente, cli.nombre_cliente;


prompt Creando vista de dimension de productos.;
CREATE OR REPLACE VIEW fv_user.vwETL_productos AS
SELECT pro.id_producto       as "id_producto",
       pro.nombre_producto   as "producto",
       pro.valor_producto    as "precio_kg",
       pro.cantidad_producto as "stock_disponible"
FROM fv_user.producto pro
ORDER BY pro.id_categoria, pro.nombre_producto;


prompt  Creando vista para ordenes de compra.;
CREATE OR REPLACE VIEW fv_user.vwETL_ordenes_compra AS
SELECT ped.id_pedido                                                                                              AS "id_orden",
       (to_number(to_char(ped.fecha_pedido, 'j')) - to_number(to_char(TO_DATE('1900-01-01', 'yyyy-MM-dd'), 'j'))) AS fecha_orden,
       (SELECT id_estado
        FROM fv_user.seguimiento_pedido
        WHERE id_pedido = ped.id_pedido
        ORDER BY id_estado DESC FETCH FIRST ROW ONLY)                                                             AS estado_orden,
       (SELECT est.desc_estado
        FROM fv_user.seguimiento_pedido spe
                 INNER JOIN fv_user.estado_pedido est ON spe.id_estado = est.id_estado
        WHERE spe.id_pedido = ped.id_pedido
        ORDER BY spe.id_estado DESC FETCH FIRST ROW ONLY)                                                         AS descripcion_estado,
       con.id_condicion                                                                                           AS condicion_pago,
       con.desc_condicion                                                                                         AS descripcion_condicion,
       ped.descuento_solicitado                                                                                   AS porcentaje_descuento,
       nvl(
               (to_number(to_char(pag.fecha_pago, 'j')) - to_number(to_char(TO_DATE('1900-01-01', 'yyyy-MM-dd'), 'j')))
           , 0)                                                                                                   AS fecha_pago,
       nvl(pag.monto_pago, 0)                                                                                     AS monto_pagado,
       nvl(met.id_metpago, 0)                                                                                     AS metodo_pago,
       nvl(met.desc_metpago, '')                                                                                  AS descripcion_metodo_pago,
       nvl(
               (to_number(to_char(env.fecha_envio, 'j')) - to_number(to_char(TO_DATE('1900-01-01', 'yyyy-MM-dd'), 'j')))
           , 0)                                                                                                   AS fecha_envio,
       nvl(cli.nombre_cliente || ' ' || cli.apellido_cliente, '')                                                 AS transportista,
       nvl(env.costo_envio, 0)                                                                                    AS costo_envio,
       nvl(sgr.nombre_seguro, '')                                                                                 AS seguro_asociado,
       nvl(sgr.compania_seguro, '')                                                                               AS aseguradora,
       nvl(sgr.primabase_seguro, 0)                                                                               AS prima_seguro
FROM fv_user.pedido ped
         INNER JOIN fv_user.condicion_pago con ON ped.id_condicion = con.id_condicion
         LEFT JOIN fv_user.pago pag ON ped.id_pedido = pag.id_pedido
         LEFT JOIN fv_user.metodo_pago met ON pag.id_metpago = met.id_metpago
         LEFT JOIN fv_user.envio env ON ped.id_pedido = env.id_pedido
         LEFT JOIN fv_user.seguro sgr ON env.id_seguro = sgr.id_seguro
         LEFT JOIN fv_user.subasta sub ON ped.id_pedido = sub.id_pedido
         LEFT JOIN fv_user.cliente cli ON sub.id_cliente = cli.id_cliente
ORDER BY ped.fecha_pedido;


prompt Creando vista para fact_table.;
CREATE OR REPLACE VIEW fv_user.vwETL_fact_table AS
SELECT (to_number(to_char(ped.fecha_pedido, 'j')) - to_number(to_char(TO_DATE('1900-01-01', 'yyyy-MM-dd'), 'j'))) AS "id_fecha",
       res.id_pedido                                                                                              AS "id_orden",
       ped.id_cliente                                                                                             AS "id_cliente",
       pro.id_cliente                                                                                             AS "id_productor",
       pro.id_producto                                                                                            AS "id_producto",
       res.cantidad                                                                                               AS "cantidad_productos_solicitados",
       res.costo_unitario                                                                                         AS "precio_por_kg_ofrecido",
       (res.cantidad * res.costo_unitario)                                                                        AS "precio_productos",
       (SELECT id_rol FROM fv_user.cliente WHERE id_cliente = ped.id_cliente)                                     AS "tipo_cliente",
       (SELECT nombre_rol
        FROM fv_user.cliente cl
                 INNER JOIN fv_user.rol_usuario rl ON cl.id_rol = rl.id_rol
        WHERE id_cliente = ped.id_cliente)                                                                        AS "descripcion_rol",
       cat.id_categoria                                                                                           AS "categoria_producto",
       cat.desc_categoria                                                                                         AS "descripcion_categoria",
       CASE
           WHEN pro.cantidad_producto = 0 THEN 0
           ELSE 1
           END                                                                                                    AS "tiene_stock_disponible",
       (SELECT CASE
                   WHEN id_estado BETWEEN 1 AND 4 THEN 0
                   WHEN id_estado = 5 THEN 1
                   WHEN id_estado = 6 THEN 2
                   WHEN id_estado = 7 THEN 3
                   ELSE 4
                   END AS "resultado"
        FROM fv_user.seguimiento_pedido
        WHERE id_pedido = ped.id_pedido
        ORDER BY id_estado DESC FETCH FIRST ROW ONLY)                                                             AS "estado_producto",
       (SELECT CASE
                   WHEN id_estado BETWEEN 1 AND 4 THEN 'En bodega'
                   WHEN id_estado = 5 THEN 'Despachado'
                   WHEN id_estado = 6 THEN 'Entregado a cliente'
                   WHEN id_estado = 7 THEN 'Aceptado por cliente'
                   ELSE 'Merma'
                   END AS "resultado"
        FROM fv_user.seguimiento_pedido
        WHERE id_pedido = ped.id_pedido
        ORDER BY id_estado DESC FETCH FIRST ROW ONLY)                                                             AS "descripcion_estado"
FROM fv_user.pedido ped
         INNER JOIN fv_user.resultado_propuesto res ON ped.id_pedido = res.id_pedido
         INNER JOIN fv_user.producto pro ON res.id_producto = pro.id_producto
         INNER JOIN fv_user.categoria_producto cat ON pro.id_categoria = cat.id_categoria
         INNER JOIN fv_user.cliente cli ON pro.id_cliente = cli.id_cliente
ORDER BY ped.fecha_pedido;


prompt  Confirmando cambios.;
commit;

