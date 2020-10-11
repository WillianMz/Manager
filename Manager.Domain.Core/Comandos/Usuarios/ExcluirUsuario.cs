using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class ExcluirUsuario : IRequest<Response>
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
    }
}
