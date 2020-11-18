using MediatR;

namespace Manager.Domain.Queries.Consultas.Tickets
{
    public class TicketPorID : IRequest<ResponseQueries>
    {
        public int Id { get; set; }
    }
}
