using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.View.Desktop.Forms.UtilForms;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Contracts{

    public partial class AssociateClientForm : Form{

        // Properties.
        public Domain.Users.Client CustomerAssociated{ get; set; }

        public bool IsNewRecord{ get; set; }
        public bool IsSaved{ get; set; }
        public string IdSelected{ get; set; }
        public ContractDetail CurrentDetail{ get; set; }
        public IList<ContractDetail> ActualDetails{ get; set; }
        public IProfileInfo Profile{ get; set; }


        public AssociateClientForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void AssociateClientForm_Load(object sender, EventArgs e){
            Text = IsNewRecord
                ? $"Asociando nuevo {Profile.SingleProfileName}."
                : $"Editando {Profile.SingleProfileName} asociado.";
            AceptContractButton.Enabled = !IsNewRecord;
            SearchClientButton.Visible = IsNewRecord;
            DataClientGroupBox.Text = $"Datos del {Profile.SingleProfileName}";
            if (IsNewRecord){
                CurrentDetail = ContractDetail.CreateDetail();
                ClearControls();
            }
            else{
                PutInfoDataIntoControls();
            }
        }


        private void SearchClientButton_Click(object sender, EventArgs e){
            var form = new SearchClientForm{
                Profile = Profile
            };
            form.ShowDialog();
            if (form.IsFound){
                if (FindRepeatCustomerInDetails(form.CustomerFound)){
                    var message =
                        $"El {Profile.SingleProfileName} que intenta asociar al contrato ya se encuentra en la lista de {Profile.ProfileName} asociados al contrato.";
                    MessageBox.Show(message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CustomerAssociated = null;
                    ClearControls();
                }
                else{
                    CustomerAssociated = form.CustomerFound;
                    PutCustomerDataIntoControls();
                }
            }

            AceptContractButton.Enabled = CustomerAssociated != null;
        }


        private bool FindRepeatCustomerInDetails(Person customer){
            return ActualDetails.Any(d => d.Customer.Id.Equals(customer.Id));
        }


        private void AceptContractButton_Click(object sender, EventArgs e){
            CurrentDetail.Customer = CustomerAssociated;
            CurrentDetail.ContractObservation = ObservationTextBox.Text;
            CurrentDetail.AdditionalValue = float.Parse(AdditionalValueNumericUpDown.Value.ToString("N2"));
            CurrentDetail.FineValue = float.Parse(FineValueNumericUpDown.Value.ToString("N2"));
            IsSaved = true;
            Close();
        }


        private void CancelContractButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void ClearControls(){
            FirstNameTextBox.Text = string.Empty;
            LastNameTextBox.Text = string.Empty;
            DniTextBox.Text = string.Empty;
            CompanyNameTextBox.Text = string.Empty;
            FantasyNameTextBox.Text = string.Empty;
            CommercialBusinessTextBox.Text = string.Empty;
            CommercialDniTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            ObservationTextBox.Text = string.Empty;
            AdditionalValueNumericUpDown.Value = 0;
            FineValueNumericUpDown.Value = 0;
        }


        private void PutInfoDataIntoControls(){
            CustomerAssociated = CurrentDetail.Customer;
            PutCustomerDataIntoControls();
            ObservationTextBox.Text = CurrentDetail.ContractObservation;
            AdditionalValueNumericUpDown.Value = decimal.Parse(CurrentDetail.AdditionalValue.ToString("N2"));
            FineValueNumericUpDown.Value = decimal.Parse(CurrentDetail.FineValue.ToString("N2"));
            ObservationTextBox.Focus();
        }


        private void PutCustomerDataIntoControls(){
            try{
                FirstNameTextBox.Text = CustomerAssociated.FirstName;
                LastNameTextBox.Text = CustomerAssociated.LastName;
                DniTextBox.Text = CustomerAssociated.Dni;
                CompanyNameTextBox.Text = CustomerAssociated.ComercialInfo.CompanyName;
                FantasyNameTextBox.Text = CustomerAssociated.ComercialInfo.FantasyName;
                CommercialBusinessTextBox.Text = CustomerAssociated.ComercialInfo.ComercialBusiness;
                CommercialDniTextBox.Text = CustomerAssociated.ComercialInfo.ComercialDni;
                EmailTextBox.Text = CustomerAssociated.ComercialInfo.Email;
                AceptContractButton.Enabled = true;
            }
            catch (Exception){
                var message =
                    $"El {Profile.SingleProfileName} que desea agregar no posee sus datos comerciales ingresados, imposible agregar a contrato.";
                MessageBox.Show(message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AceptContractButton.Enabled = false;
            }
        }

    }

}