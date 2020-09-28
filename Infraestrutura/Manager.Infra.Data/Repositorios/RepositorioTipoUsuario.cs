using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioTipoUsuario : IRepositorioTipoUsuario
    {
        public void Adicionar(TipoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<TipoUsuario> entidades)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEntidade(TipoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TipoUsuario> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TipoUsuario> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IList<TipoUsuario> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TipoUsuario> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<TipoUsuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(TipoUsuario entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<TipoUsuario> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
