using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class MembrosDoProjeto : MembroProjetoBase, IRequest<Response>
    {
    }
}
