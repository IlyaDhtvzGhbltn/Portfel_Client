using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;

namespace Custodian.InterfaceService
{
    internal class QuteParse
    {
        public static List<string> names = new List<string>();
        public static List<string> isin = new List<string>();
        public static List<decimal> quoe = new List<decimal>();
        private static decimal Qoute = new decimal();
        private static string ISIN = null;

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
                using (var reader = XmlReader.Create("http://castle-privatesolutions.sg/assets/quotes/book1.xml"))
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
            try
            {
                int cells = -1;
                using (var reader = XmlReader.Create("http://castle-privatesolutions.sg/assets/quotes/book1.xml"))
                {

                    while (reader.ReadToFollowing("Data"))
                    {
                        if (reader.GetAttribute("Type", "urn:schemas-microsoft-com:office:spreadsheet") == "Number")
                        {

                            cells++;
                            if (cells % 2 == 0)
                            {
                                Qoute = reader.ReadElementContentAsDecimal();
                            }
                            if (cells % 2 != 0)
                            {
                                ISIN = reader.ReadElementContentAsString();
                                if (currentISIN.Contains(ISIN))
                                {
                                    Storage.CurrentQuoteAll.Add(Qoute.ToString());
                                }

                            }
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
        }
        }
    }


