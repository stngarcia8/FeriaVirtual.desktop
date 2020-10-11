namespace FeriaVirtual.View.Desktop.Helpers {

    public class ProducerProfile:IProfileInfo {

        // Properties
        public int ProfileID => (int)EnumProfileInfo.Producer;

        public string ProfileName => "Productores";
        public string SingleProfileName => "Productor";

        // Constructor
        private ProducerProfile() { }

        // Named constructor
        public static ProducerProfile CreateProfile() {
            return new ProducerProfile();
        }

        // Methods
        public override string ToString() {
            return SingleProfileName;
        }
    }
}