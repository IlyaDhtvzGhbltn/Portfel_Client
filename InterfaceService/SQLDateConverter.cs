using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custodian.InterfaceService
{
    class SQLDateConverter
    {
        public static string DateConverer(DateTime _date)
        {
            int year = _date.Year;
            int month = _date.Month;
            int days = _date.Day;
            string SQLDate = year + "." + month + "." + days;
            return SQLDate;
        }
    }
}
