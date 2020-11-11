namespace FeriaVirtual.Domain.CommercialsData{

    public class City{

        // Properties
        public int CityId{ get; set; }
        public string CityName{ get; set; }


        // Constructor
        private City(){
            CityId = 0;
            CityName = string.Empty;
        }


        // named constructor
        public static City CreateCity(){
            return new City();
        }


        public override string ToString(){
            return CityName;
        }

    }

}