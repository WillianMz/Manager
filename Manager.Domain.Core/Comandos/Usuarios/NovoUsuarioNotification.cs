using Manager.Domain.Entidades;
using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class NovoUsuarioNotification : INotification
    {
        public NovoUsuarioNotification(Usuario usuario)
        {
            Usuario = usuario;
        }

        public Usuario Usuario { get; set; }

    }
}
