namespace FeriaVirtual.View.Desktop.Forms.UtilForms {
    partial class SearchProductForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchProductForm));
            this.SearchCancelButton = new System.Windows.Forms.Button();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.ListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ListFilterButton = new System.Windows.Forms.Button();
            this.ListFilterLabel = new System.Windows.Forms.Label();
            this.ListCountLabel = new System.Windows.Forms.Label();
            this.ListTitleLabel = new System.Windows.Forms.Label();
            this.ListFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ListDataGridView = new System.Windows.Forms.DataGridView();
            this.SearchAceptButton = new System.Windows.Forms.Button();
            this.ListTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchCancelButton
            // 
            this.SearchCancelButton.AutoSize = true;
            this.SearchCancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SearchCancelButton.ForeColor = System.Drawing.Color.Black;
            this.SearchCancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchCancelButton.ImageKey = "button-cancel.png";
            this.SearchCancelButton.ImageList = this.FormImageList;
            this.SearchCancelButton.Location = new System.Drawing.Point(450, 325);
            this.SearchCancelButton.Name = "SearchCancelButton";
            this.SearchCancelButton.Size = new System.Drawing.Size(98, 27);
            this.SearchCancelButton.TabIndex = 10;
            this.SearchCancelButton.Text = "Cancelar";
            this.SearchCancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchCancelButton.UseVisualStyleBackColor = true;
            this.SearchCancelButton.Click += new System.EventHandler(this.SearchCancelButton_Click);
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-find.png");
            this.FormImageList.Images.SetKeyName(1, "button-acept.png");
            this.FormImageList.Images.SetKeyName(2, "button-cancel.png");
            // 
            // ListTableLayoutPanel
            // 
            this.ListTableLayoutPanel.ColumnCount = 3;
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterButton, 2, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterLabel, 0, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListCountLabel, 0, 3);
            this.ListTableLayoutPanel.Controls.Add(this.ListTitleLabel, 0, 0);
            this.ListTableLayoutPanel.Controls.Add(this.ListFilterComboBox, 1, 1);
            this.ListTableLayoutPanel.Controls.Add(this.ListDataGridView, 0, 2);
            this.ListTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ListTableLayoutPanel.Name = "ListTableLayoutPanel";
            this.ListTableLayoutPanel.RowCount = 4;
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.ListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ListTableLayoutPanel.Size = new System.Drawing.Size(553, 352);
            this.ListTableLayoutPanel.TabIndex = 8;
            // 
            // ListFilterButton
            // 
            this.ListFilterButton.AutoSize = true;
            this.ListFilterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ListFilterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListFilterButton.ForeColor = System.Drawing.Color.Black;
            this.ListFilterButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListFilterButton.ImageKey = "button-find.png";
            this.ListFilterButton.ImageList = this.FormImageList;
            this.ListFilterButton.Location = new System.Drawing.Point(444, 38);
            this.ListFilterButton.Name = "ListFilterButton";
            this.ListFilterButton.Size = new System.Drawing.Size(106, 27);
            this.ListFilterButton.TabIndex = 7;
            this.ListFilterButton.Text = "&Buscar";
            this.ListFilterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ListFilterButton.UseVisualStyleBackColor = true;
            this.ListFilterButton.Click += new System.EventHandler(this.ListFilterButton_Click);
            // 
            // ListFilterLabel
            // 
            this.ListFilterLabel.AutoSize = true;
            this.ListFilterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFilterLabel.ForeColor = System.Drawing.Color.Black;
            this.ListFilterLabel.Location = new System.Drawing.Point(3, 35);
            this.ListFilterLabel.Name = "ListFilterLabel";
            this.ListFilterLabel.Size = new System.Drawing.Size(104, 35);
            this.ListFilterLabel.TabIndex = 4;
            this.ListFilterLabel.Text = "Filtro: ";
            this.ListFilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ListCountLabel
            // 
            this.ListCountLabel.AutoSize = true;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListCountLabel, 3);
            this.ListCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListCountLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListCountLabel.ForeColor = System.Drawing.Color.Black;
            this.ListCountLabel.Location = new System.Drawing.Point(3, 316);
            this.ListCountLabel.Name = "ListCountLabel";
            this.ListCountLabel.Size = new System.Drawing.Size(547, 36);
            this.ListCountLabel.TabIndex = 3;
            this.ListCountLabel.Text = "Clientes disponibles...";
            this.ListCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListTitleLabel
            // 
            this.ListTitleLabel.AutoSize = true;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListTitleLabel, 3);
            this.ListTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.ListTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.ListTitleLabel.Name = "ListTitleLabel";
            this.ListTitleLabel.Size = new System.Drawing.Size(547, 35);
            this.ListTitleLabel.TabIndex = 1;
            this.ListTitleLabel.Text = "Lista de clientes disponibles";
            this.ListTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ListFilterComboBox
            // 
            this.ListFilterComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListFilterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListFilterComboBox.FormattingEnabled = true;
            this.ListFilterComboBox.Location = new System.Drawing.Point(113, 38);
            this.ListFilterComboBox.MaxDropDownItems = 6;
            this.ListFilterComboBox.Name = "ListFilterComboBox";
            this.ListFilterComboBox.Size = new System.Drawing.Size(325, 25);
            this.ListFilterComboBox.TabIndex = 5;
            // 
            // ListDataGridView
            // 
            this.ListDataGridView.AllowUserToAddRows = false;
            this.ListDataGridView.AllowUserToDeleteRows = false;
            this.ListDataGridView.AllowUserToOrderColumns = true;
            this.ListDataGridView.AllowUserToResizeRows = false;
            this.ListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.ListDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListTableLayoutPanel.SetColumnSpan(this.ListDataGridView, 3);
            this.ListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ListDataGridView.Location = new System.Drawing.Point(3, 73);
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
            this.ListDataGridView.Size = new System.Drawing.Size(547, 240);
            this.ListDataGridView.StandardTab = true;
            this.ListDataGridView.TabIndex = 8;
            this.ListDataGridView.SelectionChanged += new System.EventHandler(this.ListDataGridView_SelectionChanged);
            this.ListDataGridView.DoubleClick += new System.EventHandler(this.ListDataGridView_DoubleClick);
            // 
            // SearchAceptButton
            // 
            this.SearchAceptButton.AutoSize = true;
            this.SearchAceptButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SearchAceptButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SearchAceptButton.ForeColor = System.Drawing.Color.Black;
            this.SearchAceptButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchAceptButton.ImageKey = "button-acept.png";
            this.SearchAceptButton.ImageList = this.FormImageList;
            this.SearchAceptButton.Location = new System.Drawing.Point(325, 325);
            this.SearchAceptButton.Name = "SearchAceptButton";
            this.SearchAceptButton.Size = new System.Drawing.Size(90, 27);
            this.SearchAceptButton.TabIndex = 9;
            this.SearchAceptButton.Text = "&Aceptar";
            this.SearchAceptButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchAceptButton.UseVisualStyleBackColor = true;
            this.SearchAceptButton.Click += new System.EventHandler(this.SearchAceptButton_Click);
            // 
            // SearchProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(553, 352);
            this.Controls.Add(this.SearchAceptButton);
            this.Controls.Add(this.SearchCancelButton);
            this.Controls.Add(this.ListTableLayoutPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchProductForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de productos";
            this.Load += new System.EventHandler(this.SearchProductForm_Load);
            this.ListTableLayoutPanel.ResumeLayout(false);
            this.ListTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchCancelButton;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.TableLayoutPanel ListTableLayoutPanel;
        private System.Windows.Forms.Button ListFilterButton;
        private System.Windows.Forms.Label ListFilterLabel;
        private System.Windows.Forms.Label ListCountLabel;
        private System.Windows.Forms.Label ListTitleLabel;
        private System.Windows.Forms.ComboBox ListFilterComboBox;
        private System.Windows.Forms.DataGridView ListDataGridView;
        private System.Windows.Forms.Button SearchAceptButton;
    }
}