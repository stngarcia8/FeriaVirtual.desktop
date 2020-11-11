namespace FeriaVirtual.View.Desktop.Helpers{

    public class ConsultantProfile : IProfileInfo{

        // constructor
        private ConsultantProfile(){ }


        //Properties
        public int ProfileId => (int) ProfileInfoEnum.Consultant;

        public string ProfileName => "Consultores";
        public string SingleProfileName => "Consultor";


        // Named constructor
        public static ConsultantProfile CreateProfile(){
            return new ConsultantProfile();
        }


        // Methods
        public override string ToString(){
            return SingleProfileName;
        }

    }

}