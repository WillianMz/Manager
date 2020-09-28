using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioRelease : IRepositorioRelease
    {
        public void Adicionar(Release entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<Release> entidades)
        {
            throw new NotImplementedException();
        }

        public Release CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Release entidade)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEntidade(Release entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Release> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Release> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IList<Release> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Release> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Release> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Release entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<Release> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
