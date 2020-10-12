using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class TicketHandler : IRequestHandler<CriarTicket, Response>, IRequestHandler<EditarTicket, Response>,
                                 IRequestHandler<ExcluirTicket, Response>, IRequestHandler<FinalizarTicket, Response>
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

            var usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            var projeto = _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            var categoria = _repositorioCategoria.CarregarObjetoPeloID(request.CategoriaId);

            if (usuario == null | projeto == null | categoria == null)
                return new Response(false, "Não foi encontrado nenhum objeto ", request);

            Ticket ticket = new Ticket(request.Descricao, usuario, projeto, categoria);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Adicionar(ticket);

            var result = new Response(true, "Ticket criado com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(EditarTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do ticket que deseja alterar", request);

            var usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            var categoria = _repositorioCategoria.CarregarObjetoPeloID(request.CategoriaId);
            
            if((usuario == null) | (categoria == null))
            {
                //criar uma notificação para exibir no retorno
                return new Response(false, "Passou auqui", null);
            }

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.Id);
            ticket.Editar(request.Descricao, usuario, categoria);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Ticket alterado com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(ExcluirTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o ticket que deseja excluir!", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.Id);

            if (ticket == null)
                return new Response(false, "Não foi encontrado nenhum ticket", null);

            _repositorioTicket.Remover(ticket);

            var result = new Response(true, "Ticket excluído com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(FinalizarTicket request, CancellationToken cancellationToken)
        {
            if(request == null)
                return new Response(false, "Informe o ticket que deseja finalizar", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);
            
            if (ticket == null)
                return new Response(false, "Não foi encontrado nenhum ticket", null);

            ticket.Finalizar(request.Solucao);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Ticket finalizado com sucesso!", null);
            return await Task.FromResult(result);

        }
    }
}
