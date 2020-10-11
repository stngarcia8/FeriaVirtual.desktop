using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaVirtual.Business.Validators {

    public abstract class Validator {
        protected string processName;
        protected bool editMode;
        protected int usernameLength = 6;
        protected int passwordLength = 8;

        // properties.
        public IList<string> ErrorMessages { get; }

        protected Validator() {
            ErrorMessages = new List<string>();
            processName= string.Empty;
            editMode = false;
        }

        protected string GenerateErrorMessage() {
            if(ErrorMessages.Count.Equals(0)) {
                return string.Empty;
            }
            StringBuilder errorMessage = new StringBuilder();
            errorMessage.Append("Se han encontrado los siguientes problemas al " + processName + ", solucionelos y vuelva a intentarlo."+ Environment.NewLine);
            foreach(string error in ErrorMessages) {
                errorMessage.Append(string.Format("- {0}" + Environment.NewLine,error));
            }
            return errorMessage.ToString();
        }

        protected void ValidatingValueField(float value,string fieldName) {
            if(value<0) {
                ErrorMessages.Add(string.Format("El campo {0} no puede tener un valor menor a cero.",fieldName));
            }
        }

        protected void ValidatingValueField(int value,string fieldName) {
            if(value<0) {
                ErrorMessages.Add(string.Format("El campo {0} no puede tener un valor menor a cero.",fieldName));
            }
        }

        protected void ValidatingEmptyField(float value,string fieldName) {
            if(value.Equals(0)) {
                ErrorMessages.Add(string.Format("El campo {0} no puede tener un valor de cero.",fieldName));
            }
        }

        protected void ValidatingEmptyField(int value,string fieldName) {
            if(value.Equals(0)) {
                ErrorMessages.Add(string.Format("El campo {0} no puede tener un valor de cero.",fieldName));
            }
        }

        protected void ValidatingEmptyField(string value,string fieldName) {
            if(string.IsNullOrEmpty(value)) {
                ErrorMessages.Add(string.Format("El campo {0} no puede quedar vacío.",fieldName));
            }
        }
    }
}