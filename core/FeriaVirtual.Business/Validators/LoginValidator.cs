using FeriaVirtual.Business.Exceptions;


namespace FeriaVirtual.Business.Validators{

    public class LoginValidator : Validator, IValidator{

        private readonly string password;
        private readonly string username;


        // Constructor.
        private LoginValidator(string username, string password){
            this.username = username;
            this.password = password;
            ProcessName = "iniciar sesión";
        }


        // Validate login method.
        public void Validate(){
            ValidateUsername();
            ValidatePassword();
            if (ErrorMessages.Count > 0) throw new InvalidLoginException(GenerateErrorMessage());
        }


        // Named constructor.
        public static LoginValidator CreateValidator(string username, string password){
            return new LoginValidator(username, password);
        }


        private void ValidateUsername(){
            if (string.IsNullOrEmpty(username)){
                ErrorMessages.Add("El campo nombre de usuario no puede quedar vacío.");
                return;
            }

            if (username.Length < UsernameLength)
                ErrorMessages.Add("El nombre de usuario debe contener al menos " + UsernameLength + " caracteres.");
        }


        private void ValidatePassword(){
            if (string.IsNullOrEmpty(password)){
                ErrorMessages.Add("El campo contraseña no puede quedar vacio.");
                return;
            }

            if (password.Length < PasswordLength)
                ErrorMessages.Add("la contraseña debe contener al menos " + PasswordLength + "caracteres.");
        }

    }

}