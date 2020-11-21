using MediatR;

namespace Manager.Domain.Queries.Consultas.Tickets
{
    public class DetalhesDoTicket : IRequest<ResponseQueries>
    {
        public int Id { get; set; }
    }
}
