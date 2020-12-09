namespace FeriaVirtual.View.Desktop.Forms.Consultor {
    partial class ConsultorMainForm {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultorMainForm));
            this.FormStatusStrip = new System.Windows.Forms.StatusStrip();
            this.FormStatusActiveUserToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.FormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MenuTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormTitleLabel = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.RefreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsExternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsInternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormStatusCompanyToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.InternalCustomerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InternalCustomerOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.ExternalCustomerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ExternalCustomerOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.InternalCustomerTitleLabel = new System.Windows.Forms.Label();
            this.ExternalCustomerTitleLabel = new System.Windows.Forms.Label();
            this.OrderTypeTitleLabel = new System.Windows.Forms.Label();
            this.FormStatusStrip.SuspendLayout();
            this.FormPanel.SuspendLayout();
            this.FormTableLayoutPanel.SuspendLayout();
            this.MenuTableLayoutPanel.SuspendLayout();
            this.FormMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InternalCustomerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InternalCustomerOrderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExternalCustomerChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExternalCustomerOrderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormStatusStrip
            // 
            this.FormStatusStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormStatusActiveUserToolStripStatusLabel,
            this.FormStatusCompanyToolStripStatusLabel1});
            this.FormStatusStrip.Location = new System.Drawing.Point(0, 424);
            this.FormStatusStrip.Name = "FormStatusStrip";
            this.FormStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.FormStatusStrip.Size = new System.Drawing.Size(1084, 22);
            this.FormStatusStrip.TabIndex = 3;
            this.FormStatusStrip.Text = "statusStrip1";
            // 
            // FormStatusActiveUserToolStripStatusLabel
            // 
            this.FormStatusActiveUserToolStripStatusLabel.Name = "FormStatusActiveUserToolStripStatusLabel";
            this.FormStatusActiveUserToolStripStatusLabel.Size = new System.Drawing.Size(949, 17);
            this.FormStatusActiveUserToolStripStatusLabel.Spring = true;
            this.FormStatusActiveUserToolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // FormPanel
            // 
            this.FormPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FormPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.FormPanel.Controls.Add(this.FormTableLayoutPanel);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormPanel.Location = new System.Drawing.Point(0, 0);
            this.FormPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(1084, 100);
            this.FormPanel.TabIndex = 5;
            // 
            // FormTableLayoutPanel
            // 
            this.FormTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.FormTableLayoutPanel.ColumnCount = 2;
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.FormTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.FormTableLayoutPanel.Controls.Add(this.FormPictureBox, 0, 0);
            this.FormTableLayoutPanel.Controls.Add(this.MenuTableLayoutPanel, 1, 0);
            this.FormTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.FormTableLayoutPanel.Name = "FormTableLayoutPanel";
            this.FormTableLayoutPanel.RowCount = 1;
            this.FormTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormTableLayoutPanel.Size = new System.Drawing.Size(1084, 100);
            this.FormTableLayoutPanel.TabIndex = 0;
            // 
            // MenuTableLayoutPanel
            // 
            this.MenuTableLayoutPanel.ColumnCount = 1;
            this.MenuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTableLayoutPanel.Controls.Add(this.FormMenuStrip, 1, 1);
            this.MenuTableLayoutPanel.Controls.Add(this.FormTitleLabel, 0, 2);
            this.MenuTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTableLayoutPanel.Location = new System.Drawing.Point(165, 3);
            this.MenuTableLayoutPanel.Name = "MenuTableLayoutPanel";
            this.MenuTableLayoutPanel.RowCount = 3;
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.MenuTableLayoutPanel.Size = new System.Drawing.Size(916, 94);
            this.MenuTableLayoutPanel.TabIndex = 7;
            // 
            // FormMenuStrip
            // 
            this.FormMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.FormMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FormMenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormMenuStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ReportsToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 32);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.FormMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.FormMenuStrip.Size = new System.Drawing.Size(916, 28);
            this.FormMenuStrip.TabIndex = 9;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripMenuItem1,
            this.toolStripSeparator1,
            this.CloseToolStripMenuItem});
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.FileToolStripMenuItem.Text = "&Archivo";
            // 
            // ReportsToolStripMenuItem
            // 
            this.ReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportsExternalSalesToolStripMenuItem,
            this.ReportsInternalSalesToolStripMenuItem});
            this.ReportsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
            this.ReportsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.ReportsToolStripMenuItem.Text = "&Informes";
            // 
            // FormTitleLabel
            // 
            this.FormTitleLabel.AutoSize = true;
            this.FormTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTitleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormTitleLabel.ForeColor = System.Drawing.Color.White;
            this.FormTitleLabel.Location = new System.Drawing.Point(3, 60);
            this.FormTitleLabel.Name = "FormTitleLabel";
            this.FormTitleLabel.Size = new System.Drawing.Size(910, 34);
            this.FormTitleLabel.TabIndex = 10;
            this.FormTitleLabel.Text = "Zona de usuario consultor";
            this.FormTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.FormPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.mg_logo;
            this.FormPictureBox.Location = new System.Drawing.Point(3, 3);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(156, 94);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 6;
            this.FormPictureBox.TabStop = false;
            // 
            // RefreshToolStripMenuItem1
            // 
            this.RefreshToolStripMenuItem1.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_refresh1;
            this.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1";
            this.RefreshToolStripMenuItem1.Size = new System.Drawing.Size(202, 26);
            this.RefreshToolStripMenuItem1.Text = "Actualizar resumen";
            this.RefreshToolStripMenuItem1.Click += new System.EventHandler(this.RefreshToolStripMenuItem1_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_exit;
            this.CloseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.CloseToolStripMenuItem.Text = "&Cerrar sesión";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // ReportsExternalSalesToolStripMenuItem
            // 
            this.ReportsExternalSalesToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_externalReport;
            this.ReportsExternalSalesToolStripMenuItem.Name = "ReportsExternalSalesToolStripMenuItem";
            this.ReportsExternalSalesToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.ReportsExternalSalesToolStripMenuItem.Text = "Informe de ventas &externas";
            this.ReportsExternalSalesToolStripMenuItem.Click += new System.EventHandler(this.ReportsExternalSalesToolStripMenuItem_Click);
            // 
            // ReportsInternalSalesToolStripMenuItem
            // 
            this.ReportsInternalSalesToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_internalReport;
            this.ReportsInternalSalesToolStripMenuItem.Name = "ReportsInternalSalesToolStripMenuItem";
            this.ReportsInternalSalesToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.ReportsInternalSalesToolStripMenuItem.Text = "Informe de ventas &internas";
            this.ReportsInternalSalesToolStripMenuItem.Click += new System.EventHandler(this.ReportsInternalSalesToolStripMenuItem_Click);
            // 
            // FormStatusCompanyToolStripStatusLabel1
            // 
            this.FormStatusCompanyToolStripStatusLabel1.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.maipogrande_logo1;
            this.FormStatusCompanyToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FormStatusCompanyToolStripStatusLabel1.Name = "FormStatusCompanyToolStripStatusLabel1";
            this.FormStatusCompanyToolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.FormStatusCompanyToolStripStatusLabel1.Text = "Maipo Grande";
            // 
            // InternalCustomerChart
            // 
            this.InternalCustomerChart.BackColor = System.Drawing.Color.LightGray;
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.InternalCustomerChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.LightGray;
            legend1.Name = "Legend1";
            this.InternalCustomerChart.Legends.Add(legend1);
            this.InternalCustomerChart.Location = new System.Drawing.Point(825, 200);
            this.InternalCustomerChart.Name = "InternalCustomerChart";
            this.InternalCustomerChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.InternalCustomerChart.Series.Add(series1);
            this.InternalCustomerChart.Size = new System.Drawing.Size(250, 200);
            this.InternalCustomerChart.TabIndex = 18;
            this.InternalCustomerChart.Text = "chart1";
            // 
            // InternalCustomerOrderDataGridView
            // 
            this.InternalCustomerOrderDataGridView.AllowUserToAddRows = false;
            this.InternalCustomerOrderDataGridView.AllowUserToDeleteRows = false;
            this.InternalCustomerOrderDataGridView.AllowUserToResizeColumns = false;
            this.InternalCustomerOrderDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.InternalCustomerOrderDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.InternalCustomerOrderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.InternalCustomerOrderDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.InternalCustomerOrderDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InternalCustomerOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InternalCustomerOrderDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InternalCustomerOrderDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.InternalCustomerOrderDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.InternalCustomerOrderDataGridView.Location = new System.Drawing.Point(575, 200);
            this.InternalCustomerOrderDataGridView.MultiSelect = false;
            this.InternalCustomerOrderDataGridView.Name = "InternalCustomerOrderDataGridView";
            this.InternalCustomerOrderDataGridView.ReadOnly = true;
            this.InternalCustomerOrderDataGridView.RowHeadersVisible = false;
            this.InternalCustomerOrderDataGridView.RowTemplate.Height = 23;
            this.InternalCustomerOrderDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.InternalCustomerOrderDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InternalCustomerOrderDataGridView.ShowCellErrors = false;
            this.InternalCustomerOrderDataGridView.ShowCellToolTips = false;
            this.InternalCustomerOrderDataGridView.ShowEditingIcon = false;
            this.InternalCustomerOrderDataGridView.ShowRowErrors = false;
            this.InternalCustomerOrderDataGridView.Size = new System.Drawing.Size(225, 200);
            this.InternalCustomerOrderDataGridView.StandardTab = true;
            this.InternalCustomerOrderDataGridView.TabIndex = 17;
            // 
            // ExternalCustomerChart
            // 
            this.ExternalCustomerChart.BackColor = System.Drawing.Color.LightGray;
            this.ExternalCustomerChart.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.BackColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "ChartArea1";
            this.ExternalCustomerChart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.LightGray;
            legend2.Name = "Legend1";
            this.ExternalCustomerChart.Legends.Add(legend2);
            this.ExternalCustomerChart.Location = new System.Drawing.Point(250, 200);
            this.ExternalCustomerChart.Name = "ExternalCustomerChart";
            this.ExternalCustomerChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.ExternalCustomerChart.Series.Add(series2);
            this.ExternalCustomerChart.Size = new System.Drawing.Size(250, 200);
            this.ExternalCustomerChart.TabIndex = 16;
            this.ExternalCustomerChart.Text = "chart1";
            // 
            // ExternalCustomerOrderDataGridView
            // 
            this.ExternalCustomerOrderDataGridView.AllowUserToAddRows = false;
            this.ExternalCustomerOrderDataGridView.AllowUserToDeleteRows = false;
            this.ExternalCustomerOrderDataGridView.AllowUserToResizeColumns = false;
            this.ExternalCustomerOrderDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.ExternalCustomerOrderDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ExternalCustomerOrderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ExternalCustomerOrderDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.ExternalCustomerOrderDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExternalCustomerOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExternalCustomerOrderDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExternalCustomerOrderDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExternalCustomerOrderDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.ExternalCustomerOrderDataGridView.Location = new System.Drawing.Point(25, 200);
            this.ExternalCustomerOrderDataGridView.MultiSelect = false;
            this.ExternalCustomerOrderDataGridView.Name = "ExternalCustomerOrderDataGridView";
            this.ExternalCustomerOrderDataGridView.ReadOnly = true;
            this.ExternalCustomerOrderDataGridView.RowHeadersVisible = false;
            this.ExternalCustomerOrderDataGridView.RowTemplate.Height = 23;
            this.ExternalCustomerOrderDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ExternalCustomerOrderDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExternalCustomerOrderDataGridView.ShowCellErrors = false;
            this.ExternalCustomerOrderDataGridView.ShowCellToolTips = false;
            this.ExternalCustomerOrderDataGridView.ShowEditingIcon = false;
            this.ExternalCustomerOrderDataGridView.ShowRowErrors = false;
            this.ExternalCustomerOrderDataGridView.Size = new System.Drawing.Size(200, 200);
            this.ExternalCustomerOrderDataGridView.StandardTab = true;
            this.ExternalCustomerOrderDataGridView.TabIndex = 15;
            // 
            // InternalCustomerTitleLabel
            // 
            this.InternalCustomerTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternalCustomerTitleLabel.Location = new System.Drawing.Point(575, 175);
            this.InternalCustomerTitleLabel.Name = "InternalCustomerTitleLabel";
            this.InternalCustomerTitleLabel.Size = new System.Drawing.Size(400, 23);
            this.InternalCustomerTitleLabel.TabIndex = 20;
            this.InternalCustomerTitleLabel.Text = "Clientes internos";
            this.InternalCustomerTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExternalCustomerTitleLabel
            // 
            this.ExternalCustomerTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExternalCustomerTitleLabel.Location = new System.Drawing.Point(25, 175);
            this.ExternalCustomerTitleLabel.Name = "ExternalCustomerTitleLabel";
            this.ExternalCustomerTitleLabel.Size = new System.Drawing.Size(400, 23);
            this.ExternalCustomerTitleLabel.TabIndex = 19;
            this.ExternalCustomerTitleLabel.Text = "Clientes externos";
            this.ExternalCustomerTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OrderTypeTitleLabel
            // 
            this.OrderTypeTitleLabel.AutoSize = true;
            this.OrderTypeTitleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderTypeTitleLabel.Location = new System.Drawing.Point(375, 125);
            this.OrderTypeTitleLabel.Name = "OrderTypeTitleLabel";
            this.OrderTypeTitleLabel.Size = new System.Drawing.Size(312, 23);
            this.OrderTypeTitleLabel.TabIndex = 21;
            this.OrderTypeTitleLabel.Text = "Ordenes de compra procesadas";
            // 
            // ConsultorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1084, 446);
            this.Controls.Add(this.OrderTypeTitleLabel);
            this.Controls.Add(this.InternalCustomerTitleLabel);
            this.Controls.Add(this.ExternalCustomerTitleLabel);
            this.Controls.Add(this.InternalCustomerChart);
            this.Controls.Add(this.InternalCustomerOrderDataGridView);
            this.Controls.Add(this.ExternalCustomerChart);
            this.Controls.Add(this.ExternalCustomerOrderDataGridView);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.FormStatusStrip);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(10, 10);
            this.MinimumSize = new System.Drawing.Size(628, 283);
            this.Name = "ConsultorMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Feria Virtual - Consultor.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsultorMainForm_FormClosing);
            this.Load += new System.EventHandler(this.ConsultorMainForm_Load);
            this.FormStatusStrip.ResumeLayout(false);
            this.FormStatusStrip.PerformLayout();
            this.FormPanel.ResumeLayout(false);
            this.FormTableLayoutPanel.ResumeLayout(false);
            this.MenuTableLayoutPanel.ResumeLayout(false);
            this.MenuTableLayoutPanel.PerformLayout();
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InternalCustomerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InternalCustomerOrderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExternalCustomerChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExternalCustomerOrderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip FormStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel FormStatusActiveUserToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel FormStatusCompanyToolStripStatusLabel1;
        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.TableLayoutPanel FormTableLayoutPanel;
        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.TableLayoutPanel MenuTableLayoutPanel;
        private System.Windows.Forms.MenuStrip FormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsExternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsInternalSalesToolStripMenuItem;
        private System.Windows.Forms.Label FormTitleLabel;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataVisualization.Charting.Chart InternalCustomerChart;
        private System.Windows.Forms.DataGridView InternalCustomerOrderDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart ExternalCustomerChart;
        private System.Windows.Forms.DataGridView ExternalCustomerOrderDataGridView;
        private System.Windows.Forms.Label InternalCustomerTitleLabel;
        private System.Windows.Forms.Label ExternalCustomerTitleLabel;
        private System.Windows.Forms.Label OrderTypeTitleLabel;
    }
}