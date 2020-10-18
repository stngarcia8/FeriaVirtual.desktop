namespace FeriaVirtual.Domain.Dto {

    public class PaymentCondition {

        // Properties
        public int ConditionID { get; set; }
public string ConditionDescription { get; set; }

        //Constructor
        private PaymentCondition() {
            ConditionID= 0;
            ConditionDescription = string.Empty;
        }

        // Named constructor
        public static PaymentCondition CreateCondition() {
            return new PaymentCondition();
        }
    }
}