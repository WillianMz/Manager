using Flunt.Notifications;
using Flunt.Validations;
using Manager.Infra.Utilitario;
using System;

namespace Manager.Domain.Entidades
{
    public class UsuarioAtivacao : Notifiable
    {
        private UsuarioAtivacao() { }

        public UsuarioAtivacao(Usuario usuario)
        {
            Usuario = usuario;

            CodigoAtivacao = CodigoAtivacao.GerarCodigo();
            HorasValidade = DateTime.Now.AddHours(5);
            DataValidade = DateTime.Now.AddDays(1);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(usuario,"Usuário","Usuário não identificado!")
            );
        }

        public int Id { get; private set; }
        public string CodigoAtivacao { get; private set; }
        public DateTime HorasValidade { get; private set; }
        public DateTime DataValidade { get; private set; }

        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }

    }
}
