using System;
using System.Windows.Forms;
using FeriaVirtual.View.Desktop.Login;
using System.Globalization;

namespace FeriaVirtual.View.Desktop {

    internal static class Program {

        [STAThread]
        private static void Main() {
            Environment.SetEnvironmentVariable("NLS_LANG","AMERICAN_AMERICA.WE8MSWIN1252",EnvironmentVariableTarget.Process);
            DefineCultureInfo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        private static void DefineCultureInfo() {
            CultureInfo current = CultureInfo.CurrentCulture;
            CultureInfo newCulture = new CultureInfo("es-CL");
            CultureInfo.CurrentCulture = newCulture;
        }



    }
}
