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
        /// СТОИМОСТЬ ПОКУПКИ АКТИВА ИЛИ БУМАГИ - НЕОБХОДИМА ДЛЯ АЛЬТЕРНАТИВНЫХ ИНВЕСТ
        /// </summary>
        internal static List<decimal> BuyPrice = new List<decimal>();

        /// <summary>
        /// ВАЛЮТА ДАННОГО АКТИВА
        /// </summary>
        internal static List<string> valueActive = new List<string>();


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

 
        //internal static DataSet datasetAdmin = new DataSet("AllTablesAdmin");
        internal static DataSet datasetKlient = new DataSet("AllTablesClient");
        internal static DataSet datasetInvestment = new DataSet("Invest");
        internal static string AdminName { get; set; }
        internal static string sessionGuid { get; set; }
        internal static string EnteredUserID { get; set; }

        //public static decimal Quote_by_isin(string isin)
        //{


        //}
    }
}
