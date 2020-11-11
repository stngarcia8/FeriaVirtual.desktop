using System;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Domain.Contracts{

    public class ContractDetail{

        public string DetailId{ get; set; }
        public Client Customer{ get; set; }
        public float AdditionalValue{ get; set; }
        public float FineValue{ get; set; }
        public string ContractObservation{ get; set; }
        public string ClientObservation{ get; set; }
        public DateTime DateAcepted{ get; set; }
        public DateTime RegisterDate{ get; set; }
        public int Status{ get; set; }
        public string StatusDescription{ get; set; }


        private ContractDetail(){
            InitializeObjects();
        }


        private void InitializeObjects(){
            DetailId = Guid.NewGuid().ToString();
            DateAcepted = DateTime.Now.Date;
            RegisterDate = DateTime.Now.Date;
            ContractObservation = string.Empty;
            ClientObservation = string.Empty;
            AdditionalValue = 0;
            FineValue = 0;
            Customer = Client.CreateClient();
            Status = 0;
            StatusDescription = "No visualizado";
        }


        public static ContractDetail CreateDetail(){
            return new ContractDetail();
        }

    }

}