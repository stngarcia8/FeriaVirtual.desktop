namespace FeriaVirtual.View.Desktop.Helpers {

    public class InternalCustomerProfile:IProfileInfo {
        public int ProfileID => (int)EnumProfileInfo.Internal_customer;
        public string ProfileName => "Clientes internos";
        public string SingleProfileName => "cliente interno";

        // Constructor
        private InternalCustomerProfile() { }

        // Named constructor
        public static InternalCustomerProfile CreateProfile() {
            return new InternalCustomerProfile();
        }

        // Methods
        public override string ToString() {
            return SingleProfileName;
        }
    }
}