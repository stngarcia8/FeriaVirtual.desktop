using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Validators {

    public class EmployeeValidator:Validator, IValidator {

        private Employee employee;
        private readonly bool changedPassword;


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
            ValidatingEmptyField( employee.Profile.ProfileID,"rol del empleado" );
            ValidatingEmptyField( employee.FirstName,"nombre del empleado" );
            ValidatingEmptyField( employee.LastName,"apellido del empleado" );
            if(ErrorMessages.Count>0) {
                throw new InvalidEmployeeException( GenerateErrorMessage() );
            }
        }


        private void ValidateUsername() {
            if(string.IsNullOrEmpty( employee.Credentials.Username )) {
                ErrorMessages.Add( "El campo nombre de usuario no puede quedar vacío." );
                return;
            }
            if(employee.Credentials.Username.Length < usernameLength) {
                ErrorMessages.Add( string.Format( "El largo del nombre de usuario no puede ser inferior a {0} caracteres",usernameLength ) );
                return;
            }
            if(editMode) {
                return;
            }
            EmployeeUseCase useCase = EmployeeUseCase.CreateUseCase();
            Employee emp = useCase.FindUserByUsername( employee.Credentials.Username );
            if(emp != null) {
                ErrorMessages.Add( "El username ingresado no esta disponible." );
            }
        }

        private void ValidatePassword() {
            if(!changedPassword) {
                return;
            }
            if(string.IsNullOrEmpty( employee.Credentials.Password )) {
                ErrorMessages.Add( "El campo password no puede quedar vacío." );
                return;
            }
            if(employee.Credentials.Password.Length < passwordLength) {
                ErrorMessages.Add( string.Format( "El largo del password no puede ser inferior a {0} caracteres",passwordLength ) );
            }
            Regex expresion = new Regex( "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,50}$" );
            if(!expresion.IsMatch( employee.Credentials.Password )) {
                ErrorMessages.Add( "La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#" );
            }
        }


        private void ValidateEmail() {
            if(string.IsNullOrEmpty( employee.Credentials.Email )) {
                ErrorMessages.Add( "El campo email no puede quedar vacío." );
                return;
            }
            try {
                MailAddress mail = new MailAddress( employee.Credentials.Email );
            } catch {
                ErrorMessages.Add( "El email ingresado no es una dirección de correo válida." );
            }
        }


    }
}
