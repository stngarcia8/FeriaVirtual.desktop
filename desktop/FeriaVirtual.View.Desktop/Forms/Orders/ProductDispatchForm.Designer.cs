namespace FeriaVirtual.View.Desktop.Forms.Orders {
    partial class ProductDispatchForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDispatchForm));
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.CarrierTitleLabel = new System.Windows.Forms.Label();
            this.CarrierLabel = new System.Windows.Forms.Label();
            this.CarrierTextBox = new System.Windows.Forms.TextBox();
            this.CarrierValueLabel = new System.Windows.Forms.Label();
            this.CarrierValueTextBox = new System.Windows.Forms.TextBox();
            this.CustomerTitleLabel = new System.Windows.Forms.Label();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.CustomerTextBox = new System.Windows.Forms.TextBox();
            this.CustomerCompanyLabel = new System.Windows.Forms.Label();
            this.CustomerCompanyTextBox = new System.Windows.Forms.TextBox();
            this.CustomerAddressLabel = new System.Windows.Forms.Label();
            this.CustomerAddressTextBox = new System.Windows.Forms.TextBox();
            this.CustomerPhoneLabel = new System.Windows.Forms.Label();
            this.CustomerPhoneTextBox = new System.Windows.Forms.TextBox();
            this.ProductTitleLabel = new System.Windows.Forms.Label();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.DispatchTitleLabel = new System.Windows.Forms.Label();
            this.DispatchPreparationDateLabel = new System.Windows.Forms.Label();
            this.DispatchPreparationDateTextBox = new System.Windows.Forms.TextBox();
            this.DispatchOkDateLabel = new System.Windows.Forms.Label();
            this.DispatchOkDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DispatchObservationLabel = new System.Windows.Forms.Label();
            this.DispatchObservationTextBox = new System.Windows.Forms.TextBox();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.RemoveCarrierButton = new System.Windows.Forms.Button();
            this.NotifyButton = new System.Windows.Forms.Button();
            this.NotifyCloseButton = new System.Windows.Forms.Button();
            this.SafeLabel = new System.Windows.Forms.Label();
            this.SafeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.form_notify;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 75);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // CarrierTitleLabel
            // 
            this.CarrierTitleLabel.AutoSize = true;
            this.CarrierTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarrierTitleLabel.Location = new System.Drawing.Point(125, 0);
            this.CarrierTitleLabel.Name = "CarrierTitleLabel";
            this.CarrierTitleLabel.Size = new System.Drawing.Size(231, 19);
            this.CarrierTitleLabel.TabIndex = 1;
            this.CarrierTitleLabel.Text = "Información del transportista.";
            // 
            // CarrierLabel
            // 
            this.CarrierLabel.AutoSize = true;
            this.CarrierLabel.Location = new System.Drawing.Point(125, 25);
            this.CarrierLabel.Name = "CarrierLabel";
            this.CarrierLabel.Size = new System.Drawing.Size(92, 17);
            this.CarrierLabel.TabIndex = 2;
            this.CarrierLabel.Text = "Transportista:";
            // 
            // CarrierTextBox
            // 
            this.CarrierTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarrierTextBox.Location = new System.Drawing.Point(250, 25);
            this.CarrierTextBox.Name = "CarrierTextBox";
            this.CarrierTextBox.ReadOnly = true;
            this.CarrierTextBox.Size = new System.Drawing.Size(250, 16);
            this.CarrierTextBox.TabIndex = 3;
            // 
            // CarrierValueLabel
            // 
            this.CarrierValueLabel.AutoSize = true;
            this.CarrierValueLabel.Location = new System.Drawing.Point(125, 50);
            this.CarrierValueLabel.Name = "CarrierValueLabel";
            this.CarrierValueLabel.Size = new System.Drawing.Size(116, 17);
            this.CarrierValueLabel.TabIndex = 4;
            this.CarrierValueLabel.Text = "Valor transporte:";
            // 
            // CarrierValueTextBox
            // 
            this.CarrierValueTextBox.BackColor = System.Drawing.Color.Yellow;
            this.CarrierValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CarrierValueTextBox.Location = new System.Drawing.Point(250, 50);
            this.CarrierValueTextBox.Name = "CarrierValueTextBox";
            this.CarrierValueTextBox.ReadOnly = true;
            this.CarrierValueTextBox.Size = new System.Drawing.Size(150, 16);
            this.CarrierValueTextBox.TabIndex = 5;
            this.CarrierValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CustomerTitleLabel
            // 
            this.CustomerTitleLabel.AutoSize = true;
            this.CustomerTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerTitleLabel.Location = new System.Drawing.Point(125, 100);
            this.CustomerTitleLabel.Name = "CustomerTitleLabel";
            this.CustomerTitleLabel.Size = new System.Drawing.Size(192, 19);
            this.CustomerTitleLabel.TabIndex = 6;
            this.CustomerTitleLabel.Text = "Información del cliente.";
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(125, 125);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(58, 17);
            this.CustomerLabel.TabIndex = 7;
            this.CustomerLabel.Text = "Cliente:";
            // 
            // CustomerTextBox
            // 
            this.CustomerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerTextBox.Location = new System.Drawing.Point(225, 125);
            this.CustomerTextBox.Name = "CustomerTextBox";
            this.CustomerTextBox.ReadOnly = true;
            this.CustomerTextBox.Size = new System.Drawing.Size(275, 16);
            this.CustomerTextBox.TabIndex = 8;
            // 
            // CustomerCompanyLabel
            // 
            this.CustomerCompanyLabel.AutoSize = true;
            this.CustomerCompanyLabel.Location = new System.Drawing.Point(125, 150);
            this.CustomerCompanyLabel.Name = "CustomerCompanyLabel";
            this.CustomerCompanyLabel.Size = new System.Drawing.Size(67, 17);
            this.CustomerCompanyLabel.TabIndex = 9;
            this.CustomerCompanyLabel.Text = "Empresa:";
            // 
            // CustomerCompanyTextBox
            // 
            this.CustomerCompanyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerCompanyTextBox.Location = new System.Drawing.Point(225, 150);
            this.CustomerCompanyTextBox.Name = "CustomerCompanyTextBox";
            this.CustomerCompanyTextBox.ReadOnly = true;
            this.CustomerCompanyTextBox.Size = new System.Drawing.Size(275, 16);
            this.CustomerCompanyTextBox.TabIndex = 10;
            // 
            // CustomerAddressLabel
            // 
            this.CustomerAddressLabel.AutoSize = true;
            this.CustomerAddressLabel.Location = new System.Drawing.Point(125, 175);
            this.CustomerAddressLabel.Name = "CustomerAddressLabel";
            this.CustomerAddressLabel.Size = new System.Drawing.Size(73, 17);
            this.CustomerAddressLabel.TabIndex = 11;
            this.CustomerAddressLabel.Text = "Dirección:";
            // 
            // CustomerAddressTextBox
            // 
            this.CustomerAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerAddressTextBox.Location = new System.Drawing.Point(225, 175);
            this.CustomerAddressTextBox.Name = "CustomerAddressTextBox";
            this.CustomerAddressTextBox.ReadOnly = true;
            this.CustomerAddressTextBox.Size = new System.Drawing.Size(275, 16);
            this.CustomerAddressTextBox.TabIndex = 12;
            // 
            // CustomerPhoneLabel
            // 
            this.CustomerPhoneLabel.AutoSize = true;
            this.CustomerPhoneLabel.Location = new System.Drawing.Point(125, 200);
            this.CustomerPhoneLabel.Name = "CustomerPhoneLabel";
            this.CustomerPhoneLabel.Size = new System.Drawing.Size(66, 17);
            this.CustomerPhoneLabel.TabIndex = 13;
            this.CustomerPhoneLabel.Text = "Teléfono:";
            // 
            // CustomerPhoneTextBox
            // 
            this.CustomerPhoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerPhoneTextBox.Location = new System.Drawing.Point(225, 200);
            this.CustomerPhoneTextBox.Name = "CustomerPhoneTextBox";
            this.CustomerPhoneTextBox.ReadOnly = true;
            this.CustomerPhoneTextBox.Size = new System.Drawing.Size(150, 16);
            this.CustomerPhoneTextBox.TabIndex = 14;
            // 
            // ProductTitleLabel
            // 
            this.ProductTitleLabel.AutoSize = true;
            this.ProductTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTitleLabel.Location = new System.Drawing.Point(525, 0);
            this.ProductTitleLabel.Name = "ProductTitleLabel";
            this.ProductTitleLabel.Size = new System.Drawing.Size(189, 19);
            this.ProductTitleLabel.TabIndex = 15;
            this.ProductTitleLabel.Text = "Productos a transportar.";
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.AllowUserToAddRows = false;
            this.ProductsDataGridView.AllowUserToDeleteRows = false;
            this.ProductsDataGridView.AllowUserToResizeColumns = false;
            this.ProductsDataGridView.AllowUserToResizeRows = false;
            this.ProductsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ProductsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ProductsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.GridColor = System.Drawing.Color.White;
            this.ProductsDataGridView.Location = new System.Drawing.Point(525, 25);
            this.ProductsDataGridView.MultiSelect = false;
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.ReadOnly = true;
            this.ProductsDataGridView.RowHeadersVisible = false;
            this.ProductsDataGridView.RowTemplate.Height = 23;
            this.ProductsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductsDataGridView.ShowCellErrors = false;
            this.ProductsDataGridView.ShowCellToolTips = false;
            this.ProductsDataGridView.ShowEditingIcon = false;
            this.ProductsDataGridView.ShowRowErrors = false;
            this.ProductsDataGridView.Size = new System.Drawing.Size(350, 200);
            this.ProductsDataGridView.StandardTab = true;
            this.ProductsDataGridView.TabIndex = 16;
            // 
            // DispatchTitleLabel
            // 
            this.DispatchTitleLabel.AutoSize = true;
            this.DispatchTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DispatchTitleLabel.Location = new System.Drawing.Point(125, 250);
            this.DispatchTitleLabel.Name = "DispatchTitleLabel";
            this.DispatchTitleLabel.Size = new System.Drawing.Size(215, 19);
            this.DispatchTitleLabel.TabIndex = 17;
            this.DispatchTitleLabel.Text = "Información de despacho.";
            // 
            // DispatchPreparationDateLabel
            // 
            this.DispatchPreparationDateLabel.AutoSize = true;
            this.DispatchPreparationDateLabel.Location = new System.Drawing.Point(125, 275);
            this.DispatchPreparationDateLabel.Name = "DispatchPreparationDateLabel";
            this.DispatchPreparationDateLabel.Size = new System.Drawing.Size(156, 17);
            this.DispatchPreparationDateLabel.TabIndex = 18;
            this.DispatchPreparationDateLabel.Text = "Fecha de preparación:";
            // 
            // DispatchPreparationDateTextBox
            // 
            this.DispatchPreparationDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DispatchPreparationDateTextBox.Location = new System.Drawing.Point(275, 275);
            this.DispatchPreparationDateTextBox.Name = "DispatchPreparationDateTextBox";
            this.DispatchPreparationDateTextBox.ReadOnly = true;
            this.DispatchPreparationDateTextBox.Size = new System.Drawing.Size(150, 23);
            this.DispatchPreparationDateTextBox.TabIndex = 19;
            // 
            // DispatchOkDateLabel
            // 
            this.DispatchOkDateLabel.AutoSize = true;
            this.DispatchOkDateLabel.Location = new System.Drawing.Point(125, 300);
            this.DispatchOkDateLabel.Name = "DispatchOkDateLabel";
            this.DispatchOkDateLabel.Size = new System.Drawing.Size(109, 17);
            this.DispatchOkDateLabel.TabIndex = 20;
            this.DispatchOkDateLabel.Text = "Fecha de retiro:";
            // 
            // DispatchOkDateTimePicker
            // 
            this.DispatchOkDateTimePicker.Checked = false;
            this.DispatchOkDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DispatchOkDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DispatchOkDateTimePicker.Location = new System.Drawing.Point(275, 300);
            this.DispatchOkDateTimePicker.Name = "DispatchOkDateTimePicker";
            this.DispatchOkDateTimePicker.Size = new System.Drawing.Size(150, 23);
            this.DispatchOkDateTimePicker.TabIndex = 21;
            // 
            // DispatchObservationLabel
            // 
            this.DispatchObservationLabel.AutoSize = true;
            this.DispatchObservationLabel.Location = new System.Drawing.Point(475, 275);
            this.DispatchObservationLabel.Name = "DispatchObservationLabel";
            this.DispatchObservationLabel.Size = new System.Drawing.Size(94, 17);
            this.DispatchObservationLabel.TabIndex = 24;
            this.DispatchObservationLabel.Text = "Observación:";
            // 
            // DispatchObservationTextBox
            // 
            this.DispatchObservationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.DispatchObservationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DispatchObservationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DispatchObservationTextBox.Location = new System.Drawing.Point(600, 275);
            this.DispatchObservationTextBox.MaxLength = 100;
            this.DispatchObservationTextBox.Multiline = true;
            this.DispatchObservationTextBox.Name = "DispatchObservationTextBox";
            this.DispatchObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DispatchObservationTextBox.Size = new System.Drawing.Size(275, 75);
            this.DispatchObservationTextBox.TabIndex = 25;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-remove.png");
            this.FormImageList.Images.SetKeyName(1, "button-notify.jpg");
            this.FormImageList.Images.SetKeyName(2, "button-cancel.png");
            // 
            // RemoveCarrierButton
            // 
            this.RemoveCarrierButton.AutoSize = true;
            this.RemoveCarrierButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveCarrierButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RemoveCarrierButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveCarrierButton.ImageKey = "button-remove.png";
            this.RemoveCarrierButton.ImageList = this.FormImageList;
            this.RemoveCarrierButton.Location = new System.Drawing.Point(100, 375);
            this.RemoveCarrierButton.Name = "RemoveCarrierButton";
            this.RemoveCarrierButton.Size = new System.Drawing.Size(244, 27);
            this.RemoveCarrierButton.TabIndex = 26;
            this.RemoveCarrierButton.Text = "Remover oferta de transportista";
            this.RemoveCarrierButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RemoveCarrierButton.UseVisualStyleBackColor = true;
            this.RemoveCarrierButton.Click += new System.EventHandler(this.RemoveCarrierButton_Click);
            // 
            // NotifyButton
            // 
            this.NotifyButton.AutoSize = true;
            this.NotifyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NotifyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NotifyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NotifyButton.ImageKey = "button-notify.jpg";
            this.NotifyButton.ImageList = this.FormImageList;
            this.NotifyButton.Location = new System.Drawing.Point(500, 375);
            this.NotifyButton.Name = "NotifyButton";
            this.NotifyButton.Size = new System.Drawing.Size(259, 27);
            this.NotifyButton.TabIndex = 27;
            this.NotifyButton.Text = "Notificar despacho a transportista";
            this.NotifyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NotifyButton.UseVisualStyleBackColor = true;
            this.NotifyButton.Click += new System.EventHandler(this.NotifyButton_Click);
            // 
            // NotifyCloseButton
            // 
            this.NotifyCloseButton.AutoSize = true;
            this.NotifyCloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NotifyCloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NotifyCloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NotifyCloseButton.ImageKey = "button-cancel.png";
            this.NotifyCloseButton.ImageList = this.FormImageList;
            this.NotifyCloseButton.Location = new System.Drawing.Point(800, 375);
            this.NotifyCloseButton.Name = "NotifyCloseButton";
            this.NotifyCloseButton.Size = new System.Drawing.Size(78, 27);
            this.NotifyCloseButton.TabIndex = 28;
            this.NotifyCloseButton.Text = "Cerrar";
            this.NotifyCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NotifyCloseButton.UseVisualStyleBackColor = true;
            this.NotifyCloseButton.Click += new System.EventHandler(this.NotifyCloseButton_Click);
            // 
            // SafeLabel
            // 
            this.SafeLabel.AutoSize = true;
            this.SafeLabel.Location = new System.Drawing.Point(125, 325);
            this.SafeLabel.Name = "SafeLabel";
            this.SafeLabel.Size = new System.Drawing.Size(121, 17);
            this.SafeLabel.TabIndex = 22;
            this.SafeLabel.Text = "Seguro asociado:";
            // 
            // SafeComboBox
            // 
            this.SafeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SafeComboBox.DropDownWidth = 4;
            this.SafeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SafeComboBox.FormattingEnabled = true;
            this.SafeComboBox.Location = new System.Drawing.Point(275, 325);
            this.SafeComboBox.Name = "SafeComboBox";
            this.SafeComboBox.Size = new System.Drawing.Size(300, 25);
            this.SafeComboBox.TabIndex = 23;
            // 
            // ProductDispatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.NotifyCloseButton;
            this.ClientSize = new System.Drawing.Size(892, 415);
            this.Controls.Add(this.SafeComboBox);
            this.Controls.Add(this.SafeLabel);
            this.Controls.Add(this.NotifyCloseButton);
            this.Controls.Add(this.NotifyButton);
            this.Controls.Add(this.RemoveCarrierButton);
            this.Controls.Add(this.DispatchObservationTextBox);
            this.Controls.Add(this.DispatchObservationLabel);
            this.Controls.Add(this.DispatchOkDateTimePicker);
            this.Controls.Add(this.DispatchOkDateLabel);
            this.Controls.Add(this.DispatchPreparationDateTextBox);
            this.Controls.Add(this.DispatchPreparationDateLabel);
            this.Controls.Add(this.DispatchTitleLabel);
            this.Controls.Add(this.ProductsDataGridView);
            this.Controls.Add(this.ProductTitleLabel);
            this.Controls.Add(this.CustomerPhoneTextBox);
            this.Controls.Add(this.CustomerPhoneLabel);
            this.Controls.Add(this.CustomerAddressTextBox);
            this.Controls.Add(this.CustomerAddressLabel);
            this.Controls.Add(this.CustomerCompanyTextBox);
            this.Controls.Add(this.CustomerCompanyLabel);
            this.Controls.Add(this.CustomerTextBox);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.CustomerTitleLabel);
            this.Controls.Add(this.CarrierValueTextBox);
            this.Controls.Add(this.CarrierValueLabel);
            this.Controls.Add(this.CarrierTextBox);
            this.Controls.Add(this.CarrierLabel);
            this.Controls.Add(this.CarrierTitleLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductDispatchForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Notificación de despacho de productos para transportistas.";
            this.Load += new System.EventHandler(this.ProductDispatchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label CarrierTitleLabel;
        private System.Windows.Forms.Label CarrierLabel;
        private System.Windows.Forms.TextBox CarrierTextBox;
        private System.Windows.Forms.Label CarrierValueLabel;
        private System.Windows.Forms.TextBox CarrierValueTextBox;
        private System.Windows.Forms.Label CustomerTitleLabel;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.TextBox CustomerTextBox;
        private System.Windows.Forms.Label CustomerCompanyLabel;
        private System.Windows.Forms.TextBox CustomerCompanyTextBox;
        private System.Windows.Forms.Label CustomerAddressLabel;
        private System.Windows.Forms.TextBox CustomerAddressTextBox;
        private System.Windows.Forms.Label CustomerPhoneLabel;
        private System.Windows.Forms.TextBox CustomerPhoneTextBox;
        private System.Windows.Forms.Label ProductTitleLabel;
        private System.Windows.Forms.DataGridView ProductsDataGridView;
        private System.Windows.Forms.Label DispatchTitleLabel;
        private System.Windows.Forms.Label DispatchPreparationDateLabel;
        private System.Windows.Forms.TextBox DispatchPreparationDateTextBox;
        private System.Windows.Forms.Label DispatchOkDateLabel;
        private System.Windows.Forms.DateTimePicker DispatchOkDateTimePicker;
        private System.Windows.Forms.Label DispatchObservationLabel;
        private System.Windows.Forms.TextBox DispatchObservationTextBox;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Button RemoveCarrierButton;
        private System.Windows.Forms.Button NotifyButton;
        private System.Windows.Forms.Button NotifyCloseButton;
        private System.Windows.Forms.Label SafeLabel;
        private System.Windows.Forms.ComboBox SafeComboBox;
    }
}