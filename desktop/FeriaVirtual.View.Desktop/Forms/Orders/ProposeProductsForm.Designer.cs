namespace FeriaVirtual.View.Desktop.Forms.Orders {
    partial class ProposeProductsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProposeProductsForm));
            this.FormPictureBox = new System.Windows.Forms.PictureBox();
            this.FormImageList = new System.Windows.Forms.ImageList(this.components);
            this.FormLabel = new System.Windows.Forms.Label();
            this.ProductDataGridView = new System.Windows.Forms.DataGridView();
            this.AceptProposeButton = new System.Windows.Forms.Button();
            this.CancelProposeButton = new System.Windows.Forms.Button();
            this.GenerateProposeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormPictureBox
            // 
            this.FormPictureBox.Image = global::FeriaVirtual.View.Desktop.Properties.Resources.form_ProposeProduct;
            this.FormPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FormPictureBox.Name = "FormPictureBox";
            this.FormPictureBox.Size = new System.Drawing.Size(100, 75);
            this.FormPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormPictureBox.TabIndex = 0;
            this.FormPictureBox.TabStop = false;
            // 
            // FormImageList
            // 
            this.FormImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FormImageList.ImageStream")));
            this.FormImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FormImageList.Images.SetKeyName(0, "button-acept.png");
            this.FormImageList.Images.SetKeyName(1, "button-cancel.png");
            this.FormImageList.Images.SetKeyName(2, "button-GeneratePropose.jpg");
            // 
            // FormLabel
            // 
            this.FormLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.FormLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormLabel.Location = new System.Drawing.Point(125, 0);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(325, 50);
            this.FormLabel.TabIndex = 1;
            this.FormLabel.Text = "Lista de productos seleccionados según mejor precio y cantidad disponibles para l" +
    "a orden de compra seleccionada.";
            // 
            // ProductDataGridView
            // 
            this.ProductDataGridView.AllowUserToAddRows = false;
            this.ProductDataGridView.AllowUserToDeleteRows = false;
            this.ProductDataGridView.AllowUserToOrderColumns = true;
            this.ProductDataGridView.AllowUserToResizeColumns = false;
            this.ProductDataGridView.AllowUserToResizeRows = false;
            this.ProductDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ProductDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDataGridView.Location = new System.Drawing.Point(125, 50);
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
            this.ProductDataGridView.Size = new System.Drawing.Size(550, 150);
            this.ProductDataGridView.StandardTab = true;
            this.ProductDataGridView.TabIndex = 2;
            // 
            // AceptProposeButton
            // 
            this.AceptProposeButton.AutoSize = true;
            this.AceptProposeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AceptProposeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AceptProposeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AceptProposeButton.ImageKey = "button-acept.png";
            this.AceptProposeButton.ImageList = this.FormImageList;
            this.AceptProposeButton.Location = new System.Drawing.Point(450, 225);
            this.AceptProposeButton.Name = "AceptProposeButton";
            this.AceptProposeButton.Size = new System.Drawing.Size(90, 27);
            this.AceptProposeButton.TabIndex = 3;
            this.AceptProposeButton.Text = "&Aceptar";
            this.AceptProposeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AceptProposeButton.UseVisualStyleBackColor = true;
            this.AceptProposeButton.Click += new System.EventHandler(this.AceptProposeButton_Click);
            // 
            // CancelProposeButton
            // 
            this.CancelProposeButton.AutoSize = true;
            this.CancelProposeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelProposeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelProposeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelProposeButton.ImageKey = "button-cancel.png";
            this.CancelProposeButton.ImageList = this.FormImageList;
            this.CancelProposeButton.Location = new System.Drawing.Point(575, 225);
            this.CancelProposeButton.Name = "CancelProposeButton";
            this.CancelProposeButton.Size = new System.Drawing.Size(98, 27);
            this.CancelProposeButton.TabIndex = 4;
            this.CancelProposeButton.Text = "Cancelar";
            this.CancelProposeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelProposeButton.UseVisualStyleBackColor = true;
            this.CancelProposeButton.Click += new System.EventHandler(this.CancelProposeButton_Click);
            // 
            // GenerateProposeButton
            // 
            this.GenerateProposeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GenerateProposeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GenerateProposeButton.ImageKey = "button-GeneratePropose.jpg";
            this.GenerateProposeButton.ImageList = this.FormImageList;
            this.GenerateProposeButton.Location = new System.Drawing.Point(475, 0);
            this.GenerateProposeButton.Name = "GenerateProposeButton";
            this.GenerateProposeButton.Size = new System.Drawing.Size(200, 27);
            this.GenerateProposeButton.TabIndex = 5;
            this.GenerateProposeButton.Text = "&Generar propuesta";
            this.GenerateProposeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GenerateProposeButton.UseVisualStyleBackColor = true;
            this.GenerateProposeButton.Click += new System.EventHandler(this.GenerateProposeButton_Click);
            // 
            // ProposeProductsForm
            // 
            this.AcceptButton = this.AceptProposeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.CancelProposeButton;
            this.ClientSize = new System.Drawing.Size(684, 264);
            this.Controls.Add(this.GenerateProposeButton);
            this.Controls.Add(this.CancelProposeButton);
            this.Controls.Add(this.AceptProposeButton);
            this.Controls.Add(this.ProductDataGridView);
            this.Controls.Add(this.FormLabel);
            this.Controls.Add(this.FormPictureBox);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 303);
            this.Name = "ProposeProductsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Propuesta de productos";
            this.Load += new System.EventHandler(this.ProposeProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FormPictureBox;
        private System.Windows.Forms.ImageList FormImageList;
        private System.Windows.Forms.Label FormLabel;
        private System.Windows.Forms.DataGridView ProductDataGridView;
        private System.Windows.Forms.Button AceptProposeButton;
        private System.Windows.Forms.Button CancelProposeButton;
        private System.Windows.Forms.Button GenerateProposeButton;
    }
}