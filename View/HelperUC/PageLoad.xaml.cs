using System;
using System.Collections.Generic;
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

namespace EposWpf.View.HelperUC
{
    /// <summary>
    /// PageLoad.xaml etkileşim mantığı
    /// </summary>
    public partial class PageLoad : UserControl
    {
        public Border mainBorder { get; set; }
        public PageLoad(Border mainBorder)
        {
            InitializeComponent();
            this.mainBorder = mainBorder;

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
    }
}
