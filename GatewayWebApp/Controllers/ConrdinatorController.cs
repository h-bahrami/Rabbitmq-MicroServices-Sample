using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GatewayWebApp.Controllers
{
    public class ConrdinatorController : Controller
    {
        [Route("Cordinator/Index")]
        public IActionResult Index()
        {
            ViewBag.Message = $"Process Started {DateTime.Now}";
            return View();
        }

        //[Route("Cordinator/StartProcess")]
        //public IActionResult StartProcess()
        //{            
        //    return View();
        //}
    }
}