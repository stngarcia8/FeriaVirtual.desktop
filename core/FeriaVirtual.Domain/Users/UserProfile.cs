namespace FeriaVirtual.Domain.Users {
    public class UserProfile {

        // properties
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }

        //Constructors.
        private UserProfile() {
            ProfileID= 0;
            ProfileName = string.Empty;
        }

        private UserProfile(int profileId,string profileName) {
            ProfileID = profileId;
            ProfileName = profileName;
        }

        // named constructors.
        public static UserProfile CreateProfile() {
            return new UserProfile();
        }

        public static UserProfile CreateProfile(int profileId,string profileName) {
            return new UserProfile( profileId,profileName );
        }


        public override string ToString() {
            return ProfileName;
        }


    }
}
