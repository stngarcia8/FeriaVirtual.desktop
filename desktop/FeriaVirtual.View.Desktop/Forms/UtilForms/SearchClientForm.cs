using System;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Elements;
using FeriaVirtual.Business.Users;


namespace FeriaVirtual.View.Desktop.Forms.UtilForms {

    public partial class SearchClientForm:Form {

        private string idSelected;

        // properties.
        public Domain.Users.Client CustomerFound { get; set; }
        public bool isFound { get; set; }
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }
        public string SingleProfileName { get; set; }

        public SearchClientForm() {
            InitializeComponent();
            isFound= false;
        }

        private void SearchClientForm_Load(object sender,EventArgs e) {
            Text = string.Format("Buscando {0}...",ProfileName);
            ListFilterTextBox.Text= string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void ListFilterComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            ListFilterTextBox.Visible = ListFilterComboBox.SelectedIndex.Equals(1) ? true : false;
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void SearchAceptButton_Click(object sender,EventArgs e) {
            LoadUserInfo();
            isFound= true;
            Close();
        }

        private void SearchCancelButton_Click(object sender,EventArgs e) {
            CustomerFound= null;
            isFound= false;
            Close();
        }

        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void ListDataGridView_DoubleClick(object sender,EventArgs e) {
            GetRecordId();
            LoadUserInfo();
            isFound= true;
            Close();
        }


        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Todos");
            ListFilterComboBox.Items.Add(string.Format("Nombre de {0}",SingleProfileName));
            ListFilterComboBox.Items.Add(string.Format("{0} habilitados",ProfileName));
            ListFilterComboBox.Items.Add(string.Format("{0} inhabilitados",ProfileName));
            ListFilterComboBox.EndUpdate();
        }

        private void LoadUsers(int filterType) {
            try {
                ClientUseCase useCase = ClientUseCase.CreateUseCase(ProfileID,SingleProfileName);
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
                ListCountLabel.Text = string.Format("No hay {0} disponibles.",ProfileName);
            } else {
                ListCountLabel.Text = string.Format("{0} {1} encontrados.",ListDataGridView.Rows.Count.ToString(),ProfileName);
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
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


        private void LoadUserInfo() {
            try {
                ClientUseCase usecase = ClientUseCase.CreateUseCase(ProfileID,SingleProfileName);
                GetClientData(usecase.FindClientById(idSelected));
                ComercialDataUseCase usecaseCD = ComercialDataUseCase.CreateUseCase();
                CustomerFound.ComercialInfo= usecaseCD.FindComercialDataByID(CustomerFound.ID);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                isFound= false;
                Close();
            }
        }

        private void GetClientData(DataTable clientInfo) {
            DataRow row = clientInfo.Rows[0];
            CustomerFound  = Domain.Users.Client.CreateClient(row["id_cliente"].ToString(),
                row["nombre_cliente"].ToString(),row["apellido_cliente"].ToString(),row["DNI"].ToString());
            CustomerFound.Credentials.UserId = row["id_usuario"].ToString();
            CustomerFound.Credentials.Username= row["username"].ToString();
            CustomerFound.Credentials.Password = row["password"].ToString();
            CustomerFound.Credentials.EncriptedPassword= row["password"].ToString();
            CustomerFound.Credentials.Email= row["Email"].ToString();
            CustomerFound.Credentials.IsActive= (int.Parse(row["is_active"].ToString()).Equals(1) ? true : false);
            CustomerFound.Profile.ProfileID= int.Parse(row["id_rol"].ToString());
            CustomerFound.Profile.ProfileName= row["Rol"].ToString();
        }



    }
}
