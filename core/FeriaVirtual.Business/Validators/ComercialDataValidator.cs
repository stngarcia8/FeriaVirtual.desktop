using System;
using FeriaVirtual.Domain.Elements;
using System.Net.Mail;
using FeriaVirtual.Business.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.Validators {

    public class ComercialDataValidator:Validator {

        private ComercialData data;
        private bool editMode;

               // Constructor
        private ComercialDataValidator(ComercialData data, bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format( "{0} datos comerciales", (editMode?"actualizando":"ingresando") );
        }


        // Named constructor
        public static ComercialDataValidator CreateValidator(ComercialData data, bool editMode) {
            return new ComercialDataValidator( data,editMode );
        }


        // Validate comercial data method.
        public void Validate() {
            this.ValidatingEmptyField( data.ComercialID,"id comercial" );
            this.ValidatingEmptyField( data.CompanyName,"razón social" );
            this.ValidatingEmptyField( data.ComercialBusiness,"giro comercial" );
            this.ValidatingEmptyField( data.ComercialDNI,"DNI" );
            this.ValidatingEmptyField( data.Address,"dirección comercial" );
            this.ValidatingEmptyField( data.CityID,"ciudad" );
            if(ErrorMessages.Count>0) {
                throw new InvalidClientException( GenerateErrorMessage() );
            }
        }


        private void ValidatingEmptyField(string value, string fieldName) {
            if(string.IsNullOrEmpty( value )) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede quedar vacío.",fieldName) );
            }
        }

        private void ValidatingEmptyField(int value,string fieldName) {
            if(value.Equals(0)) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede quedar vacío.",fieldName ) );
            }
        }








    }
}
