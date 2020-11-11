using System.Collections.Generic;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Domain.Vehicles;


namespace FeriaVirtual.Business.Users{

    public class CarrierUseCase{

        private readonly CarrierRepository repository;


        // Constructor
        private CarrierUseCase(){
            repository = CarrierRepository.OpenRepository();
        }


        // Named constructor
        public static CarrierUseCase CreateUseCase(){
            return new CarrierUseCase();
        }


        public Carrier FindCarrierById(string carrierId){
            repository.FindById(carrierId);
            return repository.Carrier;
        }


        public void NewVehicle(Vehicle vehicle, string clientId){
            IValidator validator = VehicleValidator.CreateValidator(vehicle, false);
            validator.Validate();
            repository.NewVehicle(vehicle, clientId);
        }


        public void EditVehicle(Vehicle vehicle){
            IValidator validator = VehicleValidator.CreateValidator(vehicle, true);
            validator.Validate();
            repository.EditVehicle(vehicle);
        }


        public void DeleteVehicle(string vehicleId){
            repository.DeleteVehicle(vehicleId);
        }


        public Vehicle FindVehicleById(string vehicleId){
            return repository.FindVehicleById(vehicleId);
        }


        public IList<Vehicle> FindAllVehicles(string clientId){
            var vehicleList = repository.FindAllVehicles(clientId);
            return vehicleList;
        }

    }

}