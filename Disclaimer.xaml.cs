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
    /// Логика взаимодействия для Disclaimer.xaml
    /// </summary>
    public partial class Disclaimer : Window
    {
        public Disclaimer()
        {
            InitializeComponent();
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

        private void DragMove_Click(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseDisclaimer_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AcceptDisclaimer_click(object sender, RoutedEventArgs e)
        {
            Settings1.Default.DisclaimerAccept = true;
            Settings1.Default.Save();
            this.Close();
        }
    }
}
