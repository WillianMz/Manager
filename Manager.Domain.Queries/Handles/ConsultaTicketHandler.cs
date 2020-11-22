using Manager.Domain.Queries.Consultas.Tickets;
using Manager.Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class ConsultaTicketHandler : IRequestHandler<ListarTickets, ResponseQueries>,
                                         IRequestHandler<TicketPorID, ResponseQueries>,
                                         IRequestHandler<TicketPorNome, ResponseQueries>,
                                         IRequestHandler<DetalhesDoTicket, ResponseQueries>
    {
        private readonly IConsultaTicket _consultaTicket;

        public ConsultaTicketHandler(IConsultaTicket consultaTicket)
        {
            _consultaTicket = consultaTicket;
        }

        public async Task<ResponseQueries> Handle(ListarTickets request, CancellationToken cancellationToken)
        {
            var tickets = await _consultaTicket.Listar();

            if (tickets.Count == 0)
                return new ResponseQueries(false, "Nenhum ticket encontrado", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Tickets", tickets);
        }

        public async Task<ResponseQueries> Handle(TicketPorID request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe o ID do ticket", null);

            var ticket = await _consultaTicket.ProcurarPorID(request.Id);            

            if (ticket == null)
                return new ResponseQueries(false, "Nenhum ticket encontrado com o ID: " + request.Id, null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Ticket", ticket);
        }

        public async Task<ResponseQueries> Handle(TicketPorNome request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe um nome para pesquisar", null);

            var tickets = await _consultaTicket.ListarPorNome(request.Nome);

            if (tickets.Count == 0)
                return new ResponseQueries(false, "Nenhum ticket encontrado", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Tickets", tickets);
        }

        public async Task<ResponseQueries> Handle(DetalhesDoTicket request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe o ID do ticket", null);

            var ticket = await _consultaTicket.ConsultarDetalhes(request.Id);

            if (ticket == null)
                return new ResponseQueries(false, "Nenhum ticket encontrado com o ID: " + request.Id, null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Ticket", ticket);
        }
    }
}
