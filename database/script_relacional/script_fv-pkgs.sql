-- Archivo: script_fv-pkgs.sql
--          Crea los packages para feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;

prompt;
prompt Creando paquetes de la base de datos.
prompt ----------------------------------------;


prompt Creando paquete  de productos.;
CREATE OR REPLACE PACKAGE fv_user.pkg_Total_productos IS
    PROCEDURE sp_insertar_producto(idresultado varchar2,idpedido varchar2,idproducto varchar2,valor_producto number,cantidad number);
    PROCEDURE sp_actualizar_producto(idproducto varchar2,stock number);
    FUNCTION  fn_cantidad_solicitado(idpedido varchar2,nombreproducto varchar2) return number;
    PROCEDURE sp_nombre_producto(idpedido fv_user.pedido.id_pedido%TYPE);
    PROCEDURE sp_total_productos(idpedido fv_user.resultado_propuesto.id_pedido%TYPE);
    procedure sp_actualiza(idpedido fv_user.pedido.id_pedido%type);
END pkg_Total_productos;
/
create or replace PACKAGE BODY  fv_user.pkg_Total_productos IS

    PROCEDURE sp_insertar_producto(
        idresultado varchar2,idpedido varchar2,idproducto varchar2,valor_producto number,cantidad number)as
    BEGIN

        INSERT INTO fv_user.resultado_propuesto
        VALUES (idresultado,idpedido,idproducto,valor_producto,cantidad);
    END sp_insertar_producto;


    PROCEDURE sp_actualizar_producto(
        idproducto varchar2,stock number) is
    begin

        update fv_user.producto_temp
        set cantidad_producto=stock
        where id_producto=idproducto;
    end sp_actualizar_producto;

    FUNCTION fn_cantidad_solicitado(
        idpedido varchar2,nombreproducto varchar2
    ) return number
    as
        cantidad_solicitado number;
    begin
        SELECT *
        INTO cantidad_solicitado
        FROM (SELECT cantidad
              FROM fv_user.detalle_pedido
              WHERE id_pedido = idpedido
                AND fv_user.detalle_pedido.nombre_producto = nombreproducto)
        WHERE ROWNUM = 1;
        return cantidad_solicitado;
    end fn_cantidad_solicitado;


    PROCEDURE sp_nombre_producto(
        idpedido fv_user.pedido.id_pedido%TYPE) AS

        cantidad_solicitado number;
        idproducto      fv_user.producto.id_producto%TYPE;
        valorproducto   fv_user.producto.valor_producto%TYPE;
        cantidadproducto fv_user.producto.cantidad_producto%TYPE;
        indice_estado   NUMBER;
        stock           NUMBER;
        faltante        NUMBER;
        lrol            NUMBER;

        CURSOR names_cur IS
            SELECT nombre_producto
            FROM fv_user.detalle_pedido
            WHERE id_pedido = idpedido;
        names_t         names_cur%ROWTYPE;
        TYPE names_ntt IS TABLE OF names_t%TYPE; -- must use type
        l_names         names_ntt;
    BEGIN

        -- traspasando productos a tabla temporal.
        INSERT INTO fv_user.producto_temp
        SELECT * FROM producto;

        -- limpiando resultados previos.
        DELETE FROM fv_user.resultado_propuesto
        WHERE id_pedido = idpedido;

        OPEN names_cur;
        FETCH names_cur BULK COLLECT INTO l_names;
        CLOSE names_cur;

        FOR indx IN 1..l_names.COUNT
            LOOP

                SELECT cl.id_rol
                INTO lrol
                FROM fv_user.pedido p
                         JOIN fv_user.cliente cl ON p.id_cliente = cl.id_cliente
                WHERE p.id_pedido = idpedido;

                if lrol = 3 then
                    SELECT *
                    INTO valorproducto,cantidadproducto,idproducto
                    FROM (SELECT MIN(valor_producto), cantidad_producto,id_producto
                          fROM fv_user.producto_temp
                          WHERE upper(nombre_producto) = upper(l_names(indx).nombre_producto)
                            and cantidad_producto >= 0
                            AND id_categoria = 1
                          GROUP BY valor_producto, cantidad_producto, id_producto
                          ORDER BY valor_producto)
                    WHERE ROWNUM = 1;

                    cantidad_solicitado:=fn_cantidad_solicitado(idpedido,upper(l_names(indx).nombre_producto));

                    if cantidadproducto > 0 then
                        indice_estado := cantidadproducto - cantidad_solicitado;
                        if indice_estado >= 0 THEN
                            stock := cantidadproducto - cantidad_solicitado;

                            sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidad_solicitado);
                            sp_actualizar_producto(idproducto,stock);

                        elsif indice_estado < 0 THEN
                            sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidadproducto);
                            sp_actualizar_producto(idproducto,0);

                            faltante := indice_estado * -1;

                            WHILE faltante > 0
                                LOOP
                                    begin
                                        SELECT *
                                        INTO valorproducto,cantidadproducto,idproducto
                                        FROM (SELECT MIN(valor_producto), cantidad_producto,id_producto
                                              FROM fv_user.producto_temp
                                              WHERE upper(nombre_producto) = upper(l_names(indx).nombre_producto)
                                                AND cantidad_producto > 0
                                                AND id_categoria = 1
                                              GROUP BY valor_producto, cantidad_producto, id_producto
                                              ORDER BY valor_producto)
                                        WHERE ROWNUM = 1;

                                    exception
                                        when no_data_found then
                                            faltante := 0;
                                    end;

                                    indice_estado := cantidadproducto - faltante;

                                    IF indice_estado >= 0 THEN

                                        stock := cantidadproducto - faltante;

                                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,faltante);
                                        sp_actualizar_producto(idproducto,stock);

                                        faltante := faltante - cantidadproducto;

                                    ELSIF indice_estado < 0 THEN

                                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidadproducto);
                                        sp_actualizar_producto(idproducto,0);

                                        faltante := faltante - cantidadproducto;

                                    END IF;

                                END LOOP;

                        end if;
                    elsif cantidadproducto = 0 then

                        sp_insertar_producto(sys_guid,idpedido,idproducto,0,0);

                    end if;

                elsif lrol = 4 then

                    SELECT *
                    INTO valorproducto,cantidadproducto,idproducto
                    FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                          FROM fv_user.producto_temp
                          WHERE upper(nombre_producto) = upper(l_names(indx).nombre_producto)
                            AND cantidad_producto >= 0
                            AND id_categoria = 2
                          GROUP BY valor_producto, cantidad_producto, id_producto
                          ORDER BY valor_producto)
                    WHERE ROWNUM = 1;

                    cantidad_solicitado:=fn_cantidad_solicitado(idpedido,upper(l_names(indx).nombre_producto));

                    if cantidadproducto > 0 then
                        indice_estado := cantidadproducto - cantidad_solicitado;
                        if indice_estado >= 0 THEN
                            stock := cantidadproducto - cantidad_solicitado;

                            sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidad_solicitado);
                            sp_actualizar_producto(idproducto,stock);

                        elsif indice_estado < 0 THEN
                            sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidadproducto);
                            sp_actualizar_producto(idproducto,0);

                            faltante := indice_estado * -1;

                            WHILE faltante > 0
                                LOOP
                                    begin
                                        SELECT *
                                        INTO valorproducto,cantidadproducto,idproducto
                                        FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                                              FROM fv_user.producto_temp
                                              WHERE upper(nombre_producto) = upper(l_names(indx).nombre_producto)
                                                AND cantidad_producto > 0
                                                AND id_categoria = 2
                                              GROUP BY valor_producto, cantidad_producto, id_producto
                                              ORDER BY valor_producto)
                                        WHERE ROWNUM = 1;

                                    exception
                                        when no_data_found then
                                            faltante := 0;
                                    end;

                                    indice_estado := cantidadproducto - faltante;

                                    IF indice_estado >= 0 THEN

                                        stock := cantidadproducto - faltante;

                                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,faltante);
                                        sp_actualizar_producto(idproducto,stock);

                                        faltante := faltante - cantidadproducto;

                                    ELSIF indice_estado < 0 THEN

                                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidadproducto);
                                        sp_actualizar_producto(idproducto,0);

                                        faltante := faltante - cantidadproducto;

                                    END IF;

                                END LOOP;

                        end if;

                    elsif cantidadproducto = 0 then
                        sp_insertar_producto(sys_guid,idpedido,idproducto,0,0);

                    end if;

                end if;

            END LOOP;
        DELETE FROM fv_user.producto_temp;
    END sp_nombre_producto;

    PROCEDURE sp_total_productos(
        idpedido fv_user.resultado_propuesto.id_pedido%TYPE) IS
        descuento       NUMBER;
        comision        number;
        id       varchar2(40);
        valor_neto      NUMBER;
        valor_iva       NUMBER;
        valor_descuento NUMBER;
        valor_condesc   NUMBER;
        valor_sindesc   NUMBER;
        CURSOR c1 IS
            SELECT id_pedido
            FROM fv_user.resultado_propuesto
            WHERE id_pedido = idpedido;
    BEGIN
        -- limpiando antes de procesar.
        DELETE FROM fv_user.pie_pedido
        WHERE id_pedido = idpedido;

        FOR r1 IN c1
            LOOP
                SELECT SUM(costo_unitario * cantidad)
                INTO valor_neto
                FROM fv_user.resultado_propuesto
                WHERE id_pedido = idpedido;
            END LOOP;

        select nvl(c.comision_contrato,20) , p.descuento_solicitado, p.id_pedido
        into comision,descuento,id
        from cliente cli join contrato_cliente cc on cli.id_cliente = cc.id_cliente
                         join contrato c on c.id_contrato = cc.id_contrato
                         join producto pro on pro.id_cliente = cli.id_cliente
                         join resultado_propuesto rp on rp.id_producto = pro.id_producto
                         join pedido p on rp.id_pedido = p.id_pedido
        where p.id_pedido = idpedido
        order by cc.fecha_registro desc FETCH FIRST ROW ONLY;


        IF descuento > 0 THEN

            --subtotal
            valor_iva := valor_neto + ((valor_neto * comision/100));
            --neto
            valor_sindesc := valor_iva - ((descuento * valor_iva)/100);
            --impuesto
            valor_descuento :=(valor_sindesc * 19) / 100;
            --total a pagar
            valor_condesc := valor_sindesc + valor_descuento;

            INSERT INTO fv_user.pie_pedido
            VALUES (sys_guid(), idpedido, valor_neto, valor_iva, valor_sindesc, valor_descuento, valor_condesc);

        ELSE

            --subtotal
            valor_iva := valor_neto + ((valor_neto * comision/100));
            --neto
            valor_sindesc := valor_iva;
            --impuesto
            valor_descuento :=(valor_sindesc * 19) / 100;
            --total a pagar
            valor_condesc := valor_sindesc + valor_descuento;

            INSERT INTO fv_user.pie_pedido
            VALUES (sys_guid(), idpedido, valor_neto, valor_iva, valor_sindesc, 0, valor_sindesc);

        END IF;

    EXCEPTION

        WHEN no_data_found THEN
            dbms_output.put_line('No hay una propuesta para realizar el total');
    END sp_total_productos;

    procedure sp_actualiza(
        idpedido fv_user.pedido.id_pedido%type
    ) as

        idproducto fv_user.producto.id_producto%type;
        cantidadpropuesto fv_user.resultado_propuesto.cantidad%type;
        cantidadproducto fv_user.producto.cantidad_producto%type;
        stock number;

        cursor c1 is
            select id_producto
            from fv_user.resultado_propuesto
            where id_pedido = idpedido;

    begin

        OPEN c1;
        LOOP
            FETCH c1 INTO idproducto;
            EXIT WHEN c1%NOTFOUND;

            select cantidad
            into cantidadpropuesto
            from fv_user.resultado_propuesto
            where id_pedido = idpedido and id_producto = idproducto;

            select cantidad_producto
            into cantidadproducto
            from fv_user.producto
            where id_producto = idproducto;

            stock:= cantidadproducto-cantidadpropuesto;

            update fv_user.producto
            set cantidad_producto = stock
            where id_producto = idproducto;

        end loop;
    end sp_actualiza;

END pkg_Total_productos;
/

prompt Confirmando cambios.;
COMMIT;