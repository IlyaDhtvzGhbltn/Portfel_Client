using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;
using System.Net;

namespace Custodian.InterfaceService
{
    internal class QuteParse
    {
        public static List<string> names = new List<string>();
        public static List<string> isin = new List<string>();
        public static List<decimal> quoe = new List<decimal>();
        private static string XMLFTPFILE = "ftp://cgaaf_ftp@castle-familyoffice.com/Quote.xml";
        private static string passftp = "X2h1E7q7";
        private static string userftp = "cgaaf_ftp";

        /// <summary>
        /// Поиск названия фирмы и текущей акции по ISIN компании
        /// </summary>
        /// <param name="getisin">ISIN</param>
        /// <returns></returns>
        internal static string[] TitleQuoteByISIN(string getisin)
        {
            try
            {
                int cells = 1;
                string[] counts = { "", "" };
                using (var reader = XmlReader.Create(XMLFTPFILE))
                {
                    while (reader.ReadToFollowing("Data"))
                    {
                        while (!isin.Contains(getisin))
                        {
                            if (reader.GetAttribute("Type", "urn:schemas-microsoft-com:office:spreadsheet") == "Number")
                            {
                                cells++;
                                if (cells % 2 != 0)
                                {
                                    isin.Add((reader.ReadElementContentAsString()));
                                }
                                if (cells % 2 == 0)
                                {
                                    quoe.Add((reader.ReadElementContentAsDecimal()));
                                }
                            }
                            else if (reader.GetAttribute("Type", "urn:schemas-microsoft-com:office:spreadsheet") == "String")
                            {
                                names.Add(reader.ReadElementContentAsString().ToString());
                            }
                            break;
                        }
                    }
                    if (isin.Contains(getisin))
                    {
                        int index = isin.IndexOf(getisin);
                        counts[0] = quoe[index].ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("ru-RU"));
                        counts[1] = names[index].ToString();
                        isin.Clear();
                        names.Clear();
                        quoe.Clear();
                        return counts;
                    }
                }
            }

            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
            string[] notFound = { "isin Not found", "isin Not found" };
            return notFound;

        }


        /// <summary>
        /// Получает ДЕЙСТВУЮЩУЮ цену на бумагу по отправленному ISIN и записывает в Storage.CurrentQuoteAll
        /// </summary>
        /// <param name="currentISIN"></param>
        internal static void StorageISINandQuoteSave(List<string> currentISIN)
        {                
            int i = 0;
            List<object> AllXMLMass = new List<object>();
            try
            {
                WebRequest request = WebRequest.Create(XMLFTPFILE);
                request.Credentials = new NetworkCredential(userftp, passftp);
                using (WebResponse responce = request.GetResponse())
                {
                    using (var reader = XmlReader.Create(responce.GetResponseStream()))
                    {
                        while (reader.ReadToFollowing("Data"))
                        {
                            if (reader.GetAttribute("Type", "urn:schemas-microsoft-com:office:spreadsheet") == "String" || reader.GetAttribute("Type", "urn:schemas-microsoft-com:office:spreadsheet") == "Number")
                            {
                                i++;
                                if (i > 4)
                                {

                                    AllXMLMass.Add(reader.ReadElementContentAsString());
                                }
                            }

                        }
                    }
                }
                AddQuoteintoStorageCurrentQuoteAll(AllXMLMass, currentISIN);
            }
            catch (ArgumentOutOfRangeException) { }
            catch (FormatException) { BOX.ShowInformation("Failed to get topical values from XML"); }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
        }
        private static List<string> allIsin = new List<string>();
        private static List<decimal> allCurrentQuote = new List<decimal>();
        private static void AddQuoteintoStorageCurrentQuoteAll(List<object> xaml, List<string> currisin)
        {
            for (int i=3; i< xaml.Count; i=i+5)
            {
                allIsin.Add(xaml[i].ToString());
            }
  
            for (int i = 2; i < xaml.Count; i = i + 5)
            {
                allCurrentQuote.Add(Convert.ToDecimal(xaml[i].ToString().Replace('.',',')));
            }

            for (int i=0; i< currisin.Count; i++)
            {
                if (allIsin.Contains(currisin[i].ToString()))
                {
                    Storage.CurrentQuoteAll.Add(allCurrentQuote[i].ToString());
                }
            }

        }
        public static decimal QuoteByIsin(string isin)
        {
            for (int i=0; i< allIsin.Count; i++)
            {
                if (allIsin[i] == isin)
                {
                    return allCurrentQuote[i];
                }
            }
            return 0;
        }



    }
    }


