using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class EditarTicket : IRequest<Response>
    {
        public int IdTicket { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }

        public int Prioridade { get; set; }
        public int Status { get; set; }
    }
}
