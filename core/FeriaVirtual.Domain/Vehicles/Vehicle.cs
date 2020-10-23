using System;
using FeriaVirtual.Domain.Dto;

namespace FeriaVirtual.Domain.Vehicles {

    public class Vehicle {

        // Properties.
        public string VehicleID { get; set; }
        public string ClientID { get; set; }
        public VehicleType VehicleType { get; set; }
        public string VehiclePatent { get; set; }
        public string VehicleModel { get; set; }
        public float VehicleCapacity { get; set; }
        public int VehicleAvailable { get; set; }
        public string Observation { get; set; }

        // Constructor
        private Vehicle() {
            InitializeObjects(Guid.NewGuid().ToString(),string.Empty,string.Empty,0);
        }

        private Vehicle(string id,string clientID,string patent,float capacity) {
            InitializeObjects(id,clientID,patent,capacity);
        }

        private void InitializeObjects(string id,string clientID,string patent,float capacity) {
            VehicleID= id;
            ClientID= clientID;
            VehicleType = VehicleType.CreateVehicle();
            VehiclePatent= patent;
            VehicleModel= string.Empty;
            VehicleCapacity= capacity;
            VehicleAvailable = 1;
            Observation= string.Empty;
        }

        // Named constructors.
        public static Vehicle CreateVehicle() {
            return new Vehicle();
        }

        public static Vehicle CreateVehicle(string id,string clientID,string patent,float capacity) {
            return new Vehicle(id,clientID,patent,capacity);
        }
    }
}