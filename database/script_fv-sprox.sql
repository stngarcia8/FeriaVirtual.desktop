-- Archivo: script_fv-sproc.sql
--      Crea los procedimientos almacenados para feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
ALTER SESSION SET NLS_LANGUAGE= 'SPANISH' NLS_TERRITORY= 'Spain' NLS_CURRENCY= '$' NLS_ISO_CURRENCY= 'AMERICA' NLS_NUMERIC_CHARACTERS= '.,' NLS_CALENDAR= 'GREGORIAN' NLS_DATE_FORMAT= 'DD-MON-RR' NLS_DATE_LANGUAGE= 'SPANISH' NLS_SORT= 'BINARY';


prompt;
prompt Creando procedimientos almacenados.;
prompt ----------------------------------------;


prompt Procedimiento almacenado de usuarios.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarUsuario(pIdUsuario varchar2,
                             pUserName VARCHAR2,
                             pPassword VARCHAR2,
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

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarUsuario(pIdUsuario varchar2,
                                pPassword VARCHAR2,
                                pEmail VARCHAR2,
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

CREATE OR REPLACE PROCEDURE
    fv_user.spHabilitarUsuario(pIdUsuario varchar2,
                               pTipoAccion NUMBER)
    IS
BEGIN
    UPDATE fv_user.usuario
    SET is_active=pTipoAccion
    WHERE id_usuario = pIdUsuario;
    COMMIT;
END spHabilitarUsuario;
/


prompt Procedimientos almacenados para los clientes.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarCliente(pIdUsuario varchar2,
                             pUserName VARCHAR2,
                             pPassword VARCHAR2,
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

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarCliente(pIdUsuario varchar2,
                                pPassword VARCHAR2,
                                pEmail VARCHAR2,
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

CREATE OR REPLACE PROCEDURE
    fv_user.spHabilitarCliente(pIdUsuario varchar2,
                               pTipoAccion NUMBER)
    IS
BEGIN
    UPDATE fv_user.usuario
    SET is_active=pTipoAccion
    WHERE id_usuario = pIdUsuario;
    COMMIT;
END spHabilitarCliente;
/


prompt Creando procedimientos almacenados para los datos comerciales de los clientes.;
create or replace procedure
    fv_user.spAgregarDatosComerciales(pIdComercial varchar2,
                                      pIdCliente varchar2,
                                      pIdCiudad number,
                                      pRSocial varchar2,
                                      pFantasia varchar2,
                                      pGiro varchar2,
                                      pEmail varchar2,
                                      pDNI varchar2,
                                      pDireccion varchar2,
                                      pTelefono varchar2)
    is
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

create or replace procedure
    fv_user.spActualizarDatosComerciales(pIdComercial varchar2,
                                         pIdCiudad number,
                                         pRSocial varchar2,
                                         pFantasia varchar2,
                                         pGiro varchar2,
                                         pEmail varchar2,
                                         pDNI varchar2,
                                         pDireccion varchar2,
                                         pTelefono varchar2)
    is
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

create or replace procedure
    fv_user.spEliminarDatosComerciales(
    pIdComercial varchar2)
    is
begin
    delete
    from fv_user.dato_comercial
    where id_comercial = pIdComercial;
    commit;
end spEliminarDatosComerciales;
/


prompt Creando procedimientos almacenados para los productos.;
create or replace procedure
    fv_user.spAgregarProductos(pIdProducto varchar2,
                               pIdCliente varchar2,
                               pIdCategoria NUMBER,
                               pNombre varchar2, pObservacion varchar2,
                               pValor number, pCantidad number)
    is
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

create or replace procedure
    fv_user.spActualizarProductos(pIdProducto varchar2,
                                  pIdCategoria NUMBER,
                                  pNombre varchar2,
                                  pObservacion varchar2,
                                  pValor number,
                                  pCantidad number)
    is
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

create or replace procedure
    fv_user.spEliminarProductos(
    pIdProducto varchar2)
    is
    vCantProductos number default 0;
begin
    delete
    from fv_user.producto
    where id_producto = pIdProducto;
    commit;
end spEliminarProductos;
/


prompt Creando procedimientos almacenados para los vehiculos.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarVehiculos(pIdVehiculo VARCHAR2,
                               pIdCliente VARCHAR2,
                               pIdTipo NUMBER,
                               pPatente VARCHAR2,
                               pModelo VARCHAR2,
                               pCapacidad NUMBER,
                               pObservacion varchar2)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarVehiculos(pIdVehiculo VARCHAR2,
                                  pIdTipo NUMBER,
                                  pPatente VARCHAR2,
                                  pModelo VARCHAR2,
                                  pCapacidad NUMBER,
                                  pDisponibilidad NUMBER,
                                  pObservacion VARCHAR2)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spEliminarVehiculos(
    pIdVehiculo VARCHAR2)
    IS
BEGIN
    DELETE
    FROM fv_user.vehiculo
    WHERE id_vehiculo = pIdVehiculo;
    COMMIT;
END spEliminarVehiculos;
/


prompt Creando procedimientos almacenados para los contratos.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarContratos(pIdContrato VARCHAR2,
                               pIdTipo NUMBER,
                               pInicio DATE,
                               pTermino DATE,
                               pDescripcion VARCHAR2,
                               pComision NUMBER,
                               pPerfil NUMBER)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarDetalleContrato(pIdContrato VARCHAR2,
                                     pIdCliente VARCHAR2,
                                     pObsContrato VARCHAR2,
                                     pAdicional NUMBER,
                                     pMulta NUMBER)
    IS
BEGIN
    INSERT INTO fv_user.contrato_cliente
    (id, id_contrato, id_cliente, fecha_registro,
     obs_contrato, valor_adicional, valor_multa)
    VALUES (sys_guid(), pIdContrato, pIdCliente, sysdate,
            pObsContrato, pAdicional, pMulta);
    COMMIT;
END spAgregarDetalleContrato;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarContratos(pIdContrato VARCHAR2,
                                  pIdTipo NUMBER,
                                  pInicio DATE,
                                  pTermino DATE,
                                  pVigente NUMBER,
                                  pDescripcion VARCHAR2,
                                  pComision NUMBER)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spEliminarContratos(
    pIdContrato VARCHAR2)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spAceptarRechazarContrato(pIdContrato VARCHAR2,
                                      pIdCliente VARCHAR2,
                                      pEstado NUMBER,
                                      pObservacion VARCHAR2)
    IS
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
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarPedido(pIdPedido VARCHAR2,
                            pIdCliente VARCHAR2,
                            pIdCondicion NUMBER,
                            pDescuento NUMBER,
                            pObservacion varchar2,
                            pGuid varchar2)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarDetallePedido(pGuid varchar2,
                                   pIdPedido VARCHAR,
                                   pProducto VARCHAR,
                                   pCantidad NUMBER)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarPedido(pIdPedido VARCHAR2,
                               pIdCondicion NUMBER,
                               pDescuento NUMBER,
                               pObservacion varchar2)
    IS
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

CREATE OR REPLACE PROCEDURE
    fv_user.spEliminarPedido(
    pIdPedido VARCHAR2)
    IS
BEGIN
    DELETE
    FROM fv_user.pedido
    WHERE id_pedido = pIdPedido;
    COMMIT;
END spEliminarPedido;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarEstadoPedido(pIdPedido VARCHAR2,
                                     pEstado NUMBER,
                                     pGuid varchar2)
    IS
BEGIN
    INSERT INTO fv_user.seguimiento_pedido
        (id_seguimiento, id_pedido, id_estado)
    VALUES (pGuid, pIdPedido, pEstado);
    COMMIT;
END spActualizarEstadoPedido;
/
CREATE OR REPLACE PROCEDURE
    fv_user.spRechazarPedido(pIdCierre VARCHAR2,
                             pIdPedido VARCHAR2,
                             pTipo NUMBER,
                             pObservacion VARCHAR2) IS
BEGIN
    INSERT INTO fv_user.cierre_pedido
        (id_cierre, id_pedido, id_tipo_cierre, fecha_cierre, obs_cierre)
    VALUES (pIdCierre, pIdPedido, pTipo, sysdate, pObservacion);
    COMMIT;
END spRechazarPedido;
/



prompt Creando procedimiento para ejecucion de paquete de productos.;
CREATE OR REPLACE PROCEDURE
    fv_user.spGenerarPropuestaProductos(
    idped pedido.id_pedido%TYPE)
    IS
BEGIN
    fv_user.pkg_Total_productos.sp_nombre_producto(idped);
    fv_user.pkg_Total_productos.sp_total_productos(idped);
    COMMIT;
END spGenerarPropuestaProductos;
/

prompt Creando procedimiento para aceptar propuesta de productos.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAceptarPropuestaProductos(pIdPedido VARCHAR2,
                                        pGuid VARCHAR2)
    IS
BEGIN
    fv_user.pkg_Total_productos.sp_actualiza(pIdPedido);
    fv_user.spActualizarEstadoPedido(
            pIdPedido, 2, pGuid);
    COMMIT;
END spAceptarPropuestaProductos;
/


prompt Creando procedimientos almacenados para subastas.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarSubasta(pIdSubasta VARCHAR2,
                             pIdPedido VARCHAR2,
                             pPorcentaje NUMBER,
                             pValor NUMBER,
                             pPeso NUMBER,
                             pFechaLimite DATE,
                             pObservacion VARCHAR2,
                             pGuid VARCHAR2)
    IS
BEGIN
    INSERT INTO fv_user.subasta
    (id_subasta, id_pedido, valor_porcentaje,
     valor_propuesto, peso_comprometido,
     fecha_limite, observacion_subasta, estado_subasta)
    VALUES (pIdSubasta, pIdPedido, pPorcentaje,
            pValor, pPeso,
            pFechaLimite, pObservacion, 1);
    fv_user.spActualizarEstadoPedido(pIdPedido, 3, pGuid);
    COMMIT;
END spAgregarSubasta;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarSubasta(pIdPedido VARCHAR2,
                                pPorcentaje number,
                                pValor NUMBER,
                                pPeso NUMBER,
                                pFechaLimite DATE,
                                pObservacion VARCHAR2)
    IS
BEGIN
    UPDATE fv_user.subasta
    SET valor_porcentaje    = pPorcentaje,
        valor_propuesto     = pValor,
        peso_comprometido   = pPeso,
        fecha_subasta       = sysdate,
        fecha_limite        = pFechaLimite,
        observacion_subasta = pObservacion
    WHERE id_pedido = pIdPedido;
    COMMIT;
END spActualizarSubasta;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spCambiarEstadoSubasta(pIdSubasta VARCHAR2,
                                   pEstado NUMBER)
    IS
BEGIN
    UPDATE fv_user.subasta
    SET estado_subasta = pEstado
    WHERE id_subasta = pIdSubasta;
    COMMIT;
END spCambiarEstadoSubasta;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spEliminarSubasta(pIdPedido VARCHAR2)
    IS
BEGIN
    DELETE
    FROM fv_user.subasta
    WHERE id_pedido = pIdPedido;
    DELETE
    FROM fv_user.seguimiento_pedido
    WHERE id_pedido = pIdPedido
      AND id_estado = 3;
    COMMIT;
END spEliminarSubasta;
/



CREATE OR REPLACE PROCEDURE
    fv_user.spCerrarSubasta(pIdSubasta VARCHAR2,
                            pIdPedido VARCHAR2,
                            pGuid VARCHAR2)
AS
    vIdCliente      fv_user.subasta.id_cliente%TYPE;
    vFechaPropuesta fv_user.subasta.fecha_puja%TYPE;
    vValorPropuesto fv_user.subasta.valor_puja%TYPE;
BEGIN
    SELECT id_cliente, fecha_propuesta, valor_propuest
    INTO vIdCliente, vFechaPropuesta, vValorPropuesto
    FROM fv_user.resultado_subasta
    WHERE id_subasta = pIdSubasta
    GROUP BY id_cliente, fecha_propuesta, valor_propuest
    HAVING valor_propuest =
           (SELECT MIN(valor_propuest) FROM fv_user.resultado_subasta WHERE id_subasta = pIdSubasta)
    order by fecha_propuesta FETCH FIRST ROW ONLY;

    UPDATE fv_user.subasta
    SET estado_subasta = 3,
        id_cliente     = vIdCliente,
        valor_puja     = vValorPropuesto,
        fecha_puja     = vFechaPropuesta
    WHERE id_subasta = pIdSubasta;

    fv_user.spActualizarEstadoPedido(
            pIdPedido, 4, pGuid);
    COMMIT;
END spCerrarSubasta;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spGrabarPropuestaSubasta(pIdResultado VARCHAR2,
                                     pIdSubasta VARCHAR2,
                                     pIdCliente VARCHAR2,
                                     pValor NUMBER) IS
BEGIN
    INSERT INTO fv_user.resultado_subasta
        (id_resultado, id_subasta, id_cliente, valor_propuest, fecha_propuesta)
    VALUES (pIdResultado, pIdSubasta, pIdCliente, pValor, sysdate);
    COMMIT;
END spGrabarPropuestaSubasta;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spQuitarPujasSubasta(pIdSubasta VARCHAR2,
                                 pIdPedido VARCHAR2)
    IS
BEGIN
    DELETE
    FROM fv_user.resultado_subasta
    WHERE id_subasta = pIdSubasta;

    UPDATE fv_user.subasta
    SET estado_subasta = 1,
        fecha_subasta  = sysdate,
        fecha_limite   = sysdate
    WHERE id_subasta = pIdSubasta;

    DELETE
    FROM fv_user.seguimiento_pedido
    WHERE id_pedido = pIdPedido
      AND id_estado > 3;
    COMMIT;
END spQuitarPujasSubasta;
/


prompt Creando procedimientos almacenados para ordenes de despacho.;
CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarOrdenDespacho(pIdOrden VARCHAR2,
                                   pIdPedido VARCHAR2,
                                   pFechaRetiro DATE,
                                   pObservacion VARCHAR2,
                                   pIdCliente VARCHAR2,
                                   pIdSeguro NUMBER,
                                   pCosto NUMBER,
                                   pGuid varchar2)
    IS
BEGIN
    -- Insertando cabecera de orden de despacho.
    INSERT INTO fv_user.orden_despacho
        (id_orden, id_pedido, fecha_retiro, obs_orden)
    VALUES (pIdOrden, pIdPedido, pFechaRetiro, pObservacion);

    -- Insertando datos de envio.
    INSERT INTO fv_user.envio
    (id_envio, id_pedido, id_seguro, id_cliente,
     estado_envio, fecha_envio, obs_envio,
     costo_envio)
    VALUES (pIdOrden, pIdPedido, pIdSeguro, pIdCliente,
            1, sysdate, pObservacion,
            pCosto);
    fv_user.spActualizarEstadoPedido(
            pIdPedido, 5, pGuid);
    COMMIT;
END spAgregarOrdenDespacho;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarDetalleDespacho(pId VARCHAR2,
                                     pIdOrden VARCHAR2,
                                     pProducto VARCHAR2,
                                     pValor NUMBER,
                                     pCantidad NUMBER,
                                     pTotal NUMBER)
    IS
BEGIN
    INSERT INTO fv_user.orden_detalle
        (id, id_orden, producto, valor, cantidad, total)
    VALUES (pId, pIdOrden, pProducto, pValor, pCantidad, pTotal);
    COMMIT;
END spAgregarDetalleDespacho;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarOrdenDespacho(pIdOrden VARCHAR2,
                                      pFechaRetiro DATE,
                                      pObservacion VARCHAR2,
                                      pEstado NUMBER,
                                      pIdSeguro NUMBER,
                                      pCosto NUMBER)
    IS
BEGIN
    -- actualizando cabecera de orden de despacho.
    UPDATE fv_user.orden_despacho
    SET fecha_retiro = pFechaRetiro,
        obs_orden    = pObservacion
    WHERE id_orden = pIdOrden;

    -- actualizando datos de envio.
    UPDATE fv_user.envio
    SET id_seguro    = pIdSeguro,
        estado_envio = pEstado,
        obs_envio    = pObservacion,
        costo_envio  = pCosto
    WHERE id_envio = pIdOrden;
    COMMIT;
END spActualizarOrdenDespacho;
/

CREATE OR REPLACE TRIGGER fv_user.trLimpiarDetalleDespacho
    AFTER UPDATE
    ON fv_user.orden_despacho
    FOR EACH ROW
BEGIN
    DELETE
    FROM fv_user.orden_detalle
    WHERE id_orden = :old.id_orden;
END;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spAceptarRechazarDespacho(pIdOrden VARCHAR2,
                                      pEstado NUMBER,
                                      pObservacion VARCHAR2,
                                      pGuid VARCHAR2)
AS
    vIdPedido fv_user.pedido.id_pedido%TYPE;
BEGIN
    SELECT id_pedido
    INTO vIdPedido
    FROM fv_user.orden_despacho
    WHERE id_orden = pIdOrden;

    UPDATE fv_user.envio
    SET estado_envio = pEstado,
        obs_envio    = pObservacion
    WHERE id_envio = pIdOrden;

    fv_user.spActualizarEstadoPedido(
            vIdPedido, pEstado, pGuid);
    COMMIT;
END spAceptarRechazarDespacho;
/


prompt Creando procedimientos para las ofertas de productos.;
CREATE OR REPLACE PROCEDURE
    fv_user.spCrearofertas(pIdOferta VARCHAR2,
                           pDescripcion VARCHAR2,
                           pDescuento NUMBER,
                           pTipo NUMBER)
    IS
BEGIN
    INSERT INTO fv_user.oferta
        (id_oferta, desc_oferta, descuento_oferta, estado_oferta)
    VALUES (pIdOferta, pDescripcion, pDescuento, pTipo);
    COMMIT;
END spCrearofertas;
/

CREATE OR REPLACE PROCEDURE
    fv_user.spAgregarDetalleOferta(pIdDetalle VARCHAR2,
                                   pIdOferta VARCHAR2,
                                   pIdProducto VARCHAR2,
                                   pValor NUMBER)
    IS
BEGIN
    INSERT INTO fv_user.oferta_detalle
        (id_detalle, id_oferta, id_producto, valor_original)
    VALUES (pIdDetalle, pIdOferta, pIdProducto, pValor);
    COMMIT;
END spAgregarDetalleOferta;
/
CREATE OR REPLACE PROCEDURE
    fv_user.spActualizarOfertas(pIdOferta VARCHAR2,
                                pDescripcion VARCHAR2,
                                pDescuento NUMBER,
                                pTipo NUMBER)
    IS
BEGIN
    UPDATE fv_user.oferta
    SET desc_oferta      = pDescripcion,
        descuento_oferta = pDescuento,
        estado_oferta    = pTipo,
        fecha_oferta     = sysdate
    WHERE id_oferta = pIdOferta;
    COMMIT;
END spActualizarOfertas;
/
CREATE OR REPLACE PROCEDURE
    fv_user.spCambiarEstadoOferta(pIdOferta VARCHAR2,
                                  pEstado NUMBER)
    IS
BEGIN
    UPDATE fv_user.oferta
    SET estado_oferta = pEstado
    WHERE id_oferta = pIdOferta;
    COMMIT;
END spCambiarEstadoOferta;
/
CREATE OR REPLACE PROCEDURE
    fv_user.spEliminarOferta(pIdOferta VARCHAR2) IS
BEGIN
    DELETE
    FROM fv_user.oferta
    WHERE id_oferta = pIdOferta;
    COMMIT;
END spEliminarOferta;
/
CREATE OR REPLACE TRIGGER fv_user.trLimpiarDetalleOferta
    AFTER UPDATE
    ON fv_user.oferta
    FOR EACH ROW
BEGIN
    DELETE
    FROM fv_user.oferta_detalle
    WHERE id_oferta = :old.id_oferta;
END;
/



prompt Creando procedimientos almacenados para pagos.;
CREATE OR REPLACE PROCEDURE
    fv_user.spRegistrarPago(pIdPago VARCHAR2,
                            pIdMetodoPago NUMBER,
                            pIdPedido VARCHAR2,
                            pMonto NUMBER,
                            pObsPago VARCHAR2) IS
BEGIN
    INSERT INTO fv_user.pago
        (id_pago, id_metpago, id_pedido, fecha_pago, monto_pago, obs_pago)
    VALUES (pIdPago, pIdMetodoPago, pIdPedido, sysdate, pMonto, pObsPago);

    INSERT INTO fv_user.cierre_pedido
        (id_cierre, id_pedido, id_tipo_cierre, fecha_cierre, obs_cierre)
    VALUES (pIdPago, pIdPedido, 7, sysdate, pObsPago);
    COMMIT;
END spRegistrarPago;
/



prompt Confirmando cambios.;
commit;