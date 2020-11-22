using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class ExcluirAnexo : IRequest<Response>
    {
        public int IdAnexo { get; set; }
    }
}
