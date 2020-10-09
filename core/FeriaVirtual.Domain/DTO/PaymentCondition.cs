using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.Dto {

    public class PaymentCondition {

        // Properties
        public int ConditionID { get; set; }
        public string ConditionDescription { get; set; }

        //Constructor
        private PaymentCondition() {
            this.ConditionID= 0;
            this.ConditionDescription = string.Empty;
        }

        // Named constructor
        public static PaymentCondition CreateCondition() {
            return new PaymentCondition();
        }

    }
}
