using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Orders{

    public partial class AuctionResultForm : Form{

        public Auction CurrentAuction{ get; set; }
        public string IdSelected{ get; set; }
        public bool IsSaved{ get; set; }


        public AuctionResultForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void AuctionResultForm_Load(object sender, EventArgs e){
            ConfigureForm();
        }


        private void RefreshButton_Click(object sender, EventArgs e){
            LoadBidValues();
            ResultDataGridView.Focus();
        }


        private void AuctionCloseButton_Click(object sender, EventArgs e){
            if (!CloseAuction()) return;
            IsSaved = true;
            Close();
        }


        private void RemoveButton_Click(object sender, EventArgs e){
            if (!DeleteAuction()) return;
            IsSaved = true;
            Close();
        }


        private void CancelAuctionFormButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void ConfigureForm(){
            PublishDateTextBox.Text = CurrentAuction.AuctionDate.ToShortDateString();
            LimitDateTextBox.Text = CurrentAuction.LimitDate.ToShortDateString();
            ValueTextBox.Text = CurrentAuction.Value.ToString("N");
            WeightTextBox.Text = CurrentAuction.Weight.ToString("N");
            ObservationTextBox.Text = CurrentAuction.Observation;
            var products = new BindingList<AuctionProduct>(CurrentAuction.Products);
            ProductsDataGridView.DataSource = products;
            ConfigureProductGrid();
            LoadBidValues();
            ConfigureResultGrid();
        }


        private void ConfigureProductGrid(){
            var configurator = DataGridViewConfigurator.CreateConfigurator(ProductsDataGridView);
            configurator.ChangeHeader("Product", "Producto");
            configurator.CurrencyColumn("UnitValue", "Valor");
            configurator.NumericIntegerColumn("Quantity", "Cantidad");
            configurator.CurrencyColumn("TotalValue", "Total");
        }


        private void ConfigureResultGrid(){
            var configurator = DataGridViewConfigurator.CreateConfigurator(ResultDataGridView);
            IList<string> columns = new List<string>{"id_resultado", "id_subasta", "id_cliente"};
            configurator.HideColumns(columns);
            configurator.CurrencyColumn("Puja", "Valor propuesto");
            RemoveButton.Visible = ResultDataGridView.Rows.Count.Equals(0);
            AuctionCloseButton.Visible = !ResultDataGridView.Rows.Count.Equals(0);
        }


        private bool DeleteAuction(){
            bool status;
            var message = "¿Esta seguro(a) de eliminar esta subasta?";
            var result = MessageBox.Show(message, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No)) return false;
            try{
                var usecase = AuctionUseCase.CreateUseCase();
                usecase.DeleteAuction(IdSelected);
                message = "La subasta fue eliminada correctamente.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                status = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                status = false;
            }

            return status;
        }


        private bool CloseAuction(){
            bool status;
            var message = "¿Esta seguro(a) de cerrar esta subasta?";
            var result = MessageBox.Show(message, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No)) return false;
            try{
                var usecase = AuctionUseCase.CreateUseCase();
                usecase.CloseAuction(IdSelected, CurrentAuction.AuctionId);
                message = "La subasta fue cerrada correctamente.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                status = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                status = false;
            }

            return status;
        }


        private void LoadBidValues(){
            try{
                var usecase = AuctionUseCase.CreateUseCase();
                ResultDataGridView.DataSource = null;
                ResultDataGridView.DataSource = usecase.GetAuctionBidValue(CurrentAuction.AuctionId);
                ConfigureResultGrid();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }

}