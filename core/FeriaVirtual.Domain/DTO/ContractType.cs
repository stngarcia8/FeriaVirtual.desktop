namespace FeriaVirtual.Domain.Dto {

    public class ContractType {

        // Properties
        public int ContractTypeID { get; set; }

        public string ContractTypeName { get; set; }

        // Constructor
        public ContractType() {
            ContractTypeID=0;
            ContractTypeName= string.Empty;
        }
    }
}