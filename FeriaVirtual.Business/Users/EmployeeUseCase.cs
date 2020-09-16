using System;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class EmployeeUseCase {

        private EmployeeRepository repository;

        // Constructor.
        private EmployeeUseCase() {
            repository = EmployeeRepository.OpenRepository();
        }

        // Named constructor.
        public static EmployeeUseCase Create() {
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


        public DataTable FindUserByUsername(string username) {
            repository.FindByName( username );
            return repository.DataSource;
        }


        public DataTable FindUserById(string idUsuario) {
            repository.FindById( idUsuario );
            return repository.DataSource;
        }


        public void NewEmployee(Employee employee) {
            try {
                EmployeeValidator validator = EmployeeValidator.CreateValidator( employee,false,true );
                employee.Credentials.EncriptedPassword= employee.Credentials.EncryptPassword();
                validator.Validate();
                employee.Credentials.EncriptedPassword= employee.Credentials.EncryptPassword();
                repository.NewEmployee( employee );
            } catch(Exception ex) {
                throw ex;
            }
        }


        public void EditEmployee(Employee employee,bool validateUsername,bool validatePassword) {
            try {
                EmployeeValidator validator = EmployeeValidator.CreateValidator( employee,validateUsername,validatePassword );
                validator.Validate();
                repository.EditEmployee( employee );

            } catch(Exception ex) {
                throw ex;
            }
        }


        public void EnableDisableUser(string idUser,bool userStatus) {
            try {
                repository.EnableOrDisableUser( idUser,(userStatus ? 0 : 1) );
            } catch(Exception ex) {
                throw ex;
            }
        }







    }

}
