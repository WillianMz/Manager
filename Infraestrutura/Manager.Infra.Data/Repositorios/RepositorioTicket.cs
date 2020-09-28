using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioTicket : IRepositorioTicket
    {
        public void Adicionar(Ticket entidade)
        {
            throw new NotImplementedException();
        }

        public void AdicionarLista(IEnumerable<Ticket> entidades)
        {
            throw new NotImplementedException();
        }

        public Ticket CarregarObjetoPeloID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Ticket entidade)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEntidade(Ticket entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ticket> ListarNomeEmOrdemCrescente()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ticket> ListarNomeEmOrdemDecrescente()
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> ListarOrdenadoPor()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Ticket> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Ticket entidade)
        {
            throw new NotImplementedException();
        }

        public void RemoverLista(IEnumerable<Ticket> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
