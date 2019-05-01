using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class questaoController : ApiController
    {
        private static Pergunta perg = new Pergunta();
        private static Resposta resp = new Resposta();

        [HttpGet,Route("api/questao/TodasPerguntas")]
        public IEnumerable<Pergunta> TodasPerguntas()
        {
            return perg.PegarTodasPerguntas();
        }

        [HttpGet,Route("api/questao/GerarPergunta")]
        public Pergunta GerarPergunta()
        {
            return perg.GerarPerguntaAleatoria();
        }

        [HttpGet,Route("api/questao/TodasRespostas")]
        public IEnumerable<Resposta> TodasRespostas()
        {
            return resp.PegarTodasRespostas();
        }

        [HttpGet,Route("api/questao/PegarRespostaDaPergunta/{id_perg}")]
        public IEnumerable<Resposta> PegarRespostaDaPergunta(int id_perg)
        {
            return resp.PegarRespostaDaPergunta(id_perg);
        }
    }
}
