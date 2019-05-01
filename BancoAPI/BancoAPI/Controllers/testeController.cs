using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class testeController : ApiController
    {
        private static Teste test = new Teste();
        private static Pergunta perg = new Pergunta();

        [HttpGet,Route("api/teste/TodosTestes")]
        public IEnumerable<Teste> TodosTestes()
        {
            return test.TrazerTodosTestes();
        }

        [HttpGet,Route("api/teste/PegarTestesDoUsuario/{id}")]
        public IEnumerable<Teste> PegarTestesDoUsuario(int id)
        {
            return test.TrazerTestesDoUsuario(id);
        }

        [HttpPost,Route("api/teste/IniciarNovoTeste/{id}")]
        public void IniciarNovoTeste(int id)
        {
            perg.LimparLista();
            test.NovoTesteDoUsuario(id);
        }

        [HttpPost,Route("api/teste/CancelarTeste/{id}")]
        public void CancelarTeste(int id)
        {
            test.CancelarTeste(id);
        }

    }
}
