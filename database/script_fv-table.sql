-- Archivo: script_fv-table.sql
--          Crea las tablas para feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
ALTER SESSION SET NLS_LANGUAGE= 'SPANISH' NLS_TERRITORY= 'Spain' NLS_CURRENCY= '$' NLS_ISO_CURRENCY= 'AMERICA' NLS_NUMERIC_CHARACTERS= '.,' NLS_CALENDAR= 'GREGORIAN' NLS_DATE_FORMAT= 'DD-MON-RR' NLS_DATE_LANGUAGE= 'SPANISH' NLS_SORT= 'BINARY';


prompt;
prompt Creando tablas de la base de datos.;
prompt ----------------------------------------;


prompt Creando tabla categorias de productos.;
CREATE TABLE fv_user.categoria_producto
(
    id_categoria   NUMBER(2)   NOT NULL,
    desc_categoria VARCHAR(25) NOT NULL,
    CONSTRAINT categoria_producto_pk PRIMARY KEY (id_categoria)
) TABLESPACE fv_env;


prompt Creando tabla de cierre de pedidos.;
CREATE TABLE fv_user.cierre_pedido
(
    id_cierre      VARCHAR2(40) NOT NULL,
    id_pedido      VARCHAR2(40) NOT NULL,
    id_tipo_cierre NUMBER(2)    NOT NULL,
    fecha_cierre   DATE,
    obs_cierre     VARCHAR2(100),
    CONSTRAINT cierre_pedido_pk PRIMARY KEY (id_cierre)
) TABLESPACE fv_env;


prompt Creando tabla de ciudades.;
CREATE TABLE fv_user.ciudad
(
    id_ciudad     NUMBER(5)     NOT NULL,
    id_pais       number(5)     NOT NULL,
    nombre_ciudad VARCHAR2(100) NOT NULL,
    constraint ciudad_pk primary key (id_ciudad)
) tablespace fv_env;


prompt Creando tabla cliente.;
CREATE TABLE fv_user.cliente
(
    id_cliente       VARCHAR2(40) NOT NULL,
    id_usuario       VARCHAR2(40) NOT NULL,
    id_rol           NUMBER(2)    NOT NULL,
    nombre_cliente   VARCHAR2(50) NOT NULL,
    apellido_cliente VARCHAR2(50) NOT NULL,
    dni_cliente      VARCHAR2(20) NOT NULL,
    constraint cliente_pk primary key (id_cliente)
) tablespace fv_env;


prompt Creando tabla condiciones de pago.;
CREATE TABLE fv_user.condicion_pago
(
    id_condicion   NUMBER(2)   NOT NULL,
    desc_condicion VARCHAR(25) NOT NULL,
    CONSTRAINT condicion_pago_pk PRIMARY KEY (id_condicion)
) TABLESPACE fv_env;


prompt Creando tabla contrato.;
CREATE TABLE fv_user.contrato
(
    id_contrato       VARCHAR2(40)           NOT NULL,
    id_tipo_contrato  number(2)              not null,
    inicio_contrato   DATE                   NOT NULL,
    termino_contrato  DATE,
    esta_vigente      NUMBER(1)              NOT NULL,
    desc_contrato     VARCHAR2(100),
    comision_contrato NUMBER(5, 2) default 0 NOT NULL,
    perfil_contrato   number(2)              not null,
    fecha_registro    date                   not null,
    constraint contrato_pk primary key (id_contrato)
) tablespace fv_env;


prompt Creando tabla contrato_cliente.;
CREATE TABLE fv_user.contrato_cliente
(
    id                VARCHAR2(40)           NOT NULL,
    id_contrato       VARCHAR2(40)           NOT NULL,
    id_cliente        VARCHAR2(40)           NOT NULL,
    fecha_aceptacion  date,
    fecha_registro    date,
    obs_contrato      varchar2(100),
    obs_cliente       varchar2(100),
    valor_adicional   number(5, 2) default 0 not null,
    valor_multa       number(5, 2) default 0 not null,
    estado_aceptacion number(1)    default 0 not null,
    constraint contrato_cliente_pk primary key (id)
) tablespace fv_env;


prompt Creando tabla dato_comercial.;
CREATE TABLE fv_user.dato_comercial
(
    id_comercial       VARCHAR2(40)  NOT NULL,
    id_cliente         VARCHAR2(40)  NOT NULL,
    id_ciudad          NUMBER(5)     NOT NULL,
    rsocial_comercial  VARCHAR2(100) NOT NULL,
    fantasia_comercial VARCHAR2(100),
    giro_comercial     VARCHAR2(100) NOT NULL,
    email_comercial    VARCHAR2(254),
    dni_comercial      VARCHAR2(20)  NOT NULL,
    dir_comercial      VARCHAR2(100) NOT NULL,
    fono_comercial     varchar(30),
    constraint dato_comercial_pk primary key (id_comercial)
) tablespace fv_env;


prompt Creando tabla detalle_pedido.;
CREATE TABLE fv_user.detalle_pedido
(
    id              VARCHAR2(40) NOT NULL,
    id_pedido       VARCHAR2(40) NOT NULL,
    nombre_producto VARCHAR2(50) NOT NULL,
    cantidad        NUMBER(5)    NOT NULL,
    constraint detalle_pedido_pk primary key (id)
) tablespace fv_env;


prompt Creando tabla empleado.;
CREATE TABLE fv_user.empleado
(
    id_empleado       VARCHAR2(40) NOT NULL,
    id_usuario        VARCHAR2(40) NOT NULL,
    id_rol            NUMBER(2)    NOT NULL,
    nombre_empleado   VARCHAR2(50) NOT NULL,
    apellido_empleado VARCHAR2(50) NOT NULL,
    constraint empleado_pk primary key (id_empleado)
) tablespace fv_env;


prompt Creando tabla envio.;
CREATE TABLE fv_user.envio
(
    id_envio     VARCHAR2(40)  NOT NULL,
    id_pedido    VARCHAR2(40)  NOT NULL,
    id_seguro    number(2)     NOT NULL,
    id_cliente   VARCHAR2(40)  NOT NULL,
    estado_envio NUMBER(1)     NOT NULL,
    fecha_envio  DATE          NOT NULL,
    obs_envio    VARCHAR2(100) NOT NULL,
    costo_envio  NUMBER(9, 2)  NOT NULL,
    CONSTRAINT envio_pk PRIMARY KEY (id_envio)
) TABLESPACE fv_env;


prompt Creando tabla estado_pedido.;
CREATE TABLE fv_user.estado_pedido
(
    id_estado   NUMBER(1)    NOT NULL,
    desc_estado VARCHAR2(30) NOT NULL,
    CONSTRAINT estado_pedido_pk PRIMARY KEY (id_estado)
) TABLESPACE fv_env;


prompt Creando tabla metodo_pago.;
CREATE TABLE fv_user.metodo_pago
(
    id_metpago   NUMBER(2)    NOT NULL,
    desc_metpago VARCHAR2(30) NOT NULL,
    constraint metodo_pago_pk primary key (id_metpago)
) tablespace fv_env;

prompt Creando tabla notificacion de pago.;
CREATE TABLE fv_user.notificacion_pago
(
    id_notificacion VARCHAR2(40) NOT NULL,
    id_pago       VARCHAR2(40) NOT NULL,
    id_cliente      VARCHAR2(40) NOT NULL,
    fecha_venta     DATE,
    cantidad        NUMBER(9, 2) DEFAULT 0,
    producto        VARCHAR2(50) NOT NULL,
    precio_unitario NUMBER(9, 2) DEFAULT 0,
    total_productos NUMBER(9, 2) DEFAULT 0,
    CONSTRAINT notificacion_pago_pk PRIMARY KEY (id_notificacion)
) TABLESPACE fv_env;


prompt Creando tabla de ofertas de productos.;
CREATE TABLE fv_user.oferta
(
    id_oferta        VARCHAR2(40)  NOT NULL,
    desc_oferta      VARCHAR2(100) NOT NULL,
    descuento_oferta NUMBER(2) DEFAULT 0,
    fecha_oferta     DATE      DEFAULT sysdate,
    tipo_oferta      NUMBER(1) DEFAULT 1,
    estado_oferta    NUMBER(1) DEFAULT 1,
    CONSTRAINT oferta_pk PRIMARY KEY (id_oferta)
) TABLESPACE fv_env;


prompt Creando tabla detalle_oferta.;
CREATE TABLE fv_user.oferta_detalle
(
    id_detalle     VARCHAR2(40) NOT NULL,
    id_oferta      VARCHAR2(40) NOT NULL,
    id_producto    VARCHAR2(40) NOT NULL,
    valor_original NUMBER(9, 2) DEFAULT 0,
    CONSTRAINT oferta_detalle_pk PRIMARY KEY (id_detalle)
) TABLESPACE fv_env;


prompt Creando tabla pago.;
CREATE TABLE fv_user.pago
(
    id_pago         VARCHAR2(40)  NOT NULL,
    id_metpago      NUMBER(2)     NOT NULL,
    id_pedido       VARCHAR2(40)  NOT NULL,
    fecha_pago      DATE          NOT NULL,
    monto_pago      NUMBER(9, 2)  NOT NULL,
    obs_pago        VARCHAR2(100) NOT NULL,
    pago_notificado number(1) default 0,
    constraint pago_pk primary key (id_pago)
) tablespace fv_env;


prompt Creando tabla pais.;
CREATE TABLE fv_user.pais
(
    id_pais      number(5) NOT NULL,
    nombre_pais  VARCHAR2(100),
    prefijo_pais VARCHAR2(6),
    constraint pais_pk primary key (id_pais)
) tablespace fv_env;


prompt Creando tabla pedido.;
CREATE TABLE fv_user.pedido
(
    id_pedido            VARCHAR2(40)        NOT NULL,
    id_condicion         NUMBER(2)           NOT NULL,
    id_cliente           VARCHAR2(40)        NOT NULL,
    fecha_pedido         DATE                NOT NULL,
    descuento_solicitado number(2) default 0 not null,
    obs_pedido           VARCHAR2(100),
    constraint pedido_pk primary key (id_pedido)
) tablespace fv_env;


prompt Creando tabla producto.;
CREATE TABLE fv_user.producto
(
    id_producto       VARCHAR2(40) NOT NULL,
    id_cliente        VARCHAR2(40) NOT NULL,
    id_categoria      NUMBER(2)    NOT NULL,
    nombre_producto   VARCHAR2(50) NOT NULL,
    obs_producto      VARCHAR2(100),
    valor_producto    NUMBER(9)    NOT NULL,
    cantidad_producto NUMBER(9, 2) NOT NULL,
    constraint producto_pk primary key (id_producto)
) tablespace fv_env;


prompt Creando tabla temporal de productos.;
CREATE TABLE fv_user.producto_temp
(
    id_producto       VARCHAR2(40) NOT NULL,
    id_cliente        VARCHAR2(40) NOT NULL,
    id_categoria      NUMBER(2)    NOT NULL,
    nombre_producto   VARCHAR2(50) NOT NULL,
    obs_producto      VARCHAR2(100),
    valor_producto    NUMBER(9)    NOT NULL,
    cantidad_producto NUMBER(9, 2) NOT NULL
) tablespace fv_env;


prompt Creando tabla de orden de despacho.;
CREATE TABLE fv_user.orden_despacho
(
    id_orden          VARCHAR2(40) NOT NULL,
    id_pedido         VARCHAR2(40) NOT NULL,
    fecha_preparacion DATE DEFAULT sysdate,
    fecha_retiro      DATE,
    obs_orden         VARCHAR2(100),
    CONSTRAINT orde_despacho_pk PRIMARY KEY (id_orden)
) TABLESPACE fv_env;


prompt Creando detalle de orden de despacho.;
CREATE TABLE fv_user.orden_detalle
(
    id       VARCHAR2(40) NOT NULL,
    id_orden VARCHAR2(40) NOT NULL,
    producto VARCHAR(50)  NOT NULL,
    valor    NUMBER(9, 2) DEFAULT 0,
    cantidad NUMBER(9, 2) DEFAULT 0,
    total    NUMBER(9, 2) DEFAULT 0,
    CONSTRAINT orden_detalle_pk PRIMARY KEY (id)
) TABLESPACE fv_env;



prompt Creando tabla resultado de pedido.;
CREATE TABLE fv_user.resultado_propuesto
(
    id_respuesta   VARCHAR2(40) NOT NULL,
    id_pedido      VARCHAR2(40) NOT NULL,
    id_producto    VARCHAR2(40) NOT NULL,
    costo_unitario NUMBER       NOT NULL,
    cantidad       NUMBER       NOT NULL,
    CONSTRAINT res_pro_pk PRIMARY KEY (id_respuesta)
) TABLESPACE fv_env;


prompt Creando tabla pie del resultado.;
CREATE TABLE fv_user.pie_pedido
(
    id_pieped             VARCHAR2(40) NOT NULL,
    id_pedido             VARCHAR2(40) NOT NULL,
    valor_neto            NUMBER       NOT NULL,
    valor_iva             NUMBER       NOT NULL,
    valor_total           NUMBER       NOT NULL,
    valor_descuento       NUMBER       NOT NULL,
    valor_total_descuento NUMBER       NOT NULL,
    CONSTRAINT pie_pedido_pk primary key (id_pieped)
) TABLESPACE fv_env;


prompt Creando tabla de resultado de subasta.;
create table fv_user.resultado_subasta
(
    id_resultado    varchar2(40) not null,
    id_subasta      varchar2(40) not null,
    id_cliente      varchar2(40) not null,
    valor_propuest  number(9, 2) default 0,
    fecha_propuesta date         default sysdate,
    constraint resultado_subasta_pk primary key (id_resultado)
) TABLESPACE fv_env;


prompt Creando tabla rol_usuario.;
CREATE TABLE fv_user.rol_usuario
(
    id_rol     NUMBER(2)    NOT NULL,
    nombre_rol VARCHAR2(50) NOT NULL,
    constraint rol_usuario_pk primary key (id_rol)
) tablespace fv_env;


prompt Creando tabla de seguimiento de pedidos.;
CREATE TABLE fv_user.seguimiento_pedido
(
    id_seguimiento VARCHAR2(40) NOT NULL,
    id_pedido      VARCHAR2(40) NOT NULL,
    id_estado      NUMBER(1) DEFAULT 1,
    fecha_proceso  DATE      DEFAULT sysdate,
    CONSTRAINT seguimiento_pk PRIMARY KEY (id_seguimiento)
) TABLESPACE fv_env;


prompt Creando tabla seguro.;
CREATE TABLE fv_user.seguro
(
    id_seguro        number(2)    NOT NULL,
    nombre_seguro    VARCHAR2(50) NOT NULL,
    compania_seguro  VARCHAR2(50) NOT NULL,
    primabase_seguro number(9, 2) not null,
    constraint seguro_pk primary key (id_seguro)
) tablespace fv_env;


prompt Creando tabla de subastas.;
CREATE TABLE fv_user.subasta
(
    id_subasta          VARCHAR2(40)  NOT NULL,
    id_pedido           VARCHAR2(40)  NOT NULL,
    fecha_subasta       DATE         DEFAULT sysdate,
    valor_porcentaje    number(5, 2) default 0,
    valor_propuesto     NUMBER(9, 2) DEFAULT 0,
    peso_comprometido   NUMBER(9, 2) DEFAULT 0,
    fecha_limite        DATE         DEFAULT sysdate,
    observacion_subasta VARCHAR2(100) NOT NULL,
    estado_subasta      number(1)    default 0,
    id_cliente          varchar2(40),
    valor_puja          number(9, 2) default 0,
    fecha_puja          date,
    observacion_puja    varchar(100),
    fecha_respuesta     date,
    CONSTRAINT subasta_pk PRIMARY KEY (id_subasta)
) TABLESPACE fv_env;


prompt Creando tabla tipo cierre.;
CREATE TABLE fv_user.tipo_cierre
(
    id_tipo_cierre   NUMBER(2)    NOT NULL,
    desc_tipo_cierre VARCHAR2(20) NOT NULL,
    CONSTRAINT tipo_cierre_pk PRIMARY KEY (id_tipo_cierre)
) TABLESPACE fv_env;


prompt Creando tabla tipo_transporte.;
CREATE TABLE fv_user.tipo_transporte
(
    id_tipo_transporte   NUMBER(2)    NOT NULL,
    desc_tipo_transporte VARCHAR2(30) NOT NULL,
    constraint tipo_transporte_pk primary key (id_tipo_transporte)
) tablespace fv_env;


prompt Creando tabla tipo_contrato.;
CREATE TABLE fv_user.tipo_contrato
(
    id_tipo_contrato   NUMBER(2)    NOT NULL,
    desc_tipo_contrato VARCHAR2(25) NOT NULL,
    constraint tipo_contrato_pk primary key (id_tipo_contrato)
) tablespace fv_env;


prompt Creando tabla usuario.;
CREATE TABLE fv_user.usuario
(
    id_usuario VARCHAR2(40)             NOT NULL,
    username   VARCHAR2(150)            NOT NULL,
    password   VARCHAR2(128)            NOT NULL,
    email      VARCHAR2(255)            NOT NULL,
    is_active  NUMBER(1)                NOT NULL,
    registro   TIMESTAMP WITH TIME ZONE NOT NULL,
    constraint usuario_pk primary key (id_usuario)
) tablespace fv_env;


prompt Creando tabla vehiculo.;
CREATE TABLE fv_user.vehiculo
(
    id_vehiculo             VARCHAR2(40)        NOT NULL,
    id_cliente              VARCHAR2(40)        NOT NULL,
    id_tipo_transporte      NUMBER(2)           NOT NULL,
    patente_vehiculo        VARCHAR2(15)        NOT NULL,
    modelo_vehiculo         VARCHAR2(50)        NOT NULL,
    capacidad_vehiculo      NUMBER(9, 2)        NOT NULL,
    disponibilidad_vehiculo NUMBER(1) DEFAULT 1 NOT NULL,
    observacion_vehiculo    VARCHAR2(100),
    CONSTRAINT vehiculo_pk PRIMARY KEY (id_vehiculo)
) TABLESPACE fv_env;



prompt Confirmando cambios.;
commit;
