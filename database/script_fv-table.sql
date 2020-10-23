-- Archivo: script_fv-table.sql
--          Crea las tablas para feria virtual.
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
prompt Creando tablas de la base de datos.;
prompt ----------------------------------------;
prompt;

prompt Creando tabla categorias de productos.;
CREATE TABLE fv_user.categoria_producto(
    id_categoria        NUMBER(2) NOT NULL,
    desc_categoria      VARCHAR(25) NOT NULL,
    CONSTRAINT categoria_producto_pk PRIMARY KEY (id_categoria)
) TABLESPACE fv_env;


prompt Creando tabla de cierre de pedidos.;
CREATE TABLE fv_user.cierre_pedido (
    id_cierre           VARCHAR2(40) NOT NULL,
    id_pedido           VARCHAR2(40) NOT NULL,
    id_tipo_cierre      NUMBER(2) NOT NULL,
    fecha_cierre        DATE,
    obs_cierre          VARCHAR2(100),
    CONSTRAINT cierre_pedido_pk PRIMARY KEY ( id_cierre )
) TABLESPACE fv_env;


prompt Creando tabla de ciudades.;
CREATE TABLE fv_user.ciudad (
    id_ciudad  NUMBER(5) NOT NULL,
    id_pais             number(5) NOT NULL,
    nombre_ciudad       VARCHAR2(100) NOT NULL,
    constraint ciudad_pk primary key (id_ciudad)
) tablespace fv_env;


prompt Creando tabla cliente.;
CREATE TABLE fv_user.cliente (
    id_cliente          VARCHAR2(40) NOT NULL,
    id_usuario          VARCHAR2(40) NOT NULL,
    id_rol              NUMBER(2) NOT NULL,
    nombre_cliente      VARCHAR2(50) NOT NULL,
    apellido_cliente    VARCHAR2(50) NOT NULL,
    dni_cliente         VARCHAR2(20) NOT NULL,
    constraint cliente_pk primary key (id_cliente)
) tablespace fv_env;


prompt Creando tabla condiciones de pago.;
CREATE TABLE fv_user.condicion_pago(
    id_condicion        NUMBER(2) NOT NULL,
    desc_condicion      VARCHAR(25) NOT NULL,
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
    estado_aceptacion   number(1) default 0 not null,
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
    id              VARCHAR2(40) NOT NULL,
    id_pedido       VARCHAR2(40) NOT NULL,
    nombre_producto VARCHAR2(50) NOT NULL,
    cantidad        NUMBER(5) NOT NULL,
    constraint      detalle_pedido_pk primary key (id)
) tablespace fv_env;


prompt Creando tabla empleado.;
CREATE TABLE fv_user.empleado(
    id_empleado         VARCHAR2(40) NOT NULL,
    id_usuario          VARCHAR2(40) NOT NULL,
    id_rol              NUMBER(2) NOT NULL,
    nombre_empleado     VARCHAR2(50) NOT NULL,
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
    id_estado       NUMBER(1) NOT NULL,
    desc_estado     VARCHAR2(15) NOT NULL,
    CONSTRAINT estado_pedido_pk PRIMARY KEY (id_estado) 
) TABLESPACE fv_env;


prompt Creando tabla metodo_pago.;
CREATE TABLE fv_user.metodo_pago (
    id_metpago      NUMBER(2) NOT NULL,
    desc_metpago    VARCHAR2(30) NOT NULL,
    constraint metodo_pago_pk primary key (id_metpago)
) tablespace fv_env;


prompt Creando tabla pago.;
CREATE TABLE fv_user.pago (
    id_pago         VARCHAR2(40) NOT NULL,
    id_metpago      NUMBER(2) NOT NULL,
    id_pedido       VARCHAR2(40) NOT NULL,
    fecha_pago      DATE NOT NULL,
    monto_pago      NUMBER(9, 2) NOT NULL,
    descuento_pago  number(4,2) not null,
    obs_pago        VARCHAR2(100) NOT NULL,
    constraint pago_pk primary key (id_pago)
) tablespace fv_env;


prompt Creando tabla pais.;
CREATE TABLE fv_user.pais (
    id_pais         number(5) NOT NULL,
    nombre_pais     VARCHAR2(100),
    prefijo_pais    VARCHAR2(6),
    constraint pais_pk primary key (id_pais)
) tablespace fv_env;


prompt Creando tabla pedido.;
CREATE TABLE fv_user.pedido (
    id_pedido               VARCHAR2(40) NOT NULL,
    id_condicion            NUMBER(2) NOT NULL,
    id_cliente              VARCHAR2(40) NOT NULL,
    fecha_pedido            DATE NOT NULL,
    descuento_solicitado    number(2) default 0 not null,
    constraint pedido_pk primary key (id_pedido)
) tablespace fv_env;


prompt Creando tabla proceso_pedido.;
CREATE TABLE fv_user.proceso_pedido(
    id_proceso      NUMBER(1) NOT NULL,
    desc_proceso    VARCHAR2(30) NOT NULL,
    CONSTRAINT proceso_pedido_pk PRIMARY KEY (id_proceso) 
) TABLESPACE fv_env;


prompt Creando tabla producto.;
CREATE TABLE fv_user.producto (
    id_producto         VARCHAR2(40) NOT NULL,
    id_cliente          VARCHAR2(40) NOT NULL,
    id_categoria        NUMBER(2) NOT NULL,
    nombre_producto     VARCHAR2(50) NOT NULL,
    obs_producto        VARCHAR2(100),
    valor_producto      NUMBER(9) NOT NULL,
    cantidad_producto   NUMBER(9, 2) NOT NULL,
    constraint producto_pk primary key (id_producto)
) tablespace fv_env;


prompt Creando tabla rol_usuario.;
CREATE TABLE fv_user.rol_usuario (
    id_rol          NUMBER(2) NOT NULL,
    nombre_rol      VARCHAR2(50) NOT NULL,
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
    id_seguro           VARCHAR2(40) NOT NULL,
    nombre_seguro       VARCHAR2(50) NOT NULL,
    compania_seguro     VARCHAR2(50) NOT NULL,
    desc_seguro         varchar(100),
    disponible_seguro   number(1) not null,
    primabase_seguro    number(9,2) not null,
    constraint seguro_pk primary key (id_seguro)
) tablespace fv_env;


prompt Creando tabla tipo cierre.;
CREATE TABLE fv_user.tipo_cierre (
    id_tipo_cierre      NUMBER(2) NOT NULL,
    desc_tipo_cierre    VARCHAR2(20) NOT NULL,
    CONSTRAINT tipo_cierre_pk PRIMARY KEY ( id_tipo_cierre )
) TABLESPACE fv_env;


prompt Creando tabla tipo_transporte.;
CREATE TABLE fv_user.tipo_transporte (
    id_tipo_transporte      NUMBER(2) NOT NULL,
    desc_tipo_transporte    VARCHAR2(30) NOT NULL,
    constraint tipo_transporte_pk primary key (id_tipo_transporte)
) tablespace fv_env;


prompt Creando tabla tipo_contrato.;
CREATE TABLE fv_user.tipo_contrato (
    id_tipo_contrato        NUMBER(2) NOT NULL,
    desc_tipo_contrato      VARCHAR2(25) NOT NULL,
    constraint tipo_contrato_pk primary key (id_tipo_contrato)
) tablespace fv_env;


prompt Creando tabla usuario.;
CREATE TABLE fv_user.usuario (
    id_usuario      VARCHAR2(40) NOT NULL,
    username        VARCHAR2(150) NOT NULL,
    password        VARCHAR2(128) NOT NULL,
    email           VARCHAR2(255) NOT NULL,
    is_active       NUMBER(1) NOT NULL,
    registro        TIMESTAMP WITH TIME ZONE NOT NULL,
    constraint usuario_pk primary key (id_usuario)
) tablespace fv_env;


prompt Creando tabla vehiculo.;
CREATE TABLE fv_user.vehiculo (
    id_vehiculo                 VARCHAR2(40) NOT NULL,
    id_cliente                  VARCHAR2(40) NOT NULL,
    id_tipo_transporte          NUMBER(2) NOT NULL,
    patente_vehiculo            VARCHAR2(15) NOT NULL,
    modelo_vehiculo             VARCHAR2(50) NOT NULL,
    capacidad_vehiculo          NUMBER(9, 2) NOT NULL,
    disponibilidad_vehiculo     NUMBER(1) DEFAULT 1 NOT NULL,
    observacion_vehiculo        VARCHAR2(100),
    CONSTRAINT vehiculo_pk PRIMARY KEY (id_vehiculo)
) TABLESPACE fv_env;




prompt Agregando claves foraneas.;
prompt alterando tabla cierre_pedido.;
alter table fv_user.cierre_pedido
    add constraint cierre_pedido_pedido_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido) 
        ON DELETE CASCADE;
alter table fv_user.cierre_pedido
    add constraint cierre_pedido_tipocierre_fk foreign key (id_tipo_cierre)
        REFERENCES fv_user.tipo_cierre ( id_tipo_cierre );


prompt Alterando ciudad.;
ALTER TABLE fv_user.ciudad
    ADD CONSTRAINT ciudad_pais_fk FOREIGN KEY ( id_pais )
        REFERENCES fv_user.pais ( id_pais ) 
        ON DELETE CASCADE;


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
        REFERENCES fv_user.contrato ( id_contrato ) 
        ON DELETE CASCADE;


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
        ON DELETE CASCADE;


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
        REFERENCES fv_user.cliente ( id_cliente )
    ADD CONSTRAINT producto_categoria_producto_fk FOREIGN KEY (ID_CATEGORIA)
        REFERENCES FV_USER.CATEGORIA_PRODUCTO (ID_CATEGORIA);


prompt alterando tabla seguimiento_pedido.;
ALTER TABLE fv_user.seguimiento_pedido
    add constraint seguimiento_pedido_seguimiento_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido)
        ON DELETE CASCADE
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


prompt Confirmando cambios.;
commit;
