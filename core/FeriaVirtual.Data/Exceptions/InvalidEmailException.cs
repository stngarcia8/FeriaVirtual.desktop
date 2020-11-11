using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Data.Exceptions{

    public class InvalidEmailException : DomainException{

        public InvalidEmailException(string message) : base(message){ }

    }

}