using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Resultado
    {
        private bd_top bd = new bd_top();

        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public int IdTeste { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int TempoConclusao { get; set; }
        public double ResultadoExatas { get; set; }
        public double ResultadoHumanas { get; set; }
        public double ResultadoBiologicas { get; set; }
        public string NomeCurso { get; set; }
        public string TipoCurso { get; set; }
        public string DuracaoCurso { get; set; }
        public string DescArea { get; set; }
        public string ImagemCurso { get; set; }
        public string NomeFaculdade { get; set; }
        public string EstadoFaculdade { get; set; }
        public string SiteFaculdade { get; set; }
        public int NotaMEC { get; set; }
        public byte NovoTeste { get; set; }

        public Resultado()
        {

        }

        public Resultado(v_relatorioResultado relResult)
        {
            IdUsuario = relResult.id_user;
            Username = relResult.username_user;
            IdTeste = relResult.id_teste;
            DataInicio = relResult.inicio_teste;
            DataFim = relResult.final_teste;
            TempoConclusao = 0;
            ResultadoExatas = relResult.exatas_resultado;
            ResultadoHumanas = relResult.humanas_resultado;
            ResultadoBiologicas = relResult.biologicas_resultado;
            NomeCurso = relResult.nome_curso;
            TipoCurso = relResult.tipo_curso;
            DuracaoCurso = relResult.duracao_curso;
            DescArea = relResult.desc_area;
            ImagemCurso = relResult.img_curso;
            NomeFaculdade = relResult.nome_facul;
            EstadoFaculdade = relResult.estado_facul;
            SiteFaculdade = relResult.site_facul;
            NotaMEC = relResult.valor_notaMec;
            NovoTeste = relResult.novo_teste;
        }

        public IEnumerable<Resultado> PegarTodosResultados()
        {
            List<Resultado> _listResult = new List<Resultado>();
            foreach (var res in from r in bd.v_relatorioResultado select r)
            {
                _listResult.Add(new Resultado(res));
            }

            return _listResult;
        }

        public IEnumerable<Resultado> TrazerResultadoUsuario(string user)
        {
            List<Resultado> _listResult = new List<Resultado>();
            foreach (var res in from r in bd.v_relatorioResultado.Where(res => res.username_user.Equals(user)) select r)
            {
                _listResult.Add(new Resultado(res));
            }

            return _listResult;

        }

    }
}