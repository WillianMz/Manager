using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class ExcluirRelease : IRequest<Response>
    {
        public int idRelease { get; set; }
    }
}
