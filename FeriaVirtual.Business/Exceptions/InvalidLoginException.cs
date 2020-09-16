using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {
    public class InvalidLoginException:DomainException {

        public InvalidLoginException(string message) : base( message ) { }

    }
}
