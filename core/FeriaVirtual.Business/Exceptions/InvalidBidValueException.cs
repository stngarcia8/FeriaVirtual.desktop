using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    internal class InvalidBidValueException:DomainException {

        public InvalidBidValueException(string message) : base(message) {
        }
    }
}
