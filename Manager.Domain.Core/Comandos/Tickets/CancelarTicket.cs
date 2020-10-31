using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class CancelarTicket : IRequest<Response>
    {
        public int IdTicket { get; set; }
        public string Motivo { get; set; }
        public int UsuarioId { get; set; }
    }
}
