using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Data.Enums;
using FeriaVirtual.View.Desktop.Forms.UtilForms;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Client{

    public partial class CarrierRegisterForm : Form{

        private Domain.Users.Client client;
        private bool passwordChanged;

        // Properties.
        public bool IsNewRecord{ get; set; }
        public bool IsSaved{ get; set; }
        public string IdSelected{ get; set; }
        public IProfileInfo Profile{ get; set; }


        public CarrierRegisterForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void CarrierRegisterForm_Load(object sender, EventArgs e){
            Text = IsNewRecord
                ? $"Nuevo {Profile.SingleProfileName}."
                : $"Editando {Profile.SingleProfileName}.";
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
                PutClientInfoIntoControls();
                ChangeTextStatusClient();
            }
        }


        private void ChangePasswordButton_Click(object sender, EventArgs e){
            var form = new ChangePasswordForm{
                PasswordChanged = false
            };
            form.ShowDialog();
            if (form.PasswordChanged){
                client.Credentials.Password = form.NewPassword;
                client.Credentials.EncriptedPassword = client.Credentials.EncryptPassword();
                PasswordTextBox.Text = form.NewPassword;
            }

            passwordChanged = form.PasswordChanged;
        }


        private void EnableUserButton_Click(object sender, EventArgs e){
            EnableOrDisableClient();
        }


        private void SaveButton_Click(object sender, EventArgs e){
            if (!SaveClientData()) return;
            IsSaved = true;
            Close();
        }


        private void BackButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void EnableOrDisableClient(){
            var message = new StringBuilder();
            message.Append(
                $"¿Esta seguro de {(client.Credentials.IsActive ? "inhabilitar" : "habilitar")} el {Profile.SingleProfileName} {client}?");
            var result = MessageBox.Show(message.ToString(), "Atención", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            var oldStatus = client.Credentials.IsActive;
            try{
                var usecase = ClientUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                usecase.EnableDisableClient(client.Credentials.UserId, client.Credentials.IsActive);
                message.Clear();
                message.Append(
                    $"El {Profile.SingleProfileName} {client} fue {(client.Credentials.IsActive ? "inhabilitado" : "habilitado")} correctamente, los usuarios administradores pueden volver a rebocar esta acción.");
                MessageBox.Show(message.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                Close();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                client.Credentials.IsActive = oldStatus;
            }

            ChangeTextStatusClient();
        }


        private void ChangeTextStatusClient(){
            EnableUserButton.Text = client.Credentials.IsActive ? "Inhabilitar" : "Habilitar";
        }


        private void CleanControls(){
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            FirstnameTextBox.Text = string.Empty;
            LastnameTextBox.Text = string.Empty;
            DNITextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            client = Domain.Users.Client.CreateClient();
            client.Credentials.IsActive = true;
        }


        private bool SaveClientData(){
            bool result;
            PutUserDataIntoObject();
            //try{
                string message;
                var usecase = ClientUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                if (IsNewRecord){
                    usecase.NewClient(client);
                    message = $"El {Profile.SingleProfileName} {client} ha sido almacenado correctamente.";
                    MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else{
                    usecase.EditEmployee(client, true, passwordChanged);
                    message = $"El {Profile.SingleProfileName} {client} ha sido actualizado correctamente.";
                    MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                result = true;
            //}
            //catch (Exception ex){
                //MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //result = false;
            //}

            return result;
        }


        private void PutUserDataIntoObject(){
            client.FirstName = FirstnameTextBox.Text;
            client.LastName = LastnameTextBox.Text;
            client.Dni = DNITextBox.Text;
            client.Profile.ProfileId = Profile.ProfileId;
            client.Profile.ProfileName = Profile.SingleProfileName;
            client.Credentials.Username = UsernameTextBox.Text;
            client.Credentials.Password = PasswordTextBox.Text;
            client.Credentials.Email = EmailTextBox.Text;
        }


        private void LoadUserInfo(){
            try{
                var usecase = ClientUseCase.CreateUseCase(Profile.ProfileId, Profile.SingleProfileName);
                GetClientData(usecase.FindClientById(IdSelected));
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }


        private void GetClientData(DataTable clientInfo){
            var row = clientInfo.Rows[0];
            client = Domain.Users.Client.CreateClient(row["id_cliente"].ToString(),
                row["nombre_cliente"].ToString(), row["apellido_cliente"].ToString(), row["DNI"].ToString());
            client.Credentials.UserId = row["id_usuario"].ToString();
            client.Credentials.Username = row["username"].ToString();
            client.Credentials.Password = row["password"].ToString();
            client.Credentials.EncriptedPassword = row["password"].ToString();
            client.Credentials.Email = row["Email"].ToString();
            client.Credentials.IsActive = int.Parse(row["is_active"].ToString()) == (int) UserStatus.Active;
            client.Profile.ProfileId = int.Parse(row["id_rol"].ToString());
            client.Profile.ProfileName = row["Rol"].ToString();
        }


        private void PutClientInfoIntoControls(){
            UsernameTextBox.Text = client.Credentials.Username;
            PasswordTextBox.Text = client.Credentials.Password;
            FirstnameTextBox.Text = client.FirstName;
            LastnameTextBox.Text = client.LastName;
            DNITextBox.Text = client.Dni;
            EmailTextBox.Text = client.Credentials.Email;
            passwordChanged = false;
        }

    }

}