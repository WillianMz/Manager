using Manager.Domain.Core.Comandos.Categorias;
using Manager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class CategoriaController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        //teste
        private async Task<IActionResult>ExecutarComando(CriarCategoria obj)
        {
            try
            {
                var response = await _mediator.Send(obj, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]//para testes
        [HttpPost]
        [Route("api/Categoria/Adicionar")]
        public async Task<IActionResult> AdicionarCategoria([FromBody] CriarCategoria request)
        {
            return await ExecutarComando(request);
        }

        [AllowAnonymous]//para testes
        [HttpPost]
        [Route("api/Categoria/Editar")]
        public async Task<IActionResult> EditarCategoria([FromBody] EditarCategoria request)
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
