using System;

namespace FeriaVirtual.Domain.Users {

    public class ComercialData {

        public string ComercialID { get; set; }
        public int CiudadID { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string ComercialBusiness { get; set; }
        public string Email { get; set; }
        public string ComercialDNI { get; set; }
        public string Address { get; set; }



        // Contructors.
        private ComercialData() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty );
        }

        private ComercialData(string comercialId,string companyName,string comercialDNI) {
            InitializeObjects( comercialId,companyName,comercialDNI );
        }

        private void InitializeObjects(string comercialId,string companyName,string comercialDNI) {
            ComercialID=comercialId;
            CompanyName=companyName;
            ComercialDNI= comercialDNI;
            this.FantasyName= string.Empty;
            ComercialBusiness= string.Empty;
            Email= string.Empty;
            ComercialDNI= string.Empty;
            Address=string.Empty;
            CiudadID= 0;
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
