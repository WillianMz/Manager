using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class ExcluirRelease : IRequest<Response>
    {
        public int IdRelease { get; set; }
    }
}
