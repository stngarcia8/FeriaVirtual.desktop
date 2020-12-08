namespace FeriaVirtual.View.Desktop.Forms.Payments {
    partial class PaymentForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaymentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PaymentRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PaymentToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PaymentShowDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.FormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ListTitleLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PropertiesDataGridView = new System.Windows.Forms.DataGridView();
            this.PropertyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ListDataGridView = new System.Windows.Forms.DataGridView();
            this.ListCountLabel = new System.Windows.Forms.Label();
            this.PropertiesTitleLabel = new System.Windows.Forms.Label();
            this.OptionsFilterTreeView = new System.Windows.Forms.TreeView();
            this.FormMenuStrip.SuspendLayout();
            this.PaymentContextMenuStrip.SuspendLayout();
            this.FormTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesDataGridView)).BeginInit();
            this.ListTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormMenuStrip
            // 
            this.FormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.FormMenuStrip.TabIndex = 5;
            this.FormMenuStrip.Text = "&Opciones";
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionRefreshToolStripMenuItem,
            this.optionToolStripSeparator2,
            this.OptionCloseToolStripMenuItem});
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.OptionToolStripMenuItem.Text = "&Opciones";
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
            // optionToolStripSeparator2
            // 
            this.optionToolStripSeparator2.Name = "optionToolStripSeparator2";
            this.optionToolStripSeparator2.Size = new System.Drawing.Size(166, 6);
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
            // PaymentContextMenuStrip
            // 
            this.PaymentContextMenuStrip.BackColor = System.Drawing.Color.LightGray;
            this.PaymentContextMenuStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PaymentRefreshToolStripMenuItem,
            this.PaymentToolStripSeparator1,
            this.PaymentShowDetailsToolStripMenuItem});
            this.PaymentContextMenuStrip.Name = "OrderContextMenuStrip";
            this.PaymentContextMenuStrip.Size = new System.Drawing.Size(249, 54);
            this.PaymentContextMenuStrip.Text = "Opciones";
            this.PaymentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.PaymentContextMenuStrip_Opening);
            // 
            // PaymentRefreshToolStripMenuItem
            // 
            this.PaymentRefreshToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_refresh;
            this.PaymentRefreshToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PaymentRefreshToolStripMenuItem.Name = "PaymentRefreshToolStripMenuItem";
            this.PaymentRefreshToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.PaymentRefreshToolStripMenuItem.Text = "Actualizar lista";
            this.PaymentRefreshToolStripMenuItem.Click += new System.EventHandler(this.PaymentRefreshToolStripMenuItem_Click);
            // 
            // PaymentToolStripSeparator1
            // 
            this.PaymentToolStripSeparator1.Name = "PaymentToolStripSeparator1";
            this.PaymentToolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // PaymentShowDetailsToolStripMenuItem
            // 
            this.PaymentShowDetailsToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_payments1;
            this.PaymentShowDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PaymentShowDetailsToolStripMenuItem.Name = "PaymentShowDetailsToolStripMenuItem";
            this.PaymentShowDetailsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.PaymentShowDetailsToolStripMenuItem.Text = "&Visualizar detalle del pago";
            this.PaymentShowDetailsToolStripMenuItem.Click += new System.EventHandler(this.PaymentShowDetailsToolStripMenuItem_Click);
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-new.png");
            this.FormImageList.Images.SetKeyName(1, "button-edit.png");
            this.FormImageList.Images.SetKeyName(2, "button-find.png");
            this.FormImageList.Images.SetKeyName(3, "menu-exit.png");
            this.FormImageList.Images.SetKeyName(4, "properties-button.png");
            // 
            // FormTableLayoutPanel
            // 
            this.FormTableLayoutPanel.ColumnCount = 3;
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.FormTableLayoutPanel.Controls.Add(this.ListTitleLabel, 1, 0);
            this.FormTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 2, 1);
            this.FormTableLayoutPanel.Controls.Add(this.ListTableLayoutPanel, 1, 1);
            this.FormTableLayoutPanel.Controls.Add(this.PropertiesTitleLabel, 2, 0);
            this.FormTableLayoutPanel.Controls.Add(this.OptionsFilterTreeView, 0, 0);
            this.FormTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.FormTableLayoutPanel.Name = "FormTableLayoutPanel";
            this.FormTableLayoutPanel.RowCount = 3;
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.562841F));
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.43716F));
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.FormTableLayoutPanel.Size = new System.Drawing.Size(784, 387);
            this.FormTableLayoutPanel.TabIndex = 7;
            // 
            // ListTitleLabel
            // 
            this.ListTitleLabel.AutoSize = true;
            this.ListTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListTitleLabel.Location = new System.Drawing.Point(159, 0);
            this.ListTitleLabel.Name = "ListTitleLabel";
            this.ListTitleLabel.Size = new System.Drawing.Size(386, 35);
            this.ListTitleLabel.TabIndex = 2;
            this.ListTitleLabel.Text = "Lista de pagos";
            this.ListTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PropertiesDataGridView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(551, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(230, 325);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // PropertiesDataGridView
            // 
            this.PropertiesDataGridView.AllowUserToAddRows = false;
            this.PropertiesDataGridView.AllowUserToDeleteRows = false;
            this.PropertiesDataGridView.AllowUserToOrderColumns = true;
            this.PropertiesDataGridView.AllowUserToResizeRows = false;
            this.PropertiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PropertiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PropertiesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PropertiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PropertiesDataGridView.ColumnHeadersVisible = false;
            this.PropertiesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyColumn,
            this.ValueColumn1});
            this.tableLayoutPanel1.SetColumnSpan(this.PropertiesDataGridView, 4);
            this.PropertiesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.PropertiesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.PropertiesDataGridView.MultiSelect = false;
            this.PropertiesDataGridView.Name = "PropertiesDataGridView";
            this.PropertiesDataGridView.ReadOnly = true;
            this.PropertiesDataGridView.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.PropertiesDataGridView, 2);
            this.PropertiesDataGridView.RowTemplate.Height = 23;
            this.PropertiesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PropertiesDataGridView.ShowCellErrors = false;
            this.PropertiesDataGridView.ShowCellToolTips = false;
            this.PropertiesDataGridView.ShowEditingIcon = false;
            this.PropertiesDataGridView.ShowRowErrors = false;
            this.PropertiesDataGridView.Size = new System.Drawing.Size(224, 319);
            this.PropertiesDataGridView.StandardTab = true;
            this.PropertiesDataGridView.TabIndex = 6;
            // 
            // PropertyColumn
            // 
            this.PropertyColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PropertyColumn.HeaderText = "Propiedad";
            this.PropertyColumn.Name = "PropertyColumn";
            this.PropertyColumn.ReadOnly = true;
            this.PropertyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyColumn.Width = 5;
            // 
            // ValueColumn1
            // 
            this.ValueColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ValueColumn1.HeaderText = "Valor";
            this.ValueColumn1.Name = "ValueColumn1";
            this.ValueColumn1.ReadOnly = true;
            this.ValueColumn1.Width = 5;
            // 
            // ListTableLayoutPanel
            // 
            this.ListTableLayoutPanel.ColumnCount = 1;
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ListTableLayoutPanel.Controls.Add(this.ListDataGridView, 0, 0);
            this.ListTableLayoutPanel.Controls.Add(this.ListCountLabel, 0, 1);
            this.ListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTableLayoutPanel.Location = new System.Drawing.Point(159, 38);
            this.ListTableLayoutPanel.Name = "ListTableLayoutPanel";
            this.ListTableLayoutPanel.RowCount = 2;
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ListTableLayoutPanel.Size = new System.Drawing.Size(386, 325);
            this.ListTableLayoutPanel.TabIndex = 4;
            // 
            // ListDataGridView
            // 
            this.ListDataGridView.AllowUserToAddRows = false;
            this.ListDataGridView.AllowUserToDeleteRows = false;
            this.ListDataGridView.AllowUserToOrderColumns = true;
            this.ListDataGridView.AllowUserToResizeRows = false;
            this.ListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.ListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListDataGridView, 2);
            this.ListDataGridView.ContextMenuStrip = this.PaymentContextMenuStrip;
            this.ListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ListDataGridView.Location = new System.Drawing.Point(3, 3);
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
            this.ListDataGridView.Size = new System.Drawing.Size(380, 293);
            this.ListDataGridView.StandardTab = true;
            this.ListDataGridView.TabIndex = 3;
            this.ListDataGridView.SelectionChanged += new System.EventHandler(this.ListDataGridView_SelectionChanged);
            // 
            // ListCountLabel
            // 
            this.ListCountLabel.AutoSize = true;
            this.ListCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListCountLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListCountLabel.Location = new System.Drawing.Point(3, 299);
            this.ListCountLabel.Name = "ListCountLabel";
            this.ListCountLabel.Size = new System.Drawing.Size(380, 26);
            this.ListCountLabel.TabIndex = 4;
            this.ListCountLabel.Text = "Pagos disponibles";
            this.ListCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PropertiesTitleLabel
            // 
            this.PropertiesTitleLabel.AutoSize = true;
            this.PropertiesTitleLabel.BackColor = System.Drawing.Color.Yellow;
            this.PropertiesTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesTitleLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertiesTitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PropertiesTitleLabel.ImageKey = "properties-button.png";
            this.PropertiesTitleLabel.ImageList = this.FormImageList;
            this.PropertiesTitleLabel.Location = new System.Drawing.Point(551, 0);
            this.PropertiesTitleLabel.Name = "PropertiesTitleLabel";
            this.PropertiesTitleLabel.Size = new System.Drawing.Size(230, 35);
            this.PropertiesTitleLabel.TabIndex = 5;
            this.PropertiesTitleLabel.Text = "Información del pago";
            this.PropertiesTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptionsFilterTreeView
            // 
            this.OptionsFilterTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionsFilterTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsFilterTreeView.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsFilterTreeView.ForeColor = System.Drawing.Color.Black;
            this.OptionsFilterTreeView.HideSelection = false;
            this.OptionsFilterTreeView.Indent = 5;
            this.OptionsFilterTreeView.Location = new System.Drawing.Point(3, 3);
            this.OptionsFilterTreeView.Name = "OptionsFilterTreeView";
            this.FormTableLayoutPanel.SetRowSpan(this.OptionsFilterTreeView, 2);
            this.OptionsFilterTreeView.ShowPlusMinus = false;
            this.OptionsFilterTreeView.Size = new System.Drawing.Size(150, 360);
            this.OptionsFilterTreeView.TabIndex = 1;
            this.OptionsFilterTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OptionsFilterTreeView_AfterSelect);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.FormTableLayoutPanel);
            this.Controls.Add(this.FormMenuStrip);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Control de pagos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
            this.PaymentContextMenuStrip.ResumeLayout(false);
            this.FormTableLayoutPanel.ResumeLayout(false);
            this.FormTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesDataGridView)).EndInit();
            this.ListTableLayoutPanel.ResumeLayout(false);
            this.ListTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator optionToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OptionCloseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PaymentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem PaymentRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator PaymentToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem PaymentShowDetailsToolStripMenuItem;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.TableLayoutPanel FormTableLayoutPanel;
        private System.Windows.Forms.Label ListTitleLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView PropertiesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn1;
        private System.Windows.Forms.TableLayoutPanel ListTableLayoutPanel;
        private System.Windows.Forms.DataGridView ListDataGridView;
        private System.Windows.Forms.Label ListCountLabel;
        private System.Windows.Forms.Label PropertiesTitleLabel;
        private System.Windows.Forms.TreeView OptionsFilterTreeView;
    }
}