using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Validators {

    public class OrderValidator:Validator, IValidator {

        private readonly Order order;


        //Constructor
        private OrderValidator(Order order,bool editMode) {
            this.order = order;
            EditMode = editMode;
            ProcessName = !editMode ? "registrar solicitud" : "editar solicitud";
        }


        // Validate contract method.
        public void Validate() {
            ValidatingValueField(order.OrderDiscount,"descuento solicitado");
            if(ErrorMessages.Count > 0) {
                throw new InvalidOrderException(GenerateErrorMessage());
            }
        }


        // Named constructor
        public static OrderValidator CreateValidator(Order order,bool editMode) {
            return new OrderValidator(order,editMode);
        }

    }

}