using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    public class Category
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public Double ButtonWidth { get; set; }
        public List<Product> Products { get; set; }
    }
}
