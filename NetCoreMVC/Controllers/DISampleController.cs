using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static NetCoreMVC.Models.DISample.DISample;

namespace NetCoreMVC.Controllers
{
    public class DISampleController : Controller
    {
        private readonly ISample _diSample;
        public DISampleController(ISample disample)
        {
            _diSample = disample;
        }
        public string Index()
        {
            return $"[ISample]\r\n"
            + $"Id: {_diSample.Id}\r\n"
       + $"HashCode: {_diSample.GetHashCode()}\r\n"
       + $"Tpye: {_diSample.GetType()}";
            //return View();
            //   return View();
        }
    }
}