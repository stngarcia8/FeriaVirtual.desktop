using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.View.Desktop.Forms.UtilForms;

namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Client {

    public partial class CarrierRegisterForm:Form {

        private bool passwordChanged;
        private Domain.Users.Client client;

        // Properties.
        public bool IsNewRecord { get; set; }
        public bool IsSaved { get; set; }
        public string idSelected { get; set; }
        public string ProfileName { get; set; }
        public string SingleProfileName { get; set; }
        public int ProfileID { get; set; }



        public CarrierRegisterForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void CarrierRegisterForm_Load(object sender,EventArgs e) {
            Text= (IsNewRecord ? string.Format("Nuevo {0}.",SingleProfileName) : string.Format("Editando {0}.",SingleProfileName));
            EnableUserButton.Visible= !IsNewRecord;
            ChangePasswordButton.Enabled= !IsNewRecord;
            UsernameTextBox.ReadOnly= !IsNewRecord;
            PasswordTextBox.ReadOnly=!IsNewRecord;
            if(IsNewRecord) {
                CleanControls();
                UsernameTextBox.Focus();
            } else {
                LoadUserInfo();
                PutClientInfoIntoControls();
                ChangeTextStatusClient();
            }
        }

        private void ChangePasswordButton_Click(object sender,EventArgs e) {
            ChangePasswordForm form = new ChangePasswordForm {
                PasswordChanged= false
            };
            form.ShowDialog();
            if(form.PasswordChanged) {
                client.Credentials.Password = form.NewPassword;
                client.Credentials.EncriptedPassword = client.Credentials.EncryptPassword();
                PasswordTextBox.Text= form.NewPassword;
            }
            passwordChanged= form.PasswordChanged;
        }


        private void EnableUserButton_Click(object sender,EventArgs e) {
            EnableOrDisableClient();
        }

        private void SaveButton_Click(object sender,EventArgs e) {
            if(IsNewRecord) {
                if(!SaveClientData(true,false)) {
                    return;
                }
            } else {
                if(!SaveClientData(false,passwordChanged)) {
                    return;
                }
            }
            IsSaved= true;
            Close();
        }

        private void BackButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }


        private void EnableOrDisableClient() {
            StringBuilder message = new StringBuilder();
            message.Append(string.Format("¿Esta seguro de {0} el {1} {2}?",(client.Credentials.IsActive ? "inhabilitar" : "habilitar"),SingleProfileName,client.ToString()));
            DialogResult result = MessageBox.Show(message.ToString(),"Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result==DialogResult.No) {
                return;
            }

            bool oldStatus = client.Credentials.IsActive;
            try {
                ClientUseCase usecase = ClientUseCase.CreateUseCase(ProfileID,SingleProfileName);
                usecase.EnableDisableClient(client.Credentials.UserId,client.Credentials.IsActive);
                message.Clear();
                message.Append(string.Format("El {0} {1} fue {2} correctamente, los usuarios administradores pueden volver a rebocar esta acción.",SingleProfileName,client.ToString(),(client.Credentials.IsActive ? "inhabilitado" : "habilitado")));
                MessageBox.Show(message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                IsSaved= true;
                Close();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                client.Credentials.IsActive= oldStatus;
            }
            ChangeTextStatusClient();
        }

        private void ChangeTextStatusClient() {
            EnableUserButton.Text = (client.Credentials.IsActive ? "Inhabilitar" : "Habilitar");
        }


        private void CleanControls() {
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            FirstnameTextBox.Text = string.Empty;
            LastnameTextBox.Text = string.Empty;
            DNITextBox.Text= string.Empty;
            EmailTextBox.Text = string.Empty;
            client= Domain.Users.Client.CreateClient();
            client.Credentials.IsActive=true;
        }


        private bool SaveClientData(bool isNew,bool isEncripted) {
            bool result = false;
            string message = string.Empty;
            PutUserDataIntoObject();
            try {
                ClientUseCase usecase = ClientUseCase.CreateUseCase(ProfileID,SingleProfileName);
                if(IsNewRecord) {
                    usecase.NewClient(client);
                    message = string.Format("El {0} {1} ha sido almacenado correctamente.",SingleProfileName,client.ToString());
                    MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } else {
                    usecase.EditEmployee(client,true,passwordChanged);
                    message= string.Format("El {0} {1} ha sido actualizado correctamente.",SingleProfileName,client.ToString());
                    MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                result= true;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }


        private void PutUserDataIntoObject() {
            client.FirstName= FirstnameTextBox.Text;
            client.LastName= LastnameTextBox.Text;
            client.DNI= DNITextBox.Text;
            client.Profile.ProfileID= ProfileID;
            client.Profile.ProfileName= SingleProfileName;
            client.Credentials.Username= UsernameTextBox.Text;
            client.Credentials.Password= PasswordTextBox.Text;
            client.Credentials.Email= EmailTextBox.Text;
        }


        private void LoadUserInfo() {
            try {
                ClientUseCase usecase = ClientUseCase.CreateUseCase(ProfileID,SingleProfileName);
                GetClientData(usecase.FindClientById(idSelected));
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                Close();
            }
        }

        private void GetClientData(DataTable clientInfo) {
            DataRow row = clientInfo.Rows[0];
            client = Domain.Users.Client.CreateClient(row["id_cliente"].ToString(),
                row["nombre_cliente"].ToString(),row["apellido_cliente"].ToString(),row["DNI"].ToString());
            client.Credentials.UserId = row["id_usuario"].ToString();
            client.Credentials.Username= row["username"].ToString();
            client.Credentials.Password = row["password"].ToString();
            client.Credentials.EncriptedPassword= row["password"].ToString();
            client.Credentials.Email= row["Email"].ToString();
            client.Credentials.IsActive= (int.Parse(row["is_active"].ToString()).Equals(1) ? true : false);
            client.Profile.ProfileID= int.Parse(row["id_rol"].ToString());
            client.Profile.ProfileName= row["Rol"].ToString();
        }


        private void PutClientInfoIntoControls() {
            UsernameTextBox.Text = client.Credentials.Username;
            PasswordTextBox.Text = client.Credentials.Password;
            FirstnameTextBox.Text = client.FirstName;
            LastnameTextBox.Text = client.LastName;
            DNITextBox.Text = client.DNI;
            EmailTextBox.Text = client.Credentials.Email;
            passwordChanged= false;
        }




    }
}
