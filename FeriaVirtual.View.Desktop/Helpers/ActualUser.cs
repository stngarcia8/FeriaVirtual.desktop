using FeriaVirtual.Domain.Users;
namespace FeriaVirtual.View.Desktop.Helpers {
    public sealed class ActualUser {

        private static ActualUser instance = null;
        private static readonly object _padLock = new object();

        // Properties.
        public static Employee ActualEmployee { get; set; }

        // Constructor.
        private ActualUser() { }

        // Verify instance.
        private static void VerifyInstance() {
            if(instance == null) {
                lock(_padLock) {
                    if(instance == null) {
                        instance = new ActualUser();
                    }
                }
            }
        }


    }
}
