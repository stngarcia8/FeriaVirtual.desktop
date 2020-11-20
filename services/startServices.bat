@echo off
cls

@echo Iniciando servicios para feria virtual.

@echo Iniciando oracle
docker start oraclexe

echo Iniciando postgresql
docker start pgsql

echo Iniciando servicio de mensajeria
docker start rabbitmq


echo servicios iniciados
pause