using EposWpf.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EposWpf.View
{
    /// <summary>
    /// OrderItem.xaml etkileşim mantığı
    /// </summary>
    public partial class OrderItemUC : UserControl
    {

        public OrderItemUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public Button productBtn
        {
            get
            {
                return _productBtn;
            }
        }
        public OrderItem SelectOrderItem { get; set; }
        public string Title{get;set; }
        public string ProductName { get; set; }
        public Double Price { get; set; }
        public String PriceText { get; set; }
        private List<ProductItemSelect> _ProductItemSelects { get; set; }
        public List<ProductItemSelect> ProductItemSelects { 
            get 
            {
                return _ProductItemSelects;
            } 
            set
            {
                int i = 0;
                foreach(var textBlock in OrderItemStack.Children)
                {
                    if(textBlock is TextBlock)
                    {
                        TextBlock textBlock1 = textBlock as TextBlock;
                        if (value.Count > i)
                        {
                            ProductItemSelect productItemSelect = value[i];
                            i++;
                            String liste = "☆ ";
                            if (productItemSelect.Values.All(p => p.Selected == 0))
                            {
                                textBlock1.Visibility = Visibility.Collapsed;
                                continue;
                            }
                            foreach(var itemSelect in productItemSelect.Values)
                            {
                                switch(itemSelect.Selected)
                                {
                                    //Select
                                    case 1:
                                        liste += itemSelect.Name + ", ";
                                        break;
                                    //Little Select
                                    case 2:
                                        liste += "Little " + itemSelect.Name + ", ";
                                        break;
                                    //Extra Select
                                    case 3:
                                        liste += "Extra " + itemSelect.Name + ", ";
                                        break;
                                }
                            }
                            textBlock1.Text = liste.Remove(liste.Length - 2);
                            textBlock1.Visibility = Visibility.Visible;
                        }
                        else
                            textBlock1.Visibility = Visibility.Collapsed;
                        

                    }
                }
                _ProductItemSelects = value;
            } 
        }
        public List<TextBlock> textBlocks { get; set; }
        /*
        public void AddorUpdateItem(int index,ItemSelect itemSelect)
        {
            int itemIndex=ItemSelects.FindIndex(p => p.ID == itemSelect.ID);
            ItemSelect ıtemSelect= ItemSelects[itemIndex];
            TextBlock textBlock;
            if (ıtemSelect == null)
            {
                ıtemSelect = new ItemSelect() { 
                    ID = itemSelect.ID,
                    Name=itemSelect.Name,
                    Price=itemSelect.Price,
                    EPrice=itemSelect.EPrice,
                    LPrice=itemSelect.LPrice,
                    Selected=itemSelect.Selected };
                textBlock = new TextBlock()
                {
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "☆ ",
                    Padding = new Thickness(20, 0, 0, 0)
                };
                switch (ıtemSelect.Selected)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                return;
            }
            ıtemSelect.Name = itemSelect.Name;
            ıtemSelect.Price= itemSelect.Price;
            ıtemSelect.LPrice = itemSelect.LPrice;
            ıtemSelect.EPrice = itemSelect.EPrice;

        }*/
        /*
        public void AddAdditions(String Addition)
        {
            AddAdditions(Additions.Count, Addition);
        }
        public void AddAdditions(int index,String Addition)
        {
            if(index>= Additions.Count)
            {
                TextBlock textBlock = new TextBlock()
                {
                    FontSize = 16,
                    Uid = index.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    Text= Addition,
                    Padding = new Thickness(20, 0, 0, 0)
                };
                OrderItemStack.Children.Add(textBlock);
            }
            else
            {
                foreach (var item in OrderItemStack.Children)
                {
                    if (item is TextBlock)
                    {
                        TextBlock textBlock = (item as TextBlock);
                        if (textBlock == null) continue;

                        if (textBlock.Uid == index.ToString()) textBlock.Text=Addition;
                    }
                }
            }
                
            Additions.Insert(index, Addition);
        }*/
    }
}
