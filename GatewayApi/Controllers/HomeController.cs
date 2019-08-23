using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GatewayApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBus bus;

        public HomeController(IBus bus)
        {
            this.bus = bus;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            bus.Send()

            return Ok(new { Message = "Hello"});
        }

        private class 
    }
}