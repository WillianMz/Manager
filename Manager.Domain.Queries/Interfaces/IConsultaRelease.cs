using Manager.Domain.Queries.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Interfaces
{
    public interface IConsultaRelease
    {
        Task<List<ReleaseDTO>> FiltrarReleasesPorProjeto(int idProjeto);
    }
}
