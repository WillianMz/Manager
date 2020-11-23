using Flunt.Notifications;
using Flunt.Validations;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Entidades;
using Manager.Domain.Enums;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Servicos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class TicketHandler : Notifiable, IRequestHandler<CriarTicket, Response>, 
                                             IRequestHandler<EditarTicket, Response>,
                                             IRequestHandler<ExcluirTicket, Response>, 
                                             IRequestHandler<FinalizarTicket, Response>,
                                             IRequestHandler<CancelarTicket, Response>
    {
        private readonly IRepositorioTicket _repositorioTicket;
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioUsuario _repositorioUsuario;
        //private readonly IMediator _mediator;
        //private readonly IServicoEmail _servicoEmail;
        private readonly INotificarTicket _notificarNovoTicket;

        public TicketHandler(IRepositorioTicket repositorioTicket, IRepositorioCategoria repositorioCategoria, 
                            IRepositorioProjeto repositorioProjeto, IRepositorioUsuario repositorioUsuario,
                            INotificarTicket notificarNovoTicket)
        {
            _repositorioTicket = repositorioTicket;
            _repositorioCategoria = repositorioCategoria;
            _repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
            //_mediator = mediator;
            //_servicoEmail = servicoEmail;
            _notificarNovoTicket = notificarNovoTicket;
        }

        public async Task<Response> Handle(CriarTicket request, CancellationToken cancellationToken)
        {            
            if (request == null)
                return new Response(false, "Informe todos os dados para criar um novo ticket", request);

            Usuario criador = await _repositorioUsuario.CarregarObjetoPeloID(request.CriadorId);
            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Categoria categoria = await _repositorioCategoria.CarregarObjetoPeloID(request.CategoriaId);

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

            Ticket ticket = new Ticket(request.Titulo, request.Descricao, criador, projeto, categoria);

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
            await _notificarNovoTicket.Novo(projeto, criador, ticket);

            Response result = new Response(true, "Ticket criado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do ticket que deseja alterar", request);

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            Categoria categoria = await _repositorioCategoria.CarregarObjetoPeloID(request.CategoriaId);
            Ticket ticket = await _repositorioTicket.CarregarObjetoPeloID(request.IdTicket);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(usuario,"Usuario","Usuário não foi encontrado")
                .IsNotNull(categoria,"Categoria","Categoria não encontrada")
                .IsNotNull(ticket,"Ticket","Ticket não encontrado")
            );

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
                default:
                    AddNotification("Prioridade", "Tipos de prioridades: 1=Baixo | 2=Normal | 3=Alto | 4=Urgente");
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
                default:
                    AddNotification("Status", "Tipos de status: 1=Aberto | 2=Em andamento | 3=Concluído | 4=Cancelado");
                    break;
            }

            if (Invalid)
                return new Response(false, "Verifique os dados informados e tente novamente", Notifications);

            ticket.Editar(request.Titulo, request.Descricao, categoria);

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

            Ticket ticket = await _repositorioTicket.CarregarObjetoPeloID(request.IdTicket);

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

            Ticket ticket = await _repositorioTicket.CarregarObjetoPeloID(request.TicketId);
            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (ticket == null)
                return new Response(false, "Ticket não localizado", request);

            if (usuario == null)
                return new Response(false, "Usuário não localizado", request);

            ticket.Finalizar(request.Solucao, usuario);

            //teste
            //NotificarFechamentoDeTicket notificacao = new NotificarFechamentoDeTicket(_servicoEmail);
            //notificacao.NotificaFechamentoDoTicket(ticket, usuario, request.Solucao);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);
            _notificarNovoTicket.Finalizar(ticket, usuario, request.Solucao);

            Response result = new Response(true, "Ticket finalizado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(CancelarTicket request, CancellationToken cancellationToken)
        {
            Ticket ticket = await _repositorioTicket.CarregarObjetoPeloID(request.IdTicket);
            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            
            if (ticket == null)
                return new Response(false, "Ticket não localizado", request);

            if (usuario == null)
                return new Response(false, "Usuário não localizado", request);

            ticket.Cancelar(request.Motivo, usuario);
            _repositorioTicket.Editar(ticket);

            Response result = new Response(true, "Ticket cancelado com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
