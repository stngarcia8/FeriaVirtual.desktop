namespace FeriaVirtual.View.Desktop.Forms.Payments {
    partial class PaymentDetailsForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentDetailsForm));
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.CustomerTitleLabel = new System.Windows.Forms.Label();
            this.CustomerNameLabel = new System.Windows.Forms.Label();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.CustomerTypeLabel = new System.Windows.Forms.Label();
            this.CustomerTypeTextBox = new System.Windows.Forms.TextBox();
            this.PaymentDateLabel = new System.Windows.Forms.Label();
            this.PaymentDateTextBox = new System.Windows.Forms.TextBox();
            this.PaymentHourLabel = new System.Windows.Forms.Label();
            this.PaymentHourTextBox = new System.Windows.Forms.TextBox();
            this.PaymentTitleLabel = new System.Windows.Forms.Label();
            this.PaymentConditionLabel = new System.Windows.Forms.Label();
            this.PaymentConditionTextBox = new System.Windows.Forms.TextBox();
            this.PaymentMethodLabel = new System.Windows.Forms.Label();
            this.PaymentMethodTextBox = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.ObservationLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ProductTitleLabel = new System.Windows.Forms.Label();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.NotifyButton = new System.Windows.Forms.Button();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.CloseShowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.menu_paymentShowDetails;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(114, 100);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // CustomerTitleLabel
            // 
            this.CustomerTitleLabel.AutoSize = true;
            this.CustomerTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.CustomerTitleLabel.Location = new System.Drawing.Point(125, 0);
            this.CustomerTitleLabel.Name = "CustomerTitleLabel";
            this.CustomerTitleLabel.Size = new System.Drawing.Size(188, 19);
            this.CustomerTitleLabel.TabIndex = 1;
            this.CustomerTitleLabel.Text = "Información del cliente";
            // 
            // CustomerNameLabel
            // 
            this.CustomerNameLabel.AutoSize = true;
            this.CustomerNameLabel.Location = new System.Drawing.Point(125, 25);
            this.CustomerNameLabel.Name = "CustomerNameLabel";
            this.CustomerNameLabel.Size = new System.Drawing.Size(58, 17);
            this.CustomerNameLabel.TabIndex = 2;
            this.CustomerNameLabel.Text = "Cliente:";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.BackColor = System.Drawing.Color.LightGray;
            this.CustomerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CustomerNameTextBox.Location = new System.Drawing.Point(225, 25);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.ReadOnly = true;
            this.CustomerNameTextBox.Size = new System.Drawing.Size(225, 16);
            this.CustomerNameTextBox.TabIndex = 3;
            // 
            // CustomerTypeLabel
            // 
            this.CustomerTypeLabel.AutoSize = true;
            this.CustomerTypeLabel.Location = new System.Drawing.Point(125, 50);
            this.CustomerTypeLabel.Name = "CustomerTypeLabel";
            this.CustomerTypeLabel.Size = new System.Drawing.Size(85, 17);
            this.CustomerTypeLabel.TabIndex = 4;
            this.CustomerTypeLabel.Text = "Tipo cliente:";
            // 
            // CustomerTypeTextBox
            // 
            this.CustomerTypeTextBox.BackColor = System.Drawing.Color.LightGray;
            this.CustomerTypeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomerTypeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CustomerTypeTextBox.Location = new System.Drawing.Point(225, 50);
            this.CustomerTypeTextBox.Name = "CustomerTypeTextBox";
            this.CustomerTypeTextBox.ReadOnly = true;
            this.CustomerTypeTextBox.Size = new System.Drawing.Size(225, 16);
            this.CustomerTypeTextBox.TabIndex = 5;
            // 
            // PaymentDateLabel
            // 
            this.PaymentDateLabel.AutoSize = true;
            this.PaymentDateLabel.Location = new System.Drawing.Point(125, 75);
            this.PaymentDateLabel.Name = "PaymentDateLabel";
            this.PaymentDateLabel.Size = new System.Drawing.Size(91, 17);
            this.PaymentDateLabel.TabIndex = 6;
            this.PaymentDateLabel.Text = "Fecha pago:";
            // 
            // PaymentDateTextBox
            // 
            this.PaymentDateTextBox.BackColor = System.Drawing.Color.LightGray;
            this.PaymentDateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentDateTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PaymentDateTextBox.Location = new System.Drawing.Point(225, 75);
            this.PaymentDateTextBox.Name = "PaymentDateTextBox";
            this.PaymentDateTextBox.ReadOnly = true;
            this.PaymentDateTextBox.Size = new System.Drawing.Size(225, 16);
            this.PaymentDateTextBox.TabIndex = 7;
            // 
            // PaymentHourLabel
            // 
            this.PaymentHourLabel.AutoSize = true;
            this.PaymentHourLabel.Location = new System.Drawing.Point(125, 100);
            this.PaymentHourLabel.Name = "PaymentHourLabel";
            this.PaymentHourLabel.Size = new System.Drawing.Size(83, 17);
            this.PaymentHourLabel.TabIndex = 8;
            this.PaymentHourLabel.Text = "Hora pago:";
            // 
            // PaymentHourTextBox
            // 
            this.PaymentHourTextBox.BackColor = System.Drawing.Color.LightGray;
            this.PaymentHourTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentHourTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PaymentHourTextBox.Location = new System.Drawing.Point(225, 100);
            this.PaymentHourTextBox.Name = "PaymentHourTextBox";
            this.PaymentHourTextBox.ReadOnly = true;
            this.PaymentHourTextBox.Size = new System.Drawing.Size(225, 16);
            this.PaymentHourTextBox.TabIndex = 9;
            // 
            // PaymentTitleLabel
            // 
            this.PaymentTitleLabel.AutoSize = true;
            this.PaymentTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.PaymentTitleLabel.Location = new System.Drawing.Point(475, 0);
            this.PaymentTitleLabel.Name = "PaymentTitleLabel";
            this.PaymentTitleLabel.Size = new System.Drawing.Size(175, 19);
            this.PaymentTitleLabel.TabIndex = 10;
            this.PaymentTitleLabel.Text = "Información de pago";
            // 
            // PaymentConditionLabel
            // 
            this.PaymentConditionLabel.AutoSize = true;
            this.PaymentConditionLabel.Location = new System.Drawing.Point(475, 25);
            this.PaymentConditionLabel.Name = "PaymentConditionLabel";
            this.PaymentConditionLabel.Size = new System.Drawing.Size(120, 17);
            this.PaymentConditionLabel.TabIndex = 11;
            this.PaymentConditionLabel.Text = "Condición pago:";
            // 
            // PaymentConditionTextBox
            // 
            this.PaymentConditionTextBox.BackColor = System.Drawing.Color.LightGray;
            this.PaymentConditionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentConditionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PaymentConditionTextBox.Location = new System.Drawing.Point(625, 25);
            this.PaymentConditionTextBox.Name = "PaymentConditionTextBox";
            this.PaymentConditionTextBox.ReadOnly = true;
            this.PaymentConditionTextBox.Size = new System.Drawing.Size(225, 16);
            this.PaymentConditionTextBox.TabIndex = 12;
            // 
            // PaymentMethodLabel
            // 
            this.PaymentMethodLabel.AutoSize = true;
            this.PaymentMethodLabel.Location = new System.Drawing.Point(475, 50);
            this.PaymentMethodLabel.Name = "PaymentMethodLabel";
            this.PaymentMethodLabel.Size = new System.Drawing.Size(124, 17);
            this.PaymentMethodLabel.TabIndex = 13;
            this.PaymentMethodLabel.Text = "Metodo de pago:";
            // 
            // PaymentMethodTextBox
            // 
            this.PaymentMethodTextBox.BackColor = System.Drawing.Color.LightGray;
            this.PaymentMethodTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PaymentMethodTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PaymentMethodTextBox.Location = new System.Drawing.Point(625, 50);
            this.PaymentMethodTextBox.Name = "PaymentMethodTextBox";
            this.PaymentMethodTextBox.ReadOnly = true;
            this.PaymentMethodTextBox.Size = new System.Drawing.Size(225, 16);
            this.PaymentMethodTextBox.TabIndex = 14;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(475, 75);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(112, 17);
            this.AmountLabel.TabIndex = 15;
            this.AmountLabel.Text = "Monto pagado:";
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.BackColor = System.Drawing.Color.Yellow;
            this.AmountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AmountTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AmountTextBox.Location = new System.Drawing.Point(625, 75);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.ReadOnly = true;
            this.AmountTextBox.Size = new System.Drawing.Size(225, 16);
            this.AmountTextBox.TabIndex = 16;
            // 
            // ObservationLabel
            // 
            this.ObservationLabel.AutoSize = true;
            this.ObservationLabel.Location = new System.Drawing.Point(475, 100);
            this.ObservationLabel.Name = "ObservationLabel";
            this.ObservationLabel.Size = new System.Drawing.Size(94, 17);
            this.ObservationLabel.TabIndex = 17;
            this.ObservationLabel.Text = "Observación:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightGray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(625, 100);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(225, 50);
            this.textBox1.TabIndex = 18;
            // 
            // ProductTitleLabel
            // 
            this.ProductTitleLabel.AutoSize = true;
            this.ProductTitleLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.ProductTitleLabel.Location = new System.Drawing.Point(125, 150);
            this.ProductTitleLabel.Name = "ProductTitleLabel";
            this.ProductTitleLabel.Size = new System.Drawing.Size(233, 19);
            this.ProductTitleLabel.TabIndex = 19;
            this.ProductTitleLabel.Text = "Productos asociados al pago";
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            this.ProductDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.ProductDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ProductDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.GridColor = System.Drawing.SystemColors.Window;
            this.ProductDataGridView.Location = new System.Drawing.Point(125, 175);
            this.ProductDataGridView.MultiSelect = false;
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.ReadOnly = true;
            this.ProductDataGridView.RowHeadersVisible = false;
            this.ProductDataGridView.RowTemplate.Height = 23;
            this.ProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDataGridView.ShowCellErrors = false;
            this.ProductDataGridView.ShowCellToolTips = false;
            this.ProductDataGridView.ShowEditingIcon = false;
            this.ProductDataGridView.ShowRowErrors = false;
            this.ProductDataGridView.Size = new System.Drawing.Size(725, 200);
            this.ProductDataGridView.StandardTab = true;
            this.ProductDataGridView.TabIndex = 20;
            // 
            // NotifyButton
            // 
            this.NotifyButton.AutoSize = true;
            this.NotifyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NotifyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NotifyButton.ImageKey = "button-emailNotify.jpg";
            this.NotifyButton.ImageList = this.FormImageList;
            this.NotifyButton.Location = new System.Drawing.Point(125, 400);
            this.NotifyButton.Name = "NotifyButton";
            this.NotifyButton.Size = new System.Drawing.Size(196, 27);
            this.NotifyButton.TabIndex = 21;
            this.NotifyButton.Text = "Notificar y distribuir pago";
            this.NotifyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NotifyButton.UseVisualStyleBackColor = true;
            this.NotifyButton.Click += new System.EventHandler(this.NotifyButton_Click);
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-emailNotify.jpg");
            this.FormImageList.Images.SetKeyName(1, "menu-exit.png");
            // 
            // CloseShowButton
            // 
            this.CloseShowButton.AutoSize = true;
            this.CloseShowButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CloseShowButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseShowButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CloseShowButton.ImageKey = "menu-exit.png";
            this.CloseShowButton.ImageList = this.FormImageList;
            this.CloseShowButton.Location = new System.Drawing.Point(750, 400);
            this.CloseShowButton.Name = "CloseShowButton";
            this.CloseShowButton.Size = new System.Drawing.Size(74, 27);
            this.CloseShowButton.TabIndex = 22;
            this.CloseShowButton.Text = "Cerrar";
            this.CloseShowButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseShowButton.UseVisualStyleBackColor = true;
            this.CloseShowButton.Click += new System.EventHandler(this.CloseShowButton_Click);
            // 
            // PaymentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.CloseShowButton;
            this.ClientSize = new System.Drawing.Size(914, 433);
            this.Controls.Add(this.CloseShowButton);
            this.Controls.Add(this.NotifyButton);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.ProductTitleLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ObservationLabel);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.PaymentMethodTextBox);
            this.Controls.Add(this.PaymentMethodLabel);
            this.Controls.Add(this.PaymentConditionTextBox);
            this.Controls.Add(this.PaymentConditionLabel);
            this.Controls.Add(this.PaymentTitleLabel);
            this.Controls.Add(this.PaymentHourTextBox);
            this.Controls.Add(this.PaymentHourLabel);
            this.Controls.Add(this.PaymentDateTextBox);
            this.Controls.Add(this.PaymentDateLabel);
            this.Controls.Add(this.CustomerTypeTextBox);
            this.Controls.Add(this.CustomerTypeLabel);
            this.Controls.Add(this.CustomerNameTextBox);
            this.Controls.Add(this.CustomerNameLabel);
            this.Controls.Add(this.CustomerTitleLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaymentDetailsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de pago";
            this.Load += new System.EventHandler(this.PaymentDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label CustomerTitleLabel;
        private System.Windows.Forms.Label CustomerNameLabel;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Label CustomerTypeLabel;
        private System.Windows.Forms.TextBox CustomerTypeTextBox;
        private System.Windows.Forms.Label PaymentDateLabel;
        private System.Windows.Forms.TextBox PaymentDateTextBox;
        private System.Windows.Forms.Label PaymentHourLabel;
        private System.Windows.Forms.TextBox PaymentHourTextBox;
        private System.Windows.Forms.Label PaymentTitleLabel;
        private System.Windows.Forms.Label PaymentConditionLabel;
        private System.Windows.Forms.TextBox PaymentConditionTextBox;
        private System.Windows.Forms.Label PaymentMethodLabel;
        private System.Windows.Forms.TextBox PaymentMethodTextBox;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.Label ObservationLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ProductTitleLabel;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.Button NotifyButton;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Button CloseShowButton;
    }
}