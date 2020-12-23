using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class EditarProjeto : ProjetoBase, IRequest<Response>
    {
        public int Id { get; set; }

        //public List<EditarDocumento> Documentos { get; set; }
        //public List<EditarRelease> Releases { get; set; }
        //public List<EquipeDoProjeto> MembrosDoProjeto { get; set; }
    }
}
