namespace FeriaVirtual.Domain.Dto {

    public class SessionDto {

        // Properties.
        public string SessionID { get; set; }

        public string UserId { get; set; }
        public string ClientID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }

        public SessionDto() {
        }
    }
}