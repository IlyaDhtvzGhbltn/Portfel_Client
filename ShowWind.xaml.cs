using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для ShowWind.xaml
    /// </summary>
    public partial class ShowWind : Window 
    {

        public ShowWind()
        {
            InitializeComponent();
        }

        public ShowWind(string Info)
        {
            InitializeComponent();
            No.Visibility = Visibility.Hidden;
            Ok.Visibility = Visibility.Hidden;
            informTXT.Text = Info;
        }

        public ShowWind(string Info, int rick)
        {
            InitializeComponent();
            buttonPassChange.Visibility = Visibility.Visible;
            No.Visibility = Visibility.Hidden;
            Ok.Visibility = Visibility.Hidden;
            informTXT.Text = Info;
            ricklev.Visibility = Visibility.Visible;
            ricklev.Content = rick.ToString();
        }

        public ShowWind(string Info, string header)
        {
            InitializeComponent();
            buttonPassChange.Visibility = Visibility.Hidden;
            No.Visibility = Visibility.Visible;
            Ok.Visibility = Visibility.Visible;
            informTXT.Text = Info;
        }

        private void buttonPassChange_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Hide();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Hide();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception) { }
        }
    }
}
