using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using static Custodian.Model.documentViewModel;
using System.Windows.Forms;
using System.Diagnostics;
using Custodian.Model;

namespace Custodian.InterfaceService
{
    class DownloadFromFTP
    {
        static string nameFTP = "cgaaf_ftp";
        static string pathFTP = "ftp://ftp.castle-familyoffice.com/PublickForms/";
        static string FTP = "ftp://ftp.castle-familyoffice.com/";
        static string passwordFTP = "X2h1E7q7";
        static  string downFolderName = @"Downloads\";


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
        /// <summary>
        /// Скачивает файл - фото по номеру адвайзера в папку
        /// </summary>
        /// <param name="adviser"></param>
        internal string DownloadFile(string adviser)
        {
            string path = string.Empty;
            GetInfoCorrectDownloadFolder();
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(nameFTP, passwordFTP);
                    string patch = FTP + "Photos/" + adviser + "/|Photo.jpg";
                    client.DownloadFile(patch, downFolderName + "Photo.jpg");
                }
                path = Directory.GetCurrentDirectory() +"/"+ downFolderName + "Photo.jpg";
            }
            catch (WebException) { BOX.ShowInformation("The server found an error (xxx). File not available. Please contact us for more information."); }
            catch (Exception ex) { BOX.ShowInformation(ex.Message); }

            return path;
        }

        /// <summary>
        /// Скачивает файл по строке, называет его и может открыть его в случае bool=true
        /// </summary>
        internal void DownloadFile(string ftpPath, string nameondisc, bool open = true)
        {
            
            GetInfoCorrectDownloadFolder();
            try
            {
                string downloadDoc = string.Empty;
                using (WebClient client = new WebClient())
                {//ftp://cgaaf_ftp@castle-familyoffice.com/Documents/BrochuresClient/%7CFactsheet%20ENG.pdf
                    downloadDoc = Directory.GetCurrentDirectory() + "\\" + downFolderName + nameondisc.Remove(0,1);
                    client.Credentials = new NetworkCredential(nameFTP, passwordFTP);
                    client.DownloadFile(ftpPath, downloadDoc);
                }
                if (open==true)
                Process.Start(Directory.GetCurrentDirectory() + "\\" + downFolderName + nameondisc.Remove(0,1));
            }
            catch (Exception ex)
            { BOX.ShowInformation(ex.Message); }



        }
    }
}
