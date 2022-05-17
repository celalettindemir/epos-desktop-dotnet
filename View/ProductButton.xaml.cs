using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// ProductButton.xaml etkileşim mantığı
    /// </summary>
    public partial class ProductButton : UserControl, INotifyPropertyChanged
    {
        public ProductButton()
        {
            InitializeComponent();
            DataContext = this;
        }
        private string _TopLeftTitle;
        private string _TopRightTitle;
        private string _ProductName;
        public String TopLeftTitle { 
            get
            {
                return _TopLeftTitle;
            }
            set
            {
                _TopLeftTitle = value;
                RaisePropertyChanged("TopLeftTitle");
            }
        }
        public String TopRightTitle
        {
            get
            {
                return _TopRightTitle;
            }
            set
            {
                _TopRightTitle = value;
                RaisePropertyChanged("TopRightTitle");
            }
        }
        public String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                RaisePropertyChanged("ProductName");
            }
        }
        public Button productButton
        {
            get
            {
                return _productButton;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
