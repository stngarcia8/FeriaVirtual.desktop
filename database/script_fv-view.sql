-- Archivo: script_fv-view.sql
--      Crea las vistas para feria virtual.
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
prompt Creando vistas predefinidas.;


prompt Creando vistas de usuarios del sistema.;
create or replace view fv_user.vwObtenerUsuarios as
select
    emp.id_empleado, usr.id_usuario, rol.id_rol,
    emp.nombre_empleado as "Nombre",
    emp.apellido_empleado as "Apellido",
    usr.username, usr.password,
    usr.email as "Email",
    rol.nombre_rol AS "Rol",
    usr.is_active,
    case usr.is_active
        when 0 then 'Inhabilitado'
        when 1 then 'habilitado'
    end as "Estado",
    to_char(usr.registro, 'dd/MM/yyyy') as "Registrado"
from fv_user.usuario usr
    inner join fv_user.empleado emp on usr.id_usuario=emp.id_usuario
    inner join fv_user.rol_usuario rol on emp.id_rol=rol.id_rol
WHERE emp.id_rol = 1 or emp.id_rol= 2
order by emp.id_rol, emp.apellido_empleado, emp.nombre_empleado;


prompt Creando vista para los logins de usuarios.;
create or replace view fv_user.vwObtenerLogin as
select
    cli.id_cliente, usr.id_usuario, rol.id_rol,
    cli.nombre_cliente as "Nombre",
    cli.apellido_cliente as "Apellido",
    usr.username, usr.password,
    usr.email as "Email",
    rol.nombre_rol AS "Rol",
    usr.is_active,
    case usr.is_active
        when 0 then 'Inhabilitado'
        when 1 then 'habilitado'
    end as "Estado",
    to_char(usr.registro, 'dd/MM/yyyy') as "Registrado"
from fv_user.usuario usr
    inner join fv_user.cliente cli on usr.id_usuario=cli.id_usuario
    inner join fv_user.rol_usuario rol on cli.id_rol=rol.id_rol
order by cli.id_rol, cli.apellido_cliente, cli.nombre_cliente;


prompt Creando vista para logins.;
create or replace view fv_user.vwLogin as
select * from vwObtenerUsuarios
union
select * from vwObtenerLogin;


prompt Creando vistas de clientes.;
create or replace view fv_user.vwObtenerClientes as
select
    cli.id_cliente, usr.id_usuario, cli.id_rol,
    cli.nombre_cliente || ' ' || cli.apellido_cliente as "Nombre cliente",
    cli.nombre_cliente, cli.apellido_cliente,
    cli.dni_cliente AS "DNI",
    usr.username, usr.password,
    usr.email as "Email",
    usr.is_active,
    case usr.is_active
        when 0 then 'Inhabilitado'
        when 1 then 'habilitado'
    end as "Estado",
    rol.nombre_rol AS "Rol",
    to_char(usr.registro, 'dd/MM/yyyy') as "Registrado"
from fv_user.usuario usr
    inner join fv_user.cliente cli on usr.id_usuario=cli.id_usuario
    inner join rol_usuario rol on cli.id_rol=rol.id_rol
WHERE cli.id_rol > 2
order by cli.apellido_cliente, cli.nombre_cliente;


prompt Creando vista para datos comerciales.;
create or replace view fv_user.vwObtenerDatosComerciales as
    select
        id_comercial, id_cliente,
        rsocial_comercial AS "Razon social",
        fantasia_comercial AS "Nombre de fantasia",
        giro_comercial as "Giro comercial",
        email_comercial as "Email",
        dni_comercial as "DNI",
        dir_comercial as "Direccion",
        ciu.id_ciudad, ciu.nombre_ciudad AS "Ciudad",
        pai.id_pais, pai.nombre_pais AS "Pais",
        pai.prefijo_pais AS "Prefijo",  fono_comercial AS "Telefono"
    from dato_comercial dat
        inner join fv_user.ciudad ciu on dat.id_ciudad=ciu.id_ciudad
        inner join fv_user.pais pai on ciu.id_pais=pai.id_pais;


prompt Creando vista para los productos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerProductos AS 
SELECT 
    pro.id_producto, pro.id_cliente, 
    cat.id_categoria, cat.desc_categoria AS "Categoria",
    pro.nombre_producto AS "Producto",
    pro.obs_producto AS "Observacion",
    pro.valor_producto  AS "Valor",
    pro.cantidad_producto AS "Cantidad"
FROM fv_user.producto pro
    INNER JOIN categoria_producto cat ON pro.id_categoria = cat.id_categoria;


prompt Creando vista para los vehiculos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerVehiculos AS
SELECT
    veh.id_vehiculo, veh.id_cliente,
    tip.id_tipo_transporte, tip.desc_tipo_transporte AS "Tipo",
    veh.patente_vehiculo AS "Patente", 
    veh.modelo_vehiculo AS "Modelo",
    veh.capacidad_vehiculo AS "Capacidad", 
    veh.disponibilidad_vehiculo AS "Disponible",
    veh.observacion_vehiculo AS "Observacion"
FROM fv_user.vehiculo veh 
    INNER JOIN fv_user.tipo_transporte tip ON veh.id_tipo_transporte=tip.id_tipo_transporte;


prompt Creando vista para los contratos.;
CREATE OR REPLACE VIEW fv_user.vwObtenerContratos AS
SELECT
    con.id_contrato, con.desc_contrato AS "Descripcion",
    tip.id_tipo_contrato, tip.desc_tipo_contrato AS "Tipo",
    to_char(con.inicio_contrato, 'dd/MM/yyyy') AS "Inicio",
    to_char(con.termino_contrato, 'dd/MM/yyyy') AS "Termino",
    con.esta_vigente,
    CASE con.esta_vigente
        WHEN 1 THEN 'Vigente'
        WHEN 0 THEN 'Caducado'
    END AS "Estado",
    con.comision_contrato AS "Comision",
    con.perfil_contrato,
    to_char(con.fecha_registro, 'dd/MM/yyyy') AS "Fecha registro", 
    (SELECT COUNT(*) FROM fv_user.contrato_cliente WHERE id_contrato = con.id_contrato) AS "Nro Asociados"
FROM fv_user.contrato con
    INNER JOIN fv_user.tipo_contrato tip ON con.id_tipo_contrato=tip.id_tipo_contrato;


prompt Creando vista para los asociados al contrato.;
CREATE OR REPLACE VIEW fv_user.vwAsociadosContrato AS 
SELECT 
    con.id_contrato, cli.id_cliente, 
    cli.nombre_cliente || ' ' || cli.apellido_cliente AS "Cliente",
    con.obs_contrato AS "Observacion contrato",
    con.obs_cliente AS "Observacion cliente",
    con.valor_adicional AS "Valor adicional",
    con.valor_multa AS "Valor multa"
FROM fv_user.contrato_cliente con 
    INNER JOIN fv_user.cliente cli ON con.id_cliente = cli.id_cliente;


prompt Creando vista para pedidos.;
CREATE OR REPLACE VIEW  fv_user.vwObtenerPedidos AS
SELECT
    ped.id_pedido,ped.id_cliente, 
    con.id_condicion, con.desc_condicion AS "Condicion de pago",
    to_char(ped.fecha_pedido, 'dd/MM/yyyy') AS "Fecha pedido",
    ped.descuento_solicitado AS "Descuento solicitado"
FROM fv_user.pedido ped
    INNER JOIN fv_user.condicion_pago con ON ped.id_condicion = con.id_condicion;


prompt Creando vista para el detalle de pedido.;
CREATE OR REPLACE VIEW fv_user.vwObtenerDetallePedido AS
SELECT 
    det.id, det.id_pedido, pro.id_producto,
    pro.nombre_producto AS "Nombre producto",
    det.cantidad AS "Cantidad solicitada"
FROM fv_user.detalle_pedido det
    INNER JOIN fv_user.producto pro ON det.id_producto = pro.id_producto 


prompt Creando vista para obbtener el seguimiento del pedido.;
CREATE OR REPLACE VIEW fv_user.vwObtenerSeguimientoPedido AS 
SELECT 
    seg.id_seguimiento, seg.id_pedido, 
    est.id_estado, est.desc_estado AS "Estado",
    pro.id_proceso, pro.desc_proceso AS "Proceso pedido",
    to_char(seg.fecha_proceso, 'dd/MM/yyyy') AS "Fecha proceso"
FROM fv_user.seguimiento_pedido seg
    INNER JOIN fv_user.estado_pedido est ON seg.id_estado = est.id_estado 
    INNER JOIN fv_user.proceso_pedido pro ON seg.id_proceso = pro.id_proceso;


prompt Confirmando cambios.;
commit;