using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    public class InvalidComercialDataException:DomainException {

        public InvalidComercialDataException(string message) : base( message ) { }

    }
}
