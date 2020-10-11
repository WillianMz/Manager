using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Manager.API.Controllers
{
    
    public class PingPongController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("api/ping")]
        public string Post(string ping)
        {
            try
            {
                if (ping == "ping")
                    return "pong";
                else
                    return "Você não deu ping!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
