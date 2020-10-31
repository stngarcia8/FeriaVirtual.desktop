﻿using System;
using System.Windows.Forms;
using FeriaVirtual.View.Desktop.Login;

namespace FeriaVirtual.View.Desktop {

    internal static class Program {

        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
