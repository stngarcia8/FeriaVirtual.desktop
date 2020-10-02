using System;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Contracts;


namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {

    public partial class ContractMaintenanceForm:Form {

        private string idSelected;
        private int profileID;
        private string profileName;
        private string singleProfileName;


        public ContractMaintenanceForm() {
            InitializeComponent();
            profileID=5;
            profileName= "Productores";
            singleProfileName="productor";
        }

        private void ContractMaintenanceForm_Load(object sender,EventArgs e) {
            ListFilterTextBox.Visible=false;
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
            // ListFilterTextBox.Visible = ListFilterComboBox.SelectedIndex.Equals(1) ? true : false;
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
            Text= string.Format("Maestro de contratos para {0}",profileName);
            OptionNewToolStripMenuItem.Text = string.Format("&Nuevo contrato de {0}",singleProfileName);
            OptionEditToolStripMenuItem.Text = string.Format("&Editar contrato de {0}",singleProfileName);
            ListTitleLabel.Text= string.Format("Lista de contratos de {0} disponibles",profileName);
            ListFilterTextBox.Text= string.Empty;
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadUsers(0);
        }



        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Todos los contratos");
            ListFilterComboBox.Items.Add(string.Format("Contratos de {0} vigentes",profileName));
            ListFilterComboBox.Items.Add(string.Format("Contratos de {0} caducados",profileName));
            ListFilterComboBox.EndUpdate();
        }



        private void LoadUsers(int filterType) {
            try {
                ContractUseCase useCase = ContractUseCase.CreateUseCase(profileID,singleProfileName);
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
            ListDataGridView.Columns["id_contrato"].Visible= false;
            ListDataGridView.Columns["id_tipo_contrato"].Visible= false;
            ListDataGridView.Columns["esta_vigente"].Visible= false;
            ListDataGridView.Columns["perfil_contrato"].Visible= false;
            ListDataGridView.Columns["Fecha registro"].Visible= false;
        }


        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = string.Format("No hay contratos para {0} disponibles.",profileName);
                OptionEditButton.Enabled = false;
                OptionEditToolStripMenuItem.Enabled= false;
            } else {
                OptionEditButton.Enabled = true;
                OptionEditToolStripMenuItem.Enabled= true;
                ListCountLabel.Text = string.Format("{0} contratos para {1} encontrados.",ListDataGridView.Rows.Count.ToString(),profileName);
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.CurrentCell = ListDataGridView.Rows[0].Cells[4];
                ListDataGridView.Focus();
            }
        }



        private void OpenRegisterForm(bool isNew) {
            ContractRegisterForm form = new ContractRegisterForm {
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
            idSelected=  row.Cells[0].Value.ToString();
        }


        private void ChangeFormStatus(int id,string prural,string singular) {
            profileID=id;
            profileName= prural;
            singleProfileName=singular;
            ConfigureForm();
        }


    }
}
