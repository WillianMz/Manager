using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class EditarUsuario : IRequest<Response>
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
    }
}
