using Manager.Infra.Data.Transacoes;
using Manager.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(Response response)
        {
            //se nao existir notificações
            if(!response.Notifications.Any())
            { 
                try
                {
                    _unitOfWork.SaveChanges();
                    return Ok(response);
                }
                catch(Exception ex)
                {
                    return BadRequest($"Houve um problema internoo com o servidor. Entre em contato com o Administrador do sistema caso o problema persista." +
                                      $"Detalhes do erro ocorrido: {ex.Message}");
                }
            }
            else
            {
                return Ok(response);
            }
        }

        public IActionResult ResponseException(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
