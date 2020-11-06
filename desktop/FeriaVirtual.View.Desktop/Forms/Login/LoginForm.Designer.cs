namespace FeriaVirtual.View.Desktop.Login {
    partial class LoginForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.LoginButton = new System.Windows.Forms.Button();
            this.CancelLoginButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(125, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(136, 17);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "Nombre de usuario:";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameTextBox.Location = new System.Drawing.Point(125, 25);
            this.UsernameTextBox.MaxLength = 150;
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(200, 23);
            this.UsernameTextBox.TabIndex = 2;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(125, 50);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(88, 17);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Contraseña:";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Location = new System.Drawing.Point(125, 75);
            this.PasswordTextBox.MaxLength = 128;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(200, 23);
            this.PasswordTextBox.TabIndex = 4;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-acept.png");
            this.FormImageList.Images.SetKeyName(1, "button-cancel.png");
            // 
            // LoginButton
            // 
            this.LoginButton.AutoSize = true;
            this.LoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoginButton.ImageKey = "button-acept.png";
            this.LoginButton.ImageList = this.FormImageList;
            this.LoginButton.Location = new System.Drawing.Point(125, 125);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(90, 27);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Aceptar";
            this.LoginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CancelLoginButton
            // 
            this.CancelLoginButton.AutoSize = true;
            this.CancelLoginButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelLoginButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelLoginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelLoginButton.ImageKey = "button-cancel.png";
            this.CancelLoginButton.ImageList = this.FormImageList;
            this.CancelLoginButton.Location = new System.Drawing.Point(225, 125);
            this.CancelLoginButton.Name = "CancelLoginButton";
            this.CancelLoginButton.Size = new System.Drawing.Size(98, 27);
            this.CancelLoginButton.TabIndex = 6;
            this.CancelLoginButton.Text = "Cancelar";
            this.CancelLoginButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelLoginButton.UseVisualStyleBackColor = true;
            this.CancelLoginButton.Click += new System.EventHandler(this.CancelLoginButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.login1;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.CancelLoginButton;
            this.ClientSize = new System.Drawing.Size(346, 163);
            this.Controls.Add(this.CancelLoginButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(362, 202);
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feria Virtual - Iniciar sesión.";
            this.Load += new System.EventHandler(this.LoginForm_Load);
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
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button CancelLoginButton;
        private System.Windows.Forms.ImageList FormImageList;
    }
}