-- Archivo: script_fv-view.sql
--      Crea las vistas para feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;


prompt;
prompt Creando vistas predefinidas.;
prompt ----------------------------------------;


prompt Creando vistas de usuarios del sistema.;
create or replace view fv_user.vwObtenerUsuarios as
select emp.id_empleado,
       usr.id_usuario,
       rol.id_rol,
       emp.nombre_empleado                 as "Nombre",
       emp.apellido_empleado               as "Apellido",
       usr.username,
       usr.password,
       usr.email                           as "Email",
       rol.nombre_rol                      AS "Rol",
       usr.is_active,
       case usr.is_active
           when 0 then 'Inhabilitado'
           when 1 then 'habilitado'
           end                             as "Estado",
       to_char(usr.registro, 'dd/MM/yyyy') as "Registrado"
from fv_user.usuario usr
         inner join fv_user.empleado emp on usr.id_usuario = emp.id_usuario
         inner join fv_user.rol_usuario rol on emp.id_rol = rol.id_rol
WHERE emp.id_rol = 1
   or emp.id_rol = 2
order by emp.id_rol, emp.apellido_empleado, emp.nombre_empleado;


prompt Creando vista para los logins de usuarios.;
create or replace view fv_user.vwObtenerLogin as
select cli.id_cliente,
       usr.id_usuario,
       rol.id_rol,
       cli.nombre_cliente                  as "Nombre",
       cli.apellido_cliente                as "Apellido",
       usr.username,
       usr.password,
       usr.email                           as "Email",
       rol.nombre_rol                      AS "Rol",
       usr.is_active,
       case usr.is_active
           when 0 then 'Inhabilitado'
           when 1 then 'habilitado'
           end                             as "Estado",
       to_char(usr.registro, 'dd/MM/yyyy') as "Registrado"
from fv_user.usuario usr
         inner join fv_user.cliente cli on usr.id_usuario = cli.id_usuario
         inner join fv_user.rol_usuario rol on cli.id_rol = rol.id_rol
order by cli.id_rol, cli.apellido_cliente, cli.nombre_cliente;


prompt Creando vista para logins.;
create or replace view fv_user.vwLogin as
select *
from vwObtenerUsuarios
union
select *
from vwObtenerLogin;


prompt Creando vistas de clientes.;
create or replace view fv_user.vwObtenerClientes as
select cli.id_cliente,
       usr.id_usuario,
       cli.id_rol,
       cli.nombre_cliente || ' ' || cli.apellido_cliente as "Nombre cliente",
       cli.nombre_cliente,
       cli.apellido_cliente,
       cli.dni_cliente                                   AS "DNI",
       usr.username,
       usr.password,
       usr.email                                         as "Email",
       usr.is_active,
       case usr.is_active
           when 0 then 'Inhabilitado'
           when 1 then 'habilitado'
           end                                           as "Estado",
       rol.nombre_rol                                    AS "Rol",
       to_char(usr.registro, 'dd/MM/yyyy')               as "Registrado"
from fv_user.usuario usr
         inner join fv_user.cliente cli on usr.id_usuario = cli.id_usuario
         inner join rol_usuario rol on cli.id_rol = rol.id_rol
WHERE cli.id_rol > 2
order by cli.apellido_cliente, cli.nombre_cliente;


prompt Creando vista para datos comerciales.;
create or replace view fv_user.vwObtenerDatosComerciales as
select id_comercial,
       id_cliente,
       rsocial_comercial  AS "Razon social",
       fantasia_comercial AS "Nombre de fantasia",
       giro_comercial     as "Giro comercial",
       email_comercial    as "Email",
       dni_comercial      as "DNI",
       dir_comercial      as "Direccion",
       ciu.id_ciudad,
       ciu.nombre_ciudad  AS "Ciudad",
       pai.id_pais,
       pai.nombre_pais    AS "Pais",
       pai.prefijo_pais   AS "Prefijo",
       fono_comercial     AS "Telefono"
from dato_comercial dat
         inner join fv_user.ciudad ciu on dat.id_ciudad = ciu.id_ciudad
         inner join fv_user.pais pai on ciu.id_pais = pai.id_pais;


prompt Creando vista para los productos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerProductos AS
SELECT pro.id_producto,
       pro.id_cliente,
       cat.id_categoria,
       cat.desc_categoria    AS "Categoria",
       pro.nombre_producto   AS "Producto",
       pro.obs_producto      AS "Observacion",
       pro.valor_producto    AS "Valor",
       pro.cantidad_producto AS "Cantidad"
FROM fv_user.producto pro
         INNER JOIN categoria_producto cat ON pro.id_categoria = cat.id_categoria
ORDER BY pro.nombre_producto;


prompt Creando vista para los productos de exportacion.;
CREATE OR REPLACE VIEW fv_user.vwObtenerProductosExportacion AS
SELECT DISTINCT nombre_producto, id_categoria
FROM fv_user.producto;


prompt Creando vista para los vehiculos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerVehiculos AS
SELECT veh.id_vehiculo,
       veh.id_cliente,
       tip.id_tipo_transporte,
       tip.desc_tipo_transporte    AS "Tipo",
       veh.patente_vehiculo        AS "Patente",
       veh.modelo_vehiculo         AS "Modelo",
       veh.capacidad_vehiculo      AS "Capacidad",
       veh.disponibilidad_vehiculo AS "Disponible",
       veh.observacion_vehiculo    AS "Observacion"
FROM fv_user.vehiculo veh
         INNER JOIN fv_user.tipo_transporte tip ON veh.id_tipo_transporte = tip.id_tipo_transporte;


prompt Creando vista para los contratos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerContratos AS
SELECT con.id_contrato,
       con.desc_contrato                                                                   AS "Descripcion",
       tip.id_tipo_contrato,
       tip.desc_tipo_contrato                                                              AS "Tipo",
       to_char(con.inicio_contrato, 'dd/MM/yyyy')                                          AS "Inicio",
       to_char(con.termino_contrato, 'dd/MM/yyyy')                                         AS "Termino",
       con.esta_vigente,
       CASE con.esta_vigente
           WHEN 1 THEN 'Vigente'
           WHEN 0 THEN 'Caducado'
           END                                                                             AS "Estado",
       con.comision_contrato                                                               AS "Comision",
       con.perfil_contrato,
       to_char(con.fecha_registro, 'dd/MM/yyyy')                                           AS "Fecha registro",
       (SELECT COUNT(*) FROM fv_user.contrato_cliente WHERE id_contrato = con.id_contrato) AS "Nro Asociados"
FROM fv_user.contrato con
         INNER JOIN fv_user.tipo_contrato tip ON con.id_tipo_contrato = tip.id_tipo_contrato;


prompt Creando vista para los asociados al contrato.;
CREATE OR REPLACE VIEW fv_user.vwAsociadosContrato AS
SELECT con.id_contrato,
       cli.id_cliente,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Cliente",
       cli.dni_cliente                                   AS "Rut",
       usr.email,
       con.obs_contrato                                  AS "Observacion contrato",
       con.obs_cliente                                   AS "Observacion cliente",
       con.valor_adicional                               AS "Valor adicional",
       con.valor_multa                                   AS "Valor multa",
       con.estado_aceptacion,
       CASE con.estado_aceptacion
           WHEN 0 THEN 'No visualizado'
           WHEN 1 THEN 'Aceptado'
           WHEN 2 THEN 'Rechazado'
           END                                           AS "Estado"
FROM fv_user.contrato_cliente con
         INNER JOIN fv_user.cliente cli ON con.id_cliente = cli.id_cliente
         INNER JOIN fv_user.usuario usr ON cli.id_usuario = usr.id_usuario;

prompt Creando vista de contrato por asociados.;
CREATE OR REPLACE VIEW fv_user.vwContratoPorAsociado AS
SELECT con.id_contrato,
       cli.id_cliente,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Cliente",
       cli.dni_cliente                                   AS "Rut",
       usr.email,
       con.obs_contrato                                  AS "Observacion contrato",
       con.obs_cliente                                   AS "Observacion cliente",
       to_char(cto.inicio_contrato, 'dd/MM/yyyy')        AS "Inicio",
       to_char(cto.termino_contrato, 'dd/MM/yyyy')       AS "Termino",
       cto.esta_vigente,
       CASE cto.esta_vigente
           WHEN 0 THEN 'Caducado'
           WHEN 1 THEN 'Vigente'
           END                                           AS "Vigente",
       cto.desc_contrato                                 AS "Descripcion",
       cto.comision_contrato                                "Comision",
       con.valor_adicional                               AS "Valor adicional",
       con.valor_multa                                   AS "Valor multa",
       con.estado_aceptacion,
       CASE con.estado_aceptacion
           WHEN 0 THEN 'No visualizado'
           WHEN 1 THEN 'Aceptado'
           WHEN 2 THEN 'Rechazado'
           END                                           AS "Estado"
FROM fv_user.contrato_cliente con
         INNER JOIN fv_user.cliente cli ON con.id_cliente = cli.id_cliente
         INNER JOIN fv_user.usuario usr ON cli.id_usuario = usr.id_usuario
         INNER JOIN fv_user.contrato cto ON con.id_contrato = cto.id_contrato;


prompt Creando vista para pedidos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerPedidos AS
SELECT ped.id_pedido,
       ped.id_cliente,
       con.id_condicion,
       con.desc_condicion                      AS "Condicion de pago",
       to_char(ped.fecha_pedido, 'dd/MM/yyyy') AS "Fecha pedido",
       ped.descuento_solicitado                AS "Descuento solicitado"
FROM fv_user.pedido ped
         INNER JOIN fv_user.condicion_pago con ON ped.id_condicion = con.id_condicion;


prompt Creando vista para el detalle de pedido.;
CREATE OR REPLACE VIEW fv_user.vwObtenerDetallePedido AS
SELECT det.id,
       det.id_pedido,
       nombre_producto AS "Nombre producto",
       det.cantidad    AS "Cantidad solicitada"
FROM fv_user.detalle_pedido det;


prompt Creando vista para obbtener el seguimiento del pedido.;
CREATE OR REPLACE VIEW fv_user.vwObtenerSeguimientoPedido AS
SELECT seg.id_seguimiento,
       seg.id_pedido,
       est.id_estado,
       est.desc_estado                          AS "Estado",
       to_char(seg.fecha_proceso, 'dd/MM/yyyy') AS "Fecha proceso"
FROM fv_user.seguimiento_pedido seg
         INNER JOIN fv_user.estado_pedido est ON seg.id_estado = est.id_estado;


prompt Creando vista de pedidos para enviar a api.;
CREATE OR REPLACE VIEW fv_user.vwObtenerPedidoToApi AS
SELECT ped.id_pedido,
       ped.id_cliente,
       cli.id_rol,
       cli.nombre_cliente || ' ' || cli.apellido_cliente                                            AS "Cliente",
       to_char(ped.fecha_pedido, 'dd/MM/yyyy')                                                      AS "Fecha orden",
       cpa.id_condicion,
       cpa.desc_condicion                                                                              "Condicion pago",
       TRIM(dco.rsocial_comercial)                                                                  AS "empresa",
       ped.descuento_solicitado                                                                     AS "Descuento",
       ped.obs_pedido                                                                               AS "Observacion",
       TRIM(dco.dir_comercial) || ', ' || TRIM(ciu.nombre_ciudad) || ' - ' || TRIM(pai.nombre_pais) AS "dir",
       TRIM(pai.prefijo_pais) || '-' || TRIM(dco.fono_comercial)                                    AS "fono",
       (SELECT *
        FROM (SELECT id_estado FROM fv_user.seguimiento_pedido WHERE id_pedido = ped.id_pedido ORDER BY id_estado DESC)
        WHERE ROWNUM = 1)                                                                           AS "ID_ESTADO",
       nvl((SELECT nvl(estado_subasta, 0) FROM fv_user.subasta WHERE id_pedido = ped.id_pedido), 0) AS "estado_subasta"
FROM fv_user.pedido ped
         INNER JOIN fv_user.condicion_pago cpa ON ped.id_condicion = cpa.id_condicion
         INNER JOIN fv_user.cliente cli ON ped.id_cliente = cli.id_cliente
         INNER JOIN fv_user.dato_comercial dco ON cli.id_cliente = dco.id_cliente
         INNER JOIN fv_user.ciudad ciu ON dco.id_ciudad = ciu.id_ciudad
         INNER JOIN fv_user.pais pai ON ciu.id_pais = pai.id_pais;



prompt Creando vista de destinos de ordenes de compra.;
CREATE OR REPLACE VIEW fv_user.destinos AS
SELECT dco.id_cliente,
       TRIM(dco.rsocial_comercial)                                                                  AS "Cliente",
       TRIM(dco.dir_comercial) || ', ' || TRIM(ciu.nombre_ciudad) || ' - ' || TRIM(pai.nombre_pais) AS "dir",
       TRIM(pai.prefijo_pais) || '-' || TRIM(dco.fono_comercial)                                    AS "Fono"
FROM fv_user.dato_comercial dco
         INNER JOIN fv_user.ciudad ciu ON dco.id_ciudad = ciu.id_ciudad
         INNER JOIN fv_user.pais pai ON ciu.id_pais = pai.id_pais;

prompt Creando vista de resultados de propuestas.;
CREATE OR REPLACE VIEW fv_user.vwObtenerResultadoPropuesta AS
SELECT res.id_respuesta,
       res.id_pedido,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Productor",
       pro.nombre_producto                               AS "Producto",
       pro.cantidad_producto                             AS "Stock disponible",
       res.cantidad                                      AS "Cantidad solicitada",
       res.costo_unitario                                AS "Valor KG",
       (res.cantidad * res.costo_unitario)               AS "Total"
FROM fv_user.resultado_propuesto res
         INNER JOIN fv_user.producto pro ON res.id_producto = pro.id_producto
         INNER JOIN fv_user.cliente cli ON pro.id_cliente = cli.id_cliente
ORDER BY res.costo_unitario;


prompt Creando vista para pie del resultado de la propuesta.;
CREATE OR REPLACE VIEW fv_user.vwObtenerTotalPropuesta AS
SELECT ppe.id_pedido,
       valor_neto               AS "Valor neto",
       to_number(19)            AS "IVA",
       valor_iva                AS "Valor IVA",
       valor_total              AS "Total",
       ped.descuento_solicitado AS "Descuento aplicado",
       valor_descuento          AS "Total descuento",
       valor_total_descuento    AS "Total a pagar"
FROM fv_user.pie_pedido ppe
         INNER JOIN fv_user.pedido ped ON ppe.id_pedido = ped.id_pedido;

prompt Creando vista para productos de subastas.;
CREATE OR REPLACE VIEW fv_user.vwObtenerProductosSubasta AS
SELECT res.id_pedido,
       pro.nombre_producto                           as "Producto",
       SUM(res.costo_unitario)                       AS "Valor unitario",
       SUM(res.cantidad)                             AS "Cantidad",
       (SUM(res.costo_unitario) * SUM(res.cantidad)) AS "Total producto"
FROM fv_user.producto pro
         INNER JOIN fv_user.resultado_propuesto res ON pro.id_producto = res.id_producto
GROUP BY pro.nombre_producto, res.id_pedido;


prompt Creando vista para las propuestas de valor en la subasta.;
CREATE OR REPLACE VIEW fv_user.vwObtenerPujaSubasta AS
SELECT res.id_resultado,
       res.id_subasta,
       res.id_cliente,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Transportista",
       res.valor_propuest                                AS "Puja",
       to_char(res.fecha_propuesta, 'dd/MM/yyyy')        AS "Fecha",
       to_char(res.fecha_propuesta, 'hh24:mi')           AS "Hora"
FROM fv_user.resultado_subasta res
         INNER JOIN fv_user.cliente cli ON res.id_cliente = cli.id_cliente
ORDER BY valor_propuest;


prompt Creando vista para las subastas.;
CREATE OR REPLACE VIEW fv_user.vwSubastas AS
SELECT sub.id_subasta,
       ped.id_pedido,
       to_char(sub.fecha_subasta, 'dd/MM/yyyy')                                                                  AS "Fecha subasta",
       sub.valor_porcentaje,
       sub.valor_propuesto,
       sub.peso_comprometido,
       to_char(fecha_limite, 'dd/MM/yyyy')                                                                       AS "Fecha limite",
       sub.observacion_subasta                                                                                   AS "obs",
       sub.estado_subasta,
       sub.id_cliente                                                                                            as "id_transportista",
       (SELECT nombre_cliente || ' ' || apellido_cliente FROM fv_user.cliente WHERE id_cliente = sub.id_cliente) AS "Transportista",
       sub.valor_puja,
       to_char(sub.fecha_puja, 'dd/MM/yyyy')                                                                     AS "Fecha puja",
       sub.observacion_puja                                                                                      AS "Observacion transportista",
       to_char(sub.fecha_respuesta, 'dd/MM/yyyy')                                                                AS "Fecha respuesta",
       TRIM(dat.rsocial_comercial)                                                                               AS "empresa",
       TRIM(dat.dir_comercial) || ', ' || TRIM(ciu.nombre_ciudad) || ' - ' || TRIM(pai.nombre_pais)              AS "dir",
       TRIM(pai.prefijo_pais) || '-' || TRIM(dat.fono_comercial)                                                 AS "fono",
       dat.email_comercial                                                                                       as "email"
FROM fv_user.subasta sub
         INNER JOIN fv_user.pedido ped ON sub.id_pedido = ped.id_pedido
         INNER JOIN fv_user.dato_comercial dat ON ped.id_cliente = dat.id_cliente
         INNER JOIN fv_user.ciudad ciu ON dat.id_ciudad = ciu.id_ciudad
         INNER JOIN fv_user.pais pai ON ciu.id_pais = pai.id_pais;


prompt  creando vista de las ordenes de despacho.;
CREATE OR REPLACE VIEW fv_user.vwOrdenDespacho AS
SELECT ord.id_orden,
       ord.id_pedido,
       ped.id_cliente,
       ord.fecha_preparacion,
       sub.id_cliente                                                                               AS id_transportista,
       sub.valor_propuesto,
       sub.peso_comprometido,
       sub.observacion_subasta,
       dat.rsocial_comercial,
       TRIM(dat.dir_comercial) || ', ' || TRIM(ciu.nombre_ciudad) || ' - ' || TRIM(pai.nombre_pais) AS "dir",
       TRIM(pai.prefijo_pais) || ' ' || TRIM(dat.fono_comercial)                                    AS "fono",
       (SELECT id_estado
        FROM fv_user.seguimiento_pedido
        WHERE id_pedido = ped.id_pedido
        ORDER BY id_estado DESC FETCH FIRST ROW ONLY)                                               AS estado_pedido,
       ord.obs_orden,
       seg.id_seguro,
       seg.nombre_seguro                                                                            AS "Seguro",
       seg.compania_seguro                                                                          AS "Aseguradora",
       seg.primabase_seguro                                                                         AS "Prima"
FROM fv_user.orden_despacho ord
         INNER JOIN fv_user.subasta sub ON ord.id_pedido = sub.id_pedido
         INNER JOIN fv_user.pedido ped ON ord.id_pedido = ped.id_pedido
         INNER JOIN fv_user.dato_comercial dat ON ped.id_cliente = dat.id_cliente
         INNER JOIN fv_user.ciudad ciu ON dat.id_ciudad = ciu.id_ciudad
         INNER JOIN fv_user.pais pai ON ciu.id_pais = pai.id_pais
         INNER JOIN fv_user.envio env ON ord.id_pedido = env.id_pedido
         INNER JOIN fv_user.seguro seg ON env.id_seguro = seg.id_seguro;


prompt Creando vista de ofertas.;
CREATE OR REPLACE VIEW fv_user.vwObtenerOfertas AS
SELECT id_oferta,
       desc_oferta                         AS "Descripcion",
       descuento_oferta                    AS "Descuento",
       to_char(fecha_oferta, 'dd/MM/yyyy') AS "Fecha publicacion",
       tipo_oferta,
       CASE tipo_oferta
           WHEN 1 THEN 'Oferta'
           WHEN 2 THEN 'Venta de saldos'
           END                             AS "Tipo",
       estado_oferta,
       CASE estado_oferta
           WHEN 1 THEN 'Disponible'
           WHEN 2 THEN 'Cerrada'
           END                             AS "Estado"
FROM fv_user.oferta
ORDER BY fecha_oferta;


prompt Creando vista del detalle de oferta.;
CREATE OR REPLACE VIEW fv_user.vwObtenerDetalleOfertas AS
SELECT det.id_detalle,
       det.id_oferta,
       pro.id_producto,
       nombre_producto                                                                               AS "Producto",
       det.valor_original,
       to_char(ofe.descuento_oferta, '99')                                                           AS "Descuento aplicado",
       to_char((det.valor_original - ((det.valor_original * ofe.descuento_oferta) / 100)), '999999') AS "Valor oferta"
FROM fv_user.oferta_detalle det
         INNER JOIN fv_user.oferta ofe ON det.id_oferta = ofe.id_oferta
         INNER JOIN fv_user.producto pro ON det.id_producto = pro.id_producto;


prompt Creando vista de pagos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerPagos AS
SELECT pag.id_pago,
       ped.id_pedido,
       cli.id_cliente,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Cliente",
       dat.email_comercial                               AS "email",
       rol.id_rol,
       rol.nombre_rol                                    AS "tipo usuario",
       con.id_condicion,
       con.desc_condicion                                AS "Condicion pago",
       met.id_metpago,
       met.desc_metpago,
       to_char(pag.fecha_pago, 'dd-MM-yyyy')             AS "Fecha pago",
       to_char(pag.fecha_pago, 'HH24:Mi:ss')             AS "Hora pago",
       to_char(pie.valor_neto, '999999999')              AS "Neto",
       to_char(pie.valor_iva, '999999999')               AS "IVA",
       to_char(ped.descuento_solicitado, '99')           AS "Porcentaje descuento",
       to_char(pie.valor_descuento, '999999999')         AS "Descuento",
       to_char(pie.valor_total_descuento, '999999999')   AS "Total a pagar",
       pag.obs_pago                                      AS "Observacion",
       pag.pago_notificado,
       CASE pag.pago_notificado
           WHEN 0 THEN 'Por notificar'
           WHEN 1 THEN 'Enviada'
           END                                           AS "Notificacion"
FROM fv_user.pago pag
         INNER JOIN fv_user.metodo_pago met ON pag.id_metpago = met.id_metpago
         INNER JOIN fv_user.pedido ped ON pag.id_pedido = ped.id_pedido
         INNER JOIN fv_user.condicion_pago con ON ped.id_condicion = con.id_condicion
         INNER JOIN fv_user.cliente cli ON ped.id_cliente = cli.id_cliente
         INNER JOIN fv_user.dato_comercial dat ON cli.id_cliente = dat.id_cliente
         INNER JOIN fv_user.rol_usuario rol ON cli.id_rol = rol.id_rol
         INNER JOIN fv_user.pie_pedido pie ON pag.id_pedido = pie.id_pedido
ORDER BY pag.fecha_pago;


prompt Creando vista para busqueda de email de clientes.;
CREATE OR REPLACE VIEW fv_user.vwBuscarMailCliente AS
SELECT pag.id_pago,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Cliente",
       dat.email_comercial                               as "email"
FROM fv_user.pago pag
         INNER JOIN fv_user.pedido ped ON pag.id_pedido = ped.id_pedido
         INNER JOIN fv_user.cliente cli ON ped.id_cliente = cli.id_cliente
         INNER JOIN fv_user.dato_comercial dat ON cli.id_cliente = dat.id_cliente;

prompt Creando vista de involucrados en el pago.;
CREATE OR REPLACE VIEW fv_user.vwInvolucradosPago AS
SELECT pag.id_pago,
       rpro.id_pedido,
       to_char(pag.fecha_pago, 'dd-MM-yyyy')             AS "Fecha venta",
       rpro.cantidad                                     AS "Cantidad",
       pro.nombre_producto                               AS "Producto",
       rpro.costo_unitario                               AS "Valor unitario",
       (rpro.costo_unitario * rpro.cantidad)             AS "Valor productos",
       cli.id_cliente,
       cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Productor",
       dat.email_comercial                               AS "email"
FROM fv_user.resultado_propuesto rpro
         INNER JOIN fv_user.producto pro ON rpro.id_producto = pro.id_producto
         INNER JOIN fv_user.pedido ped ON rpro.id_pedido = ped.id_pedido
         INNER JOIN fv_user.cliente cli ON pro.id_cliente = cli.id_cliente
         INNER JOIN fv_user.dato_comercial dat ON cli.id_cliente = dat.id_cliente
         INNER JOIN fv_user.pago pag ON ped.id_pedido = pag.id_pedido;



prompt Confirmando cambios.;
COMMIT;