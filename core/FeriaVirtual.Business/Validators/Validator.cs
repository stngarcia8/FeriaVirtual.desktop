using System;
using System.Collections.Generic;
using System.Text;


namespace FeriaVirtual.Business.Validators{

    public abstract class Validator{

        protected bool EditMode;
        protected int PasswordLength = 8;
        protected string ProcessName;
        protected int UsernameLength = 6;

        // properties.
        public IList<string> ErrorMessages{ get; }


        protected Validator(){
            ErrorMessages = new List<string>();
            ProcessName = string.Empty;
            EditMode = false;
        }


        protected string GenerateErrorMessage(){
            if (ErrorMessages.Count.Equals(0)) return string.Empty;
            var errorMessage = new StringBuilder();
            errorMessage.Append("Se han encontrado los siguientes problemas al " + ProcessName +
                                ", solucionelos y vuelva a intentarlo." + Environment.NewLine);
            foreach (var error in ErrorMessages)
                errorMessage.Append(string.Format("- {0}" + Environment.NewLine, error));
            return errorMessage.ToString();
        }


        protected void ValidatingValueField(float value, string fieldName){
            if (value < 0)
                ErrorMessages.Add($"El campo {fieldName} no puede tener un valor menor a cero.");
        }


        protected void ValidatingValueField(int value, string fieldName){
            if (value < 0)
                ErrorMessages.Add($"El campo {fieldName} no puede tener un valor menor a cero.");
        }


        protected void ValidatingEmptyField(float value, string fieldName){
            if (value.Equals(0))
                ErrorMessages.Add($"El campo {fieldName} no puede tener un valor de cero.");
        }


        protected void ValidatingEmptyField(int value, string fieldName){
            if (value.Equals(0))
                ErrorMessages.Add($"El campo {fieldName} no puede tener un valor de cero.");
        }


        protected void ValidatingEmptyField(string value, string fieldName){
            if (string.IsNullOrEmpty(value))
                ErrorMessages.Add($"El campo {fieldName} no puede quedar vacío.");
        }

    }

}