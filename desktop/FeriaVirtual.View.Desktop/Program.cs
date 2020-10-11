using System;
using NLog;
using System.Windows.Forms;
using FeriaVirtual.View.Desktop.Login;

namespace FeriaVirtual.View.Desktop {

    internal static class Program {

        // Log static properties
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main() {
            logger.Info("Iniciando aplicación.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}