using System;
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
        }


        private void AceptProposeButton_Click(object sender, EventArgs e){
            if (!AceptPropose()) return;
            IsSaved = true;
            Close();
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