using MediatR;

namespace Manager.Negocio.Commands.Usuarios
{
    public class AutenticarUsuarioRequest : IRequest<Response>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
