using Manager.Domain.Core.Comandos.Categorias;
using Manager.Domain.Interfaces;
using Manager.Domain.Queries.Consultas.Categorias;
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

        #region SERVICO DE CONSULTAS

        [AllowAnonymous]//para testes
        [HttpGet]
        [Route("api/Categoria/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var request = new ListarCategorias();
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
        [Route("api/Categoria/Nome")]
        public async Task<IActionResult> ProcurarPorNome([FromQuery] CategoriaPorNome request)
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
        [Route("api/Categoria/ID")]
        public async Task<IActionResult> ProcurarPorId([FromQuery] CategoriaPorID request)
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
        [HttpPut]
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
