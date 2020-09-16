using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {
    public class InvalidPasswordException:DomainException {

        public InvalidPasswordException(string message) : base( message ) { }

    }
}
