-- Archivo: script_fv-user.sql
--     Crea los tablespaces y usuarios para feria virtual.
-- Alumnos: Claudio Arenas, Matias Avalos, Daniel Garcia, Lucas Repetto.
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

prompt Ajustando la sesion para feria virtual.;
ALTER SESSION SET "_ORACLE_SCRIPT" = true;

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

prompt Definiendo el tablespace que trabajara el usuario.;
ALTER USER fv_user QUOTA UNLIMITED ON fv_env;

prompt Estableciendo cambios.;
COMMIT;
