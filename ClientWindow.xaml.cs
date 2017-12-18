using Custodian.DALs.Interfaces;
using Custodian.DALs.InterfaceService;
using Custodian.Model;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;

namespace Custodian
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        Chat CHAT { get; set; }
        public ClientWindow()
        {
            InitializeComponent();
           // IMGcastle = Directory.GetCurrentDirectory() + "\\Image\\castle.png";
        }
        #region События Перетаскивание Элемента
        //public string IMGcastle{get;set;}
        //private Point firstPoint = new Point();
        //private double[] firstMarginPoint = new double[2];

        //Grid CG = new Grid();

        //private void _mouseClick(object sender, MouseButtonEventArgs e)
        //{
        //    firstPoint = e.GetPosition(this);
        //    var _grid = (Grid)sender;
        //    _grid.CaptureMouse();
        //}
        //private void _mouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        Point temp = e.GetPosition(this);
        //        if (temp.X > 0 || temp.X < 1200 || temp.Y > 0 || temp.Y < 800)
        //        {
        //            Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

        //            Canvas.SetLeft(CG, Canvas.GetLeft(CG) - res.X);
        //            Canvas.SetTop(CG, Canvas.GetTop(CG) - res.Y);
        //            firstPoint = temp;

        //        }
        //       // BOX.ShowInformation(firstPoint.X + " " + firstPoint.Y);
        //    }
        //}

        //private void _mouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    var _grid = (Grid)sender;
        //    _grid.ReleaseMouseCapture();
        //    //CG = null;
        //}
        #endregion
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);

            string logini = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][7].ToString() + " ";
            logini += Storage.datasetKlient.Tables["ClientInfo"].Rows[0][8].ToString() + "\r\n";
            logini += Storage.datasetKlient.Tables["ClientInfo"].Rows[0][17].ToString() + "\r\n";
            logini += Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();

            IHardwareAcces Acces = new HardwareAcces(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString());
            Acces.InitializeAcces();
            if (Acces.HardwareStatus < 2)
            {
                if (Acces.HardwareStatus == 0)
                {
                    Acces.SetFalseHardvareStatus();
                    BOX.ShowInformation("Ваше устройство не распознано. Отправьте ваши данные для разблокировки или повторите попытку ввода позднее.");
                    HardwareAccesWindow AccesW = new HardwareAccesWindow(Acces.HddID);
                    AccesW.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    AccesW.ShowDialog();

                    Environment.Exit(0);
                }
                else if (Acces.HardwareStatus == 1)
                {
                    BOX.ShowInformation("Ваше устройство распознано и ожидает решения о разблокировке.");
                    Environment.Exit(0);
                }
            }

            if (Settings1.Default.DisclaimerAccept == false)
            {
                Disclaimer disclamer = new Disclaimer();
                disclamer.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                disclamer.ShowDialog();
            }

            if (Settings1.Default.FirstVisit == true)
            {
              
                ShowWind sw = new ShowWind();
                sw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                sw.ShowDialog();
                sw.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                Settings_Client SC = new Settings_Client();
                SC.DataContext = MainWindow.settings;
                SC.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                SC.ShowDialog();
                Settings1.Default.FirstVisit = false;
                Settings1.Default.Save();
            }

            IEnterHistory History = new HardwareAcces(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString());
            History.InitializeHistoryEnter();
            History.InsertSucsessEnterInfo();
        }

        private void NewWindowOpen_Report(object sender, RoutedEventArgs e)
        {

            Report rep = new Report();
            rep.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            rep.DataContext = MainWindow.reportVM;
            rep.Show();
        }


        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Settings_Client SC = new Settings_Client();
            SC.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SC.ShowDialog();
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void CloseT (object sender, RoutedEventArgs e)
        {
            if (BOX.ShowQuestion("Do you realy want to close Application ?", "Exit") == true)
            {
                this.WindowState = WindowState.Maximized;
                Settings1.Default.ReadMess += CounterMessages.ReadedNowSess;
                Settings1.Default.Save();
                Environment.Exit(0);
             
            }
        }
        private void Minimase (object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            Settins.Visibility = Visibility.Hidden;
        }
        private void Maximase (object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            Settins.Visibility = Visibility.Hidden;
        }

        private void CustomSize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            Settins.Visibility = Visibility.Hidden;
        }
        private void HeaderGridM_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Library_Click(object sender, RoutedEventArgs e)
        {
            Librar LL = new Librar();
            LL.DataContext = MainWindow.lubrar;
            LL.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LL.Show();
            
        }

        private void RiscStart_Click_1(object sender, RoutedEventArgs e)
        {
            RiskTT TT = new RiskTT();
            TT.DataContext = MainWindow.riskStart;
            TT.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TT.Show();
        }

        private void RiscHistory_Click(object sender, RoutedEventArgs e)
        {
            RiskHH hh = new RiskHH();
            hh.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hh.Show();
        }

#region Tasks Forms 
        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            TasksM TM = new TasksM();
            TasksModel tm = new TasksModel();
            TM.DataContext = tm;
            TM.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TM.Show();
        }

        private void Tasks_Click_Inflow(object sender, RoutedEventArgs e)
        {
            TasksIn TM = new TasksIn();
            TasksModel tm = new TasksModel();
            TM.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TM.DataContext = tm;
            TM.Show();
        }

        private void Tasks_Click_Outflow(object sender, RoutedEventArgs e)
        {
            TasksOut TM = new TasksOut();
            TasksModel tm = new TasksModel();
            TM.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TM.DataContext = tm;
            TM.Show();
        }
#endregion

        private void Image_MouseMove(object sender, MouseButtonEventArgs e)
        {
            if (Settins.Visibility == Visibility.Hidden)
                Settins.Visibility = Visibility.Visible;
            else
         if (Settins.Visibility == Visibility.Visible)
                Settins.Visibility = Visibility.Hidden;
        }

        private void MoreInfo_Click(object sender, RoutedEventArgs e)
        {
            More_Information info = new More_Information();
            info.DataContext = MainWindow.reportVM;
            info.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            info.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Send send = new Send();
            send.Show();
        }

        private void MenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
                RedCircle.Width += 5;
                RedCircle.Height += 5;
        }
        private void MenuItem_MouseLeave_1(object sender, System.Windows.Input.MouseEventArgs e)
        {

        RedCircle.Width -= 5;
        RedCircle.Height -= 5;
        }

        private void FinPlan_Click(object sender, RoutedEventArgs e)
        {
            Financial_Plan plan = new Financial_Plan();
            plan.Show();
        }
    }

}
