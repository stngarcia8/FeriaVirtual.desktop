using System;
using System.Data;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.View.Desktop.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Orders {
    public partial class ProposeProductsForm:Form {

        // Properties
        public string IdSelected { get; set; }
        public bool IsSaved { get; set; }


        public ProposeProductsForm() {
            InitializeComponent();
            this.IsSaved= false;
        }

        private void ProposeProductsForm_Load(object sender,EventArgs e) {
            this.ProductDataGridView.DataSource=null;
        }


        private void GenerateProposeButton_Click(object sender,EventArgs e) {
            LoadProposeProduct();
        }

        private void AceptProposeButton_Click(object sender,EventArgs e) {
            if(!AceptPropose()) {
                return;
            }
            this.IsSaved= true;
            this.Close();
        }

        private void CancelProposeButton_Click(object sender,EventArgs e) {
            this.IsSaved= false;
            this.Close();
        }

        private void LoadProposeProduct() {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                this.ProductDataGridView.DataSource= null;
                this.ProductDataGridView.DataSource = usecase.GetGenerateProposeProduct(this.IdSelected);
                this.ConfigureProductGrid();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void ConfigureProductGrid() {
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
            IList<string> columns = new List<string>() { "id_respuesta","id_pedido" };
            configurator.HideColumns(columns);
            configurator.NumericColumn("Stock disponible","Stock disponible");
            configurator.NumericColumn("Cantidad solicitada","Cantidad solicitada");
            configurator.NumericColumn("Valor KG","Valor KG");
        }

private bool AceptPropose() {
            bool result = false;
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                usecase.AceptProposeProducts(this.IdSelected);
                string message = "Los productos propuestos han sido aceptados.";
                MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                result= true;

            }catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                result= false;
            }
            return result;
        }

    }
}
