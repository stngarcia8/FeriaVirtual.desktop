namespace FeriaVirtual.Domain.Dto {
    public class City {

        // Properties
        public int CityID { get; set; }
        public string CityName { get; set; }


        // Constructor
        private City() {
            CityID= 0;
            CityName= string.Empty;
        }


        // named constructor
        public static City CreateCity() {
            return new City();
        }


        public override string ToString() {
            return CityName;
        }

    }
}
