using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class RegistrarNovoUsuario : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
