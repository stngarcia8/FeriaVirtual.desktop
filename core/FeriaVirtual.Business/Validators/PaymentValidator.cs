using System;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.Validators {
    public class PaymentValidator: Validator, IValidator {

        private readonly Payment payment;


        private PaymentValidator(Payment payment, bool editMode){
            this.payment = payment;
            ProcessName = (editMode ? "registrando pago" : "editando pago");
        }


        public static PaymentValidator CreateValidator(Payment payment, bool editMode){
            return new PaymentValidator(payment, editMode);
        }

        public void Validate(){
            ValidatingEmptyField(payment.OrderId, "número de orden");
            ValidatingEmptyField(payment.Amount, "monto a pagar");
            ValidatingValueField(payment.Amount, "monto a pagar");
            ValidatingEmptyField(payment.Observation, "observación de pago");
            if (ErrorMessages.Count > 0) throw new InvalidPaymentException(GenerateErrorMessage());
        }


    }
}
