using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class AdicionarUsuarioAoProjeto : IRequest<Response>
    {
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public bool Gerente { get; set; }
    }
}
