using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFtest.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public int ItemCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
    }
}
