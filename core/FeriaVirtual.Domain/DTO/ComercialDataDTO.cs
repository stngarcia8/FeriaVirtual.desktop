﻿namespace FeriaVirtual.Domain.DTO {

    public class ComercialDataDTO {

        public string ClientID { get; set; }
        public string ComercialID { get; set; }
        public string CompanyName { get; set; }
        public string FantasyName { get; set; }
        public string ComercialBusiness { get; set; }
        public string Email { get; set; }
        public string ComercialDNI { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryPrefix { get; set; }


        // Contructors.
        public ComercialDataDTO() { }


    }
}