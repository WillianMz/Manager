using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class AdicionarRelease : ReleaseBase, IRequest<Response>
    {
    }
}
