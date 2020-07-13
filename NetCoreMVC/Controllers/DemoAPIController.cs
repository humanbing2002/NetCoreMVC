using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoAPIController : ControllerBase
    {
        [HttpGet("DEMO")]
        public string GetDemo()        
        {
            return "DEMO";
        }

        [HttpGet("GetTEST")]
        public string GetTEST()
        {
            return "TEST";
        }

        [HttpGet("/Route/RTest")]
        public string GetRouteTEST()
        {
            return "RouteTEST";
        }

        [HttpGet]
        [Route("/GetNewRouteTEST")]
        public string GetNewRouteTEST()
        {
            return "NewRouteTEST";
        }

 
    }
}