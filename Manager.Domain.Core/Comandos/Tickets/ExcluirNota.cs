using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class ExcluirNota : IRequest<Response>
    {
        public int IdNota { get; set; }
        public int TicketId { get; set; }
    }
}
