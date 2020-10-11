using System;
using NLog;
using System.Collections.Generic;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class CarrierUseCase {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly CarrierRepository repository;

        // Constructor
        private CarrierUseCase() {
            repository= CarrierRepository.OpenRepository();
        }

        // Named constructor
        public static CarrierUseCase CreateUseCase() {
            return new CarrierUseCase();
        }

        public Carrier FindCarrierById(string carrierID) {
            repository.FindById(carrierID);
            return repository.Carrier;
        }

        public void NewVehicle(Vehicle vehicle,string clientID) {
            try {
                IValidator validator = VehicleValidator.CreateValidator(vehicle,false);
                validator.Validate();
                repository.NewVehicle(vehicle,clientID);
            } catch(Exception ex) {
                logger.Error(ex,"Error al crear un vehiculo");
                throw;
            }
        }

        public void EditVehicle(Vehicle vehicle) {
            try {
                IValidator validator = VehicleValidator.CreateValidator(vehicle,true);
                validator.Validate();
                repository.EditVehicle(vehicle);
            } catch(Exception ex) {
                logger.Error(ex,"Error al editar información de vehiculo");
                throw;
            }
        }

        public void DeleteVehicle(string vehicleID) {
            try {
                repository.DeleteVehicle(vehicleID);
            } catch(Exception ex) {
                logger.Error(ex,"Error al eliminar información de vehiculo");
                throw;
            }
        }

        public Vehicle FindVehicleByID(string vehicleID) {
            Vehicle vehicle;
            try {
                vehicle =  repository.FindVehicleByID(vehicleID);
            } catch(Exception ex) {
                logger.Error(ex,"Error al buscar un vehiculo por identificador");
                throw;
            }
            return vehicle;
        }

        public IList<Vehicle> FindAllVehicles(string clientID) {
            IList<Vehicle> vehicleList;
            try {
                vehicleList= repository.FindAllVehicles(clientID);
            } catch(Exception ex) {
                logger.Error(ex,"Error al buscar información de todos los vehiculos de un transportista");
                throw;
            }
            return vehicleList;
        }
    }
}