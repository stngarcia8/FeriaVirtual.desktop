using FeriaVirtual.Business.Exceptions;

namespace FeriaVirtual.Business.Validators {
    public class LoginValidator:Validator {

        private string username;
        private string password;
        private int usernameLength = 6;
        private int passwordLength = 8;

        // Constructor.
        private LoginValidator(string username,string password) : base() {
            this.username= username;
            this.password= password;
            processName= "iniciar sesión";
        }


        // Named constructor.
        public static LoginValidator CreateValidator(string username,string password) {
            return new LoginValidator( username,password );
        }

        // Validate login method.
        public void Validate() {
            ValidateUsername();
            ValidatePassword();
            if(ErrorMessages.Count>0) {
                throw new InvalidLoginException( GenerateErrorMessage() );
            }
        }

        private void ValidateUsername() {
            if(string.IsNullOrEmpty( username )) {
                ErrorMessages.Add( "El campo nombre de usuario no puede quedar vacío." );
                return;
            }
            if(username.Length<usernameLength) {
                ErrorMessages.Add( "El nombre de usuario debe contener al menos " + usernameLength.ToString() + " caracteres." );
                return;
            }
        }

        private void ValidatePassword() {
            if(string.IsNullOrEmpty( password )) {
                ErrorMessages.Add( "El campo contraseña no puede quedar vacio." );
                return;
            }
            if(password.Length<passwordLength) {
                ErrorMessages.Add( "la contraseña debe contener al menos " + passwordLength.ToString() + "caracteres." );
                return;
            }
        }


    }
}
