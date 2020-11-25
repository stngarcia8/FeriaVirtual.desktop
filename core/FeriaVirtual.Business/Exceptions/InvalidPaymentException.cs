using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

    public class InvalidPaymentException : DomainException{

        public InvalidPaymentException(string message) : base(message){ }

    }

}