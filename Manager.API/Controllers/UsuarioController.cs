using Manager.Domain.Core.Comandos.Usuarios;
using Manager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Novo")]
        public async Task<IActionResult> NovoUsuario([FromBody] RegistrarNovoUsuario request)
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
        [Route("api/Usuario/Editar")]
        public async Task<IActionResult> EditarUsuario([FromBody] EditarUsuario request)
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
        [Route("api/Usuario/Excluir")]
        public async Task<IActionResult> ExcluirUsuario([FromBody] ExcluirUsuario request)
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
        [Route("api/Usuario/Ativar")]
        public async Task<IActionResult> AtivarUsuario([FromBody] AtivarUsuario request)
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
