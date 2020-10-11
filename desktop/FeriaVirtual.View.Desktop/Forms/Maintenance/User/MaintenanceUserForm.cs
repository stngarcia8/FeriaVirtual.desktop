using System;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.User {

    public partial class MaintenanceUserForm:Form {
        private string idSelected;

        public MaintenanceUserForm() {
            InitializeComponent();
        }

        private void MaintenanceUserForm_Load(object sender,EventArgs e) {
            ListFilterTextBox.Text = string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }

        private void OptionNewToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditToolStripMenuItem_Click(object sender,EventArgs e) {
            EditUserInfo();
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadUsers(ListFilterComboBox.SelectedIndex);
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }

        private void OptionNewButton_Click(object sender,EventArgs e) {
            OpenRegisterForm(true);
        }

        private void OptionEditButton_Click(object sender,EventArgs e) {
            EditUserInfo();
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
            EditUserInfo();
        }

        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Todos");
            ListFilterComboBox.Items.Add("Nombre de usuario");
            ListFilterComboBox.Items.Add("Usuarios habilitados");
            ListFilterComboBox.Items.Add("Usuarios inhabilitados");
            ListFilterComboBox.EndUpdate();
        }

        private void LoadUsers(int filterType) {
            try {
                EmployeeUseCase useCase = EmployeeUseCase.CreateUseCase();
                DataTable data = new DataTable();
                ListDataGridView.DataSource = null;
                if(filterType.Equals(0)) {
                    data = useCase.FindAll();
                }
                if(filterType.Equals(1)) {
                    data=useCase.FindUsersByUsername(ListFilterTextBox.Text);
                }
                if(filterType.Equals(2)) {
                    data = useCase.FindActiveUsers();
                }
                if(filterType.Equals(3)) {
                    data = useCase.FindInactiveUsers();
                }
                ListDataGridView.DataSource = data;
                HideColumns();
                DisplayCounts();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void HideColumns() {
            ListDataGridView.Columns["id_usuario"].Visible = false;
            ListDataGridView.Columns["id_empleado"].Visible = false;
            ListDataGridView.Columns["password"].Visible = false;
            ListDataGridView.Columns["id_rol"].Visible = false;
            ListDataGridView.Columns["is_active"].Visible = false;
        }

        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = "No hay registros disponibles.";
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled = false;
            } else {
                ListCountLabel.Text = ListDataGridView.Rows.Count.ToString() + " registros encontrados.";
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled = true;
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.CurrentCell = ListDataGridView.Rows[0].Cells[3];
                ListDataGridView.Focus();
            }
        }

        private void OpenRegisterForm(bool isNew) {
            UserRegisterForm userRegisterForm = new UserRegisterForm();
            UserRegisterForm form = userRegisterForm;
            form.IsNewRecord = isNew;
            form.IdSelected = (isNew ? string.Empty : idSelected);
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

        private void EditUserInfo() {
            GetRecordId();
            OpenRegisterForm(false);
        }
    }
}