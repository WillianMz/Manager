using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Interfaces;
using Manager.Domain.Queries.Consultas.Releases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class ReleaseController : BaseController
    {
        private readonly IMediator _mediator;

        public ReleaseController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Projeto/Release/Novo")]
        public async Task<IActionResult> NovaRelease ([FromBody] AdicionarRelease request)
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
        [Route("api/Projeto/Release/Editar")]
        public async Task<IActionResult> EditarRelease([FromBody] EditarRelease request)
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
        [Route("api/Projeto/Release/Excluir")]
        public async Task<IActionResult> ExcluirRelease([FromBody] ExcluirRelease request)
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

        //CONSULTAS
        [AllowAnonymous]
        [HttpGet]
        [Route("api/Projeto/Release/Listar")]
        public async Task<IActionResult> ProcurarPorNome([FromQuery] FiltrarReleasesPorProjeto request)
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
    }
}
