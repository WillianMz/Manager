using Flunt.Notifications;
using System.Collections;
using System.Collections.Generic;

namespace Manager.Negocio.Commands
{
    public class Response
    {
        public Response() { }

        public Response(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}
