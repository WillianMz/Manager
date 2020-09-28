using Flunt.Validations;
using System;

namespace Manager.Domain.Entidades
{
    public class Nota : EntidadeBase
    {
        //Para o EFCore
        protected Nota() { }

        public Nota(string titulo, string descricao, Ticket ticket, Usuario usuario)
        {
            Titulo = titulo?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();
            Ticket = ticket;
            Usuario = usuario;
            DataDaNota = DateTime.Now;

            AddNotifications(new Contract()
            );
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataDaNota { get; set; }
        //public DateTime Hora { get; set; }

        public int TicketId { get; private set; }
        public virtual Ticket Ticket { get; private set; }

        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        
    }
}