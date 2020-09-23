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
alter session set "_ORACLE_SCRIPT"=true;
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

prompt Creando tabla de ciudades.;
CREATE TABLE fv_user.ciudad (
    cod_ciudad  NUMBER(5) NOT NULL,
    cod_pais       VARCHAR2(2) NOT NULL,
    nombre_ciudad  VARCHAR2(100) NOT NULL,
    constraint ciudad_pk primary key (cod_ciudad)
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


prompt Creando tabla contrato.;
CREATE TABLE fv_user.contrato (
    id_contrato        VARCHAR2(40) NOT NULL,
    inicio_contrato    DATE NOT NULL,
    termino_contrato   DATE,
    esta_vigente       NUMBER(1) NOT NULL,
    desc_contrato      VARCHAR2(100),
    comision_contrato  NUMBER(9) NOT NULL,
    constraint contrato_pk primary key (id_contrato)
) tablespace fv_env;

prompt Creando tabla contrato_cliente.;
CREATE TABLE fv_user.contrato_cliente (
    id           VARCHAR2(40) NOT NULL,
    id_contrato  VARCHAR2(40) NOT NULL,
    id_cliente   VARCHAR2(40) NOT NULL,
    constraint contrato_cliente_pk primary key (id)
) tablespace fv_env;

prompt Creando tabla dato_comercial.;
CREATE TABLE fv_user.dato_comercial (
    id_comercial        VARCHAR2(40) NOT NULL,
    id_cliente          VARCHAR2(40) NOT NULL,
    cod_ciudad       NUMBER(5) NOT NULL, 
    rsocial_comercial   VARCHAR2(100) NOT NULL,
    fantasia_comercial  VARCHAR2(100),
    giro_comercial      VARCHAR2(100) NOT NULL,
    email_comercial     VARCHAR2(254),
    dni_comercial       VARCHAR2(20) NOT NULL,
    dir_comercial       VARCHAR2(100) NOT NULL,
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
    constraint envio_pk primary key (id_envio)
) tablespace fv_env;

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
    obs_pago    VARCHAR2(100) NOT NULL,
    constraint pago_pk primary key (id_pago)
) tablespace fv_env;

prompt Creando tabla pais.;
CREATE TABLE fv_user.pais (
    cod_pais      VARCHAR2(2) NOT NULL,
    nombre_pais   VARCHAR2(100),
    prefijo_pais  VARCHAR2(6), 
    constraint pais_pk primary key (cod_pais)
) tablespace fv_env;

prompt Creando tabla pedido.;
CREATE TABLE fv_user.pedido (
    id_pedido      VARCHAR2(40) NOT NULL,
    id_cliente     VARCHAR2(40) NOT NULL,
    fecha_pedido   DATE NOT NULL,
    estado_pedido  NUMBER(1) NOT NULL,
    constraint pedido_pk primary key (id_pedido)
) tablespace fv_env;

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

prompt Creando tabla seguro.;
CREATE TABLE fv_user.seguro (
    id_seguro        VARCHAR2(40) NOT NULL,
    nombre_seguro    VARCHAR2(50) NOT NULL,
    compania_seguro  VARCHAR2(50) NOT NULL,
    constraint seguro_pk primary key (id_seguro)
) tablespace fv_env;

prompt Creando tabla telefono.;
CREATE TABLE fv_user.telefono (
    id_telefono   VARCHAR2(40) NOT NULL,
    id_comercial  VARCHAR2(40) NOT NULL,
    num_telefono  VARCHAR2(15) NOT NULL,
    constraint telefono_pk primary key (id_telefono)
) tablespace fv_env;

prompt Creando tabla tipo_transporte.;
CREATE TABLE fv_user.tipo_transporte (
    id_tipo_transporte    NUMBER(2) NOT NULL,
    desc_tipo_transporte  VARCHAR2(30) NOT NULL,
    constraint tipo_transporte_pk primary key (id_tipo_transporte)
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
    id_vehiculo         VARCHAR2(40) NOT NULL,
    id_tipo_transporte  NUMBER(2) NOT NULL,
    modelo_vehiculo     VARCHAR2(50) NOT NULL,
    capacidad_vehiculo  NUMBER(9, 2) NOT NULL,
    constraint vehiculo_pk primary key (id_vehiculo)
) tablespace fv_env;



prompt Agregando claves foraneas.;
prompt Alterando ciudad.;
ALTER TABLE fv_user.ciudad
    ADD CONSTRAINT ciudad_pais_fk FOREIGN KEY ( cod_pais )
        REFERENCES fv_user.pais ( cod_pais );

prompt Alterando tabla cliente.;
ALTER TABLE fv_user.cliente
    ADD CONSTRAINT cliente_rol_usuario_fk FOREIGN KEY ( id_rol )
        REFERENCES fv_user.rol_usuario ( id_rol )
    ADD CONSTRAINT cliente_usuario_fk FOREIGN KEY ( id_usuario )
        REFERENCES fv_user.usuario ( id_usuario );

prompt Alterando tabla contrato_cliente.;
ALTER TABLE fv_user.contrato_cliente
    ADD CONSTRAINT contrato_cliente_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente )
    ADD CONSTRAINT contrato_cliente_contrato_fk FOREIGN KEY ( id_contrato )
        REFERENCES fv_user.contrato ( id_contrato );

prompt Alterando tabla dato_comercial.;
ALTER TABLE fv_user.dato_comercial
    ADD CONSTRAINT dato_comercial_ciudad_fk FOREIGN KEY ( cod_ciudad )
        REFERENCES fv_user.ciudad ( cod_ciudad )
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

prompt Alterando tabla producto.;
ALTER TABLE fv_user.producto
    ADD CONSTRAINT producto_cliente_fk FOREIGN KEY ( id_cliente )
        REFERENCES fv_user.cliente ( id_cliente );

prompt Alterando tabla telefono.;
ALTER TABLE fv_user.telefono
    ADD CONSTRAINT telefono_dato_comercial_fk FOREIGN KEY ( id_comercial )
        REFERENCES fv_user.dato_comercial ( id_comercial );

prompt Alterando tabla vehiculo.;
ALTER TABLE fv_user.vehiculo
    ADD CONSTRAINT vehiculo_tipo_transporte_fk FOREIGN KEY ( id_tipo_transporte )
        REFERENCES fv_user.tipo_transporte ( id_tipo_transporte );



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
    pEmail varchar2, pDNI varchar2, pDireccion varchar2) is
begin
    insert into fv_user.dato_comercial 
        (id_comercial, id_cliente, cod_ciudad, rsocial_comercial, 
        fantasia_comercial, giro_comercial, email_comercial, 
        dni_comercial, dir_comercial)
    values 
        (pIdComercial, pIdCliente, pIdCiudad, 
        pRSocial, pFantasia, pGiro, 
        pEmail, pDNI, pDireccion);
    commit;
end spAgregarDatosComerciales;
/
create or replace procedure fv_user.spActualizarDatosComerciales(
    pIdComercial varchar2, pIdCiudad number, 
    pRSocial varchar2, pFantasia varchar2, pGiro varchar2, 
    pEmail varchar2, pDNI varchar2, pDireccion varchar2) is
begin
    update fv_user.dato_comercial 
       set cod_ciudad=pIdCiudad, rsocial_comercial=pRSocial, 
            fantasia_comercial=pFantasia, giro_comercial=pGiro,
            email_comercial=pEmail, dni_comercial=pDNI, dir_comercial=pDireccion 
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
        com.id_comercial, com.id_cliente, 
        rsocial_comercial AS "Razon social", 
        fantasia_comercial AS "Nombre de fantasia",
        giro_comercial as "Giro comercial", 
        email_comercial as "Email", 
        dni_comercial as "DNI", 
        dir_comercial as "Direccion", 
        ciu.cod_ciudad, ciu.nombre_ciudad as "Ciudad", 
        pai.cod_pais, pai.nombre_pais as "Pais", 
        pai.prefijo_pais as "Prefijo" 
    from dato_comercial com 
    inner join ciudad ciu on com.cod_ciudad=ciu.cod_ciudad 
    inner join pais pai on ciu.cod_pais=pai.cod_pais;





prompt insertando registros iniciales.;
prompt Insertando roles de usuario.;
insert into fv_user.rol_usuario (id_rol, nombre_rol) values (1, 'Administrador');
insert into fv_user.rol_usuario (id_rol, nombre_rol) values (2, 'Consultor');
insert into fv_user.rol_usuario (id_rol, nombre_rol) values (3, 'Cliente externo');
insert into fv_user.rol_usuario (id_rol, nombre_rol) values (4, 'Cliente interno');
insert into fv_user.rol_usuario (id_rol, nombre_rol) values (5, 'Productor');
insert into fv_user.rol_usuario (id_rol, nombre_rol) values (6, 'Transportista');

prompt Creando usuarios de ejemplo.
insert into fv_user.usuario(id_usuario, username, password, email, is_active, registro) values ('1', 'd.garcial', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'd.garcial@alumnos.duoc.cl', 1, to_date('2020/09/07', 'yyyy/mm/dd'));
insert into fv_user.usuario(id_usuario, username, password, email, is_active, registro) values ('2', 'c.arenas', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'c.arenas@alumnos.duoc.cl', 1, to_date('2020/09/07', 'yyyy/mm/dd'));
insert into fv_user.usuario(id_usuario, username, password, email, is_active, registro) values ('3', 'l.repetto', '9cf9951f2bb3fedc9f709c7314fb9fb672c7a66e', 'l.repetto@alumnos.duoc.cl', 0, to_date('2020/09/07', 'yyyy/mm/dd'));

prompt Insertando empleados de prueba.;
insert into fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado) values ('1', '1', 1, 'Daniel', 'Garcia Asathor');
insert into fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado) values ('2', '2', 2, 'Claudio', 'Arenas Carril');
insert into fv_user.empleado (id_empleado, id_usuario, id_rol, nombre_empleado, apellido_empleado) values ('3', '3', 2, 'Lucas', 'Repetto Asencio');



prompt Aceptando cambios.;
commit;

