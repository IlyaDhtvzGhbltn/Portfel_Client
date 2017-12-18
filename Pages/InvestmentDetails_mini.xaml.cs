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
    /// Логика взаимодействия для InvestmentDetails_mini.xaml
    /// </summary>
    public partial class InvestmentDetails_mini : UserControl
    {
        
        public InvestmentDetails_mini()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = MainWindow.reportVM;
        }
    }
}
