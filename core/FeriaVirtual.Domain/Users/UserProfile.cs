namespace FeriaVirtual.Domain.Users{

    public class UserProfile{

        public int ProfileId{ get; set; }

        public string ProfileName{ get; set; }


        private UserProfile(){
            ProfileId = 0;
            ProfileName = string.Empty;
        }


        private UserProfile(int profileId, string profileName){
            ProfileId = profileId;
            ProfileName = profileName;
        }


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