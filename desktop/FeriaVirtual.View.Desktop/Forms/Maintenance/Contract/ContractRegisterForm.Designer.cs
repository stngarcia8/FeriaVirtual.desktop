namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Contract {
    partial class ContractRegisterForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractRegisterForm));
            this.FormTabControl = new System.Windows.Forms.TabControl();
            this.ContractTabPage = new System.Windows.Forms.TabPage();
            this.ContractValidCheckBox = new System.Windows.Forms.CheckBox();
            this.ContractTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ContractTypeLabel = new System.Windows.Forms.Label();
            this.CommissionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CommissionLabel = new System.Windows.Forms.Label();
            this.DescriptionContractTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionContractLabel = new System.Windows.Forms.Label();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.ClientTabPage = new System.Windows.Forms.TabPage();
            this.ListClientDataGridView = new System.Windows.Forms.DataGridView();
            this.ClientListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ListRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ListAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ListRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientLabel = new System.Windows.Forms.Label();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.ContractCancelButton = new System.Windows.Forms.Button();
            this.ContractSaveButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.DeleteContractButton = new System.Windows.Forms.Button();
            this.FormTabControl.SuspendLayout();
            this.ContractTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommissionNumericUpDown)).BeginInit();
            this.ClientTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListClientDataGridView)).BeginInit();
            this.ClientListContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormTabControl
            // 
            this.FormTabControl.Controls.Add(this.ContractTabPage);
            this.FormTabControl.Controls.Add(this.ClientTabPage);
            this.FormTabControl.ImageList = this.FormImageList;
            this.FormTabControl.Location = new System.Drawing.Point(100, 0);
            this.FormTabControl.Name = "FormTabControl";
            this.FormTabControl.SelectedIndex = 0;
            this.FormTabControl.Size = new System.Drawing.Size(425, 300);
            this.FormTabControl.TabIndex = 1;
            // 
            // ContractTabPage
            // 
            this.ContractTabPage.BackColor = System.Drawing.Color.LightGray;
            this.ContractTabPage.Controls.Add(this.ContractValidCheckBox);
            this.ContractTabPage.Controls.Add(this.ContractTypeComboBox);
            this.ContractTabPage.Controls.Add(this.ContractTypeLabel);
            this.ContractTabPage.Controls.Add(this.CommissionNumericUpDown);
            this.ContractTabPage.Controls.Add(this.CommissionLabel);
            this.ContractTabPage.Controls.Add(this.DescriptionContractTextBox);
            this.ContractTabPage.Controls.Add(this.DescriptionContractLabel);
            this.ContractTabPage.Controls.Add(this.EndDateTimePicker);
            this.ContractTabPage.Controls.Add(this.EndDateLabel);
            this.ContractTabPage.Controls.Add(this.StartDateTimePicker);
            this.ContractTabPage.Controls.Add(this.StartDateLabel);
            this.ContractTabPage.ImageKey = "contract.png";
            this.ContractTabPage.Location = new System.Drawing.Point(4, 27);
            this.ContractTabPage.Name = "ContractTabPage";
            this.ContractTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ContractTabPage.Size = new System.Drawing.Size(417, 269);
            this.ContractTabPage.TabIndex = 0;
            this.ContractTabPage.Text = "Información del contrato";
            // 
            // ContractValidCheckBox
            // 
            this.ContractValidCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContractValidCheckBox.Location = new System.Drawing.Point(175, 225);
            this.ContractValidCheckBox.Name = "ContractValidCheckBox";
            this.ContractValidCheckBox.Size = new System.Drawing.Size(225, 20);
            this.ContractValidCheckBox.TabIndex = 10;
            this.ContractValidCheckBox.Text = "Contrato vigente";
            this.ContractValidCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ContractValidCheckBox.UseVisualStyleBackColor = true;
            // 
            // ContractTypeComboBox
            // 
            this.ContractTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContractTypeComboBox.FormattingEnabled = true;
            this.ContractTypeComboBox.Location = new System.Drawing.Point(175, 200);
            this.ContractTypeComboBox.MaxDropDownItems = 4;
            this.ContractTypeComboBox.Name = "ContractTypeComboBox";
            this.ContractTypeComboBox.Size = new System.Drawing.Size(225, 25);
            this.ContractTypeComboBox.TabIndex = 9;
            // 
            // ContractTypeLabel
            // 
            this.ContractTypeLabel.AutoSize = true;
            this.ContractTypeLabel.Location = new System.Drawing.Point(25, 200);
            this.ContractTypeLabel.Name = "ContractTypeLabel";
            this.ContractTypeLabel.Size = new System.Drawing.Size(99, 17);
            this.ContractTypeLabel.TabIndex = 8;
            this.ContractTypeLabel.Text = "Tipo contrato:";
            // 
            // CommissionNumericUpDown
            // 
            this.CommissionNumericUpDown.BackColor = System.Drawing.Color.Yellow;
            this.CommissionNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommissionNumericUpDown.DecimalPlaces = 2;
            this.CommissionNumericUpDown.Location = new System.Drawing.Point(175, 175);
            this.CommissionNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            131072});
            this.CommissionNumericUpDown.Name = "CommissionNumericUpDown";
            this.CommissionNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.CommissionNumericUpDown.TabIndex = 7;
            this.CommissionNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CommissionLabel
            // 
            this.CommissionLabel.AutoSize = true;
            this.CommissionLabel.Location = new System.Drawing.Point(25, 175);
            this.CommissionLabel.Name = "CommissionLabel";
            this.CommissionLabel.Size = new System.Drawing.Size(114, 17);
            this.CommissionLabel.TabIndex = 6;
            this.CommissionLabel.Text = "Comisión inicial:";
            // 
            // DescriptionContractTextBox
            // 
            this.DescriptionContractTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionContractTextBox.Location = new System.Drawing.Point(175, 100);
            this.DescriptionContractTextBox.MaxLength = 100;
            this.DescriptionContractTextBox.Multiline = true;
            this.DescriptionContractTextBox.Name = "DescriptionContractTextBox";
            this.DescriptionContractTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionContractTextBox.Size = new System.Drawing.Size(225, 75);
            this.DescriptionContractTextBox.TabIndex = 5;
            // 
            // DescriptionContractLabel
            // 
            this.DescriptionContractLabel.AutoSize = true;
            this.DescriptionContractLabel.Location = new System.Drawing.Point(25, 100);
            this.DescriptionContractLabel.Name = "DescriptionContractLabel";
            this.DescriptionContractLabel.Size = new System.Drawing.Size(87, 17);
            this.DescriptionContractLabel.TabIndex = 4;
            this.DescriptionContractLabel.Text = "Descripción:";
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDateTimePicker.Location = new System.Drawing.Point(175, 50);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(225, 23);
            this.EndDateTimePicker.TabIndex = 3;
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(25, 50);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(126, 17);
            this.EndDateLabel.TabIndex = 2;
            this.EndDateLabel.Text = "Fecha de termino:";
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateTimePicker.Location = new System.Drawing.Point(175, 25);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(225, 23);
            this.StartDateTimePicker.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(25, 25);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(110, 17);
            this.StartDateLabel.TabIndex = 0;
            this.StartDateLabel.Text = "Fecha de inicio:";
            // 
            // ClientTabPage
            // 
            this.ClientTabPage.BackColor = System.Drawing.Color.LightGray;
            this.ClientTabPage.Controls.Add(this.ListClientDataGridView);
            this.ClientTabPage.Controls.Add(this.ClientLabel);
            this.ClientTabPage.ImageKey = "customers-form.jpeg";
            this.ClientTabPage.Location = new System.Drawing.Point(4, 27);
            this.ClientTabPage.Name = "ClientTabPage";
            this.ClientTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ClientTabPage.Size = new System.Drawing.Size(417, 269);
            this.ClientTabPage.TabIndex = 1;
            this.ClientTabPage.Text = "Clientes asociados";
            // 
            // ListClientDataGridView
            // 
            this.ListClientDataGridView.AllowUserToAddRows = false;
            this.ListClientDataGridView.AllowUserToDeleteRows = false;
            this.ListClientDataGridView.AllowUserToResizeRows = false;
            this.ListClientDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListClientDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ListClientDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.ListClientDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListClientDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ListClientDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListClientDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListClientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListClientDataGridView.ContextMenuStrip = this.ClientListContextMenuStrip;
            this.ListClientDataGridView.EnableHeadersVisualStyles = false;
            this.ListClientDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ListClientDataGridView.Location = new System.Drawing.Point(15, 50);
            this.ListClientDataGridView.MultiSelect = false;
            this.ListClientDataGridView.Name = "ListClientDataGridView";
            this.ListClientDataGridView.ReadOnly = true;
            this.ListClientDataGridView.RowHeadersVisible = false;
            this.ListClientDataGridView.RowTemplate.Height = 23;
            this.ListClientDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListClientDataGridView.ShowCellErrors = false;
            this.ListClientDataGridView.ShowCellToolTips = false;
            this.ListClientDataGridView.ShowEditingIcon = false;
            this.ListClientDataGridView.ShowRowErrors = false;
            this.ListClientDataGridView.Size = new System.Drawing.Size(385, 200);
            this.ListClientDataGridView.StandardTab = true;
            this.ListClientDataGridView.TabIndex = 1;
            this.ListClientDataGridView.SelectionChanged += new System.EventHandler(this.ListClientDataGridView_SelectionChanged);
            this.ListClientDataGridView.DoubleClick += new System.EventHandler(this.ListClientDataGridView_DoubleClick);
            // 
            // ClientListContextMenuStrip
            // 
            this.ClientListContextMenuStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientListContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ClientListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListRefreshToolStripMenuItem,
            this.ListToolStripSeparator1,
            this.ListAddToolStripMenuItem,
            this.ListEditToolStripMenuItem,
            this.ListToolStripSeparator2,
            this.ListRemoveToolStripMenuItem});
            this.ClientListContextMenuStrip.Name = "ClientListContextMenuStrip";
            this.ClientListContextMenuStrip.Size = new System.Drawing.Size(282, 120);
            this.ClientListContextMenuStrip.Text = "Opciones";
            // 
            // ListRefreshToolStripMenuItem
            // 
            this.ListRefreshToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_refresh;
            this.ListRefreshToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListRefreshToolStripMenuItem.Name = "ListRefreshToolStripMenuItem";
            this.ListRefreshToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.ListRefreshToolStripMenuItem.Text = "&Actualizar lista";
            this.ListRefreshToolStripMenuItem.Click += new System.EventHandler(this.ListRefreshToolStripMenuItem_Click);
            // 
            // ListToolStripSeparator1
            // 
            this.ListToolStripSeparator1.Name = "ListToolStripSeparator1";
            this.ListToolStripSeparator1.Size = new System.Drawing.Size(278, 6);
            // 
            // ListAddToolStripMenuItem
            // 
            this.ListAddToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.Button_Add;
            this.ListAddToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListAddToolStripMenuItem.Name = "ListAddToolStripMenuItem";
            this.ListAddToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.ListAddToolStripMenuItem.Text = "Asociar &nuevo ";
            this.ListAddToolStripMenuItem.Click += new System.EventHandler(this.ListAddToolStripMenuItem_Click);
            // 
            // ListEditToolStripMenuItem
            // 
            this.ListEditToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_edit;
            this.ListEditToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListEditToolStripMenuItem.Name = "ListEditToolStripMenuItem";
            this.ListEditToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.ListEditToolStripMenuItem.Text = "Editar parametros del contrato";
            this.ListEditToolStripMenuItem.Click += new System.EventHandler(this.ListEditToolStripMenuItem_Click);
            // 
            // ListToolStripSeparator2
            // 
            this.ListToolStripSeparator2.Name = "ListToolStripSeparator2";
            this.ListToolStripSeparator2.Size = new System.Drawing.Size(278, 6);
            // 
            // ListRemoveToolStripMenuItem
            // 
            this.ListRemoveToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_remove;
            this.ListRemoveToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListRemoveToolStripMenuItem.Name = "ListRemoveToolStripMenuItem";
            this.ListRemoveToolStripMenuItem.Size = new System.Drawing.Size(281, 26);
            this.ListRemoveToolStripMenuItem.Text = "Quitar del contrato";
            this.ListRemoveToolStripMenuItem.Click += new System.EventHandler(this.ListRemoveToolStripMenuItem_Click);
            // 
            // ClientLabel
            // 
            this.ClientLabel.AutoSize = true;
            this.ClientLabel.Location = new System.Drawing.Point(0, 25);
            this.ClientLabel.Name = "ClientLabel";
            this.ClientLabel.Size = new System.Drawing.Size(210, 17);
            this.ClientLabel.TabIndex = 0;
            this.ClientLabel.Text = "Clientes asociados al contrato:";
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-save.png");
            this.FormImageList.Images.SetKeyName(1, "button-cancel.png");
            this.FormImageList.Images.SetKeyName(2, "Button-Add.png");
            this.FormImageList.Images.SetKeyName(3, "button-remove.png");
            this.FormImageList.Images.SetKeyName(4, "customers-form.jpeg");
            this.FormImageList.Images.SetKeyName(5, "contract.png");
            // 
            // ContractCancelButton
            // 
            this.ContractCancelButton.AutoSize = true;
            this.ContractCancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContractCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ContractCancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ContractCancelButton.ImageKey = "button-cancel.png";
            this.ContractCancelButton.ImageList = this.FormImageList;
            this.ContractCancelButton.Location = new System.Drawing.Point(425, 325);
            this.ContractCancelButton.Name = "ContractCancelButton";
            this.ContractCancelButton.Size = new System.Drawing.Size(98, 27);
            this.ContractCancelButton.TabIndex = 3;
            this.ContractCancelButton.Text = "Cancelar";
            this.ContractCancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ContractCancelButton.UseVisualStyleBackColor = true;
            this.ContractCancelButton.Click += new System.EventHandler(this.ContractCancelButton_Click);
            // 
            // ContractSaveButton
            // 
            this.ContractSaveButton.AutoSize = true;
            this.ContractSaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContractSaveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ContractSaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ContractSaveButton.ImageKey = "button-save.png";
            this.ContractSaveButton.ImageList = this.FormImageList;
            this.ContractSaveButton.Location = new System.Drawing.Point(325, 325);
            this.ContractSaveButton.Name = "ContractSaveButton";
            this.ContractSaveButton.Size = new System.Drawing.Size(84, 27);
            this.ContractSaveButton.TabIndex = 2;
            this.ContractSaveButton.Text = "Grabar";
            this.ContractSaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ContractSaveButton.UseVisualStyleBackColor = true;
            this.ContractSaveButton.Click += new System.EventHandler(this.ContractSaveButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.contract_form;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 75);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // DeleteContractButton
            // 
            this.DeleteContractButton.AutoSize = true;
            this.DeleteContractButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DeleteContractButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteContractButton.ImageKey = "button-remove.png";
            this.DeleteContractButton.ImageList = this.FormImageList;
            this.DeleteContractButton.Location = new System.Drawing.Point(0, 325);
            this.DeleteContractButton.Name = "DeleteContractButton";
            this.DeleteContractButton.Size = new System.Drawing.Size(149, 27);
            this.DeleteContractButton.TabIndex = 6;
            this.DeleteContractButton.Text = "Eliminar contrato";
            this.DeleteContractButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteContractButton.UseVisualStyleBackColor = true;
            this.DeleteContractButton.Click += new System.EventHandler(this.DeleteContractButton_Click);
            // 
            // ContractRegisterForm
            // 
            this.AcceptButton = this.ContractSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ContractCancelButton;
            this.ClientSize = new System.Drawing.Size(539, 361);
            this.Controls.Add(this.DeleteContractButton);
            this.Controls.Add(this.ContractCancelButton);
            this.Controls.Add(this.ContractSaveButton);
            this.Controls.Add(this.FormTabControl);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContractRegisterForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de contratos.";
            this.Load += new System.EventHandler(this.ContractRegisterForm_Load);
            this.FormTabControl.ResumeLayout(false);
            this.ContractTabPage.ResumeLayout(false);
            this.ContractTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommissionNumericUpDown)).EndInit();
            this.ClientTabPage.ResumeLayout(false);
            this.ClientTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListClientDataGridView)).EndInit();
            this.ClientListContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.TabControl FormTabControl;
        private System.Windows.Forms.TabPage ContractTabPage;
        private System.Windows.Forms.TabPage ClientTabPage;
        private System.Windows.Forms.Button ContractSaveButton;
        private System.Windows.Forms.Button ContractCancelButton;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.TextBox DescriptionContractTextBox;
        private System.Windows.Forms.Label DescriptionContractLabel;
        private System.Windows.Forms.NumericUpDown CommissionNumericUpDown;
        private System.Windows.Forms.Label CommissionLabel;
        private System.Windows.Forms.Label ContractTypeLabel;
        private System.Windows.Forms.ComboBox ContractTypeComboBox;
        private System.Windows.Forms.CheckBox ContractValidCheckBox;
        private System.Windows.Forms.DataGridView ListClientDataGridView;
        private System.Windows.Forms.Label ClientLabel;
        private System.Windows.Forms.ContextMenuStrip ClientListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ListRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ListToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ListAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ListToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ListRemoveToolStripMenuItem;
        private System.Windows.Forms.Button DeleteContractButton;
    }
}