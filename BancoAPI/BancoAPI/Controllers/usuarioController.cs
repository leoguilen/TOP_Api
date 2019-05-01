using BancoAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace BancoAPI.Controllers
{
    public class usuarioController : ApiController
    {
        private static Usuario us = new Usuario();

        [HttpGet, Route("api/usuario/TodosUsuario")]
        public IEnumerable<Usuario> TodosUsuario()
        {
            return us.PegarTodosUsuarios();
        }

        [HttpGet, Route("api/usuario/BuscarUsuarioId/{id}")]
        public Usuario BuscarUsuarioId(int id)
        {
            return us.BuscarUsuarioPorNome(id);
        }

        [HttpPost, Route("api/usuario/NovoUsuario")]
        public void NovoUsuario(string nome,string sexo,DateTime date,string user,string senha,string uf,string cidade,int nivel,string email,string cel)
        {
            us.CadastrarNovoUsuario(new Usuario {Nome = nome,Sexo = sexo,DataNascimento = date,Username = user,
                                    Senha = senha,Uf = uf,Cidade = cidade,NivelAcademico = nivel,FezTeste = 0,Avatar = null,Bio=null},email,cel);
            
        }

        [HttpGet,Route("api/usuario/ValidarLogin/{user}/{senha}")]
        public Status ValidarLogin(string user,string senha)
        {
            bool res = us.ValidarLogin(user, senha);

            if(res==true)
            {
                return new Status("Valido");

            } else
            {
                return new Status("Invalido");
            }
        }
        
        [HttpGet,Route("api/usuario/FezTeste/{user}")]
        public Status VerificarSeFezTeste(string user)
        {
            int stsTeste = us.VerificarSeFezTeste(user);
            return new Status(stsTeste);
        }

        [HttpGet,Route("api/usuario/PegarIDUsuario/{username}")]
        public Usuario PegarIDUsuario(string username)
        {
            return us.RetornarIdUsuario(username);
        }
    }
}
