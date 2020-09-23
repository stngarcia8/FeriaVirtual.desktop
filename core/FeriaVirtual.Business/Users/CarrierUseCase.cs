using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class CarrierUseCase {

        private CarrierRepository repository;

        // Constructor
        private CarrierUseCase() {
            repository= CarrierRepository.OpenRepository();
        }


        // Named constructor
        public static CarrierUseCase CreateUseCase() {
            return new CarrierUseCase();
        }


        public Carrier FindCarrierById(string carrierID) {
            repository.FindById( carrierID );
            return repository.Carrier;
        }


    }

}
