@echo off
cls

@echo Deteniendo servicios para feria virtual.

echo deteniendo Oracle
docker stop oraclexe

echo deteniendo Postgresql
docker stop pgsql

echo Deteniendo RabbitMQ
docker stop rabbitmq

echo Deteniendo Grafana.
docker stop grafana

echo Deteniendo SqlServer
docker stop sqlserver


echo servicios detenidos
pause