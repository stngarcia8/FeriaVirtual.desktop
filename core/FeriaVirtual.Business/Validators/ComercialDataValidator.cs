using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.CommercialsData;


namespace FeriaVirtual.Business.Validators{

    public class ComercialDataValidator : Validator, IValidator{

        private readonly ComercialData data;


        // Constructor
        private ComercialDataValidator(ComercialData data, bool editMode){
            this.data = data;
            EditMode = editMode;
            ProcessName = $"{(editMode ? "actualizando" : "ingresando")} datos comerciales";
        }


        public void Validate(){
            ValidatingEmptyField(data.ComercialId, "id comercial");
            ValidatingEmptyField(data.CompanyName, "razón social");
            ValidatingEmptyField(data.ComercialBusiness, "giro comercial");
            ValidatingEmptyField(data.ComercialDni, "DNI");
            ValidatingEmptyField(data.Address, "dirección comercial");
            if (ErrorMessages.Count > 0) throw new InvalidClientException(GenerateErrorMessage());
        }


        // Named constructor
        public static ComercialDataValidator CreateValidator(ComercialData data, bool editMode){
            return new ComercialDataValidator(data, editMode);
        }

    }

}