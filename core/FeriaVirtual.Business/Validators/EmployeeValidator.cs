﻿using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Validators{

    public class EmployeeValidator : Validator, IValidator{

        private readonly bool changedPassword;
        private readonly Employee employee;


        // Constructor
        private EmployeeValidator(Employee employee, bool editMode, bool changedPassword){
            this.employee = employee;
            EditMode = editMode;
            this.changedPassword = changedPassword;
            ProcessName = !editMode ? "registrar empleado" : "editar empleado";
        }


        public void Validate(){
            ValidateUsername();
            ValidatePassword();
            ValidateEmail();
            ValidatingEmptyField(employee.Profile.ProfileId, "rol del empleado");
            ValidatingEmptyField(employee.FirstName, "nombre del empleado");
            ValidatingEmptyField(employee.LastName, "apellido del empleado");
            if (ErrorMessages.Count > 0) throw new InvalidEmployeeException(GenerateErrorMessage());
        }


        // Named constructor.
        public static EmployeeValidator CreateValidator(Employee employee, bool editMode, bool changedPassword){
            return new EmployeeValidator(employee, editMode, changedPassword);
        }


        private void ValidateUsername(){
            if (string.IsNullOrEmpty(employee.Credentials.Username)){
                ErrorMessages.Add("El campo nombre de usuario no puede quedar vacío.");
                return;
            }

            if (employee.Credentials.Username.Length < UsernameLength){
                ErrorMessages.Add(
                    $"El largo del nombre de usuario no puede ser inferior a {UsernameLength} caracteres");
                return;
            }

            if (EditMode) return;
            var useCase = EmployeeUseCase.CreateUseCase();
            var emp = useCase.FindUserByUsername(employee.Credentials.Username);
            if (emp != null) ErrorMessages.Add("El username ingresado no esta disponible.");
        }


        private void ValidatePassword(){
            if (!changedPassword) return;
            if (string.IsNullOrEmpty(employee.Credentials.Password)){
                ErrorMessages.Add("El campo password no puede quedar vacío.");
                return;
            }

            if (employee.Credentials.Password.Length < PasswordLength)
                ErrorMessages.Add($"El largo del password no puede ser inferior a {PasswordLength} caracteres");
            var expresion = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,50}$");
            if (!expresion.IsMatch(employee.Credentials.Password))
                ErrorMessages.Add(
                    "La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#");
        }


        private void ValidateEmail(){
            if (string.IsNullOrEmpty(employee.Credentials.Email)){
                ErrorMessages.Add("El campo email no puede quedar vacío.");
                return;
            }

            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(employee.Credentials.Email, expresion))
                ErrorMessages.Add("El email ingresado no es una dirección de correo válida.");
        }

    }

}