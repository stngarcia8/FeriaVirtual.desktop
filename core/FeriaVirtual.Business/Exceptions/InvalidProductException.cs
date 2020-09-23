using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    public class InvalidProductException:DomainException {

        public InvalidProductException(string message) : base( message ) { }

    }
}
