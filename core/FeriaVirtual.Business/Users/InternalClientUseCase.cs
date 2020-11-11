using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Users{

    public class InternalClientUseCase{

        private readonly InternalClientRepository repository;


        // Constructor
        private InternalClientUseCase(){
            repository = InternalClientRepository.OpenRepository();
        }


        // Named constructor
        public static InternalClientUseCase CreateUseCase(){
            return new InternalClientUseCase();
        }


        public InternalClient FindClientById(string clientId){
            repository.FindById(clientId);
            return repository.Client;
        }

    }

}