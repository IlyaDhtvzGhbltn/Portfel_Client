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

            string daystr = days.ToString();
            string montstr = month.ToString();

            daystr = (daystr.Length < 2) ? "0" + daystr : daystr;
            montstr = (montstr.Length < 2) ? "0" + montstr : montstr;

            string SQLDate = year + "." + montstr + "." + daystr;
            return SQLDate;
        }
    }
}
