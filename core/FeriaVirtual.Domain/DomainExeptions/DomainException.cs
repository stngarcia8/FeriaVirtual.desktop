using System;


namespace FeriaVirtual.Domain.DomainExeptions{

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class DomainException : Exception{

        // Constructor
        public DomainException(string message) : base(message){ }
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

    }

}