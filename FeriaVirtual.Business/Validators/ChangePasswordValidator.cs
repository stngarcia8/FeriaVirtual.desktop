using System;
using FeriaVirtual.Business.Exceptions;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.Validators {

public     class ChangePasswordValidator:Validator {

        private string firstPwd;
        private string secondPwd;
        private int passwordLength = 8;


        // Constructor
        private ChangePasswordValidator(string firstPwd, string secondPwd):base() {
            this.firstPwd= firstPwd;
            this.secondPwd= secondPwd;
            this.processName= "cambiar contraseña";
        }


        // Named constructor
        public static ChangePasswordValidator CreateValidator(string firstPwd, string secondPwd) {
            return new ChangePasswordValidator( firstPwd,secondPwd );
        }


        // excecute validation.
        public void Validate() {
            this.ValidateEquals();
            this.ValidateFormat( firstPwd );
            this.ValidateFormat( secondPwd );
            if(ErrorMessages.Count>0) {
                throw new InvalidChangePasswordException( GenerateErrorMessage() );
            }
        }


        private void ValidateEquals() {
            if(!firstPwd.Equals( secondPwd )) {
                this.ErrorMessages.Add( "Las contraseñas ingresadas son diferentes." );
                return;
            }
        }

        private void ValidateLength() {
            if(firstPwd.Length<passwordLength) {
                this.ErrorMessages.Add(string.Format("Las contraseñas deben tener al menos {0} caracteres.", passwordLength));
                return;
            }
            if(secondPwd.Length<passwordLength) {
                this.ErrorMessages.Add( string.Format( "Las contraseñas deben tener al menos {0} caracteres.",passwordLength ) );
                return;
            }
        }


        private void ValidateFormat(string pwd) {
            Regex expresion = new Regex( "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,50}$" );
            if(!expresion.IsMatch( pwd)) {
                this.ErrorMessages.Add( "La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#" );
            }
        }







        }
}
