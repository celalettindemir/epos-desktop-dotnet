using EposWpf.Model;
using EposWpf.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// OrderPageUC.xaml etkileşim mantığı
    /// </summary>
    public partial class OrderPageUC : UserControl,INotifyPropertyChanged
    {
        List<NavBottomLine> list = new List<NavBottomLine>();

        List<Product> products;
        Order order;
        private String _SumPrice = "0.00";
        public String SumPrice
        {
            get
            {
                return _SumPrice;
            }
            set
            {
                _SumPrice = value;
                RaisePropertyChanged("SumPrice");
            }
        }
        public OrderPageUC(Border mainBorder)
        {
            InitializeComponent();
            this.DataContext = this;
            this.mainBorder = mainBorder;
            this.Loaded += TestUserControl_Loaded;
            /*this.Dispatcher.InvokeAsync(async () =>
            {
                PageLoad();
            });*/

        }
        // Wait for Control to Load
        void TestUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Get PresentationSource
            //PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            var margin = new Thickness(10, 10, 10, 10);


            this.Dispatcher.InvokeAsync((Action)(() => {
                
                for (int j = 0; j < 50; j++)
                productPanel.Children.Add(new ProductButton()
                {
                    Margin=margin
                });
                
                Double toplam = 0;
                int i = 0;
                foreach (var category in StaticData.categoryList)
                {

                    Button btn = new Button()
                    {
                        Content = category.Name,
                        Uid = category.ID.ToString(),
                        Height = 50,
                        Background = null,
                        BorderBrush = null,
                        Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x21, 0x96, 0xF3))
                    };
                    btn.Click += Button_Click;
                    var size = new Size(double.PositiveInfinity, double.PositiveInfinity);
                    btn.Measure(size);
                    btn.Arrange(new Rect(btn.DesiredSize));
                    category.ButtonWidth = btn.ActualWidth;
                    list.Add(new NavBottomLine() { ID = category.ID.ToString(), LeftMargin = toplam, Width = category.ButtonWidth });
                    toplam += category.ButtonWidth;
                    navPanel.Children.Add(btn);
                }
                if (list.Count > 0)
                {
                    GridCursor.Width = list[0].Width;
                    GridCursor.Margin = new Thickness(10 + list[0].LeftMargin, 0, 0, 0);
                }
                order = new Order();
                order.orderItem = new List<OrderItem>();
                products = StaticData.categoryList.First().Products;

                foreach (var item in productPanel.Children)
                {
                    if (item is ProductButton)
                    {
                        ProductButton btn = (item as ProductButton);
                        btn.productButton.Click += Button_Click_2;
                        btn.Visibility = Visibility.Hidden;
                        Product product = products.Find(p => p.PositionId == i);
                        if (product != null)
                        {
                            btn.productButton.Uid = product.ID.ToString();
                            btn.ProductName = product.Name;
                            btn.TopLeftTitle = product.Title;
                            btn.TopRightTitle = string.Format("{0:0.00}", product.Price);
                            byte a = 255; // or whatever...
                            byte r = (byte)(Convert.ToUInt32(product.Color.Substring(3, 2), 16));
                            byte g = (byte)(Convert.ToUInt32(product.Color.Substring(5, 2), 16));

                            byte b = (byte)(Convert.ToUInt32(product.Color.Substring(7, 2), 16));
                            btn.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
                            btn.Visibility = Visibility.Visible;
                        }
                    }
                    i++;
                }
                i = 0;
                foreach (var ItemSelect in StaticData.productItemSelects)
                {
                    switch (ItemSelect.Type)
                    {
                        case ItemType.Any:
                            AnyItemSelect anyItem = new AnyItemSelect();
                            anyItem.addandUpdate = addandUpdate;
                            anyItem.Uid = ItemSelect.ID.ToString();
                            anyItem.Title = ItemSelect.Title;
                            anyItem.Type = "(Any)";
                            anyItem.ItemSelects = ItemSelect.Values;
                            anyItem.ProductItemId = i;
                            ItemExtraSelectContent.Children.Add(anyItem);
                            break;
                        case ItemType.One:
                            OneItemSelect oneItem = new OneItemSelect();

                            oneItem.Uid = ItemSelect.ID.ToString();
                            oneItem.addandUpdate = addandUpdate;
                            oneItem.Title = ItemSelect.Title;
                            oneItem.Type = "(One)";
                            oneItem.ItemSelects = ItemSelect.Values;
                            oneItem.ProductItemId = i;
                            ItemExtraSelectContent.Children.Add(oneItem);
                            break;
                        case ItemType.Portion:
                            PortionItemSelect portionItem = new PortionItemSelect();
                            portionItem.addandUpdate = addandUpdate;
                            portionItem.Uid = ItemSelect.ID.ToString();
                            portionItem.Title = ItemSelect.Title;
                            portionItem.Type = "(Portion)";
                            portionItem.DefaultAll = ItemSelect.DefaultAll;
                            portionItem.ItemSelects = ItemSelect.Values;
                            portionItem.ProductItemId = i;
                            ItemExtraSelectContent.Children.Add(portionItem);
                            break;
                    }
                    i++;
                }
                MainContent.IsEnabled = true;
                LoadingIndicatorPanel.Visibility = Visibility.Collapsed;

            }));
            //this.Dispatcher.InvokeAsync((Action)(() => { MessageBox.Show("sadsaad"); }));
            //productPanel.Children.Add(new ProductButton());
            // Subscribe to PresentationSource's ContentRendered event
        }

        public void PageLoad()
        {

            for (int j = 0; j < 2000; j++)
                productPanel.Children.Add(new ProductButton());

            Double toplam = 0;
            int i = 0;
            //Category Create
            foreach (var category in StaticData.categoryList)
            {

                Button btn = new Button()
                {
                    Content = category.Name,
                    Uid = category.ID.ToString(),
                    Height = 50,
                    Background = null,
                    BorderBrush = null,
                    Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x21, 0x96, 0xF3))
                };
                btn.Click += Button_Click;
                var size = new Size(double.PositiveInfinity, double.PositiveInfinity);
                btn.Measure(size);
                btn.Arrange(new Rect(btn.DesiredSize));
                category.ButtonWidth = btn.ActualWidth;
                list.Add(new NavBottomLine() { ID = category.ID.ToString(), LeftMargin = toplam, Width = category.ButtonWidth });
                toplam += category.ButtonWidth;
                navPanel.Children.Add(btn);
            }
            if (list.Count > 0)
            {
                GridCursor.Width = list[0].Width;
                GridCursor.Margin = new Thickness(10 + list[0].LeftMargin, 0, 0, 0);
            }
            order = new Order();
            order.orderItem = new List<OrderItem>();
            products = StaticData.categoryList.First().Products;

            
            foreach (var item in productPanel.Children)
            {
                if (item is ProductButton)
                {
                    ProductButton btn = (item as ProductButton);
                    btn.productButton.Click += Button_Click_2;
                    btn.Visibility = Visibility.Hidden;
                    Product product = products.Find(p => p.PositionId == i);
                    if (product != null)
                    {
                        btn.productButton.Uid = product.ID.ToString();
                        btn.ProductName = product.Name;
                        btn.TopLeftTitle = product.Title;
                        btn.TopRightTitle = string.Format("{0:0.00}", product.Price);
                        byte a = 255; // or whatever...
                        byte r = (byte)(Convert.ToUInt32(product.Color.Substring(1, 2), 16));
                        byte g = (byte)(Convert.ToUInt32(product.Color.Substring(3, 2), 16));

                        byte b = (byte)(Convert.ToUInt32(product.Color.Substring(5, 2), 16));
                        btn.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
                        btn.Visibility = Visibility.Visible;
                        //products.Remove(product);
                    }
                }
                i++;
            }
            //Additions Sauce Salad Create
            //ItemExtraSelectContent.Children.Clear();
            i = 0;
            foreach (var ItemSelect in StaticData.productItemSelects)
            {
                switch (ItemSelect.Type)
                {
                    case ItemType.Any:
                        AnyItemSelect anyItem = new AnyItemSelect();
                        anyItem.addandUpdate = addandUpdate;
                        anyItem.Uid = ItemSelect.ID.ToString();
                        anyItem.Title = ItemSelect.Title;
                        anyItem.Type = "(Any)";
                        anyItem.ItemSelects = ItemSelect.Values;
                        anyItem.ProductItemId = i;

                        /*foreach (var btnSelect in ItemSelect.Values)
                            anyItem.AddButton(btnSelect.ID.ToString(),btnSelect.Name);*/
                        ItemExtraSelectContent.Children.Add(anyItem);
                        break;
                    case ItemType.One:
                        OneItemSelect oneItem = new OneItemSelect();

                        oneItem.Uid = ItemSelect.ID.ToString();
                        oneItem.addandUpdate = addandUpdate;
                        oneItem.Title = ItemSelect.Title;
                        oneItem.Type = "(One)";
                        oneItem.ItemSelects = ItemSelect.Values;
                        oneItem.ProductItemId = i;
                        /*foreach (var btnSelect in ItemSelect.Values)
                            oneItem.AddButton(btnSelect.ID.ToString(), btnSelect.Name);*/
                        ItemExtraSelectContent.Children.Add(oneItem);
                        break;
                    case ItemType.Portion:
                        PortionItemSelect portionItem = new PortionItemSelect();
                        portionItem.addandUpdate = addandUpdate;
                        portionItem.Uid = ItemSelect.ID.ToString();
                        portionItem.Title = ItemSelect.Title;
                        portionItem.Type = "(Portion)";
                        portionItem.DefaultAll = ItemSelect.DefaultAll;
                        portionItem.ItemSelects = ItemSelect.Values;
                        portionItem.ProductItemId = i;
                        /*foreach (var btnSelect in ItemSelect.Values)
                            portionItem.AddButton(btnSelect.ID.ToString(), btnSelect.Name);*/
                        ItemExtraSelectContent.Children.Add(portionItem);
                        break;
                }
                i++;
            }

            for (int j = 0; j < 2000;j++)
                productPanel.Children.Add(new ProductButton());
            MainContent.IsEnabled = true;
            LoadingIndicatorPanel.Visibility = Visibility.Collapsed;
        }
        String LastNavButtonId = "0";
        //Category Select
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button navMenuBtn = (Button)e.Source;

            if (LastNavButtonId == navMenuBtn.Uid)
                return;
            LastNavButtonId = navMenuBtn.Uid;
            //productPanel.Children.Clear();
            NavBottomLine navBottomLine = list.Find(p => p.ID == navMenuBtn.Uid);

            if (navBottomLine == null)
                return;
            GridCursor.Width = navBottomLine.Width;
            GridCursor.Margin = new Thickness(10 + navBottomLine.LeftMargin, 0, 0, 0);
            products = StaticData.categoryList.Find(p => p.ID.ToString() == navMenuBtn.Uid).Products;
            int i = 0;

            foreach (var item in productPanel.Children)
            {
                if (item is ProductButton)
                {
                    ProductButton btn = (item as ProductButton);
                    btn.Visibility = Visibility.Hidden;
                    if (products == null || products.Count == 0)
                        continue;
                    Product product = products.Find(p => p.PositionId == i);
                    if (product != null)
                    {
                        btn.productButton.Uid = product.ID.ToString();
                        btn.ProductName = product.Name;
                        btn.TopLeftTitle = product.Title;
                        btn.TopRightTitle = string.Format("{0:0.00}", product.Price); ;
                        byte a = 255; // or whatever...
                        byte r = (byte)(Convert.ToUInt32(product.Color.Substring(3, 2), 16));
                        byte g = (byte)(Convert.ToUInt32(product.Color.Substring(5, 2), 16));
                        byte b = (byte)(Convert.ToUInt32(product.Color.Substring(7, 2), 16));
                        btn.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
                        btn.Visibility = Visibility.Visible;
                        //products.Remove(product);
                    }
                }
                i++;
            }
        }


        //PositionId sirasi ile gelicek
        Button SelectButton = new Button();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button sipButton = (Button)e.Source;
            if (sipButton.Background == null)
            {
                SelectButton = sipButton;
                sipButton.Background = new SolidColorBrush(Colors.Yellow);
                ItemExtraSelect.Visibility = Visibility.Visible;
                return;
            }
            SelectButton = null;
            ItemExtraSelect.Visibility = Visibility.Hidden;
            sipButton.Background = null;
            //OrderItem.AddAdditions("☆ Chilli Sauce, Extra Garlic Mayo, Extra BBQ Sauce, Extra Ketchup");
            //OrderItem.AddAdditions("Chery Sauce");
        }
        //OrderItem selectOrder;
        //Order Add Product
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button productBtn = (Button)e.Source;
            if (products == null || products.Count == 0)
                return;
            Product product = products.Find(p => p.ID == Int32.Parse(productBtn.Uid));

            OrderItem orderItem = new OrderItem();
            orderItem.product = product;
            orderItem.ID = (order.orderItem.Count == 0 ? "0" : ((Int32.Parse(order.orderItem[order.orderItem.Count - 1].ID)) + 1).ToString());
            orderItem.TotalPrice += product.Price;

            OrderItemUC orderItemUC = new OrderItemUC();
            orderItemUC.Title = product.Title;


            orderItemUC.Uid = orderItem.ID;


            orderItemUC.ProductName = product.Name;
            orderItemUC.Price = product.Price;
            orderItemUC.PriceText = string.Format("{0:0.00}", product.Price);
            orderItemUC.productBtn.Uid = orderItem.ID;
            orderItemUC.productBtn.Click += Item_Select_Click;
            order.TotalPrice += orderItem.TotalPrice;

            order.orderItem.Add(orderItem);
            OrderListStack.Children.Add(orderItemUC);

            SumPrice = string.Format("{0:0.00}", order.TotalPrice);

        }


        private Button selectButton;
        public void addandUpdate(int index)
        {
            OrderItem orderItem = order.orderItem.Find(p => p.ID == selectButton.Uid);
            foreach (var orderItemUC in OrderListStack.Children)
            {
                if (orderItemUC is OrderItemUC)
                {
                    var _orderItemUC = (orderItemUC as OrderItemUC);
                    if (_orderItemUC.Uid == selectButton.Uid)
                    {
                        //orderItem.productItemSelect.Find(p => p.ID == index).Values= ıtemSelects;
                        _orderItemUC.ProductItemSelects = orderItem.productItemSelect;
                    }
                }
            }

            SumPrice = string.Format("{0:0.00}", order.TotalPrice);

        }
        private void Item_Select_Click(object sender, RoutedEventArgs e)
        {
            Button sipButton = (Button)e.Source;

            if (selectButton == null || selectButton != sipButton)
            {
                if (selectButton != null && selectButton != sipButton)
                {
                    selectButton.Background = null;
                }
                selectButton = sipButton;
                OrderItem orderItem = order.orderItem.Find(p => p.ID == sipButton.Uid);
                if (orderItem.productItemSelect == null)
                {
                    orderItem.productItemSelect = new List<ProductItemSelect>();
                    foreach (var ItemSelect in StaticData.productItemSelects)
                    {
                        var _ItemSelect = new ProductItemSelect()
                        {
                            ID = ItemSelect.ID,
                            Type = ItemSelect.Type,
                            Title = ItemSelect.Title,
                            Values = new List<ItemSelect>(),
                            DefaultAll = ItemSelect.DefaultAll
                        };
                        ItemSelect.Values.ForEach((item) =>
                        {
                            _ItemSelect.Values.Add(new ItemSelect()
                            {
                                ID = item.ID,
                                Name = item.Name,
                                Price = item.Price,
                                LPrice = item.LPrice,
                                EPrice = item.EPrice,
                                Selected = item.Selected
                            });
                        });
                        orderItem.productItemSelect.Add(_ItemSelect);
                    }
                }
                foreach (var ItemSelect in ItemExtraSelectContent.Children)
                {
                    if (ItemSelect is AnyItemSelect)
                    {
                        AnyItemSelect anyItemSelect = ItemSelect as AnyItemSelect;
                        anyItemSelect.ItemSelects = orderItem.productItemSelect.Find(p => p.ID == Int32.Parse(anyItemSelect.Uid)).Values;
                    }
                    else if (ItemSelect is OneItemSelect)
                    {
                        OneItemSelect oneItemSelect = ItemSelect as OneItemSelect;
                        oneItemSelect.ItemSelects = orderItem.productItemSelect.Find(p => p.ID == Int32.Parse(oneItemSelect.Uid)).Values;
                    }
                    else if (ItemSelect is PortionItemSelect)
                    {
                        PortionItemSelect portionItemSelect = ItemSelect as PortionItemSelect;
                        portionItemSelect.ItemSelects = orderItem.productItemSelect.Find(p => p.ID == Int32.Parse(portionItemSelect.Uid)).Values;
                    }
                }

                sipButton.Background = new SolidColorBrush(Colors.Yellow);

                ItemExtraSelect.Visibility = Visibility.Visible;
                return;
            }
            else if (selectButton == sipButton)
            {
                selectButton = null;
                sipButton.Background = null;
                ItemExtraSelect.Visibility = Visibility.Hidden;
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (selectButton == null)
                return;


            foreach (var StackItem in OrderListStack.Children)
            {
                if (StackItem is OrderItemUC)
                {
                    var _orderItemUC = (StackItem as OrderItemUC);
                    if (_orderItemUC.Uid == selectButton.Uid)
                    {
                        OrderListStack.Children.Remove(_orderItemUC);
                        OrderItem orderItem = order.orderItem.Find(p => p.ID == selectButton.Uid);
                        order.TotalPrice -= orderItem.TotalPrice;
                        order.orderItem.Remove(order.orderItem.Find(p => p.ID == selectButton.Uid));
                        SumPrice = string.Format("{0:0.00}", order.TotalPrice);
                        ItemExtraSelect.Visibility = Visibility.Hidden;
                        selectButton = null;
                        break;
                    }
                }
            }

        }
        private void RecallOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            selectButton = null;
            OrderListStack.Children.Clear();
            ItemExtraSelect.Visibility = Visibility.Hidden;

            order.TotalPrice = 0;
            SumPrice = string.Format("{0:0.00}", order.TotalPrice);
            foreach (var orderItem in order.orderItem)
            {
                if (orderItem.productItemSelect != null)
                    orderItem.productItemSelect.Clear();
            }
            order.orderItem.Clear();
        }
        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RefundOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        public Border mainBorder { get; set; }
        public MainWindow mainWindow
        {
            get
            {
                if (mainBorder != null)
                {
                    var obj = mainBorder.Parent;
                    if (obj != null && obj is MainWindow) return (MainWindow)obj;
                }
                return null;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mainWindow.navigate(new MainMenuPageUC(mainBorder));
        }
    }
}
