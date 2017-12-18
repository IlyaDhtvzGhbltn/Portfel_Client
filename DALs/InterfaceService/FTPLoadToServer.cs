using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Custodian.InterfaceService
{
    class FTPLoadToServer
    {
        /// <summary>
        /// Загружает документ на сервер через FTP 
        /// </summary>
        /// <param name="URLpath"></param>
        /// <param name="Pass"></param>
        /// <param name="username"></param>
        /// <param name="filePath"></param>
        /// <param name="fileOnFTPName"> Указывать папку с именем клиента для приватной загрузки. Например fileOnFTPName + '//order'. Расширение (.PDF) указывать во время вызова метода </param>
        /// <param name="delimiter"></param>
        internal static void FTPLoadFileOnly(string URLpath,string Pass,string username, string filePath, string fileOnFTPName, bool showmessage = true)
        {
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(username, Pass);
                client.BaseAddress = URLpath;
                client.UploadFile(fileOnFTPName, WebRequestMethods.Ftp.UploadFile, filePath);
                if (showmessage == true)
                BOX.ShowInformation("File was successful upload");
            }
        }
        /// <summary>
        /// Создает папку на сервере через FTP.
        /// </summary>
        /// <param name="URLpath"></param>
        /// <param name="Pass"></param>
        /// <param name="username"></param>
        /// <param name="folder_order">Название папки должно соответствовать номеру договора</param>
        internal static void FolderCreate(string URLpath, string Pass, string username, string folder_order)
        {
            try
            {
                string fullPath = URLpath + "/" + folder_order;
                FtpWebRequest zapros = (FtpWebRequest)WebRequest.Create(fullPath);
                zapros.Credentials = new NetworkCredential(username, Pass);
                zapros.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse resp = (FtpWebResponse)zapros.GetResponse();
                resp.Dispose();
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);

            }
        }

        /// <summary>
        /// Возвращает флаг указывающий - существует ли заданная папка на сервере
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Pass"></param>
        /// <param name="Urlpath"></param>
        /// <param name="FilelocalPath"></param>
        /// <returns></returns>
        internal static bool IsFolderCreated(string username, string Pass, string Urlpath, string textfile ="/|_CURRENT_")
        {

                try
                {
                    FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(Urlpath + textfile);
                    ftp.Credentials = new NetworkCredential(username, Pass);
                    ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                    FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                    resp.Dispose();
                    return true;
                }
                catch (Exception) { return false; }

        }
    }

   
}
