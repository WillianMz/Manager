using Flunt.Notifications;
using Flunt.Validations;
using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class NotaHandler : Notifiable, IRequestHandler<AdicionarNota, Response>,
                                           IRequestHandler<EditarNota, Response>,
                                           IRequestHandler<ExcluirNota, Response>
    {
        private readonly IRepositorioTicket _repositorioTicket;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public NotaHandler(IRepositorioTicket repositorioTicket, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioTicket = repositorioTicket;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(AdicionarNota request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da nota", null);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(usuario,"Usuário","Usuário não encontrado")
                .IsNotNull(ticket,"Ticket","Ticket não encontrado")
            );

            if (Invalid)
                return new Response(false, "Verifique os erros e tente novamente.", Notifications);

            Nota nota = new Nota(request.Titulo, request.Descricao, ticket, usuario);                    
            ticket.AdicionarNota(nota);

            if (ticket.Invalid)
                return new Response(false, "Verifique os erros e tente novamente", nota.Notifications);

            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Nota adicionada com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(EditarNota request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da nota que deseja alterar", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);
            Nota nota = ticket.Notas.FirstOrDefault(n => n.Id == request.IdNota);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(usuario,"Usuário","Usuário não encontrado")
                .IsNotNull(ticket,"Ticket","Ticket não encontrado")
                .IsNotNull(nota,"Nota","Nota não encontrada")
            );

            if (Invalid)
                return new Response(false, "Verifique os erros e tente novamente", Notifications);

            nota.Editar(request.Titulo, request.Descricao, usuario);
            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Nota alterada com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(ExcluirNota request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "informe a nota que deseja excluir", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);
            Nota nota = ticket.Notas.FirstOrDefault(n => n.Id == request.IdNota);

            AddNotifications(new Contract()
                 .Requires()
                 .IsNotNull(ticket, "Ticket", "Ticket não encontrado")
                 .IsNotNull(nota, "Nota", "Nota não encontrada")
             );

            if (Invalid)
                return new Response(false, "Verifique os erros e tente novamente", Notifications);

            ticket.ExcluirNota(nota);
            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Nota excluída com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
