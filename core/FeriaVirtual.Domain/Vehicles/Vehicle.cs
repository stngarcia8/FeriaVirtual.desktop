using System;


namespace FeriaVirtual.Domain.Vehicles{

    public class Vehicle{

        // Properties.
        public string VehicleId{ get; set; }
        public string ClientId{ get; set; }
        public VehicleType VehicleType{ get; set; }
        public string VehiclePatent{ get; set; }
        public string VehicleModel{ get; set; }
        public float VehicleCapacity{ get; set; }
        public int VehicleAvailable{ get; set; }
        public string Observation{ get; set; }


        // Constructor
        private Vehicle(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty, 0);
        }


        private Vehicle(string id, string clientId, string patent, float capacity){
            InitializeObjects(id, clientId, patent, capacity);
        }


        private void InitializeObjects(string id, string clientId, string patent, float capacity){
            VehicleId = id;
            ClientId = clientId;
            VehicleType = VehicleType.CreateVehicle();
            VehiclePatent = patent;
            VehicleModel = string.Empty;
            VehicleCapacity = capacity;
            VehicleAvailable = 1;
            Observation = string.Empty;
        }


        // Named constructors.
        public static Vehicle CreateVehicle(){
            return new Vehicle();
        }


        public static Vehicle CreateVehicle(string id, string clientId, string patent, float capacity){
            return new Vehicle(id, clientId, patent, capacity);
        }

    }

}