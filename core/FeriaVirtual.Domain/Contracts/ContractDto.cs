namespace FeriaVirtual.Domain.Contracts {

    public class ContractDto {

        public string ContractId { get; set; }
        public string ClientId { get; set; }
        public string Customername { get; set; }
        public string CustomerDni { get; set; }
        public string CustomerEmail { get; set; }
        public string ContractObservation { get; set; }
        public string CustomerObservation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string IsValid { get; set; }
        public string ValidDescription { get; set; }
        public string ContractDescription { get; set; }
        public float CommisionValue { get; set; }
        public float AdditionalValue { get; set; }
        public float FineValue { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }



    }

}