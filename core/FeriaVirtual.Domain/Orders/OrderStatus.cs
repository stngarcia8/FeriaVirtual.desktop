namespace FeriaVirtual.Domain.Orders{

    public class OrderStatus{

        public int StatusId{ get; set; }
        public string StatusDescription{ get; set; }


        private OrderStatus(){
            StatusId = 0;
            StatusDescription = string.Empty;
        }


        private OrderStatus(int statusId, string statusDescription){
            StatusId = statusId;
            StatusDescription = statusDescription;
        }


        public static OrderStatus CreateStatus(){
            return new OrderStatus();
        }


        public static OrderStatus CreateStatus(int statusId, string statusDescription){
            return new OrderStatus(statusId, statusDescription);
        }


        public override string ToString(){
            return StatusDescription;
        }

    }

}