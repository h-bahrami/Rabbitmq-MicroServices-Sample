using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared;

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


        [HttpGet("{num}")]
        public async Task<IActionResult> Get(int num = 3)
        {
            var messages = new List<string>(num);
            var start = DateTime.Now;
            for(int i = 0; i<num; i++)
            {
                var result = await bus.Request<Service1Command, RequestServiceProcessed>(
                    new Service1CommandImp() { Id = 100, Title = "Change the value" });
                messages.Add(JsonConvert.SerializeObject(result.Message));
            }

            var timespan = DateTime.Now - start;

            return Ok(new {
                Seconds = timespan.TotalSeconds,
                Items = messages
            });
        }

        private class Service1CommandImp : Service1Command
        {
            public int Id {get; set;}

            public string Title {get; set;}
        }
    }
}