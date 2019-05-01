using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Resposta
    {
        private bd_top bd = new bd_top();

        public int IdResposta { get; set; }
        public int IdPergunta { get; set; }
        public string DescResposta { get; set; }
        public double ValorExatas { get; set; }
        public double ValorHumanas { get; set; }
        public double ValorBiologicas { get; set; }

        public Resposta()
        {

        }

        public Resposta(int id_resp,int id_perg,string desc_resp,double v_exa,double v_hum,double v_bio)
        {
            IdResposta = id_resp;
            IdPergunta = id_perg;
            DescResposta = desc_resp;
            ValorExatas = v_exa;
            ValorHumanas = v_hum;
            ValorBiologicas = v_bio;
        }

        public IEnumerable<Resposta> PegarTodasRespostas()
        {
            List<Resposta> _listResp = new List<Resposta>();
            foreach (var resp in from r in bd.tb_resposta select r)
            {
                _listResp.Add(new Resposta(resp.resp_in_id,resp.perg_in_id,resp.resp_st_desc,resp.resp_re_resExatas,resp.resp_re_resHumanas,resp.resp_re_resBiologicas));
            }

            return _listResp;
        }

        public IEnumerable<Resposta> PegarRespostaDaPergunta(int id_perg)
        {
            List<Resposta> _listResp = new List<Resposta>();
            foreach (var resp in from r in bd.tb_resposta.Where(r=>r.perg_in_id == id_perg)select r)
            {
                _listResp.Add(new Resposta(resp.resp_in_id, resp.perg_in_id, resp.resp_st_desc, resp.resp_re_resExatas, resp.resp_re_resHumanas,resp.resp_re_resBiologicas));
            }

            return _listResp;
        }


    }
}