using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Orders{

    public partial class ExternalOrderForm : Form{

        private readonly IProfileInfo profile;

        private Auction currentAuction;
        private OrderDispatch currentOrderDispatch;
        private string idClientSelected;
        private string idSelected;
        private int nodeIndex;


        public ExternalOrderForm(IProfileInfo profile){
            InitializeComponent();
            this.profile = profile;
            idSelected = string.Empty;
            idClientSelected = string.Empty;
            nodeIndex = 0;
        }


        private void ExternalOrderForm_Load(object sender, EventArgs e){
            Text = $"Control de ordenes de compra ({profile.ProfileName}).";
            ConfigureForm();
            ListDataGridView.Focus();
        }


        private void OptionRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadOrders(nodeIndex);
        }


        private void OptionCloseToolStripMenuItem_Click(object sender, EventArgs e){
            Close();
        }


        private void OptionsFilterTreeView_AfterSelect(object sender, TreeViewEventArgs e){
            if (e.Node.Level.Equals(0)) return;

            ListTitleLabel.Text = $"Lista de {e.Node.Text}";
            nodeIndex = e.Node.Index;
            LoadOrders(nodeIndex);
        }


        private void ListDataGridView_SelectionChanged(object sender, EventArgs e){
            GetRecordId();
        }


        private void OrderContextMenuStrip_Opening(object sender, CancelEventArgs e){
            ConfigureContextMenu();
        }


        private void OrderRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadOrders(nodeIndex);
            ListDataGridView.Focus();
        }


        private void OrderDistributeToolStripMenuItem_Click(object sender, EventArgs e){
            var form = new ProposeProductsForm{
                IdSelected = idSelected
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }


        private void OrderAuctionToolStripMenuItem_Click(object sender, EventArgs e){
            OpenAuctionForm(true);
        }


        private void OrderEditAuctionToolStripMenuItem_Click(object sender, EventArgs e){
            OpenAuctionForm(false);
        }


        private void OrderAuctionResultToolStripMenuItem_Click(object sender, EventArgs e){
            var form = new AuctionResultForm{
                CurrentAuction = currentAuction,
                IdSelected = idSelected
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }


        private void OrderAuctionNotifyToolStripMenuItem_Click(object sender, EventArgs e){
            OpenOrderDispatchForm(true);
        }


        private void OrderDispachViewToolStripMenuItem_Click(object sender, EventArgs e){
            OpenOrderDispatchForm(false);
        }


        private void ConfigureForm(){
            LoadFilters();
            LoadOrders(nodeIndex);
        }


        private void LoadFilters(){
            OptionsFilterTreeView.BeginUpdate();
            OptionsFilterTreeView.Nodes.Clear();
            IList<string> filterOptions = new List<string>{
                "Ordenes recepcionadas", "Ordenes con propuesta generada", "Ordenes con subastas publicadas",
                "Ordenes subastadas", "Ordenes despachadas"
            };
            var configurator =
                FilterNodeConfigurator.CreateConfigurator("Ordenes de compra", filterOptions);
            OptionsFilterTreeView.Nodes.Add(configurator.GetNodes());
            OptionsFilterTreeView.ExpandAll();
            OptionsFilterTreeView.SelectedNode = OptionsFilterTreeView.Nodes[0];
            OptionsFilterTreeView.Select();
            OptionsFilterTreeView.Focus();
            OptionsFilterTreeView.EndUpdate();
        }


        private void LoadOrders(int filterType){
            try{
                var usecase = OrderUseCase.CreateUseCase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = usecase.GetOrderByStatus(filterType + 1, profile.ProfileId);
                var configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>{
                    "id_pedido", "id_cliente", "id_estado", "id_condicion", "Condicion pago", "id_rol",
                    "estado_subasta", "empresa", "dir", "fono", "observacion"
                };
                configurator.HideColumns(columns);
                configurator.ChangeHeader("Observacion", "Observación");
                configurator.NumericColumn("Descuento", "Descuento");
                DisplayCounts();
            }
            catch (Exception ex){
                ListDataGridView.DataSource = null;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = "No hay ordenes de compras disponibles.";
                PropertiesDataGridView.Rows.Clear();
                ProductDataGridView.DataSource = null;
            }
            else{
                ListCountLabel.Text = $"{ListDataGridView.Rows.Count.ToString()} ordenes de compras encontradas.";
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }


        private void GetRecordId(){
            idSelected = string.Empty;
            idClientSelected = string.Empty;
            currentAuction = Auction.CreateAuction();
            if (ListDataGridView.Rows.Count.Equals(0)) return;

            var row = ListDataGridView.CurrentRow;
            if (row == null) return;

            idSelected = row.Cells[0].Value.ToString();
            idClientSelected = row.Cells[1].Value.ToString();
            LoadBasicProperties(row);
            LoadOrderDetail(idSelected);
            LoadAuctionData(idSelected);
            LoadOrderDispatchData(idSelected);
        }


        private void LoadOrderDetail(string orderId){
            try{
                var usecase = OrderUseCase.CreateUseCase();
                ProductDataGridView.DataSource = null;
                ProductDataGridView.DataSource = usecase.GetOrderDetailById(orderId);
                var configurator = DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
                IList<string> columns = new List<string>{"id", "id_pedido"};
                configurator.HideColumns(columns);
                configurator.NumericIntegerColumn("Cantidad", "Cantidad solicitada");
            }
            catch (Exception ex){
                ProductDataGridView.DataSource = null;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void LoadBasicProperties(DataGridViewRow row){
            PropertiesDataGridView.Rows.Clear();
            PropertiesDataGridView.Rows.Add("Cliente", row.Cells["Cliente"].Value);
            PropertiesDataGridView.Rows.Add("Empresa", row.Cells["empresa"].Value);
            PropertiesDataGridView.Rows.Add("Domicilio", row.Cells["dir"].Value);
            PropertiesDataGridView.Rows.Add("Teléfono", row.Cells["fono"].Value);
            PropertiesDataGridView.Rows.Add("Fecha pedido", row.Cells["Fecha orden"].Value);
            PropertiesDataGridView.Rows.Add("Condición de pago", row.Cells["Condicion pago"].Value.ToString());
            PropertiesDataGridView.Rows.Add("Descuento solicitado", row.Cells["Descuento"].Value + "%");
            PropertiesDataGridView.Rows.Add("Observación", row.Cells["Observacion"].Value);
        }


        private void LoadAuctionData(string idSelected){
            try{
                var usecase = AuctionUseCase.CreateUseCase();
                currentAuction = usecase.GetAuctionById(idSelected);
                LoadAuctionProperties();
            }
            catch (Exception){
                currentAuction = Auction.CreateAuction();
            }
        }


        private void LoadAuctionProperties(){
            if (currentAuction == null) return;

            PropertiesDataGridView.Rows.Add("Datos de subasta", "".PadLeft(30, '-'));
            PropertiesDataGridView.Rows.Add("Fecha publicación", currentAuction.AuctionDate.ToShortDateString());
            PropertiesDataGridView.Rows.Add("Cantidad a transportar", currentAuction.Products.Count + " producto(s)");
            PropertiesDataGridView.Rows.Add("Valor inicial propuesto", "$" + currentAuction.Value);
            PropertiesDataGridView.Rows.Add("Peso a transportar", currentAuction.Weight + " KG");
            PropertiesDataGridView.Rows.Add("Fecha limite", currentAuction.LimitDate.ToShortDateString());
            var status = currentAuction.Status.Equals(1) ? "Abierta" :
                currentAuction.Status.Equals(2) ? "Finalizada" : "Cerrada por admin";
            PropertiesDataGridView.Rows.Add("Estado", status);
        }


        private void LoadOrderDispatchData(string idSelected){
            try{
                var usecase = OrderDispatchUseCase.CreateUseCase();
                currentOrderDispatch = usecase.GetOrderDispatchById(idSelected);
            }
            catch (Exception){
                currentOrderDispatch = OrderDispatch.CreateOrder();
            }
        }


        private void ConfigureContextMenu(){
            var thereAreRecords = !ListDataGridView.Rows.Count.Equals(0);
            OrderDistributeToolStripMenuItem.Visible = thereAreRecords && nodeIndex.Equals(0);
            OrderAuctionToolStripMenuItem.Visible = thereAreRecords && nodeIndex.Equals(1);
            OrderEditAuctionToolStripMenuItem.Visible = thereAreRecords && nodeIndex.Equals(2);
            OrderAuctionResultToolStripMenuItem.Visible = thereAreRecords && nodeIndex.Equals(2);
            OrderAuctionNotifyToolStripMenuItem.Visible = thereAreRecords && nodeIndex.Equals(3);
            OrderDispachViewToolStripMenuItem.Visible = thereAreRecords && nodeIndex.Equals(4);
        }


        private void OpenAuctionForm(bool isNewRecor){
            var form = new AuctionForm{
                IdSelected = idSelected,
                IsNewRecord = isNewRecor,
                CurrentAuction = currentAuction
            };
            form.ShowDialog();
            EvaluateIfFormIsSaved(form.IsSaved);
        }


        private void EvaluateIfFormIsSaved(bool formSaved){
            if (formSaved) LoadOrders(nodeIndex);
        }


        private void OpenOrderDispatchForm(bool isNew){
            var form = new ProductDispatchForm{
                IdSelected = idSelected,
                ClientId = idClientSelected,
                CustomerName = PropertiesDataGridView[1, 0].Value.ToString(),
                CurrentDispatch = currentOrderDispatch,
                IsNewRecord = isNew,
                CurrentAuction = currentAuction
            };
            form.ShowDialog();
            if (form.IsRemoveBidValue) currentOrderDispatch = null;

            if (form.IsSaved) currentOrderDispatch = form.CurrentDispatch;

            LoadOrders(nodeIndex);
        }

    }

}