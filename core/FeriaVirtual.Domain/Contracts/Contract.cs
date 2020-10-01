using System;

namespace FeriaVirtual.Domain.Contracts {

    public class Contract {

        // Properties
        public string ContractID { get; set; }
        public int TypeContractID { get; set; }
        public string TypeContract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IsValid { get; set; }
        public string ContractDescription { get; set; }
        public float ContractCommission { get; set; }
        public DateTime ContractRegisterDate { get; set; }


        // Constructor
        private Contract() {
            InitializeObjects();
        }


        private void InitializeObjects() {
            ContractID = Guid.NewGuid().ToString();
            TypeContractID = 0;
            TypeContract = string.Empty;
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date.AddMonths(6);
            IsValid = 1;
            ContractDescription = string.Empty;
            ContractCommission = 0;
            ContractRegisterDate= DateTime.Now.Date;
        }


        // Named constructor.
        public static Contract CreateContract() {
            return new Contract();
        }

        public override string ToString() {
            return ContractDescription;
        }



    }

}
