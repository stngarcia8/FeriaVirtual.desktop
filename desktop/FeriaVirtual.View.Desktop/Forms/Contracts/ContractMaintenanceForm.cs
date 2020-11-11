using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Contracts{

    public partial class ContractMaintenanceForm : Form{

        private string idSelected;
        private IProfileInfo profile;


        public ContractMaintenanceForm(){
            InitializeComponent();
            profile = ProfileInfo.CreateProfileInfo(ProfileInfoEnum.Producer).Profile;
        }


        private void ContractMaintenanceForm_Load(object sender, EventArgs e){
            ListFilterTextBox.Visible = false;
            ConfigureForm();
        }


        private void OptionNewToolStripMenuItem_Click(object sender, EventArgs e){
            OpenRegisterForm(true);
        }


        private void OptionEditToolStripMenuItem_Click(object sender, EventArgs e){
            EditContract();
        }


        private void OptionRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void OptionCloseToolStripMenuItem_Click(object sender, EventArgs e){
            Close();
        }


        private void ClientProducerToolStripMenuItem_Click(object sender, EventArgs e){
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(ProfileInfoEnum.Producer).Profile);
        }


        private void ClientCarrierToolStripMenuItem_Click(object sender, EventArgs e){
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(ProfileInfoEnum.Carrier).Profile);
        }


        private void OptionNewButton_Click(object sender, EventArgs e){
            OpenRegisterForm(true);
        }


        private void OptionEditButton_Click(object sender, EventArgs e){
            EditContract();
        }


        private void OptionCloseButton_Click(object sender, EventArgs e){
            Close();
        }


        private void ListFilterButton_Click(object sender, EventArgs e){
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void ListDataGridView_SelectionChanged(object sender, EventArgs e){
            GetRecordId();
        }


        private void ListDataGridView_DoubleClick(object sender, EventArgs e){
            EditContract();
        }


        private void ConfigureForm(){
            Text = $"Maestro de contratos para {profile.ProfileName}";
            OptionNewToolStripMenuItem.Text = $"&Nuevo contrato de {profile.SingleProfileName}";
            OptionEditToolStripMenuItem.Text = $"&Editar contrato de {profile.SingleProfileName}";
            ListTitleLabel.Text = $"Lista de contratos de {profile.ProfileName} disponibles";
            ListFilterTextBox.Text = string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }


        private void LoadFilters(){
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Todos los contratos");
            ListFilterComboBox.Items.Add($"Contratos de {profile.ProfileName} vigentes");
            ListFilterComboBox.Items.Add($"Contratos de {profile.ProfileName} caducados");
            ListFilterComboBox.EndUpdate();
        }


        private void LoadUsers(int filterType){
            try{
                var useCase = ContractUseCase.CreateUseCase(profile.ProfileId, profile.SingleProfileName);
                var data = new DataTable();
                ListDataGridView.DataSource = null;
                switch (filterType){
                    case 0:
                        data = useCase.FindAll();
                        break;
                    case 1:
                        data = useCase.FindValidContract();
                        break;
                    case 2:
                        data = useCase.FindInvalidContracts();
                        break;
                }

                ListDataGridView.DataSource = data;
                HideColumns();
                DisplayCounts();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void HideColumns(){
            IList<string> cols = new List<string>
                {"id_contrato", "id_tipo_contrato", "esta_vigente", "perfil_contrato", "Fecha registro"};
            foreach (var col in cols) ListDataGridView.Columns[col].Visible = false;
        }


        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = $"No hay contratos para {profile.ProfileName} disponibles.";
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled = false;
            }
            else{
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled = true;
                ListCountLabel.Text =
                    $"{ListDataGridView.Rows.Count.ToString()} contratos para {profile.ProfileName} encontrados.";
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.CurrentCell = ListDataGridView.Rows[0].Cells[4];
                ListDataGridView.Focus();
            }
        }


        private void OpenRegisterForm(bool isNew){
            var form = new ContractRegisterForm{
                IsNewRecord = isNew,
                IdSelected = isNew ? string.Empty : idSelected,
                Profile = profile
            };
            form.ShowDialog();
            if (!form.IsSaved) return;
            LoadUsers(ListFilterComboBox.SelectedIndex);
            ListDataGridView.Focus();
        }


        private void GetRecordId(){
            idSelected = string.Empty;
            if (ListDataGridView.Rows.Count.Equals(0)) return;
            var row = ListDataGridView.CurrentRow;
            if (row == null) return;
            idSelected = row.Cells[0].Value.ToString();
        }


        private void ChangeFormStatus(IProfileInfo profile){
            this.profile = profile;
            ConfigureForm();
        }


        private void EditContract(){
            GetRecordId();
            OpenRegisterForm(false);
        }

    }

}