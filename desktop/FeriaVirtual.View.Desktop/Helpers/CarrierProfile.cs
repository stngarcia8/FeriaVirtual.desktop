namespace FeriaVirtual.View.Desktop.Helpers{

    public class CarrierProfile : IProfileInfo{

        // Constructor
        private CarrierProfile(){ }


        //Properties
        public int ProfileId => (int) ProfileInfoEnum.Carrier;

        public string ProfileName => "Transportistas";
        public string SingleProfileName => "Transportista";


        // Named constructor
        public static CarrierProfile CreateProfile(){
            return new CarrierProfile();
        }


        // Methods
        public override string ToString(){
            return SingleProfileName;
        }

    }

}