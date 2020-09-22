using System.Collections.Generic;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Domain.Users {

    public class Carrier:Person {

        // Properties
        public IList<Vehicle> VehicleList;


        // constructors
        private Carrier() : base() {
            VehicleList= new List<Vehicle>();
        }

        private Carrier(string id,string firstName,string lastName,string dni) :
            base( id,firstName,lastName,dni ) {
            VehicleList= new List<Vehicle>();
        }


        // Named constructors.
        public static Carrier CreateCarrier() {
            return new Carrier();
        }

        public static Carrier CreateCarrier(string id,string firstName,string lastName,string dni) {
            return new Carrier( id,firstName,lastName,dni );
        }


        public void AddVehicle(Vehicle vehicle) {
            VehicleList.Add( vehicle );
        }

        public void RemoveVehicle(Vehicle vehicle) {
            VehicleList.Remove( vehicle );
        }


    }
}
