using MediatR;

namespace Manager.Domain.Queries.Consultas.Tickets
{
    public class TicketPorNome : IRequest<ResponseQueries>
    {
        public string Nome { get; set; }
    }
}
