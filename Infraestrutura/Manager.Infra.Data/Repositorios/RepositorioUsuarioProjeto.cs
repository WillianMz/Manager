using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioUsuarioProjeto : IRepositorioUsuarioProjeto
    {
        public void Adicionar(UsuarioProjeto entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<UsuarioProjeto> entidades)
        {
            throw new NotImplementedException();
        }

        public UsuarioProjeto CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(UsuarioProjeto entidade)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEntidade(UsuarioProjeto entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UsuarioProjeto> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UsuarioProjeto> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioProjeto> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UsuarioProjeto> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioProjeto> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(UsuarioProjeto entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<UsuarioProjeto> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
