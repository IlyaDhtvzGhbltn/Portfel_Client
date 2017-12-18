using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custodian.Model
{
    class VisualModels
    {
        public static string[] EtfDates = {"1 Week", "1 Month", "3 Months", "1 Year", "3 Years", "5 Years" };
            
        public class AllocationTable
        {
            public string Type { get; set; }
            public string Wieght { get; set; }
            public string USD { get; set; }
        }
        public class Diagramm
        {
            public decimal Value { get; set; }
            public string Name { get; set; }
        }
        public class Chart
        {
            public double chartVal { get; set; }
            public string chartDate { get; set; }
        }
        public class OperationsAll
        {
            public string Type { get; set; }
            public string isin { get; set; }
            public string value { get; set; }
            public string money { get; set; }
            public string Aqprice { get; set; }
            public string Units { get; set; }
            public string date { get; set; }
        }
        public class RecomendedTable
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Advice { get; set; }
            public string Value { get; set; }
            public string Isin { get; set; }
            public string Weight { get; set; }
            public string RLevel { get; set; }
        }
     
    }
}
