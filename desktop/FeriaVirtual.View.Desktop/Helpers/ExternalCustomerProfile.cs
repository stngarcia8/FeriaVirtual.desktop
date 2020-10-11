namespace FeriaVirtual.View.Desktop.Helpers {

    public class ExternalCustomerProfile:IProfileInfo {

        //Properties
        public int ProfileID => (int)EnumProfileInfo.External_customer;

        public string ProfileName => "Clientes externos";
        public string SingleProfileName => "cliente externo";

        //Constructor
        private ExternalCustomerProfile() { }

        // Named constructor
        public static ExternalCustomerProfile CreateProfile() {
            return new ExternalCustomerProfile();
        }

        // Methods
        public override string ToString() {
            return SingleProfileName;
        }
    }
}