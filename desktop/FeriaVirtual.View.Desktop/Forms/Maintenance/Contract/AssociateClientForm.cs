using System;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.View.Desktop.Forms.UtilForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {

    public partial class AssociateClientForm:Form {

        // Properties.
        public  Domain.Users.Client CustomerAssociated { get; set; }
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
            this.IsSaved= false;
        }

        private void AssociateClientForm_Load(object sender,EventArgs e) {
            this.Text= (this.IsNewRecord?string.Format("Asociando nuevo {0}.", this.SingleProfileName):string.Format("Editando {0} asociado.", this.SingleProfileName));
            this.AceptContractButton.Enabled = (IsNewRecord? false : true);
            this.DataClientGroupBox.Text= string.Format("Datos del {0}", this.SingleProfileName);
            if(this.IsNewRecord)  {
                this.CurrentDetail = ContractDetail.CreateDetail();
                this.ClearControls();
            } else {
            }
        }

        private void SearchClientButton_Click(object sender,EventArgs e) {
            SearchClientForm form = new SearchClientForm();
            form.SingleProfileName = this.SingleProfileName;
            form.ProfileID= this.ProfileID;
            form.ProfileName = this.ProfileName;
            form.ShowDialog();
            if(form.isFound) {
                if(FindRepeatCustomerInDetails(form.CustomerFound)) {
                    string message = string.Format("El {0} que intenta asociar al contrato ya se encuentra en la lista de {1} asociados al contrato.", this.SingleProfileName, this.ProfileName);
                    MessageBox.Show(message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.CustomerAssociated= null;
                    this.ClearControls();
                } else {
                    this.CustomerAssociated = form.CustomerFound;
                    PutCustomerDataIntoControls();
                }
            }
            this.AceptContractButton.Enabled = (CustomerAssociated==null?false:true);
        }

        private bool FindRepeatCustomerInDetails(Domain.Users.Client customer) {
            bool isRepeated = false;
            foreach(ContractDetail d in this.ActualDetails) {
                if(d.Customer.ID.Equals(customer.ID)) {
                    isRepeated= true;
                    break;
                }
            }
return isRepeated;
        }


        private void AceptContractButton_Click(object sender,EventArgs e) {
            this.CurrentDetail.Customer = this.CustomerAssociated;
            this.CurrentDetail.ContractObservation= this.ObservationTextBox.Text;
            this.CurrentDetail.AdditionalValue= float.Parse(this.AdditionalValueNumericUpDown.Value.ToString());
            this.CurrentDetail.FineValue= float.Parse(this.FineValueNumericUpDown.Value.ToString());
            this.CurrentDetail.ClientObservation= this.ObservationClientTextBox.Text;
            this.IsSaved= true;
            this.Close();
        }

        private void CancelContractButton_Click(object sender,EventArgs e) {
            this.IsSaved= false;
            this.Close();
        }

        private void ClearControls() {
            this.FirstNameTextBox.Text= string.Empty;
            this.LastNameTextBox.Text = string.Empty;
            this.DniTextBox.Text= string.Empty;
            this.CompanyNameTextBox.Text= string.Empty;
            this.FantasyNameTextBox.Text= string.Empty;
            this.CommercialBusinessTextBox.Text= string.Empty;
            this.CommercialDniTextBox.Text= string.Empty;
            this.EmailTextBox.Text= string.Empty;
            this.ObservationTextBox.Text= string.Empty;
            this.AdditionalValueNumericUpDown.Value= 0;
            this.FineValueNumericUpDown.Value= 0;
            this.ObservationClientTextBox.Text= string.Empty;
        }


        private void PutCustomerDataIntoControls() {
            this.FirstNameTextBox.Text= CustomerAssociated.FirstName;
            this.LastNameTextBox.Text = CustomerAssociated.LastName;
            this.DniTextBox.Text= CustomerAssociated.DNI;
            this.CompanyNameTextBox.Text= CustomerAssociated.ComercialInfo.CompanyName;
            this.FantasyNameTextBox.Text= CustomerAssociated.ComercialInfo.FantasyName;
            this.CommercialBusinessTextBox.Text= CustomerAssociated.ComercialInfo.ComercialBusiness;
            this.CommercialDniTextBox.Text= CustomerAssociated.ComercialInfo.ComercialDNI;
            this.EmailTextBox.Text= CustomerAssociated.ComercialInfo.Email;
        }





    }
}
