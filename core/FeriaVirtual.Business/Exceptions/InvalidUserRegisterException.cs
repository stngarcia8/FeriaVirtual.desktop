using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {
    public class InvalidUserRegisterException:DomainException {

        public InvalidUserRegisterException(string message) : base( message ) { }

    }
}
