using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.Dto {
    public class ChangeMessageStatus {

        public string Id{get;set;}
        public int Status{get;set;}


        private ChangeMessageStatus(string id, int status){
            this.Id= id;
            this.Status= status;
        }


        public static ChangeMessageStatus Create(string id, int status){
            return new ChangeMessageStatus(id, status);
        }


    }
}
