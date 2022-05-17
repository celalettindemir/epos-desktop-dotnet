using EposWpf.Model;
using EposWpf.Model.HelperModel;
using EposWpf.View;
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
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EposWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            navigate(new MainMenuPageUC(_EposIDBodyGrid));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged(string propertyName)
        {
            var handlers = PropertyChanged;

            handlers(this, new PropertyChangedEventArgs(propertyName));
        }
        public void navigate(UserControl control)
        {
            _EposIDBodyGrid.Child = null;
            _EposIDBodyGrid.Child = control;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
        }
    }
}
