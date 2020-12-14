namespace FeriaVirtual.Domain.Orders{

    public class PaymentCondition{

        public int ConditionId{ get; set; }
        public string ConditionDescription{ get; set; }


        private PaymentCondition(){
            ConditionId = 0;
            ConditionDescription = string.Empty;
        }


        public static PaymentCondition CreateCondition(){
            return new PaymentCondition();
        }

    }

}