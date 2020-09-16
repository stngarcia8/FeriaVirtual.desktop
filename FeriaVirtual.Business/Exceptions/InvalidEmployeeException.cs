using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {
    public class InvalidEmployeeException:DomainException {

        public InvalidEmployeeException(string message) : base( message ) { }

    }
}
