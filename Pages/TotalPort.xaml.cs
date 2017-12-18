using System;
using System.Collections.Generic;
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

namespace Custodian.Pages
{
    /// <summary>
    /// Логика взаимодействия для TotalPort.xaml
    /// </summary>
    public partial class TotalPort : UserControl
    {
        public TotalPort()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = MainWindow.reportVM;
            var tempFormat = Convert.ToDouble(Value.Content);

            if (Convert.ToDouble(Value.Content) >= 1000000)
            {
                Prefix.Content = "MM";
                Value.Content = (tempFormat/1000000).ToString("N1");
            }
            if (Convert.ToDouble(Value.Content) >= 1000)
            {
                Prefix.Content = "K";
                Value.Content = (tempFormat / 1000).ToString("N1");
            }
        }
    }
}
