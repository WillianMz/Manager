using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class EditarRelease : ReleaseBase, IRequest<Response>
    {
        public int Id { get; set; }
        
    }
}
