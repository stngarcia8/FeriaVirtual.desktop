namespace FeriaVirtual.View.Desktop.Helpers{

    public class ProfileInfo{

        private readonly ProfileInfoEnum profileInfo;

        // Properties
        public IProfileInfo Profile{ get; private set; }


        private ProfileInfo(ProfileInfoEnum profileInfo){
            this.profileInfo = profileInfo;
            CheckProfile();
        }


        // Named constructor
        public static ProfileInfo CreateProfileInfo(ProfileInfoEnum profileInfo){
            return new ProfileInfo(profileInfo);
        }


        // private methods
        private void CheckProfile(){
            switch (profileInfo){
                case ProfileInfoEnum.Administrator:
                    Profile = AdministratorProfile.CreateProfile();
                    break;

                case ProfileInfoEnum.Consultant:
                    Profile = ConsultantProfile.CreateProfile();
                    break;

                case ProfileInfoEnum.ExternalCustomer:
                    Profile = ExternalCustomerProfile.CreateProfile();
                    break;

                case ProfileInfoEnum.InternalCustomer:
                    Profile = InternalCustomerProfile.CreateProfile();
                    break;

                case ProfileInfoEnum.Producer:
                    Profile = ProducerProfile.CreateProfile();
                    break;

                case ProfileInfoEnum.Carrier:
                    Profile = CarrierProfile.CreateProfile();
                    break;
            }
        }

    }

}