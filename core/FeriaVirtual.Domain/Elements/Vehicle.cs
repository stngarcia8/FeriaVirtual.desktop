using System;

namespace FeriaVirtual.Domain.Elements {

    public class Vehicle {

        // Properties.
        public string VehicleID { get; set; }
        public int TypeVehicleID { get; set; }
        public string VehicleType { get; set; }
        public string Model { get; set; }
        public double Capacity { get; set; }


        // Constructor
        private Vehicle() {
            InitializeObjects( Guid.NewGuid().ToString(),0,string.Empty,string.Empty,0 );
        }

        private Vehicle(string id,int typeId,string type,string model,double capacity) {
            InitializeObjects( id,typeId,type,model,capacity );
        }

        private void InitializeObjects(string id,int typeId,string type,string model,double capacity) {
            VehicleID= id;
            TypeVehicleID=typeId;
            VehicleType = type;
            Model= model;
            Capacity= capacity;
        }


        // Named constructors.
        public static Vehicle CreateVehicle() {
            return new Vehicle();
        }

        public static Vehicle CreateVehicle(string id,int typeId,string type,string model,double capacity) {
            return new Vehicle( id,typeId,type,model,capacity );
        }

    }
}
