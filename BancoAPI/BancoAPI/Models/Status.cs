using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Status
    {
        public string StatusLogin { get; set; }
        public int FezTeste{ get; set; }

        public Status(string sts)
        {
            StatusLogin = sts;
        }

        public Status(int sts)
        {
            FezTeste = sts;
        }
    }
}