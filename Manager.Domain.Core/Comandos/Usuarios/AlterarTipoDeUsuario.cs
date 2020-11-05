using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class AlterarTipoDeUsuario : IRequest<Response>
    {
        public int UsuarioId { get; set; }
        public int TipoUsuario { get; set; }
    }
}
