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

CREATE OR REPLACE PACKAGE BODY fv_user.pkg_Total_productos IS

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

        IF lrol = 3 THEN

                    SELECT *
                    INTO valorproducto,cantidadproducto,idproducto
                    FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                          FROM fv_user.producto_temp
                          WHERE nombre_producto = l_names(indx).nombre_producto
                            AND cantidad_producto > 0
                            AND id_categoria = 1
                          GROUP BY valor_producto, cantidad_producto, id_producto
                          ORDER BY valor_producto)
                    WHERE ROWNUM = 1;

                    
            cantidad_solicitado:=fn_cantidad_solicitado(idpedido,l_names(indx).nombre_producto);   
                    

                    indice_estado := cantidadproducto - cantidad_solicitado;

                    IF indice_estado >= 0 THEN
                        stock := cantidadproducto - cantidad_solicitado;

                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidad_solicitado);
                        sp_actualizar_producto(idproducto,stock);

                    ELSIF indice_estado < 0 THEN

                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidadproducto);
                        sp_actualizar_producto(idproducto,0);

                        faltante := indice_estado * -1;

                        WHILE faltante > 0
                            LOOP

                                SELECT *
                                INTO valorproducto,cantidadproducto,idproducto
                                FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                                      FROM fv_user.producto_temp
                                      WHERE nombre_producto = l_names(indx).nombre_producto
                                        AND cantidad_producto != 0
                                        AND id_categoria = 1
                                      GROUP BY valor_producto, cantidad_producto, id_producto
                                      ORDER BY valor_producto)
                                WHERE ROWNUM = 1;

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

                    END IF;

            ELSIF lrol = 4 THEN

--El producto mas economico en base al nombre del detalle_pedido
                    SELECT *
                    INTO valorproducto,cantidadproducto,idproducto
                    FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                          FROM fv_user.producto_temp
                          WHERE nombre_producto = l_names(indx).nombre_producto
                            AND cantidad_producto > 0
                            AND id_categoria = 2
                          GROUP BY valor_producto, cantidad_producto, id_producto
                          ORDER BY valor_producto)
                    WHERE ROWNUM = 1;

--Datos del detalle
            cantidad_solicitado:=fn_cantidad_solicitado(idpedido,l_names(indx).nombre_producto);

                    indice_estado := cantidadproducto - cantidad_solicitado;

                    IF indice_estado >= 0 THEN
                        stock := cantidadproducto - cantidad_solicitado;
                        
                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidad_solicitado);
                        sp_actualizar_producto(idproducto,stock);

                    ELSIF indice_estado < 0 THEN

                        sp_insertar_producto(sys_guid,idpedido,idproducto,valorproducto,cantidadproducto);
                        sp_actualizar_producto(idproducto,0);

                        faltante := indice_estado * -1;

                        WHILE faltante > 0
                            LOOP

                                SELECT *
                                INTO valorproducto,cantidadproducto,idproducto
                                FROM (SELECT MIN(valor_producto), cantidad_producto, id_producto
                                      FROM fv_user.producto_temp
                                      WHERE nombre_producto = l_names(indx).nombre_producto
                                        AND cantidad_producto != 0
                                        AND id_categoria = 2
                                      GROUP BY valor_producto, cantidad_producto, id_producto
                                      ORDER BY valor_producto)
                                WHERE ROWNUM = 1;

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

                    END IF;

                END IF;
            END LOOP;

    EXCEPTION
        WHEN no_data_found THEN
            dbms_output.put_line('No estÃ¡ disponible el producto');

    DELETE FROM fv_user.producto_temp;
    END sp_nombre_producto;

    PROCEDURE sp_total_productos(
        idpedido fv_user.resultado_propuesto.id_pedido%TYPE) IS
        descuento       NUMBER;
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

        SELECT descuento_solicitado
        INTO descuento
        FROM fv_user.pedido
        WHERE id_pedido = idpedido;

        IF descuento > 0 THEN

            valor_iva := valor_neto * 0.19;
            valor_sindesc := valor_neto + valor_iva;
            valor_descuento := (valor_sindesc * descuento) / 100;
            valor_condesc := valor_sindesc - valor_descuento;

            INSERT INTO fv_user.pie_pedido
            VALUES (sys_guid(), idpedido, valor_neto, valor_iva, valor_sindesc, valor_descuento, valor_condesc);

        ELSE

            valor_iva := valor_neto * 0.19;
            valor_sindesc := valor_neto + valor_iva;

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
where id_producto=idproducto;

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