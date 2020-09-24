using System;

namespace FeriaVirtual.Domain.Elements {

    public class Vehicle {

        // Properties.
        public string VehicleID { get; set; }
        public string VehicleClientID { get; set; }
        public int TypeVehicleID { get; set; }
        public string VehicleType { get; set; }
        public string VehiclePatent { get; set; }
        public string Model { get; set; }
        public float Capacity { get; set; }


        // Constructor
        private Vehicle() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,0,string.Empty,string.Empty,string.Empty,0);
        }

        private Vehicle(string id,string clientID,int typeId,string type,string vehiclePatent,string model,float capacity) {
            InitializeObjects( id,clientID,typeId,type,vehiclePatent,model,capacity );
        }

        private void InitializeObjects(string id, string clientID, int typeId,string type, string vehiclePatent, string model,float capacity) {
            VehicleID= id;
            VehicleClientID= VehicleClientID;
            TypeVehicleID=typeId;
            VehicleType = type;
            VehiclePatent= VehiclePatent;
            Model= model;
            Capacity= capacity;
        }


        // Named constructors.
        public static Vehicle CreateVehicle() {
            return new Vehicle();
        }

        public static Vehicle CreateVehicle(string id,string clientID,int typeId,string type,string vehiclePatent,string model,float capacity) {
            return new Vehicle( id,clientID,typeId,type,vehiclePatent,model,capacity );
        }

    }
}
