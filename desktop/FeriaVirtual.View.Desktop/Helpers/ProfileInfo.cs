namespace FeriaVirtual.View.Desktop.Helpers {

    public class ProfileInfo {
        private readonly EnumProfileInfo profileInfo;
        private IProfileInfo profile;

        // Properties
        public IProfileInfo Profile => profile;

        private ProfileInfo(EnumProfileInfo profileInfo) {
            this.profileInfo= profileInfo;
            CheckProfile();
        }

        // Named constructor
        public static ProfileInfo CreateProfileInfo(EnumProfileInfo profileInfo) {
            return new ProfileInfo(profileInfo);
        }

        // private methods
        private void CheckProfile() {
            switch(profileInfo) {
                case EnumProfileInfo.Administrator:
                    profile = AdministratorProfile.CreateProfile();
                    break;

                case EnumProfileInfo.Consultant:
                    profile= ConsultantProfile.CreateProfile();
                    break;

                case EnumProfileInfo.External_customer:
                    profile = ExternalCustomerProfile.CreateProfile();
                    break;

                case EnumProfileInfo.Internal_customer:
                    profile = InternalCustomerProfile.CreateProfile();
                    break;

                case EnumProfileInfo.Producer:
                    profile= ProducerProfile.CreateProfile();
                    break;

                case EnumProfileInfo.Carrier:
                    profile = CarrierProfile.CreateProfile();
                    break;
            }
        }
    }
}