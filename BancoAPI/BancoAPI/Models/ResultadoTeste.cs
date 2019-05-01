using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class ResultadoTeste
    {
        private bd_top bd = new bd_top();

        public int IdUsuario { get; set; }
        public int IdTeste { get; set; }
        public int IdCurso { get; set; }
        public double PontosExatas { get; set; }
        public double PontosHumanas { get; set; }
        public double PontosBiologicas { get; set; }

        public ResultadoTeste()
        {

        }

        public ResultadoTeste(tb_detalhesResultado det_result)
        {
            IdUsuario = det_result.userResult_in_id;
            IdTeste = det_result.testResult_in_id;
            IdCurso = det_result.curResult_in_id;
            PontosExatas = det_result.result_re_pontosExatas;
            PontosHumanas = det_result.result_re_pontosHumanas;
            PontosBiologicas = det_result.result_re_pontosBiologicas;
        }

        public IEnumerable<ResultadoTeste> PegarTodosDetalhesDosResultados()
        {
            List<ResultadoTeste> _listDetResult = new List<ResultadoTeste>();
            var results = from res in bd.tb_detalhesResultado select res;

            foreach (var itemRes in results)
            {
                _listDetResult.Add(new ResultadoTeste(itemRes));
            }

            return _listDetResult;

        }
        public IEnumerable<ResultadoTeste> PegarDetalhesDosResultadosDoUsuario(int id_teste)
        {
            List<ResultadoTeste> _listDetResult = new List<ResultadoTeste>();
            var results = from res in bd.tb_detalhesResultado.Where(r=>r.testResult_in_id == id_teste) select res;

            foreach (var itemRes in results)
            {
                _listDetResult.Add(new ResultadoTeste(itemRes));
            }

            return _listDetResult;
        }
        
        public void FinalizarTeste(string user, double vE, double vH, double vB)
        {
            //Pegando ID do usuario logado
            int id_user = 0;

            foreach (var itemUs in from us in bd.tb_usuario.Where(u => u.user_st_username.Equals(user)) select us)
            {
                id_user = itemUs.user_in_id;
            }

            //Verificando qual area tem o maior valor
            char DescArea;
            int maiorValor;
            int id_curso = 0;
            double VE = vE, VH = vH, VB = vB;

            if (VE > VH && VE > VB)
            {
                DescArea = 'E';
                maiorValor = (int)VE;
            }
            else if (VH > VE && VH > VB)
            {
                DescArea = 'H';
                maiorValor = (int)VH;
            }
            else
            {
                DescArea = 'B';
                maiorValor = (int)VB;
            }


            //Busca o ID do curso pelo resultado da estrutura de decisão acima
            switch (DescArea)
            {
                case 'E':
                    {
                        foreach (var itemID in from cur in bd.tb_curso where cur.areaCur_in_id == 1 
                                               && maiorValor >= cur.cur_in_valorMin && maiorValor <= cur.cur_in_valorMax select cur)
                        {
                            id_curso = itemID.cur_in_id;
                        }
                        break;
                    }
                case 'H':
                    {
                        foreach (var itemID in from cur in bd.tb_curso where cur.areaCur_in_id == 2
                                                && maiorValor >= cur.cur_in_valorMin && maiorValor <= cur.cur_in_valorMax select cur)
                        {
                            id_curso = itemID.cur_in_id;
                        }
                        break;
                    }
                case 'B':
                    {
                        foreach (var itemID in from cur in bd.tb_curso where cur.areaCur_in_id == 3
                                                && maiorValor >= cur.cur_in_valorMin && maiorValor <= cur.cur_in_valorMax select cur)
                        {
                            id_curso = itemID.cur_in_id;
                        }
                        break;
                    }
                default:
                    break;
                    
            }

            //Pegando ID do teste que o usuario acabou de fazer 
            int id_teste = 0;

            foreach (var itemId in from test in bd.tb_teste.Where(t => t.userTeste_in_id == id_user && t.teste_bool_novoTeste == 1) select test) 
            {
                id_teste = itemId.teste_in_id;
            }

            //Terminando teste e inserindo os detalhes no banco de dados
            bd.sp_inserirDetalhesDoResultado(id_user, id_teste, id_curso, vE, vH, vB);
            
        }
    }
}