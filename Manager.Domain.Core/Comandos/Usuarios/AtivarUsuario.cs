using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class AtivarUsuario : IRequest<Response>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CodigoDeAtivacao { get; set; }
    }
}
