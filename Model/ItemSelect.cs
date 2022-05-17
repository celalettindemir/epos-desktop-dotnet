using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    public class ItemSelect
    {
        public int ID { get; set; }
        public String Name { get; set; }
        //0 Secili Degil
        //1 Secili
        //2 Little
        //3 Extra
        public int Selected { get; set; }
        public Double Price { get; set; }
        public Double LPrice { get; set; }
        public Double EPrice { get; set; }
    }
}
