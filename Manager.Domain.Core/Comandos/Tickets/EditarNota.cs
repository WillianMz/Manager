using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class EditarNota : IRequest<Response>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
//        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
    }
}
