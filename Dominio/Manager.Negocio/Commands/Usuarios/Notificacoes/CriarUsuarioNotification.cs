using Manager.Domain.Entidades;
using MediatR;

namespace Manager.Negocio.Commands.Usuarios.Notificacoes
{
    public class CriarUsuarioNotification : INotification
    {
        public CriarUsuarioNotification(Usuario usuario)
        {
            Usuario = usuario;
        }

        public Usuario Usuario { get; set; }
    }
}
