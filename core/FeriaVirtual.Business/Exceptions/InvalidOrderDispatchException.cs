using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

    public class InvalidOrderDispatchException : DomainException{

        public InvalidOrderDispatchException(string message) : base(message){ }

    }

}