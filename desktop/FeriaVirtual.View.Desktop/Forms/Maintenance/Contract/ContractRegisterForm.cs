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
        private Domain.Contracts.ContractDetail currentDetail;

        // Properties
        public bool IsNewRecord { get; set; }
        public bool IsSaved { get; set; }
        public string idSelected { get; set; }
        public string ProfileName { get; set; }
        public string SingleProfileName { get; set; }
        public int ProfileID { get; set; }

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
                PutsContractDataIntoControls();
            }
            // this.ConfigureCustomersList();
        }


      private void DeleteContractButton_Click(object sender,EventArgs e) {
            // aqui tengo que eliminar el contrato si es que se puede...
        }

        private void ContractSaveButton_Click(object sender,EventArgs e) {
            if(IsNewRecord) {
                if(!SaveContractData(true)) {
                    return;
                }
                } else {
                if(!SaveContractData(false)) {
                    return;
                }
            }
            IsSaved= true;
            this.Close();
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


        private void PutsControlsDataIntoContractObject() {
            this.contract.StartDate = this.StartDateTimePicker.Value;
            this.contract.EndDate = this.EndDateTimePicker.Value;
            this.contract.IsValid = (this.ContractValidCheckBox.Checked?1:0);
            this.contract.ContractDescription = this.DescriptionContractTextBox.Text;
            this.contract.ContractCommission = float.Parse(this.CommissionNumericUpDown.Value.ToString());
            this.contract.TypeContract.ContractTypeID= int.Parse( this.ContractTypeComboBox.SelectedValue.ToString());
            this.contract.TypeContract.ContractTypeName= this.ContractTypeComboBox.Text;
        }

        private void LoadUserInfo() {
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(ProfileID,SingleProfileName);
                GetContractData(usecase.FindContractById(this.idSelected));
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Close();
            }
        }


        private void GetContractData(DataTable contractInfo) {
            DataRow row = contractInfo.Rows[0];
            this.contract = Domain.Contracts.Contract.CreateContract();
            this.contract.ContractID = row["id_contrato"].ToString();
            this.contract.ContractDescription= row["Descripcion"].ToString();
            this.contract.TypeContract.ContractTypeID = int.Parse( row["id_tipo_contrato"].ToString());
            this.contract.TypeContract.ContractTypeName= row["Tipo"].ToString();
            this.contract.StartDate = DateTime.Parse(row["Inicio"].ToString());
            this.contract.EndDate = DateTime.Parse(row["Termino"].ToString());
            this.contract.IsValid = int.Parse(row["esta_vigente"].ToString());
            this.contract.ContractCommission = float.Parse(row["Comision"].ToString());
            this.contract.Details = new List<ContractDetail>();
                    }


        private void PutsContractDataIntoControls() {
            this.StartDateTimePicker.Value = this.contract.StartDate;
            this.EndDateTimePicker.Value = this.contract.EndDate;
            this.ContractValidCheckBox.Checked  = (this.contract.IsValid==1?true:false);
            this.DescriptionContractTextBox.Text = this.contract.ContractDescription;
            this.CommissionNumericUpDown.Value = decimal.Parse(this.contract.ContractCommission.ToString());
            this.ContractTypeComboBox.Text = this.contract.TypeContract.ContractTypeName;
            // this.ConfigureCustomersList();
        }


        private void ListRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            this.ConfigureCustomersList();
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
            if(this.contract.Details.Count.Equals(0)) return;
            string message = string.Format("¿Esta seguro de quitar {0} de la lista de asociados al contrato?", this.SingleProfileName);
            DialogResult result = MessageBox.Show(message, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.No) return;
            this.contract.Details.Remove(this.currentDetail);
            this.ConfigureCustomersList();
        }

        private void OpenCustomerAssociationForm(bool isNew) {
            AssociateClientForm form = new AssociateClientForm {
                CurrentDetail= this.currentDetail
            };;
            form.ProfileID = this.ProfileID;
            form.IsNewRecord = isNew;
            this.ProfileName= this.ProfileName;
            form.SingleProfileName=  this.SingleProfileName;
            form.ActualDetails = this.contract.Details;
            form.ShowDialog();
            if(form.IsSaved) {
                if(isNew) {
                    this.contract.AddDetail(form.CurrentDetail);
                } else {
                    this.ReplaceDetailData(form.CurrentDetail);
                }
                this.ConfigureCustomersList();
            }
        }

        private void ReplaceDetailData(ContractDetail newData) {
            foreach(ContractDetail d in this.contract.Details) {
                if(d.Customer.ID.Equals(newData.Customer.ID)) {
                    this.contract.Details.Remove(d);
                    this.contract.AddDetail(newData);
                    break;
                }
            }
        }


private void ConfigureCustomersList() {
            // this.ListClientDataGridView.SelectionChanged -= this.ListClientDataGridView_SelectionChanged;
            this.ListEditToolStripMenuItem.Enabled= (this.contract.Details.Count.Equals(0)?false:true);
            this.ListRemoveToolStripMenuItem.Enabled= (this.contract.Details.Count.Equals(0) ? false : true);
            BindingList<ContractDetail> bindingList = new BindingList<ContractDetail>(this.contract.Details);
            this.ListClientDataGridView.DataSource= null;
            this.ListClientDataGridView.DataSource= bindingList;
            if(this.ListClientDataGridView.Rows.Count>0) {
                this.currentDetail = this.contract.Details.First();
                this.ListClientDataGridView.Rows[0].Selected = true;
                this.ListClientDataGridView.Focus();
            }
            this.HideColumns();
            // this.ListClientDataGridView.SelectionChanged += this.ListClientDataGridView_SelectionChanged;
        }

        private void HideColumns() {
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
            OpenCustomerAssociationForm(false);
        }


        private void GetCurrentDetail() {
            if(this.ListClientDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            DataGridViewRow row = this.ListClientDataGridView.CurrentRow;
            if(row==null) {
                return;
            }
            try {
                this.currentDetail = Domain.Contracts.ContractDetail.CreateDetail();
                this.currentDetail.DetailID = row.Cells["DetailID"].Value.ToString();
                this.currentDetail.Customer = (Domain.Users.Client)row.Cells["Customer"].Value;
                this.currentDetail.AdditionalValue = float.Parse(row.Cells["AdditionalValue"].Value.ToString());
                this.currentDetail.FineValue= float.Parse(row.Cells["FineValue"].Value.ToString());
                this.currentDetail.ContractObservation = row.Cells["ContractObservation"].Value.ToString();
                this.currentDetail.ClientObservation= row.Cells["ClientObservation"].Value.ToString();
                this.currentDetail.DateAcepted= DateTime.Parse(row.Cells["DateAcepted"].Value.ToString());
                this.currentDetail.RegisterDate= DateTime.Parse(row.Cells["RegisterDate"].Value.ToString());
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool SaveContractData(bool isNew) {
            bool result = false;
            string message = string.Empty;
            PutsControlsDataIntoContractObject();
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



    }
}
