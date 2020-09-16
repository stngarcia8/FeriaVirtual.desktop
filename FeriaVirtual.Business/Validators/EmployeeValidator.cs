using System.Data;
using FeriaVirtual.Business.Users;
using System.Net.Mail;
using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Validators {

    public class EmployeeValidator:Validator {

        private Employee employee;
        private readonly bool editMode;
        private readonly bool changedPassword;
        private readonly int usernameLength = 6;
        private readonly int passwordLength = 8;


        // Constructor
        private EmployeeValidator(Employee employee,bool editMode,bool changedPassword) : base() {
            this.employee= employee;
            this.editMode= editMode;
            this.changedPassword= changedPassword;
            processName= (!editMode ? "registrar empleado" : "editar empleado");
        }


        // Named constructor.
        public static EmployeeValidator CreateValidator(Employee employee,bool editMode,bool changedPassword) {
            return new EmployeeValidator( employee,editMode,changedPassword );
        }


        // Validate employee method.
        public void Validate() {
            ValidateUsername();
            ValidatePassword();
            ValidateEmail();
            ValidateProfile();
            ValidateFirstName();
            ValidateLastName();
            if(ErrorMessages.Count>0) {
                throw new InvalidEmployeeException( GenerateErrorMessage() );
            }
        }


        private void ValidateUsername() {
            if(string.IsNullOrEmpty( employee.Credentials.Username )) {
                this.ErrorMessages.Add( "El campo nombre de usuario no puede quedar vacío." );
                return;
            }
            if(employee.Credentials.Username.Length < usernameLength) {
                this.ErrorMessages.Add( string.Format( "El largo del nombre de usuario no puede ser inferior a {0} caracteres",usernameLength ) );
                return;
            }
            if(editMode) {
                return;
            }
            EmployeeUseCase useCase = EmployeeUseCase.Create();
            DataTable dataTable = useCase.FindUserByUsername( employee.Credentials.Username );
            if(dataTable.Rows.Count > 0) {
                this.ErrorMessages.Add( "El username ingresado no esta disponible." );
            }
        }

        private void ValidatePassword() {
            if(!changedPassword) {
                return;
            }
            if(string.IsNullOrEmpty( employee.Credentials.Password )) {
                this.ErrorMessages.Add( "El campo password no puede quedar vacío." );
                return;
            }
            if(employee.Credentials.Password.Length < passwordLength) {
                this.ErrorMessages.Add( string.Format( "El largo del password no puede ser inferior a {0} caracteres",passwordLength ) );
            }
            Regex expresion = new Regex( "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,50}$" );
            if(!expresion.IsMatch( employee.Credentials.Password )) {
                this.ErrorMessages.Add( "La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#" );
            }
        }


        private void ValidateEmail() {
            if(string.IsNullOrEmpty( employee.Credentials.Email )) {
                this.ErrorMessages.Add( "El campo email no puede quedar vacío." );
                return;
            }
            try {
                MailAddress mail = new MailAddress( employee.Credentials.Email );
            } catch {
                this.ErrorMessages.Add( "El email ingresado no es una dirección de correo válida." );
            }
        }


        private void ValidateProfile() {
            if(employee.Profile.ProfileID.Equals( 0 )) {
                this.ErrorMessages.Add( "Debe seleccionar el tipo de rol para el empleado." );
            }
        }


        private void ValidateFirstName() {
            if(string.IsNullOrEmpty( employee.FirstName )) {
                this.ErrorMessages.Add( "Debe ingresar el nombre real del empleado." );
            }
        }



        private void ValidateLastName() {
            if(string.IsNullOrEmpty( employee.LastName )) {
                this.ErrorMessages.Add( "Debe ingresar el apellido del empleado." );
            }
        }








    }
}
