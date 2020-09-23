using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class ProducerUseCase {

        private ProducerRepository repository;


        // Constructor
        private ProducerUseCase() {
            repository= ProducerRepository.OpenRepository();
        }


        // Named constructor
        public static ProducerUseCase CreateUseCase() {
            return new ProducerUseCase();
        }


        public Producer FindProducerById(string producerID) {
            repository.FindById( producerID );
            return repository.Producer;
        }

    }

}
