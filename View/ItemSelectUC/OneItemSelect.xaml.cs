using EposWpf.Model;
using System;
using System.Collections.Generic;
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
    /// OneItemSelect.xaml etkileşim mantığı
    /// </summary>
    public partial class OneItemSelect : UserControl
    {
        public OneItemSelect()
        {
            InitializeComponent();
            DataContext = this; 
            redSolidColor = new SolidColorBrush(Colors.Red);
            blueSolidColor = new SolidColorBrush(Color.FromArgb(255, 0x21, 0x96, 0xF3));
        }
        private SolidColorBrush redSolidColor { get; set; }
        private SolidColorBrush blueSolidColor { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public int ProductItemId { get; set; }


        public delegate void AddandUpdate(int index);
        public AddandUpdate addandUpdate { get; set; }

        public List<ItemSelect> _itemSelects;

        public List<ItemSelect> ItemSelects
        {
            get
            {
                return _itemSelects;
            }
            set
            {
                int i = 0;
                foreach (var Items in SelectContent.Children)
                {
                    if (SelectContent.Children[i] is Button)
                    {
                        Button btn = SelectContent.Children[i] as Button;
                        if (i < value.Count)
                        {
                            btn.Visibility = Visibility.Visible;
                            btn.Content = value[i].Name;
                            btn.Uid = value[i].ID.ToString();
                            if (value[i].Selected == 0)
                            {
                                btn.Background = blueSolidColor;
                            }
                            else if (value[i].Selected == 1)
                            {
                                btn.Background = redSolidColor;
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
                _itemSelects = value;
            }

        }

        public void AddButton(String Uid, String Content)
        {
            Button btn = new Button()
            {
                Uid = Uid,
                Content = Content,
                FontSize = 16,
                Height = 38,
                Margin = new Thickness(3, 3, 5, 5)
            };
            SelectContent.Children.Add(btn);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button sipButton = (Button)e.Source;
            ItemSelect ıtemSelect = ItemSelects.Find(p => p.ID == Int32.Parse(sipButton.Uid));
            if (ıtemSelect.Selected == 1)
            {
                ıtemSelect.Selected = 0;
                sipButton.Background = blueSolidColor;
                addandUpdate(Int32.Parse(this.Uid));
                return;
            }
            if(!ItemSelects.All(p=>p.Selected==0))
            {
                ItemSelect itemSelect = ItemSelects.Find(p => p.Selected == 1);
                foreach (var button in SelectContent.Children)
                {
                   if((button as Button).Uid == itemSelect.ID.ToString())
                    {
                        itemSelect.Selected = 0;
                        (button as Button).Background = blueSolidColor;
                    }
                }
            }
            ıtemSelect.Selected = 1;
            sipButton.Background = redSolidColor;
            addandUpdate(Int32.Parse(this.Uid));
        }
    }
}
