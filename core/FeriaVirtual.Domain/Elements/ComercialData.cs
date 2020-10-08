using System;
using FeriaVirtual.Domain.Dto;

namespace FeriaVirtual.Domain.Elements {

    public class ComercialData {

        public string ComercialID { get; set; }
        public string ClientID { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string ComercialBusiness { get; set; }
        public string Email { get; set; }
        public string ComercialDNI { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public string PhoneNumber { get; set; }


        // Contructor.
        private ComercialData() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty );
        }

        private ComercialData(string comercialId,string companyName,string comercialDNI) {
            InitializeObjects( comercialId,companyName,comercialDNI );
        }

        private void InitializeObjects(string comercialId,string companyName,string comercialDNI) {
            ComercialID=comercialId;
            ClientID= string.Empty;
            CompanyName=companyName;
            ComercialDNI= comercialDNI;
            FantasyName= string.Empty;
            ComercialBusiness= string.Empty;
            Email= string.Empty;
            ComercialDNI= string.Empty;
            Address=string.Empty;
            City= City.CreateCity();
            Country= Country.CreateCountry();
            PhoneNumber= string.Empty;
        }


        // Named contructors.
        public static ComercialData CreateComercialData() {
            return new ComercialData();
        }

        public static ComercialData CreateComercialData(string comercialId,string companyName,string comercialDNI) {
            return new ComercialData( comercialId,companyName,comercialDNI );
        }


    }
}
