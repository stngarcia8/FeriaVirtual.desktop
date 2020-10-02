using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

    public class InvalidContractException:DomainException {

        public InvalidContractException(string message) : base(message) { }

    }
}
