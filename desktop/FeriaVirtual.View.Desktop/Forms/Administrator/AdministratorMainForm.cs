using System;
using System.Data;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using FeriaVirtual.Business.Stats;
using System.Windows.Forms;
using FeriaVirtual.Business.HelpersUseCases;
using FeriaVirtual.View.Desktop.Commands;
using FeriaVirtual.View.Desktop.Forms.Client;
using FeriaVirtual.View.Desktop.Forms.Contracts;
using FeriaVirtual.View.Desktop.Forms.Offers;
using FeriaVirtual.View.Desktop.Forms.Orders;
using FeriaVirtual.View.Desktop.Forms.Payments;
using FeriaVirtual.View.Desktop.Forms.User;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Administrator{

    public partial class AdministratorMainForm : Form{

        public AdministratorMainForm(){
            InitializeComponent();
        }


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


        private void BusinessOffersToolStripMenuItem_Click(object sender, EventArgs e){
            OpenForm(new OfferForm());
        }


        private void BusinessPaymentsReceptionToolStripMenuItem_Click(object sender, EventArgs e){
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


        private void VerifyemailQueue(){
            var euc = EmailUsecase.CreateUsecase();
            euc.SendingEmails();
        }


        private void AdministratorMainForm_Load(object sender, EventArgs e){
            Text = "Feria virtual - Administrador.";
            FormStatusActiveUserToolStripStatusLabel.Text = "Usuario: " + ActualUser.ActualEmployee;
            VerifyemailQueue();
            ShowResume();
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


        private void ShowResume(){
            StatsUsecase usecase = StatsUsecase.CreateUsecase();
            UserStats(usecase);
            ExternalCustomerOrderStats(usecase);
            InternalCustomerOrderStats(usecase);
        }


        private void UserStats(StatsUsecase usecase){
            DataTable source = usecase.GetUserStats();
            this.UserTypeDataGridView.DataSource = source;
            this.UserTypeChart.DataSource = source;
            this.UserTypeChart.Series[0].XValueMember = "Tipo usuario";
            this.UserTypeChart.Series[0].YValueMembers = "Cantidad";
            this.UserTypeChart.Series[0]["PieLabelStyle"] = "Disabled";
        }

        private void ExternalCustomerOrderStats(StatsUsecase usecase){
            DataTable source = usecase.GetExternalCustomerOrderStats();
            this.ExternalCustomerOrderDataGridView.DataSource = source;
            this.ExternalCustomerOrderDataGridView.Columns["id_estado"].Visible = false;
            this.ExternalCustomerChart.DataSource = source;
            this.ExternalCustomerChart.Series[0].XValueMember = "Estado orden";
            this.ExternalCustomerChart.Series[0].YValueMembers = "Cantidad";
            this.ExternalCustomerChart.Series[0]["PieLabelStyle"] = "Disabled";
        }

        private void InternalCustomerOrderStats(StatsUsecase usecase){
            DataTable source = usecase.GetInternalCustomerOrderStats();
            this.InternalCustomerOrderDataGridView.DataSource = source;
            this.InternalCustomerOrderDataGridView.Columns["id_estado"].Visible = false;
            this.InternalCustomerChart.DataSource = source;
            this.InternalCustomerChart.Series[0].XValueMember = "Estado orden";
            this.InternalCustomerChart.Series[0].YValueMembers = "Cantidad";
            this.InternalCustomerChart.Series[0]["PieLabelStyle"] = "Disabled";
        }

        private void ResumeRefreshButton_Click(object sender,EventArgs e) {
            ShowResume();
        }
    }

}