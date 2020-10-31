using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Forms.Contract {

    public partial class ContractMaintenanceForm:Form {
        private string idSelected;
        private IProfileInfo profile;

        // forms events methods
        public ContractMaintenanceForm() {
            InitializeComponent();
            profile = ProfileInfo.CreateProfileInfo(EnumProfileInfo.Producer).Profile;
        }

        private void ContractMaintenanceForm_Load(object sender,EventArgs e) {
            ListFilterTextBox.Visible=false;
            ConfigureForm();
        }

        // Menuitems events methods.
        private void OptionNewToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditToolStripMenuItem_Click(object sender,EventArgs e) {
            this.EditContract();
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }

        private void ClientProducerToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(EnumProfileInfo.Producer).Profile);
        }

        private void ClientCarrierToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(EnumProfileInfo.Carrier).Profile);
        }

        // Buttons forms events methods.
        private void OptionNewButton_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditButton_Click(object sender,EventArgs e) {
            this.EditContract();
        }

        private void OptionCloseButton_Click(object sender,EventArgs e) {
            Close();
        }

        // Filter controls events methods.
        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        // datagrid events methods.
        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void ListDataGridView_DoubleClick(object sender,EventArgs e) {
            this.EditContract();
        }

        // Forms methods.
        private void ConfigureForm() {
            Text= string.Format("Maestro de contratos para {0}",profile.ProfileName);
            OptionNewToolStripMenuItem.Text = string.Format("&Nuevo contrato de {0}",profile.SingleProfileName);
            OptionEditToolStripMenuItem.Text = string.Format("&Editar contrato de {0}",profile.SingleProfileName);
            ListTitleLabel.Text= string.Format("Lista de contratos de {0} disponibles",profile.ProfileName);
            ListFilterTextBox.Text= string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }

        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Todos los contratos");
            ListFilterComboBox.Items.Add(string.Format("Contratos de {0} vigentes",profile.ProfileName));
            ListFilterComboBox.Items.Add(string.Format("Contratos de {0} caducados",profile.ProfileName));
            ListFilterComboBox.EndUpdate();
        }

        private void LoadUsers(int filterType) {
            try {
                ContractUseCase useCase = ContractUseCase.CreateUseCase(profile.ProfileID,profile.SingleProfileName);
                DataTable data = new DataTable();
                ListDataGridView.DataSource = null;
                if(filterType.Equals(0)) {
                    data = useCase.FindAll();
                }
                if(filterType.Equals(1)) {
                    data = useCase.FindValidContract();
                }
                if(filterType.Equals(2)) {
                    data = useCase.FindInvalidContracts();
                }
                ListDataGridView.DataSource = data;
                HideColumns();
                DisplayCounts();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void HideColumns() {
            IList<string> cols = new List<string> { "id_contrato","id_tipo_contrato","esta_vigente","perfil_contrato","Fecha registro" };
            foreach(string col in cols) {
                ListDataGridView.Columns[col].Visible=false;
            }
        }

        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = string.Format("No hay contratos para {0} disponibles.",profile.ProfileName);
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled= false;
            } else {
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled= true;
                ListCountLabel.Text = string.Format("{0} contratos para {1} encontrados.",ListDataGridView.Rows.Count.ToString(),profile.ProfileName);
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.CurrentCell = ListDataGridView.Rows[0].Cells[4];
                ListDataGridView.Focus();
            }
        }

        private void OpenRegisterForm(bool isNew) {
            ContractRegisterForm form = new ContractRegisterForm {
                IsNewRecord = isNew,
                IdSelected = isNew ? string.Empty : idSelected,
                Profile = profile
            };
            form.ShowDialog();
            if(form.IsSaved) {
                LoadUsers(ListFilterComboBox.SelectedIndex);
                this.ListDataGridView.Focus();
            }
        }

        private void GetRecordId() {
            idSelected = string.Empty;
            if(ListDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            DataGridViewRow row = ListDataGridView.CurrentRow;
            if(row == null) {
                return;
            }
            idSelected=  row.Cells[0].Value.ToString();
        }

        private void ChangeFormStatus(IProfileInfo profile) {
            this.profile= profile;
            ConfigureForm();
        }

        private void EditContract() {
            GetRecordId();
            OpenRegisterForm(false);
        }

    }
}