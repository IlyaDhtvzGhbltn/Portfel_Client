using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Net;
using Microsoft.Windows.Controls;
using Custodian.InterfaceService;


namespace Custodian.Model
{
     class documentViewModel : MainVM
    {
        //Коллекции документов типов Application и Managment - контекст данных для DataGrid
       public ObservableCollection<Documents> usefulformsCollections { get; set; }
       public ObservableCollection<Documents> brochuresCollections { get; set; }
        public ObservableCollection<Documents> MyDocymentsCollections { get; set; }

        //  Скачать документ PDF по прямой ссылке
        //  Скачанный файл будет в той же папке что и *.exe
        // Публичное свойство CellInfo с помощью Binding{} XAML связано с CurrentCell в DataGrid
        // тип связи Mode = OneWayToSource

        public RelayCommand<Documents> DownloadPDF
        {
                get
                {
                    return new RelayCommand<Documents>(Download);
                }
        }
        private void Download(Documents doc)
        {
            try
            {
                string name = doc.Name;
                string ftp = string.Empty;
                DownloadFromFTP down = new DownloadFromFTP();

                if (doc.Profil == "Forms")
                    ftp = "ftp://cgaaf_ftp@castle-familyoffice.com/Documents/FormClient/";
                else if (doc.Profil == "Client")
                    ftp = "ftp://cgaaf_ftp@castle-familyoffice.com/Clients/" + Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString() + "/";
                else
                    ftp = "ftp://cgaaf_ftp@castle-familyoffice.com/Documents/BrochuresClient/";
                down.DownloadFile(ftp + name, name);

                userDAL.GetInvestmentDetails.WriteDocumentName(name.Replace("|",""), Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString());
            }
            catch (NullReferenceException) { } // ЕСЛИ НАЖАЛ НА ПУСТОЕ ПРОСТРАНСТВО НА ТАБЛИЦЕ
        }

        public RelayCommand<Documents> DownloadMydoc
        {
            get
            {
                return new RelayCommand<Documents>(Download);
            }
        }

        public class Documents
        {
            public string Name { get; set; }
            public string Profil { get; set; }
        }
        //КОНСТРУКТОР КЛАССА
        #region
        public documentViewModel()
        {
            usefulformsCollections = new ObservableCollection<Documents>();
            brochuresCollections = new ObservableCollection<Documents>();
            MyDocymentsCollections = new ObservableCollection<Documents>();

            FTPGetNAMESfromSERVER resp = new FTPGetNAMESfromSERVER();

            List<string> respPublickForms = resp.GetListFromFTP("ftp://cgaaf_ftp@castle-familyoffice.com//Documents//FormClient");
            List<string> respBrochures = resp.GetListFromFTP("ftp://cgaaf_ftp@castle-familyoffice.com//Documents//BrochuresClient");

            try
            {
                string order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
                List<string> myDocyments = resp.GetListFromFTP("ftp://cgaaf_ftp@castle-familyoffice.com" +"//Clients" + "//" + order);

                foreach (string st in myDocyments)
                {
                    MyDocymentsCollections.Add(new Documents()
                    {
                        Name = st, Profil = "Client"
                    });
                }

                for (int i = 0; i < respPublickForms.Count; i++)
                {
                    usefulformsCollections.Add(new Documents()
                    {
                        Name = respPublickForms[i], Profil = "Forms"
                    });
                }
                for (int i = 0; i < respBrochures.Count; i++)
                {
                    brochuresCollections.Add(new Documents()
                    {
                        Name = respBrochures[i], Profil = "Brochures"
                    });
                }

            }
            catch (NullReferenceException) { } // ЕСЛИ ЗАГРУЖАЕТСЯ СТРАИНЦА АДМИНА - ТУТ ВЫБИВАЕТ ИСКЛЮЧЕНИЕ

        }
        #endregion

    }
}
