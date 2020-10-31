-- Archivo: script_fv-pkgs.sql
--          Crea los packages para feria virtual.
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
prompt Creando paquetes de la base de datos.
prompt ----------------------------------------;
prompt;

prompt Creando paquete  de productos.;
CREATE OR REPLACE PACKAGE fv_user.pkg_Total_productos IS
    PROCEDURE nombre_producto(idped fv_user.pedido.id_pedido%TYPE);
    PROCEDURE sp_total_productos(idped fv_user.resultado_propuesto.id_pedido%TYPE);
        PROCEDURE sp_actualizar_productos(idped fv_user.pedido.id_pedido%TYPE);
END pkg_Total_productos;
/
CREATE OR REPLACE PACKAGE BODY fv_user.pkg_Total_productos IS
    PROCEDURE nombre_producto(
        idped fv_user.pedido.id_pedido%TYPE) AS

        nom_solicitado  fv_user.producto.nombre_producto%TYPE;
        cant_solicitado fv_user.producto.cantidad_producto%TYPE;
        id_prod         fv_user.producto.id_producto%TYPE;
        valor_prod      fv_user.producto.valor_producto%TYPE;
        cant_prod       fv_user.producto.cantidad_producto%TYPE;
        contador        NUMBER;
        indice_estado   NUMBER;
        stock           NUMBER;
        faltante        NUMBER;
        lrol            NUMBER;
        CURSOR names_cur IS
            SELECT nombre_producto
            FROM fv_user.detalle_pedido
            WHERE id_pedido = idped;
        names_t         names_cur%ROWTYPE;
        TYPE names_ntt IS TABLE OF names_t%TYPE; -- must use type
        l_names         names_ntt;
    BEGIN

        -- traspasando productos a tabla temporal.
        INSERT INTO fv_user.producto_temp 
            SELECT * FROM producto;

        -- limpiando resultados previos.
        DELETE FROM fv_user.resultado_propuesto
        WHERE id_pedido = idped;

        OPEN names_cur;
        FETCH names_cur BULK COLLECT INTO l_names;
        CLOSE names_cur;

        FOR indx IN 1..l_names.COUNT
            LOOP

                SELECT cl.id_rol
                INTO lrol
                FROM fv_user.pedido p
                         JOIN fv_user.cliente cl ON p.id_cliente = cl.id_cliente
                WHERE p.id_pedido = idped;

                IF lrol = 3 THEN

                    SELECT *
                    INTO valor_prod,cant_prod,id_prod
                    FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                          FROM fv_user.producto_temp
                          WHERE nombre_producto = l_names(indx).nombre_producto
                            AND cantidad_producto > 0
                            AND id_categoria = 1
                          GROUP BY valor_producto, cantidad_producto, id_producto
                          ORDER BY valor_producto)
                    WHERE ROWNUM = 1;

                    SELECT *
                    INTO cant_solicitado
                    FROM (SELECT cantidad
                          FROM fv_user.detalle_pedido
                          WHERE id_pedido = idped
                            AND fv_user.detalle_pedido.nombre_producto = l_names(indx).nombre_producto)
                    WHERE ROWNUM = 1;

                    indice_estado := cant_prod - cant_solicitado;

                    IF indice_estado >= 0 THEN
                        stock := cant_prod - cant_solicitado;

                        INSERT INTO fv_user.resultado_propuesto
                        VALUES (sys_guid(), idped, id_prod, valor_prod, cant_solicitado);

                        UPDATE fv_user.producto_temp
                        SET cantidad_producto = stock
                        WHERE id_producto = id_prod;

                    ELSIF indice_estado < 0 THEN

                        INSERT INTO fv_user.resultado_propuesto
                        VALUES (sys_guid(), idped, id_prod, valor_prod, cant_prod);

                        UPDATE fv_user.producto_temp
                        SET cantidad_producto = 0
                        WHERE id_producto = id_prod;

                        faltante := indice_estado * -1;

                        WHILE faltante > 0
                            LOOP

                                SELECT *
                                INTO valor_prod,cant_prod,id_prod
                                FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                                      FROM fv_user.producto_temp
                                      WHERE nombre_producto = l_names(indx).nombre_producto
                                        AND cantidad_producto != 0
                                        AND id_categoria = 2
                                      GROUP BY valor_producto, cantidad_producto, id_producto
                                      ORDER BY valor_producto)
                                WHERE ROWNUM = 1;

                                indice_estado := cant_prod - faltante;

                                IF indice_estado >= 0 THEN

                                    stock := cant_prod - faltante;

                                    INSERT INTO fv_user.resultado_propuesto
                                    VALUES (sys_guid(), idped, id_prod, valor_prod, faltante);

                                    UPDATE fv_user.producto_temp
                                    SET cantidad_producto = stock
                                    WHERE id_producto = id_prod;

                                    faltante := faltante - cant_prod;

                                ELSIF indice_estado < 0 THEN

                                    INSERT INTO fv_user.resultado_propuesto
                                    VALUES (sys_guid(), idped, id_prod, valor_prod, cant_prod);

                                    UPDATE fv_user.producto_temp
                                    SET cantidad_producto = 0
                                    WHERE id_producto = id_prod;

                                    faltante := faltante - cant_prod;

                                END IF;

                            END LOOP;

                    END IF;

                ELSIF lrol = 4 THEN

--El producto mas economico en base al nombre del detalle_pedido
                    SELECT *
                    INTO valor_prod,cant_prod,id_prod
                    FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                          FROM fv_user.producto_temp
                          WHERE nombre_producto = l_names(indx).nombre_producto
                            AND cantidad_producto > 0
                            AND id_categoria = 2
                          GROUP BY valor_producto, cantidad_producto, id_producto
                          ORDER BY valor_producto)
                    WHERE ROWNUM = 1;

--Datos del detalle
                    SELECT *
                    INTO cant_solicitado
                    FROM (SELECT cantidad
                          FROM fv_user.detalle_pedido
                          WHERE id_pedido = idped
                            AND nombre_producto = l_names(indx).nombre_producto)
                    WHERE ROWNUM = 1;

                    indice_estado := cant_prod - cant_solicitado;

                    IF indice_estado >= 0 THEN
                        stock := cant_prod - cant_solicitado;

                        INSERT INTO fv_user.resultado_propuesto
                        VALUES (sys_guid(), idped, id_prod, valor_prod, cant_solicitado);

                        UPDATE fv_user.producto_temp
                        SET cantidad_producto = stock
                        WHERE id_producto = id_prod;

                    ELSIF indice_estado < 0 THEN

                        INSERT INTO fv_user.resultado_propuesto
                        VALUES (sys_guid(), idped, id_prod, valor_prod, cant_prod);

                        UPDATE fv_user.producto_temp
                        SET cantidad_producto = 0
                        WHERE id_producto = id_prod;

                        faltante := indice_estado * -1;

                        WHILE faltante > 0
                            LOOP

                                SELECT *
                                INTO valor_prod,cant_prod,id_prod
                                FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                                      FROM fv_user.producto_temp
                                      WHERE nombre_producto = l_names(indx).nombre_producto
                                        AND cantidad_producto != 0
                                        AND id_categoria = 2
                                      GROUP BY valor_producto, cantidad_producto, id_producto
                                      ORDER BY valor_producto)
                                WHERE ROWNUM = 1;

                                indice_estado := cant_prod - faltante;

                                IF indice_estado >= 0 THEN

                                    stock := cant_prod - faltante;

                                    INSERT INTO fv_user.resultado_propuesto
                                    VALUES (sys_guid(), idped, id_prod, valor_prod, faltante);

                                    UPDATE fv_user.producto_temp
                                    SET cantidad_producto = stock
                                    WHERE id_producto = id_prod;

                                    faltante := faltante - cant_prod;

                                ELSIF indice_estado < 0 THEN

                                    INSERT INTO fv_user.resultado_propuesto
                                    VALUES (sys_guid(), idped, id_prod, valor_prod, cant_prod);

                                    UPDATE fv_user.producto_temp
                                    SET cantidad_producto = 0
                                    WHERE id_producto = id_prod;

                                    faltante := faltante - cant_prod;

                                END IF;

                            END LOOP;

                    END IF;

                END IF;
            END LOOP;
        COMMIT;
    EXCEPTION
        WHEN no_data_found THEN
            dbms_output.put_line('No está disponible el producto');

    DELETE FROM fv_user.producto_temp;
    COMMIT;
    END nombre_producto;

    PROCEDURE sp_total_productos(
        idped fv_user.resultado_propuesto.id_pedido%TYPE) IS
        descuento       NUMBER;
        valor_neto      NUMBER;
        valor_iva       NUMBER;
        valor_descuento NUMBER;
        valor_condesc   NUMBER;
        valor_sindesc   NUMBER;
        CURSOR c1 IS
            SELECT id_pedido
            FROM fv_user.resultado_propuesto
            WHERE id_pedido = idped;
    BEGIN
        -- limpiando antes de procesar.
        DELETE FROM fv_user.pie_pedido
        WHERE id_pedido = idped;
        FOR r1 IN c1
            LOOP
                SELECT SUM(costo_unitario * cantidad)
                INTO valor_neto
                FROM fv_user.resultado_propuesto
                WHERE id_pedido = idped;
            END LOOP;

        SELECT descuento_solicitado
        INTO descuento
        FROM fv_user.pedido
        WHERE id_pedido = idped;

        IF descuento > 0 THEN
            valor_iva := valor_neto * 0.19;
            valor_sindesc := valor_neto + valor_iva;
            valor_descuento := (valor_sindesc * descuento) / 100;
            valor_condesc := valor_sindesc - valor_descuento;

            INSERT INTO fv_user.pie_pedido
            VALUES (sys_guid(), idped, valor_neto, valor_iva, valor_sindesc, valor_descuento, valor_condesc);
        ELSE
            valor_iva := valor_neto * 0.19;
            valor_sindesc := valor_neto + valor_iva;

            INSERT INTO fv_user.pie_pedido
            VALUES (sys_guid(), idped, valor_neto, valor_iva, valor_sindesc, 0, valor_sindesc);
        END IF;

    EXCEPTION WHEN no_data_found THEN
            dbms_output.put_line('No hay una propuesta para realizar el total');

    END sp_total_productos;

        PROCEDURE sp_actualizar_productos(
                idped fv_user.pedido.id_pedido%TYPE) AS
                lcantidad fv_user.producto.cantidad_producto%TYPE;
                cantidad_producto fv_user.producto.cantidad_producto%TYPE;
                stock NUMBER;
        CURSOR cur_producto IS
                SELECT id_producto
                FROM fv_user.resultado_propuesto
                WHERE id_pedido =idped;
       idproducto cur_producto%ROWTYPE;
       TYPE producto_id IS TABLE OF idproducto%TYPE; -- must use type
       l_idproducto producto_id;
       
    BEGIN
       OPEN  cur_producto;
       FETCH cur_producto BULK COLLECT INTO l_idproducto;
       CLOSE cur_producto;
       FOR indx IN 1..l_idproducto.COUNT LOOP
            SELECT rp.cantidad , p.cantidad_producto
            INTO lcantidad,cantidad_producto
            FROM fv_user.resultado_propuesto rp JOIN fv_user.producto p ON rp.id_producto = p.id_producto
            WHERE rp.id_producto = l_idproducto(indx).id_producto  AND
                rp.id_pedido = idped ;
        stock:= cantidad_producto-lcantidad;
        UPDATE fv_user.producto
        SET cantidad_producto=stock
        WHERE id_producto=l_idproducto(indx).id_producto;
    END LOOP;
END sp_actualizar_productos;

END pkg_Total_productos;
/


prompt Confirmando cambios.;
COMMIT;