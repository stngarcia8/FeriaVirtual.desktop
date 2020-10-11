using System;
using System.Text;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.View.Desktop.Forms.UtilForms;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.User {

    public partial class UserRegisterForm:Form {
        private bool passwordChanged;
        private Employee employee;

        // Properties.
        public bool IsNewRecord { get; set; }

        public bool IsSaved { get; set; }
        public string IdSelected { get; set; }

        public UserRegisterForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void UserRegisterForm_Load(object sender,EventArgs e) {
            Text= (IsNewRecord ? "Nuevo usuario." : "Editando usuario.");
            EnableUserButton.Visible= !IsNewRecord;
            ChangePasswordButton.Enabled= !IsNewRecord;
            UsernameTextBox.ReadOnly= !IsNewRecord;
            PasswordTextBox.ReadOnly= !IsNewRecord;
            if(IsNewRecord) {
                CleanControls();
                UsernameTextBox.Focus();
            } else {
                LoadUserInfo();
                PutUserInfoIntoControls();
                ChangeTextStatusUser();
            }
        }

        private void ChangePasswordButton_Click(object sender,EventArgs e) {
            ChangePasswordForm form = new ChangePasswordForm {
                PasswordChanged= false
            };
            form.ShowDialog();
            if(form.PasswordChanged) {
                employee.Credentials.Password = form.NewPassword;
                employee.Credentials.EncriptedPassword = employee.Credentials.EncryptPassword();
                PasswordTextBox.Text= form.NewPassword;
            }
            passwordChanged= form.PasswordChanged;
        }

        private void EnableUserButton_Click(object sender,EventArgs e) {
            EnableOrDisableEmployee();
        }

        private void SaveButton_Click(object sender,EventArgs e) {
if(!SaveUserData()) {
                    return;
                }
            IsSaved= true;
            Close();
        }

        private void BackButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }

        private void EnableOrDisableEmployee() {
            StringBuilder message = new StringBuilder();
            message.Append(string.Format("¿Esta seguro de {0} el usuario {1}?",(employee.Credentials.IsActive ? "inhabilitar" : "habilitar"),employee.ToString()));
            DialogResult result = MessageBox.Show(message.ToString(),"Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result==DialogResult.No) {
                return;
            }
            bool oldStatus = employee.Credentials.IsActive;
            try {
                EmployeeUseCase usecase = EmployeeUseCase.CreateUseCase();
                usecase.EnableDisableUser(employee.Credentials.UserId,employee.Credentials.IsActive);
                message.Clear();
                message.Append(string.Format("El usuario {0} fue {1} correctamente, los usuarios administradores pueden volver a rebocar esta acción.",employee.ToString(),(employee.Credentials.IsActive ? "inhabilitado" : "habilitado")));
                MessageBox.Show(message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                IsSaved= true;
                Close();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                employee.Credentials.IsActive= oldStatus;
            }
            ChangeTextStatusUser();
        }

        private void ChangeTextStatusUser() {
            if(employee != null) {
                EnableUserButton.Text = (employee.Credentials.IsActive ? "Inhabilitar" : "Habilitar");
            }
        }

        private void CleanControls() {
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            FirstnameTextBox.Text = string.Empty;
            LastnameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            AdministratorRadioButton.Checked= false;
            ConsultorRadioButton.Checked= true;
            employee= Employee.CreateEmployee();
            employee.Credentials.IsActive= true;
        }

        private bool SaveUserData() {
            bool result = false;
            PutUserDataIntoObject();
            try {
                EmployeeUseCase usecase = EmployeeUseCase.CreateUseCase();
                if(IsNewRecord) {
                    usecase.NewEmployee(employee);
                    MessageBox.Show("El usuario " + employee.ToString() + " ha sido almacenado correctamente.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } else {
                    usecase.EditEmployee(employee,true,passwordChanged);
                    MessageBox.Show("El usuario " + employee.ToString() + " ha sido actualizado correctamente.","Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                result= true;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }

        private void PutUserDataIntoObject() {
            employee.FirstName= FirstnameTextBox.Text;
            employee.LastName= LastnameTextBox.Text;
            if(AdministratorRadioButton.Checked) {
                employee.Profile.ProfileID=1;
            }
            if(ConsultorRadioButton.Checked) {
                employee.Profile.ProfileID=2;
            }
            employee.Credentials.Username= UsernameTextBox.Text;
            employee.Credentials.Password= PasswordTextBox.Text;
            employee.Credentials.Email= EmailTextBox.Text;
        }

        private void LoadUserInfo() {
            try {
                EmployeeUseCase useCase = EmployeeUseCase.CreateUseCase();
                employee =  useCase.FindUserById(IdSelected);
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void PutUserInfoIntoControls() {
            if(employee== null) {
                return;
            }
            UsernameTextBox.Text = employee.Credentials.Username;
            PasswordTextBox.Text = employee.Credentials.Password;
            FirstnameTextBox.Text = employee.FirstName;
            LastnameTextBox.Text = employee.LastName;
            EmailTextBox.Text = employee.Credentials.Email;
            if(employee.Profile.ProfileID.Equals(1)) {
                AdministratorRadioButton.Checked=true;
            }
            if(employee.Profile.ProfileID.Equals(2)) {
                ConsultorRadioButton.Checked=true;
            }
            passwordChanged= false;
        }
    }
}