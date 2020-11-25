using System;
using System.Windows.Forms;
using FeriaVirtual.View.Desktop.Commands;
using FeriaVirtual.View.Desktop.Forms.Client;
using FeriaVirtual.View.Desktop.Forms.Offers;
using FeriaVirtual.View.Desktop.Forms.Contracts;
using FeriaVirtual.View.Desktop.Forms.Payments;
using FeriaVirtual.View.Desktop.Forms.Orders;
using FeriaVirtual.View.Desktop.Forms.User;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Administrator{

    public partial class AdministratorMainForm : Form{

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }


        private void MaintenanceCarrierToolStripMenuItem_Click(object sender, EventArgs e){
            OpenForm(new MaintenanceCarrierForm());
        }


        private void BusinessContractToolStripMenuItem_Click(object sender, EventArgs e){
            OpenForm(new ContractMaintenanceForm());
        }


        private void BusinessExternalSalesToolStripMenuItem_Click(object sender, EventArgs e){
            OpenForm(new ExternalOrderForm(ProfileInfo.CreateProfileInfo(ProfileInfoEnum.ExternalCustomer).Profile));
        }


        private void BusinessInternalSalesToolStripMenuItem_Click(object sender, EventArgs e){
            OpenForm(new ExternalOrderForm(ProfileInfo.CreateProfileInfo(ProfileInfoEnum.InternalCustomer).Profile));
        }

        private void BusinessOffersToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new OfferForm());
        }

        private void BusinessPaymentsReceptionToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new PaymentForm());
        }


        private void MaintenanceUserToolStripMenuItem_Click(object sender, EventArgs e){
            OpenForm(new MaintenanceUserForm());
        }


        // Open form method.
        private void OpenForm(Form form){
            Hide();
            ICommand command = OpenFormCommand.Open(form);
            command.Execute();
            Show();
        }


        #region Manejo del formulario

        public AdministratorMainForm(){
            InitializeComponent();
        }


        private void AdministratorMainForm_Load(object sender, EventArgs e){
            Text = "Feria virtual - Administrador.";
            FormStatusActiveUserToolStripStatusLabel.Text = "Usuario: " + ActualUser.ActualEmployee;
        }


        private void AdministratorMainForm_FormClosing(object sender, FormClosingEventArgs e){
            var result = MessageBox.Show("¿Esta seguro de cerrar la sesión?", "Atención", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes)){
                Environment.Exit(0);
                return;
            }
            e.Cancel = true;
        }


        #endregion Manejo del formulario


    }

}