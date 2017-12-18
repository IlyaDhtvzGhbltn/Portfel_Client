using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows;

namespace Custodian
{
    class Parser
    {
        XmlTextReader ValueReader = new XmlTextReader("http://www.cbr.ru/scripts/XML_daily.asp");
        /// <summary>
        /// 0 - AUD, 1 - GBP,2 - USD, 3 - EUR, 4 - SGD
        /// </summary>
        public static List<decimal> Values = new List<decimal>();
        public void GetValuesFromSber()
        {
            try
            {
                while (ValueReader.Read())
                {
                    switch (ValueReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (ValueReader.Name == "Valute")
                            {
                                if (ValueReader.HasAttributes)
                                {
                                    while (ValueReader.MoveToNextAttribute())
                                    {
                                        if (ValueReader.Name == "ID")
                                        {
                                            if (ValueReader.Value == "R01235")
                                            {
                                                ValueReader.MoveToElement();
                                                var USD = ValueReader.ReadOuterXml();

                                                XmlDocument usdXmlDocument = new XmlDocument();
                                                usdXmlDocument.LoadXml(USD);

                                                XmlNode xmlNode = usdXmlDocument.SelectSingleNode("Valute/Value");
                                                decimal Value = Convert.ToDecimal(xmlNode.InnerText);
                                                Values.Add(Value);
                                            }

                                            if (ValueReader.Value == "R01035")
                                            {
                                                ValueReader.MoveToElement();
                                                var GBP = ValueReader.ReadOuterXml();

                                                XmlDocument usdXmlDocument = new XmlDocument();
                                                usdXmlDocument.LoadXml(GBP);

                                                XmlNode xmlNode = usdXmlDocument.SelectSingleNode("Valute/Value");
                                                decimal Value = Convert.ToDecimal(xmlNode.InnerText);
                                                Values.Add(Value);
                                            }

                                            if (ValueReader.Value == "R01239")
                                            {
                                                ValueReader.MoveToElement();
                                                var EUR = ValueReader.ReadOuterXml();

                                                XmlDocument usdXmlDocument = new XmlDocument();
                                                usdXmlDocument.LoadXml(EUR);

                                                XmlNode xmlNode = usdXmlDocument.SelectSingleNode("Valute/Value");
                                                decimal Value = Convert.ToDecimal(xmlNode.InnerText);
                                                Values.Add(Value);
                                            }

                                            if (ValueReader.Value == "R01625")
                                            {
                                                ValueReader.MoveToElement();
                                                var SGD = ValueReader.ReadOuterXml();

                                                XmlDocument usdXmlDocument = new XmlDocument();
                                                usdXmlDocument.LoadXml(SGD);

                                                XmlNode xmlNode = usdXmlDocument.SelectSingleNode("Valute/Value");
                                                decimal Value = Convert.ToDecimal(xmlNode.InnerText);
                                                Values.Add(Value);
                                            }

                                            if (ValueReader.Value == "R01010")
                                            {
                                                ValueReader.MoveToElement();
                                                var AUD = ValueReader.ReadOuterXml();

                                                XmlDocument usdXmlDocument = new XmlDocument();
                                                usdXmlDocument.LoadXml(AUD);

                                                XmlNode xmlNode = usdXmlDocument.SelectSingleNode("Valute/Value");
                                                decimal Value = Convert.ToDecimal(xmlNode.InnerText);
                                                Values.Add(Value);
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            catch (System.Net.WebException)
            {
                GetValuesFromSber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }
    }
}
