-- Archivo: script_fv-sproc.sql
--      Crea los procedimientos almacenados para feria virtual.
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
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
prompt;
prompt ----------------------------------------;
prompt Creando procedimientos almacenados.;
prompt ----------------------------------------;
prompt;


prompt Procedimiento almacenado de usuarios.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarUsuario(pIdUsuario varchar2, pUserName VARCHAR2, pPassword VARCHAR2,
                                                     pEmail VARCHAR2,
                                                     pIdEmpleado varchar2, pIdRol number, pNombre varchar2,
                                                     pApellido varchar2)
    IS
BEGIN
    INSERT INTO fv_user.usuario
        (id_usuario, username, password, email, is_active, registro)
    VALUES (pIdUsuario, pUserName, pPassword, pEmail, 1, sysdate);
    insert into fv_user.empleado
        (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
    values (pIdEmpleado, pIdUsuario, pIdRol, pNombre, pApellido);
    COMMIT;
END spAgregarUsuario;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarUsuario(pIdUsuario varchar2, pPassword VARCHAR2, pEmail VARCHAR2,
                                                        pIdEmpleado varchar2, pIdRol number, pNombre varchar2,
                                                        pApellido varchar2)
    IS
BEGIN
    UPDATE fv_user.usuario
    SET password = pPassword,
        email    = pEmail
    WHERE id_usuario = pIdUsuario;

    UPDATE fv_user.empleado
    SET id_rol            = pIdRol,
        nombre_empleado   = pNombre,
        apellido_empleado = pApellido
    WHERE id_empleado = pIdEmpleado;
    COMMIT;
END spActualizarUsuario;
/
CREATE OR REPLACE PROCEDURE fv_user.spHabilitarUsuario(pIdUsuario varchar2, pTipoAccion NUMBER)
    IS
BEGIN
    UPDATE fv_user.usuario
    SET is_active=pTipoAccion
    WHERE id_usuario = pIdUsuario;
    COMMIT;
END spHabilitarUsuario;
/


prompt Procedimientos almacenados para los clientes.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarCliente(pIdUsuario varchar2, pUserName VARCHAR2, pPassword VARCHAR2,
                                                     pEmail VARCHAR2,
                                                     pIdCliente varchar2, pIdRol number, pNombre varchar2,
                                                     pApellido varchar2, pDNI varchar2)
    IS
BEGIN
    INSERT INTO fv_user.usuario
        (id_usuario, username, password, email, is_active, registro)
    VALUES (pIdUsuario, pUserName, pPassword, pEmail, 1, sysdate);
    insert into fv_user.cliente
    (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
    values (pIdCliente, pIdUsuario, pIdRol, pNombre, pApellido, pDNI);
    COMMIT;
END spAgregarCliente;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarCliente(pIdUsuario varchar2, pPassword VARCHAR2, pEmail VARCHAR2,
                                                        pIdCliente varchar2, pIdRol number, pNombre varchar2,
                                                        pApellido varchar2, pDNI varchar2)
    IS
BEGIN
    UPDATE fv_user.usuario
    SET password = pPassword,
        email    = pEmail
    WHERE id_usuario = pIdUsuario;
    UPDATE fv_user.cliente
    SET id_rol           = pIdRol,
        nombre_cliente   = pNombre,
        apellido_cliente = pApellido,
        dni_cliente      = pDNI
    WHERE id_cliente = pIdCliente;
    COMMIT;
END spActualizarCliente;
/
CREATE OR REPLACE PROCEDURE fv_user.spHabilitarCliente(pIdUsuario varchar2, pTipoAccion NUMBER)
    IS
BEGIN
    UPDATE fv_user.usuario
    SET is_active=pTipoAccion
    WHERE id_usuario = pIdUsuario;
    COMMIT;
END spHabilitarCliente;
/


prompt Creando procedimientos almacenados para los datos comerciales de los clientes.;
create or replace procedure fv_user.spAgregarDatosComerciales(pIdComercial varchar2, pIdCliente varchar2,
                                                              pIdCiudad number,
                                                              pRSocial varchar2, pFantasia varchar2, pGiro varchar2,
                                                              pEmail varchar2, pDNI varchar2,
                                                              pDireccion varchar2, pTelefono varchar2) is
begin
    insert into fv_user.dato_comercial
    (id_comercial, id_cliente, id_ciudad,
     rsocial_comercial, fantasia_comercial,
     giro_comercial, email_comercial,
     dni_comercial, dir_comercial, fono_comercial)
    values (pIdComercial, pIdCliente, pIdCiudad,
            pRSocial, pFantasia, pGiro,
            pEmail, pDNI, pDireccion, pTelefono);
    commit;
end spAgregarDatosComerciales;
/
create or replace procedure fv_user.spActualizarDatosComerciales(pIdComercial varchar2, pIdCiudad number,
                                                                 pRSocial varchar2, pFantasia varchar2, pGiro varchar2,
                                                                 pEmail varchar2, pDNI varchar2, pDireccion varchar2,
                                                                 pTelefono varchar2) is
begin
    update fv_user.dato_comercial
    set id_ciudad         = pIdCiudad,
        rsocial_comercial=pRSocial,
        fantasia_comercial=pFantasia,
        giro_comercial=pGiro,
        email_comercial=pEmail,
        dni_comercial=pDNI,
        dir_comercial=pDireccion,
        fono_comercial    = pTelefono
    where id_comercial = pIdComercial;
    commit;
end spActualizarDatosComerciales;
/
create or replace procedure fv_user.spEliminarDatosComerciales(
    pIdComercial varchar2) is
begin
    delete
    from fv_user.dato_comercial
    where id_comercial = pIdComercial;
    commit;
end spEliminarDatosComerciales;
/


prompt Creando procedimientos almacenados para los productos.;
create or replace procedure fv_user.spAgregarProductos(pIdProducto varchar2, pIdCliente varchar2, pIdCategoria NUMBER,
                                                       pNombre varchar2, pObservacion varchar2,
                                                       pValor number, pCantidad number) is
begin
    insert into fv_user.producto
    (id_producto, id_cliente, id_categoria,
     nombre_producto, obs_producto,
     valor_producto, cantidad_producto)
    values (pIdProducto, pIdCliente, pIdCategoria,
            pNombre, pObservacion,
            pValor, pCantidad);
    commit;
end spAgregarProductos;
/
create or replace procedure fv_user.spActualizarProductos(pIdProducto varchar2, pIdCategoria NUMBER,
                                                          pNombre varchar2, pObservacion varchar2,
                                                          pValor number, pCantidad number) is
begin
    update fv_user.producto
    set id_categoria      = pIdCategoria,
        nombre_producto   = pNombre,
        obs_producto      = pObservacion,
        valor_producto    = pValor,
        cantidad_producto = pCantidad
    where id_producto = pIdProducto;
    commit;
end spActualizarProductos;
/
create or replace procedure fv_user.spEliminarProductos(
    pIdProducto varchar2) is
    vCantProductos number default 0;
begin
    delete
    from fv_user.producto
    where id_producto = pIdProducto;
    commit;
end spEliminarProductos;
/

prompt Creando procedimientos almacenados para los vehiculos.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarVehiculos(pIdVehiculo VARCHAR2, pIdCliente VARCHAR2, pIdTipo NUMBER,
                                                       pPatente VARCHAR2, pModelo VARCHAR2, pCapacidad NUMBER,
                                                       pObservacion varchar2) IS
BEGIN
    INSERT INTO fv_user.vehiculo
    (id_vehiculo, id_cliente, id_tipo_transporte,
     patente_vehiculo, modelo_vehiculo, capacidad_vehiculo,
     observacion_vehiculo)
    VALUES (pIdVehiculo, pIdCliente, pIdTipo,
            pPatente, pModelo, pCapacidad,
            pObservacion);
    COMMIT;
END spAgregarVehiculos;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarVehiculos(pIdVehiculo VARCHAR2, pIdTipo NUMBER,
                                                          pPatente VARCHAR2, pModelo VARCHAR2,
                                                          pCapacidad NUMBER, pDisponibilidad NUMBER,
                                                          pObservacion VARCHAR2) IS
BEGIN
    UPDATE fv_user.vehiculo
    SET id_tipo_transporte      = pIdTipo,
        patente_vehiculo        = pPatente,
        modelo_vehiculo         = pModelo,
        capacidad_vehiculo      = pCapacidad,
        disponibilidad_vehiculo = pDisponibilidad,
        observacion_vehiculo    = pObservacion
    WHERE id_vehiculo = pIdVehiculo;
    COMMIT;
END spActualizarVehiculos;
/
CREATE OR REPLACE PROCEDURE fv_user.spEliminarVehiculos(
    pIdVehiculo VARCHAR2) IS
BEGIN
    DELETE
    FROM fv_user.vehiculo
    WHERE id_vehiculo = pIdVehiculo;
    COMMIT;
END spEliminarVehiculos;
/


prompt Creando procedimientos almacenados para los contratos.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarContratos(pIdContrato VARCHAR2, pIdTipo NUMBER,
                                                       pInicio DATE, pTermino DATE,
                                                       pDescripcion VARCHAR2, pComision NUMBER, pPerfil NUMBER) IS
BEGIN
    INSERT INTO fv_user.contrato
    (id_contrato, id_tipo_contrato, inicio_contrato,
     termino_contrato, esta_vigente, desc_contrato,
     comision_contrato, perfil_contrato, fecha_registro)
    VALUES (pIdContrato, pIdTipo, pInicio,
            pTermino, 1, pDescripcion,
            pComision, pPerfil, sysdate);
    COMMIT;
END spAgregarContratos;
/
CREATE OR REPLACE PROCEDURE fv_user.spAgregarDetalleContrato(pIdContrato VARCHAR2, pIdCliente VARCHAR2,
                                                             pObsContrato VARCHAR2,
                                                             pAdicional NUMBER, pMulta NUMBER) IS
BEGIN
    INSERT INTO fv_user.contrato_cliente
    (id, id_contrato, id_cliente, fecha_registro,
     obs_contrato, valor_adicional, valor_multa)
    VALUES (sys_guid(), pIdContrato, pIdCliente, sysdate,
            pObsContrato, pAdicional, pMulta);
    COMMIT;
END spAgregarDetalleContrato;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarContratos(pIdContrato VARCHAR2, pIdTipo NUMBER,
                                                          pInicio DATE, pTermino DATE, pVigente NUMBER,
                                                          pDescripcion VARCHAR2, pComision NUMBER) IS
BEGIN
    UPDATE fv_user.contrato
    SET id_tipo_contrato  = pIdTipo,
        inicio_contrato   = pInicio,
        termino_contrato  = pTermino,
        esta_vigente      = pVigente,
        desc_contrato     = pDescripcion,
        comision_contrato = pComision
    WHERE id_contrato = pIdContrato;
    COMMIT;
END spActualizarContratos;
/
CREATE OR REPLACE PROCEDURE fv_user.spEliminarContratos(
    pIdContrato VARCHAR2) IS
BEGIN
    DELETE
    FROM fv_user.contrato
    WHERE id_contrato = pIdContrato;
    COMMIT;
END spEliminarContratos;
/
CREATE OR REPLACE TRIGGER fv_user.trLimpiarDetalleContrato
    AFTER UPDATE
    ON fv_user.contrato
    FOR EACH ROW
BEGIN
    DELETE
    FROM fv_user.contrato_cliente
    WHERE id_contrato = :old.id_contrato;
END;
/
CREATE OR REPLACE PROCEDURE fv_user.spAceptarRechazarContrato(pIdContrato VARCHAR2, pIdCliente VARCHAR2,
                                                              pEstado NUMBER, pObservacion VARCHAR2) IS
BEGIN
    UPDATE fv_user.contrato_cliente
    SET estado_aceptacion = pEstado,
        fecha_aceptacion  = SYSDATE,
        obs_cliente       = pObservacion
    WHERE id_contrato = pIdContrato
      AND id_cliente = pIdCliente;
    COMMIT;
END spAceptarRechazarContrato;
/


prompt Procedimientos almacenados para pedidos.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarPedido(pIdPedido VARCHAR2, pIdCliente VARCHAR2,
                                                    pIdCondicion NUMBER, pDescuento NUMBER,
                                                    pObservacion varchar2, pGuid varchar2) IS
BEGIN
    --insertando cabecera del pedido
    INSERT INTO fv_user.pedido
    (id_pedido, id_cliente, id_condicion,
     fecha_pedido, descuento_solicitado, obs_pedido)
    VALUES (pIdPedido, pIdCliente, pIdCondicion,
            sysdate, pDescuento, pObservacion);
    -- agregando el seguimiento.
    INSERT INTO fv_user.seguimiento_pedido
        (id_seguimiento, id_pedido)
    VALUES (pGuid, pIdPedido);
    COMMIT;
END spAgregarPedido;
/
CREATE OR REPLACE PROCEDURE fv_user.spAgregarDetallePedido(pGuid varchar2, pIdPedido VARCHAR, pProducto VARCHAR,
                                                           pCantidad NUMBER) IS
BEGIN
    INSERT INTO fv_user.detalle_pedido
        (id, id_pedido, nombre_producto, cantidad)
    VALUES (pGuid, pIdPedido, pProducto, pCantidad);
    COMMIT;
END spAgregarDetallePedido;
/
CREATE OR REPLACE TRIGGER fv_user.trLimpiarDetallePedido
    AFTER UPDATE
    ON fv_user.pedido
    FOR EACH ROW
BEGIN
    DELETE
    FROM fv_user.detalle_pedido
    WHERE id_pedido = :old.id_pedido;
END;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarPedido(pIdPedido VARCHAR2, pIdCondicion NUMBER, pDescuento NUMBER,
                                                       pObservacion varchar2) IS
BEGIN
    --Actualizando cabecera del pedido
    UPDATE fv_user.pedido
    SET id_condicion        = pIdCondicion,
        descuento_solicitado= pDescuento,
        obs_pedido          = pObservacion
    WHERE id_pedido = pIdPedido;
    COMMIT;
END spActualizarPedido;
/
CREATE OR REPLACE PROCEDURE fv_user.spEliminarPedido(
    pIdPedido VARCHAR2) IS
BEGIN
    DELETE FROM fv_user.pedido 
    WHERE id_pedido = pIdPedido;
    COMMIT;
END spEliminarPedido;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarEstadoPedido
(
    pIdPedido VARCHAR2, pEstado NUMBER,
    pProceso NUMBER, pGuid varchar2
) IS
BEGIN
    INSERT INTO fv_user.seguimiento_pedido
        (id_seguimiento, id_pedido, id_estado, id_proceso)
    VALUES (pGuid, pIdPedido, pEstado, pProceso);
    COMMIT;
END spActualizarEstadoPedido;
/


prompt Creando procedimiento para ejecucion de paquete de productos.;
CREATE OR REPLACE PROCEDURE fv_user.spGenerarPropuestaProductos(
    idped pedido.id_pedido%TYPE) IS
BEGIN
    fv_user.pkg_Total_productos.sp_nombre_producto(idped);
    fv_user.pkg_Total_productos.sp_total_productos(idped);
    COMMIT;
END spGenerarPropuestaProductos;
/
/


prompt Creando procedimiento para aceptar propuesta de productos.;
CREATE OR REPLACE PROCEDURE fv_user.spAceptarPropuestaProductos(
    pIdPedido VARCHAR2, pGuid VARCHAR2) IS
BEGIN
    fv_user.pkg_Total_productos.sp_actualiza(pIdPedido);
    fv_user.spActualizarEstadoPedido(
        pIdPedido, 2, 2, pGuid);
        COMMIT;
END spAceptarPropuestaProductos;
/


prompt Creando procedimientos almacenados para subastas.;
create or replace procedure fv_user.spAgregarSubasta(
    pIdSubasta varchar2, pIdPedido varchar2, 
    pValor NUMBER, pPeso number, pFechaLimite date,
    pObservacion varchar2) is
begin
    insert into fv_user.subasta 
        (id_subasta, id_pedido,
        valor_propuesto, peso_comprometido, 
        fecha_limite, observacion_subasta, estado_subasta)
    values 
        (pIdSubasta, pIdPedido, 
        pValor, pPeso,
        pFechaLimite, pObservacion, 1);
    commit;
end  spAgregarSubasta;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarSubasta(
    pIdSubasta VARCHAR2, pValor NUMBER, pPeso NUMBER, 
    pFechaLimite DATE, pObservacion VARCHAR2) IS
BEGIN
    UPDATE fv_user.subasta 
    SET valor_propuesto = pValor, 
        peso_comprometido = pPeso, 
        fecha_subasta = sysdate,
        fecha_limite = pFechaLimite, 
        observacion_subasta = pObservacion
    WHERE id_subasta = pIdSubasta;
    COMMIT;
END  spActualizarSubasta;
/
CREATE OR REPLACE PROCEDURE fv_user.spCambiarEstadoSubasta(
    pIdSubasta VARCHAR2, pEstado NUMBER) IS
BEGIN
    UPDATE fv_user.subasta 
    SET estado_subasta = pEstado 
    WHERE id_subasta = pIdSubasta;
    COMMIT;
END spCambiarEstadoSubasta;
/



prompt Confirmando cambios.;
commit;