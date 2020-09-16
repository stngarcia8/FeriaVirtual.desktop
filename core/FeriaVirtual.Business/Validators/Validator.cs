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
            errorMessage.Append( "Se han encontrado los siguientes problemas al " + this.processName + ", solucionelos y vuelva a intentarlo.\n" );
            foreach(string error in ErrorMessages) {
                errorMessage.Append( "- " + error + "\n" );
            }
            return errorMessage.ToString();
        }


    }
}
