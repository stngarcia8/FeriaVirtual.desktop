using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Users{

    public class ExternalClientUseCase{

        private readonly ExternalClientRepository repository;


        // Constructor
        private ExternalClientUseCase(){
            repository = ExternalClientRepository.OpenRepository();
        }


        // Named constructor
        public static ExternalClientUseCase CreateUseCase(){
            return new ExternalClientUseCase();
        }


        public ExternalClient FindClientById(string clientId){
            repository.FindById(clientId);
            return repository.Client;
        }

    }

}