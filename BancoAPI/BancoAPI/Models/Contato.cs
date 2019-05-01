using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    abstract class Contato
    {
        public int ID { get; set; }
        public int TipoContato { get; set; }
        public string DescContato { get; set; }

        public Contato(int id,int tipo,string desc)
        {
            ID = id;
            TipoContato = tipo;
            DescContato = desc;
        }

        public class Telefone : Contato
        {
            public Telefone(int id, int tipo, string desc) : base(id, tipo, desc)
            {
            }
        }

        public class Celular : Contato
        {
            public Celular(int id, int tipo, string desc) : base(id, tipo, desc)
            {
            }
        }




    }
}