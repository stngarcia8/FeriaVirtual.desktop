using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaVirtual.Business.Validators {
    public abstract class Validator {

        protected string processName;


        // properties.
        public IList<string> ErrorMessages { get; }

        protected Validator() {
            ErrorMessages = new List<string>();
            processName= string.Empty;
        }


        protected string GenerateErrorMessage() {
            if(ErrorMessages.Count.Equals( 0 )) {
                return string.Empty;
            }
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.Append( "Se han encontrado los siguientes problemas al " + processName + ", solucionelos y vuelva a intentarlo."+ Environment.NewLine );
            foreach(string error in ErrorMessages) {
                errorMessage.Append( string.Format( "- {0}" + Environment.NewLine,error ) );
            }
            return errorMessage.ToString();
        }


    }
}
