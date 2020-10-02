using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.View.Desktop.Forms.UtilForms;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {

    public partial class AssociateClientForm:Form {

        // Properties.
        public Domain.Users.Client CustomerAssociated { get; set; }
        public bool IsNewRecord { get; set; }
        public bool IsSaved { get; set; }
        public string idSelected { get; set; }
        public string ProfileName { get; set; }
        public string SingleProfileName { get; set; }
        public int ProfileID { get; set; }
        public ContractDetail CurrentDetail { get; set; }
        public IList<ContractDetail> ActualDetails { get; set; }

        public AssociateClientForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void AssociateClientForm_Load(object sender,EventArgs e) {
            Text= (IsNewRecord ? string.Format("Asociando nuevo {0}.",SingleProfileName) : string.Format("Editando {0} asociado.",SingleProfileName));
            AceptContractButton.Enabled = (IsNewRecord ? false : true);
            SearchClientButton.Visible = (!IsNewRecord ? false : true);
            DataClientGroupBox.Text= string.Format("Datos del {0}",SingleProfileName);
            if(IsNewRecord) {
                CurrentDetail = ContractDetail.CreateDetail();
                ClearControls();
            } else {
                putInfoDataIntoControls();
            }
        }

        private void SearchClientButton_Click(object sender,EventArgs e) {
            SearchClientForm form = new SearchClientForm {
                SingleProfileName = SingleProfileName,
                ProfileID= ProfileID,
                ProfileName = ProfileName
            };
            form.ShowDialog();
            if(form.isFound) {
                if(FindRepeatCustomerInDetails(form.CustomerFound)) {
                    string message = string.Format("El {0} que intenta asociar al contrato ya se encuentra en la lista de {1} asociados al contrato.",SingleProfileName,ProfileName);
                    MessageBox.Show(message,"Atención!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    CustomerAssociated= null;
                    ClearControls();
                } else {
                    CustomerAssociated = form.CustomerFound;
                    PutCustomerDataIntoControls();
                }
            }
            AceptContractButton.Enabled = (CustomerAssociated==null ? false : true);
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
            CurrentDetail.ClientObservation= ObservationClientTextBox.Text;
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
            ObservationClientTextBox.Text= string.Empty;
        }

        private void putInfoDataIntoControls() {
            CustomerAssociated = CurrentDetail.Customer;
            PutCustomerDataIntoControls();
            ObservationTextBox.Text= CurrentDetail.ContractObservation;
            AdditionalValueNumericUpDown.Value = decimal.Parse(CurrentDetail.AdditionalValue.ToString());
            FineValueNumericUpDown.Value= decimal.Parse(CurrentDetail.FineValue.ToString());
            ObservationClientTextBox.Text= CurrentDetail.ClientObservation;
            ObservationTextBox.Focus();
        }



        private void PutCustomerDataIntoControls() {
            FirstNameTextBox.Text= CustomerAssociated.FirstName;
            LastNameTextBox.Text = CustomerAssociated.LastName;
            DniTextBox.Text= CustomerAssociated.DNI;
            CompanyNameTextBox.Text= CustomerAssociated.ComercialInfo.CompanyName;
            FantasyNameTextBox.Text= CustomerAssociated.ComercialInfo.FantasyName;
            CommercialBusinessTextBox.Text= CustomerAssociated.ComercialInfo.ComercialBusiness;
            CommercialDniTextBox.Text= CustomerAssociated.ComercialInfo.ComercialDNI;
            EmailTextBox.Text= CustomerAssociated.ComercialInfo.Email;
        }







    }
}
