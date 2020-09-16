using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {
    public class InvalidUsernameException:DomainException {

        public InvalidUsernameException(string message) : base( message ) { }

    }
}
