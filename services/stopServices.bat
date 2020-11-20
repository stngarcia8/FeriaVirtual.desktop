@echo off
cls

@echo Deteniendo servicios para feria virtual.

echo deteniendo oracle
docker stop oraclexe

echo deteniendo postgresql
docker stop pgsql

echo Deteniendo servicio de mensajeria
docker stop rabbitmq


echo servicios detenidos
pause