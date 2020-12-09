@echo off
cls

@echo Iniciando servicios para feria virtual.

@echo Iniciando Oracle
docker start oraclexe


echo Iniciando RabbitMQ
docker start rabbitmq


echo Iniciando SqlServer
docker start sqlserver

echo servicios iniciados
pause