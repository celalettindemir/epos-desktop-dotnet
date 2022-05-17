using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    public class Product
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public Double Price { get; set; }
        public String Name { get; set; }
        public int PositionId { get; set; }
        public String Color { get; set; }
    }
}
