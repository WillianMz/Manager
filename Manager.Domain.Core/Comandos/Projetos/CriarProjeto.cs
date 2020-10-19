using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;
using System.Collections.Generic;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class CriarProjeto : ProjetoBase, IRequest<Response>
    {
        public List<AdicionarRelease> Releases { get; set; }
        public List<AdicionarDocumento> Documentos { get; set; }
        public List<EquipeDoProjeto> MembrosDoProjeto { get; set; }
    }

}
