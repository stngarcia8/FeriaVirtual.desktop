using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.View.Desktop.Commands;


namespace FeriaVirtual.View.Desktop.Forms.Orders{

    public partial class ProposeProductsForm : Form{

        public string IdSelected{ get; set; }

        public bool IsSaved{ get; set; }


        public ProposeProductsForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void ProposeProductsForm_Load(object sender, EventArgs e){
            ProductDataGridView.DataSource = null;
        }


        private void GenerateProposeButton_Click(object sender, EventArgs e){
            LoadProducts();
            if (!VerifyStock()) AceptProposeButton.Visible = false;
        }


        private void AceptProposeButton_Click(object sender, EventArgs e){
            if (!AceptPropose()) return;
            IsSaved = true;
            Close();
        }


        private bool VerifyStock(){
            var verifyResult = true;
            IList<string> fallProducts = new List<string>();
            foreach (DataGridViewRow row in ProductDataGridView.Rows)
                if (int.Parse(row.Cells["Cantidad solicitada"].Value.ToString()).Equals(0)){
                    fallProducts.Add(row.Cells["Producto"].Value.ToString());
                    verifyResult = false;
                }
            if (fallProducts.Count > 0){
                var message = new StringBuilder();
                message.Append(
                    $"El stock del o los siguientes productos no satisfacen la cantidad solicitada por el cliente, favor verificar existencias {Environment.NewLine}");
                foreach (var p in fallProducts) message.Append($"Producto(s) : {p} {Environment.NewLine}");
                message.Append(
                    "Favor comunicar situación al cliente que solicito el producto(s).");
                MessageBox.Show(message.ToString(), "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return verifyResult;
        }


        private void CancelProposeButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void LoadProducts(){
            var propose = LoadProposeProduct.OpenPropose(ProductDataGridView, IdSelected, false);
            propose.Execute();
        }


        private bool AceptPropose(){
            bool result;
            try{
                var usecase = OrderUseCase.CreateUseCase();
                usecase.AceptProposeProducts(IdSelected);
                const string message = "Los productos propuestos han sido aceptados.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }

            return result;
        }

    }

}