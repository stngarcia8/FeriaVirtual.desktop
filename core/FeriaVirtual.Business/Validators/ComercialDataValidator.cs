using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Validators {

    public class ComercialDataValidator:Validator, IValidator {

        private ComercialData data;

        // Constructor
        private ComercialDataValidator(ComercialData data,bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format( "{0} datos comerciales",editMode ? "actualizando" : "ingresando" );
        }


        // Named constructor
        public static ComercialDataValidator CreateValidator(ComercialData data,bool editMode) {
            return new ComercialDataValidator( data,editMode );
        }


        // Validate comercial data method.
        public void Validate() {
            ValidatingEmptyField( data.ComercialID,"id comercial" );
            ValidatingEmptyField( data.CompanyName,"razón social" );
            ValidatingEmptyField( data.ComercialBusiness,"giro comercial" );
            ValidatingEmptyField( data.ComercialDNI,"DNI" );
            ValidatingEmptyField( data.Address,"dirección comercial" );
            if(ErrorMessages.Count>0) {
                throw new InvalidClientException( GenerateErrorMessage() );
            }
        }

    }
}
