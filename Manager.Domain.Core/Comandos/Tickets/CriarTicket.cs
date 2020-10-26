using Manager.Domain.Core.Comandos.Tickets.Modelos;
using MediatR;
using System.Collections.Generic;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class CriarTicket : TicketBase, IRequest<Response>
    {
        public List<AdicionarNota> Notas { get; set; }
        public List<AdicionarAnexo> Anexos { get; set; }
    }
}
