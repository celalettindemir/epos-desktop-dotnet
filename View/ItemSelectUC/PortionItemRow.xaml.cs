using System;
using System.Collections.Generic;
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
    /// PortionItemRow.xaml etkileşim mantığı
    /// </summary>
    public partial class PortionItemRow : UserControl
    {
        public PortionItemRow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public String _content { get; set; }
        public String _uid { get; set; }

    }
}
