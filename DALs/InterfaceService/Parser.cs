using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Custodian
{
    class Parser
    {
        /// <summary>
        /// 0 - AUD, 1 - GBP,2 - USD, 3 - EUR, 4 - SGD
        /// </summary>
        public static List<decimal> Values = new List<decimal>();
        public void GetValuesFromSber()
        {
            try
            {
                string data = string.Empty;
                string url = "http://www.cbr.ru/currency_base/D_print.aspx?date_req=";
                string html = string.Empty;
                string[] pattern =
                    {
                "Австралийский доллар</td>\r\n<td>(.*)</td>",
                "Фунт стерлингов Соединенного королевства</td>\r\n<td>(.*)</td>",
                "Доллар США</td>\r\n<td>(.*)</td>",
                "Евро</td>\r\n<td>(.*)</td>",
                "Сингапурский доллар</td>\r\n<td>(.*)</td>"};

                DateTime today = DateTime.Now;
                data = today.Date.ToShortDateString();
                url += data;
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream());
                html = myStreamReader.ReadToEnd();
                Match match;

                for (int i = 0; i < pattern.Length; i++)
                {
                    match = Regex.Match(html, pattern[i]);
                    string result = match.Groups[1].ToString();
                    Values.Add(Convert.ToDecimal(result));
                }

            }
            catch (WebException)
            {
                Values.Add(1);
                Values.Add(1);
                Values.Add(1);
                Values.Add(1);
                Values.Add(1);
                BOX.ShowInformation("The CB server found an error (xxx). File not available. Please contact us for more information.");
                
            }
            catch (Exception ex)
            {
                Values.Add(1);
                Values.Add(1);
                Values.Add(1);
                Values.Add(1);
                Values.Add(1);

                BOX.ShowInformation(ex.Message);
            }
        }
    }
}
