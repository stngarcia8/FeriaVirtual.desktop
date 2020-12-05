using System;
using System.Windows.Forms;


namespace FeriaVirtual.View.Desktop.Forms.Consultor{

    public partial class ConsultorMainForm : Form{

        public ConsultorMainForm(){
            InitializeComponent();
        }


        private void CloseToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }


        private void ConsultorMainForm_FormClosing(object sender, FormClosingEventArgs e){
            var result = MessageBox.Show("¿Esta seguro de cerrar la sesión?", "Atención", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes)){
                Environment.Exit(0);
                return;
            }
            e.Cancel = false;
        }

    }

}