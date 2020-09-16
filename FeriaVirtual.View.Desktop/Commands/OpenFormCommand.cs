using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Commands {
    public class OpenFormCommand:ICommand {

        private readonly Form form;

        // Constructor
        private OpenFormCommand(Form form) {
            this.form = (form == null ? null : form);
        }

        // Named constructor.
        public static OpenFormCommand Open(Form form) {
            return new OpenFormCommand( form );
        }

        // Exceute command.
        public void Execute() {
            if(form == null) {
                return;
            }
            ScreenResolutionAdjust();
            form.ShowDialog();
        }

        // Adjust form into screen resolution.
        private void ScreenResolutionAdjust() {
            Screen screen = Screen.PrimaryScreen;
            form.Height = (form.Height > (screen.Bounds.Height - 50) ? screen.Bounds.Height - 50 : form.Height);
            form.Width = (form.Width > (screen.Bounds.Width - 50) ? screen.Bounds.Width - 50 : form.Width);
        }



    }
}
