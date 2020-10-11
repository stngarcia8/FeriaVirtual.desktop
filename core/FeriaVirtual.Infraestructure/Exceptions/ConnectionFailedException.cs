using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Infraestructure.Exceptions {

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class ConnectionFailedException:DomainException {
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

        public ConnectionFailedException(string message) : base(message) {
        }
    }
}