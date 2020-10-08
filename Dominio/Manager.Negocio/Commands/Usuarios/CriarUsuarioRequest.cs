using Manager.Domain.Interfaces;
using MediatR;
using System;

namespace Manager.Negocio.Commands.Usuarios
{
    public class CriarUsuarioRequest : IRequest<Response>
    {
        //public CriarUsuarioRequest(){ }

        //public CriarUsuarioRequest(string nome, string login, string email, string senha)
        //{
        //    Nome = nome;
        //    Login = login;
        //    Email = email;
        //    Senha = senha;
        //}

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
