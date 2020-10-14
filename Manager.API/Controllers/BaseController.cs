using Manager.Domain.Core.Comandos;
using Manager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(Response response)
        {
            if(response.Mensagem.Any())
            {
                try
                {
                    _unitOfWork.SaveChanges();
                    return await Task.FromResult(Ok(response));

                }
                catch(Exception ex)
                {
                    return await Task.FromResult(BadRequest("Ocorreu um erro. Detalhes: " + ex.Message));
                    //return BadRequest("Ocorreu um problema. Detalhes: " + ex.Message);
                }
            }
            else
            {
                return await Task.FromResult(Ok(response));
                //return Ok(response);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
