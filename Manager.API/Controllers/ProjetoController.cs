using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class ProjetoController : BaseController
    {
        private readonly IMediator _mediator;

        public ProjetoController(IMediator mediator, IUnitOfWork unitOfWork): base(unitOfWork)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Projetos/Novo")]
        public async Task<IActionResult> NovoProjeto([FromBody]CriarProjeto request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/Projetos/Editar")]
        public async Task<IActionResult> EditarProjeto([FromBody] EditarProjeto request)
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
        [Route("api/Projetos/Excluir")]
        public Task<IActionResult> ExcluirProjeto()
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/Projetos/Membros")]
        public async Task<IActionResult> AdicionarMembro([FromBody] EquipeDoProjeto request)
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
