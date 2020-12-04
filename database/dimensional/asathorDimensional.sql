-- Script: asathor-dimensional.sql
-- Descripción: Crea el modelo dimensional para feria virtual.
-- Alumno: Daniel García Asathor.

SET NOCOUNT ON;
PRINT FORMAT(getdate(), 'dd/MM/yyyy HH:mm') + ' Iniciando script.';
GO
USE master;                    
GO
PRINT FORMAT(getdate(), 'dd/MM/yyyy HH:mm') + ' Cambiando a ' + db_name();
GO
-- Creando la base de datos y sus elementos.
DROP DATABASE IF EXISTS DWFeriaVirtual 
GO
CREATE DATABASE DWFeriaVirtual   
GO
USE DWFeriaVirtual;
PRINT FORMAT(getdate(), 'dd/MM/yyyy HH:mm') + ' Cambiando a ' + db_name();
GO
CREATE TRIGGER trgDBMonitor ON DATABASE 
FOR CREATE_TABLE, ALTER_TABLE, DROP_TABLE  
  AS                          
BEGIN
    SET NOCOUNT ON;
    DECLARE @InfoEvento XML,@Accion VARCHAR(500),@Objeto VARCHAR(500);
    SET @InfoEvento = EVENTDATA();
    SET @Accion = @InfoEvento.value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(500)');
    SET @Objeto = @InfoEvento.value('(/EVENT_INSTANCE/SchemaName)[1]', 'varchar(250)') 
                   +'.'
                   +@InfoEvento.value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(250)');
    PRINT FORMAT(getdate(), 'dd/MM/yyyy HH:mm') + ' ' + @accion + ' ' + @Objeto + '.';
END;
GO


-- Creando las tablas del modelo dimensional.
CREATE TABLE dbo.dimCliente
(
    id_cliente        VARCHAR(40)  NOT NULL,
    nombre_cliente    VARCHAR(50)  NOT NULL,
    apellido_cliente  VARCHAR(50)  NOT NULL,
    nombre_completo   VARCHAR(150) NOT NULL,
    cantidad_comprasS BIGINT       DEFAULT 0 NOT NULL,
    cantidad_rechazos BIGINT       DEFAULT 0 NOT NULL,
    is_activo         TINYINT      DEFAULT 0 NOT NULL,
    estado_usuario    VARCHAR(50)  NOT NULL,
    fecha_registro    BIGINT       DEFAULT 0,
    CONSTRAINT DimCliente_PK PRIMARY KEY (ID_CLIENTE)
)
GO


CREATE TABLE dbo.dimProductor
(
    id_productor       VARCHAR(40)  NOT NULL,
    nombre_productor   VARCHAR(50)  NOT NULL,
    apellido_productor VARCHAR(50)  NOT NULL,
    nombre_completo    VARCHAR(150) NOT NULL,
    is_activo          TINYINT      DEFAULT 0 NOT NULL,
    estado_usuario     VARCHAR(50)  NOT NULL,
    fecha_registro     BIGINT       DEFAULT 0,
    CONSTRAINT DimProductor_PK PRIMARY KEY (ID_PRODUCTOR)
)
GO

CREATE TABLE dbo.dimProducto
(
    id_producto      VARCHAR(40) NOT NULL,
    producto         VARCHAR(50) NOT NULL,
    precio_kg        INT         DEFAULT 0,
    stock_disponible INT         DEFAULT 0,
    CONSTRAINT dimProducto_pk PRIMARY KEY (ID_producto)
)
GO

CREATE TABLE dbo.dimOrdenCompra
(
    id_orden                VARCHAR(40)  NOT NULL,
    fecha_orden             BIGINT       DEFAULT 0 NOT NULL,
    estado_orden            TINYINT      NOT NULL,
    descripcion_estado      VARCHAR(50)  NOT NULL,
    condicion_pago          TINYINT      NOT NULL,
    descripcion_condicion   VARCHAR(50)  NOT NULL,
    porcentaje_descuento    INT          DEFAULT 0,
    fecha_pago              BIGINT       DEFAULT 0,
    monto_pagado            BIGINT       DEFAULT 0,
    metodo_pago             TINYINT      DEFAULT 0,
    descripcion_metodo_pago VARCHAR(50),
    fecha_envio             BIGINT       DEFAULT 0,
    transportista           VARCHAR(150),
    costo_envio             INT          DEFAULT 0,
    seguro_asociado         VARCHAR(100),
    aseguradora             VARCHAR(100),
    prima_seguro            BIGINT       DEFAULT 0,
    CONSTRAINT dimOrdenCompra_pk PRIMARY KEY (ID_orden)
) 
GO


CREATE TABLE dbo.dimTiempo
(
    id_fecha     BIGINT      NOT NULL,
    FECHA        DATE        NOT NULL,
    DIA          INT         NOT NULL,
    NOMBRE_DIA   VARCHAR(15) NOT NULL,
    DIA_ANIO     INT         NOT NULL,
    Mes          INT         NOT NULL,
    NOMBRE_MES   VARCHAR(10) NOT NULL,
    DIAS_DEL_MES INT         NOT NULL,
    INICIO_MES   VARCHAR(15) NOT NULL,
    TERMINO_MES  VARCHAR(15) NOT NULL,
    ANIO         INT         NOT NULL,
    SEMANA       INT         NOT NULL,
    TRIMESTRE    INT         NOT NULL,
    SEMESTRE     INT         NOT NULL,
    CONSTRAINT fecha_pk PRIMARY KEY (ID_FECHA)
)
GO


CREATE TABLE dbo.factVenta
(
    id_fecha                       BIGINT      NOT NULL,
    id_orden                       VARCHAR(40) NOT NULL,
    id_cliente                     VARCHAR(40) NOT NULL,
    id_productor                   VARCHAR(40) NOT NULL,
    id_producto                    VARCHAR(40) NOT NULL,
    cantidad_productos_solicitados INT         DEFAULT 0,
    precio_por_kg_ofrecido         INT         DEFAULT 0,
    precio_productos               BIGINT      DEFAULT 0,
    tipo_cliente                   TINYINT     DEFAULT 0,
    descripcion_rol                VARCHAR(50) NOT NULL,
    categoria_producto             TINYINT     DEFAULT 0,
    descripcion_categoria          VARCHAR(50) NOT NULL,
    tiene_stock_disponible         TINYINT     DEFAULT 0,
    estado_producto                TINYINT     DEFAULT 0,
    descripcion_estado             VARCHAR(50),
    CONSTRAINT factVenta_fecha_fk FOREIGN KEY (id_fecha)
    REFERENCES dbo.dimTiempo (id_fecha),
    CONSTRAINT factVenta_orden_fk FOREIGN KEY (id_orden)
    REFERENCES dbo.dimOrdenCompra (id_orden),
    CONSTRAINT factVenta_cliente_fk FOREIGN KEY (id_cliente)
    REFERENCES dbo.dimCliente (id_cliente),
    CONSTRAINT factVenta_productor_fk FOREIGN KEY (id_productor)
    REFERENCES dbo.dimProductor (id_productor),
    CONSTRAINT factVenta_producto_fk FOREIGN KEY (id_producto)
    REFERENCES dbo.dimProducto (id_producto)
)
GO

PRINT FORMAT(getdate(), 'dd/MM/yyyy HH:mm') + ' Generando fechas.';
WITH
    Dates
    AS
    (
                    SELECT [Date] = CONVERT(DATETIME,'01/01/2010')
        UNION ALL
            SELECT
                [Date] = DATEADD(DAY, 1, [Date])
            FROM
                Dates
            WHERE
         Date < '01/01/2025'
    )
INSERT INTO dbo.dimTiempo
SELECT
    CONVERT(INT, [Date]) AS  ID_FECHA,
    CONVERT(DATE, [Date]) AS FECHA,
    datepart(DAY, [Date]) AS DIA,
    CASE
    WHEN datepart(dw, [Date])=1 THEN 'Lunes'
    WHEN datepart(dw, [Date])=2 THEN 'Martes'
    WHEN datepart(dw, [Date])=3 THEN 'Miercoles'
    WHEN datepart(dw, [Date])=4 THEN 'Jueves'
    WHEN datepart(dw, [Date])=5 THEN 'Viernes'
    WHEN datepart(dw, [Date])=6 THEN 'Sabado'
    ELSE 'Domingo'
    END AS NOMBRE_DIA,
    datepart(dayofyear, [Date]) AS DIA_ANIO,
    month([Date]) AS MES,
    CASE  
    WHEN datepart(month, [Date])=1 THEN 'Enero'
    WHEN datepart(month, [Date])=2 THEN 'Febrero'
    WHEN datepart(month, [Date])=3 THEN 'marzo'
    WHEN datepart(month, [Date])=4 THEN 'Abril'
    WHEN datepart(month, [Date])=5 THEN 'Mayo'
    WHEN datepart(month, [Date])=6 THEN 'Junio'
    WHEN datepart(month, [Date])=7 THEN 'Julio'
    WHEN datepart(month, [Date])=8 THEN 'Agosto'
    WHEN datepart(month, [Date])=9 THEN 'Septiembre'
    WHEN datepart(month, [Date])=10 THEN 'octubre'
    WHEN datepart(month, [Date])=11 THEN 'Noviembre'
WHEN datepart(month, [Date])=12 THEN 'Diciembre'
    ELSE ''
END AS NOMBRE_MES,
    datepart(day, dateadd(day, -1, dateadd(month, 1, DATEADD(MONTH, DATEDIFF(MONTH, 0,[Date]), 0)))) AS DIAS_DEL_MES,
    CONVERT(DATE, DATEADD(MONTH, DATEDIFF(MONTH, 0,[Date]), 0)) AS INICIO_MES,
    CONVERT(DATE, dateadd(day, -1, dateadd(month, 1, DATEADD(MONTH, DATEDIFF(MONTH, 0,[Date]), 0)))) AS TERMINO_MES,
    datepart(year, [Date]) AS ANIO,
    datepart(week, [Date]) AS SEMANA,
    datepart(qq, [Date]) AS TRIMESTRE,
    CONVERT(INT,(datepart(month, [Date])/7)+1) AS SEMESTRE
FROM
    Dates
OPTION
(MAXRECURSION
20000)

PRINT FORMAT(getdate(), 'dd/MM/yyyy HH:mm') + ' Finalizando script.';


    