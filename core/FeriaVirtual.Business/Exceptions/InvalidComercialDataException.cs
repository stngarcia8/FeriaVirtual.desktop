using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Business.Exceptions {

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class InvalidComercialDataException:DomainException {
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

        public InvalidComercialDataException(string message) : base(message) {
        }
    }
}