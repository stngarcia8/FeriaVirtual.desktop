-- Archivo: script_fv-fkeys.sql
--          Crea las claves foraneas de las tablas de feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
ALTER SESSION SET NLS_LANGUAGE= 'SPANISH' NLS_TERRITORY= 'Spain' NLS_CURRENCY= '$' NLS_ISO_CURRENCY= 'AMERICA' NLS_NUMERIC_CHARACTERS= '.,' NLS_CALENDAR= 'GREGORIAN' NLS_DATE_FORMAT= 'DD-MON-RR' NLS_DATE_LANGUAGE= 'SPANISH' NLS_SORT= 'BINARY';


prompt;
prompt Creando claves foraneas para tablas de la base de datos.;
prompt ----------------------------------------------------------;


prompt Claves foraneas para tabla cierre_pedido.;
alter table fv_user.cierre_pedido
    add constraint cierre_pedido_pedido_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido)
            ON DELETE CASCADE
    add constraint cierre_pedido_tipocierre_fk foreign key (id_tipo_cierre)
        REFERENCES fv_user.tipo_cierre (id_tipo_cierre);


prompt Clave foranea para  ciudad.;
ALTER TABLE fv_user.ciudad
    ADD CONSTRAINT ciudad_pais_fk FOREIGN KEY (id_pais)
        REFERENCES fv_user.pais (id_pais)
            ON DELETE CASCADE;


prompt Claves foraneas para  tabla cliente.;
ALTER TABLE fv_user.cliente
    ADD CONSTRAINT cliente_rol_usuario_fk FOREIGN KEY (id_rol)
        REFERENCES fv_user.rol_usuario (id_rol)
    ADD CONSTRAINT cliente_usuario_fk FOREIGN KEY (id_usuario)
        REFERENCES fv_user.usuario (id_usuario);


prompt Clave foranea para  tabla contrato.;
ALTER TABLE fv_user.contrato
    ADD CONSTRAINT contrato_tipocontrato_fk FOREIGN KEY (id_tipo_contrato)
        REFERENCES fv_user.tipo_contrato (id_tipo_contrato);


prompt Claves foraneas para  tabla contrato_cliente.;
ALTER TABLE fv_user.contrato_cliente
    ADD CONSTRAINT contrato_cliente_cliente_fk FOREIGN KEY (id_cliente)
        REFERENCES fv_user.cliente (id_cliente)
    ADD CONSTRAINT contrato_cliente_contrato_fk FOREIGN KEY (id_contrato)
        REFERENCES fv_user.contrato (id_contrato)
            ON DELETE CASCADE;


prompt Clave foranea para  tabla dato_comercial.;
ALTER TABLE fv_user.dato_comercial
    ADD CONSTRAINT dato_comercial_ciudad_fk FOREIGN KEY (id_ciudad)
        REFERENCES fv_user.ciudad (id_ciudad)
    ADD CONSTRAINT dato_comercial_cliente_fk FOREIGN KEY (id_cliente)
        REFERENCES fv_user.cliente (id_cliente);


prompt Clave foranea para  tabla detalle_pedido.
ALTER TABLE fv_user.detalle_pedido
    ADD CONSTRAINT detalle_pedido_pedido_fk FOREIGN KEY ( id_pedido )
        REFERENCES fv_user.pedido ( id_pedido )
        ON
DELETE CASCADE;


prompt Claves foraneas para  tabla empleado.;
ALTER TABLE fv_user.empleado
    ADD CONSTRAINT empleado_rol_usuario_fk FOREIGN KEY (id_rol)
        REFERENCES fv_user.rol_usuario (id_rol)
    ADD CONSTRAINT empleado_usuario_fk FOREIGN KEY (id_usuario)
        REFERENCES fv_user.usuario (id_usuario);


prompt Claves foraneas para  tabla envio.;
ALTER TABLE fv_user.envio
    ADD CONSTRAINT envio_cliente_fk FOREIGN KEY (id_cliente)
        REFERENCES fv_user.cliente (id_cliente)
    ADD CONSTRAINT envio_pedido_fk FOREIGN KEY (id_pedido)
        REFERENCES fv_user.pedido (id_pedido)
            on delete cascade
    ADD CONSTRAINT envio_seguro_fk FOREIGN KEY (id_seguro)
        REFERENCES fv_user.seguro (id_seguro);


prompt Clave foranea para tabla notificacion_pago.;
ALTER TABLE fv_user.notificacion_pago
    ADD CONSTRAINT  notificacion_pago_pago_fk FOREIGN KEY (id_pago)
        REFERENCES fv_user.pago (id_pago)
            ON DELETE CASCADE;


prompt Claves foraneas para  tabla pago.;
ALTER TABLE fv_user.pago
    ADD CONSTRAINT pago_metodo_pago_fk FOREIGN KEY (id_metpago)
        REFERENCES fv_user.metodo_pago (id_metpago)
    ADD CONSTRAINT pago_pedido_fk FOREIGN KEY (id_pedido)
        REFERENCES fv_user.pedido (id_pedido)
            on delete cascade;


prompt Claves foraneas para tabla de detalle de oferta.;
ALTER TABLE fv_user.oferta_detalle
    add constraint detalleoferta_oferta_fk foreign key (id_oferta)
        references fv_user.oferta (id_oferta)
            ON delete cascade
    add constraint detalleoferta_producto_fk foreign key (id_producto)
        references fv_user.producto (id_producto);


prompt Clave foranea para tabla orden_despacho.;
ALTER TABLE fv_user.orden_despacho
    ADD CONSTRAINT orden_despacho_pedido_fk FOREIGN KEY (id_pedido)
        REFERENCES fv_user.pedido (id_pedido)
            ON DELETE CASCADE;


prompt Clave primaria para tabla de detalle de orden.;
ALTER TABLE fv_user.orden_detalle
    ADD CONSTRAINT orden_detalle_orden_fk FOREIGN KEY (id_orden)
        REFERENCES fv_user.orden_despacho (id_orden)
            ON DELETE CASCADE;


prompt Claves foraneas para  tabla pedido.;
ALTER TABLE fv_user.pedido
    ADD CONSTRAINT pedido_cliente_fk FOREIGN KEY (id_cliente)
        REFERENCES fv_user.cliente (id_cliente)
    add constraint pedido_condicionpago_fk foreign key (id_condicion)
        references fv_user.condicion_pago (id_condicion);


prompt Claves foraneas para  tabla producto.;
ALTER TABLE fv_user.producto
    ADD CONSTRAINT producto_cliente_fk FOREIGN KEY (id_cliente)
        REFERENCES fv_user.cliente (id_cliente)
    ADD CONSTRAINT producto_categoria_producto_fk FOREIGN KEY (ID_CATEGORIA)
        REFERENCES FV_USER.CATEGORIA_PRODUCTO (ID_CATEGORIA);


prompt Claves foraneas para  tabla resultado pedido.;
Alter table fv_user.resultado_propuesto
    ADD constraint resultado_propuesto_pedido_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido)
            ON DELETE CASCADE
    ADD constraint resultado_propuesto_producto_fk foreign key (id_producto)
        references fv_user.producto (id_producto);


prompt Clave foranea para  tabla pie de pedido.;
Alter table fv_user.pie_pedido
    ADD constraint pie_pedido_pedido_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido)
            ON DELETE CASCADE;


prompt Clave foranea para tabla de resultado de subastas.;
alter table fv_user.resultado_subasta
    add constraint resultadosubasta_subasta_fk foreign key (id_subasta)
        references fv_user.subasta (id_subasta)
            on delete cascade
    add constraint resultadosubasta_cliente_fk foreign key (id_cliente)
        references fv_user.cliente (id_cliente);


prompt Claves foraneas para  tabla seguimiento_pedido.;
ALTER TABLE fv_user.seguimiento_pedido
    add constraint seguimiento_pedido_seguimiento_fk foreign key (id_pedido)
        references fv_user.pedido (id_pedido)
            ON DELETE CASCADE
    add constraint seguimiento_estado_seguimiento_fk foreign key (id_estado)
        references fv_user.estado_pedido (id_estado);


prompt Clave foranea para  tabla subasta.;
ALTER TABLE fv_user.subasta
    ADD CONSTRAINT subasta_pedido_fk FOREIGN KEY (id_pedido)
        REFERENCES fv_user.pedido (id_pedido)
            ON DELETE CASCADE;


prompt Claves foraneas para  tabla vehiculo.;
ALTER TABLE fv_user.vehiculo
    ADD constraint vehiculo_cliente_vehiculo_fk foreign key (id_cliente)
        references fv_user.cliente (id_cliente)
    add constraint vehiculo_tipotrans_fk foreign key (id_tipo_transporte)
        references fv_user.tipo_transporte (id_tipo_transporte);


prompt Confirmando cambios.;
commit;
