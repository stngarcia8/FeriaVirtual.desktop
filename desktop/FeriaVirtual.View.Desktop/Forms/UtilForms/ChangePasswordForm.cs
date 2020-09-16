using System;
using System.Windows.Forms;
using FeriaVirtual.Business.Validators;

namespace FeriaVirtual.View.Desktop.Forms.UtilForms {

    public partial class ChangePasswordForm:Form {

        // Properties.
        public bool PasswordChanged { get; set; }
        public string NewPassword { get; set; }


        public ChangePasswordForm() {
            InitializeComponent();
        }


        private void ChangePasswordForm_Load(object sender,EventArgs e) {
            NewPasswordTextBox.Text= string.Empty;
            RenewPasswordTextBox.Text = string.Empty;
            this.NewPassword= string.Empty;
        }

        private void ChangePasswordButton_Click(object sender,EventArgs e) {
            if(ValidatePasswords()) {
                PasswordChanged= true;
                this.NewPassword = this.NewPasswordTextBox.Text;
                Close();
            }
        }

        private void CancelChangeButton_Click(object sender,EventArgs e) {
            PasswordChanged= false;
            this.NewPassword= string.Empty;
            Close();
        }

        private bool ValidatePasswords() {
            bool result = false;
            try {
                ChangePasswordValidator validator = ChangePasswordValidator.CreateValidator( NewPasswordTextBox.Text,RenewPasswordTextBox.Text );
                validator.Validate();
                result= true;
            } catch(Exception ex) {
                MessageBox.Show( ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
                result= false;
            }
            return result;
        }




    }
}
