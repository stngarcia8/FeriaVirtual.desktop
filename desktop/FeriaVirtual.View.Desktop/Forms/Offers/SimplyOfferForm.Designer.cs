namespace FeriaVirtual.View.Desktop.Forms.Offers {
    partial class SimplyOfferForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimplyOfferForm));
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.PublishDateLabel = new System.Windows.Forms.Label();
            this.PublishDateTextBox = new System.Windows.Forms.TextBox();
            this.DiscountLabel = new System.Windows.Forms.Label();
            this.DiscountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ProductTitleLabel = new System.Windows.Forms.Label();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ListRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ListAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ListRemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelOfferButton = new System.Windows.Forms.Button();
            this.SaveOfferButton = new System.Windows.Forms.Button();
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.OfferTypeLabel = new System.Windows.Forms.Label();
            this.OfferTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.ProductListContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-close_offer.png");
            this.FormImageList.Images.SetKeyName(1, "button-save.png");
            this.FormImageList.Images.SetKeyName(2, "button-cancel.png");
            // 
            // PublishDateLabel
            // 
            this.PublishDateLabel.AutoSize = true;
            this.PublishDateLabel.Location = new System.Drawing.Point(150, 0);
            this.PublishDateLabel.Name = "PublishDateLabel";
            this.PublishDateLabel.Size = new System.Drawing.Size(153, 17);
            this.PublishDateLabel.TabIndex = 1;
            this.PublishDateLabel.Text = "Fecha de publicación:";
            // 
            // PublishDateTextBox
            // 
            this.PublishDateTextBox.Location = new System.Drawing.Point(350, 0);
            this.PublishDateTextBox.Name = "PublishDateTextBox";
            this.PublishDateTextBox.ReadOnly = true;
            this.PublishDateTextBox.Size = new System.Drawing.Size(175, 23);
            this.PublishDateTextBox.TabIndex = 2;
            this.PublishDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DiscountLabel
            // 
            this.DiscountLabel.AutoSize = true;
            this.DiscountLabel.Location = new System.Drawing.Point(150, 25);
            this.DiscountLabel.Name = "DiscountLabel";
            this.DiscountLabel.Size = new System.Drawing.Size(144, 17);
            this.DiscountLabel.TabIndex = 3;
            this.DiscountLabel.Text = "Descuento aplicado:";
            // 
            // DiscountNumericUpDown
            // 
            this.DiscountNumericUpDown.BackColor = System.Drawing.Color.Yellow;
            this.DiscountNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscountNumericUpDown.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscountNumericUpDown.Location = new System.Drawing.Point(350, 25);
            this.DiscountNumericUpDown.Name = "DiscountNumericUpDown";
            this.DiscountNumericUpDown.Size = new System.Drawing.Size(175, 23);
            this.DiscountNumericUpDown.TabIndex = 4;
            this.DiscountNumericUpDown.ValueChanged += new System.EventHandler(this.DiscountNumericUpDown_ValueChanged);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(150, 50);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(167, 17);
            this.DescriptionLabel.TabIndex = 5;
            this.DescriptionLabel.Text = "Descripción de la oferta:";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DescriptionTextBox.Location = new System.Drawing.Point(350, 50);
            this.DescriptionTextBox.MaxLength = 100;
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextBox.Size = new System.Drawing.Size(300, 50);
            this.DescriptionTextBox.TabIndex = 6;
            // 
            // ProductTitleLabel
            // 
            this.ProductTitleLabel.AutoSize = true;
            this.ProductTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTitleLabel.Location = new System.Drawing.Point(150, 150);
            this.ProductTitleLabel.Name = "ProductTitleLabel";
            this.ProductTitleLabel.Size = new System.Drawing.Size(253, 19);
            this.ProductTitleLabel.TabIndex = 9;
            this.ProductTitleLabel.Text = "Productos asociados a la oferta:";
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            this.ProductDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.ContextMenuStrip = this.ProductListContextMenuStrip;
            this.ProductDataGridView.Location = new System.Drawing.Point(150, 175);
            this.ProductDataGridView.MultiSelect = false;
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.ReadOnly = true;
            this.ProductDataGridView.RowHeadersVisible = false;
            this.ProductDataGridView.RowTemplate.Height = 23;
            this.ProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDataGridView.ShowCellToolTips = false;
            this.ProductDataGridView.ShowEditingIcon = false;
            this.ProductDataGridView.ShowRowErrors = false;
            this.ProductDataGridView.Size = new System.Drawing.Size(475, 175);
            this.ProductDataGridView.StandardTab = true;
            this.ProductDataGridView.TabIndex = 10;
            this.ProductDataGridView.SelectionChanged += new System.EventHandler(this.ProductDataGridView_SelectionChanged);
            // 
            // ProductListContextMenuStrip
            // 
            this.ProductListContextMenuStrip.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ProductListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListRefreshToolStripMenuItem,
            this.ListToolStripSeparator1,
            this.ListAddToolStripMenuItem,
            this.ListToolStripSeparator2,
            this.ListRemoveToolStripMenuItem});
            this.ProductListContextMenuStrip.Name = "ClientListContextMenuStrip";
            this.ProductListContextMenuStrip.Size = new System.Drawing.Size(254, 94);
            this.ProductListContextMenuStrip.Text = "Opciones";
            this.ProductListContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ProductListContextMenuStrip_Opening);
            // 
            // ListRefreshToolStripMenuItem
            // 
            this.ListRefreshToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_refresh;
            this.ListRefreshToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListRefreshToolStripMenuItem.Name = "ListRefreshToolStripMenuItem";
            this.ListRefreshToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.ListRefreshToolStripMenuItem.Text = "&Actualizar lista";
            this.ListRefreshToolStripMenuItem.Click += new System.EventHandler(this.ListRefreshToolStripMenuItem_Click);
            // 
            // ListToolStripSeparator1
            // 
            this.ListToolStripSeparator1.Name = "ListToolStripSeparator1";
            this.ListToolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // ListAddToolStripMenuItem
            // 
            this.ListAddToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.Button_Add;
            this.ListAddToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListAddToolStripMenuItem.Name = "ListAddToolStripMenuItem";
            this.ListAddToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.ListAddToolStripMenuItem.Text = "Agregar producto a &oferta";
            this.ListAddToolStripMenuItem.Click += new System.EventHandler(this.ListAddToolStripMenuItem_Click);
            // 
            // ListToolStripSeparator2
            // 
            this.ListToolStripSeparator2.Name = "ListToolStripSeparator2";
            this.ListToolStripSeparator2.Size = new System.Drawing.Size(250, 6);
            // 
            // ListRemoveToolStripMenuItem
            // 
            this.ListRemoveToolStripMenuItem.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.button_remove;
            this.ListRemoveToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListRemoveToolStripMenuItem.Name = "ListRemoveToolStripMenuItem";
            this.ListRemoveToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
            this.ListRemoveToolStripMenuItem.Text = "&Quitar de la oferta";
            this.ListRemoveToolStripMenuItem.Click += new System.EventHandler(this.ListRemoveToolStripMenuItem_Click);
            // 
            // CancelOfferButton
            // 
            this.CancelOfferButton.AutoSize = true;
            this.CancelOfferButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelOfferButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelOfferButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelOfferButton.ImageKey = "button-cancel.png";
            this.CancelOfferButton.ImageList = this.FormImageList;
            this.CancelOfferButton.Location = new System.Drawing.Point(525, 375);
            this.CancelOfferButton.Name = "CancelOfferButton";
            this.CancelOfferButton.Size = new System.Drawing.Size(98, 27);
            this.CancelOfferButton.TabIndex = 12;
            this.CancelOfferButton.Text = "Cancelar";
            this.CancelOfferButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelOfferButton.UseVisualStyleBackColor = true;
            this.CancelOfferButton.Click += new System.EventHandler(this.CancelOfferButton_Click);
            // 
            // SaveOfferButton
            // 
            this.SaveOfferButton.AutoSize = true;
            this.SaveOfferButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveOfferButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveOfferButton.ImageKey = "button-save.png";
            this.SaveOfferButton.ImageList = this.FormImageList;
            this.SaveOfferButton.Location = new System.Drawing.Point(375, 375);
            this.SaveOfferButton.Name = "SaveOfferButton";
            this.SaveOfferButton.Size = new System.Drawing.Size(127, 27);
            this.SaveOfferButton.TabIndex = 11;
            this.SaveOfferButton.Text = "Grabar oferta";
            this.SaveOfferButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveOfferButton.UseVisualStyleBackColor = true;
            this.SaveOfferButton.Click += new System.EventHandler(this.SaveOfferButton_Click);
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.Offer_form;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(114, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // OfferTypeLabel
            // 
            this.OfferTypeLabel.AutoSize = true;
            this.OfferTypeLabel.Location = new System.Drawing.Point(150, 100);
            this.OfferTypeLabel.Name = "OfferTypeLabel";
            this.OfferTypeLabel.Size = new System.Drawing.Size(102, 17);
            this.OfferTypeLabel.TabIndex = 7;
            this.OfferTypeLabel.Text = "Tipo de oferta:";
            // 
            // OfferTypeComboBox
            // 
            this.OfferTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OfferTypeComboBox.FormattingEnabled = true;
            this.OfferTypeComboBox.Location = new System.Drawing.Point(350, 100);
            this.OfferTypeComboBox.Name = "OfferTypeComboBox";
            this.OfferTypeComboBox.Size = new System.Drawing.Size(275, 25);
            this.OfferTypeComboBox.TabIndex = 8;
            // 
            // SimplyOfferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.CancelOfferButton;
            this.ClientSize = new System.Drawing.Size(635, 411);
            this.Controls.Add(this.OfferTypeComboBox);
            this.Controls.Add(this.OfferTypeLabel);
            this.Controls.Add(this.CancelOfferButton);
            this.Controls.Add(this.SaveOfferButton);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.ProductTitleLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DiscountNumericUpDown);
            this.Controls.Add(this.DiscountLabel);
            this.Controls.Add(this.PublishDateTextBox);
            this.Controls.Add(this.PublishDateLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimplyOfferForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publicación de ofertas";
            this.Load += new System.EventHandler(this.SimplyOfferForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DiscountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.ProductListContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Label PublishDateLabel;
        private System.Windows.Forms.TextBox PublishDateTextBox;
        private System.Windows.Forms.Label DiscountLabel;
        private System.Windows.Forms.NumericUpDown DiscountNumericUpDown;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label ProductTitleLabel;
        private System.Windows.Forms.Button SaveOfferButton;
        private System.Windows.Forms.Button CancelOfferButton;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.ContextMenuStrip ProductListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ListRefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ListToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ListAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ListToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ListRemoveToolStripMenuItem;
        private System.Windows.Forms.Label OfferTypeLabel;
        private System.Windows.Forms.ComboBox OfferTypeComboBox;
    }
}