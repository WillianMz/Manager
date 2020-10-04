using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioNota : IRepositorioNota
    {
        private readonly ManagerContext context;

        public RepositorioNota(ManagerContext context)
        {
            this.context = context;
        }

        public void Adicionar(Nota entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<Nota> entidades)
        {
            throw new NotImplementedException();
        }

        public Nota CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Nota entidade)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEntidade(Nota entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nota> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nota> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IList<Nota> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nota> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Nota> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Nota entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<Nota> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
