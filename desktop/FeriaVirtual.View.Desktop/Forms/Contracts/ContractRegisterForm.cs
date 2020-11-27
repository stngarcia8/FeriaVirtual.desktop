using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.Business.HelpersUseCases;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Contracts{

    public partial class ContractRegisterForm : Form{

        private Contract contract;
        private ContractDetail currentDetail = ContractDetail.CreateDetail();
        private BindingList<ContractDetail> source;

        // Properties
        public bool IsNewRecord{ get; set; }

        public bool IsSaved{ get; set; }
        public string IdSelected{ get; set; }
        public IProfileInfo Profile{ get; set; }


        public ContractRegisterForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void ContractRegisterForm_Load(object sender, EventArgs e){
            ConfigureForm();
            LoadContractTypes();
            if (IsNewRecord){
                ContractValidCheckBox.Checked = true;
                contract = Contract.CreateContract();
                CleanControls();
            }
            else{
                LoadContractInfo();
                PutContractInfoToControls();
            }

            ConfigureBindingList();
            ConfigureCustomerList();
            StartDateTimePicker.Focus();
        }


        private void DeleteContractButton_Click(object sender, EventArgs e){
            if (!DeleteContract()) return;
            IsSaved = true;
            Close();
        }


        private void ContractSaveButton_Click(object sender, EventArgs e){
            if (!SaveContractData()) return;
            IsSaved = true;
            Close();
        }


        private void ContractCancelButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void ListClientDataGridView_SelectionChanged(object sender, EventArgs e){
            GetCurrentDetail();
        }


        private void ListClientDataGridView_DoubleClick(object sender, EventArgs e){
            EditCustomer();
        }


        private void ListRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            ConfigureCustomerList();
            ListClientDataGridView.Focus();
        }


        private void ListAddToolStripMenuItem_Click(object sender, EventArgs e){
            OpenCustomerAssociationForm(true);
        }


        private void ListEditToolStripMenuItem_Click(object sender, EventArgs e){
            EditCustomer();
        }


        private void ListRemoveToolStripMenuItem_Click(object sender, EventArgs e){
            if (ListClientDataGridView.Rows.Count.Equals(0)) return;
            if (ListClientDataGridView.SelectedRows.Count.Equals(0)) return;
            ListClientDataGridView.Rows.Remove(ListClientDataGridView.SelectedRows[0]);
        }


        private void ConfigureForm(){
            Text = IsNewRecord
                ? $"Nuevo contrato de {Profile.SingleProfileName}."
                : $"Editando contrato de {Profile.SingleProfileName}.";
            ListAddToolStripMenuItem.Text = $"Asociar nuevo {Profile.SingleProfileName}";
            DeleteContractButton.Visible = !IsNewRecord;
            ClientLabel.Text = $"{Profile.ProfileName} asociados al contrato.";
            ClientTabPage.Text = $"{Profile.ProfileName} asociados";
        }


        private void ConfigureBindingList(){
            source = new BindingList<ContractDetail>(contract.Details){
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };
            source.AllowNew = true;
        }


        private void LoadContractTypes(){
            ContractTypeComboBox.BeginUpdate();
            var usecase = ContractTypeUseCase.CreateUseCase();
            ContractTypeComboBox.DataSource = usecase.FindAll();
            ContractTypeComboBox.DisplayMember = "desc_tipo_contrato";
            ContractTypeComboBox.ValueMember = "id_tipo_contrato";
            ContractTypeComboBox.EndUpdate();
        }


        private void CleanControls(){
            StartDateTimePicker.Value = DateTime.Now.Date;
            EndDateTimePicker.Value = DateTime.Now.AddMonths(6);
            CommissionNumericUpDown.Value = 20;
            DescriptionContractTextBox.Text = string.Empty;
            ContractValidCheckBox.Checked = true;
            contract = Contract.CreateContract();
        }


        private void OpenCustomerAssociationForm(bool isNew){
            var form = new AssociateClientForm{
                CurrentDetail = currentDetail, Profile = Profile, IsNewRecord = isNew, ActualDetails = contract.Details
            };
            form.ShowDialog();
            if (!form.IsSaved || !isNew) return;
            contract.Details.Add(form.CurrentDetail);
            ConfigureBindingList();
            ConfigureCustomerList();
        }


        private void ConfigureCustomerList(){
            ListClientDataGridView.SelectionChanged -= ListClientDataGridView_SelectionChanged;
            ListClientDataGridView.DataSource = null;
            ListClientDataGridView.DataSource = source;
            ListClientDataGridView.Refresh();
            if (ListClientDataGridView.Rows.Count.Equals(0))
                DeleteContractButton.Visible = !IsNewRecord;
            else
                DeleteContractButton.Visible = false;
            ConfigureGrid();
            ListClientDataGridView.SelectionChanged += ListClientDataGridView_SelectionChanged;
        }


        private void ConfigureGrid(){
            IList<string> cols = new List<string>
                {"DetailId", "ContractObservation", "ClientObservation", "RegisterDate", "DateAcepted", "Status"};
            foreach (var col in cols) ListClientDataGridView.Columns[col].Visible = false;
            if (ListClientDataGridView == null) return;
            ListClientDataGridView.Columns["Customer"].HeaderText = Profile.SingleProfileName;
            ListClientDataGridView.Columns["StatusDescription"].HeaderText = "Estado";
            ConfigureNumericColumn("AdditionalValue", "Valor adic.");
            ConfigureNumericColumn("FineValue", "Valor multa");
        }


        private void ConfigureNumericColumn(string colName, string headerText){
            ListClientDataGridView.Columns[colName].HeaderText = headerText;
            ListClientDataGridView.Columns[colName].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            ListClientDataGridView.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListClientDataGridView.Columns[colName].DefaultCellStyle.Format = "N2";
        }


        private void GetCurrentDetail(){
            if (contract.Details.Count.Equals(0)){
                currentDetail = ContractDetail.CreateDetail();
                return;
            }

            var row = ListClientDataGridView.CurrentRow;
            if (row != null) currentDetail = row.DataBoundItem as ContractDetail;
        }


        private void PutInfoControlsToContract(){
            contract.StartDate = StartDateTimePicker.Value;
            contract.EndDate = EndDateTimePicker.Value;
            contract.IsValid = ContractValidCheckBox.Checked ? 1 : 0;
            contract.ContractDescription = DescriptionContractTextBox.Text;
            contract.ContractCommission = float.Parse(CommissionNumericUpDown.Value.ToString("N2"));
            contract.TypeContract.ContractTypeId = int.Parse(ContractTypeComboBox.SelectedValue.ToString());
            contract.TypeContract.ContractTypeName = ContractTypeComboBox.Text;
            contract.Details = contract.Details.ToList();
        }


        private bool SaveContractData(){
            bool result;
            PutInfoControlsToContract();
            try{
                string message;
                var usecase = ContractUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                if (IsNewRecord){
                    usecase.NewContract(contract);
                    message = $"El contrato de {Profile.ProfileName} ha sido almacenado correctamente.";
                    MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else{
                    usecase.EditContract(contract);
                    message = $"El contrato de {Profile.ProfileName} ha sido actualizado correctamente.";
                    MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }

            return result;
        }


        private void LoadContractInfo(){
            try{
                var usecase = ContractUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                contract = usecase.FindOneContractByID(IdSelected);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }


        private void PutContractInfoToControls(){
            StartDateTimePicker.Value = contract.StartDate;
            EndDateTimePicker.Value = contract.EndDate;
            ContractValidCheckBox.Checked = contract.IsValid == 1;
            DescriptionContractTextBox.Text = contract.ContractDescription;
            CommissionNumericUpDown.Value = decimal.Parse(contract.ContractCommission.ToString("N2"));
            ContractTypeComboBox.Text = contract.TypeContract.ContractTypeName;
        }


        private void EditCustomer(){
            GetCurrentDetail();
            OpenCustomerAssociationForm(false);
        }


        private bool DeleteContract(){
            bool deleteStatus;
            var message = "¿Esta seguro de eliminar el contrato?";
            var result = MessageBox.Show(message, "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No)) return false;
            var usecase = ContractUseCase.CreateUseCase(Profile.ProfileId, Profile.ProfileName);
            try{
                usecase.DeleteContract(IdSelected);
                message = "El contrato ha sido eliminado correctamente.";
                MessageBox.Show(message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deleteStatus = true;
            }
            catch{
                deleteStatus = false;
            }

            return deleteStatus;
        }

    }

}