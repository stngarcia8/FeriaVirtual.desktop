using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

    internal class InvalidOrderException : DomainException{

        public InvalidOrderException(string message) : base(message){ }

    }

}