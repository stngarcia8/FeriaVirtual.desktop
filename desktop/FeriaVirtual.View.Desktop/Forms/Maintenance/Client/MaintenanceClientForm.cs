using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Client {

    public partial class MaintenanceCarrierForm:Form {
        private string idSelected;
        public IProfileInfo Profile { get; set; }

        public MaintenanceCarrierForm() {
            InitializeComponent();
            Profile = ProfileInfo.CreateProfileInfo(EnumProfileInfo.External_customer).Profile;
        }

        private void MaintenanceCarrierForm_Load(object sender,EventArgs e) {
            ConfigureForm();
        }

        private void OptionNewToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditToolStripMenuItem_Click(object sender,EventArgs e) {
            EditClient();
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }

        private void ClientExternalToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(EnumProfileInfo.External_customer).Profile);
        }

        private void ClientInternalToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(EnumProfileInfo.Internal_customer).Profile);
        }

        private void ClientProducerToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(EnumProfileInfo.Producer).Profile);
        }

        private void ClientCarrierToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(EnumProfileInfo.Carrier).Profile);
        }

        private void OptionNewButton_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditButton_Click(object sender,EventArgs e) {
            EditClient();
        }

        private void OptionCloseButton_Click(object sender,EventArgs e) {
            Close();
        }

        private void ListFilterComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            ListFilterTextBox.Visible = ListFilterComboBox.SelectedIndex.Equals(1);
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void ListDataGridView_DoubleClick(object sender,EventArgs e) {
            EditClient();
        }

        private void ConfigureForm() {
            Text= string.Format("Mantenedor de {0}",Profile.ProfileName);
            OptionNewToolStripMenuItem.Text = string.Format("&Nuevo {0}",Profile.SingleProfileName);
            OptionEditToolStripMenuItem.Text = string.Format("&Editar {0}",Profile.SingleProfileName);
            ListTitleLabel.Text= string.Format("Lista de {0} disponibles",Profile.ProfileName);
            ListFilterTextBox.Text= string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }

        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add(string.Format("Todos los {0}",Profile.ProfileName));
            ListFilterComboBox.Items.Add(string.Format("Nombre de {0}",Profile.SingleProfileName));
            ListFilterComboBox.Items.Add(string.Format("{0} habilitados",Profile.ProfileName));
            ListFilterComboBox.Items.Add(string.Format("{0} inhabilitados",Profile.ProfileName));
            ListFilterComboBox.EndUpdate();
        }

        private void LoadUsers(int filterType) {
            try {
                ClientUseCase useCase = ClientUseCase.CreateUseCase(Profile.ProfileID,Profile.SingleProfileName);
                DataTable data = new DataTable();
                ListDataGridView.DataSource = null;
                if(filterType.Equals(0)) {
                    data = useCase.FindAll();
                }
                if(filterType.Equals(1)) {
                    data = useCase.FindClientByName(ListFilterTextBox.Text);
                }
                if(filterType.Equals(2)) {
                    data = useCase.FindActiveClients();
                }
                if(filterType.Equals(3)) {
                    data = useCase.FindInactiveClients();
                }
                ListDataGridView.DataSource = data;
                DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>() { "id_cliente","id_usuario","id_rol","nombre_cliente","apellido_cliente","password","is_active" };
                configurator.HideColumns(columns);
                DisplayCounts();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = string.Format("No hay {0} disponibles.",Profile.ProfileName);
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled= false;
            } else {
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled= true;
                ListCountLabel.Text = string.Format("{0} {1} encontrados.",ListDataGridView.Rows.Count.ToString(),Profile.ProfileName);
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }

        private void OpenRegisterForm(bool isNew) {
            CarrierRegisterForm form = new CarrierRegisterForm {
                Profile = Profile,
                IsNewRecord = isNew,
                IdSelected = isNew ? string.Empty : idSelected
            };
            form.ShowDialog();
            if(form.IsSaved) {
                LoadUsers(ListFilterComboBox.SelectedIndex);
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
            idSelected=  row.Cells[1].Value.ToString();
        }

        private void ChangeFormStatus(IProfileInfo profile) {
            Profile = profile;
            ConfigureForm();
        }

        private void EditClient() {
            GetRecordId();
            OpenRegisterForm(false);
        }
    }
}