-- Archivo: script_fv-main.sql
--     Inicia la ejecución del script de creación de base de datos de feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.
-- Descripcion: Genera la base en oracle para el aplicativo de feria virtual.

SET ECHO OFF;
set feedback off;
clear screen;
prompt: Feria virtual.;
prompt --------------;
prompt;
prompt script de creación de la base de datos;
prompt para el proyecto "Feria Virtual";
prompt Ramo de portafolio de título DUOC UC.;
prompt;
prompt 2020, Arenas, Avalos, Garcia, Repetto.;
prompt ----------------------------------------;
prompt;


prompt Ajustando la sesion para feria virtual.;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
ALTER SESSION SET NLS_LANGUAGE= 'SPANISH' NLS_TERRITORY= 'Spain' NLS_CURRENCY= '$' NLS_ISO_CURRENCY= 'AMERICA' NLS_NUMERIC_CHARACTERS= '.,' NLS_CALENDAR= 'GREGORIAN' NLS_DATE_FORMAT= 'DD-MON-RR' NLS_DATE_LANGUAGE= 'SPANISH' NLS_SORT= 'BINARY';


@/script_files/script_fv-user.sql;
@/script_files/script_fv-table.sql;
@/script_files/script_fv-fkeys.sql;
@/script_files/script_fv-pkgs.sql;
@/script_files/script_fv-sprox.sql;
@/script_files/script_fv-view.sql;
@/script_files/script_fv-popul.sql;
@/script_files/script_fv-norm.sql;

prompt ----------------------------------------;
prompt Base de datos de feria virtual lista!;
prompt;