using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class EditarDocumento : DocumentoBase, IRequest<Response>
    {
        public int Id { get; set; }
    }
}
