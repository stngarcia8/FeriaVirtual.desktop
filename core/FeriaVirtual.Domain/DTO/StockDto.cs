using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.Dto {
    public class StockDto {

        public string ProductId{get;set;}
        public int Stock{get;set;}


        public StockDto(){
            ProductId = string.Empty;
            Stock = 0;
        }

    }
}
