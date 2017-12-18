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
using System.Windows.Shapes;

namespace Custodian
{
    /// <summary>
    /// Логика взаимодействия для RiskTT.xaml
    /// </summary>
    public partial class RiskTT : Window
    {
        public RiskTT()
        {
            InitializeComponent();
        }
        private void GoToRUVersion(object sender, RoutedEventArgs e)
        {
           // this.NavigationService.Navigate(new Uri("Pages/Admin/ClientOperations/TestRiscProfilRU.xaml", UriKind.Relative));
        }

        private List<string> SelectedRadioBtn = new List<string>();
        int[] balls = new int[7];
        int F = 10;
        int S = 10;
        int min = 10;
        private void TestContent_MouseDown(object sender, RoutedEventArgs e)
        {
            RadioButton RB = (RadioButton)sender;
            string name = RB.Name.Remove(1);
            int index = Convert.ToInt32(RB.Tag);
            if (name == "E") F = index;
            if (name == "F") S = index;

            if (F < S)
            {
                min = F;
            }
            else min = S;

            if (!SelectedRadioBtn.Contains(name))
            {
                SelectedRadioBtn.Add(name);
                balls[index] = Convert.ToInt32(RB.Tag);
            }
            else if (SelectedRadioBtn.Contains(name))
            {
                balls[index] = Convert.ToInt32(RB.Tag);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            if (BOX.ShowInformation(min) == true)
            {
                Settings1.Default.CurrentRiscProfil = min;
                userDAL.AddRiskTest(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString(), min);
                BOX.ShowInformation("Please, Restart the program to change took effect.");
            }
        }

        private void DragMove_Click(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MinimaseState_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void NormalState_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
