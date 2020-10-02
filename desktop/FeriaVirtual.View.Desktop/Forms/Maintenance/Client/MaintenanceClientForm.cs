using System;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Client {

    public partial class MaintenanceCarrierForm:Form {

        private string idSelected;
        private int profileID;
        private string profileName;
        private string singleProfileName;

        public MaintenanceCarrierForm() {
            InitializeComponent();
            profileID=3;
            profileName= "Clientes externos";
            singleProfileName="cliente externo";
        }

        private void MaintenanceCarrierForm_Load(object sender,EventArgs e) {
            ConfigureForm();
        }


        private void OptionNewToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditToolStripMenuItem_Click(object sender,EventArgs e) {
            GetRecordId();
            OpenRegisterForm(false);
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }



        private void ClientExternalToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(3,"clientes externos","cliente externo");
        }

        private void ClientInternalToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(4,"clientes internos","cliente interno");
        }

        private void ClientProducerToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(5,"productores","productor");
        }

        private void ClientCarrierToolStripMenuItem_Click(object sender,EventArgs e) {
            ChangeFormStatus(6,"transportistas","transportista");
        }



        private void OptionNewButton_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditButton_Click(object sender,EventArgs e) {
            GetRecordId();
            OpenRegisterForm(false);
        }

        private void OptionCloseButton_Click(object sender,EventArgs e) {
            Close();
        }


        private void ListFilterComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            ListFilterTextBox.Visible = ListFilterComboBox.SelectedIndex.Equals(1) ? true : false;
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void ListDataGridView_DoubleClick(object sender,EventArgs e) {
            GetRecordId();
            OpenRegisterForm(false);
        }


        private void ConfigureForm() {
            Text= string.Format("Mantenedor de {0}",profileName);
            OptionNewToolStripMenuItem.Text = string.Format("&Nuevo {0}",singleProfileName);
            OptionEditToolStripMenuItem.Text = string.Format("&Editar {0}",singleProfileName);
            ListTitleLabel.Text= string.Format("Lista de {0} disponibles",profileName);
            ListFilterTextBox.Text= string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }


        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Todos");
            ListFilterComboBox.Items.Add(string.Format("Nombre de {0}",singleProfileName));
            ListFilterComboBox.Items.Add(string.Format("{0} habilitados",profileName));
            ListFilterComboBox.Items.Add(string.Format("{0} inhabilitados",profileName));
            ListFilterComboBox.EndUpdate();
        }


        private void LoadUsers(int filterType) {
            try {
                ClientUseCase useCase = ClientUseCase.CreateUseCase(profileID,singleProfileName);
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
                HideColumns();
                DisplayCounts();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }


        private void HideColumns() {
            ListDataGridView.Columns["id_cliente"].Visible = false;
            ListDataGridView.Columns["id_usuario"].Visible = false;
            ListDataGridView.Columns["id_rol"].Visible = false;
            ListDataGridView.Columns["nombre_cliente"].Visible = false;
            ListDataGridView.Columns["apellido_cliente"].Visible = false;
            ListDataGridView.Columns["password"].Visible = false;
            ListDataGridView.Columns["is_active"].Visible = false;
        }


        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = string.Format("No hay {0} disponibles.",profileName);
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled= false;
            } else {
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled= true;
                ListCountLabel.Text = string.Format("{0} {1} encontrados.",ListDataGridView.Rows.Count.ToString(),profileName);
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }


        private void OpenRegisterForm(bool isNew) {
            CarrierRegisterForm form = new CarrierRegisterForm {
                IsNewRecord = isNew,
                idSelected = isNew ? string.Empty : idSelected
            };
            form.ProfileID= profileID;
            form.ProfileName= profileName;
            form.SingleProfileName= singleProfileName;
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


        private void ChangeFormStatus(int id,string prural,string singular) {
            profileID=id;
            profileName= prural;
            singleProfileName=singular;
            ConfigureForm();
        }



    }
}
