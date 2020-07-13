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
    public class RestFulController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Get";
        }
        [HttpPost]
        public string Post()
        {
            return "Post";
        }
        [HttpPut]
        public string Put()
        {
            return "Put";
        }
        [HttpDelete]
        public string Delete()
        {
            return "Delete";
        }
    }
}