namespace FeriaVirtual.Domain.Contracts{

    public class ContractType{

        public int ContractTypeId{ get; set; }
        public string ContractTypeName{ get; set; }


        public ContractType(){
            ContractTypeId = 0;
            ContractTypeName = string.Empty;
        }

    }

}