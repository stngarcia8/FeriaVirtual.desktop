using System;
using FeriaVirtual.Business.Users;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.User {
    public partial class MaintenanceUserForm:Form {

        private string idSelected;

        public MaintenanceUserForm() {
            InitializeComponent();
        }

        private void MaintenanceUserForm_Load(object sender,EventArgs e) {
            this.ListFilterTextBox.Text = string.Empty;
            this.LoadFilters();
            this.ListFilterComboBox.SelectedIndex = 0;
            this.LoadUsers( 0 );
        }

        private void OptionNewButton_Click(object sender,EventArgs e) {
            this.OpenRegisterForm( true );
        }

        private void OptionEditButton_Click(object sender,EventArgs e) {
            this.GetRecordId();
            this.OpenRegisterForm( false );
        }

        private void OptionCloseButton_Click(object sender,EventArgs e) {
            this.Close();
        }

        private void ListFilterComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            this.ListFilterTextBox.Visible = (this.ListFilterComboBox.SelectedIndex.Equals( 1 ) ? true : false);
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            this.LoadUsers( this.ListFilterComboBox.SelectedIndex );
        }

        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            this.GetRecordId();
        }

        private void ListDataGridView_DoubleClick(object sender,EventArgs e) {
            this.GetRecordId();
            this.OpenRegisterForm( false );
        }



        private void LoadFilters() {
            this.ListFilterComboBox.BeginUpdate();
            this.ListFilterComboBox.Items.Add( "Todos" );
            this.ListFilterComboBox.Items.Add( "Nombre de usuario" );
            this.ListFilterComboBox.Items.Add( "Usuarios habilitados" );
            this.ListFilterComboBox.Items.Add( "Usuarios inhabilitados" );
            this.ListFilterComboBox.EndUpdate();
        }


        private void LoadUsers(int filterType) {
            try {
                EmployeeUseCase useCase = EmployeeUseCase.Create();
                DataTable data = new DataTable();
                this.ListDataGridView.DataSource = null;
                if(filterType.Equals( 0 )) data = useCase.FindAll();
                if(filterType.Equals( 1 )) data = useCase.FindUserByUsername( this.ListFilterTextBox.Text );
                if(filterType.Equals( 2 )) data = useCase.FindActiveUsers();
                if(filterType.Equals( 3 )) data = useCase.FindInactiveUsers();
                this.ListDataGridView.DataSource = data;
                 this.HideColumns();
                this.DisplayCounts();
            } catch(Exception ex) {
                MessageBox.Show( ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
            }
        }


        private void HideColumns() {
            this.ListDataGridView.Columns["id_usuario"].Visible = false;
            this.ListDataGridView.Columns["id_empleado"].Visible = false;
            this.ListDataGridView.Columns["password"].Visible = false;
            this.ListDataGridView.Columns["id_rol"].Visible = false;
            this.ListDataGridView.Columns["is_active"].Visible = false;
        }



        private void DisplayCounts() {
            if(this.ListDataGridView.Rows.Count.Equals( 0 )) {
                this.ListCountLabel.Text = "No hay registros disponibles.";
                this.OptionEditButton.Enabled = false;
            } else {
                this.ListCountLabel.Text = this.ListDataGridView.Rows.Count.ToString() + " registros encontrados.";
                this.ListDataGridView.Rows[0].Selected = true;
                this.ListDataGridView.Focus();
            }
        }


        private void OpenRegisterForm(bool isNew) {
            UserRegisterForm form = new UserRegisterForm();
             form.IsNewRecord = isNew;
              form.idSelected = (isNew ? string.Empty : this.idSelected);
            form.ShowDialog();
             if(form.IsSaved) this.LoadUsers( this.ListFilterComboBox.SelectedIndex );
        }


        private void GetRecordId() {
            this.idSelected = string.Empty;
            if(this.ListDataGridView.Rows.Count.Equals( 0 )) return;
            DataGridViewRow row = this.ListDataGridView.CurrentRow;
            if(row == null) return;
            this.idSelected=  row.Cells[1].Value.ToString();
        }




    }
}
