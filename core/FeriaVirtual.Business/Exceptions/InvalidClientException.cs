using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    public class InvalidClientException:DomainException {

        public InvalidClientException(string message) : base( message ) { }

    }
}
