using System;
using System.Collections.Generic;
using System.Text;

namespace EposWpf.Model
{
    static class StaticData
    {
        public static List<Category> categoryList = new List<Category>() {
            new Category()
            {
                ID=2,
                Name="KEBAB",
                Products=new List<Product>() {
                    new Product()
                    {
                        ID=12,
                        Title="REG",
                        Price=5.90,
                        PositionId=1,
                        Name="Lamb Doner",
                        Color="#FFFF0235"
                    },
                    new Product()
                    {
                        ID=14,
                        Title="LRG",
                        Price=7.50,
                        PositionId=2,
                        Name="Lamb Doner",
                        Color="#FFFF0235"
                    },
                    new Product()
                    {
                        ID=15,
                        Title="MEG",
                        Price=8.90,
                        PositionId=3,
                        Name="Lamb Doner",
                        Color="#FFFF0235"
                    },
                    new Product()
                    {
                        ID=16,
                        Title="REG",
                        Price=5.90,
                        PositionId=5,
                        Name="Chicken Doner",
                        Color="#FFFF4835"
                    },
                    new Product()
                    {
                        ID=17,
                        Title="REG",
                        Price=6.50,
                        PositionId=8,
                        Name="Mixed Doner",
                        Color="#FFFF0266"
                    },
                }
            },
            new Category()
            {
                ID=3,
                Name="COMBO",
                Products=new List<Product>() {
                    new Product()
                    {
                        ID=21,
                        Title="REG",
                        Price=6.90,
                        PositionId=1,
                        Name="Lamb Doner",
                        Color="#FFFF1235"
                    },
                    new Product()
                    {
                        ID=22,
                        Title="LRG",
                        Price=8.50,
                        PositionId=2,
                        Name="Lamb Doner",
                        Color="#FFFF1235"
                    },
                    new Product()
                    {
                        ID=23,
                        Title="MEG",
                        Price=6.90,
                        PositionId=3,
                        Name="Lamb Doner",
                        Color="#FFFF1235"
                    },
                    new Product()
                    {
                        ID=24,
                        Title="REG",
                        Price=6.90,
                        PositionId=5,
                        Name="Chips & Chicken Doner",
                        Color="#FFFF4835"
                    },
                    new Product()
                    {
                        ID=25,
                        Title="LRG",
                        Price=8.50,
                        PositionId=8,
                        Name="Chips & Chicken Doner",
                        Color="#FFFF4835"
                    },
                }
            },
            new Category()
            {
                ID=5,
                Name="WRAP",
                Products= new List<Product>() {
                        new Product()
                        {
                            ID=34,
                            Title="1/4lb",
                            Price=3.90,
                            PositionId=1,
                            Name="Beef Burger",
                            Color="#FFFF3335"
                        },
                        new Product()
                        {
                            ID=35,
                            Title="1/2lb",
                            Price=4.90,
                            PositionId=2,
                            Name="Beef Burger",
                            Color="#FFFF3335"
                        },
                        new Product()
                        {
                            ID=36,
                            Title="1/4lb",
                            Price=4.20,
                            PositionId=9,
                            Name="Cheese Burger",
                            Color="#FFFF1235"
                        },
                        new Product()
                        {
                            ID=37,
                            Title="1/2lb",
                            Price=5.90,
                            PositionId=10,
                            Name="Cheese Burger",
                            Color="#FFFF1235"
                        },
                    }
                },
            new Category()
            {
                ID=6,
                Name="BURGER"
            },
            new Category()
            {
                ID=7,
                Name="VEGETARIAN"
            },
            new Category()
            {
                ID=8,
                Name="CHICKEN"
            },
            new Category()
            {
                ID=9,
                Name="SIDES"
            },
            new Category()
            {
                ID=11,
                Name="KIDS"
            },
            new Category()
            {
                ID=12,
                Name="DESSERTS"
            },
            new Category()
            {
                ID=22,
                Name="DRINKS"
            },
            new Category()
            {
                ID=23,
                Name="D/C"
            }

        };

        public static List<ProductItemSelect> productItemSelects = new List<ProductItemSelect>()
        {
            new ProductItemSelect()
            {
                ID=1,
                Title="Additions",
                Type=ItemType.Any,
                Values=new List<ItemSelect>()
                {
                    new ItemSelect(){
                        ID=1,
                        Name="No Pitta",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=2,
                        Name="Pitta Separate",
                        Price=3
                        },
                    new ItemSelect(){
                        ID=3,
                        Name="Pineapple",
                        Price=4
                        },
                    new ItemSelect(){
                        ID=4,
                        Name="Plain",
                        Price=1
                        },
                    new ItemSelect(){
                        ID=5,
                        Name="Grilled Halloumi",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=6,
                        Name="Grilled Halloumi",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=7,
                        Name="Salad Separate",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=8,
                        Name="Well Done Meat",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=9,
                        Name="Grated Cheese",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=10,
                        Name="Mushrooms",
                        Price=4
                        },
                    new ItemSelect(){
                        ID=11,
                        Name="Slice Cheese",
                        Price=3
                        },
                    new ItemSelect(){
                        ID=12,
                        Name="+2.00 Lamb Doner",
                        Price=1.9
                        },
                    new ItemSelect(){
                        ID=13,
                        Name="+2.00 Chicken Doner",
                        Price=2.1
                        },
                    new ItemSelect(){
                        ID=14,
                        Name="Lemon Juice",
                        Price=3.2
                        },
                    new ItemSelect(){
                        ID=15,
                        Name="Extra Lamb Shish",
                        Price=3.3
                        },
                    new ItemSelect(){
                        ID=16,
                        Name="Extra Kofte Shish",
                        Price=2.2
                        },
                    new ItemSelect(){
                        ID=17,
                        Name="Extra Grilled Onion",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=18,
                        Name="No Grilled Peppers",
                        Price=2
                        },
                    new ItemSelect(){
                        ID=19,
                        Name="Extra Grilled Peppers",
                        Price=2
                        },
                },
            },
            new ProductItemSelect()
            {
                ID=2,
                Title="Sauce",
                Type=ItemType.Portion,
                Values=new List<ItemSelect>()
                {

                    new ItemSelect(){
                        ID=20,
                        Name="Chilli Sauce",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },

                    new ItemSelect(){
                        ID=21,
                        Name="Garlic Mayo",
                        Price=3,
                        LPrice=2.3,
                        EPrice=4.3
                        },

                    new ItemSelect(){
                        ID=22,
                        Name="Yogurt Mint",
                        Price=1,
                        LPrice=0.3,
                        EPrice=1.3
                        },
                    new ItemSelect(){
                        ID=23,
                        Name="BBQ Sauce",
                        Price=3,
                        LPrice=1.4,
                        EPrice=5.3
                        },
                    new ItemSelect(){
                        ID=24,
                        Name="Burger Sauce",
                        Price=2,
                        LPrice=1,
                        EPrice=3.4
                        },
                    new ItemSelect(){
                        ID=25,
                        Name="Ketchup",
                        Price=1.4,
                        LPrice=1.2,
                        EPrice=1.6
                        },
                    new ItemSelect(){
                        ID=26,
                        Name="Crushed Chilli Flakes",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },
                },
            },
            new ProductItemSelect()
            {
                ID=3,
                Title="Salad",
                Type=ItemType.Portion,
                Values=new List<ItemSelect>()
                {
                    new ItemSelect(){
                        ID=27,
                        Name="Onion",
                        Price=3,
                        LPrice=1.3,
                        EPrice=4.3
                        },
                    new ItemSelect(){
                        ID=28,
                        Name="Lettuce",
                        Price=8,
                        LPrice=3.3,
                        EPrice=9.3
                        },
                    new ItemSelect(){
                        ID=29,
                        Name="Cabbage",
                        Price=5,
                        LPrice=3.3,
                        EPrice=7.3
                        },
                    new ItemSelect(){
                        ID=30,
                        Name="Tomato",
                        Price=3,
                        LPrice=2.3,
                        EPrice=4.3
                        },
                    new ItemSelect(){
                        ID=31,
                        Name="Cucumber",
                        Price=4,
                        LPrice=2.3,
                        EPrice=5.3
                        },
                },
                DefaultAll=true
            },
            new ProductItemSelect()
            {
                ID=4,
                Title="Chilli Peppers",
                Type=ItemType.Portion,
                Values=new List<ItemSelect>()
                {
                    new ItemSelect(){
                        ID=32,
                        Name="Chilli Peppers",
                        Price=3,
                        LPrice=2.3,
                        EPrice=4.3
                        },
                }
            },
            new ProductItemSelect()
            {
                ID=5,
                Title="Sauce Pots",
                Type=ItemType.Any,
                Values=new List<ItemSelect>()
                {
                    new ItemSelect(){
                        ID=33,
                        Name="Pot Chilli Sauce",
                        Price=5,
                        LPrice=3.3,
                        EPrice=7.3
                        },
                    new ItemSelect(){
                        ID=34,
                        Name="Pot Burger Sauce",
                        Price=4,
                        LPrice=3.3,
                        EPrice=6.3
                        },
                    new ItemSelect(){
                        ID=35,
                        Name="Pot Garlic Mayo",
                        Price=3,
                        LPrice=1.3,
                        EPrice=4.3
                        },
                    new ItemSelect(){
                        ID=36,
                        Name="Pot BBQ Sauce",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },
                    new ItemSelect(){
                        ID=37,
                        Name="Pot Ketchup",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },
                }
            },
            new ProductItemSelect()
            {
                ID=6,
                Title="Salt & Vinegar",
                Type=ItemType.One,
                Values=new List<ItemSelect>()
                {
                    new ItemSelect(){
                        ID=38,
                        Name="Salt",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },
                    new ItemSelect(){
                        ID=39,
                        Name="Salt & Vinegar",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },
                    new ItemSelect(){
                        ID=40,
                        Name="Vinegar",
                        Price=2,
                        LPrice=1.3,
                        EPrice=2.3
                        },
                }
            },
        };
    }
}
