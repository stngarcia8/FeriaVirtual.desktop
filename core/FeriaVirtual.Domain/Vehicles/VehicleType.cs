namespace FeriaVirtual.Domain.Vehicles{

    public class VehicleType{

        // Properties
        public int VehicleTypeId{ get; set; }

        public string VehicleTypeDescription{ get; set; }


        // Constructor
        private VehicleType(){
            VehicleTypeId = 0;
            VehicleTypeDescription = string.Empty;
        }


        // Named constructor
        public static VehicleType CreateVehicle(){
            return new VehicleType();
        }


        public override string ToString(){
            return VehicleTypeDescription;
        }

    }

}