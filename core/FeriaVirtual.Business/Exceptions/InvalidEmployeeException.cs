﻿using FeriaVirtual.Domain.DomainExeptions;


namespace FeriaVirtual.Business.Exceptions{

#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class InvalidEmployeeException : DomainException{

        public InvalidEmployeeException(string message) : base(message){ }
#pragma warning restore S3925 // "ISerializable" should be implemented correctly

    }

}