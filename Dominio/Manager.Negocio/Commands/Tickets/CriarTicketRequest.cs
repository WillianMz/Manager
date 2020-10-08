using Manager.Domain.Interfaces;
using System;

namespace Manager.Negocio.Commands.Tickets
{
    public class CriarTicketRequest : ICommand
    {
        public CriarTicketRequest(){ }

        public CriarTicketRequest(string descricao, string projeto, string categoria, string usuario)
        {
            Descricao = descricao;
            Projeto = projeto;
            Categoria = categoria;
            Usuario = usuario;
        }

        public string Descricao { get; set; }
        public string Projeto { get; set; }
        public string Categoria { get; set; }
        public string Usuario { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
