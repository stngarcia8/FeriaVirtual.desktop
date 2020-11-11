-- Archivo: script_fv-norm.sql
--      Aujusta los registros de pruebas.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.

SET ECHO OFF;
set feedback off;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
ALTER SESSION SET CURRENT_SCHEMA = fv_user;
ALTER SESSION SET NLS_LANGUAGE= 'SPANISH' NLS_TERRITORY= 'Spain' NLS_CURRENCY= '$' NLS_ISO_CURRENCY= 'AMERICA' NLS_NUMERIC_CHARACTERS= '.,' NLS_CALENDAR= 'GREGORIAN' NLS_DATE_FORMAT= 'DD-MON-RR' NLS_DATE_LANGUAGE= 'SPANISH' NLS_SORT= 'BINARY';


prompt;
prompt Ajustando registros iniciales.;
prompt ----------------------------------------;


prompt Actualizando giro comercial de transportistas.;
UPDATE fv_user.dato_comercial
SET giro_comercial = 'Transportes y fletes'
WHERE id_cliente IN (SELECT id_cliente FROM fv_user.cliente WHERE id_rol = 6);


prompt "Eliminando algunos productos para diferenciar entre cliente externo e interno.;"
delete
from fv_user.producto
where id_categoria = 2
  and nombre_producto in ('Almendras', 'Frutillas', 'Mandarinas', 'Paltas', 'Ciruelas', 'Cerezas', 'Guindas', 'Palta Hass');

prompt Normalizando nombres de productos y observacion a mayusculas.;
UPDATE fv_user.producto
SET nombre_producto = TRIM(upper(nombre_producto)),
    obs_producto    = TRIM(upper(obs_producto));


prompt Normalizando vehiculos a mayusculas.;
update fv_user.vehiculo
set patente_vehiculo     = upper(patente_vehiculo),
    modelo_vehiculo      = upper(modelo_vehiculo),
    observacion_vehiculo = upper(observacion_vehiculo);

prompt Modificando email de clientes para pruebas de envio de correos.;
update fv_user.dato_comercial
set email_comercial = 'stngarcia8@gmail.com';



prompt Aceptando cambios.;
commit;

