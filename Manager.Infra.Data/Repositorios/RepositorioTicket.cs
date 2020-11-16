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

        public bool Existe(Ticket entidade)
        {
            throw new NotImplementedException();
        }

        public IList<Ticket> ListarNomeEmOrdemCrescente()
        {
            List<Ticket> tickets = context.Tickets.OrderBy(t => t.Id).ToList();
            return tickets;
        }

        public IList<Ticket> ListarNomeEmOrdemDecrescente()
        {
            List<Ticket> tickets = context.Tickets.OrderByDescending(t => t.Id).ToList();
            return tickets;
        }

        public IList<Ticket> ListarPorNome(string nome)
        {
            List<Ticket> tickets = context.Tickets.OrderBy(t => t.Titulo).ToList();
            return tickets;
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
