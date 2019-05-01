using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class resultadoController : ApiController
    {
        private static Resultado result = new Resultado();

        [HttpGet,Route("api/resultado/TodosResultados")]
        public IEnumerable<Resultado> TodosResultados()
        {
            return result.PegarTodosResultados();
        }

        [HttpGet,Route("api/resultado/TrazerResultado/{user}")]
        public IEnumerable<Resultado> TrazerResultado(string user)
        {
            return result.TrazerResultadoUsuario(user);
        }
    }
}
