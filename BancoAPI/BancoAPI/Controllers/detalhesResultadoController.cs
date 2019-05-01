using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class detalhesResultadoController : ApiController
    {
        private static ResultadoTeste resTeste = new ResultadoTeste();

        [HttpGet,Route("api/detalhesResultado/TodosDetalhesDosTestes")]
        public IEnumerable<ResultadoTeste> TodosDetalhesDosTestes()
        {
            return resTeste.PegarTodosDetalhesDosResultados();
        }

        [HttpGet, Route("api/detalhesResultado/DetalhesDosTestesDoUsuario/{id}")]
        public IEnumerable<ResultadoTeste> DetalhesDosTestesDoUsuario(int id_teste)
        {
            return resTeste.PegarDetalhesDosResultadosDoUsuario(id_teste);
        }

        [HttpPost,Route("api/detalhesResultado/CalcularResultadoDaCompatibilidade/{user}/{ve}/{vh}/{vb}")]
        public void CalcularResultadoDaCompatibilidade(string user, double ve,double vh,double vb)
        {
            resTeste.FinalizarTeste(user,ve,vh,vb);
        }


    }
}
