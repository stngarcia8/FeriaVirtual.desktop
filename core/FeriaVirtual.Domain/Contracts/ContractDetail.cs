using System;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Domain.Contracts {

    public class ContractDetail {

        // Properties
        public string DetailID { get; set; }
        public Client Customer { get; set; }
        public float AdditionalValue { get; set; }
        public float FineValue { get; set; }
        public string ContractObservation { get; set; }
        public string ClientObservation { get; set; }
        public DateTime DateAcepted { get; set; }
        public DateTime RegisterDate { get; set; }


        // constructor
        private ContractDetail() {
            InitializeObjects();
        }

        private void InitializeObjects() {
            DetailID= Guid.NewGuid().ToString();
            DateAcepted = DateTime.Now.Date;
            RegisterDate = DateTime.Now.Date;
            ContractObservation = string.Empty;
            ClientObservation = string.Empty;
            AdditionalValue = 0;
            FineValue = 0;
            Customer = Client.CreateClient();
        }

        // Named constructor.
        public static ContractDetail CreateDetail() {
            return new ContractDetail();
        }

    }

}
