﻿namespace FeriaVirtual.View.Desktop.Forms.Contracts {
    partial class ContractMaintenanceForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractMaintenanceForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientProducerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClientCarrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormLabel = new System.Windows.Forms.Label();
            this.OptionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.OptionLabel = new System.Windows.Forms.Label();
            this.ListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ListFilterLabel = new System.Windows.Forms.Label();
            this.ListCountLabel = new System.Windows.Forms.Label();
            this.ListTitleLabel = new System.Windows.Forms.Label();
            this.ListFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ListFilterTextBox = new System.Windows.Forms.TextBox();
            this.ListDataGridView = new System.Windows.Forms.DataGridView();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.OptionCloseButton = new System.Windows.Forms.Button();
            this.OptionEditButton = new System.Windows.Forms.Button();
            this.OptionNewButton = new System.Windows.Forms.Button();
            this.ListFilterButton = new System.Windows.Forms.Button();
            this.OptionNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormMenuStrip.SuspendLayout();
            this.FormTableLayoutPanel.SuspendLayout();
            this.OptionsTableLayoutPanel.SuspendLayout();
            this.ListTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormMenuStrip
            // 
            this.FormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem,
            this.ClientToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Size = new System.Drawing.Size(730, 25);
            this.FormMenuStrip.TabIndex = 4;
            this.FormMenuStrip.Text = "&Opciones";
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionNewToolStripMenuItem,
            this.OptionEditToolStripMenuItem,
            this.OptionToolStripSeparator1,
            this.OptionRefreshToolStripMenuItem,
            this.optionToolStripSeparator2,
            this.OptionCloseToolStripMenuItem});
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.OptionToolStripMenuItem.Text = "&Opciones";
            // 
            // OptionToolStripSeparator1
            // 
            this.OptionToolStripSeparator1.Name = "OptionToolStripSeparator1";
            this.OptionToolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // optionToolStripSeparator2
            // 
            this.optionToolStripSeparator2.Name = "optionToolStripSeparator2";
            this.optionToolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // ClientToolStripMenuItem
            // 
            this.ClientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientProducerToolStripMenuItem,
            this.ClientToolStripSeparator1,
            this.ClientCarrierToolStripMenuItem});
            this.ClientToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem";
            this.ClientToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.ClientToolStripMenuItem.Text = "Clientes";
            // 
            // ClientProducerToolStripMenuItem
            // 
            this.ClientProducerToolStripMenuItem.Name = "ClientProducerToolStripMenuItem";
            this.ClientProducerToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ClientProducerToolStripMenuItem.Text = "Procesar productores";
            this.ClientProducerToolStripMenuItem.Click += new System.EventHandler(this.ClientProducerToolStripMenuItem_Click);
            // 
            // ClientToolStripSeparator1
            // 
            this.ClientToolStripSeparator1.Name = "ClientToolStripSeparator1";
            this.ClientToolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // ClientCarrierToolStripMenuItem
            // 
            this.ClientCarrierToolStripMenuItem.Name = "ClientCarrierToolStripMenuItem";
            this.ClientCarrierToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.ClientCarrierToolStripMenuItem.Text = "Procesar transportistas";
            this.ClientCarrierToolStripMenuItem.Click += new System.EventHandler(this.ClientCarrierToolStripMenuItem_Click);
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
            this.FormTableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.FormTableLayoutPanel.Name = "FormTableLayoutPanel";
            this.FormTableLayoutPanel.RowCount = 2;
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.FormTableLayoutPanel.Size = new System.Drawing.Size(730, 278);
            this.FormTableLayoutPanel.TabIndex = 5;
            // 
            // FormLabel
            // 
            this.FormLabel.AutoSize = true;
            this.FormLabel.BackColor = System.Drawing.Color.LightGray;
            this.FormTableLayoutPanel.SetColumnSpan(this.FormLabel, 2);
            this.FormLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FormLabel.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormLabel.Location = new System.Drawing.Point(3, 2);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(724, 25);
            this.FormLabel.TabIndex = 2;
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
            this.OptionsTableLayoutPanel.Location = new System.Drawing.Point(3, 30);
            this.OptionsTableLayoutPanel.Name = "OptionsTableLayoutPanel";
            this.OptionsTableLayoutPanel.RowCount = 6;
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.OptionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.OptionsTableLayoutPanel.Size = new System.Drawing.Size(103, 245);
            this.OptionsTableLayoutPanel.TabIndex = 3;
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
            // OptionLabel
            // 
            this.OptionLabel.AutoSize = true;
            this.OptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionLabel.Location = new System.Drawing.Point(3, 0);
            this.OptionLabel.Name = "OptionLabel";
            this.OptionLabel.Size = new System.Drawing.Size(97, 24);
            this.OptionLabel.TabIndex = 0;
            this.OptionLabel.Text = "Opciones";
            this.OptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ListTableLayoutPanel.Location = new System.Drawing.Point(112, 30);
            this.ListTableLayoutPanel.Name = "ListTableLayoutPanel";
            this.ListTableLayoutPanel.RowCount = 4;
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.Size = new System.Drawing.Size(615, 245);
            this.ListTableLayoutPanel.TabIndex = 4;
            // 
            // ListFilterLabel
            // 
            this.ListFilterLabel.AutoSize = true;
            this.ListFilterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFilterLabel.Location = new System.Drawing.Point(3, 24);
            this.ListFilterLabel.Name = "ListFilterLabel";
            this.ListFilterLabel.Size = new System.Drawing.Size(86, 24);
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
            this.ListCountLabel.Location = new System.Drawing.Point(3, 219);
            this.ListCountLabel.Name = "ListCountLabel";
            this.ListCountLabel.Size = new System.Drawing.Size(609, 26);
            this.ListCountLabel.TabIndex = 3;
            this.ListCountLabel.Text = "Contratos disponibles...";
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
            this.ListTitleLabel.Size = new System.Drawing.Size(609, 24);
            this.ListTitleLabel.TabIndex = 1;
            this.ListTitleLabel.Text = "Lista de contratos disponibles";
            this.ListTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListFilterComboBox
            // 
            this.ListFilterComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListFilterComboBox.FormattingEnabled = true;
            this.ListFilterComboBox.Location = new System.Drawing.Point(95, 27);
            this.ListFilterComboBox.Name = "ListFilterComboBox";
            this.ListFilterComboBox.Size = new System.Drawing.Size(209, 25);
            this.ListFilterComboBox.TabIndex = 5;
            // 
            // ListFilterTextBox
            // 
            this.ListFilterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterTextBox.Location = new System.Drawing.Point(310, 27);
            this.ListFilterTextBox.Name = "ListFilterTextBox";
            this.ListFilterTextBox.Size = new System.Drawing.Size(209, 23);
            this.ListFilterTextBox.TabIndex = 6;
            // 
            // ListDataGridView
            // 
            this.ListDataGridView.AllowUserToAddRows = false;
            this.ListDataGridView.AllowUserToDeleteRows = false;
            this.ListDataGridView.AllowUserToOrderColumns = true;
            this.ListDataGridView.AllowUserToResizeRows = false;
            this.ListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.ListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListDataGridView, 4);
            this.ListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ListDataGridView.Location = new System.Drawing.Point(3, 51);
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
            this.ListDataGridView.Size = new System.Drawing.Size(609, 165);
            this.ListDataGridView.StandardTab = true;
            this.ListDataGridView.TabIndex = 8;
            this.ListDataGridView.SelectionChanged += new System.EventHandler(this.ListDataGridView_SelectionChanged);
            this.ListDataGridView.DoubleClick += new System.EventHandler(this.ListDataGridView_DoubleClick);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.contract_asociation;
            this.FormPictureBox.Location = new System.Drawing.Point(3, 172);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(97, 70);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 6;
            this.FormPictureBox.TabStop = false;
            // 
            // OptionCloseButton
            // 
            this.OptionCloseButton.AutoSize = true;
            this.OptionCloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionCloseButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionCloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionCloseButton.ImageKey = "menu-exit.png";
            this.OptionCloseButton.ImageList = this.FormImageList;
            this.OptionCloseButton.Location = new System.Drawing.Point(3, 99);
            this.OptionCloseButton.Name = "OptionCloseButton";
            this.OptionCloseButton.Size = new System.Drawing.Size(97, 27);
            this.OptionCloseButton.TabIndex = 4;
            this.OptionCloseButton.Text = "&Cerrar";
            this.OptionCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OptionCloseButton.UseVisualStyleBackColor = true;
            this.OptionCloseButton.Click += new System.EventHandler(this.OptionCloseButton_Click);
            // 
            // OptionEditButton
            // 
            this.OptionEditButton.AutoSize = true;
            this.OptionEditButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionEditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionEditButton.ImageKey = "button-edit.png";
            this.OptionEditButton.ImageList = this.FormImageList;
            this.OptionEditButton.Location = new System.Drawing.Point(3, 51);
            this.OptionEditButton.Name = "OptionEditButton";
            this.OptionEditButton.Size = new System.Drawing.Size(97, 18);
            this.OptionEditButton.TabIndex = 2;
            this.OptionEditButton.Text = "&Editar";
            this.OptionEditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OptionEditButton.UseVisualStyleBackColor = true;
            this.OptionEditButton.Click += new System.EventHandler(this.OptionEditButton_Click);
            // 
            // OptionNewButton
            // 
            this.OptionNewButton.AutoSize = true;
            this.OptionNewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OptionNewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionNewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionNewButton.ImageKey = "button-new.png";
            this.OptionNewButton.ImageList = this.FormImageList;
            this.OptionNewButton.Location = new System.Drawing.Point(3, 27);
            this.OptionNewButton.Name = "OptionNewButton";
            this.OptionNewButton.Size = new System.Drawing.Size(97, 18);
            this.OptionNewButton.TabIndex = 1;
            this.OptionNewButton.Text = "&Nuevo";
            this.OptionNewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OptionNewButton.UseVisualStyleBackColor = true;
            this.OptionNewButton.Click += new System.EventHandler(this.OptionNewButton_Click);
            // 
            // ListFilterButton
            // 
            this.ListFilterButton.AutoSize = true;
            this.ListFilterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListFilterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListFilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListFilterButton.ImageKey = "button-find.png";
            this.ListFilterButton.ImageList = this.FormImageList;
            this.ListFilterButton.Location = new System.Drawing.Point(525, 27);
            this.ListFilterButton.Name = "ListFilterButton";
            this.ListFilterButton.Size = new System.Drawing.Size(87, 18);
            this.ListFilterButton.TabIndex = 7;
            this.ListFilterButton.Text = "&Buscar";
            this.ListFilterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ListFilterButton.UseVisualStyleBackColor = true;
            this.ListFilterButton.Click += new System.EventHandler(this.ListFilterButton_Click);
            // 
            // OptionNewToolStripMenuItem
            // 
            this.OptionNewToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_new;
            this.OptionNewToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionNewToolStripMenuItem.Name = "OptionNewToolStripMenuItem";
            this.OptionNewToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.OptionNewToolStripMenuItem.Text = "&Nuevo contrato";
            this.OptionNewToolStripMenuItem.Click += new System.EventHandler(this.OptionNewToolStripMenuItem_Click);
            // 
            // OptionEditToolStripMenuItem
            // 
            this.OptionEditToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_edit;
            this.OptionEditToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionEditToolStripMenuItem.Name = "OptionEditToolStripMenuItem";
            this.OptionEditToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.OptionEditToolStripMenuItem.Text = "&Editar contrato";
            this.OptionEditToolStripMenuItem.Click += new System.EventHandler(this.OptionEditToolStripMenuItem_Click);
            // 
            // OptionRefreshToolStripMenuItem
            // 
            this.OptionRefreshToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_refresh;
            this.OptionRefreshToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionRefreshToolStripMenuItem.Name = "OptionRefreshToolStripMenuItem";
            this.OptionRefreshToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.OptionRefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.OptionRefreshToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.OptionRefreshToolStripMenuItem.Text = "&Actualizar lista";
            this.OptionRefreshToolStripMenuItem.Click += new System.EventHandler(this.OptionRefreshToolStripMenuItem_Click);
            // 
            // OptionCloseToolStripMenuItem
            // 
            this.OptionCloseToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_exit;
            this.OptionCloseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptionCloseToolStripMenuItem.Name = "OptionCloseToolStripMenuItem";
            this.OptionCloseToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.OptionCloseToolStripMenuItem.Text = "&Cerrar formulario";
            this.OptionCloseToolStripMenuItem.Click += new System.EventHandler(this.OptionCloseToolStripMenuItem_Click);
            // 
            // ContractMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(730, 303);
            this.Controls.Add(this.FormTableLayoutPanel);
            this.Controls.Add(this.FormMenuStrip);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(746, 342);
            this.Name = "ContractMaintenanceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maestro de contratos.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContractMaintenanceForm_Load);
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
            this.FormTableLayoutPanel.ResumeLayout(false);
            this.FormTableLayoutPanel.PerformLayout();
            this.OptionsTableLayoutPanel.ResumeLayout(false);
            this.OptionsTableLayoutPanel.PerformLayout();
            this.ListTableLayoutPanel.ResumeLayout(false);
            this.ListTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator OptionToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OptionRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator optionToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OptionCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientProducerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ClientToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ClientCarrierToolStripMenuItem;
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