using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class CriarNota : IRequest<Response>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
    }
}
