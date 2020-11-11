namespace FeriaVirtual.View.Desktop.Helpers{

    public class AdministratorProfile : IProfileInfo{

        // Constructor
        private AdministratorProfile(){ }


        //Properties
        public int ProfileId => (int) ProfileInfoEnum.Administrator;

        public string ProfileName => "Administradores";
        public string SingleProfileName => "Administrador";


        // Named constructor
        public static AdministratorProfile CreateProfile(){
            return new AdministratorProfile();
        }


        // Methods
        public override string ToString(){
            return SingleProfileName;
        }

    }

}