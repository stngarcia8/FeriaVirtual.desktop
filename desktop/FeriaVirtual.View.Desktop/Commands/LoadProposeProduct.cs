using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Commands{

    public class LoadProposeProduct : ICommand{

        private readonly string idSelected;
        private bool onlyLoad;
        public DataGridView Data{ get; }



        private LoadProposeProduct(DataGridView datagrid, string idSelected, bool onlyLoad){
            Data = datagrid;
            this.idSelected = idSelected;
            this.onlyLoad=onlyLoad;
        }


        public void Execute(){
            LoadProducts();
        }


        public static LoadProposeProduct OpenPropose(DataGridView datagrid, string idSelected, bool onlyLoad){
            return new LoadProposeProduct(datagrid, idSelected, onlyLoad);
        }


        private void LoadProducts() {
            try{
                var usecase = OrderUseCase.CreateUseCase();
                Data.DataSource = null;
                if (this.onlyLoad){
                    Data.DataSource = usecase.GetOnlyGenerateProposeProduct(idSelected);
                }
                else{
                    Data.DataSource = usecase.GetGenerateProposeProduct(idSelected);
                }
                ConfigureProductGrid();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ConfigureProductGrid(){
            var configurator = DataGridViewConfigurator.CreateConfigurator(Data);
            IList<string> columns = new List<string>{"id_respuesta", "id_pedido"};
            configurator.HideColumns(columns);
            configurator.NumericIntegerColumn("Stock disponible", "Stock disponible");
            configurator.NumericIntegerColumn("Cantidad solicitada", "Cantidad solicitada");
            configurator.CurrencyColumn("Valor KG", "Valor KG");
            configurator.CurrencyColumn("Total", "Valor KG");
        }

    }

}