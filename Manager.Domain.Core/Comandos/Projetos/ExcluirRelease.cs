using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class ExcluirRelease : IRequest<Response>
    {
        public int ProjetoId { get; set; }
        public int idRelease { get; set; }
    }
}
