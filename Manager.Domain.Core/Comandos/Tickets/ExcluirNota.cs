using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class ExcluirNota : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
