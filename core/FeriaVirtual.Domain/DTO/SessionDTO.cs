﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.DTO {

    public class SessionDTO {

        // Properties.
        public string SessionID { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }


        public SessionDTO() { }


    }
}
