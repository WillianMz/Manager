using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Interfaces;
using Manager.Domain.Queries.Consultas.Tickets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class TicketController : BaseController
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        #region CONSULTAS

        [AllowAnonymous]//para testes
        [HttpGet]
        [Route("api/Tickets/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var request = new ListarTickets();
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseQuerieAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]//para testes
        [HttpGet]
        [Route("api/Tickets/Nome")]
        public async Task<IActionResult> ProcurarPorNome([FromQuery] TicketPorNome request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseQuerieAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]//para testes
        [HttpGet]
        [Route("api/Tickets/ID")]
        public async Task<IActionResult> ProcurarPorID([FromQuery] TicketPorID request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseQuerieAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]//para testes
        [HttpGet]
        [Route("api/Tickets/Detalhes/ID")]
        public async Task<IActionResult> DetalhesDoTicket([FromQuery] DetalhesDoTicket request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseQuerieAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region TICKETS

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Ticket/Novo")]
        public async Task<IActionResult> NovoTicket([FromBody] CriarTicket request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/Ticket/Editar")]
        public async Task<IActionResult> Editaricket([FromBody] EditarTicket request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPut]
        [Route("api/Ticket/Finalizar")]
        public async Task<IActionResult> Finalizar([FromBody] FinalizarTicket request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/Ticket/Cancelar")]
        public async Task<IActionResult> Cancelar([FromBody] CancelarTicket request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

    }
}
