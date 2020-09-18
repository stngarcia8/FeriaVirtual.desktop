using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.InitializeObjects( Guid.NewGuid().ToString(),0,string.Empty,string.Empty,0 );
        }

        private Vehicle(string id, int typeId, string type, string model, double capacity) {
            this.InitializeObjects( id,typeId,type,model,capacity );
        }

        private void InitializeObjects(string id,int typeId,string type,string model,double capacity) {
            this.VehicleID= id;
            this.TypeVehicleID=typeId;
            this.VehicleType = type;
            this.Model= model;
            this.Capacity= capacity;
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
