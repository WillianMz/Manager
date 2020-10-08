using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioStatus : IRepositorioStatus
    {
        public void Adicionar(Status entidade)
        {
            throw new System.NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<Status> entidades)
        {
            throw new System.NotImplementedException();
        }

        public Status CarregarObjetoPeloID(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Editar(Status entidade)
        {
            throw new System.NotImplementedException();
        }

        public bool Existe(Status entidade)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Status> ListarNomeEmOrdemCrescente()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Status> ListarNomeEmOrdemDecrescente()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Status> ListarPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        public IList<Status> ListarTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Remover(Status entidade)
        {
            throw new System.NotImplementedException();
        }

        public void RemoverLista(IEnumerable<Status> entidades)
        {
            throw new System.NotImplementedException();
        }
    }
}
