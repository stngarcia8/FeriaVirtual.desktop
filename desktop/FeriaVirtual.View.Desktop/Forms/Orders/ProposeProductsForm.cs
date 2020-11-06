using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.View.Desktop.Helpers;
using FeriaVirtual.View.Desktop.Commands;

namespace FeriaVirtual.View.Desktop.Forms.Orders {

    public partial class ProposeProductsForm:Form {

        // Properties
        public string IdSelected { get; set; }

        public bool IsSaved { get; set; }

        public ProposeProductsForm() {
            InitializeComponent();
            IsSaved= false;
        }

        private void ProposeProductsForm_Load(object sender,EventArgs e) {
            ProductDataGridView.DataSource=null;
        }

        private void GenerateProposeButton_Click(object sender,EventArgs e) {
            LoadProducts();
        }

        private void AceptProposeButton_Click(object sender,EventArgs e) {
            if(!AceptPropose()) {
                return;
            }
            IsSaved= true;
            Close();
        }

        private void CancelProposeButton_Click(object sender,EventArgs e) {
            IsSaved= false;
            Close();
        }

        private void LoadProducts() {
            LoadProposeProduct propose = LoadProposeProduct.OpenPropose(this.ProductDataGridView,this.IdSelected);
            propose.Execute();
        }

        private bool AceptPropose() {
            bool result = false;
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                usecase.AceptProposeProducts(IdSelected);
                string message = "Los productos propuestos han sido aceptados.";
                MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                result= true;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                result= false;
            }
            return result;
        }
    }
}
