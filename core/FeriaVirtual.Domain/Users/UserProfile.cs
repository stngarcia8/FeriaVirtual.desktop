namespace FeriaVirtual.Domain.Users{

    public class UserProfile{

        // properties
        public int ProfileId{ get; set; }

        public string ProfileName{ get; set; }


        //Constructors.
        private UserProfile(){
            ProfileId = 0;
            ProfileName = string.Empty;
        }


        private UserProfile(int profileId, string profileName){
            ProfileId = profileId;
            ProfileName = profileName;
        }


        // named constructors.
        public static UserProfile CreateProfile(){
            return new UserProfile();
        }


        public static UserProfile CreateProfile(int profileId, string profileName){
            return new UserProfile(profileId, profileName);
        }


        public override string ToString(){
            return ProfileName;
        }

    }

}