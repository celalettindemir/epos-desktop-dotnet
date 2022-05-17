using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    public class OrderItem
    {
        public String ID { get; set; }
        public Product product { get; set; }
        public Double TotalPrice { get; set; }
        public int Count { get; set; } = 1;
        public List<ProductItemSelect> productItemSelect { get; set; }
    }
}
