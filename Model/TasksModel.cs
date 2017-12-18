using Custodian.DALs.InterfaceService;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Custodian.Model
{
    class TasksModel : MainVM
    {
        string PathToMain { get; set; }
        string PathToTermSheet { get; set; }

        /// <summary>
        /// Коллекция путей до нескольких документов подгружаемых за раз
        /// </summary>
        List<string> PathToInflowDocs { get; set; }
        List<string> PathToInflowDocsNames { get; set; }


        private string ftpUser = "cgaaf_ftp";
        private string ftppass = "X2h1E7q7";

        //Order
        public string mainSelect { get; set; }
        public string termSelect { get; set; }

        //Inflow
        public string infloDoc { get; set; }


        public int Bnumber { get { return _Bnumber; } set { _Bnumber = value; } }
        public int Snumber { get { return _Snumber; } set { _Snumber = value; } }
        public int Tnumber { get { return _Tnumber; } set { _Tnumber = value; } }
        public int Cnumber { get { return _Cnumber; } set { _Cnumber = value; } }
        public int Inumber { get { return _Inumber; } set { _Inumber = value; } }
        public int Onumber { get { return _Onumber; } set { _Onumber = value; } }

        private static int _Bnumber { get; set; }
        private static int _Snumber { get; set; }
        private static int _Tnumber { get; set; }
        private static int _Cnumber { get; set; }
        private static int _Inumber { get; set; }
        private static int _Onumber { get; set; }


        public string DocNumbers { get { return _DocNumbers; } set { _DocNumbers = value; } }
        private static string _DocNumbers { get; set; }


        public static int currentTasks { get; set; }
        private string order { get; set; }
        static DataTable table { get; set; }
        public static ObservableCollection<Tasks> tascKollections { get; set; }

        //Конструктор класса
        public TasksModel()
        {
            order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
            tascKollections = new ObservableCollection<Tasks>();
            collectionsReset();
            Formaterrorflag = false;
            PathToInflowDocs = new List<string>();
            PathToInflowDocsNames = new List<string>();
            mainSelect = "Not Selected";
            termSelect = "Not Selected";
            infloDoc = "Not Selected";
            Bnumber = 0;
            Snumber = 0;
            Tnumber = 0;
            Cnumber = 0;
            Inumber = 0;
            Onumber = 0;
    }

        /// <summary>
        /// Показывает актуальнвый список задач
        /// </summary>
        public static void collectionsReset()
        {
            table = userDAL.GetAllTasks(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString());
            tascKollections.Clear();
            currentTasks = table.Rows.Count;

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    tascKollections.Add(new Tasks()
                    {
                        numberT = table.Rows[i][0].ToString(),
                        dateIn = table.Rows[i][1].ToString(),
                        dateOUT = table.Rows[i][2].ToString(),
                        status = table.Rows[i][3].ToString(),
                        comment = table.Rows[i][4].ToString()
                    });
                }
            }
            else
            {
                tascKollections.Add(new Tasks()
                {
                    numberT = "No Tasks"
                });
            }
        }
        /// <summary>
        /// Проверка правильности формата в колличестве операций
        /// </summary>
        public bool Formaterrorflag { get; set; }

        /// <summary>
        /// Форматирование любого текстбокса
        /// </summary>
        public ICommand FormatCount { get { return new RelayCommand<string>(_format); } }
        private void _format(string text)
        {

            try
            {
                Convert.ToInt32(text);
                Formaterrorflag = false;
                NotifyPropertyChanged("Formaterrorflag");
            }
            catch (FormatException)
            {
                Formaterrorflag = true;
            }
            NotifyPropertyChanged("Formaterrorflag");
            NotifyPropertyChanged("IsOrderEnebled");
        }


        /// <summary>
        /// Выбор Главного документа
        /// </summary>
        public ICommand SelectMainDoc { get { return new RelayCommand(SetMainDoc);} }
        private void SetMainDoc()
        {
            OpenFileDialog dialogMainDoc = new OpenFileDialog();
            bool? result = dialogMainDoc.ShowDialog();
            PathToMain = dialogMainDoc.FileName;
            if (PathToMain != "")
                mainSelect = "OK";
            NotifyPropertyChanged("mainSelect");
        }
        /// <summary>
        /// Выбор терма
        /// </summary>
        public ICommand SelectTermDoc { get { return new RelayCommand(TermSheetDocument); } }
        private void TermSheetDocument()
        {
            OpenFileDialog dialogSheet = new OpenFileDialog();
            bool? result = dialogSheet.ShowDialog();
            PathToTermSheet = dialogSheet.FileName;
            if (PathToTermSheet != "")
            termSelect = "OK";
            NotifyPropertyChanged("termSelect");

        }


        /// <summary>
        /// Открытие и получение множества документов
        /// </summary>
        public ICommand MultiSelect { get { return new RelayCommand(_multiselect); } }
        private void _multiselect()
        {
            PathToInflowDocs.Clear();
            PathToInflowDocsNames.Clear();
            OpenFileDialog multidialog = new OpenFileDialog();
            multidialog.Multiselect = true;
            bool? result = multidialog.ShowDialog();

            string[] namesMassive = multidialog.SafeFileNames;
            string[] pathMassive = multidialog.FileNames;

            for (int i=0; i< pathMassive.Length; i++)
            {
                PathToInflowDocs.Add(pathMassive[i]);
                PathToInflowDocsNames.Add(namesMassive[i]);
            }
          
            if (pathMassive.Length > 0)
            {
                infloDoc = "OK";
                DocNumbers = "Selected Documents " + pathMassive.Length.ToString();
                NotifyPropertyChanged("infloDoc");
                NotifyPropertyChanged("DocNumbers");
            }
        }
      
            string FTPURL = "ftp://cgaaf_ftp@castle-familyoffice.com" + "//Clients//" + Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString() + "//";

        /// <summary>
        /// Отправка задания либо с 1 документом - Outflow либо с 2мя  - Order
        /// </summary>
        public ICommand SendOrder
        {
            get
            {
             return new RelayCommand(_send);
            }
        }
        private void _send()
        {

            if (Formaterrorflag != false)
                return;
            if (_Bnumber <= 0 && _Snumber<=0 && _Cnumber <=0 && _Tnumber <=0 && _Onumber<=0)
                return;

            Random rand = new Random();
            order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
            string adminID = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][18].ToString();

            try
            {
                if (string.IsNullOrWhiteSpace(PathToMain) != true && string.IsNullOrWhiteSpace(PathToTermSheet) == true)
                {
                    int index = userDAL.AddTask(order, adminID, _Bnumber, _Snumber, _Tnumber, _Cnumber, _Inumber, _Onumber); 

                    string taskNameMain = "|" + order + "_main_user_task_№_" + index.ToString() + PathToMain.Remove(0, PathToMain.IndexOf('.'));
                    InterfaceService.FTPLoadToServer.FTPLoadFileOnly(FTPURL + taskNameMain, ftppass, ftpUser, PathToMain, taskNameMain);
                   
                    userDAL.AddDocumentTask(index.ToString(), taskNameMain, FTPURL + taskNameMain);
                }

                else if (string.IsNullOrWhiteSpace(PathToMain) != true && string.IsNullOrWhiteSpace(PathToTermSheet) != true)
                {
                    int index = userDAL.AddTask(order, adminID, _Bnumber, _Snumber, _Tnumber, _Cnumber, _Inumber, _Onumber);

                    string taskNameMain = "|" + order + "_main_user_task_№_" + index.ToString() + PathToMain.Remove(0, PathToMain.IndexOf('.'));
                    InterfaceService.FTPLoadToServer.FTPLoadFileOnly(FTPURL + taskNameMain, ftppass, ftpUser, PathToMain, taskNameMain);

                    string taskNameStruct = "|" + order + "_struct_ user_task_№_" + index.ToString() + PathToTermSheet.Remove(0, PathToMain.IndexOf('.'));
                    InterfaceService.FTPLoadToServer.FTPLoadFileOnly(FTPURL + taskNameStruct, ftppass, ftpUser, PathToTermSheet, taskNameStruct);

                    userDAL.AddDocumentTask(index.ToString(), taskNameMain, taskNameStruct, FTPURL + taskNameMain, FTPURL + taskNameStruct);
                }
                else BOX.ShowInformation("Not Selecten document(s) file(s)");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            finally
            {
                DocNumbers = "Selected Documents 0";
                mainSelect = "Not select";
                termSelect = "Not select";
                PathToMain = "";
                PathToTermSheet = "";
                Model.TasksModel.collectionsReset();
                _Bnumber = 0;
                _Snumber = 0;
                _Tnumber = 0;
                _Cnumber = 0;
                _Inumber = 0;
                _Onumber = 0;
                NotifyPropertyChanged("mainSelect");
                NotifyPropertyChanged("termSelect");
                NotifyPropertyChanged("Bnumber");
                NotifyPropertyChanged("Snumber");
                NotifyPropertyChanged("Tnumber");
                NotifyPropertyChanged("Cnumber");
                NotifyPropertyChanged("Inumber");
                NotifyPropertyChanged("Onumber");
                NotifyPropertyChanged("DocNumbers");

            }
        }

        /// <summary>
        /// Отправка задания со множеством документов
        /// </summary>
        public ICommand MultiorderSend { get { return new RelayCommand(_Multisend); } }
        private void _Multisend()
        {
            if (Formaterrorflag != false)
            return;
            if (_Inumber <= 0)
            return;

            Random rand = new Random();
            order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
            string adminID = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][18].ToString();
            try
            {
                int index = userDAL.AddTask(order, adminID, 0, 0, 0, 0, _Inumber, _Onumber);
                for (int i= 0; i<PathToInflowDocs.Count; i++)
                {
                    string taskNameMain = "|" + order + "_" + "_inflow_user_task_№_" + index.ToString() + PathToInflowDocs[i].Remove(0, PathToInflowDocs[i].IndexOf('.'));
                    InterfaceService.FTPLoadToServer.FTPLoadFileOnly(FTPURL + taskNameMain, ftppass, ftpUser, PathToInflowDocs[i], taskNameMain);
                    userDAL.AddDocumentTask(index.ToString(), taskNameMain, FTPURL + taskNameMain);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            finally
            {
                mainSelect = "Not select";
                termSelect = "Not select";
                PathToMain = "";
                PathToTermSheet = "";
                Model.TasksModel.collectionsReset();
                _Bnumber = 0;
                _Snumber = 0;
                _Tnumber = 0;
                _Cnumber = 0;
                _Inumber = 0;
                _Onumber = 0;
                NotifyPropertyChanged("mainSelect");
                NotifyPropertyChanged("termSelect");
                NotifyPropertyChanged("Bnumber");
                NotifyPropertyChanged("Snumber");
                NotifyPropertyChanged("Tnumber");
                NotifyPropertyChanged("Cnumber");
                NotifyPropertyChanged("Inumber");
                NotifyPropertyChanged("Onumber");
                PathToInflowDocs.Clear();
            }
        }
        public class Tasks
        {
            public string numberT { get; set; }
            public string dateIn { get; set; }
            public string dateOUT { get; set; }
            public string status { get; set; }
            public string comment { get; set; }
        }

    }
}
