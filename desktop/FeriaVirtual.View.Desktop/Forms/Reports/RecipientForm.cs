using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FeriaVirtual.Business.Stats;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Reports{

    public partial class RecipientForm : Form{

        private FileInfo info;
        private IList<ReportRecipientsDto> recipients;
        private BindingList<ReportRecipientsDto> source;

        public bool IsSendit{ get; set; }
        public string FileName{ get; set; }
        public string ReportName{ get; set; }


        public RecipientForm(){
            InitializeComponent();
            IsSendit = false;
        }


        private void RecipientForm_Load(object sender, EventArgs e){
            recipients = new List<ReportRecipientsDto>();
            info = new FileInfo(FileName);
            ReportNameTextBox.Text = ReportName;
            FilenameTextBox.Text = info.Name;
            ConfigureBindingList();
            ConfigureRecipientList();
            RecipientNameTextBox.Focus();
        }


        private void AddRecipientButton_Click(object sender, EventArgs e){
            if (string.IsNullOrEmpty(RecipientNameTextBox.Text)){
                MessageBox.Show("El nombre del destinatario no puede quedar vacio.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                RecipientNameTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(RecipientEmailTextBox.Text)){
                MessageBox.Show("El email  del destinatario no puede quedar vacio.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                RecipientEmailTextBox.Focus();
                return;
            }
            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(RecipientEmailTextBox.Text, expresion)){
                MessageBox.Show("El email ingresado no es válido.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                RecipientEmailTextBox.Focus();
                return;
            }
            var dto = new ReportRecipientsDto{
                Name = RecipientNameTextBox.Text,
                Subject = ReportName,
                Email = RecipientEmailTextBox.Text,
                Filename = info.FullName,
                Message = ReportName
            };
            recipients.Add(dto);
            ConfigureBindingList();
            ConfigureRecipientList();
            RecipientNameTextBox.Text = string.Empty;
            RecipientEmailTextBox.Text = string.Empty;
        }


        private void RemoveRecipientButton_Click(object sender, EventArgs e){
            if (RecipientDataGridView.Rows.Count.Equals(0)) return;

            if (RecipientDataGridView.SelectedRows.Count.Equals(0)) return;

            RecipientDataGridView.Rows.Remove(RecipientDataGridView.SelectedRows[0]);
            RemoveRecipientButton.Visible = !RecipientDataGridView.Rows.Count.Equals(0);
        }


        private void SendReportButton_Click(object sender, EventArgs e){
            if (!SendReport()) return;

            IsSendit = true;
            Close();
        }


        private void CancelMailButton_Click(object sender, EventArgs e){
            IsSendit = false;
            Close();
        }


        private void ConfigureBindingList(){
            source = new BindingList<ReportRecipientsDto>(recipients){
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };
        }


        private void ConfigureRecipientList(){
            RecipientDataGridView.DataSource = null;
            RecipientDataGridView.DataSource = source;
            RecipientDataGridView.Refresh();
            RemoveRecipientButton.Visible = !RecipientDataGridView.Rows.Count.Equals(0);
            ConfigureGrid();
        }


        private void ConfigureGrid(){
            var configurator =
                DataGridViewConfigurator.CreateConfigurator(RecipientDataGridView);
            IList<string> columns = new List<string>{"Filename", "Subject", "Message"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("Name", "Destinatario");
        }


        private bool SendReport(){
            var result = false;
            try{
                var usecase = ReportUsecase.CreateUsecase();
                usecase.SendReportToEmail(recipients);
                MessageBox.Show("Reporte enviado a los destinatarios.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }

    }

}