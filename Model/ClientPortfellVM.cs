using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.Windows.Forms;
using System.Windows.Controls;
using System.ComponentModel;
using Custodian.InterfaceService;
using System.Threading;
using Custodian.Model;

namespace Custodian
{
     class ClientPortfellVM : MainVM
    {

        //В интерфейсе пользователя :
        // Units - число ценных бумаг расчитанных по формуле =( ЧислоКупленных - ЧислоПроданных )
        // MarcetValue - текущая стоимость всех инструментов портфеля

        // Данные из класса Storage для отбражения на странице
        DataTable table => Storage.datasetKlient.Tables["ClientInfo"];
        string order => table.Rows[0][6].ToString();




        //_cellInfo Текущая выделенная ячейка DGInvestmentDetails
        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get
            {
                return _cellInfo;
            }
            set
            {
                _cellInfo = value;
            }
        }
        /// <summary>
        /// Информация об выделенном активе
        /// </summary>
        private string _activeInfoString;
        public string activeInfoString
        {
            get
            {
                return _activeInfoString;
            }
            set
            {
                _activeInfoString = value;
                NotifyPropertyChanged("activeInfoString");
            }
        }
        // Получить ISIN из текущей CellInfo и затем
        // Заполнить детальных сведений об инструменте
        // Публичное свойство CellInfo с помощью Binding{} XAML связано с CurrentCell в DataGrid
        ToolsInvestmentDetails row = new ToolsInvestmentDetails();
        public ICommand SelectDetails
        {
            get
            { 
                return new RelayCommand(() =>
                {
                    try
                    {
                        row = (ToolsInvestmentDetails)_cellInfo.Item;
                        if (row.Isin != "")
                        {
                            ActifeInfo(row);
                            DataTable table = userDAL.GetInvestmentDetails.GetByu_Sale_ActivesTotal(Order, row.Isin);
                            TotalInvestCollection.Clear();
                            if (table.Rows.Count > 0)
                            {
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    TotalInvestCollection.Add(new TotalInvest()
                                    {
                                        Operation = table.Rows[i][0].ToString(),
                                        Title = row.Type.ToString(),
                                        Isin = table.Rows[i][2].ToString(),
                                        value = table.Rows[i][3].ToString(),
                                        Units = table.Rows[i][4].ToString(),
                                        AqP = table.Rows[i][5].ToString(),
                                        Date = table.Rows[i][6].ToString() 
                                    });
                                }
                            }
                        }
                        if (row.Isin == null)
                        {
                            DataTable table = userDAL.GetInvestmentDetails.GetSaxo_IB_ActivesTotal(Order, row.Type);
                            TotalInvestCollection.Clear();
                            if (table.Rows.Count > 0)
                            {
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    TotalInvestCollection.Add(new TotalInvest()
                                    {
                                        Operation = table.Rows[i][0].ToString(),
                                        Title = table.Rows[i][1].ToString(),
                                        value = table.Rows[i][4].ToString(),
                                        Units = table.Rows[i][2].ToString(),
                                        Date = table.Rows[i][3].ToString()
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                    }
                });
            } 
        }


        public ICommand GetInfoInNew
        {
            get
            {
                return new RelayCommand(()=> 
                {
                    try
                    {
                        if (row.Type != null)
                        {
                            ActiveInfo active = new ActiveInfo();
                            active.URI = new Uri(YahooFinans.httpString(YahooFinans.Tikker(row.Type)));
                            active.Show();
                        }
                        else BOX.ShowInformation("Select Active");

                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                    }
                });
            }
        }

        private async void ActifeInfo(ToolsInvestmentDetails CurrRow)
        {
            string isin = CurrRow.Isin;
            await actInf(isin);
        }
        Task actInf(string _isin)
        {
            return Task.Run(()=> 
            {
                activeInfoString = _isin;
            });
        }

        public ObservableCollection<ToolsInvestmentDetailsTotal> Collection { get; set; }
        public ObservableCollection<ToolsInvestmentDetails> InvestCollection { get; set; }
        public static ObservableCollection<TotalInvest> TotalInvestCollection { get; set; }
        public ObservableCollection<InflowTools> InflowDetailsCollection { get; set; }
        public ObservableCollection<Withdraw> WithdrawDetailsCollection { get; set; }
        public decimal LTV { get; set; }

        public class TestQuestions
        {
            public string title { get; set; }
            public string result { get; set; }
        }
        public class TotalInvest
        {
            public string Operation { get; set; }
            public string Title { get; set; }
            public string Isin { get; set; }
            public string value { get; set; }

            public string Units { get; set; }
            public string AqP { get; set; }
            public string Date { get; set; }
        }
        public class ToolsInvestmentDetails
        {
            public string Type { get; set; }
            public string Date { get; set; }
            public string Percent { get; set; }
            public string Units { get; set; }
            public string unrealizedrezult { get; set; }
            public string AqPr { get; set; }
            public string Isin { get; set; }
            public string currentDate { get; set; }
            public string Quote { get; set; }
            public string AqMoney { get; set; }
            public string MarkedvalueUSD { get; set; }
            public string Markedvalue { get; set; }
            public string Value { get; set; }
            public string profit { get; set; }

        }
        public class ToolsInvestmentDetailsTotal
        {
            public string Type { get; set; }
            public string Balance { get; set; }
        }
        public class InflowTools
        {
            public string CashAccount { get; set; }
            public decimal CashAccSumm { get; set; }
            public string Isin { get; set; }
            public string security { get; set; }
            public string aqprice { get; set; }
            public decimal countPaper { get; set; }
            public DateTime date { get; set; }

        }
        public class Withdraw
        {
            public string Summ { get; set; }
            public string Date { get; set; }
        }

        // Заполнение Fond Summary
        #region статичные поля из таблицы пользователя
 
        public decimal Cash => Convert.ToDecimal(table.Rows[0][1]) + Convert.ToDecimal(table.Rows[0][2])+ Convert.ToDecimal(table.Rows[0][3])+ Convert.ToDecimal(table.Rows[0][4]) + Convert.ToDecimal(table.Rows[0][5]);
        //CashAccount USD-EUR-GBP ...


        public long number => Convert.ToInt64(table.Rows[0][13]);          //Mobile number -long-
        public string mobile => number.ToString("# (###) ###-##-##");       //Mobile number -string-
        public string KProfession => table.Rows[0][14].ToString();          //Profession
        public string KFName => table.Rows[0][7].ToString();                //First Name
        public string KLName => table.Rows[0][8].ToString();                 //Last Name
        public string FIO => KFName + " " + KLName;                           //First Name + Last Name
        public string Mail => table.Rows[0][17].ToString();                 //Mail
        public string Adviser => table.Rows[0][18].ToString();              //Personal Adviser
        public string DateReg => table.Rows[0][19].ToString();              //Date of Registration
        public string DateofBirth => table.Rows[0][11].ToString();           //Date of Birth
        public string Order => table.Rows[0][6].ToString();                 //Order Number
        public string Value => table.Rows[0][5].ToString();                 //Value - USD-GBP-...
        public string Status => table.Rows[0][24].ToString();               //Status
        public string Company => table.Rows[0][23].ToString();              //Company Name
        public decimal CashAllocStart => Convert.ToDecimal(table.Rows[0][22]);            //Cash Allocation

        public string YearsOfRegist => (table.Rows[0][19]).ToString();       //Date of Registration
        private string s => YearsOfRegist.Remove(11);
        private string ss => s.Remove(0,6);
        public decimal CashAllocationPluss => Storage.AllPluss;                      //Cash Allocation Pluss

        public string MINCash => (3 * ((CashAllocStart) / 100)).ToString("N2");    //MinCash Allocation

        public string Marcet => (Storage.Count_Mul_Price + Storage.SAXO_IB).ToString("N2"); //Marcet Value
        public string Found => (Storage.Count_Mul_Price + Storage.SAXO_IB + Convert.ToDecimal(table.Rows[0][1])).ToString("N2");
        private decimal nowYear = DateTime.Now.Year;

        public decimal ostYears => Convert.ToDecimal(ss) - nowYear;
        private decimal years => 10 + ostYears;
        public string  Encasment => (Convert.ToDecimal(MINCash)
                              + Convert.ToDecimal((CashAllocationPluss/100*3) * (years))).ToString("N2");
        #endregion



        // КОНСТРУКТОР КЛАССА
        private static decimal ActiveSumm = new decimal();


        public ClientPortfellVM() 
        {
            decimal totalMarkedValueUSD = 0;  //Сумма текущих стоимостей всех инструментов
            decimal totalUSDprifit = 0;     //Сумма всех прибылей от каждого инструмента

            //..............<Заполнение таблицы Investment>....................
            #region
            InvestCollection = new ObservableCollection<ToolsInvestmentDetails>();
            TotalInvestCollection = new ObservableCollection<TotalInvest>();
            // Actives
            DataTable tableInf = userDAL.GetInvestmentDetails.CurrActives(order);
            for (int i = 0; i < tableInf.Rows.Count; i++) // Сумма всех активов в USD , нужна для подсчета %
            {
                string _value = tableInf.Rows[i][4].ToString();
                decimal _marketVUSD = Convert.ToDecimal(tableInf.Rows[i][3]);

                if (_value != "USD")
                {
                    _marketVUSD = ValueOperation.ValueToUSD(_value, _marketVUSD);
                }
                ActiveSumm += _marketVUSD;
            }
          
                for (int i=0; i<tableInf.Rows.Count; i++)
            {
                string Type = tableInf.Rows[i][6].ToString();
                Type = (Type == "") ? "Alternative Invest" : Type;
                string _value = tableInf.Rows[i][4].ToString();
                decimal _marketVUSD = Convert.ToDecimal(tableInf.Rows[i][3]);

                if (_value!="USD")
                {
                    _marketVUSD = ValueOperation.ValueToUSD(_value, _marketVUSD);
                }
                decimal _nowQuote = QuteParse.QuoteByIsin(tableInf.Rows[i][0].ToString());
                decimal _aqpr = Convert.ToDecimal(tableInf.Rows[i][1]);
                decimal _units = Convert.ToDecimal(tableInf.Rows[i][2]);
                decimal _profit = ((_units * _nowQuote) - (_units * _aqpr));
                _profit = (_marketVUSD == _aqpr) ?0:_profit;
                InvestCollection.Add(new ToolsInvestmentDetails()
                {
                    Type = Type,
                    Isin = tableInf.Rows[i][0].ToString(),
                    Value = _value,
                    currentDate = (DateTime.Now.Date).ToString(),
                    Date = tableInf.Rows[i][5].ToString(),
                    Markedvalue = tableInf.Rows[i][3].ToString(),
                    MarkedvalueUSD = _marketVUSD.ToString("N2"),
                    Units = _units.ToString(),
                    AqPr = _aqpr.ToString(),
                    Quote = _nowQuote.ToString(),
                    profit = _profit.ToString("N2"),
                    Percent = ((_units* _nowQuote)/ ActiveSumm * 100).ToString("N2")

                });
            }
           
            // "Saxxxo", "IB"
            #region
            try
            {
                DataTable saxIbtable = userDAL.GetInvestmentDetails.GetInvestmentSaxoIb(Order);
                int roxsTable = saxIbtable.Rows.Count;
                InvestCollection.Add(new ToolsInvestmentDetails() { Type = "Transfer" });
                if (roxsTable > 0)
                {
                    for (int i = 0; i < roxsTable; i++)
                    {
                        InvestCollection.Add(new ToolsInvestmentDetails()
                        {
                            Type = saxIbtable.Rows[i][0].ToString().ToUpper(),
                            Date = saxIbtable.Rows[i][3].ToString(),
                            MarkedvalueUSD = saxIbtable.Rows[i][2].ToString(),
                            Value = saxIbtable.Rows[i][1].ToString()
                        });
                    }
                }

                InvestCollection.Add(new ToolsInvestmentDetails()
                {
                    Type = "TOTAL RESULTS",
                    MarkedvalueUSD = totalMarkedValueUSD.ToString("N2"),
                    Percent = (totalMarkedValueUSD / ((Convert.ToDecimal(Cash) + totalMarkedValueUSD) / 100)).ToString("N2") + " %",
                    profit = totalUSDprifit.ToString("N2")

                });
            }
            catch (Exception ex)
            {
               // BOX.ShowError(ex.Message, ex.Source);
            }
            #endregion
            #endregion

            //.............<Заполнение таблицы Inflow>.....................
            #region
            InflowDetailsCollection = new ObservableCollection<InflowTools>();
            DataTable tableIn = userDAL.GetInvestmentDetails.GetInflowDetails(order);
            for (int i = 0; i < tableIn.Rows.Count; i++)
            {
                InflowDetailsCollection.Add(new InflowTools()
                {
                     CashAccount = tableIn.Rows[i][0].ToString(),
                     aqprice = tableIn.Rows[i][5].ToString(),
                     CashAccSumm = Convert.ToDecimal(tableIn.Rows[i][4]),
                     countPaper = Convert.ToDecimal(tableIn.Rows[i][6]),
                     date = Convert.ToDateTime(tableIn.Rows[i][7]),
                     Isin = tableIn.Rows[i][2].ToString(),
                     security = tableIn.Rows[i][3].ToString(),
                });
            }

            #endregion
            //......................<Заоплнение Outflow>.....................
            #region
            WithdrawDetailsCollection = new ObservableCollection<Withdraw>();
            DataTable table = userDAL.GetInvestmentDetails.OutFlow(order);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                WithdrawDetailsCollection.Add(new Withdraw()
                {
                    Summ = table.Rows[i][0].ToString(),
                    Date = table.Rows[i][1].ToString()
                });
            }


            #endregion

            //..............<Заполнение таблицы CELL Summary>....................
            #region
            Collection = new ObservableCollection<ToolsInvestmentDetailsTotal>();
            Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Cash Account", Balance = Cash.ToString("N2") });
            Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Market value of investments", Balance = Marcet });
            Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Fund Value", Balance = Found });
            Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Min Cash Allocation", Balance = MINCash });
            Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Encasment", Balance = Encasment });

            Model.ClientReportVM report = new Model.ClientReportVM();
            var tools= report.Tools;
            var toolstitle = report.ToolsTitle;
            var total = report.totallSumm;
            RiscDict dic = new RiscDict();
            decimal totalmidCELLTV = 0;
            for (int i=0; i< toolstitle.Length; i++)
            {
                if (toolstitle[i]!= "leveraged_ETF")
                {
                    decimal toolPrice = Convert.ToDecimal(tools.Rows[0][i]);
                    int midd = dic.MiddCELLTV(toolstitle[i]);
                    if (midd!=0)
                    {
                        var activeMidd = (toolPrice / midd) * 100;
                        totalmidCELLTV += activeMidd;
                    }
                }
            }
            decimal CELLTV = totalmidCELLTV / total;
            LTV = CELLTV;
            //Collection.Add(new ToolsInvestmentDetailsTotal() { Type= "CELLTV", Balance = (CELLTV).ToString("N2")+" %" });
            #endregion
        }
    }
}
