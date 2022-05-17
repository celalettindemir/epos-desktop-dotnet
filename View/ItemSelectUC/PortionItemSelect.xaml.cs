using EposWpf.Model;
using EposWpf.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EposWpf.View
{
    /// <summary>
    /// PortionItemSelect.xaml etkileşim mantığı
    /// </summary>
    public partial class PortionItemSelect : UserControl
    {
        public PortionItemSelect()
        {
            InitializeComponent();
            DataContext = this;
            redSolidColor = new SolidColorBrush(Colors.Red);
            blueSolidColor = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
            foreach (var Items in SelectContent.Children)
            {
                if (Items is PortionItemRow)
                {
                    PortionItemRow btn = Items as PortionItemRow;

                    btn.LittleBtn.Click += Little_Button_Select;
                    btn.MediumBtn.Click += Medium_Button_Select;
                    btn.ExtraBtn.Click += Extra_Button_Select;
                }
            }
        }
        private SolidColorBrush redSolidColor { get; set; }
        private SolidColorBrush blueSolidColor { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public int ProductItemId { get; set; }
        public Boolean DefaultAll { get; set; }

        
        public delegate void AddandUpdate(int index);

        public AddandUpdate addandUpdate { get; set; }


        private List<ItemSelect> _ItemSelects { get; set; }
        public List<ItemSelect> ItemSelects
        {
            get
            {
                return _ItemSelects;
            }
            set
            {
                int i = -1;
                foreach (var Items in SelectContent.Children)
                {
                    if (Items is PortionItemRow)
                    {
                        PortionItemRow btn = Items as PortionItemRow;
                        if (DefaultAll && i<0 )
                        {
                            btn.Visibility = Visibility.Visible;
                            btn._content = "All";
                            btn.LittleBtn.Uid = "0";
                            btn.MediumBtn.Uid = "0";
                            btn.ExtraBtn.Uid = "0";
                            if(value.All(p => p.Selected == 0))
                            {
                                btn.LittleBtn.Background = redSolidColor;
                                btn.MediumBtn.Background = redSolidColor;
                                btn.ExtraBtn.Background = redSolidColor;
                            }
                            else
                            {
                                btn.LittleBtn.Background = blueSolidColor;
                                btn.MediumBtn.Background = blueSolidColor;
                                btn.ExtraBtn.Background = blueSolidColor;
                            }
                            i++;
                            continue;
                        }
                        else if(i < 0)
                            i++;
                        if (i < value.Count)
                        {

                            btn.Visibility = Visibility.Visible;
                            btn._content = value[i].Name;
                            btn.Uid = value[i].ID.ToString();
                            btn.LittleBtn.Uid = value[i].ID.ToString();
                            btn.MediumBtn.Uid = value[i].ID.ToString();
                            btn.ExtraBtn.Uid = value[i].ID.ToString();
                            if (value[i].Selected == 0)
                            {
                                btn.LittleBtn.Background = blueSolidColor;
                                btn.MediumBtn.Background = blueSolidColor;
                                btn.ExtraBtn.Background = blueSolidColor;
                            }
                            else if (value[i].Selected == 2)
                            {
                                btn.LittleBtn.Background = redSolidColor;
                                btn.MediumBtn.Background = blueSolidColor;
                                btn.ExtraBtn.Background = blueSolidColor;
                            }
                            else if (value[i].Selected == 1)
                            {
                                btn.LittleBtn.Background = blueSolidColor;
                                btn.MediumBtn.Background = redSolidColor;
                                btn.ExtraBtn.Background = blueSolidColor;
                            }
                            else if (value[i].Selected == 3)
                            {
                                btn.LittleBtn.Background = blueSolidColor;
                                btn.MediumBtn.Background = blueSolidColor;
                                btn.ExtraBtn.Background = redSolidColor;
                            }
                        }
                        else
                        {
                            if (btn.Visibility == Visibility.Collapsed)
                                break;
                            btn.Visibility = Visibility.Collapsed;
                        }
                        i++;

                    }
                }
                _ItemSelects = value;


            }

        }
        //#FF2196F3
        private void Little_Button_Select(object sender, RoutedEventArgs e)
        {
            Button sipButton = (Button)e.Source;
            ItemSelect ıtemSelect = ItemSelects.Find(p => p.ID == Int32.Parse(sipButton.Uid));
            if (DefaultAll && sipButton.Uid == "0")
            {
                foreach (var btn in SelectContent.Children)
                {
                    ItemSelects.ForEach(x => x.Selected = 0);
                    (btn as PortionItemRow).LittleBtn.Background = blueSolidColor;
                    (btn as PortionItemRow).MediumBtn.Background = blueSolidColor;
                    (btn as PortionItemRow).ExtraBtn.Background = blueSolidColor;
                }
                (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = redSolidColor;
                (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = redSolidColor;
                (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = redSolidColor;
                addandUpdate(Int32.Parse(this.Uid));
                return;
            }
            else if (DefaultAll)
            {
                (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = blueSolidColor;
                (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = blueSolidColor;
                (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = blueSolidColor;
            }
            foreach (var btn in SelectContent.Children)
            {
                PortionItemRow selectBtn = btn as PortionItemRow;
                if(selectBtn.Uid==sipButton.Uid)
                {
                    if (ıtemSelect.Selected == 2)
                    {
                        selectBtn.MediumBtn.Background = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
                        ıtemSelect.Selected = 0;
                        sipButton.Background = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
                        if (ItemSelects.All(p => p.Selected == 0) && DefaultAll)
                        {
                            (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = redSolidColor;
                            (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = redSolidColor;
                            (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = redSolidColor;
                        }
                        addandUpdate(Int32.Parse(this.Uid));
                        return;
                    }
                    else if (ıtemSelect.Selected==1)
                        selectBtn.MediumBtn.Background = blueSolidColor;
                    else if(ıtemSelect.Selected == 3)
                        selectBtn.ExtraBtn.Background = blueSolidColor;
                    break;
                }
            }
            ıtemSelect.Selected = 2;
            sipButton.Background = redSolidColor;
            addandUpdate(Int32.Parse(this.Uid));
            //OrderItem.AddAdditions("☆ Chilli Sauce, Extra Garlic Mayo, Extra BBQ Sauce, Extra Ketchup");
            //OrderItem.AddAdditions("Chery Sauce");
        }
        private void Medium_Button_Select(object sender, RoutedEventArgs e)
        {
            Button sipButton = (Button)e.Source;
            ItemSelect ıtemSelect = ItemSelects.Find(p => p.ID == Int32.Parse(sipButton.Uid));
            if (DefaultAll && sipButton.Uid == "0")
            {
                foreach (var btn in SelectContent.Children)
                {
                    ItemSelects.ForEach(x => x.Selected = 0);
                    (btn as PortionItemRow).LittleBtn.Background = blueSolidColor;
                    (btn as PortionItemRow).MediumBtn.Background = blueSolidColor;
                    (btn as PortionItemRow).ExtraBtn.Background = blueSolidColor;
                }
                (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = redSolidColor;
                (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = redSolidColor;
                (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = redSolidColor;
                addandUpdate(Int32.Parse(this.Uid));
                return;
            }
            else if (DefaultAll)
            {
                (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = blueSolidColor;
                (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = blueSolidColor;
                (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = blueSolidColor;
            }
            foreach (var btn in SelectContent.Children)
            {
                PortionItemRow selectBtn = btn as PortionItemRow;
                if (selectBtn.Uid == sipButton.Uid)
                {
                    if (ıtemSelect.Selected == 1)
                    {
                        selectBtn.MediumBtn.Background = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
                        ıtemSelect.Selected = 0;
                        sipButton.Background = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
                        if (ItemSelects.All(p=>p.Selected==0)&& DefaultAll)
                        {
                            (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = redSolidColor;
                            (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = redSolidColor;
                            (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = redSolidColor;
                        }
                        addandUpdate(Int32.Parse(this.Uid));
                        return;
                    }
                    else if (ıtemSelect.Selected == 2)
                        selectBtn.LittleBtn.Background = blueSolidColor;
                    else if (ıtemSelect.Selected == 3)
                        selectBtn.ExtraBtn.Background = blueSolidColor;
                    break;
                }
            }
            ıtemSelect.Selected = 1;
            sipButton.Background = new SolidColorBrush(Colors.Red);
            addandUpdate(Int32.Parse(this.Uid));
            //OrderItem.AddAdditions("☆ Chilli Sauce, Extra Garlic Mayo, Extra BBQ Sauce, Extra Ketchup");
            //OrderItem.AddAdditions("Chery Sauce");
        }
        private void Extra_Button_Select(object sender, RoutedEventArgs e)
        {
            Button sipButton = (Button)e.Source;
            ItemSelect ıtemSelect = ItemSelects.Find(p => p.ID == Int32.Parse(sipButton.Uid));
            if (DefaultAll && sipButton.Uid == "0")
            {
                foreach (var btn in SelectContent.Children)
                {
                    ItemSelects.ForEach(x => x.Selected = 0);
                    (btn as PortionItemRow).LittleBtn.Background = blueSolidColor;
                    (btn as PortionItemRow).MediumBtn.Background = blueSolidColor;
                    (btn as PortionItemRow).ExtraBtn.Background = blueSolidColor;
                }
                (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = redSolidColor;
                (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = redSolidColor;
                (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = redSolidColor;
                addandUpdate(Int32.Parse(this.Uid));
                return;
            }
            else if (DefaultAll)
            {
                (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = blueSolidColor;
                (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = blueSolidColor;
                (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = blueSolidColor;
            }
            foreach (var btn in SelectContent.Children)
            {
                PortionItemRow selectBtn = btn as PortionItemRow;
                if (selectBtn.Uid == sipButton.Uid)
                {
                    if (ıtemSelect.Selected == 3)
                    {
                        selectBtn.MediumBtn.Background = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
                        ıtemSelect.Selected = 0;
                        sipButton.Background = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
                        if (ItemSelects.All(p => p.Selected == 0) && DefaultAll)
                        {
                            (SelectContent.Children[0] as PortionItemRow).LittleBtn.Background = redSolidColor;
                            (SelectContent.Children[0] as PortionItemRow).MediumBtn.Background = redSolidColor;
                            (SelectContent.Children[0] as PortionItemRow).ExtraBtn.Background = redSolidColor;
                        }
                        addandUpdate(Int32.Parse(this.Uid));
                        return;
                    }
                    else if (ıtemSelect.Selected == 1)
                        selectBtn.MediumBtn.Background = blueSolidColor;
                    else if (ıtemSelect.Selected == 2)
                        selectBtn.LittleBtn.Background = blueSolidColor;
                    break;
                }
            }
            ıtemSelect.Selected = 3;
            sipButton.Background = new SolidColorBrush(Colors.Red);
            addandUpdate(Int32.Parse(this.Uid));
            //OrderItem.AddAdditions("☆ Chilli Sauce, Extra Garlic Mayo, Extra BBQ Sauce, Extra Ketchup");
            //OrderItem.AddAdditions("Chery Sauce");
        }
        public void AddButton(String Uid, String Content)
        {
            PortionItemRow btn = new PortionItemRow()
            {
                _uid = Uid,
                _content = Content
            };
            SelectContent.Children.Add(btn);
        }
    }
}
