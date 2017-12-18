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

        internal static string GuidTask { get; set; }

        /// <summary>
        /// СПИСОК ISIN ИМЕЮЩИХСЯ У КЛИЕНТА БУМАГ
        /// </summary>
        internal static List<string> CURRENTisin = new List<string>();

        /// <summary>
        /// КОЛИЧЕСТВО ИМЕЮЩИХСЯ У КЛИЕНТА БУМАГ
        /// </summary>        
        internal static List<string> CURRENTCountforISIN = new List<string>();

        /// <summary>
        /// ТЕКУЩАЯ СТОИМОСТЬ КАЖДОЙ БУМАГИ
        /// </summary>
        /// 
        internal static List<string> CurrentQuoteAll = new List<string>();
        /// <summary>
        /// СУММА САХО и IB
        /// </summary>
        /// 
        internal static decimal AllPluss = new decimal();

        internal static decimal SAXO_IB = new decimal();
        internal static decimal Count_Mul_Price = new decimal();
        internal static decimal FundingSumm = new decimal();
        internal static void MarKetVall()
        {
            decimal result = new decimal();
            for (int i = 0; i < CURRENTCountforISIN.Count; i++)
            {
                decimal Count = Convert.ToDecimal(CURRENTCountforISIN[i]);
                decimal price = Convert.ToDecimal(CurrentQuoteAll[i]);
                result += Count * price;
            }
            Count_Mul_Price = result;
        }

        internal static DataSet datasetAdmin = new DataSet("AllTablesAdmin");
        internal static DataSet datasetKlient = new DataSet("AllTablesClient");
        internal static DataSet datasetInvestment = new DataSet("Invest");
        internal static DataSet datasetSaxoIB = new DataSet("SaxoIB");
        internal static string AdminName { get; set; }
        internal static string sessionGuid { get; set; }
        internal static string EnteredUserID { get; set; }
    }
}
