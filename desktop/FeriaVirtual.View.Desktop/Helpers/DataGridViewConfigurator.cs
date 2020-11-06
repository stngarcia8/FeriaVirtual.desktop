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

        public void NumericColumn(string colName,string headerText) {
            datagrid.Columns[colName].HeaderText = headerText;
            datagrid.Columns[colName].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[colName].AutoSizeMode= DataGridViewAutoSizeColumnMode.ColumnHeader;
            datagrid.Columns[colName].DefaultCellStyle.Format="N2";
        }

        public void NumericIntegerColumn(string colName,string headerText) {
            datagrid.Columns[colName].HeaderText = headerText;
            datagrid.Columns[colName].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[colName].AutoSizeMode= DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        public void CurrencyColumn(string colName,string headerText) {
            datagrid.Columns[colName].HeaderText = headerText;
            datagrid.Columns[colName].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            datagrid.Columns[colName].AutoSizeMode= DataGridViewAutoSizeColumnMode.ColumnHeader;
            datagrid.Columns[colName].DefaultCellStyle.Format="C0";
        }

        public void ChangeHeader(string colName,string headerText) {
            datagrid.Columns[colName].HeaderText = headerText;
        }

    }
}