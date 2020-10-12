using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public TicketController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        private async Task<IActionResult> ResponseAsync(Response response)
        {
            if (response.Mensagem.Any())
            {
                try
                {
                    _unitOfWork.SaveChanges();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Detalhes: " + ex.Message);
                }
            }
            else
            {
                return Ok(response);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Ticket/Novo")]
        public async Task<IActionResult> Novo([FromBody] CriarTicket request)
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
        public async Task<IActionResult> Editar([FromBody] EditarTicket request)
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
        [HttpDelete]
        [Route("api/Ticket/Delete")]
        public async Task<IActionResult> Excluir([FromBody] ExcluirTicket request)
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
    }
}
