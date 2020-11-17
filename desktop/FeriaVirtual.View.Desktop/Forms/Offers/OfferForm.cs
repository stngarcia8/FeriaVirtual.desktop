using System;
using System.Windows.Forms;
using System.ComponentModel;
using FeriaVirtual.Business.Offers;
using FeriaVirtual.Domain.Offers;
using FeriaVirtual.View.Desktop.Helpers;
using System.Collections.Generic;


namespace FeriaVirtual.View.Desktop.Forms.Offers{

    public partial class OfferForm : Form{

        private Offer currentOffer;
        private string idSelected;
        private int nodeIndex;



        public OfferForm(){
            InitializeComponent();
            idSelected = string.Empty;
        }

        private void OfferForm_Load(object sender,System.EventArgs e) {
            ConfigureForm();
            ListDataGridView.Focus();
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,System.EventArgs e) {

        }

        private void OptionCloseToolStripMenuItem_Click(object sender,System.EventArgs e){
            this.Close();
        }

        private void OptionsFilterTreeView_AfterSelect(object sender,TreeViewEventArgs e) {
            if (e.Node.Level.Equals(0)) return;
            ListTitleLabel.Text = $"Lista de {e.Node.Text}";
            nodeIndex = e.Node.Index;
            LoadOrders(nodeIndex);
        }

        private void ListDataGridView_SelectionChanged(object sender,System.EventArgs e) {
            //GetRecordId();
        }

        private void OrderContextMenuStrip_Opening(object sender,CancelEventArgs e) {

        }

        private void ConfigureForm(){
            LoadFilters();
            LoadOrders(nodeIndex);
        }

        private void LoadFilters(){
            OptionsFilterTreeView.BeginUpdate();
            OptionsFilterTreeView.Nodes.Clear();
            IList<string> filterOptions = new List<string>{
                "Ofertas publicadas", "Ofertas pasadas", "Oferta de saldos"
            };
            var configurator =
                FilterNodeConfigurator.CreateConfigurator("Ofertas", filterOptions);
            OptionsFilterTreeView.Nodes.Add(configurator.GetNodes());
            OptionsFilterTreeView.ExpandAll();
            OptionsFilterTreeView.SelectedNode = OptionsFilterTreeView.Nodes[0];
            OptionsFilterTreeView.Select();
            OptionsFilterTreeView.Focus();
            OptionsFilterTreeView.EndUpdate();
        }

        private void LoadOrders(int filterType){
            try{
                var usecase = OfferUseCase.CreateUsecase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = usecase.FindOffersByStatus(this.nodeIndex);
                var configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>{
                    "id_oferta", "estado_oferta"
                };
                configurator.HideColumns(columns);
                configurator.ChangeHeader("Descripcion", "Descripción");
                configurator.ChangeHeader("Fecha publicacion", "Fecha publicación");
                configurator.NumericColumn("Descuento", "Descuento");
                //DisplayCounts();
            }
            catch (Exception ex){
                ListDataGridView.DataSource = null;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }







    }

}