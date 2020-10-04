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
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "T�tulo n�o pode estar em branco")
                .IsNotNullOrEmpty(descricao, "Descricao", "Descri��o n�o pode estar em branco")
                .IsNotNull(ticket, "Ticket", "N�o foi informado a qual ticket esta nota pertence")
                .IsNotNull(usuario, "Usuario", "N�o foi informado o usu�rio criador desta nota")
            );
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataDaNota { get; set; }
        public int TicketId { get; private set; }
        public virtual Ticket Ticket { get; private set; }

        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
     
        //METODOS
        public void Editar(string titulo, string descricao, Usuario usuario)
        {
            if(usuario == Usuario)
            {
                Titulo = titulo?.Trim().ToUpper();
                Descricao = descricao?.Trim().ToUpper();

                AddNotifications(new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(titulo, "Titulo", "T�tulo n�o pode estar em branco")
                    .IsNotNullOrEmpty(descricao, "Descricao", "Descri��o n�o pode estar em branco")
                    .IsNotNull(usuario, "Usuario", "N�o foi informado o usu�rio criador desta nota")
                );
            }         
            else
            {
                AddNotification("Usuario", "Voc� n�o pode alterar a nota de outro usu�rio");
            }           

        }
    }
}