using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.InterfaceService
{
    class YahooFinans
    {

        public static string Tikker(string BloombTik)
        {
            string YahoTik = BloombTik.Remove(BloombTik.IndexOf(' '));
            return YahoTik;
        }
        public static string httpString(string Tikker)
        {
            return "https://finance.yahoo.com/quote/" + Tikker;
        }

    }
}
