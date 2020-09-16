﻿namespace FeriaVirtual.View.Desktop.Forms.Administrator {
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
            this.FormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceProducerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceExternalCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceInternalCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceCarrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.MaintenanceUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessContractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BusinessExternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessInternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BusinessTransportAuctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessProductDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessResultNotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BusinessPaymentsReceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessPaymentsDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsExternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsInternalSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormStatusStrip = new System.Windows.Forms.StatusStrip();
            this.FormStatusActiveUserToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormStatusCompanyToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FormMenuStrip.SuspendLayout();
            this.FormStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormMenuStrip
            // 
            this.FormMenuStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.MaintenanceToolStripMenuItem,
            this.BusinessToolStripMenuItem,
            this.ReportsToolStripMenuItem});
            this.FormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FormMenuStrip.Name = "FormMenuStrip";
            this.FormMenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.FormMenuStrip.Size = new System.Drawing.Size(487, 25);
            this.FormMenuStrip.TabIndex = 1;
            this.FormMenuStrip.Text = "FormMenuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(69, 21);
            this.FileToolStripMenuItem.Text = "&Archivo";
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CloseToolStripMenuItem.Text = "&Cerrar sesión";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // MaintenanceToolStripMenuItem
            // 
            this.MaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaintenanceProducerToolStripMenuItem,
            this.MaintenanceExternalCustomerToolStripMenuItem,
            this.MaintenanceInternalCustomerToolStripMenuItem,
            this.MaintenanceCarrierToolStripMenuItem,
            this.MaintenanceToolStripSeparator,
            this.MaintenanceUserToolStripMenuItem});
            this.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem";
            this.MaintenanceToolStripMenuItem.Size = new System.Drawing.Size(118, 21);
            this.MaintenanceToolStripMenuItem.Text = "&Mantenimiento";
            // 
            // MaintenanceProducerToolStripMenuItem
            // 
            this.MaintenanceProducerToolStripMenuItem.Name = "MaintenanceProducerToolStripMenuItem";
            this.MaintenanceProducerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.MaintenanceProducerToolStripMenuItem.Text = "Datos de &productores";
            // 
            // MaintenanceExternalCustomerToolStripMenuItem
            // 
            this.MaintenanceExternalCustomerToolStripMenuItem.Name = "MaintenanceExternalCustomerToolStripMenuItem";
            this.MaintenanceExternalCustomerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.MaintenanceExternalCustomerToolStripMenuItem.Text = "Datos cliente &externo";
            // 
            // MaintenanceInternalCustomerToolStripMenuItem
            // 
            this.MaintenanceInternalCustomerToolStripMenuItem.Name = "MaintenanceInternalCustomerToolStripMenuItem";
            this.MaintenanceInternalCustomerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.MaintenanceInternalCustomerToolStripMenuItem.Text = "Datos cliente &interno";
            // 
            // MaintenanceCarrierToolStripMenuItem
            // 
            this.MaintenanceCarrierToolStripMenuItem.Name = "MaintenanceCarrierToolStripMenuItem";
            this.MaintenanceCarrierToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.MaintenanceCarrierToolStripMenuItem.Text = "Datos de &transportistas";
            // 
            // MaintenanceToolStripSeparator
            // 
            this.MaintenanceToolStripSeparator.Name = "MaintenanceToolStripSeparator";
            this.MaintenanceToolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // MaintenanceUserToolStripMenuItem
            // 
            this.MaintenanceUserToolStripMenuItem.Name = "MaintenanceUserToolStripMenuItem";
            this.MaintenanceUserToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
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
            this.BusinessTransportAuctionToolStripMenuItem,
            this.BusinessProductDistributionToolStripMenuItem,
            this.BusinessResultNotifyToolStripMenuItem,
            this.BusinessToolStripSeparator3,
            this.BusinessPaymentsReceptionToolStripMenuItem,
            this.BusinessPaymentsDistributionToolStripMenuItem});
            this.BusinessToolStripMenuItem.Name = "BusinessToolStripMenuItem";
            this.BusinessToolStripMenuItem.Size = new System.Drawing.Size(155, 21);
            this.BusinessToolStripMenuItem.Text = "&Procesos de negocio";
            // 
            // BusinessContractToolStripMenuItem
            // 
            this.BusinessContractToolStripMenuItem.Name = "BusinessContractToolStripMenuItem";
            this.BusinessContractToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessContractToolStripMenuItem.Text = "&Control de contratos";
            // 
            // BusinessToolStripSeparator1
            // 
            this.BusinessToolStripSeparator1.Name = "BusinessToolStripSeparator1";
            this.BusinessToolStripSeparator1.Size = new System.Drawing.Size(251, 6);
            // 
            // BusinessExternalSalesToolStripMenuItem
            // 
            this.BusinessExternalSalesToolStripMenuItem.Name = "BusinessExternalSalesToolStripMenuItem";
            this.BusinessExternalSalesToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessExternalSalesToolStripMenuItem.Text = "Proceso de ventas &externas";
            // 
            // BusinessInternalSalesToolStripMenuItem
            // 
            this.BusinessInternalSalesToolStripMenuItem.Name = "BusinessInternalSalesToolStripMenuItem";
            this.BusinessInternalSalesToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessInternalSalesToolStripMenuItem.Text = "Procesos de ventas &internas";
            // 
            // BusinessToolStripSeparator2
            // 
            this.BusinessToolStripSeparator2.Name = "BusinessToolStripSeparator2";
            this.BusinessToolStripSeparator2.Size = new System.Drawing.Size(251, 6);
            // 
            // BusinessTransportAuctionToolStripMenuItem
            // 
            this.BusinessTransportAuctionToolStripMenuItem.Name = "BusinessTransportAuctionToolStripMenuItem";
            this.BusinessTransportAuctionToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessTransportAuctionToolStripMenuItem.Text = "&Subasta de transportes";
            // 
            // BusinessProductDistributionToolStripMenuItem
            // 
            this.BusinessProductDistributionToolStripMenuItem.Name = "BusinessProductDistributionToolStripMenuItem";
            this.BusinessProductDistributionToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessProductDistributionToolStripMenuItem.Text = "&Distribución de productos";
            // 
            // BusinessResultNotifyToolStripMenuItem
            // 
            this.BusinessResultNotifyToolStripMenuItem.Name = "BusinessResultNotifyToolStripMenuItem";
            this.BusinessResultNotifyToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessResultNotifyToolStripMenuItem.Text = "&Notificación de resultados";
            // 
            // BusinessToolStripSeparator3
            // 
            this.BusinessToolStripSeparator3.Name = "BusinessToolStripSeparator3";
            this.BusinessToolStripSeparator3.Size = new System.Drawing.Size(251, 6);
            // 
            // BusinessPaymentsReceptionToolStripMenuItem
            // 
            this.BusinessPaymentsReceptionToolStripMenuItem.Name = "BusinessPaymentsReceptionToolStripMenuItem";
            this.BusinessPaymentsReceptionToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessPaymentsReceptionToolStripMenuItem.Text = "&Recepción de pagos";
            // 
            // BusinessPaymentsDistributionToolStripMenuItem
            // 
            this.BusinessPaymentsDistributionToolStripMenuItem.Name = "BusinessPaymentsDistributionToolStripMenuItem";
            this.BusinessPaymentsDistributionToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.BusinessPaymentsDistributionToolStripMenuItem.Text = "Distribución de &pagos";
            // 
            // ReportsToolStripMenuItem
            // 
            this.ReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportsExternalSalesToolStripMenuItem,
            this.ReportsInternalSalesToolStripMenuItem});
            this.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
            this.ReportsToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
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
            // FormStatusStrip
            // 
            this.FormStatusStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormStatusActiveUserToolStripStatusLabel,
            this.FormStatusCompanyToolStripStatusLabel1});
            this.FormStatusStrip.Location = new System.Drawing.Point(0, 175);
            this.FormStatusStrip.Name = "FormStatusStrip";
            this.FormStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.FormStatusStrip.Size = new System.Drawing.Size(487, 22);
            this.FormStatusStrip.TabIndex = 2;
            this.FormStatusStrip.Text = "statusStrip1";
            // 
            // FormStatusActiveUserToolStripStatusLabel
            // 
            this.FormStatusActiveUserToolStripStatusLabel.Name = "FormStatusActiveUserToolStripStatusLabel";
            this.FormStatusActiveUserToolStripStatusLabel.Size = new System.Drawing.Size(368, 17);
            this.FormStatusActiveUserToolStripStatusLabel.Spring = true;
            this.FormStatusActiveUserToolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // FormStatusCompanyToolStripStatusLabel1
            // 
            this.FormStatusCompanyToolStripStatusLabel1.Name = "FormStatusCompanyToolStripStatusLabel1";
            this.FormStatusCompanyToolStripStatusLabel1.Size = new System.Drawing.Size(102, 17);
            this.FormStatusCompanyToolStripStatusLabel1.Text = "Maipo Grande";
            // 
            // AdministratorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 197);
            this.Controls.Add(this.FormStatusStrip);
            this.Controls.Add(this.FormMenuStrip);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdministratorMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Feria Virtual - Administrador.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministratorMainForm_FormClosing);
            this.Load += new System.EventHandler(this.AdministratorMainForm_Load);
            this.FormMenuStrip.ResumeLayout(false);
            this.FormMenuStrip.PerformLayout();
            this.FormStatusStrip.ResumeLayout(false);
            this.FormStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip FormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceProducerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceExternalCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceInternalCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceCarrierToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator MaintenanceToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessContractToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator BusinessToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem BusinessExternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessInternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator BusinessToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem BusinessTransportAuctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessProductDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessResultNotifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator BusinessToolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem BusinessPaymentsReceptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BusinessPaymentsDistributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsExternalSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsInternalSalesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip FormStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel FormStatusActiveUserToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel FormStatusCompanyToolStripStatusLabel1;
    }
}