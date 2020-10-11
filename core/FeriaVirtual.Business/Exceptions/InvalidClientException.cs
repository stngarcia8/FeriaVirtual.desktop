using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class InvalidClientException:DomainException {
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

        public InvalidClientException(string message) : base(message) {
        }
    }
}