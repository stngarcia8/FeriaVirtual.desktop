namespace FeriaVirtual.Domain.Orders{

    public class PaymentCondition{

        // Properties
        public int ConditionId{ get; set; }
        public string ConditionDescription{ get; set; }


        //Constructor
        private PaymentCondition(){
            ConditionId = 0;
            ConditionDescription = string.Empty;
        }


        // Named constructor
        public static PaymentCondition CreateCondition(){
            return new PaymentCondition();
        }

    }

}