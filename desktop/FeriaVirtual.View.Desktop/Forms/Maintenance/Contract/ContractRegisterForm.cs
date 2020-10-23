using System;
using FeriaVirtual.Business.Documents;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.Business.HelpersUseCases;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {

    public partial class ContractRegisterForm:Form {
        private Domain.Contracts.Contract contract;
        private Domain.Contracts.ContractDetail currentDetail = ContractDetail.CreateDetail();
        private BindingList<ContractDetail> source;

        // Properties
        public bool IsNewRecord { get; set; }

        public bool IsSaved { get; set; }
        public string IdSelected { get; set; }
        public IProfileInfo Profile { get; set; }

        // Forms events method
        public ContractRegisterForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void ContractRegisterForm_Load(object sender,EventArgs e) {
            ConfigureForm();
            LoadContractTypes();
            if(IsNewRecord) {
                ContractValidCheckBox.Checked= true;
                contract = Domain.Contracts.Contract.CreateContract();
                CleanControls();
            } else {
                LoadContractInfo();
                PutContractInfoToControls();
            }
            ConfigureBindingList();
            ConfigureCustomerList();
            StartDateTimePicker.Focus();
        }

        // Form buttons events method.
        private void DeleteContractButton_Click(object sender,EventArgs e) {
            if(!this.DeleteContract()) {
                return;
            }
            this.IsSaved= true;
            this.Close();
        }

        private void ContractSaveButton_Click(object sender,EventArgs e) {
            if(!SaveContractData()) {
                return;
            }
            IsSaved= true;
            Close();
        }

        private void ContractCancelButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }

        // datagridview events method
        private void ListClientDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetCurrentDetail();
        }

        private void ListClientDataGridView_DoubleClick(object sender,EventArgs e) {
            EditCustomer();
        }

        // datagridview contextmenu controls events methods.
        private void ListRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            ConfigureCustomerList();
            ListClientDataGridView.Focus();
        }

        private void ListAddToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenCustomerAssociationForm(true);
        }

        private void ListEditToolStripMenuItem_Click(object sender,EventArgs e) {
            EditCustomer();
        }

        private void ListRemoveToolStripMenuItem_Click(object sender,EventArgs e) {
            if(ListClientDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            if(ListClientDataGridView.SelectedRows.Count.Equals(0)) {
                return;
            }
            ListClientDataGridView.Rows.Remove(ListClientDataGridView.SelectedRows[0]);
        }

        // Form methods
        private void ConfigureForm() {
            Text= (IsNewRecord ? string.Format("Nuevo contrato de {0}.",Profile.SingleProfileName) : string.Format("Editando contrato de {0}.",Profile.SingleProfileName));
            ListAddToolStripMenuItem.Text = string.Format("Asociar nuevo {0}",Profile.SingleProfileName);
            DeleteContractButton.Visible= !IsNewRecord;
            ClientLabel.Text= string.Format("{0} asociados al contrato.",Profile.ProfileName);
            ClientTabPage.Text = string.Format("{0} asociados",Profile.ProfileName);
        }

        private void ConfigureBindingList() {
            source = new BindingList<ContractDetail>(contract.Details) {
                AllowNew= true,
                AllowEdit= true,
                AllowRemove= true
            };
            source.AllowNew= true;
        }

        private void LoadContractTypes() {
            ContractTypeComboBox.BeginUpdate();
            ContractTypeUseCase usecase = ContractTypeUseCase.CreateUseCase();
            ContractTypeComboBox.DataSource = usecase.FindAll();
            ContractTypeComboBox.DisplayMember= "desc_tipo_contrato";
            ContractTypeComboBox.ValueMember = "id_tipo_contrato";
            ContractTypeComboBox.EndUpdate();
        }

        private void CleanControls() {
            StartDateTimePicker.Value = DateTime.Now.Date;
            EndDateTimePicker.Value= DateTime.Now.AddMonths(6);
            CommissionNumericUpDown.Value= 0;
            DescriptionContractTextBox.Text= string.Empty;
            ContractValidCheckBox.Checked = true;
            contract = Domain.Contracts.Contract.CreateContract();
        }

        private void OpenCustomerAssociationForm(bool isNew) {
            AssociateClientForm form = new AssociateClientForm {
                CurrentDetail= currentDetail,
                Profile=Profile
            };
            form.IsNewRecord = isNew;
            form.ActualDetails = contract.Details;
            form.ShowDialog();
            if(form.IsSaved && isNew) {
                contract.Details.Add(form.CurrentDetail);
                ConfigureBindingList();
                ConfigureCustomerList();
            }
        }

        private void ConfigureCustomerList() {
            ListClientDataGridView.SelectionChanged-= ListClientDataGridView_SelectionChanged;
            ListClientDataGridView.DataSource= null;
            ListClientDataGridView.DataSource=source;
            ListClientDataGridView.Refresh();
            if(this.ListClientDataGridView.Rows.Count.Equals(0)) {
                this.DeleteContractButton.Visible= (this.IsNewRecord ? false:true);
            } else {
                this.DeleteContractButton.Visible=false;
            }
            ConfigureGrid();
            ListClientDataGridView.SelectionChanged+= ListClientDataGridView_SelectionChanged;
        }

        private void ConfigureGrid() {
            IList<string> cols = new List<string> { "DetailID","ContractObservation","ClientObservation","RegisterDate","DateAcepted", "Status" };
            foreach(string col in cols) {
                ListClientDataGridView.Columns[col].Visible= false;
            }
            ListClientDataGridView.Columns["Customer"].HeaderText = Profile.SingleProfileName;
            ListClientDataGridView.Columns["StatusDescription"].HeaderText = "Estado";
            ConfigureNumericColumn("AdditionalValue","Valor adic.");
            ConfigureNumericColumn("FineValue","Valor multa");
        }

        private void ConfigureNumericColumn(string colName,string headerText) {
            ListClientDataGridView.Columns[colName].HeaderText = headerText;
            ListClientDataGridView.Columns[colName].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            ListClientDataGridView.Columns[colName].AutoSizeMode= DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListClientDataGridView.Columns[colName].DefaultCellStyle.Format="N2";
        }

        private void GetCurrentDetail() {
            if(contract.Details.Count.Equals(0)) {
                currentDetail = ContractDetail.CreateDetail();
                return;
            }
            DataGridViewRow row = ListClientDataGridView.CurrentRow;
            currentDetail = row.DataBoundItem as ContractDetail;
        }

        private void PutInfoControlsToContract() {
            contract.StartDate = StartDateTimePicker.Value;
            contract.EndDate = EndDateTimePicker.Value;
            contract.IsValid = (ContractValidCheckBox.Checked ? 1 : 0);
            contract.ContractDescription = DescriptionContractTextBox.Text;
            contract.ContractCommission = float.Parse(CommissionNumericUpDown.Value.ToString());
            contract.TypeContract.ContractTypeID= int.Parse(ContractTypeComboBox.SelectedValue.ToString());
            contract.TypeContract.ContractTypeName= ContractTypeComboBox.Text;
            contract.Details = contract.Details.ToList();
        }

        private bool SaveContractData() {
            bool result = false;
            string message = string.Empty;
            PutInfoControlsToContract();
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(Profile.ProfileID,Profile.SingleProfileName);
                if(IsNewRecord) {
                    usecase.NewContract(contract);
                    message = string.Format("El contrato de {0} ha sido almacenado correctamente.",Profile.ProfileName);
                    MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } else {
                    usecase.EditContract(contract);
                    message= string.Format("El contrato de {0} ha sido actualizado correctamente.",Profile.ProfileName);
                    MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                result= true;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }

        private void LoadContractInfo() {
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(Profile.ProfileID,Profile.SingleProfileName);
                contract = usecase.FindOneContractByID(IdSelected);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void PutContractInfoToControls() {
            StartDateTimePicker.Value = contract.StartDate;
            EndDateTimePicker.Value = contract.EndDate;
            ContractValidCheckBox.Checked  = contract.IsValid==1;
            DescriptionContractTextBox.Text = contract.ContractDescription;
            CommissionNumericUpDown.Value = decimal.Parse(contract.ContractCommission.ToString());
            ContractTypeComboBox.Text = contract.TypeContract.ContractTypeName;
        }

        private void EditCustomer() {
            GetCurrentDetail();
            OpenCustomerAssociationForm(false);
        }

        private bool DeleteContract() {
            bool deleteStatus = false;
            string message = "¿Esta seguro de eliminar el contrato?";
            DialogResult result = MessageBox.Show(message,"Atención!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result.Equals(DialogResult.No)) return deleteStatus;
            ContractUseCase usecase = ContractUseCase.CreateUseCase(Profile.ProfileID, Profile.ProfileName);
            try {
                usecase.DeleteContract(this.IdSelected);
                message = "El contrato ha sido eliminado correctamente.";
                MessageBox.Show(message,"Atención!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                deleteStatus = true;
            } catch (Exception ex) {
                deleteStatus= false;
            }
            return deleteStatus;
        }


    }
}