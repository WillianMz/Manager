using Flunt.Notifications;
using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Entidades;
using Manager.Domain.Enums;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class TicketHandler : Notifiable, IRequestHandler<CriarTicket, Response>, 
                                             IRequestHandler<EditarTicket, Response>,
                                             IRequestHandler<ExcluirTicket, Response>, 
                                             IRequestHandler<FinalizarTicket, Response>
    {
        private readonly IRepositorioTicket _repositorioTicket;
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMediator _mediator;

        public TicketHandler(IRepositorioTicket repositorioTicket, IRepositorioCategoria repositorioCategoria, 
                             IRepositorioProjeto repositorioProjeto, IRepositorioUsuario repositorioUsuario, IMediator mediator)
        {
            _repositorioTicket = repositorioTicket;
            _repositorioCategoria = repositorioCategoria;
            _repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
            _mediator = mediator;
        }

        public async Task<Response> Handle(CriarTicket request, CancellationToken cancellationToken)
        {            
            if (request == null)
                return new Response(false, "Informe todos os dados para criar um novo ticket", request);

            Usuario criador = _repositorioUsuario.CarregarObjetoPeloID(request.CriadorId);
            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Categoria categoria = _repositorioCategoria.CarregarObjetoPeloID(request.CategoriaId);

            #region VALIDACOES DE CRIADOR/PROJETO/CATEGORIA

            if (criador == null)
                //return new Response(false, "Usuário criador do ticket não encontrado", request);
                AddNotification("Criador do Ticket", "Usuário criador do ticket não foi encontrado");

            if (projeto == null)
                //return new Response(false, "Projeto referenciado a este ticket não foi encontrado", request);
                AddNotification("Projeto", "Projeto referenciado a este ticket não foi encontrado");

            if (categoria == null)
                //return new Response(false, "Categoria não encontrada", request);
                AddNotification("Categoria", "Categoria não encontrada");

            #endregion

            if (Invalid)
                return new Response(false, "Verifique os erros e tente novamente", Notifications);

            Ticket ticket = new Ticket(request.Descricao, criador, projeto, categoria);

            if (request.Notas != null)
            {
                List<AdicionarNota> notas = request.Notas;

                foreach (var n in notas)
                    ticket.AdicionarNota(new Nota(n.Titulo, n.Descricao, ticket, criador));
            }

            if (request.Anexos != null)
            {
                List<AdicionarAnexo> anexos = request.Anexos;

                foreach (var a in anexos)
                    ticket.AdicionarAnexo(new Anexo(a.Descricao, a.URL, ticket));

            }

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Adicionar(ticket);        

            Response result = new Response(true, "Ticket criado com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(EditarTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do ticket que deseja alterar", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            Categoria categoria = _repositorioCategoria.CarregarObjetoPeloID(request.CategoriaId);
            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.IdTicket);

            if (usuario == null)
                AddNotification("Usuário", "Usuário não foi encontrado");

            if (categoria == null)
                AddNotification("Categoria", "Categoria não encontrada");

            if (ticket == null)
                AddNotification("Ticket", "Ticket não localizado");

            if (Invalid)
                return new Response(false, "Verifique os dados informados e tente novamente", Notifications);

            ticket.Editar(request.Descricao, categoria);

            switch (request.Prioridade)
            {
                case 1:
                    ticket.AlterarPrioridade(PrioridadeEnum.Baixo);
                    break;
                case 2:
                    ticket.AlterarPrioridade(PrioridadeEnum.Normal);
                    break;
                case 3:
                    ticket.AlterarPrioridade(PrioridadeEnum.Alto);
                    break;
                case 4:
                    ticket.AlterarPrioridade(PrioridadeEnum.Urgente);
                    break;
            }

            switch (request.Status)
            {
                case 1:
                    ticket.AlterarStatus(StatusEnum.Aberto);
                    break;
                case 2:
                    ticket.AlterarStatus(StatusEnum.EmAndamento);
                    break;
                case 3:
                    ticket.AlterarStatus(StatusEnum.Concluido);
                    break;
                case 4:
                    ticket.AlterarStatus(StatusEnum.Cancelado);
                    break;
            }

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);

            Response result = new Response(true, "Ticket alterado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(ExcluirTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o ticket que deseja excluir!", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.IdTicket);

            if (ticket == null)
                return new Response(false, "Ticket não localizado", request);

            _repositorioTicket.Remover(ticket);

            Response result = new Response(true, "Ticket excluído com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(FinalizarTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do ticket para finalizar", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);

            if (ticket == null)
                return new Response(false, "Ticket não localizado", request);

            ticket.Finalizar(request.Solucao);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);

            Response result = new Response(true, "Ticket finalizado com sucesso!", null);
            return await Task.FromResult(result);

        }
    }
}
