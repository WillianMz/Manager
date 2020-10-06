using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioTicket : IRepositorioTicket
    {
        private readonly ManagerContext context;

        public RepositorioTicket(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Ticket entidade)
        {
            context.Tickets.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Ticket> entidades)
        {
            context.Tickets.AddRange(entidades);
        }

        public Ticket CarregarObjetoPeloID(int id)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
            return ticket;
        }

        public void Editar(Ticket entidade)
        {
            context.Tickets.Update(entidade);
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

        public IQueryable<Ticket> ListarPorNome(string nome)
        {
            var ticketsPorDescricao = context.Tickets.Where(t => t.Descricao.Contains(nome));
            return ticketsPorDescricao;
        }

        public IList<Ticket> ListarTodos()
        {
            var tickets = context.Tickets.ToList();
            return tickets;
        }

        public void Remover(Ticket entidade)
        {
            context.Tickets.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Ticket> entidades)
        {
            context.Tickets.RemoveRange(entidades);
        }
    }
}
