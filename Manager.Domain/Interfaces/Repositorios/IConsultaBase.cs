using System.Collections.Generic;

namespace Manager.Domain.Interfaces.Repositorios
{ 
    public interface IConsultaBase<TEntidade>
    {        
        IList<TEntidade> ListarTodos();
        IList<TEntidade> ListarTodos(bool ativo);
        IList<TEntidade> ListarPorNome(string nome);
        IList<TEntidade> ListarNomeEmOrdemCrescente();
        IList<TEntidade> ListarNomeEmOrdemDecrescente();
        TEntidade ListarPorId(int id);
        IList<TEntidade> ListarPorIdCrescente();
        IList<TEntidade> ListarPorIdDecrescente();
    }
}
