using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Validators {

    public class OrderValidator:Validator, IValidator {
        private readonly Order order;

        //Constructor
        private OrderValidator(Order order,bool editMode) : base() {
            this.order=order;
            this.editMode= editMode;
            processName= !editMode ? "registrar solicitud" : "editar solicitud";
        }

        // Named constructor
        public static OrderValidator CreateValidator(Order order,bool editMode) {
            return new OrderValidator(order,editMode);
        }

        // Validate contract method.
        public void Validate() {
            ValidatingEmptyField(order.OrderDiscount,"descuento solicitado");
            ValidatingValueField(order.OrderDiscount,"descuento solicitado");
            if(ErrorMessages.Count>0) {
                throw new InvalidOrderException(GenerateErrorMessage());
            }
        }
    }
}