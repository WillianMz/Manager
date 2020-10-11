using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class AtivarDestativarUsuario : IRequest<Response>
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public bool Ativar { get; set; }
    }
}
