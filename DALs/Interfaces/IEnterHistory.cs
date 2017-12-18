using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.DALs.Interfaces
{
    interface IEnterHistory
    {
        string MachineName { get; }
        string Orderclient { get; }
        void InsertSucsessEnterInfo();
        void InitializeHistoryEnter();
        void InsertExitInfo();
    }
}
