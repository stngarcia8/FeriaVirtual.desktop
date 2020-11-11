using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Users {

    public class ClientUseCase{

        private readonly int profileId;
        private readonly ClientRepository repository;
        private readonly string singleProfileName;


        // Constructor.
        private ClientUseCase(int profileId, string singleProfileName){
            repository = ClientRepository.OpenRepository(profileId);
            this.profileId = profileId;
            this.singleProfileName = singleProfileName;
        }


        // Named constructor.
        public static ClientUseCase CreateUseCase(int profileId, string singleProfileName){
            return new ClientUseCase(profileId, singleProfileName);
        }


        public DataTable FindAll(){
            repository.FindAll();
            return repository.DataSource;
        }


        public DataTable FindActiveClients(){
            repository.FindActiveClients();
            return repository.DataSource;
        }


        public DataTable FindInactiveClients(){
            repository.FindInactiveClients();
            return repository.DataSource;
        }


        public DataTable FindClientByName(string name){
            repository.FindByName(name);
            return repository.DataSource;
        }


        public DataTable FindClientById(string idClient){
            repository.FindById(idClient);
            return repository.DataSource;
        }


        public void NewClient(Client client){
            IValidator validator =
                ClientValidator.CreateValidator(client, false, true, profileId, singleProfileName);
            validator.Validate();
            client.Credentials.EncriptedPassword = client.Credentials.EncryptPassword();
            repository.NewClient(client);
        }


        public void EditEmployee(Client client, bool validateUsername, bool validatePassword){
            IValidator validator = ClientValidator.CreateValidator(client, validateUsername, validatePassword,
                profileId, singleProfileName);
            validator.Validate();
            repository.EditClient(client);
        }


        public void EnableDisableClient(string idUser, bool userStatus){
            repository.EnableOrDisableClient(idUser, userStatus ? 0 : 1);
        }

    }

}