namespace FeriaVirtual.Domain.Users {
    public class Client:Person {

        // constructors.
        private Client() : base() { }

        private Client(string id,string firstName,string lastName,string dni) :
            base( id,firstName,lastName,dni ) {
        }


        // Named constructors.
        public static Client CreateClient() {
            return new Client();
        }

        public static Client CreateClient(string id,string firstName,string lastName,string dni) {
            return new Client( id,firstName,lastName,dni );
        }

    }
}
