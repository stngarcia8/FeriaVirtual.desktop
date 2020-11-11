namespace FeriaVirtual.View.Desktop.Forms.Administrator {
    partial class AdministratorMainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministratorMainForm));
            this.FormStatusStrip = new System.Windows.Forms.StatusStrip();
            this.FormStatusActiveUserToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormStatusCompanyToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.FormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.MenuTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceCarrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MaintenanceUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessContractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BusinessExternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessInternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BusinessPaymentsReceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessResultNotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsExternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsInternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormTitleLabel = new System.Windows.Forms.Label();
            this.FormStatusStrip.SuspendLayout();
            this.FormPanel.SuspendLayout();
            this.FormTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.MenuTableLayoutPanel.SuspendLayout();
            this.FormMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormStatusStrip
            // 
            this.FormStatusStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormStatusActiveUserToolStripStatusLabel,
            this.FormStatusCompanyToolStripStatusLabel1});
            this.FormStatusStrip.Location = new System.Drawing.Point(0, 261);
            this.FormStatusStrip.Name = "FormStatusStrip";
            this.FormStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.FormStatusStrip.Size = new System.Drawing.Size(652, 22);
            this.FormStatusStrip.TabIndex = 2;
            this.FormStatusStrip.Text = "statusStrip1";
            // 
            // FormStatusActiveUserToolStripStatusLabel
            // 
            this.FormStatusActiveUserToolStripStatusLabel.Name = "FormStatusActiveUserToolStripStatusLabel";
            this.FormStatusActiveUserToolStripStatusLabel.Size = new System.Drawing.Size(517, 17);
            this.FormStatusActiveUserToolStripStatusLabel.Spring = true;
            this.FormStatusActiveUserToolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // FormStatusCompanyToolStripStatusLabel1
            // 
            this.FormStatusCompanyToolStripStatusLabel1.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.mg_logo;
            this.FormStatusCompanyToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FormStatusCompanyToolStripStatusLabel1.Name = "FormStatusCompanyToolStripStatusLabel1";
            this.FormStatusCompanyToolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.FormStatusCompanyToolStripStatusLabel1.Text = "Maipo Grande";
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
            this.FormPanel.Size = new System.Drawing.Size(652, 100);
            this.FormPanel.TabIndex = 4;
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
            this.FormTableLayoutPanel.Size = new System.Drawing.Size(652, 100);
            this.FormTableLayoutPanel.TabIndex = 0;
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.FormPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.mg_logo;
            this.FormPictureBox.Location = new System.Drawing.Point(3, 3);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(91, 94);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 6;
            this.FormPictureBox.TabStop = false;
            // 
            // MenuTableLayoutPanel
            // 
            this.MenuTableLayoutPanel.ColumnCount = 1;
            this.MenuTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTableLayoutPanel.Controls.Add(this.FormMenuStrip, 1, 1);
            this.MenuTableLayoutPanel.Controls.Add(this.FormTitleLabel, 0, 2);
            this.MenuTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTableLayoutPanel.Location = new System.Drawing.Point(100, 3);
            this.MenuTableLayoutPanel.Name = "MenuTableLayoutPanel";
            this.MenuTableLayoutPanel.RowCount = 3;
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MenuTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.MenuTableLayoutPanel.Size = new System.Drawing.Size(549, 94);
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
            this.MaintenanceToolStripMenuItem,
            this.BusinessToolStripMenuItem,
            this.ReportsToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 32);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.FormMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.FormMenuStrip.Size = new System.Drawing.Size(549, 28);
            this.FormMenuStrip.TabIndex = 9;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseToolStripMenuItem});
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.FileToolStripMenuItem.Text = "&Archivo";
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_exit;
            this.CloseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseToolStripMenuItem.RightToLeftAutoMirrorImage = true;
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.CloseToolStripMenuItem.Text = "&Cerrar sesión";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // MaintenanceToolStripMenuItem
            // 
            this.MaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaintenanceCarrierToolStripMenuItem,
            this.MaintenanceToolStripSeparator,
            this.MaintenanceUserToolStripMenuItem});
            this.MaintenanceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem";
            this.MaintenanceToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.MaintenanceToolStripMenuItem.Text = "&Mantenimiento";
            // 
            // MaintenanceCarrierToolStripMenuItem
            // 
            this.MaintenanceCarrierToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_customer;
            this.MaintenanceCarrierToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MaintenanceCarrierToolStripMenuItem.Name = "MaintenanceCarrierToolStripMenuItem";
            this.MaintenanceCarrierToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.MaintenanceCarrierToolStripMenuItem.Text = "Datos de &clientes";
            this.MaintenanceCarrierToolStripMenuItem.Click += new System.EventHandler(this.MaintenanceCarrierToolStripMenuItem_Click);
            // 
            // MaintenanceToolStripSeparator
            // 
            this.MaintenanceToolStripSeparator.Name = "MaintenanceToolStripSeparator";
            this.MaintenanceToolStripSeparator.Size = new System.Drawing.Size(204, 6);
            // 
            // MaintenanceUserToolStripMenuItem
            // 
            this.MaintenanceUserToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.login;
            this.MaintenanceUserToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MaintenanceUserToolStripMenuItem.Name = "MaintenanceUserToolStripMenuItem";
            this.MaintenanceUserToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.MaintenanceUserToolStripMenuItem.Text = "Usuarios del sistema";
            this.MaintenanceUserToolStripMenuItem.Click += new System.EventHandler(this.MaintenanceUserToolStripMenuItem_Click);
            // 
            // BusinessToolStripMenuItem
            // 
            this.BusinessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BusinessContractToolStripMenuItem,
            this.BusinessToolStripSeparator1,
            this.BusinessExternalSalesToolStripMenuItem,
            this.BusinessInternalSalesToolStripMenuItem,
            this.BusinessToolStripSeparator2,
            this.BusinessPaymentsReceptionToolStripMenuItem,
            this.BusinessResultNotifyToolStripMenuItem});
            this.BusinessToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.BusinessToolStripMenuItem.Name = "BusinessToolStripMenuItem";
            this.BusinessToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.BusinessToolStripMenuItem.Text = "&Procesos de negocio";
            // 
            // BusinessContractToolStripMenuItem
            // 
            this.BusinessContractToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_contract;
            this.BusinessContractToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BusinessContractToolStripMenuItem.Name = "BusinessContractToolStripMenuItem";
            this.BusinessContractToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.BusinessContractToolStripMenuItem.Text = "&Control de contratos";
            this.BusinessContractToolStripMenuItem.Click += new System.EventHandler(this.BusinessContractToolStripMenuItem_Click);
            // 
            // BusinessToolStripSeparator1
            // 
            this.BusinessToolStripSeparator1.Name = "BusinessToolStripSeparator1";
            this.BusinessToolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // BusinessExternalSalesToolStripMenuItem
            // 
            this.BusinessExternalSalesToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_externalOrders;
            this.BusinessExternalSalesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BusinessExternalSalesToolStripMenuItem.Name = "BusinessExternalSalesToolStripMenuItem";
            this.BusinessExternalSalesToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.BusinessExternalSalesToolStripMenuItem.Text = "Proceso de ventas &externas";
            this.BusinessExternalSalesToolStripMenuItem.Click += new System.EventHandler(this.BusinessExternalSalesToolStripMenuItem_Click);
            // 
            // BusinessInternalSalesToolStripMenuItem
            // 
            this.BusinessInternalSalesToolStripMenuItem.Name = "BusinessInternalSalesToolStripMenuItem";
            this.BusinessInternalSalesToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.BusinessInternalSalesToolStripMenuItem.Text = "Procesos de ventas &internas";
            this.BusinessInternalSalesToolStripMenuItem.Click += new System.EventHandler(this.BusinessInternalSalesToolStripMenuItem_Click);
            // 
            // BusinessToolStripSeparator2
            // 
            this.BusinessToolStripSeparator2.Name = "BusinessToolStripSeparator2";
            this.BusinessToolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // BusinessPaymentsReceptionToolStripMenuItem
            // 
            this.BusinessPaymentsReceptionToolStripMenuItem.Name = "BusinessPaymentsReceptionToolStripMenuItem";
            this.BusinessPaymentsReceptionToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.BusinessPaymentsReceptionToolStripMenuItem.Text = "&Recepción de pagos";
            // 
            // BusinessResultNotifyToolStripMenuItem
            // 
            this.BusinessResultNotifyToolStripMenuItem.Name = "BusinessResultNotifyToolStripMenuItem";
            this.BusinessResultNotifyToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.BusinessResultNotifyToolStripMenuItem.Text = "&Notificación de resultados";
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
            // ReportsExternalSalesToolStripMenuItem
            // 
            this.ReportsExternalSalesToolStripMenuItem.Name = "ReportsExternalSalesToolStripMenuItem";
            this.ReportsExternalSalesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ReportsExternalSalesToolStripMenuItem.Text = "Informe de ventas &externas";
            // 
            // ReportsInternalSalesToolStripMenuItem
            // 
            this.ReportsInternalSalesToolStripMenuItem.Name = "ReportsInternalSalesToolStripMenuItem";
            this.ReportsInternalSalesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ReportsInternalSalesToolStripMenuItem.Text = "Informe de ventas &internas";
            // 
            // FormTitleLabel
            // 
            this.FormTitleLabel.AutoSize = true;
            this.FormTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTitleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormTitleLabel.ForeColor = System.Drawing.Color.White;
            this.FormTitleLabel.Location = new System.Drawing.Point(3, 60);
            this.FormTitleLabel.Name = "FormTitleLabel";
            this.FormTitleLabel.Size = new System.Drawing.Size(543, 34);
            this.FormTitleLabel.TabIndex = 10;
            this.FormTitleLabel.Text = "Zona de usuario Administrador";
            this.FormTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdministratorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(652, 283);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.FormStatusStrip);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(652, 283);
            this.Name = "AdministratorMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Feria Virtual - Administrador.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorMainForm_FormClosing);
            this.Load += new System.EventHandler(this.AdministratorMainForm_Load);
            this.FormStatusStrip.ResumeLayout(false);
            this.FormStatusStrip.PerformLayout();
            this.FormPanel.ResumeLayout(false);
            this.FormTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.MenuTableLayoutPanel.ResumeLayout(false);
            this.MenuTableLayoutPanel.PerformLayout();
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem MaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceCarrierToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator MaintenanceToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessContractToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator BusinessToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BusinessExternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessInternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator BusinessToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem BusinessPaymentsReceptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessResultNotifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsExternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsInternalSalesToolStripMenuItem;
        private System.Windows.Forms.Label FormTitleLabel;
    }
}