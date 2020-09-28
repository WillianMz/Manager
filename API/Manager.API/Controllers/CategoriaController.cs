using Manager.Infra.Data.Transacoes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Adicionar")]
        //public async Task<IActionResult> Adicionar([FromBody]AdicionarCategoriaRequest request)
        //{
        //    try
        //    {
        //        var response = await _mediator.Send(request, CancellationToken.None);
        //        return await ResponseAsync(response);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
