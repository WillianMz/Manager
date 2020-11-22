using Flunt.Notifications;
using Flunt.Validations;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class AnexoHandler : Notifiable, IRequestHandler<AdicionarAnexo, Response>, 
                                            IRequestHandler<ExcluirAnexo, Response>
    {
        private readonly IRepositorioTicket _repositorioTicket;
        private readonly IRepositorioAnexo _repositorioAnexo;

        public AnexoHandler(IRepositorioTicket repositorioTicket, IRepositorioAnexo repositorioAnexo)
        {
            _repositorioTicket = repositorioTicket;
            _repositorioAnexo = repositorioAnexo;
        }

        public async Task<Response> Handle(AdicionarAnexo request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do anexo", request);

            Ticket ticket = await _repositorioTicket.CarregarObjetoPeloID(request.TicketId);

            if (ticket == null)
                return new Response(false, "Ticket não encontrado", null);

            Anexo anexo = new Anexo(request.Descricao, request.URL, ticket);
            //ticket.AdicionarAnexo(anexo);

            if (anexo.Invalid)
                return new Response(false, "Anexo inválido", ticket.Notifications);

            //_repositorioTicket.Editar(ticket);
            _repositorioAnexo.Adicionar(anexo);

            var result = new Response(true, "Anexo adicionado com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(ExcluirAnexo request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o anexo que deseja excluír", request);

            //Ticket ticket = await _repositorioTicket.CarregarObjetoPeloID(request.TicketId);
            //Anexo anexo = ticket.Anexos.FirstOrDefault(a => a.Id == request.IdAnexo);
            Anexo anexo = await _repositorioAnexo.CarregarObjetoPeloID(request.IdAnexo);

            AddNotifications(new Contract()
                .Requires()
                //.IsNotNull(ticket,"Ticket","Ticket não encontrado")
                .IsNotNull(anexo,"Anexo","Anexo não encontrado")
            );

            //ticket.ExcluirAnexo(anexo);

            //if (ticket.Invalid)
            //    return new Response(false, "Ticket inválido", ticket.Notifications);

            //_repositorioTicket.Editar(ticket);
            _repositorioAnexo.Remover(anexo);

            var result = new Response(true, "Anexo excluído com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
