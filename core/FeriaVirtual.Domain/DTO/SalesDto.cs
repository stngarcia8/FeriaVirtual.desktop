using System;
using System.Collections.Generic;


namespace FeriaVirtual.Domain.Dto{

    public class SalesDto{

        public string ProducerName{ get; set; }
        public string ProducerEmail{ get; set; }
        public DateTime SalesDate{ get; set; }
        public IList<SalesProductDto> Products{ get; set; }


        public SalesDto(){
            ProducerName = string.Empty;
            ProducerEmail = string.Empty;
            SalesDate = DateTime.Now.Date;
            Products = new List<SalesProductDto>();
        }

    }

}