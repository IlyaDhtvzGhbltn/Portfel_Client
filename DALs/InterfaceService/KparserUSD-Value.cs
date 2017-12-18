using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custodian.InterfaceService
{
    class KparserUSD_Value
    {
        public static decimal ConvertToUSD(decimal usd, decimal value)
        {
            decimal result;
            result = (usd/ value);
            return result;
        }
        public static decimal ArraySummDouble(List<decimal> currList)
        {
            decimal result=0;
            for (int i=0; i< currList.Count; i++)
            {
                result += currList[i];
            }
            return result;
        }
    }
}
