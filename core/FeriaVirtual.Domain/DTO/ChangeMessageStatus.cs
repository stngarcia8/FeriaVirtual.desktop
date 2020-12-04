namespace FeriaVirtual.Domain.Dto{

    public class ChangeMessageStatus{

        public string Id{ get; set; }
        public int Status{ get; set; }


        private ChangeMessageStatus(string id, int status){
            Id = id;
            Status = status;
        }


        public static ChangeMessageStatus Create(string id, int status){
            return new ChangeMessageStatus(id, status);
        }

    }

}