using System;
using System.Collections.Generic;

namespace FeriaVirtual.Domain.Contracts {

    public class Contract {

        // Properties
        public string ContractID { get; set; }
        public ContractType TypeContract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IsValid { get; set; }
        public string ContractDescription { get; set; }
        public float ContractCommission { get; set; }
        public DateTime ContractRegisterDate { get; set; }
        public IList<ContractDetail> Details { get; set; }

        // Constructor
        private Contract() {
            InitializeObjects();
        }

        private void InitializeObjects() {
            ContractID = Guid.NewGuid().ToString();
            TypeContract =  new ContractType();
            StartDate = DateTime.Now.Date;
            EndDate = DateTime.Now.Date.AddMonths(6);
            IsValid = 1;
            ContractDescription = string.Empty;
            ContractCommission = 0;
            ContractRegisterDate= DateTime.Now.Date;
            Details = new List<ContractDetail>();
        }

        // Named constructor.
        public static Contract CreateContract() {
            return new Contract();
        }

        public void AddDetail(ContractDetail detail) {
            Details.Add(detail);
        }

        public void RemoveDetail(ContractDetail detail) {
            Details.Remove(detail);
        }

        public void CleanDetails() {
            Details.Clear();
        }

        public override string ToString() {
            return ContractDescription;
        }
    }
}