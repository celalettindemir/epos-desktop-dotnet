using EposWpf.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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
    /// ProductOpW.xaml etkileşim mantığı
    /// </summary>
    public partial class ProductOpW : Window
    {
        public ProductOpW()
        {
            InitializeComponent();
        }
        public ProductOpW(ProductButton productButton,int categoryId,int positionId)
        {
            InitializeComponent();
            this.productButton = productButton;
            this.categoryId = categoryId;
            this.positionId = positionId;
        }
        public ProductButton productButton { get; set; }
        public Product _product { get; set; }
        public Product product { 
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                if (_product != null)
                {
                    ProductName.Text = value.Name;
                    ProductTitle.Text = value.Title;
                    ProductPrice.Text = value.Price.ToString();
                    byte a = 255; // or whatever...
                    byte r = (byte)(Convert.ToUInt32(value.Color.Substring(3, 2), 16));
                    byte g = (byte)(Convert.ToUInt32(value.Color.Substring(5, 2), 16));
                    byte b = (byte)(Convert.ToUInt32(value.Color.Substring(7, 2), 16));
                    ClrPcker_Background.Color = Color.FromArgb(a, r, g, b);
                }
            }

        }
        public Int32 categoryId { get; set; }
        public Int32 positionId { get; set; }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                MessageBox.Show("asddas");
                //Do your stuff
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var category = StaticData.categoryList.Find(p => p.ID == categoryId);
            if (category.Products == null)
            {
                category.Products = new List<Product>();
            }
            category.Products.Add(new Product()
            {
                Name = ProductName.Text,
                Title = ProductTitle.Text,
                PositionId = positionId,
                Color = ClrPcker_Background.Color.ToString(),
                Price = Convert.ToDouble(ProductPrice.Text)
            });
            productButton.ProductName = ProductName.Text;
            productButton.TopLeftTitle = ProductTitle.Text;
            productButton.TopRightTitle = string.Format("{0:0.00}", Convert.ToDouble(ProductPrice.Text));
            productButton.Background = new SolidColorBrush(ClrPcker_Background.Color);
            
            this.Close();
        }

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListViewItem leftMenuItem = (ListViewItem)e.Source;
            if(leftMenuItem.Name== "CopyItem")
            {
                if(product!=null)
                {

                    product.Name = ProductName.Text;
                    product.Title = ProductTitle.Text;
                    product.Color = ClrPcker_Background.Color.ToString();
                    product.Price = Convert.ToDouble(ProductPrice.Text);
                    Clipboard.SetText(JsonSerializer.Serialize(product));
                }
            }
            else
            {
                try
                {
                    product = JsonSerializer.Deserialize<Product>(Clipboard.GetText());
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Copy operation failed, try again");
                    return;
                }
                product.PositionId = positionId;
                ProductName.Text = product.Name;
                ProductTitle.Text = product.Title;
                ProductPrice.Text = product.Price.ToString();
                byte a = 255; // or whatever...
                byte r = (byte)(Convert.ToUInt32(product.Color.Substring(3, 2), 16));
                byte g = (byte)(Convert.ToUInt32(product.Color.Substring(5, 2), 16));
                byte b = (byte)(Convert.ToUInt32(product.Color.Substring(7, 2), 16));
                ClrPcker_Background.Color = Color.FromArgb(a, r, g, b);
            }

        }
    }
}
