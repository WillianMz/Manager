using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;
using System.Collections.Generic;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class AdicionarMembroNaEquipe : MembroProjetoBase, IRequest<Response>
    {
        public List<EquipeDoProjeto> MembrosDaEquipe { get; set; }
    }
}
