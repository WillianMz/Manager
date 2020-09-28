using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Domain.Interfaces.Repositorios.Base
{
    public interface IRepositorioBase<TEntidade>
    {        
        void Adicionar(TEntidade entidade);
        void Editar(TEntidade entidade);               
        void Remover(TEntidade entidade);       
        void AdicionarLista(IEnumerable<TEntidade> entidades);
        void RemoverLista(IEnumerable<TEntidade> entidades);
        bool ExisteEntidade(TEntidade entidade);
        TEntidade CarregarObjetoPeloID(int id);

        IList<TEntidade> ListarTodos();
        IQueryable<TEntidade> ListarPorNome(string nome);
        IList<TEntidade> ListarOrdenadoPor();
        IQueryable<TEntidade> ListarNomeEmOrdemCrescente();
        IQueryable<TEntidade> ListarNomeEmOrdemDecrescente();
    }
}