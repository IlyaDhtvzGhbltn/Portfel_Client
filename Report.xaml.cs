using System.Windows;
using System.Windows.Input;
using Custodian.InterfaceService;
using Custodian.DALs.InterfaceService;

namespace Custodian
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
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

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
