using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using static Custodian.Model.documentViewModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace Custodian.InterfaceService
{
    class DownloadFromFTP
    {
        static string nameFTP = "platform@castle-familyoffice.sg";
        static string pathFTP = "ftp://ftp.castlefamily.co.uk/";
        static string passwordFTP = "o;I{#y0[S4a9";
        static string downFolderName = @"Downloads\\";
        /// <summary>
        /// Скачивает публичный выбранный файл с FTP сервера в папку для загрузок.
        /// </summary>
        /// <param name="doc">Параметр для MvvM</param>
        internal static void download(Documents doc)
        {
            try
            {
                GetInfoCorrectDownloadFolder();

                using (WebClient clientPDF = new WebClient())
                {
                    clientPDF.Credentials = new
                    NetworkCredential(nameFTP, passwordFTP);
                    string ftpPath = pathFTP + "|" + doc.Name;
                    clientPDF.DownloadFile(ftpPath, downFolderName + doc.Name + ".PDF");

                    string exePath = Directory.GetCurrentDirectory();
                    string openFolder = exePath + "Downloads";
                }
                Process.Start(@"Downloads");
            }
            catch (NullReferenceException)
            {
                // Срабатывает когда пользователь нажал не на ячейку с именем файла а пустое пространство
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
        }

        internal static void PrivateDownload(Documents doc)
            {
            try
            {
                string order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
                GetInfoCorrectDownloadFolder();

                using (WebClient clientPDF = new WebClient())
                {
                    clientPDF.Credentials = new
                    NetworkCredential(nameFTP, passwordFTP);
    string ftpPath = pathFTP  + "/"+order +"/" + "|" + doc.Name;
    clientPDF.DownloadFile(ftpPath, downFolderName + doc.Name + ".PDF");

                    string exePath = Directory.GetCurrentDirectory();
    string openFolder = exePath + "Downloads";
                }
Process.Start(@"Downloads");
            }
            catch (NullReferenceException)
            {
                // Срабатывает когда пользователь нажал не на ячейку с именем файла а пустое пространство
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
        }
        /// <summary>
        /// Проверяет существует ли папка Downloads для загружаемых документов,
        /// создает если нет.
        /// </summary>
        private static void GetInfoCorrectDownloadFolder()
        {
            try
            {
                string exePath = Directory.GetCurrentDirectory();
                DirectoryInfo folder = new DirectoryInfo(exePath + "Downloads");
                if (!folder.Exists)
                {
                    Directory.CreateDirectory(exePath + @"\Downloads");

                }

            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
        }
        internal static void downloadPrivate(string order, string filename)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(nameFTP, passwordFTP);
                    string path = pathFTP + "\\" + order + "\\" + "|" + filename;
                    client.DownloadFile(path, downFolderName + filename);
                    Process.Start(@"Downloads");
                }

            }
            catch (WebException) { }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.StackTrace);
            }
        }

    }
}
