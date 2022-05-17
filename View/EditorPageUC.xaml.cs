using EposWpf.Model;
using EposWpf.Model.HelperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// EditorPageUC.xaml etkileşim mantığı
    /// </summary>
    public partial class EditorPageUC : UserControl
    {

        List<NavBottomLine> list = new List<NavBottomLine>();
        public Border mainBorder { get; set; }
        List<Product> products;
        public EditorPageUC( Border mainBorder)
        {
            InitializeComponent();
            this.mainBorder = mainBorder;
            this.Loaded += TestUserControl_Loaded;

        }
        void TestUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Get PresentationSource
            //PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);
            var margin = new Thickness(10, 10, 10, 10);


            this.Dispatcher.InvokeAsync((Action)(() =>
            {
                var editorMenu = new OrderItemUC() { ProductName = "Product",Name="product" };
                editorMenu.productBtn.Click += LeftMenuItem_Click;
                EditListStack.Children.Add(editorMenu);
                editorMenu = new OrderItemUC() { ProductName = "Stock", Name = "stock" };
                editorMenu.productBtn.Click += LeftMenuItem_Click;
                EditListStack.Children.Add(editorMenu);
                editorMenu = new OrderItemUC() { ProductName = "Table", Name = "table" };
                editorMenu.productBtn.Click += LeftMenuItem_Click;
                EditListStack.Children.Add(editorMenu);
                editorMenu = new OrderItemUC() { ProductName = "Person", Name = "person" };
                editorMenu.productBtn.Click += LeftMenuItem_Click;
                EditListStack.Children.Add(editorMenu);


                products = StaticData.categoryList.First().Products;
                for (int j = 0; j < 70; j++)
                    productPanel.Children.Add(new ProductButton()
                    {
                        Margin = margin
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
                    btn.Click += NavButton_Click;
                    var size = new Size(double.PositiveInfinity, double.PositiveInfinity);
                    btn.Measure(size);
                    btn.Arrange(new Rect(btn.DesiredSize));
                    category.ButtonWidth = btn.ActualWidth;
                    list.Add(new NavBottomLine() { ID = category.ID.ToString(), LeftMargin = toplam, Width = category.ButtonWidth });
                    toplam += category.ButtonWidth;
                    navPanel.Children.Add(btn);
                }
                Button btn1 = new Button()
                {
                    Content = "+",
                    Uid = "-1",
                    Height = 50,
                    Background = null,
                    BorderBrush = null,
                    Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x21, 0x96, 0xF3))
                };
                //btn1.Click += Button_Click;
                var size1 = new Size(double.PositiveInfinity, double.PositiveInfinity);
                btn1.Measure(size1);
                btn1.Arrange(new Rect(btn1.DesiredSize));
                //category.ButtonWidth = btn1.ActualWidth;
                //list.Add(new NavBottomLine() { ID = category.ID.ToString(), LeftMargin = toplam, Width = category.ButtonWidth });
                toplam += btn1.ActualWidth;
                navPanel.Children.Add(btn1);
                if (list.Count > 0)
                {
                    LastNavButtonId= list[0].ID;
                    GridCursor.Width = list[0].Width;
                    GridCursor.Margin = new Thickness(10 + list[0].LeftMargin, 0, 0, 0);
                }
                var greenColor = new SolidColorBrush(Colors.Green);
                i = 0;
                foreach (var item in productPanel.Children)
                {
                    if (item is ProductButton)
                    {
                        ProductButton btn = (item as ProductButton);

                        btn.productButton.Uid = i.ToString();
                        btn.Uid = i.ToString();

                        btn.productButton.Click += ProductOp_Click;
                        if (products == null || products.Count == 0)
                        {
                            btn.ProductName = "+";
                            btn.Background = greenColor;
                            btn.TopLeftTitle = " ";
                            btn.TopRightTitle = " ";
                            btn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Product product = products.Find(p => p.PositionId == i);
                            if (product != null)
                            {
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
                            else
                            {
                                //btn.productButton.Uid = product.ID.ToString();
                                btn.ProductName = "+";
                                btn.Background = greenColor;
                                btn.TopLeftTitle = " ";
                                btn.TopRightTitle = " ";
                                btn.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    i++;
                }

                MainContent.IsEnabled = true;
                LoadingIndicatorPanel.Visibility = Visibility.Collapsed;
            }));
        }
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
        String LastNavButtonId = "0";
        private void NavButton_Click(object sender, RoutedEventArgs e)
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

            var greenColor = new SolidColorBrush(Colors.Green);
            int i = 0;


            foreach (var item in productPanel.Children)
            {
                if (item is ProductButton)
                {
                    ProductButton btn = (item as ProductButton);
                    btn.Visibility = Visibility.Hidden;
                    btn.productButton.Uid = i.ToString();
                    btn.Uid = i.ToString();
                    if (products == null || products.Count == 0)
                    {
                        btn.ProductName = "+";
                        btn.Background = greenColor;
                        btn.TopLeftTitle = " ";
                        btn.TopRightTitle = " ";
                        btn.Visibility = Visibility.Visible;
                    }
                    else
                    {

                    Product product = products.Find(p => p.PositionId == i);
                    if (product != null)
                    {
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
                    else
                    {
                        //btn.productButton.Uid = product.ID.ToString();
                        btn.ProductName = "+";
                        btn.Background = greenColor;
                        btn.TopLeftTitle = " ";
                        btn.TopRightTitle = " ";
                        btn.Visibility = Visibility.Visible;
                    }

                    }
                }
                i++;
            }
        }
        private void ProductItem_Click(object sender, RoutedEventArgs e)
        {

        }
        public void SelectMenuList(String name)
        {
            foreach(var menu in EditListStack.Children)
            {
                if(menu is OrderItemUC)
                {
                    OrderItemUC orderItemUC = menu as OrderItemUC;
                    /*if(orderItemUC.Name==name)
                        orderItemUC.Background=*/
                }
            }

        }
        private void LeftMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Button menuItem = (Button)e.Source;
            //SelectMenuList((menuItem.Parent as OrderItemUC).Name);
        }
        private void ProductOp_Click(object sender, RoutedEventArgs e)
        {

            Button productButton = (Button)e.Source;
            
            if (productButton.Parent is ProductButton)
            {
                ProductOpW popup = new ProductOpW((productButton.Parent as ProductButton), Int32.Parse(LastNavButtonId), Int32.Parse(productButton.Uid));
                if(products!=null&&products.Count()!=0)
                    popup.product=products.Find(p => p.PositionId == Int32.Parse(productButton.Uid));
                popup.ShowDialog();
            }

        }
        private void Navigation_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.navigate(new MainMenuPageUC(mainBorder));
        }
    }
}
