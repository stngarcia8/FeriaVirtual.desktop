using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.View.Desktop.Forms.UtilForms;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {

    public partial class AssociateClientForm:Form {

        // Properties.
        public Domain.Users.Client CustomerAssociated { get; set; }

        public bool IsNewRecord { get; set; }
        public bool IsSaved { get; set; }
        public string IdSelected { get; set; }
        public ContractDetail CurrentDetail { get; set; }
        public IList<ContractDetail> ActualDetails { get; set; }
        public IProfileInfo Profile { get; set; }

        public AssociateClientForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void AssociateClientForm_Load(object sender,EventArgs e) {
            Text= (IsNewRecord ? string.Format("Asociando nuevo {0}.",Profile.SingleProfileName) : string.Format("Editando {0} asociado.",Profile.SingleProfileName));
            AceptContractButton.Enabled = !IsNewRecord;
            SearchClientButton.Visible = IsNewRecord;
            DataClientGroupBox.Text= string.Format("Datos del {0}",Profile.SingleProfileName);
            if(IsNewRecord) {
                CurrentDetail = ContractDetail.CreateDetail();
                ClearControls();
            } else {
                PutInfoDataIntoControls();
            }
        }

        private void SearchClientButton_Click(object sender,EventArgs e) {
            SearchClientForm form = new SearchClientForm {
                Profile= Profile
            };
            form.ShowDialog();
            if(form.IsFound) {
                if(FindRepeatCustomerInDetails(form.CustomerFound)) {
                    string message = string.Format("El {0} que intenta asociar al contrato ya se encuentra en la lista de {1} asociados al contrato.",Profile.SingleProfileName,Profile.ProfileName);
                    MessageBox.Show(message,"Atención!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    CustomerAssociated= null;
                    ClearControls();
                } else {
                    CustomerAssociated = form.CustomerFound;
                    PutCustomerDataIntoControls();
                }
            }
            AceptContractButton.Enabled = CustomerAssociated !=null;
        }

        private bool FindRepeatCustomerInDetails(Domain.Users.Client customer) {
            bool isRepeated = false;
            foreach(ContractDetail d in ActualDetails) {
                if(d.Customer.ID.Equals(customer.ID)) {
                    isRepeated= true;
                    break;
                }
            }
            return isRepeated;
        }

        private void AceptContractButton_Click(object sender,EventArgs e) {
            CurrentDetail.Customer = CustomerAssociated;
            CurrentDetail.ContractObservation= ObservationTextBox.Text;
            CurrentDetail.AdditionalValue= float.Parse(AdditionalValueNumericUpDown.Value.ToString());
            CurrentDetail.FineValue= float.Parse(FineValueNumericUpDown.Value.ToString());
            IsSaved= true;
            Close();
        }

        private void CancelContractButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }

        private void ClearControls() {
            FirstNameTextBox.Text= string.Empty;
            LastNameTextBox.Text = string.Empty;
            DniTextBox.Text= string.Empty;
            CompanyNameTextBox.Text= string.Empty;
            FantasyNameTextBox.Text= string.Empty;
            CommercialBusinessTextBox.Text= string.Empty;
            CommercialDniTextBox.Text= string.Empty;
            EmailTextBox.Text= string.Empty;
            ObservationTextBox.Text= string.Empty;
            AdditionalValueNumericUpDown.Value= 0;
            FineValueNumericUpDown.Value= 0;
        }

        private void PutInfoDataIntoControls() {
            CustomerAssociated = CurrentDetail.Customer;
            PutCustomerDataIntoControls();
            ObservationTextBox.Text= CurrentDetail.ContractObservation;
            AdditionalValueNumericUpDown.Value = decimal.Parse(CurrentDetail.AdditionalValue.ToString());
            FineValueNumericUpDown.Value= decimal.Parse(CurrentDetail.FineValue.ToString());
            ObservationTextBox.Focus();
        }

        private void PutCustomerDataIntoControls() {
            try {

                FirstNameTextBox.Text= CustomerAssociated.FirstName;
                LastNameTextBox.Text = CustomerAssociated.LastName;
                DniTextBox.Text= CustomerAssociated.DNI;
                CompanyNameTextBox.Text= CustomerAssociated.ComercialInfo.CompanyName;
                FantasyNameTextBox.Text= CustomerAssociated.ComercialInfo.FantasyName;
                CommercialBusinessTextBox.Text= CustomerAssociated.ComercialInfo.ComercialBusiness;
                CommercialDniTextBox.Text= CustomerAssociated.ComercialInfo.ComercialDNI;
                EmailTextBox.Text= CustomerAssociated.ComercialInfo.Email;
                AceptContractButton.Enabled= true;
            } catch(Exception) {
                string message = string.Format("El {0} que desea agregar no posee sus datos comerciales ingresados, imposible agregar a contrato.",Profile.SingleProfileName);
                MessageBox.Show(message,"Atención!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                AceptContractButton.Enabled= false;

            }
        }
    }
}