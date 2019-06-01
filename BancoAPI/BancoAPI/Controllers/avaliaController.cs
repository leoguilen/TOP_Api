using BancoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class avaliaController : ApiController
    {
        private Avaliacao avalia = new Avaliacao();

        [HttpPost, Route("api/avalia/InsereAvaliacao")]
        public void InsereAvaliacao(int user_id, int test_id, int avalia_qtde, string avalia_comentario)
        {
            avalia.NovaAvaliacao(new Avaliacao { UserID = user_id, TestID = test_id, QtdeRatings = avalia_qtde, Comentario = avalia_comentario });
        }

    }
}
