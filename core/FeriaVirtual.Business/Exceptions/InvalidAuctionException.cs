using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

    public class InvalidAuctionException : DomainException{

        public InvalidAuctionException(string message) : base(message){ }

    }

}