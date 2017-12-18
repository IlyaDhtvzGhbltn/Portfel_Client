using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Custodian
{
    class Storage
    {

        internal static DataSet dataset = new DataSet("AllTables");
        internal static string sessionGuid { get; set; }
        internal static string EnteredUserID { get; set; }
        internal static bool admin_client;
    }
}
