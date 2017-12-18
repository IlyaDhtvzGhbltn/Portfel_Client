using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.DALs.InterfaceService
{
    class CounterMessages
    {
        public static int AllIntoMess { get; set; }
        public static int ReadedNowSess { get; set; }
        public static int ReadedLastSess = Settings1.Default.ReadMess;
    }
}
