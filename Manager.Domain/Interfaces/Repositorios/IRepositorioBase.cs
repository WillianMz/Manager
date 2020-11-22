using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade>
    {        
        void Adicionar(TEntidade entidade);
        void Editar(TEntidade entidade);               
        void Remover(TEntidade entidade);       
        void AdicionarLista(IEnumerable<TEntidade> entidades);
        void RemoverLista(IEnumerable<TEntidade> entidades);
        Task<bool> Existe(TEntidade entidade);
        Task<TEntidade> CarregarObjetoPeloID(int id);
       
    }
}