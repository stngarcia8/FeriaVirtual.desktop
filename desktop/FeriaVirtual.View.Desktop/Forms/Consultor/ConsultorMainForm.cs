using System;
using System.Windows.Forms;
using FeriaVirtual.Business.HelpersUseCases;
using FeriaVirtual.Business.Stats;
using FeriaVirtual.View.Desktop.Commands;
using FeriaVirtual.View.Desktop.Forms.Reports;
using FeriaVirtual.View.Desktop.Helpers;
using FeriaVirtual.View.Desktop.Forms.Offers;


namespace FeriaVirtual.View.Desktop.Forms.Consultor{

    public partial class ConsultorMainForm : Form{

        public ConsultorMainForm(){
            InitializeComponent();
        }

        private void RefreshToolStripMenuItem1_Click(object sender,EventArgs e){
            ShowResume();
        }



        private void CloseToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void ReportsExternalSalesToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new ExternalSalesForm(3));           
        }

        private void ReportsInternalSalesToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenForm(new ExternalSalesForm(4));           
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

        private void ConsultorMainForm_Load(object sender,EventArgs e) {
            Text = "Feria virtual - Consultor.";
            FormStatusActiveUserToolStripStatusLabel.Text= $"Usuario: {ActualUser.ActualEmployee}";
            ShowResume();
        }



        private void OpenForm(Form form){
            Hide();
            ICommand command = OpenFormCommand.Open(form);
            command.Execute();
            Show();
        }

        private void ShowResume(){
            var usecase = StatsUsecase.CreateUsecase();
            ExternalCustomerOrderStats(usecase);
            InternalCustomerOrderStats(usecase);
        }


        private void ExternalCustomerOrderStats(StatsUsecase usecase){
            var source = usecase.GetExternalCustomerOrderStats();
            ExternalCustomerOrderDataGridView.DataSource = source;
            ExternalCustomerOrderDataGridView.Columns["id_estado"].Visible = false;
            ExternalCustomerChart.DataSource = source;
            ExternalCustomerChart.Series[0].XValueMember = "Estado orden";
            ExternalCustomerChart.Series[0].YValueMembers = "Cantidad";
            ExternalCustomerChart.Series[0]["PieLabelStyle"] = "Disabled";
        }


        private void InternalCustomerOrderStats(StatsUsecase usecase){
            var source = usecase.GetInternalCustomerOrderStats();
            InternalCustomerOrderDataGridView.DataSource = source;
            InternalCustomerOrderDataGridView.Columns["id_estado"].Visible = false;
            InternalCustomerChart.DataSource = source;
            InternalCustomerChart.Series[0].XValueMember = "Estado orden";
            InternalCustomerChart.Series[0].YValueMembers = "Cantidad";
            InternalCustomerChart.Series[0]["PieLabelStyle"] = "Disabled";
        }


    }

}