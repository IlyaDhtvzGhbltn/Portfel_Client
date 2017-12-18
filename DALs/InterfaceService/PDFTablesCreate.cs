using Custodian.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Custodian.Model.ClientReportVM;
using static Custodian.Model.VisualModels;

namespace Custodian.DALs.InterfaceService
{
    /// <summary>
    /// Класс для создания обьектов DataTable для печати на PDF
    /// </summary>
    class PDFTablesCreate
    {

        public DataTable ReturnT { get; set; }
        public DataTable AllocationT { get; set; }
        public DataTable CellPolicy { get; set; }
        public DataTable Holdings { get; set; }
        public DataTable Transactions { get; set; }
        public ObservableCollection<Diagramm> ClassesDiagramm { get; set; }

        private string order = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
        private string[] ClassesDiagrammNames = { "Bonds", "Struct", "Share", "Derivatives", "Funds", "Alternative", "Cash" };


        DateTime Nowdate { get; set; }
        DateTime Threemonthagodate { get; set; }
        DateTime Sixmonthagodate { get; set; }
        DateTime Yearagodate { get; set; }
        DateTime TwoYearsAgodate { get; set; }
        DateTime Startdate { get; set; }
        

        double portfelstart { get; set; }
        double portfelyearago { get; set; }
        double portfel2ya { get; set; }

        decimal PortfellnowP { get; set; }

        public PDFTablesCreate(ObservableCollection<Diagramm> ClassesDiagramm, decimal portfel)
        {
            Nowdate = DateTime.Now;
            Threemonthagodate = Nowdate.AddDays(-90);
            Sixmonthagodate = Nowdate.AddDays(-180);
            Yearagodate = Nowdate.AddYears(-1);
            TwoYearsAgodate = Nowdate.AddYears(-2);
            Startdate = Convert.ToDateTime(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][19]);

            this.ClassesDiagramm = ClassesDiagramm;
            this.PortfellnowP = portfel;
            ReturnTable();
            AllocationTable();
            CellPolicyTable();
            HoldingsTable();
            TransactionTable();
        }


        public void ReturnTable()
        {
            List<DataColumn> ColumnsCollection = new List<DataColumn>
            {
                new DataColumn("Period", typeof(String)),
                new DataColumn("%", typeof(String)),
                new DataColumn("USD", typeof(String))
            };
            ReturnT = new DataTable();
            ReturnT.ColumnCollectionAdd(ColumnsCollection);

            portfelstart = userDAL.GetInvestmentDetails.StartInflo();
            double portfelthreemonthago;
            double portfelsixmonthago;

            int i = DateTime.Compare(Threemonthagodate, Startdate);
            if (i < 0)
                portfelthreemonthago = portfelstart;
            else
                portfelthreemonthago = userDAL.GetInvestmentDetails.PortfelActiveInTime(Threemonthagodate, order);



            int j = DateTime.Compare(Sixmonthagodate, Startdate);
            if (j < 0)
                portfelsixmonthago = portfelstart;
            else
                portfelsixmonthago =  userDAL.GetInvestmentDetails.PortfelActiveInTime(Sixmonthagodate, order);



            int y = DateTime.Compare(Yearagodate, Startdate);
            if (y < 0)
                portfelyearago = portfelstart;
            else 
                portfelyearago = userDAL.GetInvestmentDetails.PortfelActiveInTime(Yearagodate, order);


            int l = DateTime.Compare(TwoYearsAgodate, Startdate);
            if (l < 0)
                portfel2ya = portfelstart;
            else
                portfel2ya = userDAL.GetInvestmentDetails.PortfelActiveInTime(TwoYearsAgodate, order);


            double[] portfelCells = new double[] { portfelstart, portfelthreemonthago, portfelsixmonthago, portfelyearago, Convert.ToDouble(PortfellnowP)};


            Difference dif = new Difference(portfelCells);


            DataRow Threemonth = ReturnT.Rows.Add("3 months", dif.Relative3M.ToString("N2"), dif.Absolute3M);
            DataRow Sixmonth = ReturnT.Rows.Add("6 months", dif.Relative6M.ToString("N2"), dif.Absolute6M);
            DataRow Yearmonth = ReturnT.Rows.Add("1 year", dif.Relative1Y.ToString("N2"), dif.Absolute1Y);
            DataRow Alltimemonth = ReturnT.Rows.Add("All time", dif.RelativeAT.ToString("N2"), dif.AbsoluteAT);
        }

        private void AllocationTable()
        {

            List<DataColumn> ColumnsCollection = new List<DataColumn>
            {
                new DataColumn("Summary", typeof(String)),
                new DataColumn("%", typeof(String)),
                new DataColumn("USD", typeof(String))
            };
            AllocationT = new DataTable();
            AllocationT.ColumnCollectionAdd(ColumnsCollection);

            ClassesDiagramm.AddNullSubClasses(ClassesDiagrammNames);
            decimal SummPortfell = ClassesDiagramm.SummValue();
            foreach (var item in ClassesDiagramm)
            {
                AllocationT.Rows.Add(item.Name, Math.Round(item.Value/ SummPortfell * 100, 2), item.Value.ToString("N2"));
            }
        }
        private void CellPolicyTable()
        {
            List<DataColumn> ColumnsCollection = new List<DataColumn>()
            {
                new DataColumn("Title", typeof(String)),
                new DataColumn("This Year", typeof(String)),
                new DataColumn("Last Year", typeof(String)),
                new DataColumn("Total Cell", typeof(String)),
            };
            CellPolicy = new DataTable();
            CellPolicy.ColumnCollectionAdd(ColumnsCollection);

#region Total Column
            decimal totalInflow = ClientReportVM.InflowDetailsCollection.SummValue(Startdate, Nowdate);
            decimal totalOutflow = ClientReportVM.WithdrawDetailsCollection.SummValue(Startdate, Nowdate);
            decimal totalActualResult = Convert.ToDecimal( Convert.ToDouble(PortfellnowP) - portfelstart);
            decimal totalClosingBalance = totalActualResult + totalInflow - totalOutflow;
            #endregion

#region Last 1 year Column
            decimal YearInflow = ClientReportVM.InflowDetailsCollection.SummValue(Nowdate.AddYears(-1), Nowdate);
            decimal YearOutflow = ClientReportVM.WithdrawDetailsCollection.SummValue(Nowdate.AddYears(-1), Nowdate);
            decimal YearActualResult = Convert.ToDecimal(Convert.ToDouble(PortfellnowP) - portfelyearago);
            decimal YearClosingBalance = YearActualResult + YearInflow - YearOutflow;
#endregion

#region Last 2 years Column
            decimal TwoYearInflow = ClientReportVM.InflowDetailsCollection.SummValue(Nowdate.AddYears(-2), Nowdate);
            decimal TwoYearOutflow = ClientReportVM.WithdrawDetailsCollection.SummValue(Nowdate.AddYears(-2), Nowdate);
            decimal TwoYearActualResult = Convert.ToDecimal(Convert.ToDouble(PortfellnowP) - portfel2ya);
            decimal TwoYearClosingBalance = TwoYearActualResult + TwoYearInflow - TwoYearOutflow;
            #endregion

            DataRow inflof = CellPolicy.Rows.Add("Inflow", TwoYearInflow.ToString("N2"), YearInflow.ToString("N2"), totalInflow.ToString("N2"));
            DataRow outflow = CellPolicy.Rows.Add("Outflow", TwoYearOutflow.ToString("N2"), YearOutflow.ToString("N2"), totalOutflow.ToString("N2"));
            DataRow actualresult = CellPolicy.Rows.Add("Actual Result", TwoYearActualResult.ToString("N2"), YearActualResult.ToString("N2"), totalActualResult.ToString("N2"));
            DataRow closingbalance = CellPolicy.Rows.Add("Closing Balanse", TwoYearClosingBalance.ToString("N2"), YearClosingBalance.ToString("N2"), totalClosingBalance.ToString("N2"));
        }
        private void HoldingsTable()
        {
            try
            {
                Holdings = new DataTable();
                var holdings = ClientReportVM.InvestCollection;
                DataColumn[] ColumnsCollection = new DataColumn[10]
                {
                new DataColumn("Type", typeof(String)),
                new DataColumn("Currency", typeof(String)),
                new DataColumn("Date", typeof(String)),
                new DataColumn("Units", typeof(String)),
                new DataColumn("Aq. Prise", typeof(String)),
                new DataColumn("Isin", typeof(String)),
                new DataColumn("Marced Value", typeof(String)),
                new DataColumn("Marced Value USD", typeof(String)),
                new DataColumn("Profit", typeof(String)),
                new DataColumn("Weight", typeof(String))
                };
                Holdings.ColumnCollectionAdd(ColumnsCollection);
                var list = holdings.MassObjToList();
                foreach (var item in list)
                {
                    Holdings.Rows.Add(item.Type, item.Value, item.Date, item.Units,
                        item.AqPr, item.Isin, item.Markedvalue, item.MarkedvalueUSD, item.profit, item.Percent);
                }
            }
            catch (Exception ex) { BOX.ShowInformation(ex.Message); }
        }
        private void TransactionTable()
        {
            Transactions = new DataTable();
            DataColumn[] ColumnsCollection = new DataColumn[]
            {
                new DataColumn("Operation Type", typeof(String)),
                new DataColumn("Isin", typeof(String)),
                new DataColumn("Currency", typeof(String)),
                new DataColumn("Commission", typeof(String)),
                new DataColumn("Date", typeof(String))
            };
            Transactions.ColumnCollectionAdd(ColumnsCollection);
            var list = ClientReportVM.OperationsCollection;
            try
            {
                foreach (var item in list)
                {
                    Transactions.Rows.Add(item.Type, item.isin, item.value, item.money, item.date);
                }
            }
            catch (Exception ex) { }
        }
    }



    /// <summary>
    /// Методы расширения DataTable
    /// </summary>
    public static class TableExp
    {
        /// <summary>
        /// Инициализирует таблицу указанной коллекцией столбцов
        /// </summary>
        /// <param name="table">Таблица</param>
        /// <param name="columns">Коллекция столбцов</param>
        public static void ColumnCollectionAdd(this DataTable table, List<DataColumn> columns)
        {
            foreach (var item in columns)
            {
                table.Columns.Add(item);
            }
        }
        public static void ColumnCollectionAdd(this DataTable table, DataColumn[] columns)
        {
            foreach (var item in columns)
            {
                table.Columns.Add(item);
            }
        }

    }
    /// <summary>
    /// Методы расширения ObservableCollection<T>
    /// </summary>
    internal static class ObservableCollectionExp
    {
        public static decimal SummValue(this ObservableCollection<Diagramm> collect)
        {
            decimal portfell = 0;
            foreach (var item in collect)
            {
                portfell += item.Value;
            }
            return portfell;
        }
        public static decimal SummValue(this ObservableCollection<InflowTools> collect)
        {
            decimal portfell = 0;
            foreach (var item in collect)
            {
                portfell += Convert.ToDecimal(item.CashAccSumm);
            }
            return portfell;
        }
        public static decimal SummValue(this ObservableCollection<InflowTools> InflofCollect, DateTime FromDate, DateTime ToDate)
        {
            decimal summ = 0;

            foreach (var item in InflofCollect)
            {
                if (Convert.ToDateTime(item.date) < ToDate && Convert.ToDateTime(item.date) > FromDate)
                {
                    summ += Convert.ToDecimal(item.CashAccSumm);
                }
            }
            return summ;
        }
        public static decimal SummValue(this ObservableCollection<Withdraw> OutflowCollect, DateTime FromDate, DateTime ToDate)
        {
            decimal summ = 0;
            foreach (var item in OutflowCollect)
            {
                if (Convert.ToDateTime(item.Date) < ToDate && Convert.ToDateTime(item.Date) > FromDate)
                {
                    summ += item.Summ;
                }
            }
            return summ;
        }
        public static void AddNullSubClasses(this ObservableCollection<Diagramm> collect, string[] subclassesnames)
        {
            List<string> collectActives = new List<string>();
            foreach (var item in collect)
            {
                collectActives.Add(item.Name);
            }
            foreach (var item in subclassesnames)
            {
                if (!collectActives.Contains(item))
                {
                    collect.Add(new Diagramm() { Name = item, Value = 0 });
                }
            }
        }
        public static List<ToolsInvestmentDetails> MassObjToList(this ObservableCollection<ToolsInvestmentDetails> collect)
        {
                RiscDict dic = new RiscDict();
                List<ToolsInvestmentDetails> Details = new List<ToolsInvestmentDetails>();
                foreach (var item in collect)
                {
                    if (item.Units != null)
                    {
                        Details.Add(new ToolsInvestmentDetails()
                        {
                            Type = dic.IntegerDivide(item.SubClassType).Item2,
                            Value = item.Value,
                            Date = item.Date.ToString(),
                            Units = item.Units,
                            AqPr = item.AqPr,
                            Isin = item.Isin,
                            Markedvalue = item.Markedvalue,
                            MarkedvalueUSD = item.MarkedvalueUSD,
                            profit = item.profit,
                            Percent = item.Percent
                        });
                    }
                if (item.Isin == "Cash accounts")
                {
                    Details.Add(new ToolsInvestmentDetails()
                    {
                        Type = item.Type,
                        Value = item.Value,
                        Date = DateTime.Now.ToString().Remove(10),
                        Units = "",
                        AqPr = "",
                        Isin = item.Isin,
                        Markedvalue = "",
                        MarkedvalueUSD = item.MarkedvalueUSD,
                        profit = "",
                        Percent = item.Percent
                    });
                }
                }
                return Details;
        }
        public static List<OperationsAll> MassObjToList(this ObservableCollection<OperationsAll> collect)
        {
            List<OperationsAll> Trans = new List<OperationsAll>();
            foreach (var item in collect)
            {
                Trans.Add(new OperationsAll()
                {
                    date = item.date,
                    isin = item.isin,
                    money = item.money,
                    Type = item.Type,
                    value = item.value
                });
            }
            return Trans;
        }
    }

    class Difference
    {
        
        public string Absolute3M { get; set; }
        public string Absolute6M { get; set; }
        public string Absolute1Y { get; set; }
        public string AbsoluteAT { get; set; }


        public double Relative3M { get; set; }
        public double Relative6M { get; set; }
        public double Relative1Y { get; set; }
        public double RelativeAT { get; set; }


        public Difference(double[] mass)
        {
            AbsoluteDiff(mass);
            RelativeDiff(mass);
        }

        public void AbsoluteDiff(double[] mass)
        {
            AbsoluteAT = (mass[4] - mass[0]).ToString("N2");
            Absolute3M = (mass[4] - mass[1]).ToString("N2");
            Absolute6M = (mass[4] - mass[2]).ToString("N2");
            Absolute1Y = (mass[4] - mass[3]).ToString("N2");
         }

        public  void RelativeDiff(double[] mass)
        {
            Relative3M = Math.Round((mass[4] * 100 / mass[1]) - 100, 2);
            if (double.IsNaN(Relative3M))
                Relative3M = 0;
            Relative6M = Math.Round((mass[4] * 100 / mass[2]) - 100, 2);
            if (double.IsNaN(Relative6M))
                Relative6M = 0;
            Relative1Y = Math.Round((mass[4] * 100 / mass[3]) - 100, 2);
            if (double.IsNaN(Relative1Y))
                Relative1Y = 0;
            RelativeAT = Math.Round((mass[4] * 100 / mass[0]) - 100, 2);
            if (double.IsNaN(RelativeAT))
                RelativeAT = 0;
        }

    }

}
