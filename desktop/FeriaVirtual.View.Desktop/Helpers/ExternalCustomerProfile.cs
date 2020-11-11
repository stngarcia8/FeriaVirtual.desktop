namespace FeriaVirtual.View.Desktop.Helpers{

    public class ExternalCustomerProfile : IProfileInfo{

        //Constructor
        private ExternalCustomerProfile(){ }


        //Properties
        public int ProfileId => (int) ProfileInfoEnum.ExternalCustomer;

        public string ProfileName => "Clientes externos";
        public string SingleProfileName => "cliente externo";


        // Named constructor
        public static ExternalCustomerProfile CreateProfile(){
            return new ExternalCustomerProfile();
        }


        // Methods
        public override string ToString(){
            return SingleProfileName;
        }

    }

}