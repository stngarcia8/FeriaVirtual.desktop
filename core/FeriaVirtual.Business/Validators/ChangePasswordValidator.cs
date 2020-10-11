using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;

namespace FeriaVirtual.Business.Validators {

    public class ChangePasswordValidator:Validator, IValidator {
        private readonly string firstPwd;
        private readonly string secondPwd;

        // Constructor
        private ChangePasswordValidator(string firstPwd,string secondPwd) : base() {
            this.firstPwd= firstPwd;
            this.secondPwd= secondPwd;
            processName= "cambiar contraseña";
        }

        // Named constructor
        public static ChangePasswordValidator CreateValidator(string firstPwd,string secondPwd) {
            return new ChangePasswordValidator(firstPwd,secondPwd);
        }

        // excecute validation.
        public void Validate() {
            ValidateEquals();
            ValidateFormat(firstPwd);
            ValidateFormat(secondPwd);
            if(ErrorMessages.Count>0) {
                throw new InvalidChangePasswordException(GenerateErrorMessage());
            }
        }

        private void ValidateEquals() {
            if(!firstPwd.Equals(secondPwd)) {
                ErrorMessages.Add("Las contraseñas ingresadas son diferentes.");
            }
        }

        private void ValidateFormat(string pwd) {
            Regex expresion = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,50}$");
            if(!expresion.IsMatch(pwd)) {
                ErrorMessages.Add("La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#");
            }
        }
    }
}