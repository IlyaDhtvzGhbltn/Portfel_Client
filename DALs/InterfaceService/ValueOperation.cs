using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.InterfaceService
{
    class ValueOperation
    {
        private static decimal K_USD(decimal value, decimal usd)
        {
            return value / usd;
        }

        public static decimal ValueToUSD(string value, decimal summ)
        {
            switch (value)
            {
                case "EUR":
                    return summ * K_USD(Parser.Values[3], Parser.Values[2]);
                case "GBP":
                    return summ * K_USD(Parser.Values[1], Parser.Values[2]);
                case "SGD":
                    return summ * K_USD(Parser.Values[4], Parser.Values[2]);
                case "AUD":
                    return summ * K_USD(Parser.Values[0], Parser.Values[2]);
            }
            return 0.00000000000M;

        }

    }
}
