using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class AnexoController : BaseController
    {
        private readonly IMediator _mediator;

        public AnexoController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Ticket/Anexo/Novo")]
        public async Task<IActionResult> NovoAnexo ([FromBody] AdicionarAnexo request)
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
        [Route("api/Ticket/Anexo/Excluir")]
        public async Task<IActionResult> ExcluirAnexo ([FromBody] ExcluirAnexo request)
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
