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
    public class AnexoHandler : Notifiable, IRequestHandler<AdicionarAnexo, Response>, IRequestHandler<ExcluirAnexo, Response>
    {
        private readonly IRepositorioTicket _repositorioTicket;

        public AnexoHandler(IRepositorioTicket repositorioTicket)
        {
            _repositorioTicket = repositorioTicket;
        }

        public async Task<Response> Handle(AdicionarAnexo request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do anexo", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);

            if (ticket == null)
                return new Response(false, "Ticket não encontrado", null);

            Anexo anexo = new Anexo(request.Descricao, request.URL, ticket);
            ticket.AdicionarAnexo(anexo);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Anexo adicionado com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(ExcluirAnexo request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o anexo que deseja excluír", request);

            Ticket ticket = _repositorioTicket.CarregarObjetoPeloID(request.TicketId);
            Anexo anexo = ticket.Anexos.FirstOrDefault(a => a.Id == request.IdAnexo);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(ticket,"Ticket","Ticket não encontrado")
                .IsNotNull(anexo,"Anexo","Anexo não encontrado")
            );

            ticket.ExcluirAnexo(anexo);

            if (ticket.Invalid)
                return new Response(false, "Ticket inválido", ticket.Notifications);

            _repositorioTicket.Editar(ticket);

            var result = new Response(true, "Anexo excluído com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
