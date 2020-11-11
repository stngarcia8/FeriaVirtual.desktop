using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

    internal class InvalidOrderDetailException : DomainException{

        public InvalidOrderDetailException(string message) : base(message){ }

    }

}