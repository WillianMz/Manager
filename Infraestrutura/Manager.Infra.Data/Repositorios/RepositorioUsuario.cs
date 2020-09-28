using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public void Adicionar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<Usuario> entidades)
        {
            throw new NotImplementedException();
        }

        public Usuario CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEntidade(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Usuario> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<Usuario> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
