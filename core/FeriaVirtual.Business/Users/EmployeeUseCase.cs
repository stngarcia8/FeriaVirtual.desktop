using System;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class EmployeeUseCase {
        private readonly EmployeeRepository repository;

        // Constructor.
        private EmployeeUseCase() {
            repository = EmployeeRepository.OpenRepository();
        }

        // Named constructor.
        public static EmployeeUseCase CreateUseCase() {
            return new EmployeeUseCase();
        }

        public DataTable FindAll() {
            repository.FindAll();
            return repository.DataSource;
        }

        public DataTable FindActiveUsers() {
            repository.FindActiveUsers();
            return repository.DataSource;
        }

        public DataTable FindInactiveUsers() {
            repository.FindInactiveUsers();
            return repository.DataSource;
        }

        public DataTable FindUsersByUsername(string username) {
            repository.FindTableByName(username);
            return repository.DataSource;
        }

        public Employee FindUserByUsername(string username) {
            return repository.FindByName(username);
        }

        public Employee FindUserById(string idUsuario) {
            return repository.FindById(idUsuario); 
        }

        public void NewEmployee(Employee employee) {
            try {
                IValidator validator = EmployeeValidator.CreateValidator(employee,false,true);
                employee.Credentials.EncriptedPassword= employee.Credentials.EncryptPassword();
                validator.Validate();
                employee.Credentials.EncriptedPassword= employee.Credentials.EncryptPassword();
                repository.NewEmployee(employee);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void EditEmployee(Employee employee,bool validateUsername,bool validatePassword) {
            try {
                IValidator validator = EmployeeValidator.CreateValidator(employee,validateUsername,validatePassword);
                validator.Validate();
                repository.EditEmployee(employee);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void EnableDisableUser(string idUser,bool userStatus) {
            try {
                repository.EnableOrDisableUser(idUser,(userStatus ? 0 : 1));
            } catch(Exception ex) {
                throw ex;
            }
        }
    }
}