namespace FeriaVirtual.View.Desktop.Helpers{

    public class CarrierProfile : IProfileInfo{

        //Properties
        public int ProfileId => (int) ProfileInfoEnum.Carrier;

        public string ProfileName => "Transportistas";
        public string SingleProfileName => "Transportista";


        // Constructor
        private CarrierProfile(){ }


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