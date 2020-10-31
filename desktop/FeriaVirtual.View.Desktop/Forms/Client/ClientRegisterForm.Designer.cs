namespace FeriaVirtual.View.Desktop.Forms.Client {
    partial class CarrierRegisterForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarrierRegisterForm));
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastnameTextBox = new System.Windows.Forms.TextBox();
            this.LastnameLabel = new System.Windows.Forms.Label();
            this.FirstnameTextBox = new System.Windows.Forms.TextBox();
            this.FirstnameLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DNITextBox = new System.Windows.Forms.TextBox();
            this.DNILabel = new System.Windows.Forms.Label();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EnableUserButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-save.png");
            this.FormImageList.Images.SetKeyName(1, "button-cancel.png");
            this.FormImageList.Images.SetKeyName(2, "button-disable.png");
            this.FormImageList.Images.SetKeyName(3, "button-changepassword.png");
            this.FormImageList.Images.SetKeyName(4, "Button-Add.png");
            this.FormImageList.Images.SetKeyName(5, "button-remove.png");
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(250, 150);
            this.EmailTextBox.MaxLength = 254;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(275, 23);
            this.EmailTextBox.TabIndex = 13;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(165, 150);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(51, 17);
            this.EmailLabel.TabIndex = 12;
            this.EmailLabel.Text = "Email :";
            // 
            // LastnameTextBox
            // 
            this.LastnameTextBox.Location = new System.Drawing.Point(250, 100);
            this.LastnameTextBox.MaxLength = 50;
            this.LastnameTextBox.Name = "LastnameTextBox";
            this.LastnameTextBox.Size = new System.Drawing.Size(275, 23);
            this.LastnameTextBox.TabIndex = 9;
            // 
            // LastnameLabel
            // 
            this.LastnameLabel.AutoSize = true;
            this.LastnameLabel.Location = new System.Drawing.Point(165, 100);
            this.LastnameLabel.Name = "LastnameLabel";
            this.LastnameLabel.Size = new System.Drawing.Size(69, 17);
            this.LastnameLabel.TabIndex = 8;
            this.LastnameLabel.Text = "Apellido :";
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.Location = new System.Drawing.Point(250, 75);
            this.FirstnameTextBox.MaxLength = 30;
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.Size = new System.Drawing.Size(275, 23);
            this.FirstnameTextBox.TabIndex = 7;
            // 
            // FirstnameLabel
            // 
            this.FirstnameLabel.AutoSize = true;
            this.FirstnameLabel.Location = new System.Drawing.Point(165, 75);
            this.FirstnameLabel.Name = "FirstnameLabel";
            this.FirstnameLabel.Size = new System.Drawing.Size(69, 17);
            this.FirstnameLabel.TabIndex = 6;
            this.FirstnameLabel.Text = "Nombre :";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(250, 25);
            this.PasswordTextBox.MaxLength = 128;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(175, 23);
            this.PasswordTextBox.TabIndex = 4;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(165, 25);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(77, 17);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password :";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(250, 0);
            this.UsernameTextBox.MaxLength = 150;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(275, 23);
            this.UsernameTextBox.TabIndex = 2;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(165, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(79, 17);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Username :";
            // 
            // DNITextBox
            // 
            this.DNITextBox.Location = new System.Drawing.Point(250, 125);
            this.DNITextBox.MaxLength = 20;
            this.DNITextBox.Name = "DNITextBox";
            this.DNITextBox.Size = new System.Drawing.Size(175, 23);
            this.DNITextBox.TabIndex = 11;
            // 
            // DNILabel
            // 
            this.DNILabel.AutoSize = true;
            this.DNILabel.Location = new System.Drawing.Point(175, 125);
            this.DNILabel.Name = "DNILabel";
            this.DNILabel.Size = new System.Drawing.Size(62, 17);
            this.DNILabel.TabIndex = 10;
            this.DNILabel.Text = "DNI/Rut:";
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.AutoSize = true;
            this.ChangePasswordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangePasswordButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePasswordButton.ImageKey = "button-changepassword.png";
            this.ChangePasswordButton.ImageList = this.FormImageList;
            this.ChangePasswordButton.Location = new System.Drawing.Point(450, 25);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(86, 26);
            this.ChangePasswordButton.TabIndex = 5;
            this.ChangePasswordButton.Text = "Cambiar";
            this.ChangePasswordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.AutoSize = true;
            this.BackButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackButton.ImageKey = "button-cancel.png";
            this.BackButton.ImageList = this.FormImageList;
            this.BackButton.Location = new System.Drawing.Point(450, 200);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(98, 27);
            this.BackButton.TabIndex = 16;
            this.BackButton.Text = "&Cancelar";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.ImageKey = "button-save.png";
            this.SaveButton.ImageList = this.FormImageList;
            this.SaveButton.Location = new System.Drawing.Point(350, 200);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 27);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "&Grabar";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.EnableUserButton.TabIndex = 14;
            this.EnableUserButton.Text = "Habilitar usuario";
            this.EnableUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EnableUserButton.UseVisualStyleBackColor = true;
            this.EnableUserButton.Click += new System.EventHandler(this.EnableUserButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.customer_register;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(125, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 21;
            this.FormPictureBox.TabStop = false;
            // 
            // CarrierRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(555, 232);
            this.Controls.Add(this.ChangePasswordButton);
            this.Controls.Add(this.DNILabel);
            this.Controls.Add(this.DNITextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.LastnameTextBox);
            this.Controls.Add(this.LastnameLabel);
            this.Controls.Add(this.FirstnameTextBox);
            this.Controls.Add(this.FirstnameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EnableUserButton);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(571, 271);
            this.Name = "CarrierRegisterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Registros de clientes.";
            this.Load += new System.EventHandler(this.CarrierRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EnableUserButton;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox LastnameTextBox;
        private System.Windows.Forms.Label LastnameLabel;
        private System.Windows.Forms.TextBox FirstnameTextBox;
        private System.Windows.Forms.Label FirstnameLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox DNITextBox;
        private System.Windows.Forms.Label DNILabel;
        private System.Windows.Forms.Button ChangePasswordButton;
    }
}