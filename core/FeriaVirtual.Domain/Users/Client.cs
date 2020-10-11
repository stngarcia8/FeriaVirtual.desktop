namespace FeriaVirtual.Domain.Users {

    public class Client:Person {

        // Properties
        public Credential Credentials { get; set; }

        // constructors.
        private Client() : base() {
            Credentials = Credential.CreateCredential();
        }

        private Client(string id,string firstName,string lastName,string dni) :
            base(id,firstName,lastName,dni) {
            Credentials = Credential.CreateCredential();
        }

        // Named constructors.
        public static Client CreateClient() {
            return new Client();
        }

        public static Client CreateClient(string id,string firstName,string lastName,string dni) {
            return new Client(id,firstName,lastName,dni);
        }
    }
}