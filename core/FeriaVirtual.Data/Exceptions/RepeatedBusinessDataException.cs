using FeriaVirtual.Domain.DomainExeptions;

namespace FeriaVirtual.Data.Exceptions {
#pragma warning disable S3925 // "ISerializable" should be implemented correctly

    public class RepeatedBusinessDataException:DomainException {
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

        public RepeatedBusinessDataException(string message) : base(message) {
        }
    }
}