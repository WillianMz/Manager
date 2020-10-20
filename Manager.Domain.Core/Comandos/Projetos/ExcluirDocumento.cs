using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class ExcluirDocumento : DocumentoBase, IRequest<Response>
    {
        public int IdDocumento { get; set; }
    }
}
