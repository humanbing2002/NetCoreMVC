using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models.DISample;

namespace NetCoreMVC.Controllers
{
    public class DILifeCycleController : Controller
    {
        private  ISampleTransient _transientsample;
        private  ISampleScoped _scopedsample;
        private  ISampleSingleton _singletonsample;

        public DILifeCycleController( ISampleTransient transientsample, ISampleScoped scopedsample, ISampleSingleton singletonsample)
        {
            _transientsample = transientsample;
            _scopedsample = scopedsample;
            _singletonsample = singletonsample;
        }
        public IActionResult Index()
        {
            ViewBag.TransientId = _transientsample.Id;
            ViewBag.TransientHashCode = _transientsample.GetHashCode();

            ViewBag.ScopedId = _scopedsample.Id;
            ViewBag.ScopedHashCode = _scopedsample.GetHashCode();

            ViewBag.SingletonId = _singletonsample.Id;
            ViewBag.SingletonHashCode = _singletonsample.GetHashCode();
            return View();
        }
    }
}