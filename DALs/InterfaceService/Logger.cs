using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.DALs.InterfaceService
{
    class Logger
    {
        public static void WriteLog(string message, string source)
        {
            try
            {
                string formatable = string.Format("=", 10);
                string errortext = Environment.NewLine + source + Environment.NewLine + message + Environment.NewLine;
                string errordate = Environment.NewLine + DateTime.Now.ToString();
                File.AppendAllText("Log.txt", formatable + errortext + errordate + formatable);
            }
            catch(System.IO.IOException)
            {
                
            }
        }
    }
}
