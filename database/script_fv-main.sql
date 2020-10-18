-- Archivo: script_fv.sql
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
ALTER SESSION SET "_ORACLE_SCRIPT" = true;
clear screen;

prompt Eliminando usuario y tablespace.;
DROP USER fv_user CASCADE;
DROP tablespace fv_env INCLUDING CONTENTS AND DATAFILES CASCADE CONSTRAINTS;

prompt Creando tablespace y usuario para feria virtual.;
CREATE TABLESPACE fv_env DATAFILE 'fv_env.dbf' SIZE 500M autoextend ON;
CREATE USER fv_user IDENTIFIED BY fv_pwd DEFAULT TABLESPACE fv_env temporary tablespace temp;

prompt Asignando los privilegios al usuario.;
GRANT CREATE SESSION TO fv_user;
GRANT RESOURCE TO fv_user;
GRANT CREATE VIEW TO fv_user;
-- REVOKE UNLIMITED TABLESPACE FROM fvirtual_user;

prompt Definiendo el tablespace que trabajara el usuario.;
ALTER USER fv_user QUOTA UNLIMITED ON fv_env;

prompt Estableciendo cambios.;
COMMIT;

@/script_files/script_fv-table.sql;
@/script_files/script_fv-sprox.sql;
@/script_files/script_fv-view.sql;
@/script_files/script_fv-popul.sql;
