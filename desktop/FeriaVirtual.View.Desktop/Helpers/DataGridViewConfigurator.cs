using System.Collections.Generic;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Helpers {

    public class DataGridViewConfigurator {
        private readonly DataGridView datagrid;

        // Constructor
        private DataGridViewConfigurator(DataGridView datagrid) {
            this.datagrid= datagrid;
        }

        // Named constructor
        public static DataGridViewConfigurator CreateConfigurator(DataGridView datagrid) {
            return new DataGridViewConfigurator(datagrid);
        }

        // Public methods.
        public void HideColumns(IList<string> columns) {
            foreach(string column in columns) {
                datagrid.Columns[column].Visible= false;
            }
        }




    }
}