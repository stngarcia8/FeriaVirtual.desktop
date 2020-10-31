-- Archivo: script_fv-main.sql
--     Inicia la ejecución del script de creación de base de datos de feria virtual.
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
clear screen;
prompt ----------------------------------------;
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

@/script_files/script_fv-user.sql;
@/script_files/script_fv-table.sql;
@/script_files/script_fv-pkgs.sql;
@/script_files/script_fv-sprox.sql;
@/script_files/script_fv-view.sql;
@/script_files/script_fv-popul.sql;

prompt;
prompt ----------------------------------------;
prompt Base de datos de feria virtual lista!;
prompt;
prompt;