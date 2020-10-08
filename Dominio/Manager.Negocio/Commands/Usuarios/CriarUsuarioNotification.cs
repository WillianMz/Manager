using Manager.Domain.Entidades;
using MediatR;

namespace Manager.Negocio.Commands.Usuarios
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
