using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class FinalizarTicket : IRequest<Response>
    {
        public int TicketId { get; set; }
        public string Solucao { get; set; }
    }
}
