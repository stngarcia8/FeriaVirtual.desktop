@echo off
cls

@echo Deteniendo servicios para feria virtual.

echo deteniendo Oracle
docker stop oraclexe


echo Deteniendo RabbitMQ
docker stop rabbitmq


echo Deteniendo SqlServer
docker stop sqlserver


echo servicios detenidos
pause