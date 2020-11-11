namespace FeriaVirtual.Domain.CommercialsData{

    public class Country{

        // Properties
        public int CountryId{ get; set; }
        public string CountryName{ get; set; }
        public string CountryPrefix{ get; set; }


        // Constructor
        private Country(){
            CountryId = 0;
            CountryName = string.Empty;
            CountryPrefix = string.Empty;
        }


        // Named constructor
        public static Country CreateCountry(){
            return new Country();
        }


        public override string ToString(){
            return CountryName;
        }

    }

}