using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Avaliacao
    {
        private bd_top bd = new bd_top();

        public int UserID { get; set; }
        public int TestID { get; set; }
        public int QtdeRatings { get; set; }
        public string Comentario { get; set; }

        public Avaliacao()
        {

        }

        public Avaliacao(tb_avaliacao avaliacao)
        {
            UserID = avaliacao.user_in_id;
            QtdeRatings = avaliacao.ava_in_ratings;
            Comentario = avaliacao.ava_st_comentario;
        }

        public async void NovaAvaliacao(Avaliacao ava)
        {
            bd.sp_inserirAvaliacao(ava.UserID, ava.TestID, ava.QtdeRatings, ava.Comentario);
            await bd.SaveChangesAsync();
        }



    }
}