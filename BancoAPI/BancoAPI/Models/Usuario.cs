using BancoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BancoAPI.Models
{
    public class Usuario
    {
        private bd_top bd = new bd_top();

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public int NivelAcademico { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte FezTeste { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }

        public Usuario()
        {

        }

        public Usuario(tb_usuario us)
        {
            ID = us.user_in_id;
            Nome = us.user_st_nome;
            Sexo = us.user_st_sexo;
            DataNascimento = us.user_dt_dtNasc;
            Username = us.user_st_username;
            Senha = us.user_st_senha;
            Uf = us.user_st_uf;
            Cidade = us.user_st_cidade;
            NivelAcademico = us.user_in_nivelAcad;
            DataCadastro = us.user_dt_dtCad;
            FezTeste = us.user_bool_fezTeste;
            Avatar = us.user_img_avatar;
            Bio = us.user_st_bio;
        }

        public IEnumerable<Usuario> PegarTodosUsuarios()
        {
            List<Usuario> _listUsers = new List<Usuario>();
            foreach (var users in from us in bd.tb_usuario select us)
            {
                _listUsers.Add(new Usuario(users));
            }

            return _listUsers;
        }

        public Usuario BuscarUsuarioPorNome(int id)
        {
            if(id==0)
            {
                return null;
            } else
            {
                var user = (from us in bd.tb_usuario.Where(u => u.user_in_id == id) select us).FirstOrDefault();
                return new Usuario(user);
            } 
            
        }

        public async void CadastrarNovoUsuario(Usuario us,string email,string cel)
        {
            bd.sp_inserirNovoUsuario(us.Nome, us.Sexo, us.DataNascimento, us.Username, us.Senha, us.Uf, us.Cidade, us.NivelAcademico, DateTime.Now, us.FezTeste, us.Avatar, us.Bio);
            bd.sp_inserirNovoEmail(us.Username, email);
            bd.sp_inserirNovosContatos(us.Username,null, cel);
            await bd.SaveChangesAsync();
        }

        public bool ValidarLogin(string user, string senha)
        {
            bool resultado = false;

            using (SqlConnection cnx = new SqlConnection(@"Server=HS-35722\SQLEXPRESS; Database=bd_top;uid=sa;pwd=S@server2019"))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT dbo.func_validaLogin ('"+user+"','"+senha+"') as sts", cnx))
                {
                    object res = cmd.ExecuteScalar();

                    if (res.ToString().Equals("Invalido"))
                        resultado = false;
                    else
                        resultado = true;
                }
            }

            return resultado;
        }

        public int VerificarSeFezTeste(string user)
        {
            var seeUser = (from us in bd.tb_usuario.Where(u => u.user_st_username.Equals(user)) select new { us.user_bool_fezTeste }).FirstOrDefault();

            return seeUser.user_bool_fezTeste;
        }
        
        public Usuario RetornarIdUsuario(string user_logado)
        {
            tb_usuario user = (from us in bd.tb_usuario.Where(u => u.user_st_username.Equals(user_logado)) select us).FirstOrDefault();

            return new Usuario(user);
        }
    }
}