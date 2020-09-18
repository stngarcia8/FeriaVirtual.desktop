namespace FeriaVirtual.View.Desktop.Forms.UtilForms {
    partial class ChangePasswordForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.NewPasswordLabel = new System.Windows.Forms.Label();
            this.NewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.renewPasswordLabel = new System.Windows.Forms.Label();
            this.RenewPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.CancelChangeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.change_password;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 50);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // NewPasswordLabel
            // 
            this.NewPasswordLabel.AutoSize = true;
            this.NewPasswordLabel.Location = new System.Drawing.Point(125, 0);
            this.NewPasswordLabel.Name = "NewPasswordLabel";
            this.NewPasswordLabel.Size = new System.Drawing.Size(179, 17);
            this.NewPasswordLabel.TabIndex = 1;
            this.NewPasswordLabel.Text = "Ingrese nueva contraseña:";
            // 
            // NewPasswordTextBox
            // 
            this.NewPasswordTextBox.Location = new System.Drawing.Point(125, 25);
            this.NewPasswordTextBox.MaxLength = 128;
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.Size = new System.Drawing.Size(225, 23);
            this.NewPasswordTextBox.TabIndex = 2;
            this.NewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // renewPasswordLabel
            // 
            this.renewPasswordLabel.AutoSize = true;
            this.renewPasswordLabel.Location = new System.Drawing.Point(125, 50);
            this.renewPasswordLabel.Name = "renewPasswordLabel";
            this.renewPasswordLabel.Size = new System.Drawing.Size(205, 17);
            this.renewPasswordLabel.TabIndex = 3;
            this.renewPasswordLabel.Text = "Rescriba su nueva contraseña:";
            // 
            // RenewPasswordTextBox
            // 
            this.RenewPasswordTextBox.Location = new System.Drawing.Point(125, 75);
            this.RenewPasswordTextBox.MaxLength = 128;
            this.RenewPasswordTextBox.Name = "RenewPasswordTextBox";
            this.RenewPasswordTextBox.Size = new System.Drawing.Size(225, 23);
            this.RenewPasswordTextBox.TabIndex = 4;
            this.RenewPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.AutoSize = true;
            this.ChangePasswordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChangePasswordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangePasswordButton.ImageKey = "button-acept.png";
            this.ChangePasswordButton.ImageList = this.FormImageList;
            this.ChangePasswordButton.Location = new System.Drawing.Point(150, 125);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(90, 27);
            this.ChangePasswordButton.TabIndex = 5;
            this.ChangePasswordButton.Text = "Aceptar";
            this.ChangePasswordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChangePasswordButton.UseVisualStyleBackColor = true;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-acept.png");
            this.FormImageList.Images.SetKeyName(1, "button-cancel.png");
            // 
            // CancelChangeButton
            // 
            this.CancelChangeButton.AutoSize = true;
            this.CancelChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelChangeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelChangeButton.ImageKey = "button-cancel.png";
            this.CancelChangeButton.ImageList = this.FormImageList;
            this.CancelChangeButton.Location = new System.Drawing.Point(250, 125);
            this.CancelChangeButton.Name = "CancelChangeButton";
            this.CancelChangeButton.Size = new System.Drawing.Size(98, 27);
            this.CancelChangeButton.TabIndex = 6;
            this.CancelChangeButton.Text = "Cancelar";
            this.CancelChangeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelChangeButton.UseVisualStyleBackColor = true;
            this.CancelChangeButton.Click += new System.EventHandler(this.CancelChangeButton_Click);
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.ChangePasswordButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelChangeButton;
            this.ClientSize = new System.Drawing.Size(355, 155);
            this.Controls.Add(this.CancelChangeButton);
            this.Controls.Add(this.ChangePasswordButton);
            this.Controls.Add(this.RenewPasswordTextBox);
            this.Controls.Add(this.renewPasswordLabel);
            this.Controls.Add(this.NewPasswordTextBox);
            this.Controls.Add(this.NewPasswordLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de contraseña.";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label NewPasswordLabel;
        private System.Windows.Forms.TextBox NewPasswordTextBox;
        private System.Windows.Forms.Label renewPasswordLabel;
        private System.Windows.Forms.TextBox RenewPasswordTextBox;
        private System.Windows.Forms.Button ChangePasswordButton;
        private System.Windows.Forms.Button CancelChangeButton;
        private System.Windows.Forms.ImageList FormImageList;
    }
}