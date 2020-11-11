using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Elements;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Data.Enums;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.UtilForms{

    public partial class SearchClientForm : Form{

        private string idSelected;

        // properties.
        public Domain.Users.Client CustomerFound{ get; set; }

        public bool IsFound{ get; set; }
        public IProfileInfo Profile{ get; set; }


        public SearchClientForm(){
            InitializeComponent();
            IsFound = false;
        }


        private void SearchClientForm_Load(object sender, EventArgs e){
            Text = $"Buscando {Profile.ProfileName}...";
            ListFilterTextBox.Text = string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void ListFilterComboBox_SelectedIndexChanged(object sender, EventArgs e){
            ListFilterTextBox.Visible = ListFilterComboBox.SelectedIndex.Equals(1);
        }


        private void ListFilterButton_Click(object sender, EventArgs e){
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }


        private void SearchAceptButton_Click(object sender, EventArgs e){
            LoadUserInfo();
            IsFound = true;
            Close();
        }


        private void SearchCancelButton_Click(object sender, EventArgs e){
            CustomerFound = null;
            IsFound = false;
            Close();
        }


        private void ListDataGridView_SelectionChanged(object sender, EventArgs e){
            GetRecordId();
        }


        private void ListDataGridView_DoubleClick(object sender, EventArgs e){
            GetRecordId();
            LoadUserInfo();
            IsFound = true;
            Close();
        }


        private void LoadFilters(){
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add($"Todos los {Profile.ProfileName}");
            ListFilterComboBox.Items.Add($"Nombre de {Profile.SingleProfileName}");
            ListFilterComboBox.Items.Add($"{Profile.ProfileName} habilitados");
            ListFilterComboBox.Items.Add($"{Profile.ProfileName} inhabilitados");
            ListFilterComboBox.EndUpdate();
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
                HideColumns();
                DisplayCounts();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void HideColumns(){
            IList<string> cols = new List<string>
                {"id_cliente", "id_usuario", "id_rol", "nombre_cliente", "apellido_cliente", "password", "is_active"};
            foreach (var col in cols) ListDataGridView.Columns[col].Visible = false;
        }


        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = $"No hay {Profile.ProfileName} disponibles.";
            }
            else{
                ListCountLabel.Text = $"{ListDataGridView.Rows.Count.ToString()} {Profile.ProfileName} encontrados.";
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }


        private void GetRecordId(){
            idSelected = string.Empty;
            if (ListDataGridView.Rows.Count.Equals(0)) return;
            var row = ListDataGridView.CurrentRow;
            if (row == null) return;
            row = ListDataGridView.CurrentRow;
            idSelected = row.Cells[1].Value.ToString();
        }


        private void LoadUserInfo(){
            try{
                var usecase = ClientUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                GetClientData(usecase.FindClientById(idSelected));
                var usecaseCd = ComercialDataUseCase.CreateUseCase();
                CustomerFound.ComercialInfo = usecaseCd.FindComercialDataById(CustomerFound.Id);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsFound = false;
                Close();
            }
        }


        private void GetClientData(DataTable clientInfo){
            var row = clientInfo.Rows[0];
            CustomerFound = Domain.Users.Client.CreateClient(row["id_cliente"].ToString(),
                row["nombre_cliente"].ToString(), row["apellido_cliente"].ToString(), row["DNI"].ToString());
            CustomerFound.Credentials.UserId = row["id_usuario"].ToString();
            CustomerFound.Credentials.Username = row["username"].ToString();
            CustomerFound.Credentials.Password = row["password"].ToString();
            CustomerFound.Credentials.EncriptedPassword = row["password"].ToString();
            CustomerFound.Credentials.Email = row["Email"].ToString();
            CustomerFound.Credentials.IsActive = int.Parse(row["is_active"].ToString()) == (int) UserStatus.Active;
            CustomerFound.Profile.ProfileId = int.Parse(row["id_rol"].ToString());
            CustomerFound.Profile.ProfileName = row["Rol"].ToString();
        }

    }

}