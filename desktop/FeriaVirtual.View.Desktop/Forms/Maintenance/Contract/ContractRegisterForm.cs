using System;
using FeriaVirtual.Business.HelpersUseCases;
using System.Data;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.View.Desktop.Forms.UtilForms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {

    public partial class ContractRegisterForm:Form {

        private Domain.Contracts.Contract contract;

        // Properties
        public bool IsNewRecord { get; set; }
        public bool IsSaved { get; set; }
        public string idSelected { get; set; }
        public string ProfileName { get; set; }
        public string SingleProfileName { get; set; }
        public int ProfileID { get; set; }

        private ContractDetail CurrentDetail;

                public ContractRegisterForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void ContractRegisterForm_Load(object sender,EventArgs e) {
            Text= (IsNewRecord ? string.Format("Nuevo contrato de {0}.",SingleProfileName) : string.Format("Editando contrato de {0}.",SingleProfileName));
            this.ListAddToolStripMenuItem.Text = string.Format("Asociar nuevo {0}", this.SingleProfileName);
            LoadContractTypes();
            DeleteContractButton.Visible= !IsNewRecord;
            this.ClientLabel.Text= string.Format("{0} asociados al contrato.", this.ProfileName);
            this.ClientTabPage.Text = string.Format("{0} asociados", this.ProfileName);
            if(IsNewRecord) {
                this.contract = Domain.Contracts.Contract.CreateContract();
                CleanControls();
                StartDateTimePicker.Focus();
            } else {
                LoadUserInfo();
                // PutClientInfoIntoControls();
            }
            this.ConfigureCustomersList();
        }


      private void DeleteContractButton_Click(object sender,EventArgs e) {
            // aqui tengo que eliminar el contrato si es que se puede...
        }

        private void ContractSaveButton_Click(object sender,EventArgs e) {
// tengo que grabar...
        }

        private void ContractCancelButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }

        private void LoadContractTypes() {
            this.ContractTypeComboBox.BeginUpdate();
            ContractTypeUseCase usecase = ContractTypeUseCase.CreateUseCase();
            this.ContractTypeComboBox.DataSource = usecase.FindAll();
            this.ContractTypeComboBox.DisplayMember= "desc_tipo_contrato";
            this.ContractTypeComboBox.ValueMember = "id_tipo_contrato";
            this.ContractTypeComboBox.EndUpdate();
        }

        private void CleanControls() {
            this.StartDateTimePicker.Value = DateTime.Now.Date;
            this.EndDateTimePicker.Value= DateTime.Now.AddMonths(6);
            this.CommissionNumericUpDown.Value= 0;
            this.DescriptionContractTextBox.Text= string.Empty;
            this.ContractValidCheckBox.Checked = true;
            this.contract = Domain.Contracts.Contract.CreateContract();
            this.ConfigureCustomersList();
        }


        private void PutUserDataIntoObject() {
            this.contract.StartDate = this.StartDateTimePicker.Value;
            this.contract.EndDate = this.EndDateTimePicker.Value;
            this.contract.IsValid = (this.ContractValidCheckBox.Checked?1:0);
            this.contract.ContractDescription = this.DescriptionContractTextBox.Text;
            this.contract.ContractCommission = float.Parse(this.CommissionNumericUpDown.Value.ToString());
            this.contract.TypeContract.ContractTypeID= int.Parse(this.ContractTypeComboBox.ValueMember);
            this.contract.TypeContract.ContractTypeName= this.ContractTypeComboBox.Text;
        }

        private void LoadUserInfo() {
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(ProfileID,SingleProfileName);
                GetClientData(usecase.FindContractById(this.idSelected));
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Close();
            }
        }


        private void GetClientData(DataTable contractInfo) {
            DataRow row = contractInfo.Rows[0];
            this.contract = Domain.Contracts.Contract.CreateContract();
                    }

        private void ListRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            this.ConfigureCustomersList();
            this.ListClientDataGridView.Focus();
        }

        private void ListAddToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenCustomerAssociationForm(true);
        }

        private void ListEditToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenCustomerAssociationForm(false);
        }

        private void ListRemoveToolStripMenuItem_Click(object sender,EventArgs e) {

        }

        private void OpenCustomerAssociationForm(bool isNew) {
            AssociateClientForm form = new AssociateClientForm {
                CurrentDetail= this.CurrentDetail
            };;
            form.ProfileID = this.ProfileID;
            form.IsNewRecord = isNew;
            this.ProfileName= this.ProfileName;
            form.SingleProfileName=  this.SingleProfileName;
            form.ActualDetails = this.contract.Details;
            form.ShowDialog();
            if(form.IsSaved) {
                this.contract.AddDetail(form.CurrentDetail);
                this.ConfigureCustomersList();
            }
        }

private void ConfigureCustomersList() {
            this.ListClientDataGridView.DataSource= null;
            this.ListClientDataGridView.Refresh();
            this.ListClientDataGridView.DataSource= this.contract.Details;
            this.ListClientDataGridView.Columns["DetailID"].Visible= false;
            this.ListClientDataGridView.Columns["RegisterDate"].Visible= false;
            this.ListClientDataGridView.Columns["DateAcepted"].Visible= false;
            this.ListClientDataGridView.Columns["ContractObservation"].Visible= false;
            this.ListClientDataGridView.Columns["ClientObservation"].Visible= false;
            this.ListClientDataGridView.Columns["AdditionalValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.ListClientDataGridView.Columns["FineValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ListClientDataGridView_SelectionChanged(object sender,EventArgs e) {
            this.GetCurrentDetail();
        }

        private void ListClientDataGridView_DoubleClick(object sender,EventArgs e) {
            this.GetCurrentDetail();
        }


        private void GetCurrentDetail() {
            if(this.ListClientDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            DataGridViewRow row = this.ListClientDataGridView.CurrentRow;
            if(row==null) {
                return;
            }
            this.CurrentDetail = ContractDetail.CreateDetail();
            this.CurrentDetail.DetailID = row.Cells["DetailID"].Value.ToString();
            this.CurrentDetail.Customer = (Domain.Users.Client)row.Cells["Customer"].Value;
            this.CurrentDetail.AdditionalValue = float.Parse(row.Cells["AdditionalValue"].Value.ToString());
            this.CurrentDetail.FineValue= float.Parse(row.Cells["FineValue"].Value.ToString());
            this.CurrentDetail.ContractObservation = row.Cells["ContractObservation"].Value.ToString();
            this.CurrentDetail.ClientObservation= row.Cells["ClientObservation"].Value.ToString();
            this.CurrentDetail.DateAcepted= DateTime.Parse(row.Cells["DateAcepted"].Value.ToString());
            this.CurrentDetail.RegisterDate= DateTime.Parse(row.Cells["RegisterDate"].Value.ToString());
        }



    }
}
