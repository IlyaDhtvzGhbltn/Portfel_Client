using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Custodian.InterfaceService
{
    class FTPGetNAMESfromSERVER
    {
        private string UserName = "platform@castle-familyoffice.sg";
        private string Password = "o;I{#y0[S4a9";
        private string FTPServer = "ftp://ftp.castlefamily.co.uk";
        private string fileName;

        /// <summary>
        /// Возвращает список приватных документов по указанному номеру договора
        /// Возвращает список публичных документов если на вход подан null
        /// </summary>
        /// <param name="folder">Номер договора или null</param>
        /// <returns></returns>
        internal List<string> GetListFromFTP(string folder)
        {
            folder =(folder==null) ? folder :  FTPServer += "//" +folder;
            List<string> FTPFiles = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPServer);
            request.Credentials = new NetworkCredential(UserName, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                try
                {
                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        if (reader.EndOfStream)
                        {
                            FTPFiles.Add
                                ("This guy don't have private folder. \r\nCreate immediately! ");
                            return FTPFiles;
                        }
                        while (!reader.EndOfStream)
                        {
                            fileName = reader.ReadLine();
                            if (fileName.Contains("|"))
                            {
                                fileName = fileName.Substring(fileName.IndexOf('|') + 1);
                                FTPFiles.Add(fileName);
                            }
                        }
                        if (FTPFiles.Count == 0)
                        {
                            FTPFiles.Add("Folder is Empty");
                        }
                        return FTPFiles;
                    }
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
                
            }

        }
    }
}
