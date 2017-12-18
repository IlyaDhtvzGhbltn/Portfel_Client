using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.DALs.Interfaces
{
    interface IHardwareAcces
    {
        int HardwareStatus { get; }
        string HddID { get; }
        void InitializeAcces();
        void SetFalseHardvareStatus();
    }
}
