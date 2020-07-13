using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models;

namespace NetCoreMVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {

            return View(GetOrders());
        }
        public List<modelOrder> GetOrders()
        {
            List<modelOrder> orders = new List<modelOrder>();
            for (int i = 1; i < 10; i++)
            {
                orders.Add(new modelOrder
                {
                    ID = Guid.NewGuid(),
                    OrderNo = i.ToString(),
                    OrderDT = DateTime.Now,
                    CustomerName = $"Cust{i}",
                    EachPrice = 10,
                    Number = 5,
                });
            }
            return orders;
        }
    }
}