using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    public class InvalidVehicleException:DomainException {

        public InvalidVehicleException(string message) : base( message ) { }

    }
}
