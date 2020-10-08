using Flunt.Notifications;
using Flunt.Validations;
using Manager.Domain.Enums;
using Manager.Domain.Interfaces;
using System;

namespace Manager.Negocio.Commands.Ticket
{
    public class CriarTicketCommand : Notifiable, ICommand
    {
        public CriarTicketCommand(){ }

        public CriarTicketCommand(string descricao, PrioridadeEnum prioridade, string projeto, string categoria, string usuario)
        {
            Descricao = descricao;
            Prioridade = prioridade;
            Projeto = projeto;
            Categoria = categoria;
            Usuario = usuario;
        }

        public string Descricao { get; set; }
        public PrioridadeEnum  Prioridade { get; set; }
        public string Projeto { get; set; }
        public string Categoria { get; set; }
        public string Usuario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                    
            );
        }
    }
}
