using System;
using System.Text;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.View.Desktop.Forms.UtilForms;


namespace FeriaVirtual.View.Desktop.Forms.User{

    public partial class UserRegisterForm : Form{

        private Employee employee;
        private bool passwordChanged;

        // Properties.
        public bool IsNewRecord{ get; set; }

        public bool IsSaved{ get; set; }
        public string IdSelected{ get; set; }


        public UserRegisterForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void UserRegisterForm_Load(object sender, EventArgs e){
            Text = IsNewRecord ? "Nuevo usuario." : "Editando usuario.";
            EnableUserButton.Visible = !IsNewRecord;
            ChangePasswordButton.Enabled = !IsNewRecord;
            UsernameTextBox.ReadOnly = !IsNewRecord;
            PasswordTextBox.ReadOnly = !IsNewRecord;
            if (IsNewRecord){
                CleanControls();
                UsernameTextBox.Focus();
            }
            else{
                LoadUserInfo();
                PutUserInfoIntoControls();
                ChangeTextStatusUser();
            }
        }


        private void ChangePasswordButton_Click(object sender, EventArgs e){
            var form = new ChangePasswordForm{
                PasswordChanged = false
            };
            form.ShowDialog();
            if (form.PasswordChanged){
                employee.Credentials.Password = form.NewPassword;
                employee.Credentials.EncriptedPassword = employee.Credentials.EncryptPassword();
                PasswordTextBox.Text = form.NewPassword;
            }

            passwordChanged = form.PasswordChanged;
        }


        private void EnableUserButton_Click(object sender, EventArgs e){
            EnableOrDisableEmployee();
        }


        private void SaveButton_Click(object sender, EventArgs e){
            if (!SaveUserData()) return;
            IsSaved = true;
            Close();
        }


        private void BackButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void EnableOrDisableEmployee(){
            var message = new StringBuilder();
            message.Append(
                $"¿Esta seguro de {(employee.Credentials.IsActive ? "inhabilitar" : "habilitar")} el usuario {employee}?");
            var result = MessageBox.Show(message.ToString(), "Atención", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            var oldStatus = employee.Credentials.IsActive;
            try{
                var usecase = EmployeeUseCase.CreateUseCase();
                usecase.EnableDisableUser(employee.Credentials.UserId, employee.Credentials.IsActive);
                message.Clear();
                message.Append(
                    $"El usuario {employee} fue {(employee.Credentials.IsActive ? "inhabilitado" : "habilitado")} correctamente, los usuarios administradores pueden volver a rebocar esta acción.");
                MessageBox.Show(message.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                employee.Credentials.IsActive = oldStatus;
            }

            ChangeTextStatusUser();
        }


        private void ChangeTextStatusUser(){
            if (employee != null) EnableUserButton.Text = employee.Credentials.IsActive ? "Inhabilitar" : "Habilitar";
        }


        private void CleanControls(){
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            FirstnameTextBox.Text = string.Empty;
            LastnameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            AdministratorRadioButton.Checked = false;
            ConsultorRadioButton.Checked = true;
            employee = Employee.CreateEmployee();
            employee.Credentials.IsActive = true;
        }


        private bool SaveUserData(){
            bool result;
            PutUserDataIntoObject();
            try{
                var usecase = EmployeeUseCase.CreateUseCase();
                if (IsNewRecord){
                    usecase.NewEmployee(employee);
                    MessageBox.Show("El usuario " + employee + " ha sido almacenado correctamente.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else{
                    usecase.EditEmployee(employee, true, passwordChanged);
                    MessageBox.Show("El usuario " + employee + " ha sido actualizado correctamente.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }

            return result;
        }


        private void PutUserDataIntoObject(){
            employee.FirstName = FirstnameTextBox.Text;
            employee.LastName = LastnameTextBox.Text;
            if (AdministratorRadioButton.Checked) employee.Profile.ProfileId = 1;
            if (ConsultorRadioButton.Checked) employee.Profile.ProfileId = 2;
            employee.Credentials.Username = UsernameTextBox.Text;
            employee.Credentials.Password = PasswordTextBox.Text;
            employee.Credentials.Email = EmailTextBox.Text;
        }


        private void LoadUserInfo(){
            try{
                var useCase = EmployeeUseCase.CreateUseCase();
                employee = useCase.FindUserById(IdSelected);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }


        private void PutUserInfoIntoControls(){
            if (employee == null) return;
            UsernameTextBox.Text = employee.Credentials.Username;
            PasswordTextBox.Text = employee.Credentials.Password;
            FirstnameTextBox.Text = employee.FirstName;
            LastnameTextBox.Text = employee.LastName;
            EmailTextBox.Text = employee.Credentials.Email;
            switch (employee.Profile.ProfileId){
                case 1:
                    AdministratorRadioButton.Checked = true;
                    break;
                case 2:
                    ConsultorRadioButton.Checked = true;
                    break;
            }

            passwordChanged = false;
        }

    }

}