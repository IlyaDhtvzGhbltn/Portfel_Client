using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Custodian.Pages.Admin.ClientOperations
{
    /// <summary>
    /// Логика взаимодействия для TestRiscProfil.xaml
    /// </summary>
    public partial class TestRiscProfil : Page
    {
        public TestRiscProfil()
        {
            InitializeComponent();
        }

        private List<string> SelectedRadioBtn = new List<string>();
        int[] balls = new int[7];


        private void TestContent_MouseDown(object sender, RoutedEventArgs e)
        {
            RadioButton RB = (RadioButton)sender;
            string name = RB.Name.Remove(1);
            int index = Convert.ToInt32(RB.Name.Remove(0,2));

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
            //decimal result = 0;
            //foreach (int i in balls)
            //{
            //    if (i != 0)
            //    {
            //        result += i;
            //    }
            //}
            //result = Math.Round(result / 7);
            //int SettingsResultRiskProfil = Convert.ToInt32(result);
            //BOX.ShowInformation($"You Risk Profil is P{result}");
            //Settings1.Default.CurrentRiscProfil = SettingsResultRiskProfil;

           // userDAL.AddRiskTest(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString(), SettingsResultRiskProfil, balls[0], balls[1], balls[2], balls[3], balls[4], balls[5], balls[6]);

        }

        private void GoToENGVersion(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/Admin/ClientOperations/TestRiscProfilENG.xaml", UriKind.Relative));
        }
    }
}
