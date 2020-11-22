using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class ExcluirDocumento : IRequest<Response>
    {
        public int IdDocumento { get; set; }
    }
}
