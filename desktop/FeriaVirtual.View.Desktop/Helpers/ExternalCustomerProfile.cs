namespace FeriaVirtual.View.Desktop.Helpers{

    public class ExternalCustomerProfile : IProfileInfo{

        //Properties
        public int ProfileId => (int) ProfileInfoEnum.ExternalCustomer;

        public string ProfileName => "Clientes externos";
        public string SingleProfileName => "cliente externo";


        //Constructor
        private ExternalCustomerProfile(){ }


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