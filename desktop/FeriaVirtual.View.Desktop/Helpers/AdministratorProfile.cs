namespace FeriaVirtual.View.Desktop.Helpers {

    public class AdministratorProfile:IProfileInfo {

        //Properties
        public int ProfileID => (int)EnumProfileInfo.Administrator;

        public string ProfileName => "Administradores";
        public string SingleProfileName => "Administrador";

        // Constructor
        private AdministratorProfile() { }

        // Named constructor
        public static AdministratorProfile CreateProfile() {
            return new AdministratorProfile();
        }

        // Methods
        public override string ToString() {
            return SingleProfileName;
        }
    }
}