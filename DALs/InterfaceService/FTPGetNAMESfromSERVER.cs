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
        private string UserName = "cgaaf_ftp";
        private string Password = "X2h1E7q7";
        private string FTPServer = "ftp://cgaaf_ftp@castle-familyoffice.com";
        private string fileName;

        /// <summary>
        /// Возвращает список приватных документов по указанному номеру договора
        /// Возвращает список публичных документов если на вход подан null
        /// </summary>
        /// <param name="folder">Номер договора или null</param>
        /// <returns></returns>
        internal List<string> GetListFromFTP(string folder)
        {
            List<string> FTPFiles = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(folder);
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
                                ("Documents Folder is Empty ");
                            return FTPFiles;
                        }
                        while (!reader.EndOfStream)
                        {
                            fileName = reader.ReadLine();
                            if (fileName.Contains("|"))
                            {
                                fileName = fileName.Substring(fileName.IndexOf('|'));
                                FTPFiles.Add(fileName);
                            }
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
