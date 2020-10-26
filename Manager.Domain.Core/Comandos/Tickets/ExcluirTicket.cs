using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class ExcluirTicket : IRequest<Response>
    {
        public int IdTicket { get; set; }
    }
}
