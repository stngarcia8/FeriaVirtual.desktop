namespace FeriaVirtual.View.Desktop.Forms.Maintenance.User {
    partial class UserRegisterForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRegisterForm));
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.FirstnameLabel = new System.Windows.Forms.Label();
            this.FirstnameTextBox = new System.Windows.Forms.TextBox();
            this.LastnameLabel = new System.Windows.Forms.Label();
            this.LastnameTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.UserTypeLabel = new System.Windows.Forms.Label();
            this.AdministratorRadioButton = new System.Windows.Forms.RadioButton();
            this.ConsultorRadioButton = new System.Windows.Forms.RadioButton();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.SaveButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.EnableUserButton = new System.Windows.Forms.Button();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(125, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(79, 17);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username :";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(225, 0);
            this.UsernameTextBox.MaxLength = 150;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(275, 23);
            this.UsernameTextBox.TabIndex = 4;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(125, 25);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(77, 17);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password :";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(225, 25);
            this.PasswordTextBox.MaxLength = 128;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(175, 23);
            this.PasswordTextBox.TabIndex = 6;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // FirstnameLabel
            // 
            this.FirstnameLabel.AutoSize = true;
            this.FirstnameLabel.Location = new System.Drawing.Point(125, 75);
            this.FirstnameLabel.Name = "FirstnameLabel";
            this.FirstnameLabel.Size = new System.Drawing.Size(69, 17);
            this.FirstnameLabel.TabIndex = 8;
            this.FirstnameLabel.Text = "Nombre :";
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.Location = new System.Drawing.Point(225, 75);
            this.FirstnameTextBox.MaxLength = 30;
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.Size = new System.Drawing.Size(275, 23);
            this.FirstnameTextBox.TabIndex = 10;
            // 
            // LastnameLabel
            // 
            this.LastnameLabel.AutoSize = true;
            this.LastnameLabel.Location = new System.Drawing.Point(125, 100);
            this.LastnameLabel.Name = "LastnameLabel";
            this.LastnameLabel.Size = new System.Drawing.Size(69, 17);
            this.LastnameLabel.TabIndex = 11;
            this.LastnameLabel.Text = "Apellido :";
            // 
            // LastnameTextBox
            // 
            this.LastnameTextBox.Location = new System.Drawing.Point(225, 100);
            this.LastnameTextBox.MaxLength = 150;
            this.LastnameTextBox.Name = "LastnameTextBox";
            this.LastnameTextBox.Size = new System.Drawing.Size(275, 23);
            this.LastnameTextBox.TabIndex = 12;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(125, 125);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(51, 17);
            this.EmailLabel.TabIndex = 13;
            this.EmailLabel.Text = "Email :";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(225, 125);
            this.EmailTextBox.MaxLength = 254;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(275, 23);
            this.EmailTextBox.TabIndex = 14;
            // 
            // UserTypeLabel
            // 
            this.UserTypeLabel.AutoSize = true;
            this.UserTypeLabel.Location = new System.Drawing.Point(125, 150);
            this.UserTypeLabel.Name = "UserTypeLabel";
            this.UserTypeLabel.Size = new System.Drawing.Size(92, 17);
            this.UserTypeLabel.TabIndex = 15;
            this.UserTypeLabel.Text = "Tipo usuario :";
            // 
            // AdministratorRadioButton
            // 
            this.AdministratorRadioButton.AutoSize = true;
            this.AdministratorRadioButton.Location = new System.Drawing.Point(225, 150);
            this.AdministratorRadioButton.Name = "AdministratorRadioButton";
            this.AdministratorRadioButton.Size = new System.Drawing.Size(116, 21);
            this.AdministratorRadioButton.TabIndex = 16;
            this.AdministratorRadioButton.TabStop = true;
            this.AdministratorRadioButton.Text = "Administrador";
            this.AdministratorRadioButton.UseVisualStyleBackColor = true;
            // 
            // ConsultorRadioButton
            // 
            this.ConsultorRadioButton.AutoSize = true;
            this.ConsultorRadioButton.Location = new System.Drawing.Point(375, 150);
            this.ConsultorRadioButton.Name = "ConsultorRadioButton";
            this.ConsultorRadioButton.Size = new System.Drawing.Size(88, 21);
            this.ConsultorRadioButton.TabIndex = 17;
            this.ConsultorRadioButton.TabStop = true;
            this.ConsultorRadioButton.Text = "Consultor";
            this.ConsultorRadioButton.UseVisualStyleBackColor = true;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-save.png");
            this.FormImageList.Images.SetKeyName(1, "button-cancel.png");
            this.FormImageList.Images.SetKeyName(2, "button-disable.png");
            this.FormImageList.Images.SetKeyName(3, "button-changepassword.png");
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.ImageKey = "button-save.png";
            this.SaveButton.ImageList = this.FormImageList;
            this.SaveButton.Location = new System.Drawing.Point(300, 200);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 27);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "&Grabar";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.AutoSize = true;
            this.BackButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.ImageKey = "button-cancel.png";
            this.BackButton.ImageList = this.FormImageList;
            this.BackButton.Location = new System.Drawing.Point(400, 200);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(98, 27);
            this.BackButton.TabIndex = 20;
            this.BackButton.Text = "&Cancelar";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // EnableUserButton
            // 
            this.EnableUserButton.AutoSize = true;
            this.EnableUserButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EnableUserButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnableUserButton.ImageKey = "button-disable.png";
            this.EnableUserButton.ImageList = this.FormImageList;
            this.EnableUserButton.Location = new System.Drawing.Point(0, 200);
            this.EnableUserButton.Name = "EnableUserButton";
            this.EnableUserButton.Size = new System.Drawing.Size(142, 27);
            this.EnableUserButton.TabIndex = 18;
            this.EnableUserButton.Text = "Habilitar usuario";
            this.EnableUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EnableUserButton.UseVisualStyleBackColor = true;
            this.EnableUserButton.Click += new System.EventHandler(this.EnableUserButton_Click);
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.AutoSize = true;
            this.ChangePasswordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangePasswordButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordButton.ImageKey = "button-changepassword.png";
            this.ChangePasswordButton.ImageList = this.FormImageList;
            this.ChangePasswordButton.Location = new System.Drawing.Point(400, 25);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(86, 26);
            this.ChangePasswordButton.TabIndex = 7;
            this.ChangePasswordButton.Text = "Cambiar";
            this.ChangePasswordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.employees;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(125, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 1;
            this.FormPictureBox.TabStop = false;
            // 
            // UserRegisterForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BackButton;
            this.ClientSize = new System.Drawing.Size(507, 238);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EnableUserButton);
            this.Controls.Add(this.ConsultorRadioButton);
            this.Controls.Add(this.AdministratorRadioButton);
            this.Controls.Add(this.UserTypeLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.LastnameTextBox);
            this.Controls.Add(this.LastnameLabel);
            this.Controls.Add(this.FirstnameTextBox);
            this.Controls.Add(this.FirstnameLabel);
            this.Controls.Add(this.ChangePasswordButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserRegisterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserRegisterForm";
            this.Load += new System.EventHandler(this.UserRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Label FirstnameLabel;
        private System.Windows.Forms.TextBox FirstnameTextBox;
        private System.Windows.Forms.Label LastnameLabel;
        private System.Windows.Forms.TextBox LastnameTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label UserTypeLabel;
        private System.Windows.Forms.RadioButton AdministratorRadioButton;
        private System.Windows.Forms.RadioButton ConsultorRadioButton;
        private System.Windows.Forms.Button EnableUserButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ImageList FormImageList;
    }
}