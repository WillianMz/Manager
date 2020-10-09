using Manager.Negocio.Commands.Documentos;
using Manager.Negocio.Commands.Releases;
using MediatR;
using System.Collections.Generic;

namespace Manager.Negocio.Commands.Projetos
{
    public class CriarProjetoRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<AdicionarDocumentoRequest> Documentos { get; set; }
        public List<AdicionarReleaseRequest> Releases { get; set; }
    }
}
