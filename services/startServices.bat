@echo off
cls

@echo Iniciando servicios para feria virtual.

@echo Iniciando Oracle
docker start oraclexe

echo Iniciando RabbitMQ
docker start rabbitmq

echo Iniciando SqlServer
docker start sqlserver

echo Iniciando sitio web
docker start fvirtual

echo servicios iniciados
pause