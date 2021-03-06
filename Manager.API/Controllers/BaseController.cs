﻿using Manager.Domain.Core;
using Manager.Domain.Interfaces;
using Manager.Domain.Queries;
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
                    //throw new Exception(ex.Message);
                    //return BadRequest("Ocorreu um problema. Detalhes: " + ex.Message);
                }
            }
            else
            {
                return await Task.FromResult(Ok(response));
                //return Ok(response);
            }
        }


        public async Task<IActionResult> ResponseQuerieAsync(ResponseQueries response)
        {
            if (response.Mensagem.Any())
            {
                try
                {
                    return await Task.FromResult(Ok(response));

                }
                catch (Exception ex)
                {
                    return await Task.FromResult(BadRequest("Ocorreu um erro. Detalhes: " + ex.Message));
                }
            }
            else
            {
                return await Task.FromResult(Ok(response));
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
