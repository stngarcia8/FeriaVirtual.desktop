namespace FeriaVirtual.View.Desktop.Forms.orders {
    partial class AuctionForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuctionForm));
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductWeightLabel = new System.Windows.Forms.Label();
            this.ProductWeightTextBox = new System.Windows.Forms.TextBox();
            this.ProductWeigthKGLabel = new System.Windows.Forms.Label();
            this.ProductValueLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AuctionTitleLabel = new System.Windows.Forms.Label();
            this.ProposeValueLabel = new System.Windows.Forms.Label();
            this.ProposeValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProposeValueTextBox = new System.Windows.Forms.TextBox();
            this.LimitDateLabel = new System.Windows.Forms.Label();
            this.LimitDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AuctionStatusRefreshButton = new System.Windows.Forms.Button();
            this.AuctionStatusCloseButton = new System.Windows.Forms.Button();
            this.AuctionStatusDataGridView = new System.Windows.Forms.DataGridView();
            this.AuctionStatusLabel = new System.Windows.Forms.Label();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.AuctionSaveButton = new System.Windows.Forms.Button();
            this.AuctionCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProposeValueNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuctionStatusDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.form_auction;
            this.FormPictureBox.Location = new System.Drawing.Point(0,0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100,75);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Century Gothic",12F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.ProductLabel.Location = new System.Drawing.Point(125,0);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(320,21);
            this.ProductLabel.TabIndex = 1;
            this.ProductLabel.Text = "Información de productos a transportar";
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            this.ProductDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ProductDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(125,25);
            this.ProductDataGridView.MultiSelect = false;
            this.ProductDataGridView.Name = "ProductDataGridView";
            this.ProductDataGridView.ReadOnly = true;
            this.ProductDataGridView.RowHeadersVisible = false;
            this.ProductDataGridView.RowTemplate.Height = 23;
            this.ProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductDataGridView.ShowCellToolTips = false;
            this.ProductDataGridView.ShowEditingIcon = false;
            this.ProductDataGridView.ShowRowErrors = false;
            this.ProductDataGridView.Size = new System.Drawing.Size(675,150);
            this.ProductDataGridView.StandardTab = true;
            this.ProductDataGridView.TabIndex = 2;
            // 
            // ProductWeightLabel
            // 
            this.ProductWeightLabel.AutoSize = true;
            this.ProductWeightLabel.Location = new System.Drawing.Point(125,175);
            this.ProductWeightLabel.Name = "ProductWeightLabel";
            this.ProductWeightLabel.Size = new System.Drawing.Size(78,17);
            this.ProductWeightLabel.TabIndex = 3;
            this.ProductWeightLabel.Text = "Total peso:";
            // 
            // ProductWeightTextBox
            // 
            this.ProductWeightTextBox.BackColor = System.Drawing.Color.Yellow;
            this.ProductWeightTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductWeightTextBox.Font = new System.Drawing.Font("Century Gothic",9.75F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.ProductWeightTextBox.Location = new System.Drawing.Point(225,175);
            this.ProductWeightTextBox.Name = "ProductWeightTextBox";
            this.ProductWeightTextBox.ReadOnly = true;
            this.ProductWeightTextBox.Size = new System.Drawing.Size(100,16);
            this.ProductWeightTextBox.TabIndex = 4;
            this.ProductWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ProductWeigthKGLabel
            // 
            this.ProductWeigthKGLabel.AutoSize = true;
            this.ProductWeigthKGLabel.Location = new System.Drawing.Point(325,175);
            this.ProductWeigthKGLabel.Name = "ProductWeigthKGLabel";
            this.ProductWeigthKGLabel.Size = new System.Drawing.Size(41,17);
            this.ProductWeigthKGLabel.TabIndex = 5;
            this.ProductWeigthKGLabel.Text = "(KGs)";
            // 
            // ProductValueLabel
            // 
            this.ProductValueLabel.AutoSize = true;
            this.ProductValueLabel.Location = new System.Drawing.Point(550,175);
            this.ProductValueLabel.Name = "ProductValueLabel";
            this.ProductValueLabel.Size = new System.Drawing.Size(151,17);
            this.ProductValueLabel.TabIndex = 6;
            this.ProductValueLabel.Text = "Valor total productos:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Yellow;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic",9.75F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(700,175);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100,16);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AuctionTitleLabel
            // 
            this.AuctionTitleLabel.AutoSize = true;
            this.AuctionTitleLabel.Font = new System.Drawing.Font("Century Gothic",12F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.AuctionTitleLabel.Location = new System.Drawing.Point(125,225);
            this.AuctionTitleLabel.Name = "AuctionTitleLabel";
            this.AuctionTitleLabel.Size = new System.Drawing.Size(199,21);
            this.AuctionTitleLabel.TabIndex = 8;
            this.AuctionTitleLabel.Text = "Información de subasta.";
            // 
            // ProposeValueLabel
            // 
            this.ProposeValueLabel.AutoSize = true;
            this.ProposeValueLabel.Location = new System.Drawing.Point(125,250);
            this.ProposeValueLabel.Name = "ProposeValueLabel";
            this.ProposeValueLabel.Size = new System.Drawing.Size(116,17);
            this.ProposeValueLabel.TabIndex = 9;
            this.ProposeValueLabel.Text = "Valor propuesto:";
            // 
            // ProposeValueNumericUpDown
            // 
            this.ProposeValueNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProposeValueNumericUpDown.Location = new System.Drawing.Point(125,275);
            this.ProposeValueNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ProposeValueNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ProposeValueNumericUpDown.Name = "ProposeValueNumericUpDown";
            this.ProposeValueNumericUpDown.ReadOnly = true;
            this.ProposeValueNumericUpDown.Size = new System.Drawing.Size(75,23);
            this.ProposeValueNumericUpDown.TabIndex = 10;
            this.ProposeValueNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ProposeValueNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProposeValueTextBox
            // 
            this.ProposeValueTextBox.BackColor = System.Drawing.Color.Yellow;
            this.ProposeValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProposeValueTextBox.Font = new System.Drawing.Font("Century Gothic",9.75F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.ProposeValueTextBox.Location = new System.Drawing.Point(200,275);
            this.ProposeValueTextBox.Name = "ProposeValueTextBox";
            this.ProposeValueTextBox.ReadOnly = true;
            this.ProposeValueTextBox.Size = new System.Drawing.Size(100,16);
            this.ProposeValueTextBox.TabIndex = 12;
            this.ProposeValueTextBox.Text = "999,9999,9999";
            this.ProposeValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LimitDateLabel
            // 
            this.LimitDateLabel.AutoSize = true;
            this.LimitDateLabel.Location = new System.Drawing.Point(125,325);
            this.LimitDateLabel.Name = "LimitDateLabel";
            this.LimitDateLabel.Size = new System.Drawing.Size(124,17);
            this.LimitDateLabel.TabIndex = 13;
            this.LimitDateLabel.Text = "Fecha finalización";
            // 
            // LimitDateDateTimePicker
            // 
            this.LimitDateDateTimePicker.Checked = false;
            this.LimitDateDateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.LimitDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LimitDateDateTimePicker.Location = new System.Drawing.Point(125,350);
            this.LimitDateDateTimePicker.Name = "LimitDateDateTimePicker";
            this.LimitDateDateTimePicker.Size = new System.Drawing.Size(175,23);
            this.LimitDateDateTimePicker.TabIndex = 14;
            // 
            // AuctionStatusRefreshButton
            // 
            this.AuctionStatusRefreshButton.Font = new System.Drawing.Font("Century Gothic",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.AuctionStatusRefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuctionStatusRefreshButton.ImageKey = "menu-refresh.png";
            this.AuctionStatusRefreshButton.ImageList = this.FormImageList;
            this.AuctionStatusRefreshButton.Location = new System.Drawing.Point(675,250);
            this.AuctionStatusRefreshButton.Name = "AuctionStatusRefreshButton";
            this.AuctionStatusRefreshButton.Size = new System.Drawing.Size(125,23);
            this.AuctionStatusRefreshButton.TabIndex = 16;
            this.AuctionStatusRefreshButton.Text = "Actualizar";
            this.AuctionStatusRefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AuctionStatusRefreshButton.UseVisualStyleBackColor = true;
            // 
            // AuctionStatusCloseButton
            // 
            this.AuctionStatusCloseButton.Font = new System.Drawing.Font("Century Gothic",8.25F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.AuctionStatusCloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuctionStatusCloseButton.ImageKey = "button-auction.png";
            this.AuctionStatusCloseButton.ImageList = this.FormImageList;
            this.AuctionStatusCloseButton.Location = new System.Drawing.Point(675,300);
            this.AuctionStatusCloseButton.Name = "AuctionStatusCloseButton";
            this.AuctionStatusCloseButton.Size = new System.Drawing.Size(125,23);
            this.AuctionStatusCloseButton.TabIndex = 17;
            this.AuctionStatusCloseButton.Text = "Cerrar subasta";
            this.AuctionStatusCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AuctionStatusCloseButton.UseVisualStyleBackColor = true;
            // 
            // AuctionStatusDataGridView
            // 
            this.AuctionStatusDataGridView.AllowUserToAddRows = false;
            this.AuctionStatusDataGridView.AllowUserToDeleteRows = false;
            this.AuctionStatusDataGridView.AllowUserToResizeColumns = false;
            this.AuctionStatusDataGridView.AllowUserToResizeRows = false;
            this.AuctionStatusDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.AuctionStatusDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            this.AuctionStatusDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.AuctionStatusDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuctionStatusDataGridView.GridColor = System.Drawing.Color.LightGray;
            this.AuctionStatusDataGridView.Location = new System.Drawing.Point(350,250);
            this.AuctionStatusDataGridView.MultiSelect = false;
            this.AuctionStatusDataGridView.Name = "AuctionStatusDataGridView";
            this.AuctionStatusDataGridView.ReadOnly = true;
            this.AuctionStatusDataGridView.RowHeadersVisible = false;
            this.AuctionStatusDataGridView.RowTemplate.Height = 23;
            this.AuctionStatusDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuctionStatusDataGridView.ShowCellErrors = false;
            this.AuctionStatusDataGridView.ShowCellToolTips = false;
            this.AuctionStatusDataGridView.ShowEditingIcon = false;
            this.AuctionStatusDataGridView.ShowRowErrors = false;
            this.AuctionStatusDataGridView.Size = new System.Drawing.Size(300,125);
            this.AuctionStatusDataGridView.StandardTab = true;
            this.AuctionStatusDataGridView.TabIndex = 15;
            // 
            // AuctionStatusLabel
            // 
            this.AuctionStatusLabel.AutoSize = true;
            this.AuctionStatusLabel.Location = new System.Drawing.Point(350,225);
            this.AuctionStatusLabel.Name = "AuctionStatusLabel";
            this.AuctionStatusLabel.Size = new System.Drawing.Size(189,17);
            this.AuctionStatusLabel.TabIndex = 19;
            this.AuctionStatusLabel.Text = "Resultados puja de subasta:";
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0,"button-acept.png");
            this.FormImageList.Images.SetKeyName(1,"button-cancel.png");
            this.FormImageList.Images.SetKeyName(2,"menu-refresh.png");
            this.FormImageList.Images.SetKeyName(3,"button-auction.png");
            this.FormImageList.Images.SetKeyName(4,"button-save.png");
            // 
            // AuctionSaveButton
            // 
            this.AuctionSaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuctionSaveButton.ImageKey = "button-save.png";
            this.AuctionSaveButton.ImageList = this.FormImageList;
            this.AuctionSaveButton.Location = new System.Drawing.Point(475,425);
            this.AuctionSaveButton.Name = "AuctionSaveButton";
            this.AuctionSaveButton.Size = new System.Drawing.Size(200,23);
            this.AuctionSaveButton.TabIndex = 20;
            this.AuctionSaveButton.Text = "&Grabar información de subasta";
            this.AuctionSaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AuctionSaveButton.UseVisualStyleBackColor = true;
            // 
            // AuctionCancelButton
            // 
            this.AuctionCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AuctionCancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuctionCancelButton.ImageKey = "button-cancel.png";
            this.AuctionCancelButton.ImageList = this.FormImageList;
            this.AuctionCancelButton.Location = new System.Drawing.Point(700,425);
            this.AuctionCancelButton.Name = "AuctionCancelButton";
            this.AuctionCancelButton.Size = new System.Drawing.Size(100,23);
            this.AuctionCancelButton.TabIndex = 21;
            this.AuctionCancelButton.Text = "Cancelar";
            this.AuctionCancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuctionCancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AuctionCancelButton.UseVisualStyleBackColor = true;
            // 
            // AuctionForm
            // 
            this.AcceptButton = this.AuctionSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F,17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.AuctionCancelButton;
            this.ClientSize = new System.Drawing.Size(813,460);
            this.Controls.Add(this.AuctionCancelButton);
            this.Controls.Add(this.AuctionSaveButton);
            this.Controls.Add(this.AuctionStatusLabel);
            this.Controls.Add(this.AuctionStatusDataGridView);
            this.Controls.Add(this.AuctionStatusCloseButton);
            this.Controls.Add(this.AuctionStatusRefreshButton);
            this.Controls.Add(this.LimitDateDateTimePicker);
            this.Controls.Add(this.LimitDateLabel);
            this.Controls.Add(this.ProposeValueTextBox);
            this.Controls.Add(this.ProposeValueNumericUpDown);
            this.Controls.Add(this.ProposeValueLabel);
            this.Controls.Add(this.AuctionTitleLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ProductValueLabel);
            this.Controls.Add(this.ProductWeigthKGLabel);
            this.Controls.Add(this.ProductWeightTextBox);
            this.Controls.Add(this.ProductWeightLabel);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.ProductLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic",9.75F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuctionForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subastar transporte";
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProposeValueNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuctionStatusDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.Label ProductWeightLabel;
        private System.Windows.Forms.TextBox ProductWeightTextBox;
        private System.Windows.Forms.Label ProductWeigthKGLabel;
        private System.Windows.Forms.Label ProductValueLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label AuctionTitleLabel;
        private System.Windows.Forms.Label ProposeValueLabel;
        private System.Windows.Forms.NumericUpDown ProposeValueNumericUpDown;
        private System.Windows.Forms.TextBox ProposeValueTextBox;
        private System.Windows.Forms.Label LimitDateLabel;
        private System.Windows.Forms.DateTimePicker LimitDateDateTimePicker;
        private System.Windows.Forms.Button AuctionStatusRefreshButton;
        private System.Windows.Forms.Button AuctionStatusCloseButton;
        private System.Windows.Forms.DataGridView AuctionStatusDataGridView;
        private System.Windows.Forms.Label AuctionStatusLabel;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Button AuctionSaveButton;
        private System.Windows.Forms.Button AuctionCancelButton;
    }
}