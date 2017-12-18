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

namespace Custodian.Dynamics_Controls
{
    /// <summary>
    /// Логика взаимодействия для MessageCloud.xaml
    /// </summary>
    public partial class MessageCloud : UserControl
    {
        private string Ftppath { get; set; }
        private string Filename { get; set; }
        //public Brush FonColor
        //{
        //    get => Back.Background;
        //    set => Back.Background = value;
        //}

        //public Brush TextColor
        //{
        //    get => MessOnly.Foreground;
        //    set => MessOnly.Foreground = value;
        //}
        //public Brush DataButtomColor
        //{
        //    get => ButtomTime.Foreground;
        //    set => ButtomTime.Foreground = value;
        //}

        //public Brush HeaderDateColor
        //{
        //    get => HeaderDate.Foreground;
        //    set => HeaderDate.Foreground = value;
        //}

        public MessageCloud()
        {
            InitializeComponent();
        }
        public MessageCloud(string textmess, DateTime datetimemess)
        {
            InitializeComponent();
            HeaderDate.Content = datetimemess.Day + "." + datetimemess.Month + "." + datetimemess.Year;
            MessOnly.Text = textmess;
            ButtomTime.Content = datetimemess.Hour + ":" + datetimemess.Minute;
            LoadBTN.Visibility = Visibility.Collapsed;
        }

        public MessageCloud(string textmess, DateTime datetimemess, string FTPPath)
        {
            InitializeComponent();
            Ftppath = FTPPath;
            Filename = textmess;
            MessOnly.Text = textmess;
            LoadBTN.Visibility = Visibility.Visible;
            ButtomTime.Content = datetimemess.Hour + ":" + datetimemess.Minute;
            HeaderDate.Content = datetimemess.Day + "." + datetimemess.Month + "." + datetimemess.Year;
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            InterfaceService.DownloadFromFTP downloader = new InterfaceService.DownloadFromFTP();
            downloader.DownloadFile(Ftppath, Filename);
        }
    }
}