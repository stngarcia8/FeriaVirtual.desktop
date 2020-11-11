using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Validators{

    public class ClientValidator : Validator, IValidator{

        private readonly bool changedPassword;
        private readonly Client client;
        private readonly int profileId;
        private readonly string singleProfileName;


        // Constructor
        private ClientValidator(Client client, bool editMode, bool changedPassword, int profileId,
            string singleProfileName){
            this.client = client;
            EditMode = editMode;
            this.changedPassword = changedPassword;
            this.profileId = profileId;
            this.singleProfileName = singleProfileName;
            ProcessName = !editMode
                ? $"registrar {singleProfileName}"
                : $"editar {singleProfileName}";
        }


        // Validate client method.
        public void Validate(){
            ValidateUsername();
            ValidatePassword();
            ValidateEmail();
            ValidatingEmptyField(client.Profile.ProfileId, $"rol de {singleProfileName}");
            ValidatingEmptyField(client.FirstName, $"{singleProfileName}");
            ValidatingEmptyField(client.LastName, $"apellido de {singleProfileName}");
            if (ErrorMessages.Count > 0) throw new InvalidClientException(GenerateErrorMessage());
        }


        // Named constructor.
        public static ClientValidator CreateValidator(Client client, bool editMode, bool changedPassword, int profileId,
            string singleProfileName){
            return new ClientValidator(client, editMode, changedPassword, profileId, singleProfileName);
        }


        private void ValidateUsername(){
            if (string.IsNullOrEmpty(client.Credentials.Username)){
                ErrorMessages.Add($"El campo nombre de {singleProfileName} no puede quedar vacío.");
                return;
            }

            if (client.Credentials.Username.Length < UsernameLength){
                ErrorMessages.Add(
                    $"El largo del nombre de {singleProfileName} no puede ser inferior a {UsernameLength} caracteres");
                return;
            }

            if (EditMode) return;
            var useCase = ClientUseCase.CreateUseCase(profileId, singleProfileName);
            var dataTable = useCase.FindClientById(client.Credentials.Username);
            if (dataTable.Rows.Count > 0) ErrorMessages.Add("El username ingresado no esta disponible.");
        }


        private void ValidatePassword(){
            if (!changedPassword) return;
            if (string.IsNullOrEmpty(client.Credentials.Password)){
                ErrorMessages.Add("El campo password no puede quedar vacío.");
                return;
            }

            if (client.Credentials.Password.Length < PasswordLength)
                ErrorMessages.Add($"El largo del password no puede ser inferior a {PasswordLength} caracteres");
            var expresion = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,128}$");
            if (!expresion.IsMatch(client.Credentials.Password))
                ErrorMessages.Add(
                    "La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#");
        }


        private void ValidateEmail(){
            if (string.IsNullOrEmpty(client.Credentials.Email)){
                ErrorMessages.Add("El campo email no puede quedar vacío.");
                return;
            }

            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(client.Credentials.Email, expresion))
                ErrorMessages.Add("El email ingresado no es una dirección de correo válida.");
        }

    }

}