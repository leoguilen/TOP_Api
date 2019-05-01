using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Pergunta
    {
        private static bd_top bd = new bd_top();
        List<int> jaGerados = new List<int>();

        public int IdPergunta { get; set; }
        public string DescPergunta { get; set; }

        public Pergunta() {}

        public Pergunta(int id,string desc_perg) { IdPergunta = id; DescPergunta = desc_perg; }

        public IEnumerable<Pergunta> PegarTodasPerguntas()
        {
            List<Pergunta> _listPerg = new List<Pergunta>();
            foreach (var perg in from p in bd.tb_pergunta select p)
            {
                _listPerg.Add(new Pergunta(perg.perg_in_id,perg.perg_st_desc));
            }

            return _listPerg;
        }

        public void LimparLista()
        {
            jaGerados.Clear();
        }

        public Pergunta GerarPerguntaAleatoria()
        {
            List<int> disponiveis = new List<int>();
            Random rand = new Random();
            int totalPergs = (from perg in bd.tb_pergunta select perg).Count();

            List<int> pergIds = (from pergs in bd.tb_pergunta orderby pergs.perg_in_id ascending select pergs.perg_in_id).ToList();

            foreach (int itemPergDisp in pergIds.Except(jaGerados))
            {
                disponiveis.Add(itemPergDisp);
            }

            Random rand2 = new Random(DateTime.Now.Millisecond);
            int result = disponiveis[rand.Next(disponiveis.Count)];

            var pergNova = (from pgta in bd.tb_pergunta.Where(p => p.perg_in_id == result) select pgta).FirstOrDefault();
   
            jaGerados.Add(result);

            if(jaGerados.Count == totalPergs)
            {
                jaGerados.Clear();
            }

            return new Pergunta(pergNova.perg_in_id, pergNova.perg_st_desc);
        }

        
    }
}