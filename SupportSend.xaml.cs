using Custodian.DALs.InterfaceService;
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
    /// Логика взаимодействия для Send.xaml
    /// </summary>
    public partial class Send : Window
    {
        string text { get; set; }
        string subject { get; set; }
        string subjectCurl { get; set; }

        public Send()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                text = text_bx.Text;
                subjectCurl = subjct_cmb.SelectedItem.ToString();
                subject = subjectCurl.Remove(0, subjectCurl.IndexOf(':') + 1);
                MailSendMessage mail = new MailSendMessage(text, subject);
                mail.SendMessage();
                BOX.ShowInformation("Message was sended");
                text_bx.Text = string.Empty;
                subjct_cmb.SelectedIndex = -1;
            }
            catch (NullReferenceException)
            {
                BOX.ShowInformation("Subject are not Select");
            }
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

        private void DragMove_Click(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
