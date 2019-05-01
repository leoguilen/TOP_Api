using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Teste
    {
        private bd_top bd = new bd_top();

        public int IdTeste { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public byte NovoTeste { get; set; }

        public Teste()
        {

        }

        public Teste(tb_teste test)
        {
            IdTeste = test.teste_in_id;
            IdUsuario = test.userTeste_in_id;
            DataInicio = test.teste_dt_inicio;
            DataFinal = test.teste_dt_final;
            NovoTeste = test.teste_bool_novoTeste;
        }

        public IEnumerable<Teste> TrazerTodosTestes()
        {
            List<Teste> _listTeste = new List<Teste>();
            var testes = from tes in bd.tb_teste select tes;

            foreach (var itemTest in testes)
            {
                _listTeste.Add(new Teste(itemTest));
            }

            return _listTeste;

        }

        public IEnumerable<Teste> TrazerTestesDoUsuario(int id_user)
        {
            List<Teste> _listTeste = new List<Teste>();
            var testes = from tes in bd.tb_teste.Where(t=>t.userTeste_in_id == id_user) select tes;

            foreach (var itemTest in testes)
            {
                _listTeste.Add(new Teste(itemTest));
            }

            return _listTeste;
        }

        public async void NovoTesteDoUsuario(int id)
        {
            int temTeste = (from t in bd.tb_teste.Where(t => t.userTeste_in_id == id) select t).Count();

            if(temTeste > 0)
            {
                bd.sp_novoTeste(id);
                bd.sp_iniciarTeste(id, DateTime.Now);
            } else
            {
                bd.sp_iniciarTeste(id, DateTime.Now);
            }

            await bd.SaveChangesAsync();
        }

        public void CancelarTeste(int id)
        {
            foreach (var itemDelete in from test in bd.tb_teste.Where(t=>t.userTeste_in_id == id && t.teste_bool_novoTeste == 1) select test)
            {
                bd.tb_teste.Remove(itemDelete);
            }
            
            bd.SaveChanges();
        }
    }
}