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

namespace EposWpf.View.ButtonUC
{
    /// <summary>
    /// MainMenuButton.xaml etkileşim mantığı
    /// </summary>
    public partial class MainMenuButton : UserControl,INotifyPropertyChanged
    {
        public MainMenuButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private string _ImageSource { get; set; }
        public string ImageSource { 
            get
            {
                return _ImageSource;
            }
            set
            {
                _ImageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }
        private string _ButtonText { get; set; }
        public string ButtonText
        {
            get
            {
                return _ButtonText;
            }
            set
            {
                _ButtonText = value;
                RaisePropertyChanged("ButtonText");
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
