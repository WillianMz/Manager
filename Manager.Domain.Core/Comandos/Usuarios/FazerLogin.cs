using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class FazerLogin : IRequest<Response>
    {        
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
