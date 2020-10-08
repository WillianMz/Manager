using MediatR;

namespace Manager.Negocio.Commands.Usuarios
{
    public class EditarUsuarioRequest : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
