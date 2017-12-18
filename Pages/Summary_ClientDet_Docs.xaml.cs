using Custodian.Model;
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
    /// Логика взаимодействия для Summary_ClientDet_Docs.xaml
    /// </summary>
    public partial class Summary_ClientDet_Docs : UserControl
    {
        public Summary_ClientDet_Docs()
        {
            InitializeComponent();
        }

        private void btn_Library_Click(object sender, RoutedEventArgs e)
        {
            Librar doc = new Librar();
            doc.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = MainWindow.reportVM;
        }
    }
}
