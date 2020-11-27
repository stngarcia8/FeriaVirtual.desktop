using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Validators{

    public class OrderDispatchValidator : Validator, IValidator{

        private readonly OrderDispatch order;


        private OrderDispatchValidator(OrderDispatch order, bool editMode){
            this.order= order;
            ProcessName = (editMode ? "ingresando orden de despacho" : "editando orden de despacho");
        }


        public void Validate(){
            ValidatingEmptyField(order.Observation, "observación de orden de despacho");
            if (ErrorMessages.Count > 0) throw new InvalidOrderDispatchException(GenerateErrorMessage());
        }


        public static OrderDispatchValidator CreateValidator(OrderDispatch order, bool editMode){
            return new OrderDispatchValidator(order, editMode);
        }

    }

}