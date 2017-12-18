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
    /// Логика взаимодействия для HardwareAccesWindow.xaml
    /// </summary>
    public partial class HardwareAccesWindow : Window
    {
        public HardwareAccesWindow()
        {
            InitializeComponent();
        }
        public HardwareAccesWindow(string ID)
        {
            InitializeComponent();
            ID_Hardware.Content = ID;
            txb_FName.Text = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][7].ToString();
            txb_LName.Text = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][8].ToString();
            txb_Mail.Text = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][17].ToString();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string messtoclient = "Your e-mail was linked to CGAAF Platform, if you didn’t send us Request - please let us know by e-mail";
            MailSendMessage MessToClient = new MailSendMessage(messtoclient, "Hardware Acces", txb_Mail.Text);
            try { MessToClient.SendMessageClientMail(); }
            catch (Exception ex)
            {
                BOX.ShowInformation(ex.Message);
            }
            string texttoadminsupport = "Client : " + txb_FName.Text + " " + txb_LName.Text + "needs approval of their equipment ID : " + ID_Hardware.Content;
            MailSendMessage MessToSupport = new MailSendMessage(texttoadminsupport, "Needs Approval of Hardware");
            try { MessToSupport.SendMessage(); }
            catch (Exception ex)
            {
                BOX.ShowInformation(ex.Message);
            }
            BOX.ShowInformation("Message was sent.");
            this.Close();
        }
    }
}
