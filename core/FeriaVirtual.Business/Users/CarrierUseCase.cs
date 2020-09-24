using System;
using System.Collections.Generic;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Users {

    public class CarrierUseCase {

        private CarrierRepository repository;

        // Constructor
        private CarrierUseCase() {
            repository= CarrierRepository.OpenRepository();
        }


        // Named constructor
        public static CarrierUseCase CreateUseCase() {
            return new CarrierUseCase();
        }


        public Carrier FindCarrierById(string carrierID) {
            repository.FindById( carrierID );
            return repository.Carrier;
        }

        public void NewVehicle(Vehicle vehicle,string clientID) {
            try {
                VehicleValidator validator = VehicleValidator.CreateValidator( vehicle,false );
                validator.Validate();
                repository.NewVehicle( vehicle,clientID );
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void EditVehicle(Vehicle vehicle) {
            try {
                VehicleValidator validator = VehicleValidator.CreateValidator( vehicle,true );
                validator.Validate();
                repository.EditVehicle( vehicle );
            } catch(Exception ex) {
                throw ex;
            }
        }


        public void DeleteVehicle(string vehicleID) {
            try {
                repository.DeleteVehicle( vehicleID );
            } catch(Exception ex) {
                throw ex;
            }
        }


        public Vehicle FindVehicleByID(string vehicleID) {
            Vehicle vehicle = Vehicle.CreateVehicle();
            try {
                vehicle =  repository.FindVehicleByID( vehicleID );
            } catch(Exception ex) {
                vehicle = null;
                throw ex;
            }
            return vehicle;
        }


        public IList<Vehicle> FindAllVehicles(string clientID) {
            IList<Vehicle> vehicleList = new List<Vehicle>();
            try {
                vehicleList= repository.FindAllVehicles( clientID );
            } catch(Exception ex) {
                vehicleList= null;
                throw ex;
            }
            return vehicleList;
        }




    }

}
