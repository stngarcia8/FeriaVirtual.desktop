using System;
using System.Globalization;
using System.Windows.Forms;
using FeriaVirtual.View.Desktop.Forms.Login;


namespace FeriaVirtual.View.Desktop{

    internal static class Program{

        [STAThread]
        private static void Main(){
            Environment.SetEnvironmentVariable("NLS_LANG", "AMERICAN_AMERICA.WE8MSWIN1252",
                EnvironmentVariableTarget.Process);
            DefineCultureInfo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }


        private static void DefineCultureInfo(){
            var newCulture = new CultureInfo("es-CL");
            CultureInfo.CurrentCulture = newCulture;
        }

    }

}