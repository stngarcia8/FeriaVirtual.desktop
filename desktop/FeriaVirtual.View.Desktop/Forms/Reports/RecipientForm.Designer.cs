namespace FeriaVirtual.View.Desktop.Forms.Reports {
    partial class RecipientForm {
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipientForm));
            this.ReportTitleLabel = new System.Windows.Forms.Label();
            this.ReportNameLabel = new System.Windows.Forms.Label();
            this.ReportNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FilenameTextBox = new System.Windows.Forms.TextBox();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.RecipientTitleLabel = new System.Windows.Forms.Label();
            this.RecipientNameLabel = new System.Windows.Forms.Label();
            this.RecipientNameTextBox = new System.Windows.Forms.TextBox();
            this.RecipientEmailLabel = new System.Windows.Forms.Label();
            this.RecipientEmailTextBox = new System.Windows.Forms.TextBox();
            this.ListRecipientTitleLabel = new System.Windows.Forms.Label();
            this.RecipientDataGridView = new System.Windows.Forms.DataGridView();
            this.CancelMailButton = new System.Windows.Forms.Button();
            this.SendReportButton = new System.Windows.Forms.Button();
            this.RemoveRecipientButton = new System.Windows.Forms.Button();
            this.AddRecipientButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RecipientDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportTitleLabel
            // 
            this.ReportTitleLabel.AutoSize = true;
            this.ReportTitleLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportTitleLabel.Location = new System.Drawing.Point(125, 0);
            this.ReportTitleLabel.Name = "ReportTitleLabel";
            this.ReportTitleLabel.Size = new System.Drawing.Size(120, 16);
            this.ReportTitleLabel.TabIndex = 1;
            this.ReportTitleLabel.Text = "Datos del reporte";
            // 
            // ReportNameLabel
            // 
            this.ReportNameLabel.AutoSize = true;
            this.ReportNameLabel.Location = new System.Drawing.Point(125, 25);
            this.ReportNameLabel.Name = "ReportNameLabel";
            this.ReportNameLabel.Size = new System.Drawing.Size(63, 17);
            this.ReportNameLabel.TabIndex = 2;
            this.ReportNameLabel.Text = "Reporte:";
            // 
            // ReportNameTextBox
            // 
            this.ReportNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReportNameTextBox.Location = new System.Drawing.Point(200, 25);
            this.ReportNameTextBox.Name = "ReportNameTextBox";
            this.ReportNameTextBox.ReadOnly = true;
            this.ReportNameTextBox.Size = new System.Drawing.Size(300, 16);
            this.ReportNameTextBox.TabIndex = 3;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(125, 50);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(61, 17);
            this.FileNameLabel.TabIndex = 4;
            this.FileNameLabel.Text = "Archivo:";
            // 
            // FilenameTextBox
            // 
            this.FilenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilenameTextBox.Location = new System.Drawing.Point(200, 50);
            this.FilenameTextBox.Name = "FilenameTextBox";
            this.FilenameTextBox.ReadOnly = true;
            this.FilenameTextBox.Size = new System.Drawing.Size(300, 16);
            this.FilenameTextBox.TabIndex = 5;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-previewPdf.jpg");
            this.FormImageList.Images.SetKeyName(1, "Button-Add.png");
            this.FormImageList.Images.SetKeyName(2, "button-sendMail.jpg");
            this.FormImageList.Images.SetKeyName(3, "button-cancel.png");
            this.FormImageList.Images.SetKeyName(4, "button-remove.png");
            // 
            // RecipientTitleLabel
            // 
            this.RecipientTitleLabel.AutoSize = true;
            this.RecipientTitleLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipientTitleLabel.Location = new System.Drawing.Point(125, 100);
            this.RecipientTitleLabel.Name = "RecipientTitleLabel";
            this.RecipientTitleLabel.Size = new System.Drawing.Size(193, 16);
            this.RecipientTitleLabel.TabIndex = 7;
            this.RecipientTitleLabel.Text = "Información del destinatario";
            // 
            // RecipientNameLabel
            // 
            this.RecipientNameLabel.AutoSize = true;
            this.RecipientNameLabel.Location = new System.Drawing.Point(125, 125);
            this.RecipientNameLabel.Name = "RecipientNameLabel";
            this.RecipientNameLabel.Size = new System.Drawing.Size(65, 17);
            this.RecipientNameLabel.TabIndex = 8;
            this.RecipientNameLabel.Text = "Nombre:";
            // 
            // RecipientNameTextBox
            // 
            this.RecipientNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecipientNameTextBox.Location = new System.Drawing.Point(200, 125);
            this.RecipientNameTextBox.MaxLength = 50;
            this.RecipientNameTextBox.Name = "RecipientNameTextBox";
            this.RecipientNameTextBox.Size = new System.Drawing.Size(300, 23);
            this.RecipientNameTextBox.TabIndex = 9;
            // 
            // RecipientEmailLabel
            // 
            this.RecipientEmailLabel.AutoSize = true;
            this.RecipientEmailLabel.Location = new System.Drawing.Point(125, 150);
            this.RecipientEmailLabel.Name = "RecipientEmailLabel";
            this.RecipientEmailLabel.Size = new System.Drawing.Size(47, 17);
            this.RecipientEmailLabel.TabIndex = 10;
            this.RecipientEmailLabel.Text = "Email:";
            // 
            // RecipientEmailTextBox
            // 
            this.RecipientEmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecipientEmailTextBox.Location = new System.Drawing.Point(200, 150);
            this.RecipientEmailTextBox.MaxLength = 255;
            this.RecipientEmailTextBox.Name = "RecipientEmailTextBox";
            this.RecipientEmailTextBox.Size = new System.Drawing.Size(300, 23);
            this.RecipientEmailTextBox.TabIndex = 11;
            // 
            // ListRecipientTitleLabel
            // 
            this.ListRecipientTitleLabel.AutoSize = true;
            this.ListRecipientTitleLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListRecipientTitleLabel.Location = new System.Drawing.Point(125, 225);
            this.ListRecipientTitleLabel.Name = "ListRecipientTitleLabel";
            this.ListRecipientTitleLabel.Size = new System.Drawing.Size(146, 16);
            this.ListRecipientTitleLabel.TabIndex = 13;
            this.ListRecipientTitleLabel.Text = "Lista de destinatarios";
            // 
            // RecipientDataGridView
            // 
            this.RecipientDataGridView.AllowUserToAddRows = false;
            this.RecipientDataGridView.AllowUserToDeleteRows = false;
            this.RecipientDataGridView.AllowUserToResizeColumns = false;
            this.RecipientDataGridView.AllowUserToResizeRows = false;
            this.RecipientDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RecipientDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.RecipientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecipientDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.RecipientDataGridView.Location = new System.Drawing.Point(125, 250);
            this.RecipientDataGridView.MultiSelect = false;
            this.RecipientDataGridView.Name = "RecipientDataGridView";
            this.RecipientDataGridView.ReadOnly = true;
            this.RecipientDataGridView.RowHeadersVisible = false;
            this.RecipientDataGridView.RowTemplate.Height = 23;
            this.RecipientDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecipientDataGridView.ShowCellErrors = false;
            this.RecipientDataGridView.ShowCellToolTips = false;
            this.RecipientDataGridView.ShowEditingIcon = false;
            this.RecipientDataGridView.ShowRowErrors = false;
            this.RecipientDataGridView.Size = new System.Drawing.Size(375, 150);
            this.RecipientDataGridView.StandardTab = true;
            this.RecipientDataGridView.TabIndex = 14;
            // 
            // CancelMailButton
            // 
            this.CancelMailButton.AutoSize = true;
            this.CancelMailButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelMailButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelMailButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelMailButton.ImageKey = "button-cancel.png";
            this.CancelMailButton.ImageList = this.FormImageList;
            this.CancelMailButton.Location = new System.Drawing.Point(425, 425);
            this.CancelMailButton.Name = "CancelMailButton";
            this.CancelMailButton.Size = new System.Drawing.Size(94, 27);
            this.CancelMailButton.TabIndex = 17;
            this.CancelMailButton.Text = "Cancelar";
            this.CancelMailButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelMailButton.UseVisualStyleBackColor = true;
            this.CancelMailButton.Click += new System.EventHandler(this.CancelMailButton_Click);
            // 
            // SendReportButton
            // 
            this.SendReportButton.AutoSize = true;
            this.SendReportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SendReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SendReportButton.ImageKey = "button-sendMail.jpg";
            this.SendReportButton.ImageList = this.FormImageList;
            this.SendReportButton.Location = new System.Drawing.Point(275, 425);
            this.SendReportButton.Name = "SendReportButton";
            this.SendReportButton.Size = new System.Drawing.Size(124, 27);
            this.SendReportButton.TabIndex = 16;
            this.SendReportButton.Text = "Enviar reporte";
            this.SendReportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SendReportButton.UseVisualStyleBackColor = true;
            this.SendReportButton.Click += new System.EventHandler(this.SendReportButton_Click);
            // 
            // RemoveRecipientButton
            // 
            this.RemoveRecipientButton.AccessibleDescription = "quitar destinatario";
            this.RemoveRecipientButton.AccessibleName = "quitar destinatario";
            this.RemoveRecipientButton.AutoSize = true;
            this.RemoveRecipientButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveRecipientButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveRecipientButton.ImageKey = "button-remove.png";
            this.RemoveRecipientButton.ImageList = this.FormImageList;
            this.RemoveRecipientButton.Location = new System.Drawing.Point(125, 425);
            this.RemoveRecipientButton.Name = "RemoveRecipientButton";
            this.RemoveRecipientButton.Size = new System.Drawing.Size(155, 27);
            this.RemoveRecipientButton.TabIndex = 15;
            this.RemoveRecipientButton.Text = "Quitar destinatario";
            this.RemoveRecipientButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RemoveRecipientButton.UseVisualStyleBackColor = true;
            this.RemoveRecipientButton.Click += new System.EventHandler(this.RemoveRecipientButton_Click);
            // 
            // AddRecipientButton
            // 
            this.AddRecipientButton.AutoSize = true;
            this.AddRecipientButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddRecipientButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddRecipientButton.ImageKey = "Button-Add.png";
            this.AddRecipientButton.ImageList = this.FormImageList;
            this.AddRecipientButton.Location = new System.Drawing.Point(200, 175);
            this.AddRecipientButton.Name = "AddRecipientButton";
            this.AddRecipientButton.Size = new System.Drawing.Size(225, 27);
            this.AddRecipientButton.TabIndex = 12;
            this.AddRecipientButton.Text = "Agregar destinatario a la lista";
            this.AddRecipientButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddRecipientButton.UseVisualStyleBackColor = true;
            this.AddRecipientButton.Click += new System.EventHandler(this.AddRecipientButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.form_sendReport;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // RecipientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.CancelMailButton;
            this.ClientSize = new System.Drawing.Size(516, 461);
            this.Controls.Add(this.CancelMailButton);
            this.Controls.Add(this.SendReportButton);
            this.Controls.Add(this.RemoveRecipientButton);
            this.Controls.Add(this.RecipientDataGridView);
            this.Controls.Add(this.ListRecipientTitleLabel);
            this.Controls.Add(this.AddRecipientButton);
            this.Controls.Add(this.RecipientEmailTextBox);
            this.Controls.Add(this.RecipientEmailLabel);
            this.Controls.Add(this.RecipientNameTextBox);
            this.Controls.Add(this.RecipientNameLabel);
            this.Controls.Add(this.RecipientTitleLabel);
            this.Controls.Add(this.FilenameTextBox);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.ReportNameTextBox);
            this.Controls.Add(this.ReportNameLabel);
            this.Controls.Add(this.ReportTitleLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecipientForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar reporte por email";
            this.Load += new System.EventHandler(this.RecipientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RecipientDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label ReportTitleLabel;
        private System.Windows.Forms.Label ReportNameLabel;
        private System.Windows.Forms.TextBox ReportNameTextBox;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FilenameTextBox;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Label RecipientTitleLabel;
        private System.Windows.Forms.Label RecipientNameLabel;
        private System.Windows.Forms.TextBox RecipientNameTextBox;
        private System.Windows.Forms.Label RecipientEmailLabel;
        private System.Windows.Forms.TextBox RecipientEmailTextBox;
        private System.Windows.Forms.Button AddRecipientButton;
        private System.Windows.Forms.Label ListRecipientTitleLabel;
        private System.Windows.Forms.DataGridView RecipientDataGridView;
        private System.Windows.Forms.Button RemoveRecipientButton;
        private System.Windows.Forms.Button SendReportButton;
        private System.Windows.Forms.Button CancelMailButton;
    }
}