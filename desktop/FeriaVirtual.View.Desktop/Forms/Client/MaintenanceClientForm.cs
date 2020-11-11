using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Client{

    public partial class MaintenanceCarrierForm : Form{

        private string idSelected;
        public IProfileInfo Profile{ get; set; }


        public MaintenanceCarrierForm(){
            InitializeComponent();
            Profile = ProfileInfo.CreateProfileInfo(ProfileInfoEnum.ExternalCustomer).Profile;
        }


        private void MaintenanceCarrierForm_Load(object sender, EventArgs e){
            ConfigureForm();
        }


        private void OptionNewToolStripMenuItem_Click(object sender, EventArgs e){
            OpenRegisterForm(true);
        }


        private void OptionEditToolStripMenuItem_Click(object sender, EventArgs e){
            EditClient();
        }


        private void OptionRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void OptionCloseToolStripMenuItem_Click(object sender, EventArgs e){
            Close();
        }


        private void ClientExternalToolStripMenuItem_Click(object sender, EventArgs e){
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(ProfileInfoEnum.ExternalCustomer).Profile);
        }


        private void ClientInternalToolStripMenuItem_Click(object sender, EventArgs e){
            ChangeFormStatus(ProfileInfo.CreateProfileInfo(ProfileInfoEnum.InternalCustomer).Profile);
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
            EditClient();
        }


        private void OptionCloseButton_Click(object sender, EventArgs e){
            Close();
        }


        private void ListFilterComboBox_SelectedIndexChanged(object sender, EventArgs e){
            ListFilterTextBox.Visible = ListFilterComboBox.SelectedIndex.Equals(1);
        }


        private void ListFilterButton_Click(object sender, EventArgs e){
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void ListDataGridView_SelectionChanged(object sender, EventArgs e){
            GetRecordId();
        }


        private void ListDataGridView_DoubleClick(object sender, EventArgs e){
            EditClient();
        }


        private void ConfigureForm(){
            Text = $"Mantenedor de {Profile.ProfileName}";
            OptionNewToolStripMenuItem.Text = $"&Nuevo {Profile.SingleProfileName}";
            OptionEditToolStripMenuItem.Text = $"&Editar {Profile.SingleProfileName}";
            ListTitleLabel.Text = $"Lista de {Profile.ProfileName} disponibles";
            ListFilterTextBox.Text = string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }


        private void LoadFilters(){
            IList<string> filterList = new List<string>{
                $"Todos los {Profile.ProfileName}",
                $"Nombre de {Profile.SingleProfileName}",
                $"{Profile.ProfileName} habilitados",
                $"{Profile.ProfileName} inhabilitados"
            };
            var configurator = FilterComboConfigurator.CreateConfigurator(ListFilterComboBox);
            configurator.ClearFilters();
            configurator.LoadFilters(filterList);
        }


        private void LoadUsers(int filterType){
            try{
                var useCase = ClientUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                var data = new DataTable();
                ListDataGridView.DataSource = null;
                switch (filterType){
                    case 0:
                        data = useCase.FindAll();
                        break;
                    case 1:
                        data = useCase.FindClientByName(ListFilterTextBox.Text);
                        break;
                    case 2:
                        data = useCase.FindActiveClients();
                        break;
                    case 3:
                        data = useCase.FindInactiveClients();
                        break;
                }

                ListDataGridView.DataSource = data;
                var configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>{
                    "id_cliente", "id_usuario", "id_rol", "nombre_cliente", "apellido_cliente", "password", "is_active"
                };
                configurator.HideColumns(columns);
                DisplayCounts();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = $"No hay {Profile.ProfileName} disponibles.";
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled = false;
            }
            else{
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled = true;
                ListCountLabel.Text = $"{ListDataGridView.Rows.Count.ToString()} {Profile.ProfileName} encontrados.";
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }


        private void OpenRegisterForm(bool isNew){
            var form = new CarrierRegisterForm{
                Profile = Profile,
                IsNewRecord = isNew,
                IdSelected = isNew ? string.Empty : idSelected
            };
            form.ShowDialog();
            if (form.IsSaved) LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void GetRecordId(){
            idSelected = string.Empty;
            if (ListDataGridView.Rows.Count.Equals(0)) return;
            var row = ListDataGridView.CurrentRow;
            if (row == null) return;
            idSelected = row.Cells[1].Value.ToString();
        }


        private void ChangeFormStatus(IProfileInfo profile){
            Profile = profile;
            ConfigureForm();
        }


        private void EditClient(){
            GetRecordId();
            OpenRegisterForm(false);
        }

    }

}