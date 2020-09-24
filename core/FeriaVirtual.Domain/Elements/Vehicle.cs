using System;

namespace FeriaVirtual.Domain.Elements {

    public class Vehicle {

        // Properties.
        public string VehicleID { get; set; }
        public string ClientID { get; set; }
        public string VehicleType { get; set; }
        public string VehiclePatent { get; set; }
        public string VehicleModel { get; set; }
        public float VehicleCapacity { get; set; }


        // Constructor
        private Vehicle() {
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty, 0);
        }

        private Vehicle(string id,string clientID,string patent,float capacity) {
            InitializeObjects( id,clientID,patent,capacity );
        }

        private void InitializeObjects(string id,string clientID,string patent,float capacity) {
            VehicleID= id;
            ClientID= clientID;
            VehicleType= string.Empty;
            VehiclePatent= patent;
            VehicleModel= string.Empty;
            VehicleCapacity= capacity;
        }


        // Named constructors.
        public static Vehicle CreateVehicle() {
            return new Vehicle();
        }

        public static Vehicle CreateVehicle(string id,string clientID,string patent,float capacity) {
            return new Vehicle( id,clientID,patent,capacity );
        }

    }
}
