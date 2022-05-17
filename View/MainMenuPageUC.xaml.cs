using EposWpf.Model;
using EposWpf.View.ButtonUC;
using EposWpf.View.HelperUC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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
    /// MainMenuPageUC.xaml etkileşim mantığı
    /// </summary>
    public partial class MainMenuPageUC : UserControl
    {

        public Border mainBorder { get; set; }

        public MainMenuPageUC(Border mainBorder)
        {
            InitializeComponent();
            this.mainBorder = mainBorder;
            int i = 0;
            foreach(var _buttonItem in MenuButtonWrap.Children)
            {
                var buttonItem = _buttonItem as MainMenuButton;
                buttonItem.MenuButton.Uid = i.ToString();
                buttonItem.MenuButton.Click += Navigate_Button;
                i++;
            }
        }

        private void Navigate_Button(object sender, RoutedEventArgs e)
        {
            Button menuButton = (Button)e.Source;
            if (menuButton.Uid=="0")
            {
                var Page = new OrderPageUC(mainBorder);
                mainWindow.navigate(Page);
            }
            else if (menuButton.Uid == "1")
            {
                var Page = new EditorPageUC(mainBorder);
                mainWindow.navigate(Page);
            }
            else if (menuButton.Uid == "2")
            {

                Clipboard.SetText(JsonSerializer.Serialize(StaticData.categoryList[0].Products[0]));
                /*var Page = new EditorPageUC(mainBorder);
                mainWindow.navigate(Page);*/
            }
            //mainWindow.navigate(new PageLoad(mainBorder));
            /*
            var Page = new OrderPageUC(mainBorder);
            System.Threading.Thread.Sleep(5000);

            mainWindow.navigate(Page);*/
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
