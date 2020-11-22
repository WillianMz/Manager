using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Interfaces
{
    public interface IConsultaBase<TEntidade>
    {
        Task<List<TEntidade>> Listar();
        Task<List<TEntidade>> ListarPorNome(string nome);
        Task<TEntidade> ProcurarPorID(int id);
    }
}
