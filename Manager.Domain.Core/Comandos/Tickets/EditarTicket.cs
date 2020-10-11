using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class EditarTicket : IRequest<Response>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        //public int UsuarioId { get; set; }
        //public int ProjetoId { get; set; }
        public int CategoriaId { get; set; }
    }
}
