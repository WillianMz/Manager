using System.Collections.Generic;

namespace Manager.Domain.Queries.Interfaces
{
    public interface IConsultaBase<TEntidade>
    {
        List<TEntidade> Listar();
        List<TEntidade> ListarPorNome(string nome);
        TEntidade ProcurarPorID(int id);
    }
}
