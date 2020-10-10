-- Archivo: script_fv.sql
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

clear screen;
prompt Creando tablespace y asignando roles A usuario.;

prompt Eliminando usuario y tablespace.;
DROP USER fv_user CASCADE;
DROP tablespace fv_env INCLUDING CONTENTS AND DATAFILES CASCADE CONSTRAINTS;

prompt Creando tablespace y usuario para feria virtual.;
CREATE TABLESPACE fv_env DATAFILE 'fv_env.dbf' SIZE 500M autoextend ON;
CREATE USER fv_user IDENTIFIED BY fv_pwd DEFAULT TABLESPACE fv_env temporary tablespace temp;

prompt Asignando los privilegios al usuario.;
GRANT CREATE SESSION TO fv_user;
GRANT RESOURCE TO fv_user;
GRANT CREATE VIEW TO fv_user;
-- REVOKE UNLIMITED TABLESPACE FROM fvirtual_user;

prompt Definiendo el tablespace que trabajara el usuario.;
ALTER USER fv_user QUOTA UNLIMITED ON fv_env;

prompt Estableciendo cambios.;
COMMIT;



prompt Creando tablas de la base de datos.;
prompt Creando tabla de cierre de pedidos.;
CREATE TABLE fv_user.cierre_pedido (
    id_cierre       VARCHAR2(40) NOT NULL,
    id_pedido      VARCHAR2(40) NOT NULL,
    id_tipo_cierre  NUMBER(2) NOT NULL,
    fecha_cierre    DATE,
    obs_cierre      VARCHAR2(100),
    CONSTRAINT cierre_pedido_pk PRIMARY KEY ( id_cierre )
) TABLESPACE fv_env;

prompt Creando tabla de ciudades.;
CREATE TABLE fv_user.ciudad (
    id_ciudad  NUMBER(5) NOT NULL,
    id_pais      number(5) NOT NULL,
    nombre_ciudad  VARCHAR2(100) NOT NULL,
    constraint ciudad_pk primary key (id_ciudad)
) tablespace fv_env;

prompt Creando tabla cliente.;
CREATE TABLE fv_user.cliente (
    id_cliente      VARCHAR2(40) NOT NULL,
    id_usuario      VARCHAR2(40) NOT NULL,
    id_rol          NUMBER(2) NOT NULL,
    nombre_cliente  VARCHAR2(50) NOT NULL,
    apellido_cliente    VARCHAR2(50) NOT NULL,
    dni_cliente     VARCHAR2(20) NOT NULL,
    constraint cliente_pk primary key (id_cliente)
) tablespace fv_env;

prompt Creando tabla condiciones de pago.;;
CREATE TABLE fv_user.condicion_pago(
    id_condicion NUMBER(2) NOT NULL,
    desc_condicion VARCHAR(25) NOT NULL,
    CONSTRAINT condicion_pago_pk PRIMARY KEY (id_condicion)
) TABLESPACE fv_env;


prompt Creando tabla contrato.;
CREATE TABLE fv_user.contrato (
    id_contrato        VARCHAR2(40) NOT NULL,
    id_tipo_contrato    number(2) not null,
    inicio_contrato    DATE NOT NULL,
    termino_contrato   DATE,
    esta_vigente       NUMBER(1) NOT NULL,
    desc_contrato      VARCHAR2(100),
    comision_contrato  NUMBER(5,2) default 0  NOT NULL,
    perfil_contrato     number(2) not null,
    fecha_registro      date not null,
    constraint contrato_pk primary key (id_contrato)
) tablespace fv_env;

prompt Creando tabla contrato_cliente.;
CREATE TABLE fv_user.contrato_cliente (
    id                  VARCHAR2(40) NOT NULL,
    id_contrato         VARCHAR2(40) NOT NULL,
    id_cliente          VARCHAR2(40) NOT NULL,
    fecha_aceptacion   date,
    fecha_registro     date,
    obs_contrato        varchar2(100),
    obs_cliente        varchar2(100),
    valor_adicional    number(5,2) default 0 not null,
    valor_multa         number(5,2) default 0 not null,
    constraint contrato_cliente_pk primary key (id)
) tablespace fv_env;

prompt Creando tabla dato_comercial.;
CREATE TABLE fv_user.dato_comercial (
    id_comercial        VARCHAR2(40) NOT NULL,
    id_cliente          VARCHAR2(40) NOT NULL,
	id_ciudad          NUMBER(5) NOT NULL,
    rsocial_comercial   VARCHAR2(100) NOT NULL,
    fantasia_comercial  VARCHAR2(100),
    giro_comercial      VARCHAR2(100) NOT NULL,
    email_comercial     VARCHAR2(254),
    dni_comercial       VARCHAR2(20) NOT NULL,
    dir_comercial       VARCHAR2(100) NOT NULL,
    fono_comercial      varchar(30),
    constraint dato_comercial_pk primary key (id_comercial)
) tablespace fv_env;

prompt Creando tabla detalle_pedido.;
CREATE TABLE fv_user.detalle_pedido (
    id           VARCHAR2(40) NOT NULL,
    id_pedido    VARCHAR2(40) NOT NULL,
    id_producto  VARCHAR2(40) NOT NULL,
    cantidad     NUMBER(5) NOT NULL,
    constraint detalle_pedido_pk primary key (id)
) tablespace fv_env;

prompt Creando tabla empleado.;
CREATE TABLE fv_user.empleado(
    id_empleado      VARCHAR2(40) NOT NULL,
    id_usuario      VARCHAR2(40) NOT NULL,
    id_rol          NUMBER(2) NOT NULL,
    nombre_empleado  VARCHAR2(50) NOT NULL,
    apellido_empleado    VARCHAR2(50) NOT NULL,
    constraint empleado_pk primary key (id_empleado)
) tablespace fv_env;

prompt Creando tabla envio.;
CREATE TABLE fv_user.envio (
    id_envio        VARCHAR2(40) NOT NULL,
    id_pedido       VARCHAR2(40) NOT NULL,
    id_seguro       VARCHAR2(40) NOT NULL,
    id_cliente      VARCHAR2(40) NOT NULL,
    estado_envio    NUMBER(1) NOT NULL,
    fecha_envio     DATE NOT NULL,
    fecha_embarque  DATE NOT NULL,
    obs_envio       VARCHAR2(100) NOT NULL,
    costo_envio     NUMBER(9, 2) NOT NULL,
    costo_seguro    NUMBER(9, 2) NOT NULL,
    CONSTRAINT envio_pk PRIMARY KEY (id_envio)
) TABLESPACE fv_env;

prompt Creando tabla estado_pedido.;
CREATE TABLE fv_user.estado_pedido(
    id_estado   NUMBER(1) NOT NULL,
    desc_estado VARCHAR2(15) NOT NULL,
    CONSTRAINT estado_pedido_pk PRIMARY KEY (id_estado) 
) TABLESPACE fv_env;

prompt Creando tabla metodo_pago.;
CREATE TABLE fv_user.metodo_pago (
    id_metpago    NUMBER(2) NOT NULL,
    desc_metpago  VARCHAR2(30) NOT NULL,
    constraint metodo_pago_pk primary key (id_metpago)
) tablespace fv_env;

prompt Creando tabla pago.;
CREATE TABLE fv_user.pago (
    id_pago     VARCHAR2(40) NOT NULL,
    id_metpago  NUMBER(2) NOT NULL,
    id_pedido   VARCHAR2(40) NOT NULL,
    fecha_pago  DATE NOT NULL,
    monto_pago  NUMBER(9, 2) NOT NULL,
    descuento_pago number(4,2) not null,
    obs_pago    VARCHAR2(100) NOT NULL,
    constraint pago_pk primary key (id_pago)
) tablespace fv_env;

prompt Creando tabla pais.;
CREATE TABLE fv_user.pais (
    id_pais      number(5) NOT NULL,
    nombre_pais   VARCHAR2(100),
    prefijo_pais  VARCHAR2(6),
    constraint pais_pk primary key (id_pais)
) tablespace fv_env;

prompt Creando tabla pedido.;
CREATE TABLE fv_user.pedido (
    id_pedido      VARCHAR2(40) NOT NULL,
    id_cliente     VARCHAR2(40) NOT NULL,
    fecha_pedido   DATE NOT NULL,
    descuento_solicitado number(2) default 0 not null,
    constraint pedido_pk primary key (id_pedido)
) tablespace fv_env;

prompt Creando tabla proceso_pedido.;
CREATE TABLE fv_user.proceso_pedido(
    id_proceso      NUMBER(1) NOT NULL,
    desc_proceso    VARCHAR2(15) NOT NULL,
    CONSTRAINT proceso_pedido_pk PRIMARY KEY (id_proceso) 
) TABLESPACE fv_env;

prompt Creando tabla producto.;
CREATE TABLE fv_user.producto (
    id_producto        VARCHAR2(40) NOT NULL,
    id_cliente         VARCHAR2(40) NOT NULL,
    nombre_producto    VARCHAR2(50) NOT NULL,
    obs_producto       VARCHAR2(100),
    valor_producto     NUMBER(9) NOT NULL,
    cantidad_producto  NUMBER(9, 2) NOT NULL,
    constraint producto_pk primary key (id_producto)
) tablespace fv_env;

prompt Creando tabla rol_usuario.;
CREATE TABLE fv_user.rol_usuario (
    id_rol      NUMBER(2) NOT NULL,
    nombre_rol  VARCHAR2(50) NOT NULL,
    constraint rol_usuario_pk primary key (id_rol)
) tablespace fv_env;

prompt Creando tabla de seguimiento de pedidos.;
CREATE TABLE fv_user.seguimiento_pedido(
    id_seguimiento      VARCHAR2(40) NOT NULL,
    id_pedido           VARCHAR2(40) NOT NULL,
    id_estado           NUMBER(1) DEFAULT 1,
    id_proceso          NUMBER(1) DEFAULT 1,
    fecha_proceso       DATE DEFAULT sysdate,
    CONSTRAINT seguimiento_pk PRIMARY KEY (id_seguimiento)
) TABLESPACE fv_env;

prompt Creando tabla seguro.;
CREATE TABLE fv_user.seguro (
    id_seguro        VARCHAR2(40) NOT NULL,
    nombre_seguro    VARCHAR2(50) NOT NULL,
    compania_seguro  VARCHAR2(50) NOT NULL,
    desc_seguro      varchar(100),
    disponible_seguro number(1) not null,
    primabase_seguro number(9,2) not null,
    constraint seguro_pk primary key (id_seguro)
) tablespace fv_env;

prompt Creando tabla tipo cierre.;
CREATE TABLE fv_user.tipo_cierre (
    id_tipo_cierre    NUMBER(2) NOT NULL,
    desc_tipo_cierre  VARCHAR2(20) NOT NULL,
    CONSTRAINT tipo_cierre_pk PRIMARY KEY ( id_tipo_cierre )
) TABLESPACE fv_env;

prompt Creando tabla tipo_transporte.;
CREATE TABLE fv_user.tipo_transporte (
    id_tipo_transporte    NUMBER(2) NOT NULL,
    desc_tipo_transporte  VARCHAR2(30) NOT NULL,
    constraint tipo_transporte_pk primary key (id_tipo_transporte)
) tablespace fv_env;

prompt Creando tabla tipo_contrato.;
CREATE TABLE fv_user.tipo_contrato (
    id_tipo_contrato    NUMBER(2) NOT NULL,
    desc_tipo_contrato  VARCHAR2(25) NOT NULL,
    constraint tipo_contrato_pk primary key (id_tipo_contrato)
) tablespace fv_env;

prompt Creando tabla usuario.;
CREATE TABLE fv_user.usuario (
    id_usuario  VARCHAR2(40) NOT NULL,
    username    VARCHAR2(150) NOT NULL,
    password    VARCHAR2(128) NOT NULL,
    email       VARCHAR2(255) NOT NULL,
    is_active   NUMBER(1) NOT NULL,
    registro    TIMESTAMP WITH TIME ZONE NOT NULL,
    constraint usuario_pk primary key (id_usuario)
) tablespace fv_env;

prompt Creando tabla vehiculo.;
CREATE TABLE fv_user.vehiculo (
    id_vehiculo          VARCHAR2(40) NOT NULL,
    id_cliente            VARCHAR2(40) NOT NULL,
    id_tipo_transporte    NUMBER(2) NOT NULL,
    patente_vehiculo    VARCHAR2(15) NOT NULL,
    modelo_vehiculo     VARCHAR2(50) NOT NULL,
    capacidad_vehiculo  NUMBER(9, 2) NOT NULL,
    disponibilidad_vehiculo NUMBER(1) DEFAULT 1 NOT NULL,
    CONSTRAINT vehiculo_pk PRIMARY KEY (id_vehiculo)
) TABLESPACE fv_env;



prompt Agregando claves foraneas.;
prompt alterando tabla cierre_pedido.;
alter table fv_user.cierre_pedido
    add constraint cierre_pedido_pedido_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido);

alter table fv_user.cierre_pedido
    add constraint cierre_pedido_tipocierre_fk foreign key (id_tipo_cierre)
        REFERENCES fv_user.tipo_cierre ( id_tipo_cierre );

prompt Alterando ciudad.;
ALTER TABLE fv_user.ciudad
    ADD CONSTRAINT ciudad_pais_fk FOREIGN KEY ( id_pais )
        REFERENCES fv_user.pais ( id_pais );

prompt Alterando tabla cliente.;
ALTER TABLE fv_user.cliente
    ADD CONSTRAINT cliente_rol_usuario_fk FOREIGN KEY ( id_rol )
        REFERENCES fv_user.rol_usuario ( id_rol )
    ADD CONSTRAINT cliente_usuario_fk FOREIGN KEY ( id_usuario )
        REFERENCES fv_user.usuario ( id_usuario );

prompt Alterando tabla contrato.;
ALTER TABLE fv_user.contrato
    ADD CONSTRAINT contrato_tipocontrato_fk FOREIGN KEY ( id_tipo_contrato)
        REFERENCES fv_user.tipo_contrato ( id_tipo_contrato );

prompt Alterando tabla contrato_cliente.;
ALTER TABLE fv_user.contrato_cliente
    ADD CONSTRAINT contrato_cliente_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente )
    ADD CONSTRAINT contrato_cliente_contrato_fk FOREIGN KEY ( id_contrato )
        REFERENCES fv_user.contrato ( id_contrato );

prompt Alterando tabla dato_comercial.;
ALTER TABLE fv_user.dato_comercial
    ADD CONSTRAINT dato_comercial_ciudad_fk FOREIGN KEY ( id_ciudad )
        REFERENCES fv_user.ciudad ( id_ciudad )
	ADD CONSTRAINT dato_comercial_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente );

prompt Alterando tabla detalle_pedido.
ALTER TABLE fv_user.detalle_pedido
    ADD CONSTRAINT detalle_pedido_pedido_fk FOREIGN KEY ( id_pedido )
        REFERENCES fv_user.pedido ( id_pedido )
    ADD CONSTRAINT detalle_pedido_producto_fk FOREIGN KEY ( id_producto )
        REFERENCES fv_user.producto ( id_producto );

prompt Alterando tabla empleado.;
ALTER TABLE fv_user.empleado
    ADD CONSTRAINT empleado_rol_usuario_fk FOREIGN KEY ( id_rol )
        REFERENCES fv_user.rol_usuario ( id_rol )
    ADD CONSTRAINT empleado_usuario_fk FOREIGN KEY ( id_usuario )
        REFERENCES fv_user.usuario ( id_usuario );

prompt Alterando tabla envio.;
ALTER TABLE fv_user.envio
    ADD CONSTRAINT envio_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente )
    ADD CONSTRAINT envio_pedido_fk FOREIGN KEY ( id_pedido )
        REFERENCES fv_user.pedido ( id_pedido )
    ADD CONSTRAINT envio_seguro_fk FOREIGN KEY ( id_seguro )
        REFERENCES fv_user.seguro ( id_seguro );

prompt Alterando tabla pago.;
ALTER TABLE fv_user.pago
    ADD CONSTRAINT pago_metodo_pago_fk FOREIGN KEY ( id_metpago )
        REFERENCES fv_user.metodo_pago ( id_metpago )
    ADD CONSTRAINT pago_pedido_fk FOREIGN KEY ( id_pedido )
        REFERENCES fv_user.pedido ( id_pedido );

prompt Alterando tabla pedido.;
ALTER TABLE fv_user.pedido
    ADD CONSTRAINT pedido_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente );
ALTER TABLE fv_user.pedido
    add constraint pedido_condicionpago_fk foreign key (id_condicion)
        references fv_user.condicion_pago (id_condicion);

prompt Alterando tabla producto.;
ALTER TABLE fv_user.producto
    ADD CONSTRAINT producto_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente );

prompt alterando tabla seguimiento_pedido.;
ALTER TABLE seguimiento_pedido
    add constraint seguimiento_pedido_seguimiento_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido)
    add constraint seguimiento_estado_seguimiento_fk foreign key (id_estado)
        references fv_user.estado_pedido (id_estado)
    add constraint seguimiento_proceso_seguimiento_fk foreign key (id_proceso)
        references fv_user.proceso_pedido (id_proceso);

prompt Alterando tabla vehiculo.;
ALTER TABLE fv_user.vehiculo
   ADD  constraint vehiculo_cliente_vehiculo_fk foreign key (id_cliente)
        references fv_user.cliente (id_cliente)
    add constraint vehiculo_tipotrans_fk foreign key (id_tipo_transporte)
        references fv_user.tipo_transporte ( id_tipo_transporte);



prompt Creando procedimientos almacenados.;
prompt Procedimiento almacenado de usuarios.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarUsuario(
    pIdUsuario varchar2, pUserName VARCHAR2, pPassword VARCHAR2, pEmail VARCHAR2,
    pIdEmpleado varchar2, pIdRol number, pNombre varchar2, pApellido varchar2)
IS
BEGIN
    INSERT INTO fv_user.usuario
        (id_usuario, username, password, email, is_active, registro)
    VALUES
        (pIdUsuario, pUserName, pPassword, pEmail, 1, sysdate);
    insert into fv_user.empleado
        (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado)
    values
        (pIdEmpleado, pIdUsuario, pIdRol, pNombre, pApellido);
    COMMIT;
END spAgregarUsuario;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarUsuario(
    pIdUsuario varchar2, pPassword VARCHAR2, pEmail VARCHAR2,
    pIdEmpleado varchar2, pIdRol number, pNombre varchar2, pApellido varchar2)
IS
BEGIN
    UPDATE fv_user.usuario
    SET password = pPassword, email = pEmail
    WHERE id_usuario = pIdUsuario;

    UPDATE fv_user.empleado
    SET id_rol = pIdRol, nombre_empleado = pNombre, apellido_empleado = pApellido
    WHERE id_empleado = pIdEmpleado;
    COMMIT;
END spActualizarUsuario;
/
CREATE OR REPLACE PROCEDURE fv_user.spHabilitarUsuario(
    pIdUsuario varchar2, pTipoAccion NUMBER)
IS
BEGIN
    UPDATE fv_user.usuario
    SET is_active=pTipoAccion
    WHERE id_usuario=pIdUsuario;
    COMMIT;
END spHabilitarUsuario;
/

prompt Procedimientos almacenados para los clientes.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarCliente(
    pIdUsuario varchar2, pUserName VARCHAR2, pPassword VARCHAR2, pEmail VARCHAR2,
    pIdCliente varchar2, pIdRol number, pNombre varchar2, pApellido varchar2, pDNI varchar2)
IS
BEGIN
    INSERT INTO fv_user.usuario
        (id_usuario, username, password, email, is_active, registro)
    VALUES
        (pIdUsuario, pUserName, pPassword, pEmail, 1, sysdate);
    insert into fv_user.cliente
        (id_cliente, id_usuario, id_rol, nombre_cliente, apellido_cliente, dni_cliente)
    values
        (pIdCliente, pIdUsuario, pIdRol, pNombre, pApellido, pDNI);
    COMMIT;
END spAgregarCliente;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarCliente(
    pIdUsuario varchar2, pPassword VARCHAR2, pEmail VARCHAR2,
    pIdCliente varchar2, pIdRol number, pNombre varchar2, pApellido varchar2, pDNI varchar2)
IS
BEGIN
    UPDATE fv_user.usuario
    SET password = pPassword, email = pEmail
    WHERE id_usuario = pIdUsuario;

    UPDATE fv_user.cliente
    SET id_rol = pIdRol,
        nombre_cliente = pNombre, apellido_cliente = pApellido,
        dni_cliente = pDNI
    WHERE id_cliente = pIdCliente;
    COMMIT;
END spActualizarCliente;
/
CREATE OR REPLACE PROCEDURE fv_user.spHabilitarCliente(
    pIdUsuario varchar2, pTipoAccion NUMBER)
IS
BEGIN
    UPDATE fv_user.usuario
    SET is_active=pTipoAccion
    WHERE id_usuario=pIdUsuario;
    COMMIT;
END spHabilitarCliente;
/


prompt Creando procedimientos almacenados para los datos comerciales de los clientes.;
create or replace procedure fv_user.spAgregarDatosComerciales(
    pIdComercial varchar2, pIdCliente varchar2, pIdCiudad number, 
    pRSocial varchar2, pFantasia varchar2, pGiro varchar2,
    pEmail varchar2, pDNI varchar2, 
    pDireccion varchar2, pTelefono varchar2) is
begin
    insert into fv_user.dato_comercial
        (id_comercial, id_cliente, id_ciudad,
        rsocial_comercial, fantasia_comercial, 
        giro_comercial, email_comercial,
        dni_comercial, dir_comercial, fono_comercial)
    values
        (pIdComercial, pIdCliente, pIdCiudad,
        pRSocial, pFantasia, pGiro,
        pEmail, pDNI, pDireccion, pTelefono);
    commit;
end spAgregarDatosComerciales;
/
create or replace procedure fv_user.spActualizarDatosComerciales(
    pIdComercial varchar2, pIdCiudad number,
    pRSocial varchar2, pFantasia varchar2, pGiro varchar2,
    pEmail varchar2, pDNI varchar2, pDireccion varchar2, pTelefono varchar2) is
begin
    update fv_user.dato_comercial
       set id_ciudad = pIdCiudad,
            rsocial_comercial=pRSocial,
            fantasia_comercial=pFantasia, giro_comercial=pGiro,
            email_comercial=pEmail, dni_comercial=pDNI, 
            dir_comercial=pDireccion, fono_comercial = pTelefono
     where id_comercial = pIdComercial;
    commit;
end spActualizarDatosComerciales;
/
create or replace procedure fv_user.spEliminarDatosComerciales(
    pIdComercial varchar2) is
begin
    delete from fv_user.dato_comercial
    where id_comercial = pIdComercial;
    commit;
end spEliminarDatosComerciales;
/

prompt Creando procedimientos almacenados para los productos.;
create or replace procedure fv_user.spAgregarProductos(
    pIdProducto varchar2, pIdCliente varchar2,
    pNombre varchar2, pObservacion varchar2,
    pValor number, pCantidad number) is
begin
    insert into fv_user.producto
        (id_producto, id_cliente,
        nombre_producto, obs_producto,
        valor_producto, cantidad_producto)
    values
        (pIdProducto, pIdCliente,
        pNombre, pObservacion,
        pValor, pCantidad);
    commit;
end spAgregarProductos;
/
create or replace procedure fv_user.spActualizarProductos(
    pIdProducto varchar2,
    pNombre varchar2, pObservacion varchar2,
    pValor number, pCantidad number) is
begin
    update fv_user.producto
       set nombre_producto = pNombre,
            obs_producto = pObservacion,
            valor_producto = pValor,
            cantidad_producto = pCantidad
     where id_producto = pIdProducto;
    commit;
end spActualizarProductos;
/
create or replace procedure fv_user.spEliminarProductos(
    pIdProducto varchar2) is
    vCantProductos number default 0;
begin
    select count(id_producto)
      into vCantProductos
    from fv_user.detalle_pedido
    where id_producto = pIdProducto;
    if vCantProductos=0 then
        delete from fv_user.producto
        where id_producto = pIdProducto;
        commit;
    end if;
end spEliminarProductos;
/

prompt Creando procedimientos almacenados para los vehiculos.;
CREATE OR REPLACE PROCEDURE fv_user.spagregarvehiculos(
    pidvehiculo VARCHAR2, pidcliente VARCHAR2, pidtipo NUMBER,
    ppatente VARCHAR2, pmodelo VARCHAR2, pcapacidad NUMBER) IS
BEGIN
    INSERT INTO fv_user.vehiculo
        (id_vehiculo, id_cliente, id_tipo_transporte,
        patente_vehiculo, modelo_vehiculo, capacidad_vehiculo)
    VALUES
        (pidvehiculo, pidcliente, pidtipo,
        ppatente, pmodelo, pcapacidad);
    COMMIT;
END spagregarvehiculos;
/
CREATE OR REPLACE PROCEDURE fv_user.spactualizarvehiculos(
    pidvehiculo VARCHAR2, pidtipo NUMBER,
    ppatente VARCHAR2, pmodelo VARCHAR2, 
    pcapacidad NUMBER, pdisponibilidad NUMBER) IS
BEGIN
    UPDATE fv_user.vehiculo
       SET id_tipo_transporte = pidtipo,
            patente_vehiculo = ppatente,
            modelo_vehiculo = pmodelo,
            capacidad_vehiculo = pcapacidad,
            disponibilidad_vehiculo = pdisponibilidad
     WHERE id_vehiculo = pidvehiculo;
    COMMIT;
END spactualizarvehiculos;
/
CREATE OR REPLACE PROCEDURE fv_user.speliminarvehiculos(
    pidvehiculo VARCHAR2) IS
BEGIN
        DELETE FROM fv_user.vehiculo
        WHERE id_vehiculo = pidvehiculo;
        COMMIT;
END speliminarvehiculos;
/

prompt Creando procedimientos almacenados para los contratos.;
create or replace procedure fv_user.spAgregarContratos(
    pIdContrato varchar2, pIdTipo number,
    pInicio date, pTermino date,
    pDescripcion varchar2, pComision number, pPerfil number) is
begin
    insert into fv_user.contrato
        (id_contrato, id_tipo_contrato, inicio_contrato,
        termino_contrato, esta_vigente, desc_contrato,
        comision_contrato, perfil_contrato, fecha_registro)
    values
        (pIdContrato, pIdTipo, pInicio,
        pTermino, 1, pDescripcion,
        pComision, pPerfil, sysdate);
    commit;
end spAgregarContratos;
/
create or replace procedure fv_user.spActualizarContratos(
    pIdContrato varchar2, pIdTipo number,
    pInicio date, pTermino date, pVigente number,
    pDescripcion varchar2, pComision number) is
begin
    update  fv_user.contrato
        set id_tipo_contrato = pIdTipo,
            inicio_contrato = pInicio,
            termino_contrato = pTermino,
            esta_vigente = pVigente,
            desc_contrato = pDescripcion,
            comision_contrato = pComision
    where id_contrato = pIdContrato;
    commit;
end spActualizarContratos;
/
create or replace procedure fv_user.spEliminarContratos(
    pIdContrato varchar2) is
begin
    delete from   fv_user.contrato
    where id_contrato = pIdContrato;
    commit;
end spEliminarContratos;
/


prompt Procedimientos almacenados para pedidos.;
CREATE OR REPLACE PROCEDURE fv_user.spAgregarPedido(
    pIdPedido VARCHAR2, pIdCliente VARCHAR2,
    pIdCondicion NUMBER, pDescuento NUMBER) IS
BEGIN
    --insertando cabecera del pedido
    INSERT INTO fv_user.pedido 
        (id_pedido, id_cliente, id_condicion, 
        fecha_pedido, descuento_solicitado)
    VALUES 
        (pIdPedido, pIdCliente, pIdCondicion, 
        sysdate, pDescuento);
    -- agregando el seguimiento.
    INSERT INTO fv_user.seguimiento_pedido 
        (id_seguimiento, id_pedido)
    VALUES 
        (sys_guid(), pIdPedido);
    COMMIT;
END spAgregarPedido;
/
CREATE OR REPLACE PROCEDURE fv_user.spAgregarDetallePedido(
    pIdPedido VARCHAR, pIdProducto VARCHAR, pCantidad NUMBER) IS
BEGIN
    INSERT INTO fv_user.detalle_pedido
        (id, id_pedido, id_producto, cantidad)
    VALUES 
        (sys_guid(), pIdPedido, pIdProducto, pCantidad);
    COMMIT;
END spAgregarDetallePedido;
/
CREATE OR REPLACE TRIGGER fv_user.trLimpiarDetallePedido
AFTER UPDATE ON fv_user.pedido
FOR EACH ROW
BEGIN 
    DELETE FROM fv_user.detalle_pedido 
    WHERE id_pedido = :old.id_pedido;
END;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarPedido(
    pIdPedido VARCHAR2, pIdCondicion NUMBER, pDescuento NUMBER) IS
BEGIN
    --Actualizando cabecera del pedido
    UPDATE fv_user.pedido 
    SET id_condicion = pIdCondicion,
        descuento_solicitado= pDescuento
    WHERE id_pedido = pIdPedido;
    COMMIT;
END spActualizarPedido;
/
CREATE OR REPLACE PROCEDURE fv_user.spActualizarEstadoPedido(
    pIdPedido VARCHAR2, pEstado NUMBER, pProceso NUMBER) IS
BEGIN
    INSERT INTO fv_user.seguimiento_pedido
        (id_seguimiento, id_pedido, id_estado, id_proceso)
    VALUES
        (sys_guid(), pIdPedido, pEstado, pProceso);
    COMMIT;
END spActualizarEstadoPedido;
/



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

prompt Creando vista para los vehiculos.;
CREATE OR REPLACE VIEW fv_user.vwvehiculos AS
    SELECT
        veh.id_vehiculo, veh.id_cliente,
        tip.id_tipo_transporte, tip.desc_tipo_transporte AS "Tipo",
        veh.patente_vehiculo AS "Patente", 
        veh.modelo_vehiculo AS "Modelo",
        veh.capacidad_vehiculo AS "Capacidad", 
        veh.disponibilidad_vehiculo AS "Disponible"
    FROM fv_user.vehiculo veh 
        INNER JOIN fv_user.tipo_transporte tip 
            ON veh.id_tipo_transporte=tip.id_tipo_transporte;

prompt Creando vista para los contratos.;
create or replace view fv_user.vwObtenerContratos as
    select
        con.id_contrato, con.desc_contrato as "Descripcion",
        tip.id_tipo_contrato, tip.desc_tipo_contrato as "Tipo",
        to_char(con.inicio_contrato, 'dd/MM/yyyy') AS "Inicio",
        to_char(con.termino_contrato, 'dd/MM/yyyy') as "Termino",
        con.esta_vigente,
        case con.esta_vigente
            when 1 then 'Vigente'
            when 0 then 'Caducado'
        end as "Estado",
        con.comision_contrato as "Comision",
        con.perfil_contrato,
        to_char(con.fecha_registro, 'dd/MM/yyyy') AS "Fecha registro"
    from fv_user.contrato con
        inner join fv_user.tipo_contrato tip
            on con.id_tipo_contrato=tip.id_tipo_contrato;

prompt Creando vista para pedidos.;
CREATE OR REPLACE VIEW  fv_user.vwObtenerPedidos AS
SELECT
    ped.id_pedido,ped.id_cliente, 
    con.id_condicion, con.desc_condicion AS "Condicion de pago",
    to_char(ped.fecha_pedido, 'dd/MM/yyyy') AS "Fecha pedido",
    ped.descuento_solicitado AS "Descuento solicitado"
FROM fv_user.pedido ped
    INNER JOIN fv_user.condicion_pago con
        ON ped.id_condicion = con.id_condicion;

prompt Creando vista para el detalle de pedido.;
CREATE OR REPLACE VIEW fv_user.vwObtenerDetallePedido AS
SELECT 
    det.id, det.id_pedido, pro.id_producto,
    pro.nombre_producto AS "Nombre producto",
    det.cantidad AS "Cantidad solicitada"
FROM fv_user.detalle_pedido det
    INNER JOIN fv_user.producto pro 
        ON det.id_producto = pro.id_producto 

prompt Creando vista para obbtener el seguimiento del pedido.;
CREATE OR REPLACE VIEW fv_user.vwObtenerSeguimientoPedido AS 
SELECT 
    seg.id_seguimiento, seg.id_pedido, 
    est.id_estado, est.desc_estado AS "Estado",
    pro.id_proceso, pro.desc_proceso AS "Proceso pedido",
    to_char(seg.fecha_proceso, 'dd/MM/yyyy') AS "Fecha proceso"
FROM fv_user.seguimiento_pedido seg
    INNER JOIN fv_user.estado_pedido est
        ON seg.id_estado = est.id_estado 
    INNER JOIN fv_user.proceso_pedido pro 
        ON seg.id_proceso = pro.id_proceso;


prompt insertando registros iniciales.;
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

