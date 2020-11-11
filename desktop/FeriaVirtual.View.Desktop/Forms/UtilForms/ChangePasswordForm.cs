using System;
using System.Windows.Forms;
using FeriaVirtual.Business.Validators;


namespace FeriaVirtual.View.Desktop.Forms.UtilForms{

    public partial class ChangePasswordForm : Form{

        // Properties.
        public bool PasswordChanged{ get; set; }

        public string NewPassword{ get; set; }


        public ChangePasswordForm(){
            InitializeComponent();
        }


        private void ChangePasswordForm_Load(object sender, EventArgs e){
            NewPasswordTextBox.Text = string.Empty;
            RenewPasswordTextBox.Text = string.Empty;
            NewPassword = string.Empty;
        }


        private void ChangePasswordButton_Click(object sender, EventArgs e){
            if (!ValidatePasswords()) return;
            PasswordChanged = true;
            NewPassword = NewPasswordTextBox.Text;
            Close();
        }


        private void CancelChangeButton_Click(object sender, EventArgs e){
            PasswordChanged = false;
            NewPassword = string.Empty;
            Close();
        }


        private bool ValidatePasswords(){
            bool result;
            try{
                var validator =
                    ChangePasswordValidator.CreateValidator(NewPasswordTextBox.Text, RenewPasswordTextBox.Text);
                validator.Validate();
                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }

            return result;
        }

    }

}