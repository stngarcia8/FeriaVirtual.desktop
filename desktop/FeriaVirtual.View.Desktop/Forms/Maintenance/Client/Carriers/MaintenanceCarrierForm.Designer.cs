namespace FeriaVirtual.View.Desktop.Forms.Maintenance.Client.Carriers {
    partial class MaintenanceCarrierForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceCarrierForm));
            this.FormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormLabel = new System.Windows.Forms.Label();
            this.OptionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OptionCloseButton = new System.Windows.Forms.Button();
            this.OptionEditButton = new System.Windows.Forms.Button();
            this.OptionLabel = new System.Windows.Forms.Label();
            this.OptionNewButton = new System.Windows.Forms.Button();
            this.ListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ListFilterButton = new System.Windows.Forms.Button();
            this.ListFilterLabel = new System.Windows.Forms.Label();
            this.ListCountLabel = new System.Windows.Forms.Label();
            this.ListTitleLabel = new System.Windows.Forms.Label();
            this.ListFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ListFilterTextBox = new System.Windows.Forms.TextBox();
            this.ListDataGridView = new System.Windows.Forms.DataGridView();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.FormTableLayoutPanel.SuspendLayout();
            this.OptionsTableLayoutPanel.SuspendLayout();
            this.ListTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormTableLayoutPanel
            // 
            this.FormTableLayoutPanel.ColumnCount = 2;
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.FormTableLayoutPanel.Controls.Add(this.FormLabel, 0, 0);
            this.FormTableLayoutPanel.Controls.Add(this.OptionsTableLayoutPanel, 0, 1);
            this.FormTableLayoutPanel.Controls.Add(this.ListTableLayoutPanel, 1, 1);
            this.FormTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FormTableLayoutPanel.Name = "FormTableLayoutPanel";
            this.FormTableLayoutPanel.RowCount = 2;
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.FormTableLayoutPanel.Size = new System.Drawing.Size(789, 352);
            this.FormTableLayoutPanel.TabIndex = 2;
            // 
            // FormLabel
            // 
            this.FormLabel.AutoSize = true;
            this.FormLabel.BackColor = System.Drawing.Color.LightGray;
            this.FormTableLayoutPanel.SetColumnSpan(this.FormLabel, 2);
            this.FormLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormLabel.Location = new System.Drawing.Point(3, 0);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(783, 35);
            this.FormLabel.TabIndex = 2;
            this.FormLabel.Text = "Transportistas registrados.";
            this.FormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OptionsTableLayoutPanel
            // 
            this.OptionsTableLayoutPanel.ColumnCount = 1;
            this.OptionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionsTableLayoutPanel.Controls.Add(this.FormPictureBox, 0, 5);
            this.OptionsTableLayoutPanel.Controls.Add(this.OptionCloseButton, 0, 4);
            this.OptionsTableLayoutPanel.Controls.Add(this.OptionEditButton, 0, 2);
            this.OptionsTableLayoutPanel.Controls.Add(this.OptionLabel, 0, 0);
            this.OptionsTableLayoutPanel.Controls.Add(this.OptionNewButton, 0, 1);
            this.OptionsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsTableLayoutPanel.Location = new System.Drawing.Point(3, 38);
            this.OptionsTableLayoutPanel.Name = "OptionsTableLayoutPanel";
            this.OptionsTableLayoutPanel.RowCount = 6;
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.OptionsTableLayoutPanel.Size = new System.Drawing.Size(112, 311);
            this.OptionsTableLayoutPanel.TabIndex = 3;
            // 
            // OptionCloseButton
            // 
            this.OptionCloseButton.AutoSize = true;
            this.OptionCloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionCloseButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionCloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionCloseButton.ImageKey = "menu-exit.png";
            this.OptionCloseButton.ImageList = this.FormImageList;
            this.OptionCloseButton.Location = new System.Drawing.Point(3, 127);
            this.OptionCloseButton.Name = "OptionCloseButton";
            this.OptionCloseButton.Size = new System.Drawing.Size(106, 27);
            this.OptionCloseButton.TabIndex = 4;
            this.OptionCloseButton.Text = "&Cerrar";
            this.OptionCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OptionCloseButton.UseVisualStyleBackColor = true;
            // 
            // OptionEditButton
            // 
            this.OptionEditButton.AutoSize = true;
            this.OptionEditButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionEditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionEditButton.ImageKey = "button-edit.png";
            this.OptionEditButton.ImageList = this.FormImageList;
            this.OptionEditButton.Location = new System.Drawing.Point(3, 65);
            this.OptionEditButton.Name = "OptionEditButton";
            this.OptionEditButton.Size = new System.Drawing.Size(106, 25);
            this.OptionEditButton.TabIndex = 2;
            this.OptionEditButton.Text = "&Editar";
            this.OptionEditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OptionEditButton.UseVisualStyleBackColor = true;
            // 
            // OptionLabel
            // 
            this.OptionLabel.AutoSize = true;
            this.OptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionLabel.Location = new System.Drawing.Point(3, 0);
            this.OptionLabel.Name = "OptionLabel";
            this.OptionLabel.Size = new System.Drawing.Size(106, 31);
            this.OptionLabel.TabIndex = 0;
            this.OptionLabel.Text = "Opciones";
            this.OptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptionNewButton
            // 
            this.OptionNewButton.AutoSize = true;
            this.OptionNewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionNewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionNewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionNewButton.ImageKey = "button-new.png";
            this.OptionNewButton.ImageList = this.FormImageList;
            this.OptionNewButton.Location = new System.Drawing.Point(3, 34);
            this.OptionNewButton.Name = "OptionNewButton";
            this.OptionNewButton.Size = new System.Drawing.Size(106, 25);
            this.OptionNewButton.TabIndex = 1;
            this.OptionNewButton.Text = "&Nuevo";
            this.OptionNewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OptionNewButton.UseVisualStyleBackColor = true;
            // 
            // ListTableLayoutPanel
            // 
            this.ListTableLayoutPanel.ColumnCount = 4;
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterButton, 3, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterLabel, 0, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListCountLabel, 0, 3);
            this.ListTableLayoutPanel.Controls.Add(this.ListTitleLabel, 0, 0);
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterComboBox, 1, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterTextBox, 2, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListDataGridView, 0, 2);
            this.ListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTableLayoutPanel.Location = new System.Drawing.Point(121, 38);
            this.ListTableLayoutPanel.Name = "ListTableLayoutPanel";
            this.ListTableLayoutPanel.RowCount = 4;
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.Size = new System.Drawing.Size(665, 311);
            this.ListTableLayoutPanel.TabIndex = 4;
            // 
            // ListFilterButton
            // 
            this.ListFilterButton.AutoSize = true;
            this.ListFilterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListFilterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListFilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListFilterButton.ImageKey = "button-find.png";
            this.ListFilterButton.ImageList = this.FormImageList;
            this.ListFilterButton.Location = new System.Drawing.Point(566, 34);
            this.ListFilterButton.Name = "ListFilterButton";
            this.ListFilterButton.Size = new System.Drawing.Size(96, 25);
            this.ListFilterButton.TabIndex = 7;
            this.ListFilterButton.Text = "&Buscar";
            this.ListFilterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ListFilterButton.UseVisualStyleBackColor = true;
            // 
            // ListFilterLabel
            // 
            this.ListFilterLabel.AutoSize = true;
            this.ListFilterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFilterLabel.Location = new System.Drawing.Point(3, 31);
            this.ListFilterLabel.Name = "ListFilterLabel";
            this.ListFilterLabel.Size = new System.Drawing.Size(93, 31);
            this.ListFilterLabel.TabIndex = 4;
            this.ListFilterLabel.Text = "Filtro: ";
            this.ListFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ListCountLabel
            // 
            this.ListCountLabel.AutoSize = true;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListCountLabel, 4);
            this.ListCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListCountLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListCountLabel.Location = new System.Drawing.Point(3, 279);
            this.ListCountLabel.Name = "ListCountLabel";
            this.ListCountLabel.Size = new System.Drawing.Size(659, 32);
            this.ListCountLabel.TabIndex = 3;
            this.ListCountLabel.Text = "Usuarios disponibles...";
            this.ListCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListTitleLabel
            // 
            this.ListTitleLabel.AutoSize = true;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListTitleLabel, 4);
            this.ListTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.ListTitleLabel.Name = "ListTitleLabel";
            this.ListTitleLabel.Size = new System.Drawing.Size(659, 31);
            this.ListTitleLabel.TabIndex = 1;
            this.ListTitleLabel.Text = "Lista de transportistas disponibles";
            this.ListTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListFilterComboBox
            // 
            this.ListFilterComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListFilterComboBox.FormattingEnabled = true;
            this.ListFilterComboBox.Location = new System.Drawing.Point(102, 34);
            this.ListFilterComboBox.Name = "ListFilterComboBox";
            this.ListFilterComboBox.Size = new System.Drawing.Size(226, 25);
            this.ListFilterComboBox.TabIndex = 5;
            // 
            // ListFilterTextBox
            // 
            this.ListFilterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterTextBox.Location = new System.Drawing.Point(334, 34);
            this.ListFilterTextBox.Name = "ListFilterTextBox";
            this.ListFilterTextBox.Size = new System.Drawing.Size(226, 23);
            this.ListFilterTextBox.TabIndex = 6;
            // 
            // ListDataGridView
            // 
            this.ListDataGridView.AllowUserToAddRows = false;
            this.ListDataGridView.AllowUserToDeleteRows = false;
            this.ListDataGridView.AllowUserToOrderColumns = true;
            this.ListDataGridView.AllowUserToResizeRows = false;
            this.ListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.ListDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListDataGridView, 4);
            this.ListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ListDataGridView.Location = new System.Drawing.Point(3, 65);
            this.ListDataGridView.MultiSelect = false;
            this.ListDataGridView.Name = "ListDataGridView";
            this.ListDataGridView.ReadOnly = true;
            this.ListDataGridView.RowHeadersVisible = false;
            this.ListDataGridView.RowTemplate.Height = 23;
            this.ListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListDataGridView.ShowCellErrors = false;
            this.ListDataGridView.ShowCellToolTips = false;
            this.ListDataGridView.ShowEditingIcon = false;
            this.ListDataGridView.ShowRowErrors = false;
            this.ListDataGridView.Size = new System.Drawing.Size(659, 211);
            this.ListDataGridView.StandardTab = true;
            this.ListDataGridView.TabIndex = 8;
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.transportist_form;
            this.FormPictureBox.Location = new System.Drawing.Point(3, 220);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(106, 77);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 6;
            this.FormPictureBox.TabStop = false;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-new.png");
            this.FormImageList.Images.SetKeyName(1, "button-edit.png");
            this.FormImageList.Images.SetKeyName(2, "button-find.png");
            this.FormImageList.Images.SetKeyName(3, "menu-exit.png");
            // 
            // MaintenanceCarrierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 352);
            this.Controls.Add(this.FormTableLayoutPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MaintenanceCarrierForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mantenimiento de transportistas.";
            this.FormTableLayoutPanel.ResumeLayout(false);
            this.FormTableLayoutPanel.PerformLayout();
            this.OptionsTableLayoutPanel.ResumeLayout(false);
            this.OptionsTableLayoutPanel.PerformLayout();
            this.ListTableLayoutPanel.ResumeLayout(false);
            this.ListTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel FormTableLayoutPanel;
        private System.Windows.Forms.Label FormLabel;
        private System.Windows.Forms.TableLayoutPanel OptionsTableLayoutPanel;
        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Button OptionCloseButton;
        private System.Windows.Forms.Button OptionEditButton;
        private System.Windows.Forms.Label OptionLabel;
        private System.Windows.Forms.Button OptionNewButton;
        private System.Windows.Forms.TableLayoutPanel ListTableLayoutPanel;
        private System.Windows.Forms.Button ListFilterButton;
        private System.Windows.Forms.Label ListFilterLabel;
        private System.Windows.Forms.Label ListCountLabel;
        private System.Windows.Forms.Label ListTitleLabel;
        private System.Windows.Forms.ComboBox ListFilterComboBox;
        private System.Windows.Forms.TextBox ListFilterTextBox;
        private System.Windows.Forms.DataGridView ListDataGridView;
        private System.Windows.Forms.ImageList FormImageList;
    }
}