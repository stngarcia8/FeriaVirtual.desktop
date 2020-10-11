using System.Data;
using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Validators {

    public class ClientValidator:Validator, IValidator {
        private readonly Client client;
        private readonly bool changedPassword;
        private readonly int profileID;
        private readonly string singleProfileName;

        // Constructor
        private ClientValidator(Client client,bool editMode,bool changedPassword,int profileID,string singleProfileName) : base() {
            this.client= client;
            this.editMode= editMode;
            this.changedPassword= changedPassword;
            this.profileID= profileID;
            this.singleProfileName= singleProfileName;
            processName= !editMode ? string.Format("registrar {0}",singleProfileName) : string.Format("editar {0}",singleProfileName);
        }

        // Named constructor.
        public static ClientValidator CreateValidator(Client client,bool editMode,bool changedPassword,int profileID,string singleProfileName) {
            return new ClientValidator(client,editMode,changedPassword,profileID,singleProfileName);
        }

        // Validate client method.
        public void Validate() {
            ValidateUsername();
            ValidatePassword();
            ValidateEmail();
            ValidatingEmptyField(client.Profile.ProfileID,string.Format("rol de {0}",singleProfileName));
            ValidatingEmptyField(client.FirstName,string.Format("{0}",singleProfileName));
            ValidatingEmptyField(client.LastName,string.Format("apellido de {0}",singleProfileName));
            if(ErrorMessages.Count>0) {
                throw new InvalidClientException(GenerateErrorMessage());
            }
        }

        private void ValidateUsername() {
            if(string.IsNullOrEmpty(client.Credentials.Username)) {
                ErrorMessages.Add(string.Format("El campo nombre de {0} no puede quedar vacío.",singleProfileName));
                return;
            }
            if(client.Credentials.Username.Length < usernameLength) {
                ErrorMessages.Add(string.Format("El largo del nombre de {0} no puede ser inferior a {1} caracteres",singleProfileName,usernameLength));
                return;
            }
            if(editMode) {
                return;
            }
            ClientUseCase useCase = ClientUseCase.CreateUseCase(profileID,singleProfileName);
            DataTable dataTable = useCase.FindClientById(client.Credentials.Username);
            if(dataTable.Rows.Count > 0) {
                ErrorMessages.Add("El username ingresado no esta disponible.");
            }
        }

        private void ValidatePassword() {
            if(!changedPassword) {
                return;
            }
            if(string.IsNullOrEmpty(client.Credentials.Password)) {
                ErrorMessages.Add("El campo password no puede quedar vacío.");
                return;
            }
            if(client.Credentials.Password.Length < passwordLength) {
                ErrorMessages.Add(string.Format("El largo del password no puede ser inferior a {0} caracteres",passwordLength));
            }
            Regex expresion = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,128}$");
            if(!expresion.IsMatch(client.Credentials.Password)) {
                ErrorMessages.Add("La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#");
            }
        }

        private void ValidateEmail() {
            if(string.IsNullOrEmpty(client.Credentials.Email)) {
                ErrorMessages.Add("El campo email no puede quedar vacío.");
                return;
            }
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if(!Regex.IsMatch(client.Credentials.Email,expresion)) {
                ErrorMessages.Add("El email ingresado no es una dirección de correo válida.");
            }
        }
    }
}