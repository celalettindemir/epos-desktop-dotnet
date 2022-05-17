using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    public enum ItemType
    {
        Any,
        Portion,
        One
    }
    public class ProductItemSelect
    {
        public int ID { get; set; }
        public ItemType Type { get; set; }
        public String Title { get; set; }
        public List<ItemSelect> Values { get; set; }
        public Boolean DefaultAll { get; set; } = false;
    }
}
