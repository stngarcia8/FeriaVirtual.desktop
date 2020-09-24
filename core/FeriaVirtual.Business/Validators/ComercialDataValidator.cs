using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Validators {

    public class ComercialDataValidator:Validator {

        private ComercialData data;
        private readonly bool editMode;

        // Constructor
        private ComercialDataValidator(ComercialData data,bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format( "{0} datos comerciales",(editMode ? "actualizando" : "ingresando") );
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
            ValidatingEmptyField( data.City,"ciudad" );
            ValidatingEmptyField( data.Country,"país" );
            if(ErrorMessages.Count>0) {
                throw new InvalidClientException( GenerateErrorMessage() );
            }
        }


        private void ValidatingEmptyField(string value,string fieldName) {
            if(string.IsNullOrEmpty( value )) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede quedar vacío.",fieldName ) );
            }
        }

        private void ValidatingEmptyField(int value,string fieldName) {
            if(value.Equals( 0 )) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede quedar vacío.",fieldName ) );
            }
        }








    }
}
