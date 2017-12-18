using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using System.Drawing;
using Custodian.InterfaceService;
using Custodian.Dynamics_Controls;
using System.Net;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media;
using Custodian.DALs.InterfaceService;

namespace Custodian.Model
{
    class ClientChatModel : MainVM
    {
        private string Adviser => Storage.datasetKlient.Tables["ClientInfo"].Rows[0][18].ToString();
        public string LastFirstAdviserName { get; set; }
        private string ToPhotoPath { get; set; }
        private System.Windows.HorizontalAlignment Alignment { get; set; }
        public string AdviserPhoto { get; set; }
        private System.Windows.Media.Brush Fonbrush { get; set; }
        private System.Windows.Media.Brush TextBrush { get; set; }
        public DataTable Messangers { get; set; }



        private System.Windows.Media.Brush ToMeMess = new SolidColorBrush(System.Windows.Media.Color.FromRgb(54, 54, 54));
        private System.Windows.Media.Brush FromMeMess = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));

        private System.Windows.Media.Brush FromMeMessText = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0x72, 0x72, 0x72));
        private System.Windows.Media.Brush ToMeMessText = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0xcb, 0xcb, 0xcb));


        public string TextToSend
        {
            get
            {
                return _texttosend;
            }
            set
            {
                _texttosend = value;
                NotifyPropertyChanged("TextToSend");
            }
        }

        private string _texttosend { get; set; }

        public ObservableCollection<AdviserInfoTable> AdviserInfoCollection { get; set; }
        public class AdviserInfoTable
        {
            public string StaticsNames { get; set; }
            public string FromDBNames { get; set; }
        }
        private string Text { get; set; }
        private DateTime DataMess { get; set; }
        private string FromMess { get; set; }
        private string Order { get; set; }
        public ObservableCollection<MessageCloud> MessangersCollection { get; set; }
        public ObservableCollection<FilesNameControll> LoadFilesCollection { get; set; }

        public bool FileOkVisible { get; set; }
        System.IO.FileInfo info;
        string[] Fullpathtofile = new string[] { };
        string[] Filenames = new string[] { };
        List<string> Links { get; set; }
        List<string> GuidStr { get; set; }
        private string Ftp { get; set; }


        private string ClientID => Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
        private string ClientPerSonalAdviser => Storage.datasetKlient.Tables["ClientInfo"].Rows[0][18].ToString();


        /// <summary>
        /// Отправка сообщения 
        /// </summary>
        public RelayCommand InsertMessage
        {
            get
            {
                return new RelayCommand(SendMethod);
            }
        }
        private void SendMethod()
        {
            if (!string.IsNullOrWhiteSpace(_texttosend) || LoadFilesCollection.Count != 0)
            {
                if (LoadFilesCollection.Count == 0)
                {
                    SendTextOnly();
                }
                else
                {
                    SendTextOnly();

                    string CallFolderName = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString() + "_" +
                                            Storage.datasetKlient.Tables["ClientInfo"].Rows[0][18].ToString();
                    GuidStr = new List<string>();
                    string path = "ftp://cgaaf_ftp@castle-familyoffice.com/Files/";

                    if (!FTPLoadToServer.IsFolderCreated("cgaaf_ftp", "X2h1E7q7", path + CallFolderName))
                    {
                        FTPLoadToServer.FolderCreate(path, "X2h1E7q7", "cgaaf_ftp", CallFolderName);
                    }

                    for (int i=0; i< Fullpathtofile.Length; i++)
                    {
                       
                        GuidStr.Add(Guid.NewGuid().ToString());
                        FTPLoadToServer.FTPLoadFileOnly(path + CallFolderName + "/", "X2h1E7q7", "cgaaf_ftp", Fullpathtofile[i], GuidStr[i], false);
                        SendTextOnly(Filenames[i], path + CallFolderName + "/" + GuidStr[i]);
                    }
                    LoadFilesCollection.Clear();
                    GuidStr.Clear();
                }
            }
            TextToSend = string.Empty;
            FileOkVisible = false;
            NotifyPropertyChanged("FileOkVisible");
        }


        private void SendTextOnly()
        {
            if (!string.IsNullOrWhiteSpace(_texttosend))
            userDAL.SendMail(ClientID, ClientPerSonalAdviser, _texttosend);
        }
        private void SendTextOnly(string text, string path)
        {
            userDAL.SendMail(ClientID, ClientPerSonalAdviser, text, path);
        }

        /// <summary>
        /// Закрепить файл
        /// </summary>
        public ICommand SelectFile { get { return new RelayCommand(SelectedFile); } }
        private void SelectedFile()
        {

            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true
            };
            dialog.ShowDialog();
            Fullpathtofile = dialog.FileNames;
            Filenames = dialog.SafeFileNames;

            if (Fullpathtofile != null)
            {
                FileOkVisible = true;
                NotifyPropertyChanged("FileOkVisible");

                int sizeMB = 0;
                for (int i = 0; i < Fullpathtofile.Length; i++)
                {
                    info = new FileInfo(Fullpathtofile[i]);
                    sizeMB = (int)Math.Abs(info.Length / 1048576);

                    if (sizeMB < 50)
                    {
                        LoadFilesCollection.Add(new FilesNameControll(Filenames[i]) { DataContext = MainWindow.chat });
                    }
                    else
                    {
                        BOX.ShowInformation("Selected File is too Big for load (You File must be less or equal 50MB).");
                        FileOkVisible = false;
                        base.NotifyPropertyChanged("FileOkVisible");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Удалить все файлы
        /// </summary>
        public ICommand DeleteFiles { get { return new RelayCommand(AllDeletedFile); } }
        private void AllDeletedFile()
        {
            Fullpathtofile = null;
            FileOkVisible = false;
            LoadFilesCollection.Clear();
            base.NotifyPropertyChanged("FileOkVisible");
        }

        public ICommand DaleteSelected { get { return new RelayCommand<string>(DeletFile); } }
        private void DeletFile(string name)
        {
            LoadFilesCollection.Remove(LoadFilesCollection.FirstOrDefault((item)=>item.Cont==name));
        }



        public System.Windows.Forms.Timer ChatTimer { get; set; }
        //КОНСТРУКТОР КЛАССА
        public ClientChatModel()
        {
            try
            {
                Messangers = new DataTable();
                LoadFilesCollection = new ObservableCollection<FilesNameControll>();
                FileOkVisible = false;
                Order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
                ChatTimer = new System.Windows.Forms.Timer();
                ChatTimer.Tick += new EventHandler(ResetAsync);
                ChatTimer.Interval = 2000;
                ChatTimer.Start();
                DataTable adviserInfo = userDAL.AdviserInfo(ClientPerSonalAdviser);
                LastFirstAdviserName = adviserInfo.Rows[0][1].ToString() + " " + adviserInfo.Rows[0][2].ToString();
                DownloadFromFTP fotoload = new DownloadFromFTP();
                AdviserPhoto = fotoload.DownloadFile(adviserInfo.Rows[0][0].ToString());
                AdviserInfoCollection = new ObservableCollection<AdviserInfoTable>();
                MessangersCollection = new ObservableCollection<MessageCloud>();
                AdviserInfoCollection.Add(new AdviserInfoTable() { StaticsNames = "ID", FromDBNames = adviserInfo.Rows[0][0].ToString() });
                AdviserInfoCollection.Add(new AdviserInfoTable() { StaticsNames = "E-Mail", FromDBNames = adviserInfo.Rows[0][3].ToString() });
            }
            catch (Exception ex)

            {
                Logger.WriteLog(ex.Message + " ChatModel Error", ex.Source);
            }
        }

        private void ResetAsync(object sender, EventArgs e)
        {
            try
            {
                userDAL.ReturnChat(ClientID, Adviser);
                Messangers = userDAL.chatTable;

                MessangersCollection.Clear();
                for (int i = 0; i < Messangers.Rows.Count; i++)
                {
                    Ftp = Messangers.Rows[i][3].ToString();
                    Text = Messangers.Rows[i][0].ToString();
                    DataMess = Convert.ToDateTime(Messangers.Rows[i][1].ToString());
                    FromMess = Messangers.Rows[i][2].ToString();

                    if (FromMess == Order)
                    {
                        Alignment = System.Windows.HorizontalAlignment.Right;
                        Fonbrush = FromMeMess;
                        TextBrush = FromMeMessText;

                    }

                    else
                    {
                        Alignment = System.Windows.HorizontalAlignment.Left;
                        Fonbrush = ToMeMess;
                        TextBrush = ToMeMessText;
                    }
                    if (Ftp.Length <= 1)
                        MessangersCollection.Add(new MessageCloud(Text, DataMess)
                        {
                            HorizontalAlignment = Alignment,
                            //FonColor = Fonbrush,
                            //TextColor = TextBrush,
                            //DataButtomColor = TextBrush,
                            //HeaderDateColor = TextBrush
                        });
                    else
                    {
                        MessangersCollection.Add(new MessageCloud(Text, DataMess, Ftp)
                        {
                            HorizontalAlignment = Alignment,
                            //FonColor = Fonbrush,
                            //TextColor = TextBrush,
                            //DataButtomColor = TextBrush,
                            //HeaderDateColor = TextBrush
                        });
                    }
                }
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
        }

    }
}
