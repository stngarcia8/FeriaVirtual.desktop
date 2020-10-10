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
        private Domain.Contracts.ContractDetail currentDetail = ContractDetail.CreateDetail();
        private BindingList<ContractDetail> source = new BindingList<ContractDetail>();

        // Properties
        public bool IsNewRecord { get; set; }
        public bool IsSaved { get; set; }
        public string idSelected { get; set; }
        public string ProfileName { get; set; }
        public string SingleProfileName { get; set; }
        public int ProfileID { get; set; }


        // Forms events method
        public ContractRegisterForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void ContractRegisterForm_Load(object sender,EventArgs e) {
            this.ConfigureForm();
            LoadContractTypes();
            if(IsNewRecord) {
                this.ContractValidCheckBox.Checked= true;
                this.contract = Domain.Contracts.Contract.CreateContract();
                 //this.contract.Details = new BindingList<ContractDetail>();
                CleanControls();
            } else {
                LoadContractInfo();
                PutContractInfoToControls();
            }
            source.AllowNew= true;
            source.AllowEdit= true;
            source.AllowRemove= true;
            StartDateTimePicker.Focus();
            this.ConfigureCustomerList();
        }



        // Form buttons events method.
      private void DeleteContractButton_Click(object sender,EventArgs e) {
            // aqui tengo que eliminar el contrato si es que se puede...
        }

        private void ContractSaveButton_Click(object sender,EventArgs e) {
            if(!SaveContractData()) {
                return;
            }
            this.IsSaved= true;
            this.Close();
        }

        private void ContractCancelButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }



        // datagridview events method
        private void ListClientDataGridView_SelectionChanged(object sender,EventArgs e) {
            this.GetCurrentDetail();
        }

        private void ListClientDataGridView_DoubleClick(object sender,EventArgs e) {
            this.GetCurrentDetail();
            OpenCustomerAssociationForm(false);
        }



        // datagridview contextmenu controls
        private void ListRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            this.ConfigureCustomerList();
            this.ListClientDataGridView.Focus();
        }

        private void ListAddToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenCustomerAssociationForm(true);
        }

        private void ListEditToolStripMenuItem_Click(object sender,EventArgs e) {
            GetCurrentDetail();
            OpenCustomerAssociationForm(false);
        }

        private void ListRemoveToolStripMenuItem_Click(object sender,EventArgs e) {
            if(this.ListClientDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            this.GetCurrentDetail();
            source.Remove(currentDetail);
            currentDetail = ContractDetail.CreateDetail();
            //this.ListClientDataGridView.Rows.Remove(this.ListClientDataGridView.SelectedRows[0]);
        }


        // Form methods
        private void ConfigureForm() {
            Text= (IsNewRecord ? string.Format("Nuevo contrato de {0}.",SingleProfileName) : string.Format("Editando contrato de {0}.",SingleProfileName));
            this.ListAddToolStripMenuItem.Text = string.Format("Asociar nuevo {0}",this.SingleProfileName);
            DeleteContractButton.Visible= !IsNewRecord;
            this.ClientLabel.Text= string.Format("{0} asociados al contrato.",this.ProfileName);
            this.ClientTabPage.Text = string.Format("{0} asociados",this.ProfileName);
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
            this.ListClientDataGridView.DataSource = source;
        }

        private void OpenCustomerAssociationForm(bool isNew) {
            AssociateClientForm form = new AssociateClientForm {
                CurrentDetail= this.currentDetail
            }; ;
            form.ProfileID = this.ProfileID;
            form.IsNewRecord = isNew;
            this.ProfileName= this.ProfileName;
            form.SingleProfileName=  this.SingleProfileName;
            form.ActualDetails = contract.Details;
            form.ShowDialog();
            if(form.IsSaved) {
                if(isNew) {
                    //source.Add(form.CurrentDetail);
                    this.contract.Details.Add(form.CurrentDetail);

                } else {
                    // aqui tengo que editar
                }
                this.ConfigureCustomerList();
            }
        }


        private void ConfigureCustomerList() {
            ListClientDataGridView.DataSource=this.contract.Details;
            //ListClientDataGridView.DataSource =source;
            ListClientDataGridView.Refresh();
            this.ConfigureGrid();
        }

        private void ConfigureGrid() {
            ListClientDataGridView.Columns["DetailID"].Visible=false;
            ListClientDataGridView.Columns["ContractObservation"].Visible=false;
            ListClientDataGridView.Columns["DateAcepted"].Visible=false;
            ListClientDataGridView.Columns["ClientObservation"].Visible=false;
            ListClientDataGridView.Columns["RegisterDate"].Visible=false;
            ListClientDataGridView.Columns["Customer"].HeaderText = this.SingleProfileName;
            ListClientDataGridView.Columns["AdditionalValue"].HeaderText = "Valor adic.";
            ListClientDataGridView.Columns["AdditionalValue"].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            ListClientDataGridView.Columns["AdditionalValue"].AutoSizeMode= DataGridViewAutoSizeColumnMode.ColumnHeader;
            ListClientDataGridView.Columns["FineValue"].HeaderText = "Valor multa";
            ListClientDataGridView.Columns["FineValue"].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            ListClientDataGridView.Columns["FineValue"].AutoSizeMode= DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void GetCurrentDetail() {
            if(source.Count.Equals(0)) {
                currentDetail = ContractDetail.CreateDetail();
                return;
            }
            DataGridViewRow row = this.ListClientDataGridView.SelectedRows[0];
            currentDetail = row.DataBoundItem as ContractDetail;
        }

        private void PutInfoControlsToContract() {
            this.contract.StartDate = this.StartDateTimePicker.Value;
            this.contract.EndDate = this.EndDateTimePicker.Value;
            this.contract.IsValid = (this.ContractValidCheckBox.Checked ? 1 : 0);
            this.contract.ContractDescription = this.DescriptionContractTextBox.Text;
            this.contract.ContractCommission = float.Parse(this.CommissionNumericUpDown.Value.ToString());
            this.contract.TypeContract.ContractTypeID= int.Parse(this.ContractTypeComboBox.SelectedValue.ToString());
            this.contract.TypeContract.ContractTypeName= this.ContractTypeComboBox.Text;
            this.contract.Details = source.ToList();
        }

        private bool SaveContractData() {
            bool result = false;
            string message = string.Empty;
            PutInfoControlsToContract();
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(this.ProfileID,this.SingleProfileName);
                if(IsNewRecord) {
                    usecase.NewContract(this.contract);
                    message = string.Format("El contrato de {0} ha sido almacenado correctamente.",this.ProfileName);
                    MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } else {
                    usecase.EditContract(this.contract);
                    message= string.Format("El contrato de {0} ha sido actualizado correctamente.",this.ProfileName);
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
                ContractUseCase usecase = ContractUseCase.CreateUseCase(ProfileID,SingleProfileName);
                this.contract = usecase.FindOneContractByID(this.idSelected);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void PutContractInfoToControls() {
            this.StartDateTimePicker.Value = this.contract.StartDate;
            this.EndDateTimePicker.Value = this.contract.EndDate;
            this.ContractValidCheckBox.Checked  = (this.contract.IsValid==1 ? true : false);
            this.DescriptionContractTextBox.Text = this.contract.ContractDescription;
            this.CommissionNumericUpDown.Value = decimal.Parse(this.contract.ContractCommission.ToString());
            this.ContractTypeComboBox.Text = this.contract.TypeContract.ContractTypeName;
        }






    }
}
