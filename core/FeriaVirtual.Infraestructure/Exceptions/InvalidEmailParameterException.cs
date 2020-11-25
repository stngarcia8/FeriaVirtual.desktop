using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Infraestructure.Exceptions{

    public class InvalidEmailParameterException : DomainException{

        public InvalidEmailParameterException(string message) : base(message){ }

    }

}