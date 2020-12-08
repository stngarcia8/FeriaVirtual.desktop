namespace FeriaVirtual.View.Desktop.Forms.Reports {
    partial class ExternalSalesForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalSalesForm));
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.MonthRadioButton = new System.Windows.Forms.RadioButton();
            this.SemesterRadioButton = new System.Windows.Forms.RadioButton();
            this.SemesterComboBox = new System.Windows.Forms.ComboBox();
            this.DateRadioButton = new System.Windows.Forms.RadioButton();
            this.DateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.RangeRadioButton = new System.Windows.Forms.RadioButton();
            this.RangeFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.RangeToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SalesDataGridView = new System.Windows.Forms.DataGridView();
            this.YearRadioButton = new System.Windows.Forms.RadioButton();
            this.SalesTitleLabel = new System.Windows.Forms.Label();
            this.ResumeSalesDataGridView = new System.Windows.Forms.DataGridView();
            this.ResumeSalesLabel = new System.Windows.Forms.Label();
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionSendMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionCleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LossesDataGridView = new System.Windows.Forms.DataGridView();
            this.LossesLabel = new System.Windows.Forms.Label();
            this.ResumeLossesDataGridView = new System.Windows.Forms.DataGridView();
            this.ResumeLossesLabel = new System.Windows.Forms.Label();
            this.LossesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.FilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResumeSalesDataGridView)).BeginInit();
            this.FormMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LossesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResumeLossesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LossesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.FilterGroupBox.Controls.Add(this.YearRadioButton);
            this.FilterGroupBox.Controls.Add(this.RangeToDateTimePicker);
            this.FilterGroupBox.Controls.Add(this.RangeFromDateTimePicker);
            this.FilterGroupBox.Controls.Add(this.RangeRadioButton);
            this.FilterGroupBox.Controls.Add(this.DateDateTimePicker);
            this.FilterGroupBox.Controls.Add(this.DateRadioButton);
            this.FilterGroupBox.Controls.Add(this.SemesterComboBox);
            this.FilterGroupBox.Controls.Add(this.SemesterRadioButton);
            this.FilterGroupBox.Controls.Add(this.MonthRadioButton);
            this.FilterGroupBox.Controls.Add(this.MonthComboBox);
            this.FilterGroupBox.Controls.Add(this.YearComboBox);
            this.FilterGroupBox.Controls.Add(this.YearLabel);
            this.FilterGroupBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterGroupBox.ForeColor = System.Drawing.Color.White;
            this.FilterGroupBox.Location = new System.Drawing.Point(0, 25);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(950, 125);
            this.FilterGroupBox.TabIndex = 3;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filtros del reporte";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(25, 25);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(111, 17);
            this.YearLabel.TabIndex = 0;
            this.YearLabel.Text = "Año a procesar:";
            // 
            // YearComboBox
            // 
            this.YearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearComboBox.ForeColor = System.Drawing.Color.Black;
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022"});
            this.YearComboBox.Location = new System.Drawing.Point(150, 25);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(125, 25);
            this.YearComboBox.TabIndex = 1;
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.MonthComboBox.Location = new System.Drawing.Point(450, 25);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(150, 25);
            this.MonthComboBox.TabIndex = 4;
            // 
            // MonthRadioButton
            // 
            this.MonthRadioButton.AutoSize = true;
            this.MonthRadioButton.Location = new System.Drawing.Point(350, 25);
            this.MonthRadioButton.Name = "MonthRadioButton";
            this.MonthRadioButton.Size = new System.Drawing.Size(82, 21);
            this.MonthRadioButton.TabIndex = 3;
            this.MonthRadioButton.TabStop = true;
            this.MonthRadioButton.Text = "Mensual:";
            this.MonthRadioButton.UseVisualStyleBackColor = true;
            this.MonthRadioButton.CheckedChanged += new System.EventHandler(this.MonthRadioButton_CheckedChanged);
            // 
            // SemesterRadioButton
            // 
            this.SemesterRadioButton.AutoSize = true;
            this.SemesterRadioButton.Location = new System.Drawing.Point(350, 75);
            this.SemesterRadioButton.Name = "SemesterRadioButton";
            this.SemesterRadioButton.Size = new System.Drawing.Size(87, 21);
            this.SemesterRadioButton.TabIndex = 5;
            this.SemesterRadioButton.TabStop = true;
            this.SemesterRadioButton.Text = "Semestral";
            this.SemesterRadioButton.UseVisualStyleBackColor = true;
            this.SemesterRadioButton.CheckedChanged += new System.EventHandler(this.SemesterRadioButton_CheckedChanged);
            // 
            // SemesterComboBox
            // 
            this.SemesterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemesterComboBox.FormattingEnabled = true;
            this.SemesterComboBox.Items.AddRange(new object[] {
            "Primer semestre",
            "Segundo semestre"});
            this.SemesterComboBox.Location = new System.Drawing.Point(450, 75);
            this.SemesterComboBox.Name = "SemesterComboBox";
            this.SemesterComboBox.Size = new System.Drawing.Size(150, 25);
            this.SemesterComboBox.TabIndex = 6;
            // 
            // DateRadioButton
            // 
            this.DateRadioButton.AutoSize = true;
            this.DateRadioButton.Location = new System.Drawing.Point(725, 25);
            this.DateRadioButton.Name = "DateRadioButton";
            this.DateRadioButton.Size = new System.Drawing.Size(92, 21);
            this.DateRadioButton.TabIndex = 7;
            this.DateRadioButton.TabStop = true;
            this.DateRadioButton.Text = "Por fecha:";
            this.DateRadioButton.UseVisualStyleBackColor = true;
            this.DateRadioButton.CheckedChanged += new System.EventHandler(this.DateRadioButton_CheckedChanged);
            // 
            // DateDateTimePicker
            // 
            this.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateDateTimePicker.Location = new System.Drawing.Point(900, 25);
            this.DateDateTimePicker.Name = "DateDateTimePicker";
            this.DateDateTimePicker.Size = new System.Drawing.Size(125, 23);
            this.DateDateTimePicker.TabIndex = 8;
            // 
            // RangeRadioButton
            // 
            this.RangeRadioButton.AutoSize = true;
            this.RangeRadioButton.Location = new System.Drawing.Point(725, 75);
            this.RangeRadioButton.Name = "RangeRadioButton";
            this.RangeRadioButton.Size = new System.Drawing.Size(161, 21);
            this.RangeRadioButton.TabIndex = 9;
            this.RangeRadioButton.TabStop = true;
            this.RangeRadioButton.Text = "Por rango de fechas:";
            this.RangeRadioButton.UseVisualStyleBackColor = true;
            this.RangeRadioButton.CheckedChanged += new System.EventHandler(this.RangeRadioButton_CheckedChanged);
            // 
            // RangeFromDateTimePicker
            // 
            this.RangeFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RangeFromDateTimePicker.Location = new System.Drawing.Point(900, 75);
            this.RangeFromDateTimePicker.Name = "RangeFromDateTimePicker";
            this.RangeFromDateTimePicker.Size = new System.Drawing.Size(125, 23);
            this.RangeFromDateTimePicker.TabIndex = 10;
            this.RangeFromDateTimePicker.ValueChanged += new System.EventHandler(this.RangeFromDateTimePicker_ValueChanged);
            // 
            // RangeToDateTimePicker
            // 
            this.RangeToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RangeToDateTimePicker.Location = new System.Drawing.Point(1075, 75);
            this.RangeToDateTimePicker.Name = "RangeToDateTimePicker";
            this.RangeToDateTimePicker.Size = new System.Drawing.Size(125, 23);
            this.RangeToDateTimePicker.TabIndex = 11;
            // 
            // SalesDataGridView
            // 
            this.SalesDataGridView.AllowUserToAddRows = false;
            this.SalesDataGridView.AllowUserToDeleteRows = false;
            this.SalesDataGridView.AllowUserToResizeColumns = false;
            this.SalesDataGridView.AllowUserToResizeRows = false;
            this.SalesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SalesDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.SalesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SalesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SalesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.SalesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.SalesDataGridView.Location = new System.Drawing.Point(0, 275);
            this.SalesDataGridView.MultiSelect = false;
            this.SalesDataGridView.Name = "SalesDataGridView";
            this.SalesDataGridView.ReadOnly = true;
            this.SalesDataGridView.RowHeadersVisible = false;
            this.SalesDataGridView.RowTemplate.Height = 23;
            this.SalesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SalesDataGridView.ShowCellErrors = false;
            this.SalesDataGridView.ShowCellToolTips = false;
            this.SalesDataGridView.ShowEditingIcon = false;
            this.SalesDataGridView.ShowRowErrors = false;
            this.SalesDataGridView.Size = new System.Drawing.Size(650, 50);
            this.SalesDataGridView.StandardTab = true;
            this.SalesDataGridView.TabIndex = 4;
            // 
            // YearRadioButton
            // 
            this.YearRadioButton.AutoSize = true;
            this.YearRadioButton.Location = new System.Drawing.Point(25, 75);
            this.YearRadioButton.Name = "YearRadioButton";
            this.YearRadioButton.Size = new System.Drawing.Size(194, 21);
            this.YearRadioButton.TabIndex = 2;
            this.YearRadioButton.TabStop = true;
            this.YearRadioButton.Text = "Todo el año seleccionado";
            this.YearRadioButton.UseVisualStyleBackColor = true;
            this.YearRadioButton.CheckedChanged += new System.EventHandler(this.YearRadioButton_CheckedChanged);
            // 
            // SalesTitleLabel
            // 
            this.SalesTitleLabel.AutoSize = true;
            this.SalesTitleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesTitleLabel.Location = new System.Drawing.Point(0, 250);
            this.SalesTitleLabel.Name = "SalesTitleLabel";
            this.SalesTitleLabel.Size = new System.Drawing.Size(172, 23);
            this.SalesTitleLabel.TabIndex = 5;
            this.SalesTitleLabel.Text = "Detalle de ventas";
            // 
            // ResumeSalesDataGridView
            // 
            this.ResumeSalesDataGridView.AllowUserToAddRows = false;
            this.ResumeSalesDataGridView.AllowUserToDeleteRows = false;
            this.ResumeSalesDataGridView.AllowUserToResizeColumns = false;
            this.ResumeSalesDataGridView.AllowUserToResizeRows = false;
            this.ResumeSalesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResumeSalesDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.ResumeSalesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResumeSalesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ResumeSalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResumeSalesDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.ResumeSalesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.ResumeSalesDataGridView.Location = new System.Drawing.Point(0, 175);
            this.ResumeSalesDataGridView.MultiSelect = false;
            this.ResumeSalesDataGridView.Name = "ResumeSalesDataGridView";
            this.ResumeSalesDataGridView.ReadOnly = true;
            this.ResumeSalesDataGridView.RowHeadersVisible = false;
            this.ResumeSalesDataGridView.RowTemplate.Height = 23;
            this.ResumeSalesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResumeSalesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResumeSalesDataGridView.ShowCellErrors = false;
            this.ResumeSalesDataGridView.ShowCellToolTips = false;
            this.ResumeSalesDataGridView.ShowEditingIcon = false;
            this.ResumeSalesDataGridView.ShowRowErrors = false;
            this.ResumeSalesDataGridView.Size = new System.Drawing.Size(225, 50);
            this.ResumeSalesDataGridView.StandardTab = true;
            this.ResumeSalesDataGridView.TabIndex = 6;
            // 
            // ResumeSalesLabel
            // 
            this.ResumeSalesLabel.AutoSize = true;
            this.ResumeSalesLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeSalesLabel.Location = new System.Drawing.Point(0, 150);
            this.ResumeSalesLabel.Name = "ResumeSalesLabel";
            this.ResumeSalesLabel.Size = new System.Drawing.Size(189, 23);
            this.ResumeSalesLabel.TabIndex = 7;
            this.ResumeSalesLabel.Text = "Resumen de ventas";
            // 
            // FormMenuStrip
            // 
            this.FormMenuStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Size = new System.Drawing.Size(1325, 25);
            this.FormMenuStrip.TabIndex = 13;
            this.FormMenuStrip.Text = "menuStrip1";
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionExecuteToolStripMenuItem,
            this.OptionSendMailToolStripMenuItem,
            this.OptionToolStripSeparator1,
            this.OptionCleanToolStripMenuItem,
            this.OptionToolStripSeparator2,
            this.OptionCloseToolStripMenuItem});
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.OptionToolStripMenuItem.Text = "Opciones";
            // 
            // OptionExecuteToolStripMenuItem
            // 
            this.OptionExecuteToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_find;
            this.OptionExecuteToolStripMenuItem.Name = "OptionExecuteToolStripMenuItem";
            this.OptionExecuteToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+F5";
            this.OptionExecuteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.OptionExecuteToolStripMenuItem.Size = new System.Drawing.Size(356, 22);
            this.OptionExecuteToolStripMenuItem.Text = "Ejecutar consulta";
            this.OptionExecuteToolStripMenuItem.Click += new System.EventHandler(this.OptionExecuteToolStripMenuItem_Click);
            // 
            // OptionSendMailToolStripMenuItem
            // 
            this.OptionSendMailToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_emailNotify;
            this.OptionSendMailToolStripMenuItem.Name = "OptionSendMailToolStripMenuItem";
            this.OptionSendMailToolStripMenuItem.Size = new System.Drawing.Size(356, 22);
            this.OptionSendMailToolStripMenuItem.Text = "Enviar informe por email";
            this.OptionSendMailToolStripMenuItem.Click += new System.EventHandler(this.OptionSendMailToolStripMenuItem_Click);
            // 
            // OptionToolStripSeparator1
            // 
            this.OptionToolStripSeparator1.Name = "OptionToolStripSeparator1";
            this.OptionToolStripSeparator1.Size = new System.Drawing.Size(353, 6);
            // 
            // OptionCleanToolStripMenuItem
            // 
            this.OptionCleanToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_new1;
            this.OptionCleanToolStripMenuItem.Name = "OptionCleanToolStripMenuItem";
            this.OptionCleanToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+MAYUSC+F5";
            this.OptionCleanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F5)));
            this.OptionCleanToolStripMenuItem.Size = new System.Drawing.Size(356, 22);
            this.OptionCleanToolStripMenuItem.Text = "Preparar nueva consulta";
            this.OptionCleanToolStripMenuItem.Click += new System.EventHandler(this.OptionCleanToolStripMenuItem_Click);
            // 
            // OptionToolStripSeparator2
            // 
            this.OptionToolStripSeparator2.Name = "OptionToolStripSeparator2";
            this.OptionToolStripSeparator2.Size = new System.Drawing.Size(353, 6);
            // 
            // OptionCloseToolStripMenuItem
            // 
            this.OptionCloseToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_exit;
            this.OptionCloseToolStripMenuItem.Name = "OptionCloseToolStripMenuItem";
            this.OptionCloseToolStripMenuItem.Size = new System.Drawing.Size(356, 22);
            this.OptionCloseToolStripMenuItem.Text = "Cerrar reportes";
            this.OptionCloseToolStripMenuItem.Click += new System.EventHandler(this.OptionCloseToolStripMenuItem_Click);
            // 
            // LossesDataGridView
            // 
            this.LossesDataGridView.AllowUserToAddRows = false;
            this.LossesDataGridView.AllowUserToDeleteRows = false;
            this.LossesDataGridView.AllowUserToResizeColumns = false;
            this.LossesDataGridView.AllowUserToResizeRows = false;
            this.LossesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LossesDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.LossesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LossesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.LossesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LossesDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.LossesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.LossesDataGridView.Location = new System.Drawing.Point(675, 275);
            this.LossesDataGridView.MultiSelect = false;
            this.LossesDataGridView.Name = "LossesDataGridView";
            this.LossesDataGridView.ReadOnly = true;
            this.LossesDataGridView.RowHeadersVisible = false;
            this.LossesDataGridView.RowTemplate.Height = 23;
            this.LossesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LossesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LossesDataGridView.ShowCellErrors = false;
            this.LossesDataGridView.ShowCellToolTips = false;
            this.LossesDataGridView.ShowEditingIcon = false;
            this.LossesDataGridView.ShowRowErrors = false;
            this.LossesDataGridView.Size = new System.Drawing.Size(650, 50);
            this.LossesDataGridView.StandardTab = true;
            this.LossesDataGridView.TabIndex = 14;
            // 
            // LossesLabel
            // 
            this.LossesLabel.AutoSize = true;
            this.LossesLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LossesLabel.Location = new System.Drawing.Point(675, 250);
            this.LossesLabel.Name = "LossesLabel";
            this.LossesLabel.Size = new System.Drawing.Size(314, 23);
            this.LossesLabel.TabIndex = 15;
            this.LossesLabel.Text = "Detalle de mermas de productos";
            // 
            // ResumeLossesDataGridView
            // 
            this.ResumeLossesDataGridView.AllowUserToAddRows = false;
            this.ResumeLossesDataGridView.AllowUserToDeleteRows = false;
            this.ResumeLossesDataGridView.AllowUserToResizeColumns = false;
            this.ResumeLossesDataGridView.AllowUserToResizeRows = false;
            this.ResumeLossesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResumeLossesDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.ResumeLossesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResumeLossesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ResumeLossesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResumeLossesDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.ResumeLossesDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.ResumeLossesDataGridView.Location = new System.Drawing.Point(675, 175);
            this.ResumeLossesDataGridView.MultiSelect = false;
            this.ResumeLossesDataGridView.Name = "ResumeLossesDataGridView";
            this.ResumeLossesDataGridView.ReadOnly = true;
            this.ResumeLossesDataGridView.RowHeadersVisible = false;
            this.ResumeLossesDataGridView.RowTemplate.Height = 23;
            this.ResumeLossesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResumeLossesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResumeLossesDataGridView.ShowCellErrors = false;
            this.ResumeLossesDataGridView.ShowCellToolTips = false;
            this.ResumeLossesDataGridView.ShowEditingIcon = false;
            this.ResumeLossesDataGridView.ShowRowErrors = false;
            this.ResumeLossesDataGridView.Size = new System.Drawing.Size(425, 50);
            this.ResumeLossesDataGridView.StandardTab = true;
            this.ResumeLossesDataGridView.TabIndex = 16;
            // 
            // ResumeLossesLabel
            // 
            this.ResumeLossesLabel.AutoSize = true;
            this.ResumeLossesLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLossesLabel.Location = new System.Drawing.Point(675, 150);
            this.ResumeLossesLabel.Name = "ResumeLossesLabel";
            this.ResumeLossesLabel.Size = new System.Drawing.Size(203, 23);
            this.ResumeLossesLabel.TabIndex = 17;
            this.ResumeLossesLabel.Text = "Resumen de mermas";
            // 
            // LossesChart
            // 
            this.LossesChart.BackColor = System.Drawing.Color.LightGray;
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.LossesChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.LightGray;
            legend1.Name = "Legend1";
            this.LossesChart.Legends.Add(legend1);
            this.LossesChart.Location = new System.Drawing.Point(675, 375);
            this.LossesChart.Name = "LossesChart";
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.LossesChart.Series.Add(series1);
            this.LossesChart.Size = new System.Drawing.Size(650, 150);
            this.LossesChart.TabIndex = 18;
            this.LossesChart.Text = "chart1";
            // 
            // ExternalSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.ControlBox = false;
            this.Controls.Add(this.LossesChart);
            this.Controls.Add(this.ResumeLossesLabel);
            this.Controls.Add(this.ResumeLossesDataGridView);
            this.Controls.Add(this.LossesLabel);
            this.Controls.Add(this.LossesDataGridView);
            this.Controls.Add(this.FormMenuStrip);
            this.Controls.Add(this.ResumeSalesLabel);
            this.Controls.Add(this.ResumeSalesDataGridView);
            this.Controls.Add(this.SalesTitleLabel);
            this.Controls.Add(this.SalesDataGridView);
            this.Controls.Add(this.FilterGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExternalSalesForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe de ventas externas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExternalSalesForm_Load);
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResumeSalesDataGridView)).EndInit();
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LossesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResumeLossesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LossesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.DateTimePicker RangeToDateTimePicker;
        private System.Windows.Forms.DateTimePicker RangeFromDateTimePicker;
        private System.Windows.Forms.RadioButton RangeRadioButton;
        private System.Windows.Forms.DateTimePicker DateDateTimePicker;
        private System.Windows.Forms.RadioButton DateRadioButton;
        private System.Windows.Forms.ComboBox SemesterComboBox;
        private System.Windows.Forms.RadioButton SemesterRadioButton;
        private System.Windows.Forms.RadioButton MonthRadioButton;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.DataGridView SalesDataGridView;
        private System.Windows.Forms.RadioButton YearRadioButton;
        private System.Windows.Forms.Label SalesTitleLabel;
        private System.Windows.Forms.DataGridView ResumeSalesDataGridView;
        private System.Windows.Forms.Label ResumeSalesLabel;
        private System.Windows.Forms.MenuStrip FormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionExecuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionSendMailToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator OptionToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OptionCleanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator OptionToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OptionCloseToolStripMenuItem;
        private System.Windows.Forms.DataGridView LossesDataGridView;
        private System.Windows.Forms.Label LossesLabel;
        private System.Windows.Forms.DataGridView ResumeLossesDataGridView;
        private System.Windows.Forms.Label ResumeLossesLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart LossesChart;
    }
}