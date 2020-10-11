using System;
using System.Windows.Forms;
using FeriaVirtual.View.Desktop.Commands;
using FeriaVirtual.View.Desktop.Forms.Maintenance.Client;
using FeriaVirtual.View.Desktop.Forms.Maintenance.Contract;
using FeriaVirtual.View.Desktop.Forms.Maintenance.User;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Forms.Administrator {

    public partial class AdministratorMainForm:Form {

        #region Manejo del formulario

        public AdministratorMainForm() {
            InitializeComponent();
        }

        private void AdministratorMainForm_Load(object sender,EventArgs e) {
            Text= "Feria virtual - Administrador.";
            FormStatusActiveUserToolStripStatusLabel.Text = "Usuario: " + ActualUser.ActualEmployee.ToString();
        }

        private void AdministratorMainForm_FormClosing(object sender,FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("¿Esta seguro de cerrar la sesión?","Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            e.Cancel= result==DialogResult.Yes;
        }

        #endregion Manejo del formulario

        private void CloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }

        private void MaintenanceCarrierToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new MaintenanceCarrierForm());
        }

        private void BusinessContractToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new ContractMaintenanceForm());
        }

        private void MaintenanceUserToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new MaintenanceUserForm());
        }

        // Open form method.
        private void OpenForm(Form form) {
            Hide();
            ICommand command = OpenFormCommand.Open(form);
            command.Execute();
            Show();
        }
    }
}