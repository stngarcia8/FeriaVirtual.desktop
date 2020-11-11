using System;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.View.Desktop.Commands;
using FeriaVirtual.View.Desktop.Forms.Administrator;
using FeriaVirtual.View.Desktop.Forms.Consultor;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Login{

    public partial class LoginForm : Form{

        public LoginForm(){
            InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e){
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
        }


        private void LoginButton_Click(object sender, EventArgs e){
            StartSession();
        }


        private void CancelLoginButton_Click(object sender, EventArgs e){
            Close();
        }


        private void StartSession(){
            try{
                var user = Credential.CreateCredential();
                user.Username = UsernameTextBox.Text;
                user.Password = PasswordTextBox.Text;
                user.EncriptedPassword = user.EncryptPassword();
                var login = LoginUseCase.CreateLogin(user.Username, user.EncriptedPassword);
                login.StartSession();
                ActualUser.ActualEmployee = login.EmployeeLogged;
                OpenForm();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PasswordTextBox.Text = string.Empty;
                UsernameTextBox.Focus();
            }
        }


        // Open form method.
        private void OpenForm(){
            Form form = null;
            switch (ActualUser.ActualEmployee.Profile.ProfileId){
                case 1:
                    form = new AdministratorMainForm();
                    break;
                case 2:
                    form = new ConsultorMainForm();
                    break;
            }

            Hide();
            ICommand openFormCommand = OpenFormCommand.Open(form);
            openFormCommand.Execute();
        }

    }

}