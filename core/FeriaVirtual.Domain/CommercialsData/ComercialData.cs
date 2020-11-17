using System;


namespace FeriaVirtual.Domain.CommercialsData{

    public class ComercialData{

        public string ComercialId{ get; set; }
        public string ClientId{ get; set; }
        public string CompanyName{ get; set; }
        public string FantasyName{ get; set; }
        public string ComercialBusiness{ get; set; }
        public string Email{ get; set; }
        public string ComercialDni{ get; set; }
        public string Address{ get; set; }
        public City City{ get; set; }
        public Country Country{ get; set; }
        public string PhoneNumber{ get; set; }


        private ComercialData(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty);
        }


        private ComercialData(string comercialId, string companyName, string comercialDni){
            InitializeObjects(comercialId, companyName, comercialDni);
        }


        private void InitializeObjects(string comercialId, string companyName, string comercialDni){
            ComercialId = comercialId;
            ClientId = string.Empty;
            CompanyName = companyName;
            ComercialDni = comercialDni;
            FantasyName = string.Empty;
            ComercialBusiness = string.Empty;
            Email = string.Empty;
            ComercialDni = string.Empty;
            Address = string.Empty;
            City = City.CreateCity();
            Country = Country.CreateCountry();
            PhoneNumber = string.Empty;
        }


        public static ComercialData CreateComercialData(){
            return new ComercialData();
        }


        public static ComercialData CreateComercialData(string comercialId, string companyName, string comercialDni){
            return new ComercialData(comercialId, companyName, comercialDni);
        }

    }

}