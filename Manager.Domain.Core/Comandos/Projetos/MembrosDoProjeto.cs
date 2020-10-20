using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;
using System.Collections.Generic;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class MembrosDoProjeto : MembroProjetoBase, IRequest<Response>
    {
        public  List<EquipeDoProjeto> AdicionarMembros { get; set; }
        public List<EquipeDoProjeto> ExcluirMembros { get; set; }

    }
}
