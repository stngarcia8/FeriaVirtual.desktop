using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Infraestructure.Exceptions {
    public class ConnectionFailedException:DomainException {

        public ConnectionFailedException(string message) : base( message ) { }

    }
}
