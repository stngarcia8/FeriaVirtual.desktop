using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    public class InvalidChangePasswordException:DomainException {

        public InvalidChangePasswordException(string message) : base( message ) { }

    }
}
