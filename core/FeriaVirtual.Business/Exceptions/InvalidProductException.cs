﻿using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class InvalidProductException : DomainException{

        public InvalidProductException(string message) : base(message){ }
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

    }

}