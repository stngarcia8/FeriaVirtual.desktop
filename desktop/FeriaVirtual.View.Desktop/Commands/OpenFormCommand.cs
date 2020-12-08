using System.Windows.Forms;


namespace FeriaVirtual.View.Desktop.Commands{

    public class OpenFormCommand : ICommand{

        private readonly Form form;


        public void Execute(){
            if (form == null) return;
            ScreenResolutionAdjust();
            form.ShowDialog();
        }


        private OpenFormCommand(Form form){
            if (form == null){
                this.form = null;
                return;
            }

            this.form = form;
        }


        public static OpenFormCommand Open(Form form){
            return new OpenFormCommand(form);
        }


        private void ScreenResolutionAdjust(){
            var screen = Screen.PrimaryScreen;
            form.Height = form.Height > screen.Bounds.Height - 50 ? screen.Bounds.Height - 50 : form.Height;
            form.Width = form.Width > screen.Bounds.Width - 50 ? screen.Bounds.Width - 50 : form.Width;
        }

    }

}