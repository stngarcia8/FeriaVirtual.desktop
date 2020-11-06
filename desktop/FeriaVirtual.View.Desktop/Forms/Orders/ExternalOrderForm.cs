using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Forms.Orders {

    public partial class ExternalOrderForm:Form {
        private string idSelected;
        private string idClientSelected;
        private int userRolID = 3;
        private Auction currentAuction;

        public ExternalOrderForm() {
            InitializeComponent();
            idSelected= string.Empty;
            idClientSelected= string.Empty;
        }

        private void ExternalOrderForm_Load(object sender,EventArgs e) {
            ConfigureForm();
            ListDataGridView.Focus();
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadOrders(ListFilterComboBox.SelectedIndex);
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }

        private void ListFilterComboBox_SelectedIndexChanged(object sender,EventArgs e) {
            ConfigureContextMenu();
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadOrders(ListFilterComboBox.SelectedIndex);
        }

        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void OrderContextMenuStrip_Opening(object sender,CancelEventArgs e) {
            ConfigureContextMenu();
        }

        private void OrderRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadOrders(ListFilterComboBox.SelectedIndex);
            ListDataGridView.Focus();
        }

        private void OrderDistributeToolStripMenuItem_Click(object sender,EventArgs e) {
            ProposeProductsForm form = new ProposeProductsForm {
                IdSelected= idSelected
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }

        private void OrderAuctionToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenAuctionForm(true);
        }

        private void OrderEditAuctionToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenAuctionForm(false);
        }

        private void OrderAuctionResultToolStripMenuItem_Click(object sender,EventArgs e) {
            AuctionResultForm form = new AuctionResultForm {
                CurrentAuction= currentAuction,
                IdSelected=this.idSelected
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }

        private void ConfigureForm() {
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadOrders(ListFilterComboBox.SelectedIndex);
        }

        private void LoadFilters() {
            FilterConfigurator configurator = FilterConfigurator.CreateConfigurator(ListFilterComboBox);
            IList<string> filterOptions = new List<string>()
                { "Ordenes recepcionadas", "Ordenes con propuesta generada", "Ordenes con subastas publicadas",
                "Ordenes subastadas", "Ordenes despachadas"};
            configurator.LoadFilters(filterOptions);
        }

        private void LoadOrders(int filterType) {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = usecase.GetOrderByStatus((filterType+1),userRolID);
                DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>() { "id_pedido","id_cliente","id_estado","id_condicion","Condicion pago","id_rol","estado_subasta", "empresa", "dir", "fono", "observacion" };
                configurator.HideColumns(columns);
                configurator.ChangeHeader("Observacion","Observación");
                configurator.NumericColumn("Descuento","Descuento");
                DisplayCounts();
            } catch(Exception ex) {
                ListDataGridView.DataSource=null;
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = "No hay ordenes de compras disponibles.";
            } else {
                ListCountLabel.Text = string.Format("{0} ordenes de compras encontradas.",ListDataGridView.Rows.Count.ToString());
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }

        private void GetRecordId() {
            idSelected = string.Empty;
            idClientSelected= string.Empty;
            currentAuction = Auction.CreateAuction();
            if(ListDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            DataGridViewRow row = ListDataGridView.CurrentRow;
            if(row == null) {
                return;
            }
            idSelected=  row.Cells[0].Value.ToString();
            idClientSelected=  row.Cells[1].Value.ToString();
            LoadBasicProperties(row);
            LoadOrderDetail(idSelected);
            LoadAuctionData(idSelected);
        }

        private void LoadOrderDetail(string orderID) {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                ProductDataGridView.DataSource = null;
                ProductDataGridView.DataSource = usecase.GetOrderDetailByID(orderID);
                DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
                IList<string> columns = new List<string>() { "id","id_pedido" };
                 configurator.HideColumns(columns);
                configurator.NumericIntegerColumn("Cantidad","Cantidad solicitada");
            } catch(Exception ex) {
                ProductDataGridView.DataSource= null;
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void LoadBasicProperties(DataGridViewRow row) {
            PropertiesDataGridView.Rows.Clear();
            PropertiesDataGridView.Rows.Add("Cliente",row.Cells["Cliente"].Value);
            PropertiesDataGridView.Rows.Add("Empresa",row.Cells["empresa"].Value);
            PropertiesDataGridView.Rows.Add("Domicilio", row.Cells["dir"].Value);
            PropertiesDataGridView.Rows.Add("Teléfono", row.Cells["fono"].Value);
            PropertiesDataGridView.Rows.Add("Fecha pedido",row.Cells["Fecha orden"].Value);
            PropertiesDataGridView.Rows.Add("Condición de pago",row.Cells["Condicion pago"].Value.ToString());
            PropertiesDataGridView.Rows.Add("Descuento solicitado",row.Cells["Descuento"].Value.ToString()+"%");
            PropertiesDataGridView.Rows.Add("Observación",row.Cells["Observacion"].Value);
        }

        private void LoadAuctionData(string idSelected) {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                currentAuction = usecase.GetAuctionById(idSelected);
                LoadAuctionProperties();
            } catch(Exception) {
                currentAuction = Auction.CreateAuction();
            }
        }

        private void LoadAuctionProperties() {
            if(currentAuction == null) {
                return;
            }
            PropertiesDataGridView.Rows.Add("Datos de subasta","".PadLeft(30,'-'));
            PropertiesDataGridView.Rows.Add("Fecha publicación",currentAuction.AuctionDate.ToShortDateString());
            PropertiesDataGridView.Rows.Add("Cantidad a transportar",currentAuction.Products.Count.ToString()+ " producto(s)");
            PropertiesDataGridView.Rows.Add("Valor inicial propuesto","$" + currentAuction.Value.ToString());
            PropertiesDataGridView.Rows.Add("Peso a transportar",currentAuction.Weight.ToString()+" KG");
            PropertiesDataGridView.Rows.Add("Fecha limite",currentAuction.LimitDate.ToShortDateString());
            string status = (currentAuction.Status.Equals(1) ? "Abierta" : (currentAuction.Status.Equals(2) ? "Finalizada" : "Cerrada por admin"));
            PropertiesDataGridView.Rows.Add("Estado",status);
        }

        private void ConfigureContextMenu() {
            bool thereAreRecords = !ListDataGridView.Rows.Count.Equals(0);
            OrderDistributeToolStripMenuItem.Visible=thereAreRecords && ListFilterComboBox.SelectedIndex.Equals(0);
            OrderAuctionToolStripMenuItem.Visible= thereAreRecords && ListFilterComboBox.SelectedIndex.Equals(1);
            OrderEditAuctionToolStripMenuItem.Visible= thereAreRecords && ListFilterComboBox.SelectedIndex.Equals(2);
            OrderAuctionResultToolStripMenuItem.Visible= thereAreRecords && ListFilterComboBox.SelectedIndex.Equals(2);
            OrderAuctionNotifyToolStripMenuItem.Visible= thereAreRecords && ListFilterComboBox.SelectedIndex.Equals(3);
        }

        private void OpenAuctionForm(bool isNewRecor) {
            AuctionForm form = new AuctionForm {
                IdSelected= idSelected,
                IsNewRecord= isNewRecor,
                CurrentAuction = currentAuction
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }

        private void EvaluateIfFormIsSaved(bool formSaved) {
            if(formSaved) {
                LoadOrders(ListFilterComboBox.SelectedIndex);
            }
        }

        private void OrderAuctionNotifyToolStripMenuItem_Click(object sender,EventArgs e) {
            ProductDispatchForm form = new ProductDispatchForm {
                IdSelected= idSelected,
                ClientID= this.idClientSelected,
                CustomerName= this.PropertiesDataGridView[1,0].Value.ToString(),
                IsNewRecord= true,
                CurrentAuction = currentAuction
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }
    }
}
