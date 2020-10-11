using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Categorias;
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
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CategoriaController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        private async Task<IActionResult> ResponseAsync(Response response)
        {
            if(response.Mensagem.Any())
            {
                try
                {
                    _unitOfWork.SaveChanges();
                    return Ok(response);
                }
                catch(Exception ex)
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
        [Route("api/Categoria/Adicionar")]
        public async Task<IActionResult> AdicionarCategoria([FromBody]NovaCategoriaRequest request)
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
    }
}
