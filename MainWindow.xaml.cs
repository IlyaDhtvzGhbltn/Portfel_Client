using Custodian.Model;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Xml;

namespace Custodian
{

    public partial class MainWindow : Window
    {
        static string configText = string.Empty;
        static string user = "cgaaf_ftp";
        static string password = "X2h1E7q7";
        private static string pathToFolder;


        public static MainVM reportVM { get; set; }
        internal static ClientChatModel chat { get; set; }
        public static MainVM document { get; set; }
        public static MainVM test { get; set; }
        public static MainVM settings { get; set; }
        public static MainVM lubrar { get; set; }
        public static MainVM riskStart { get; set; }
        public static MainVM riskHistor { get; set; }
        public delegate void ErrorLog();

       public MainWindow()
        {
            InitializeComponent();
            clientLOG.TextChanged += new TextChangedEventHandler(errorAdminAuth);
            PassBox.PasswordChanged += new RoutedEventHandler(errorAdminAuth);
            clientLOG.TextChanged += new TextChangedEventHandler(errorClientAuth);
            PassBox.PasswordChanged += new RoutedEventHandler(errorClientAuth);
            this.Closing += new System.ComponentModel.CancelEventHandler(Exit);
        }


        #region ВХОД В КЛИЕНТА
        private async void enterClient_Click(object sender, RoutedEventArgs e)
        {
            enterClient.IsEnabled = false;
            rotIMG.Visibility = Visibility.Visible;
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                RepeatBehavior = RepeatBehavior.Forever
            };
            rotate.BeginAnimation(RotateTransform.AngleProperty, animation);


            await GetClientInfoinDAL(clientLOG.Text, Hash.GetHash(PassBox.Password));
            if (Storage.datasetKlient.Tables["ClientInfo"].Rows.Count > 0)
            {
 
                if (savePass.IsChecked == true)
                {
                    Settings1.Default.Login = clientLOG.Text;
                    Settings1.Default.Password = PassBox.Password;
                    Settings1.Default.Save();
                }
                StartQute();
                chat = new ClientChatModel();
                reportVM = new ClientReportVM(chat);

                ClientWindow newClientWindow = new ClientWindow();
              
                //DALs.InterfaceService.Page_Location_Visibly.SetWinVisible(newClientWindow);
                await ModelCreating();
                Hide();
                newClientWindow.DataContext = reportVM;
                newClientWindow.WindowState = WindowState.Maximized;
                newClientWindow.Show();
            }
            else
            {
                errorClient.Visibility = Visibility.Visible;
                enterClient.IsEnabled = true;
            }
        }
        private async Task GetClientInfoinDAL(string clientLOG, string hash)
        {
            await Task.Run(()=> {
                userDAL.GetClientInfo(clientLOG, hash);
                userDAL.GetInvestmentDetails.GetHistory(clientLOG);
            });
        }
   
        private async Task ModelCreating()
        {
            await Task.Run(()=>
            {
                document = new documentViewModel();
                test = new TestHistory();
                riskHistor = new TestHistory();
             });
        }

        #endregion
        #region СКРЫТЬ СООБЩЕНИЕ ОБ ОШИБКЕ 
        private void errorAdminAuth(object sender, RoutedEventArgs e)
        {
            errorClient.Visibility = Visibility.Hidden;
        }
        private void errorClientAuth(object sender, RoutedEventArgs e)
        {
            errorClient.Visibility = Visibility.Hidden;
        }
        #endregion
        private void StartQute()
        {
                string order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
                userDAL.GetIsinQouteCURRENTKlient(order);
                InterfaceService.QuteParse.StorageISINandQuoteSave(Storage.CURRENTisin);
            //userDAL.GetSaxoIB(order);
            //userDAL.GetInvestmentDetails.GetInflowDetails(order);
            //userDAL.GetInvestmentDetails.OutFlow(order);
        }

        private void Exit(object s, EventArgs e)
        {
           Environment.Exit(0);
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            clientLOG.Text = Settings1.Default.Login;
            PassBox.Password = Settings1.Default.Password;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {







            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);

            pathToFolder = Directory.GetCurrentDirectory();
            Uri ftp = new Uri("ftp://cgaaf_ftp@castle-familyoffice.com/Versions/Last_Version.txt");
            Version newUpdate = new Version(pathToFolder, ftp, password, user);
            var installedVersion = newUpdate.getCurrentVersion();
            if (installedVersion != 0)
            {
                newUpdate.SetRemoteVersion();

                if (newUpdate.ConnectFlag != false)
                {
                    var remoteVersion = newUpdate.getRemoteVersionsXML();
                    if (installedVersion < remoteVersion)
                    {

                        if (BOX.ShowQuestion("You have old version of application."
                            + Environment.NewLine +
                            "Would you like install the new version?", "Update") == true)
                        {
                            Process.Start(System.IO.Path.Combine(pathToFolder, "Updater.exe"));
                            Environment.Exit(0);
                        }
                    }
                }
            }
         }

        internal class Version
        {
            internal bool ConnectFlag = false;
            private double currentVersion;

            private string _pathToFolder { get; set; }
            private string _passwordFTP { get; set; }
            private string _userNameFTP { get; set; }
            private Uri _uriFTP { get; set; }
            private static XmlDocument RemoteXMLVersion { get; set; }
            private string _fileNameFTP { get; set; }

            public Version(string pathCurrentVersion, Uri ftpURI, string ftpPassword, string ftpUsername)
            {
                this._pathToFolder = pathCurrentVersion;
                this._uriFTP = ftpURI;
                this._userNameFTP = ftpUsername;
                this._passwordFTP = ftpPassword;
            }

            internal double getCurrentVersion()
            {
                try
                {
                    currentVersion = Convert.ToDouble((ConfigurationManager.AppSettings["currentVersion"]).Replace('.', ','));
                    return currentVersion;
                }

                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                return 0;
            }

            internal void SetRemoteVersion()
            {
                Console.WriteLine("Connecting to Server");
                var client = new WebClient();
                client.Credentials = new NetworkCredential(_userNameFTP, _passwordFTP);
                try
                {
                    var dataFTP = client.DownloadData(_uriFTP);
                    string fileString = System.Text.Encoding.UTF8.GetString(dataFTP);
                    RemoteXMLVersion = new XmlDocument();
                    RemoteXMLVersion.LoadXml(fileString);
                    ConnectFlag = true;
                }
                catch (Exception)
                {
                    BOX.ShowInformation("Internet Connect failed");
                    ConnectFlag = false;
                   // BOX.ShowInformation("Internet Connection Failed");
                }
            }

            internal double getRemoteVersionsXML()
            {
                if (ConnectFlag == true)
                {
                    var remote = RemoteXMLVersion.GetElementsByTagName("NewVersion")[0].InnerText;
                    string version = remote.Replace('.', ',');
                    return Convert.ToDouble(version);
                }
                else return 0;
            }
        }
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch (Exception) { }
        }
 
        private void help_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Send help = new Send();
            help.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
