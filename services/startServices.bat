@echo off
cls

@echo Iniciando servicios para feria virtual.

@echo Iniciando Oracle
docker start oraclexe

echo Iniciando Postgresql
docker start pgsql

echo Iniciando RabbitMQ
docker start rabbitmq

echo Iniciando Grafana
docker start grafana

echo Iniciando SqlServer
docker start sqlserver

echo servicios iniciados
pause