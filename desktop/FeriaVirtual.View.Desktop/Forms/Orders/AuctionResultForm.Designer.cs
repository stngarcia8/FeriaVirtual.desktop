namespace FeriaVirtual.View.Desktop.Forms.Orders {
    partial class AuctionResultForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuctionResultForm));
            this.AuctionDataLabel = new System.Windows.Forms.Label();
            this.PublichDateLabel = new System.Windows.Forms.Label();
            this.PublishDateTextBox = new System.Windows.Forms.TextBox();
            this.LimitDateLabel = new System.Windows.Forms.Label();
            this.LimitDateTextBox = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.ObservationLabel = new System.Windows.Forms.Label();
            this.ObservationTextBox = new System.Windows.Forms.TextBox();
            this.ProductsLabel = new System.Windows.Forms.Label();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.ResultTitleLabel = new System.Windows.Forms.Label();
            this.ResultDataGridView = new System.Windows.Forms.DataGridView();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.CancelAuctionFormButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AuctionCloseButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AuctionDataLabel
            // 
            this.AuctionDataLabel.AutoSize = true;
            this.AuctionDataLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuctionDataLabel.Location = new System.Drawing.Point(25, 0);
            this.AuctionDataLabel.Name = "AuctionDataLabel";
            this.AuctionDataLabel.Size = new System.Drawing.Size(166, 19);
            this.AuctionDataLabel.TabIndex = 1;
            this.AuctionDataLabel.Text = "Información subasta";
            // 
            // PublichDateLabel
            // 
            this.PublichDateLabel.AutoSize = true;
            this.PublichDateLabel.Location = new System.Drawing.Point(25, 50);
            this.PublichDateLabel.Name = "PublichDateLabel";
            this.PublichDateLabel.Size = new System.Drawing.Size(78, 17);
            this.PublichDateLabel.TabIndex = 2;
            this.PublichDateLabel.Text = "Publicada:";
            // 
            // PublishDateTextBox
            // 
            this.PublishDateTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.PublishDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PublishDateTextBox.Location = new System.Drawing.Point(125, 50);
            this.PublishDateTextBox.Name = "PublishDateTextBox";
            this.PublishDateTextBox.ReadOnly = true;
            this.PublishDateTextBox.Size = new System.Drawing.Size(100, 16);
            this.PublishDateTextBox.TabIndex = 3;
            // 
            // LimitDateLabel
            // 
            this.LimitDateLabel.AutoSize = true;
            this.LimitDateLabel.Location = new System.Drawing.Point(25, 75);
            this.LimitDateLabel.Name = "LimitDateLabel";
            this.LimitDateLabel.Size = new System.Drawing.Size(102, 17);
            this.LimitDateLabel.TabIndex = 4;
            this.LimitDateLabel.Text = "Vigente hasta:";
            // 
            // LimitDateTextBox
            // 
            this.LimitDateTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LimitDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LimitDateTextBox.Location = new System.Drawing.Point(125, 75);
            this.LimitDateTextBox.Name = "LimitDateTextBox";
            this.LimitDateTextBox.ReadOnly = true;
            this.LimitDateTextBox.Size = new System.Drawing.Size(100, 16);
            this.LimitDateTextBox.TabIndex = 5;
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(25, 100);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(46, 17);
            this.ValueLabel.TabIndex = 6;
            this.ValueLabel.Text = "Valor:";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.BackColor = System.Drawing.Color.Yellow;
            this.ValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ValueTextBox.Location = new System.Drawing.Point(125, 100);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.ReadOnly = true;
            this.ValueTextBox.Size = new System.Drawing.Size(100, 16);
            this.ValueTextBox.TabIndex = 7;
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(25, 125);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(74, 17);
            this.WeightLabel.TabIndex = 8;
            this.WeightLabel.Text = "Peso (KG):";
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.BackColor = System.Drawing.Color.Yellow;
            this.WeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WeightTextBox.Location = new System.Drawing.Point(125, 125);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.ReadOnly = true;
            this.WeightTextBox.Size = new System.Drawing.Size(100, 16);
            this.WeightTextBox.TabIndex = 9;
            // 
            // ObservationLabel
            // 
            this.ObservationLabel.AutoSize = true;
            this.ObservationLabel.Location = new System.Drawing.Point(25, 150);
            this.ObservationLabel.Name = "ObservationLabel";
            this.ObservationLabel.Size = new System.Drawing.Size(94, 17);
            this.ObservationLabel.TabIndex = 10;
            this.ObservationLabel.Text = "Observación:";
            // 
            // ObservationTextBox
            // 
            this.ObservationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ObservationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ObservationTextBox.Location = new System.Drawing.Point(125, 150);
            this.ObservationTextBox.Multiline = true;
            this.ObservationTextBox.Name = "ObservationTextBox";
            this.ObservationTextBox.ReadOnly = true;
            this.ObservationTextBox.Size = new System.Drawing.Size(450, 50);
            this.ObservationTextBox.TabIndex = 11;
            // 
            // ProductsLabel
            // 
            this.ProductsLabel.AutoSize = true;
            this.ProductsLabel.Location = new System.Drawing.Point(225, 0);
            this.ProductsLabel.Name = "ProductsLabel";
            this.ProductsLabel.Size = new System.Drawing.Size(94, 17);
            this.ProductsLabel.TabIndex = 12;
            this.ProductsLabel.Text = "Observación:";
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.AllowUserToAddRows = false;
            this.ProductsDataGridView.AllowUserToDeleteRows = false;
            this.ProductsDataGridView.AllowUserToResizeColumns = false;
            this.ProductsDataGridView.AllowUserToResizeRows = false;
            this.ProductsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ProductsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ProductsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.GridColor = System.Drawing.Color.White;
            this.ProductsDataGridView.Location = new System.Drawing.Point(225, 25);
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
            this.ProductsDataGridView.Size = new System.Drawing.Size(350, 125);
            this.ProductsDataGridView.StandardTab = true;
            this.ProductsDataGridView.TabIndex = 13;
            // 
            // ResultTitleLabel
            // 
            this.ResultTitleLabel.AutoSize = true;
            this.ResultTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultTitleLabel.Location = new System.Drawing.Point(25, 200);
            this.ResultTitleLabel.Name = "ResultTitleLabel";
            this.ResultTitleLabel.Size = new System.Drawing.Size(91, 19);
            this.ResultTitleLabel.TabIndex = 14;
            this.ResultTitleLabel.Text = "Propuestas";
            // 
            // ResultDataGridView
            // 
            this.ResultDataGridView.AllowUserToAddRows = false;
            this.ResultDataGridView.AllowUserToDeleteRows = false;
            this.ResultDataGridView.AllowUserToResizeColumns = false;
            this.ResultDataGridView.AllowUserToResizeRows = false;
            this.ResultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ResultDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResultDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultDataGridView.GridColor = System.Drawing.Color.White;
            this.ResultDataGridView.Location = new System.Drawing.Point(25, 225);
            this.ResultDataGridView.MultiSelect = false;
            this.ResultDataGridView.Name = "ResultDataGridView";
            this.ResultDataGridView.ReadOnly = true;
            this.ResultDataGridView.RowHeadersVisible = false;
            this.ResultDataGridView.RowTemplate.Height = 23;
            this.ResultDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultDataGridView.ShowCellErrors = false;
            this.ResultDataGridView.ShowCellToolTips = false;
            this.ResultDataGridView.ShowEditingIcon = false;
            this.ResultDataGridView.ShowRowErrors = false;
            this.ResultDataGridView.Size = new System.Drawing.Size(425, 175);
            this.ResultDataGridView.StandardTab = true;
            this.ResultDataGridView.TabIndex = 15;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "menu-refresh.png");
            this.FormImageList.Images.SetKeyName(1, "button-closeAuction.jpg");
            this.FormImageList.Images.SetKeyName(2, "button-remove.png");
            this.FormImageList.Images.SetKeyName(3, "button-cancel.png");
            // 
            // CancelAuctionFormButton
            // 
            this.CancelAuctionFormButton.AutoSize = true;
            this.CancelAuctionFormButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelAuctionFormButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelAuctionFormButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelAuctionFormButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelAuctionFormButton.ImageKey = "button-cancel.png";
            this.CancelAuctionFormButton.ImageList = this.FormImageList;
            this.CancelAuctionFormButton.Location = new System.Drawing.Point(500, 425);
            this.CancelAuctionFormButton.Name = "CancelAuctionFormButton";
            this.CancelAuctionFormButton.Size = new System.Drawing.Size(89, 26);
            this.CancelAuctionFormButton.TabIndex = 19;
            this.CancelAuctionFormButton.Text = "Cancelar";
            this.CancelAuctionFormButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelAuctionFormButton.UseVisualStyleBackColor = true;
            this.CancelAuctionFormButton.Click += new System.EventHandler(this.CancelAuctionFormButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AutoSize = true;
            this.RemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveButton.ImageKey = "button-remove.png";
            this.RemoveButton.ImageList = this.FormImageList;
            this.RemoveButton.Location = new System.Drawing.Point(350, 425);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(124, 26);
            this.RemoveButton.TabIndex = 18;
            this.RemoveButton.Text = "Eliminar subasta";
            this.RemoveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AuctionCloseButton
            // 
            this.AuctionCloseButton.AutoSize = true;
            this.AuctionCloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AuctionCloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AuctionCloseButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuctionCloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuctionCloseButton.ImageKey = "button-closeAuction.jpg";
            this.AuctionCloseButton.ImageList = this.FormImageList;
            this.AuctionCloseButton.Location = new System.Drawing.Point(200, 425);
            this.AuctionCloseButton.Name = "AuctionCloseButton";
            this.AuctionCloseButton.Size = new System.Drawing.Size(117, 26);
            this.AuctionCloseButton.TabIndex = 17;
            this.AuctionCloseButton.Text = "Cerrar subasta";
            this.AuctionCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AuctionCloseButton.UseVisualStyleBackColor = true;
            this.AuctionCloseButton.Click += new System.EventHandler(this.AuctionCloseButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.AutoSize = true;
            this.RefreshButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RefreshButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.ImageKey = "menu-refresh.png";
            this.RefreshButton.ImageList = this.FormImageList;
            this.RefreshButton.Location = new System.Drawing.Point(25, 425);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(154, 26);
            this.RefreshButton.TabIndex = 16;
            this.RefreshButton.Text = "Actualizar propuestas";
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_auctionView;
            this.FormPictureBox.Location = new System.Drawing.Point(475, 225);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // AuctionResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.CancelAuctionFormButton;
            this.ClientSize = new System.Drawing.Size(592, 461);
            this.Controls.Add(this.CancelAuctionFormButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AuctionCloseButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ResultDataGridView);
            this.Controls.Add(this.ResultTitleLabel);
            this.Controls.Add(this.ProductsDataGridView);
            this.Controls.Add(this.ProductsLabel);
            this.Controls.Add(this.ObservationTextBox);
            this.Controls.Add(this.ObservationLabel);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.LimitDateTextBox);
            this.Controls.Add(this.LimitDateLabel);
            this.Controls.Add(this.PublishDateTextBox);
            this.Controls.Add(this.PublichDateLabel);
            this.Controls.Add(this.AuctionDataLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuctionResultForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar resultado de subasta.";
            this.Load += new System.EventHandler(this.AuctionResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label AuctionDataLabel;
        private System.Windows.Forms.Label PublichDateLabel;
        private System.Windows.Forms.TextBox PublishDateTextBox;
        private System.Windows.Forms.Label LimitDateLabel;
        private System.Windows.Forms.TextBox LimitDateTextBox;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label ObservationLabel;
        private System.Windows.Forms.TextBox ObservationTextBox;
        private System.Windows.Forms.Label ProductsLabel;
        private System.Windows.Forms.DataGridView ProductsDataGridView;
        private System.Windows.Forms.Label ResultTitleLabel;
        private System.Windows.Forms.DataGridView ResultDataGridView;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Button AuctionCloseButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button CancelAuctionFormButton;
    }
}