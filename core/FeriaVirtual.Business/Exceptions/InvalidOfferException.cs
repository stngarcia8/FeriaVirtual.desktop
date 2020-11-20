using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

    public class InvalidOfferException : DomainException{

        public InvalidOfferException(string message) : base(message){ }

    }

}