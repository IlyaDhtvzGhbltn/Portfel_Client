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
    /// Логика взаимодействия для Settings_Client.xaml
    /// </summary>
    public partial class Settings_Client : Window
    {
        public Settings_Client()
        {
            InitializeComponent();
            ExitClick.IsCancel = true;
        }

        private void buttonPassChange_Click(object sender, RoutedEventArgs e)
        {
                var table = Storage.datasetKlient.Tables["ClientInfo"];
                userDAL.SaveNewKlientPass(table.Rows[0][6].ToString(), newpas.Password);
                Settings1.Default.Password = newpas.Password;
                currpassmore.Password = null;
                newpas.Password = null;
            
        }

        private void currpass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Brush green = (Brush)bc.ConvertFrom("#FF57F000");
            Brush red = (Brush)bc.ConvertFrom("#ff0000");


                    if (newpas.Password.Length >= 10)
                    {
                        if (newpas.Password == currpassmore.Password)
                        {
                            PassStatus.Foreground = green;
                            PassStatus.Content = "New Password is Ok";
                            buttonPassChange.IsEnabled = true;

                        }
                        else
                        {
                            PassStatus.Foreground = red;
                            PassStatus.Content = "Passwords are Match";
                            buttonPassChange.IsEnabled = false;
                        }
                    }
                    else
                    {
                        PassStatus.Foreground = red;
                        PassStatus.Content = "New Password too simple";
                        buttonPassChange.IsEnabled = false;

                    }
                }
              
            
         

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
