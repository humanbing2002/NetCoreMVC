using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVC.Models
{
    public class modelOrder
    {
        public Guid ID { get; set; }
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDT { get; set; }
        public decimal Number { get; set; }
        public decimal EachPrice { get; set; }


    }
}
