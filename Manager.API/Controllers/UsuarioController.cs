using Manager.Domain.Core.Comandos.Usuarios;
using Manager.Domain.Interfaces;
using Manager.Domain.Queries.Consultas.Usuarios;
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

        [AllowAnonymous]//para testes
        [HttpGet]
        [Route("api/Usuarios/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var request = new ListarUsuarios();
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
        [Route("api/Usuarios/Nome")]
        public async Task<IActionResult> ProcurarPorNome([FromQuery] UsuarioPorNome request)
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
        [Route("api/Usuarios/ID")]
        public async Task<IActionResult> ProcurarPorID([FromQuery] UsuarioPorID request)
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
