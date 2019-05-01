using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string DescEmail { get; set; }

        public Email(int id,string descMail)
        {
            ID = id;
            descMail = DescEmail;
        }   


    }
}