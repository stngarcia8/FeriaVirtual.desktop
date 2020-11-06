using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.View.Desktop.Helpers;

namespace FeriaVirtual.View.Desktop.Commands {

    public class LoadProposeProduct:ICommand {
        private DataGridView datagrid;
        private string idSelected;
        public DataGridView Data => datagrid;

        // Constructor
        private LoadProposeProduct(DataGridView datagrid, string idSelected) {
            this.datagrid= datagrid;
            this.idSelected= idSelected;
        }

        // Named constructor
        public static LoadProposeProduct OpenPropose(DataGridView datagrid, string idSelected) {
            return new LoadProposeProduct(datagrid, idSelected);
        }

        public void Execute() {
            LoadProducts();
        }

        private void LoadProducts() {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                datagrid.DataSource= null;
                datagrid.DataSource = usecase.GetGenerateProposeProduct(idSelected);
                ConfigureProductGrid();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void ConfigureProductGrid() {
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(datagrid);
            IList<string> columns = new List<string>() { "id_respuesta","id_pedido" };
            configurator.HideColumns(columns);
            configurator.NumericIntegerColumn("Stock disponible","Stock disponible");
            configurator.NumericIntegerColumn("Cantidad solicitada","Cantidad solicitada");
            configurator.CurrencyColumn("Valor KG","Valor KG");
            configurator.CurrencyColumn("Total","Valor KG");
        }
    }
}
