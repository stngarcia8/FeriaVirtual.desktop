using System;

namespace FeriaVirtual.Domain.DomainExeptions {
    public class DomainException:Exception {

        // Constructor
        public DomainException(string message) : base( message ) { }

    }
}
