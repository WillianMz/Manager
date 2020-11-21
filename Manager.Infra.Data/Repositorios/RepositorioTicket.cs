using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Queries.DTOs;
using Manager.Domain.Queries.Interfaces;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioTicket : IRepositorioTicket, IConsultaTicket
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

        public void Remover(Ticket entidade)
        {
            context.Tickets.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Ticket> entidades)
        {
            context.Tickets.RemoveRange(entidades);
        }

        #region CONSULTAS

        public List<TicketDTO> Listar()
        {
            var tickets = context.Tickets.OrderBy(t => t.Id).ToList();
            List<TicketDTO> ticketDTOs = new List<TicketDTO>();

            foreach (var t in tickets)
            {
                TicketDTO DTO = new TicketDTO()
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    DataAbertura = Convert.ToString(t.DataAbertura),
                    Categoria = t.Categoria.Nome,
                    Prioridade = t.PrioridadeAtual.ToString(),
                    StatusAtual = t.StatusAtual.ToString(),
                    Criador = t.Criador.Nome,
                    Projeto = t.Projeto.Nome
                };

                ticketDTOs.Add(DTO);
            }

            return ticketDTOs;
        }

        public List<TicketDTO> ListarPorNome(string nome)
        {
            var tickets = context.Tickets.Where(t => t.Titulo.Contains(nome)).ToList();
            tickets.OrderBy(t => t.Titulo);
            List<TicketDTO> ticketDTOs = new List<TicketDTO>();

            foreach (var t in tickets)
            {
                TicketDTO DTO = new TicketDTO()
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao,
                    DataAbertura = Convert.ToString(t.DataAbertura),
                    Categoria = t.Categoria.Nome,
                    Prioridade = t.PrioridadeAtual.ToString(),
                    Criador = t.Criador.Nome
                };

                ticketDTOs.Add(DTO);
            }

            return ticketDTOs;
        }

        public TicketDTO ProcurarPorID(int id)
        {
            var ticket = context.Tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
                return null;

            TicketDTO ticketDTO = new TicketDTO()
            {
                Id = ticket.Id,
                Titulo = ticket.Titulo,
                Descricao = ticket.Descricao,
                DataAbertura = Convert.ToString(ticket.DataAbertura),
                Categoria = ticket.Categoria.Nome,
                Prioridade = ticket.PrioridadeAtual.ToString(),
                Criador = ticket.Criador.Nome
            };

            return ticketDTO;
        }

        public TicketDTO ConsultarDetalhes(int id)
        {
            var ticket = context.Tickets.FirstOrDefault(t => t.Id == id);

            if (ticket == null)
                return null;

            TicketDTO ticketDTO = new TicketDTO()
            {
                Id = ticket.Id,
                DataAbertura = Convert.ToString(ticket.DataAbertura),
                Titulo = ticket.Titulo,
                Descricao = ticket.Descricao,
                StatusAtual = ticket.StatusAtual.ToString(),
                Prioridade = ticket.PrioridadeAtual.ToString(),
                DataFechamento = ticket.DataFechamento.ToString(),
                Tempo = ticket.Tempo.ToString(),
                DataCancelamento = ticket.DataCancelamento.ToString(),
                MotivoCancelamento = ticket.MotivoCancelamento,
                Criador = ticket.Criador.Nome,
                Projeto = ticket.Projeto.Nome,
                Categoria = ticket.Categoria.Nome,
                //se o ticket estiver aberto não possui usuario que fechou ou cancelou           
                UsuarioFechamento = ticket.UsuarioFechamento == null ? "null" : ticket.UsuarioFechamento.Nome,
                UsuarioCancelamento = ticket.UsuarioCancelamento == null ? "null" : ticket.UsuarioCancelamento.Nome
            };

            foreach (var n in ticket.Notas)
            {
                NotaDTO notaDTO = new NotaDTO
                {
                    Id = n.Id,
                    Titulo = n.Titulo,
                    Descricao = n.Descricao,
                    DataCriacao = null,
                    Usuario = n.Usuario.Nome
                };
                ticketDTO.Notas.Add(notaDTO);
            }

            foreach (var a in ticket.Anexos)
            {
                AnexoDTO anexoDTO = new AnexoDTO
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    URL = a.URL
                };
                ticketDTO.Anexos.Add(anexoDTO);                
            }

            return ticketDTO;
        }

        public async Task<Ticket> GetByID(int id)
        {
            Ticket ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
            return await Task.FromResult(ticket);
        }

        #endregion
    }
}
