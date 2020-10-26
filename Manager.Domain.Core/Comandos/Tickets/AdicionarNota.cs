using Manager.Domain.Core.Comandos.Tickets.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class AdicionarNota : NotaBase, IRequest<Response>
    {
    }
}
