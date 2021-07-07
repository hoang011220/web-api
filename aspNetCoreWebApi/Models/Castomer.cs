using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspNetCoreWebApi.Customer
{
    public class Castomer
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
