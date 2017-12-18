using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Custodian
{
    /// <summary>
    /// Логика взаимодействия для ActiveInfo.xaml
    /// </summary>
    public partial class ActiveInfo : Window
    {
        public ActiveInfo()
        {
            InitializeComponent();
        }
        public Uri URI
        {
            get
            {
                return browser.Source;
            }
            set
            {
                browser.Source = value;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dynamic activeX = browser.GetType().InvokeMember("ActiveXInstance",
                       BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                       null, browser, new object[] { });
            activeX.Silent = true;
        }
    }
}
