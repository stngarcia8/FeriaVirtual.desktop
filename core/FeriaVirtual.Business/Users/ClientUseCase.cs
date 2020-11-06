using System;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class ClientUseCase {
        private readonly ClientRepository repository;
        private readonly int profileID;
        private readonly string singleProfileName;

        // Constructor.
        private ClientUseCase(int profileID,string singleProfileName) {
            repository = ClientRepository.OpenRepository(profileID);
            this.profileID= profileID;
            this.singleProfileName=singleProfileName;
        }

        // Named constructor.
        public static ClientUseCase CreateUseCase(int profileID,string singleProfileName) {
            return new ClientUseCase(profileID,singleProfileName);
        }

        public DataTable FindAll() {
            repository.FindAll();
            return repository.DataSource;
        }

        public DataTable FindActiveClients() {
            repository.FindActiveClients();
            return repository.DataSource;
        }

        public DataTable FindInactiveClients() {
            repository.FindInactiveClients();
            return repository.DataSource;
        }

        public DataTable FindClientByName(string name) {
            repository.FindByName(name);
            return repository.DataSource;
        }

        public DataTable FindClientById(string idClient) {
            repository.FindById(idClient);
            return repository.DataSource;
        }

        public void NewClient(Client client) {
            try {
                IValidator validator = ClientValidator.CreateValidator(client,false,true,profileID,singleProfileName);
                validator.Validate();
                client.Credentials.EncriptedPassword= client.Credentials.EncryptPassword();
                repository.NewClient(client);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void EditEmployee(Client client,bool validateUsername,bool validatePassword) {
            try {
                IValidator validator = ClientValidator.CreateValidator(client,validateUsername,validatePassword,profileID,singleProfileName);
                validator.Validate();
                repository.EditClient(client);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void EnableDisableClient(string idUser,bool userStatus) {
            try {
                repository.EnableOrDisableClient(idUser,userStatus ? 0 : 1);
            } catch(Exception ex) {
                throw ex;
            }
        }
    }
}