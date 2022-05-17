using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    public class Order
    {
        public int ID { get; set; }
        public Double TotalPrice { get; set; }
        public List<OrderItem> orderItem {get;set;}
    }
}
