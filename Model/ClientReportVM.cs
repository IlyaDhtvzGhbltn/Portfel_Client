using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Custodian.InterfaceService;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Custodian.Pages;
using System.Windows.Controls;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Input;
using Custodian.DALs.InterfaceService;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Reflection;
using model = Custodian.Model.VisualModels;

/*

ViewModel для страницы с отчетом клиента

*/
namespace Custodian.Model
{
     class ClientReportVM : MainVM
    {
        DateTime zerotime = new DateTime();
        public string DifferenceTermin { get; set; }
        public string RiscLev { get; set; }
        public string LTV2 { get; set; }
        private static DataTable ClientInfo = Storage.datasetKlient.Tables["ClientInfo"];
        public string Allocation { get; set; } // Подпись Allocation - DateTime 
        public ObservableCollection<model.AllocationTable> AllocationCollection { get; set; }
        public ObservableCollection<model.Chart> PercentPortfelDeviation { get; set; }
        public ObservableCollection<model.Diagramm> DiagrammValueCollection { get; set; }
        // Коллекции для графика по инструментам
        public ObservableCollection<model.Chart> ChartCollectionTotal { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionInvestment { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionSpeculation { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionCreditLinkNotes { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionSNGC { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionSNCC { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionSNRS { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionHi_cap_share { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionEmerging_markets { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionMid_cap_share { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionLo_cap { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionOptions { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionFutures { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionLeveraged_ETF { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionMutual_funds { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionResidential_properties { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionCommercial_property { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionClassics_pictures { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionModern_pictures { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionMarks { get; set; }
        public static ObservableCollection<model.Chart> ChartCollectionWine { get; set; }


        private static int _NewMessages { get; set; }
        public int NewMessages
        {
            get
            {
                return _NewMessages; 
            }
            set
            {
                _NewMessages = value;
                NotifyPropertyChanged("NewMessages");
            }
        }

        //................................................................
        public ObservableCollection<model.Diagramm> CurrentISINs { get; set; }
        public ObservableCollection<model.Diagramm> DiagrammCashCollection { get; set; }
        public ObservableCollection<model.Diagramm> DiagrammIdealCollection { get; set; }
        public ObservableCollection<model.Diagramm> RiskActivesCollection { get; set; }

        public ObservableCollection<ToolsInvestmentDetailsTotal> Collection { get; set; }
        public static ObservableCollection<model.OperationsAll> OperationsCollection { get; set; }
        public static ObservableCollection<ToolsInvestmentDetails> InvestCollection { get; set; }
        public static ObservableCollection<TotalInvest> TotalInvestCollection { get; set; }
        public static ObservableCollection<InflowTools> InflowDetailsCollection { get; set; }
        public static ObservableCollection<Withdraw> WithdrawDetailsCollection { get; set; }
        public ObservableCollection<model.RecomendedTable> RecommendTableCollection { get; set; }
        Chat CHAT { get; set; }

        public decimal TotalIndictivePerfomans { get; set; }

        public static string LTV { get; set; }

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

        public string FromDat
        {
            get { return dateFrom.ToString().Remove(10); }
            set
            {
                NotifyPropertyChanged("FromDat");
            }
        }

        public string ToDat
        {
            get { return todate.ToString().Remove(10); }
            set { NotifyPropertyChanged("ToDat"); }
        }


        public DateTime dateFrom { get; set; }
        public DateTime todate { get; set; }

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
            public string SubClassType { get; set; }
        }
        public class ToolsInvestmentDetailsTotal
        {
            public string Type { get; set; }
            public string Balance { get; set; }
        }
        public class InflowTools
        {
            public string CashAccount { get; set; }
            public string CashAccSumm { get; set; }
            public string Isin { get; set; }
            public string security { get; set; }
            public string aqprice { get; set; }
            public decimal countPaper { get; set; }
            public string date { get; set; }

        }
        public class Withdraw
        {
            public decimal Summ { get; set; }
            public string Date { get; set; }
        }

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

        public decimal badcases { get; set; }
        public decimal goodcases { get; set; }
        public string idealP { get; set; }


        private static string client = ClientInfo.Rows[0][6].ToString();


 
        public string typeChart { get; set; }

        private async void ActifeInfo(ToolsInvestmentDetails CurrRow)
        {
            string isin = CurrRow.Isin;
            await actInf(isin);
        }
        Task actInf(string _isin)
        {
            return Task.Run(() =>
            {
                activeInfoString = _isin;
            });
        }

        private string _riscLevel { get; set; }
        public string RiskLevel
        {
            get
            {
                return _riscLevel;
            }
            set
            {
                _riscLevel = value;
                NotifyPropertyChanged("RiskLevel");
            }
        }

        public string DeviantInfo
        {
            get
            {
                return
                    @"
                    0,85 < - optimal deviation
                    0,7 - 0,85 – moderate
                    0,5 - 0,7 -  moderately aggressive
                    0,5 > - aggressive deviation
                    ";
            }
        }

        public RelayCommand GetInfoInNew
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        if (row.Type != null)
                        {
                            try
                            {
                                if (row.Type.Contains("Note"))
                                {
                                    Process.Start("https://castle-privatesolutions.sg/");
                                }
                                else if (row.Type.Contains("Alternative"))
                                {
                                    Process.Start("https://castle-alternatives.sg/");
                                }
                                else
                                {
                                    Process.Start(YahooFinans.httpString(YahooFinans.Tikker(row.Type)));
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.WriteLog(ex.Message, ex.Source);

                                ActiveInfo active = new ActiveInfo();
                                active.WindowState = System.Windows.WindowState.Maximized;
                                if (row.Type.Contains("Note"))
                                {
                                    active.URI = new Uri("https://castle-privatesolutions.sg/");
                                }
                                else if (row.Type.Contains("Alternative"))
                                {
                                    active.URI = new Uri("https://castle-alternatives.sg/");
                                }
                                else
                                {
                                    active.URI = new Uri(YahooFinans.httpString(YahooFinans.Tikker(row.Type)));
                                }
                                active.Show();

                            }


                        }
                        else BOX.ShowInformation("Select Active");

                    }
                    catch (ArgumentOutOfRangeException) { }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                });
            }
        }


        ToolsInvestmentDetails row = new ToolsInvestmentDetails();
        public RelayCommand SelectDetails
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
                        Logger.WriteLog(ex.Message, ex.Source);

                        // BOX.ShowError(ex.Message, ex.Source);
                    }
                });
            }
        }
        /// <summary>
        /// Вызывает метод для обновления графика по ДАТАМ
        /// </summary>
        /// 
        public RelayCommand ChartChange
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _chartChange(ChartCollectionTotal, userDAL.GetInvestmentDetails.ChartInfoPortfell(client, dateFrom, todate));
                    _chartChange(ChartCollectionInvestment, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "investment_bonds"));
                    _chartChange(ChartCollectionSpeculation, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "speculation_bonds"));
                    _chartChange(ChartCollectionCreditLinkNotes, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "Credit_Linked_Notes"));
                    _chartChange(ChartCollectionSNGC, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "SNGC"));
                    _chartChange(ChartCollectionSNCC, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "SNCC"));
                    _chartChange(ChartCollectionSNRS, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "SNRS"));
                    _chartChange(ChartCollectionHi_cap_share, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "Hi_cap_share"));
                    _chartChange(ChartCollectionEmerging_markets, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "emerging_markets"));
                    _chartChange(ChartCollectionMid_cap_share, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "mid_cap_share"));
                    _chartChange(ChartCollectionLo_cap, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "lo_cap"));
                    _chartChange(ChartCollectionOptions, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "options"));
                    _chartChange(ChartCollectionFutures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "futures"));
                    _chartChange(ChartCollectionLeveraged_ETF, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "leveraged_ETF"));
                    _chartChange(ChartCollectionMutual_funds, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "mutual_funds"));
                    _chartChange(ChartCollectionResidential_properties, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "residential_properties"));
                    _chartChange(ChartCollectionCommercial_property, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "commercial_property"));
                    _chartChange(ChartCollectionClassics_pictures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "classics_pictures"));
                    _chartChange(ChartCollectionModern_pictures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "modern_pictures"));
                    _chartChange(ChartCollectionMarks, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "marks"));
                    _chartChange(ChartCollectionWine, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "wine"));
                    ResetStatement(client, dateFrom, todate);
                    FromDat = dateFrom.ToString().Remove(10);
                    ToDat = todate.ToString();
                    NotifyPropertyChanged("FromDat");
                    NotifyPropertyChanged("ToDat");

                });
            }
        }
        /// <summary>
        /// Метод обновляющий график согласно датам в 2х DateTimePicker - работает для активов тк могут быть 0 начальные значения
        /// </summary>
        /// 
        private void _chartChange(ObservableCollection<model.Chart> ChartObj, Dictionary<DateTime, double> Dict)
        {
            string datetoadd = string.Empty;
            try
            {
                ChartObj.Clear();
                var values = Dict.Values.ToArray();
                var dates = Dict.Keys.ToArray();

                double startvallue = 0;
                double OnePercent = 0;
                bool flag = false;

                foreach (var item in values)
                {
                    if (item!=0)
                    {
                        startvallue = item;
                        flag = true;
                        break;
                    }
                }

                for (int i = 0; i < Dict.Count; i++)
                {
                    if (values[i] != 0)
                    {
                        if (values[i] == startvallue && flag == true)
                        {
                            if (dates[i] == zerotime) { datetoadd = "0"; } else { datetoadd = dates[i].ToString().Remove(5); }
                            ChartObj.Add(new model.Chart()
                            {
                                chartDate = datetoadd,
                                chartVal = 0
                            });
                        }
                        else
                        {
                            if (dates[i] == zerotime) { datetoadd = "0"; } else { datetoadd = dates[i].ToString().Remove(5); }

                            OnePercent = startvallue / 100;
                            ChartObj.Add(new model.Chart()
                            {
                                chartDate = datetoadd,
                                chartVal = (values[i] - startvallue) / OnePercent       //тут выдаст ошибка при нуле
                            });
                        }
                    }
                    else
                    {
                        if (dates[i] == zerotime) { datetoadd = "0"; } else { datetoadd = dates[i].ToString().Remove(5); }
                        ChartObj.Add(new model.Chart()
                        {
                            chartDate = datetoadd,
                            chartVal = 0
                        });
                    }
                }
            }
            catch (System.IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
        }
        /// <summary>
        /// Изменения графика для указанных инструментов
        /// </summary>
        public RelayCommand<object> ChartUploadType
        {
            get
            {
                return new RelayCommand<object>(_chartchange);
            }
        }
        private void _chartchange(object sender)
        {
            switch (sender.ToString())
            {
                case "Port_total":
                    _chartChange(ChartCollectionTotal, userDAL.GetInvestmentDetails.ChartInfoPortfell(client, dateFrom, todate));
                    typeChart = "total";
                    break;
            }
        }
        // Открыть чать 
        public ICommand OpenChat
        {
            get { return new RelayCommand(()=> 
            {
                 if (CHAT == null)
            {
                CHAT = new Chat();
                CHAT.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                CHAT.DataContext = MainWindow.chat;
                CHAT.Show();
                CounterMessages.ReadedNowSess = CounterMessages.AllIntoMess - CounterMessages.ReadedLastSess;
            }
            else
            {
                CHAT.Show();
                CounterMessages.ReadedNowSess = CounterMessages.AllIntoMess - CounterMessages.ReadedLastSess;
            }
                CircleMessVisible = false;
            }
            ); }
        }


        //Показать скрыть календари
        public RelayCommand CalendarVisible
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (CalenVisible == true)
                    {
                        CalenVisible = false;
                    }
                    else CalenVisible = true;
                    NotifyPropertyChanged("CalenVisible");
                });
            }
        }
        public bool CalenVisible { get; set; }

        
        public RelayCommand MouseMoveVisible
        {
            get
            {
                return new RelayCommand(() =>
                {
                    CalenVisible = false;
                    NotifyPropertyChanged("CalenVisible");
                });
            }
        }

        // Изменить выделенную строку
        private int _selectedIndex { get; set; }
        public int SelectedIndexCurrent
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyPropertyChanged("SelectedIndexCurrent");
            }
        }

        public RelayCommand<int> ClickMouseP
        {
            get
            {
                return new RelayCommand<int>(RowChanger);
            }
        }
        private void RowChanger(int Segment)
        {
            SelectedIndexCurrent = Segment;
        }

        //Настроить график согласно кнопкам 1m 3m 4m 1y 2y
        public ICommand ChartConstDayChange
        {
            get
            {
                return new RelayCommand<string>(_chartConstDayChange);

            }
        }
        private void _chartConstDayChange(string fromdate)
        {

            var FromDate = new DateTime();
            var NOW = DateTime.Now;
            switch (fromdate)
            {
                case "m1":
                    FromDate = NOW.AddDays(-30); //Вычитаем тридцать дней
                    break;
                case "m3":
                    FromDate = NOW.AddDays(-90);
                    break;
                case "m4":
                    FromDate = NOW.AddDays(-120);
                    break;
                case "y1":
                    FromDate = NOW.AddYears(-1);
                    break;
                case "y2":
                    FromDate = NOW.AddYears(-2);
                    break;
                case "max":
                    var dateMax = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][19];
                    FromDate = Convert.ToDateTime(dateMax);
                    break;
            }
            _chartChange(ChartCollectionTotal, userDAL.GetInvestmentDetails.ChartInfoPortfell(client, FromDate, NOW));
            _chartChange(ChartCollectionInvestment, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "investment_bonds"));
            _chartChange(ChartCollectionSpeculation, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "speculation_bonds"));
            _chartChange(ChartCollectionCreditLinkNotes, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "Credit_Linked_Notes"));
            _chartChange(ChartCollectionSNGC, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "SNGC"));
            _chartChange(ChartCollectionSNCC, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "SNCC"));
            _chartChange(ChartCollectionSNRS, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "SNRS"));
            _chartChange(ChartCollectionHi_cap_share, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "Hi_cap_share"));
            _chartChange(ChartCollectionEmerging_markets, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "emerging_markets"));
            _chartChange(ChartCollectionMid_cap_share, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "mid_cap_share"));
            _chartChange(ChartCollectionLo_cap, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "lo_cap"));
            _chartChange(ChartCollectionOptions, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "options"));
            _chartChange(ChartCollectionFutures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "futures"));
            _chartChange(ChartCollectionLeveraged_ETF, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "leveraged_ETF"));
            _chartChange(ChartCollectionMutual_funds, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "mutual_funds"));
            _chartChange(ChartCollectionResidential_properties, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "residential_properties"));
            _chartChange(ChartCollectionCommercial_property, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "commercial_property"));
            _chartChange(ChartCollectionClassics_pictures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "classics_pictures"));
            _chartChange(ChartCollectionModern_pictures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "modern_pictures"));
            _chartChange(ChartCollectionMarks, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "marks"));
            _chartChange(ChartCollectionWine, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, FromDate, NOW, "wine"));
            ResetStatement(client, dateFrom, todate);
        }


        public RelayCommand IntervalChart
        {
            get
            {
                return new RelayCommand(() =>
                {
                    dateFrom = DateTime.Now.Subtract(new TimeSpan(24 * 30));
                    NotifyPropertyChanged("dateFrom");
                    _chartChange(ChartCollectionTotal, userDAL.GetInvestmentDetails.ChartInfoPortfell(client, dateFrom, todate));

                });
            }
        }

        /// <summary>
        /// Открывает форму с результатом и историей тестирования
        /// </summary>
        public RelayCommand ShowtestResulr
        {
            get
            {
                return new RelayCommand(() => _showtestresult());
            }
        }
        private void _showtestresult()
        {
            TestResult results = new TestResult();
            results.Show();
        }
        public ICommand OpenCastleTraider
        {
            get
            {
                return new RelayCommand(CastleTrader);
            }
        }
        private void CastleTrader()
        {
            try
            {
                Process.Start("https://castle-familyoffice.sg/castle-trader/");
            }
            catch (Exception ex)
            {
                ActiveInfo active = new ActiveInfo();
                active.WindowState = System.Windows.WindowState.Maximized;
                active.URI = new Uri("https://castle-familyoffice.sg/castle-trader/");
                active.Show();
                Logger.WriteLog(ex.Message, ex.Source);
            }
        }

        //......Все инструменты(т.е. = типы), которые есть клиента......
        #region
        public decimal totallSumm { get; set; }


        private decimal totalCash = new decimal();
        public decimal totalTools = new decimal();

        private string[] ClassesDiagrammNames = { "Bonds", "Structured", "Shares", "Derivatives", "Funds", "Alternatives", "Cash" };
        private decimal[] ClassesDiagramm = new decimal[7];

        private string[] CashDiagrammNames = { "Cash Account USD", "Cash Account EUR", "Cash Account GBP", "Cash Account SGD", "Cash Account AUD" };
        private decimal[] CashDiagramm = new decimal[5];

        string[] RiskID = { "P1", "P2", "P3", "P4", "P5", "P6" };
        private decimal[] RiskActives = new decimal[6];

        #endregion


        internal DataTable Tools = userDAL.GetInvestmentDetails.GetToolsCurrentPrice(client, DateTime.Now);

        internal string[] ToolsTitle = new string[20];


        //Конструктор класса
        public ColorCollection Colors { get; set; }
        public static decimal AllPortfelSumminUSD { get; set; }
        public static decimal CashUSD { get; set; }
        public long number => Convert.ToInt64(ClientInfo.Rows[0][13]);                  //Mobile number -long-
        public string mobile => number.ToString("# (###) ###-##-##");                   //Mobile number -string-
        public string KProfession => ClientInfo.Rows[0][14].ToString();                 //Profession
        public string KFName => ClientInfo.Rows[0][7].ToString();                       //First Name
        public string KLName => ClientInfo.Rows[0][8].ToString();                       //Last Name
        public string FIO => KFName + " " + KLName;                                     //First Name + Last Name
        public string Mail => ClientInfo.Rows[0][17].ToString();                        //Mail
        public string Adviser => ClientInfo.Rows[0][18].ToString();                     //Personal Adviser
        public string DateReg => ClientInfo.Rows[0][19].ToString().Remove(11);          //Date of Registration
        public string DateofBirth => ClientInfo.Rows[0][11].ToString();                 //Date of Birth
        public string Order => ClientInfo.Rows[0][6].ToString();                        //Order Number
        public string Value => ClientInfo.Rows[0][5].ToString();                        //Value - USD-GBP-...
        public string Status => ClientInfo.Rows[0][24].ToString();                      //Status
        //public string Company => ClientInfo.Rows[0][23].ToString();                   //Company Name
        public decimal CashAllocStart => Convert.ToDecimal(ClientInfo.Rows[0][22]);     //Cash Allocation

        public string YearsOfRegist => (ClientInfo.Rows[0][19]).ToString();             //Date of Registration
        private string s => YearsOfRegist.Remove(11);
        private string ss => s.Remove(0,6);
        public decimal CashAllocationPluss => Storage.AllPluss;                         //Cash Allocation Pluss

        public string MINCash => (3 * ((InflowDetailsCollection.SummValue()) / 100)).ToString("N2");    //MinCash Allocation

        public string Marcet => (Storage.Count_Mul_Price + Storage.SAXO_IB).ToString("N2"); //Marcet Value
        public decimal Found => AllPortfelSumminUSD;
        private double nowYear = DateTime.Now.Year;
        private Tuple<int, string> Risc_Subclass { get; set; }
        int myRisk { get; set; }

        public double ostYears => Convert.ToDouble(ss) - nowYear;
        private double years => 10 + ostYears;

        public string Encasment => Math.Abs(Convert.ToDecimal(AllPortfelSumminUSD) -
                               Convert.ToDecimal(0.0118 * years * Convert.ToDouble(InflowDetailsCollection.SummValue()))).ToString("N2");

        public decimal CashPort => Convert.ToDecimal(ClientInfo.Rows[0][1]) 
            + Convert.ToDecimal(ClientInfo.Rows[0][2]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[3])
            + Convert.ToDecimal(ClientInfo.Rows[0][3]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[1])
            + Convert.ToDecimal(ClientInfo.Rows[0][4]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[4])
            + Convert.ToDecimal(ClientInfo.Rows[0][5]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[0]);

        List<string> subClassesNames { get; set; }
        List<string> subClassesBadNames { get; set; }
        List<decimal> subClassesBadMarcedValueUSD { get; set; }
        List<decimal> subClassesPercent { get; set; }
        List<string> newgoodclassesnames = new List<string>();
        List<string> riskLivelgoodclasses = new List<string>();
        private DataTable CurrentMessagers { get; }


        public bool CircleMessVisible
        {
            get; set;
        }

        private void ResetCount(object sender, EventArgs e)
        {
          
                int CM = 0;
                string messFrom = string.Empty;

                for (int i = 0; i < userDAL.chatTable.Rows.Count; i++)
                {
                    messFrom = userDAL.chatTable.Rows[i][2].ToString();
                    if (messFrom != Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString())
                        CM++;
                }
                CounterMessages.AllIntoMess = CM;
                NewMessages = CounterMessages.AllIntoMess - (CounterMessages.ReadedLastSess + CounterMessages.ReadedNowSess);

            if (NewMessages > 0)
            {
                CircleMessVisible = true;
            }
            else
            {
                CircleMessVisible = false;
            }
            NotifyPropertyChanged("CircleMessVisible");

        }



        public ClientReportVM(ClientChatModel Chat)
        {
            CurrentMessagers =  new DataTable();
            Chat.ChatTimer.Tick += new EventHandler(ResetCount);
            zerotime = zerotime.AddDays(10);
            zerotime = zerotime.AddMonths(10);
            zerotime = zerotime.AddYears(1110);
            Colors = new ColorCollection
            {
                Investment_bonds_color = new SolidColorBrush() { Color = Color.FromRgb(255, 0,0)},
                Speculation_bonds_color = new SolidColorBrush() { Color = Color.FromRgb(255, 192, 135)},
                Credit_Linked_Notes_color = new SolidColorBrush() { Color = Color.FromRgb(129, 146, 255) },
                SNGC_color = new SolidColorBrush() { Color = Color.FromRgb(255, 222, 255) },
                SNCC_color = new SolidColorBrush() { Color = Color.FromRgb(255, 255, 136) },
                SNRS_color = new SolidColorBrush() {Color = Color.FromRgb(129, 188, 255) },
                Hi_cap_share_color = new SolidColorBrush() { Color = Color.FromRgb(255, 89, 73) },
                emerging_markets_color = new SolidColorBrush() {Color = Color.FromRgb(255, 255, 135) },
                mid_cap_share_color = new SolidColorBrush() { Color = Color.FromRgb(255, 187, 39) },
                lo_cap_color = new SolidColorBrush() {Color = Color.FromRgb(226, 126, 126) },
                options_color = new SolidColorBrush() {Color = Color.FromRgb(16, 93, 85) },
                futures_color = new SolidColorBrush() { Color = Color.FromRgb(255, 142, 129) },
                leveraged_ETF_color = new SolidColorBrush() {Color = Color.FromRgb(249, 142, 60) },
                mutual_funds_color = new SolidColorBrush() {Color = Color.FromRgb(119, 35, 19) },
                residential_properties_color = new SolidColorBrush() { Color = Color.FromRgb(129, 255, 151) },
                commercial_property_color = new SolidColorBrush() { Color = Color.FromRgb(151, 129, 255) },
                classics_pictures_color = new SolidColorBrush() {Color = Color.FromRgb(255, 201, 129) },
                modern_pictures_color = new SolidColorBrush() {Color = Color.FromRgb(255, 135, 233) },
                marks_color = new SolidColorBrush() {Color = Color.FromRgb(129, 159, 255) },
                wine_color = new SolidColorBrush() {Color = Color.FromRgb(51, 119, 17) },
                Totaal_POrtfel_color = new SolidColorBrush() {Color = Color.FromRgb(255,0,0) }
            };

            _selectedIndex = 0;  // выделенная строка в таблице по умолчанию
            if (Tools.Rows.Count == 0)
            {
                Tools = userDAL.GetInvestmentDetails.GetToolsCurrentPrice(client, DateTime.Now.Subtract(TimeSpan.FromDays(1)));
            }
            int rows = Storage.datasetKlient.Tables["RiscInfo"].Rows.Count -1 ;
            RiscLev = Storage.datasetKlient.Tables["RiscInfo"].Rows[rows][1].ToString();
            Parser parcer = new Parser();
            parcer.GetValuesFromSber();

            RiscDict dic = new RiscDict();
            try
            {
                _riscLevel = Settings1.Default.CurrentRiscProfil.ToString();
            }

            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }

            string date = ClientInfo.Rows[0][19].ToString();                                         //Registration Date
            string _date = date.Remove(10);                                                          //Now Date

            dateFrom = DateTime.Parse(_date);
            todate = DateTime.Now;

            //..........Заполнение DGAllocation таблицы...................................
            //..........А также значений для круговых диаграмм............................
            #region
            /*   */

            Allocation = "Allocation - " + DateTime.Today.ToString("d MMM yyyy");                   //label 'Allocation' + DateTime Now
            AllocationCollection = new ObservableCollection<model.AllocationTable>();

            var Cash = new decimal[6];
            var CashTitle = new string[6];

            try
            {

                Cash[0] = Convert.ToDecimal(ClientInfo.Rows[0][1]);
                Cash[1] = Convert.ToDecimal(ClientInfo.Rows[0][2]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[3]);
                Cash[2] = Convert.ToDecimal(ClientInfo.Rows[0][3]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[1]);
                Cash[3] = Convert.ToDecimal(ClientInfo.Rows[0][4]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[4]);
                Cash[4] = Convert.ToDecimal(ClientInfo.Rows[0][5]) * KparserUSD_Value.ConvertToUSD(Parser.Values[2], Parser.Values[0]);
                Cash[5] = Convert.ToDecimal(ClientInfo.Rows[0][22]);

                for (int i = 0; i < Cash.Length; i++)
                {
                    AllPortfelSumminUSD += Cash[i];
                }
                CashUSD = AllPortfelSumminUSD;

                ToolsTitle[0] = "investment_bonds";
                ToolsTitle[1] = "speculation_bonds";
                ToolsTitle[2] = "Credit_Linked_Notes";
                ToolsTitle[3] = "SNGC";
                ToolsTitle[4] = "SNCC";
                ToolsTitle[5] = "SNRS";
                ToolsTitle[6] = "Hi_cap_share";
                ToolsTitle[7] = "emerging_markets";
                ToolsTitle[8] = "mid_cap_share";
                ToolsTitle[9] = "lo_cap";
                ToolsTitle[10] = "options";
                ToolsTitle[11] = "futures";
                ToolsTitle[12] = "leveraged_ETF";
                ToolsTitle[13] = "mutual_funds";
                ToolsTitle[14] = "residential_properties";
                ToolsTitle[15] = "commercial_property";
                ToolsTitle[16] = "classics_pictures";
                ToolsTitle[17] = "modern_pictures";
                ToolsTitle[18] = "marks";
                ToolsTitle[19] = "wine";


                //..............Приращение Кошелька.................

                for (int i = 0; i < Cash.Length; i++)
                {
                    totallSumm += Cash[i];
                }
                totalCash = totallSumm;

                //..............Приращение Инструментов.........

                for (int i = 0; i < Tools.Rows.Count; i++)
                {
                    totallSumm += Convert.ToDecimal(Tools.Rows[0][i]);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }


            // Actives
            DataTable tableInf = userDAL.GetInvestmentDetails.CurrActives(client);

            decimal OnlyActivesWhisOutCashesAcc = 0;
            for (int i = 0; i < tableInf.Rows.Count; i++) // Сумма всех активов в USD , нужна для подсчета %
            {
                string Title = tableInf.Rows[i][6].ToString();
                decimal _nowQuote = 0;

                if (!string.IsNullOrEmpty(Title))
                {
                    _nowQuote = QuteParse.QuoteByIsin(tableInf.Rows[i][0].ToString());
                }
                else
                {
                    decimal PurscharePrice = Convert.ToDecimal(tableInf.Rows[i][3]);
                    _nowQuote = PurscharePrice;
                }

                decimal _units = Convert.ToDecimal(tableInf.Rows[i][2]);
                string _value = tableInf.Rows[i][4].ToString();

                decimal _marketVUSD = 0;

                if (_value != "USD")
                {
                    _marketVUSD = _units * _nowQuote;
                    _marketVUSD = ValueOperation.ValueToUSD(_value, _marketVUSD);

                    OnlyActivesWhisOutCashesAcc += _marketVUSD;
                }
                else
                {
                    _marketVUSD = _units * _nowQuote;
                    OnlyActivesWhisOutCashesAcc += _marketVUSD;
                }
            }


            AllPortfelSumminUSD += OnlyActivesWhisOutCashesAcc;

            if (Tools.Rows.Count <= 0)
            {
                totalTools = AllPortfelSumminUSD;
            }
            else
                for (int i = 0; i < Tools.Columns.Count; i++)
                {
                    totalTools += Convert.ToDecimal(Tools.Rows[0][i]);
                }
            #endregion

            decimal totalMarkedValueUSD = 0;  //Сумма текущих стоимостей всех инструментов
            decimal totalUSDprifit = 0;     //Сумма всех прибылей от каждого инструмента

            //..............<Заполнение таблицы Investment>....................
            #region
            InvestCollection = new ObservableCollection<ToolsInvestmentDetails>();
            TotalInvestCollection = new ObservableCollection<TotalInvest>();

            for (int i = 0; i < tableInf.Rows.Count; i++)
            {
                decimal _nowQuote = 0;
                string Title = tableInf.Rows[i][6].ToString();
                decimal PurscharePrice = 0;
                if (!string.IsNullOrEmpty(Title) || Title=="cash")
                {
                    _nowQuote = QuteParse.QuoteByIsin(tableInf.Rows[i][0].ToString());
                }
                else
                {
                    PurscharePrice = Convert.ToDecimal(tableInf.Rows[i][3]);
                    _nowQuote = PurscharePrice;
                }

                _nowQuote =(_nowQuote == 0) ? Convert.ToDecimal(tableInf.Rows[i][3]) : _nowQuote;
                Title = (Title == "" || Title == "cash") ? "Alternative Invest" : Title;

                string _value = tableInf.Rows[i][4].ToString();
                decimal _marketVUSD = Convert.ToDecimal(tableInf.Rows[i][3]);

                if (_value != "USD")
                {
                    _marketVUSD = ValueOperation.ValueToUSD(_value, _marketVUSD);
                }


                decimal _aqpr = Convert.ToDecimal(tableInf.Rows[i][1]);
                decimal _units = Convert.ToDecimal(tableInf.Rows[i][2]);
                decimal _profit = ((_units * _nowQuote) - (_units * _aqpr));
                _profit = (_marketVUSD == _aqpr) ? 0 : _profit;


                    if (tableInf.Rows[i][0].ToString() != "cash")
                    InvestCollection.Add(new ToolsInvestmentDetails()
                    {
                        Type = Title,
                        Isin = tableInf.Rows[i][0].ToString(),
                        Value = _value,
                        currentDate = (DateTime.Now.Date).ToString().Remove(11),
                        Date = tableInf.Rows[i][5].ToString().Remove(11),
                        Markedvalue = tableInf.Rows[i][3].ToString(),
                        MarkedvalueUSD = _marketVUSD.ToString("N2"),
                        Units = _units.ToString(),
                        AqPr = _aqpr.ToString(),
                        Quote = _nowQuote.ToString("N2"),
                        profit = _profit.ToString("N2"),
                        Percent = ((_units * _nowQuote) / AllPortfelSumminUSD * 100).ToString("N2"),
                        SubClassType = dic.CurlReturnFull(tableInf.Rows[i][7].ToString())

                    });
            }
            //Добавление строки кошелька
            InvestCollection.Add(new ToolsInvestmentDetails()
            {
                Isin = "Cash accounts",
                Percent = (CashUSD / AllPortfelSumminUSD * 100).ToString("N2"),
                MarkedvalueUSD = CashUSD.ToString("N2"),
                currentDate = (DateTime.Now.Date).ToString().Remove(11),
                SubClassType = "cash",
                Type = "Cash",
                Value = "USD"
            });
            //Добавление общей прибыли
            TotalIndictivePerfomans = 0;
            foreach (var perfom in InvestCollection)
            {
                TotalIndictivePerfomans += Convert.ToDecimal(perfom.profit);
            }
            InvestCollection.Add(new ToolsInvestmentDetails()
            {
                Type = "Total Indicative Perfomance",
                profit = TotalIndictivePerfomans.ToString("N2")
            });

            // "Saxxxo", "IB"
            #region
            try
            {
                DataTable saxIbtable = userDAL.GetInvestmentDetails.GetInvestmentSaxoIb(client);
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
                Logger.WriteLog(ex.Message, ex.Source);
            }
            #endregion
            #endregion

            //..........Заполнение Круговой Диаграммы Clases Types........................
            #region
            try
            {
                RiscDict dict = new RiscDict();
                DiagrammValueCollection = new ObservableCollection<model.Diagramm>();

                for (int i = 0; i < InvestCollection.Count; i++)
                {
                    if (InvestCollection[i].MarkedvalueUSD != null)
                    {

                        string col = InvestCollection[i].SubClassType;
                        var res = dict.IntegerDivide(col);
                        if (res.Item2 == "Bonds")
                        {
                            ClassesDiagramm[0] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        }
                        else if (res.Item2 == "Structs")
                        {
                            ClassesDiagramm[1] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        }
                        else if (res.Item2 == "Shares")
                        {
                            ClassesDiagramm[2] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        }
                        else if (res.Item2 == "Derivatives")
                        {
                            ClassesDiagramm[3] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        }
                        else if (res.Item2 == "Funds")
                        {
                            ClassesDiagramm[4] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        }
                        else if (res.Item2 == "Alternative")
                        {
                            ClassesDiagramm[5] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);//Convert.ToDouble(Tools.Rows[0][i]);
                        }
                        else if (res.Item2 == "Cash")
                        {
                            ClassesDiagramm[6] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException) { }
            catch (DivideByZeroException) { }
            catch (NullReferenceException) { }
            // catch (NullReferenceException) { BOX.ShowInformation("Internet Connection Failed"); }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            try
            {
                for (int i = 0; i < ClassesDiagramm.Length; i++)
                {
                    if (ClassesDiagramm[i] > 0)
                    {
                        DiagrammValueCollection.Add(new model.Diagramm()
                        {
                            Name = ClassesDiagrammNames[i].ToString(),
                            Value = ClassesDiagramm[i]
                        });
                    }
                }
            }
            catch (Exception ex) {
                Logger.WriteLog(ex.Message, ex.Source);
            }


            //...........Заполнение Таблицы со всеми операциями.....................
            OperationsCollection = new ObservableCollection<model.OperationsAll>();
            ResetStatement(client, dateFrom, todate);
            #endregion
            //...........Заполнение  AllTools (нужно для идеального портфеля)...........................
            #region

            DiagrammCashCollection = new ObservableCollection<model.Diagramm>();
            try
            {
                for (int i = 0; i < ToolsTitle.Length; i++)
                {
                    if (Convert.ToDouble(Tools.Rows[0][i]) > 0)
                    {
                        DiagrammCashCollection.Add(new model.Diagramm()
                        {
                            Name = ToolsTitle[i],
                            Value = Convert.ToDecimal(Tools.Rows[0][i])
                        });
                    }
                }

            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            #endregion

            //............Заполнение круговой диаграммы Ideal portfel.....................
            #region
            DiagrammIdealCollection = new ObservableCollection<model.Diagramm>();
            try
            {
                if (userDAL.GetRiskTestResult(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString()).Rows.Count == 0)
                {
                    BOX.ShowInformation("You need to pass the Risk-Test");
                    Settings1.Default.CurrentRiscProfil = 0;
                }
                else
                {
                    var client = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
                    var risk = userDAL.GetRiskTestResult(client);
                    int lastRisk = risk.Rows.Count - 1;
                    Settings1.Default.CurrentRiscProfil = Convert.ToInt32(risk.Rows[lastRisk][1]);
                    Settings1.Default.Save();


                    myRisk = Settings1.Default.CurrentRiscProfil;
                    if (myRisk == 0) { }

                    int activescount = 0;
                    for (int i = 0; i < InvestCollection.Count; i++)
                    {
                        if (InvestCollection[i].MarkedvalueUSD != null)
                        { activescount++; }
                    }

                    subClassesNames = new List<string>();          // Текущие активы удовлетворяющие требованиям
                    subClassesPercent = new List<decimal>();        // Текущие значения активов удовлетворяющие требованиям

                    subClassesBadNames = new List<string>();                    // Текущие активы НЕ удовлетворяющие требованиям
                    subClassesBadMarcedValueUSD = new List<decimal>();           // Стоимость текущих активов неподходящих под РП в USD

                    // Анализ имеющихся активов
                    for (int i = 0; i < activescount; i++)
                    {
                        if (InvestCollection[i].SubClassType != null)
                        {
                            string subClass = InvestCollection[i].SubClassType;

                            if (dic.IntegerDivide(subClass).Item1 <= myRisk)
                            {
                                subClassesNames.Add(InvestCollection[i].Isin);

                                if (InvestCollection[i].Isin != "Cash accounts")
                                {
                                    subClassesPercent.Add(Convert.ToDecimal(InvestCollection[i].Quote) * Convert.ToDecimal(InvestCollection[i].Units));
                                }
                                else
                                {
                                    subClassesPercent.Add(Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD));
                                }
                            }
                            else
                            {
                                subClassesBadNames.Add(InvestCollection[i].Isin);

                                if (InvestCollection[i].Isin != "Cash accounts")
                                {
                                    subClassesBadMarcedValueUSD.Add(Convert.ToDecimal(InvestCollection[i].Quote) * Convert.ToDecimal(InvestCollection[i].Units));
                                }
                                else
                                {
                                    subClassesBadMarcedValueUSD.Add(Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD));
                                }
                            }

                            //Нужно для заполнения внешнего круга с Р2 - Р6
                            switch (dic.IntegerDivide(subClass).Item1)
                            {
                                case 1:
                                    RiskActives[0] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD);
                                    break;
                                case 2:
                                    RiskActives[1] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD);
                                    break;
                                case 3:
                                    RiskActives[2] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD);
                                    break;
                                case 4:
                                    RiskActives[3] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD);
                                    break;
                                case 5:
                                    RiskActives[4] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD);
                                    break;
                                case 6:
                                    RiskActives[5] += Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD);
                                    break;
                            }
                        }
                    }
                    //

                    int current = subClassesNames.Count;    // число нормальных активов
                    goodcases = KparserUSD_Value.ArraySummDouble(subClassesPercent); // столько всего денег подходит под условие в долларах

                    badcases =  (AllPortfelSumminUSD) - goodcases; // сколько всего денег нужно распределить в долларах 
                                                                                  // Если все активы подходят под риск уровень то их нужно распределить просто раскидав по разным другим активам до 10
                                                                                  // Заполнение рекомендуемого портфеля
                    int changesactives = 10 - (current); // сколько активов нужно заменить
                    decimal newgoodcase = badcases / changesactives; 
                    if (newgoodcase <= 0) { newgoodcase = goodcases / 10; }

                    string tmp = string.Empty;
                    string risks = string.Empty;

                   

                    ///АКТИВОВ МЕНЕЕ 10
                    if (activescount < 10)
                    {
                        //int different = AllPortfelSumminUSD - 
                        List<string> goodNames = dic.RiscDivide(myRisk, subClassesNames);
                        Random rand = new Random();
                       
                        // Заполнение новыми, более подходящими активами
                        //goodcases = 0;
                        for (int i = 0; i < changesactives; i++)
                        {

                            newgoodclassesnames.Add(goodNames[rand.Next(0, goodNames.Count)]);
                            subClassesBadMarcedValueUSD.Add(newgoodcase);

                            model.Diagramm diagramm = 
                            new model.Diagramm() { Name = newgoodclassesnames[i], Value = Math.Round(newgoodcase / Convert.ToDecimal(AllPortfelSumminUSD) * 100, 6) };

                       
                           DiagrammIdealCollection.Add(diagramm);
                           riskLivelgoodclasses.Add(dic.IntegerDivide(newgoodclassesnames[i]).Item1.ToString());      
                        }
                        //Заполнение старыми, которые подходят под требования
                        {
                            for (int i = 0; i < current; i++)
                            {
                                DiagrammIdealCollection.Add(new model.Diagramm()
                                {
                                    Name = subClassesNames[i],
                                    Value = Math.Round(subClassesPercent[i] / Convert.ToDecimal(AllPortfelSumminUSD) * 100, 2)
                                });
                            }
                        }
                    }

                    //АКТИВОВ БОЛЕЕ-РАВНО 10
                    else if (activescount >= 10)
                    {
                        if (newgoodcase > 0)
                        {
                            int changes = subClassesBadNames.Count;
                            List<string> goodNames = dic.RiscDivide(myRisk, subClassesNames);
                            Random rand = new Random();

                            for (int i = 0; i < changes; i++)
                            {
                                newgoodclassesnames.Add(goodNames[rand.Next(0, goodNames.Count)]);
                                tmp = newgoodclassesnames[i].ToString();
                                tmp = (tmp == "Cash_Accounts") ? "cash" : tmp;
                                risks = dic.IntegerDivide(tmp).Item1.ToString();
                                riskLivelgoodclasses.Add(risks);

                                if (newgoodclassesnames[i] == "Cash")
                                {
                                    newgoodclassesnames[i] = "Cash accounts";
                                }
                            }

                        List<string> ZanesennijeName = new List<string>();
                        List<int> IndexZanesennogo = new List<int>();

                        //Заполнение старыми, которые подходят под требования
                        for (int i = 0; i < current; i++)
                        {
                                model.Diagramm diagramm =
                           new model.Diagramm() { Name = newgoodclassesnames[i], Value = Math.Round(subClassesPercent[i] / (AllPortfelSumminUSD) * 100,7) };


                            DiagrammIdealCollection.Add(diagramm);
                            ZanesennijeName.Add(diagramm.Name);
                            IndexZanesennogo.Add(i);
                        }

                        //Заполнение новыми подходящими
                            newgoodcase = (AllPortfelSumminUSD - Convert.ToDecimal(Math.Round(subClassesPercent.ListElementSumm(),6))) / changes;
                            decimal Summport = (Math.Round(AllPortfelSumminUSD,8));
                            for (int i = 0; i < changes; i++)
                            {
                                model.Diagramm diagramm =
                            new model.Diagramm() { Name = newgoodclassesnames[i], Value = Math.Round(newgoodcase / Summport * 100, 8) };


                                if (!ZanesennijeName.Contains(diagramm.Name))
                                {
                                    DiagrammIdealCollection.Add(diagramm);
                                    ZanesennijeName.Add(diagramm.Name);
                                    IndexZanesennogo.Add(i + current);
                                }
                                else
                                {
                                    int index = ZanesennijeName.IndexOf(diagramm.Name);
                                    DiagrammIdealCollection[index].Value += diagramm.Value;
                                }
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                if (BOX.ShowQuestion("The Application will not correctly run. Would you like to continue anyway ? ", "Internet Connection Failed") == false)
                {
                    Environment.Exit(0);
                }
            }
            catch (System.ArgumentOutOfRangeException) { }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            #endregion

            //.............. Заполнение Summary таблицы .................

            // CashTitle нужны для заполнения Summary Названиями
            CashTitle[0] = "Cash USD";
            CashTitle[1] = "Cash EUR";
            CashTitle[2] = "Cash GBP";
            CashTitle[3] = "Cash SGD";
            CashTitle[4] = "Cash AUD";
            CashTitle[5] = "Cash Allocation";

            #region
            try
            {
                for (int i = 0; i < CashTitle.Length; i++)
                {
                    AllocationCollection.Add(new model.AllocationTable()
                    {
                        Type = CashTitle[i],
                        USD = Cash[i].ToString("N2"),
                        Wieght = (Cash[i] / AllPortfelSumminUSD * 100).ToString("N2")
                    });
                }
                for (int i = 0; i < InvestCollection.Count; i++)
                {
                    if (InvestCollection[i].Isin != null)
                    {
                        var USDPriseActive = Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        AllocationCollection.Add(new model.AllocationTable()
                        {
                            Type = InvestCollection[i].Isin,
                            USD = USDPriseActive.ToString("N2"),
                            Wieght = (USDPriseActive / AllPortfelSumminUSD * 100).ToString("N2")
                        });
                    }
                }
                AllocationCollection.Add(new model.AllocationTable()
                {
                    Type = "Total", USD = AllPortfelSumminUSD.ToString("N2"), Wieght = (100).ToString("N2")
                });

            }
            catch (IndexOutOfRangeException) { } //у нового пользователя тут пусто
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);

            }
            //try
            //{

            //}
            //catch (DivideByZeroException)
            //{
            //    BOX.ShowInformation("Internet Connect Error. Please restart programm");
            //}
            #endregion
            //...........Заполнение Chart диаграммы.......................................
            #region
            ChartCollectionTotal = new ObservableCollection<model.Chart>();
            ChartCollectionInvestment = new ObservableCollection<model.Chart>();
            ChartCollectionSpeculation = new ObservableCollection<model.Chart>();
            ChartCollectionCreditLinkNotes = new ObservableCollection<model.Chart>();
            ChartCollectionSNGC = new ObservableCollection<model.Chart>();
            ChartCollectionSNCC = new ObservableCollection<model.Chart>();
            ChartCollectionSNRS = new ObservableCollection<model.Chart>();
            ChartCollectionHi_cap_share = new ObservableCollection<model.Chart>();
            ChartCollectionEmerging_markets = new ObservableCollection<model.Chart>();
            ChartCollectionMid_cap_share = new ObservableCollection<model.Chart>();
            ChartCollectionLo_cap = new ObservableCollection<model.Chart>();
            ChartCollectionOptions = new ObservableCollection<model.Chart>();
            ChartCollectionFutures = new ObservableCollection<model.Chart>();
            ChartCollectionLeveraged_ETF = new ObservableCollection<model.Chart>();
            ChartCollectionMutual_funds = new ObservableCollection<model.Chart>();
            ChartCollectionResidential_properties = new ObservableCollection<model.Chart>();
            ChartCollectionCommercial_property = new ObservableCollection<model.Chart>();
            ChartCollectionClassics_pictures = new ObservableCollection<model.Chart>();
            ChartCollectionModern_pictures = new ObservableCollection<model.Chart>();
            ChartCollectionMarks = new ObservableCollection<model.Chart>();
            ChartCollectionWine = new ObservableCollection<model.Chart>();

            _chartChange(ChartCollectionTotal, userDAL.GetInvestmentDetails.ChartInfoPortfell(client, dateFrom, todate));
            _chartChange(ChartCollectionInvestment, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "investment_bonds"));
            _chartChange(ChartCollectionSpeculation, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "speculation_bonds"));
            _chartChange(ChartCollectionCreditLinkNotes, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "Credit_Linked_Notes"));
            _chartChange(ChartCollectionSNGC, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "SNGC"));
            _chartChange(ChartCollectionSNCC, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "SNCC"));
            _chartChange(ChartCollectionSNRS, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "SNRS"));
            _chartChange(ChartCollectionHi_cap_share, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "Hi_cap_share"));
            _chartChange(ChartCollectionEmerging_markets, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "emerging_markets"));
            _chartChange(ChartCollectionMid_cap_share, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "mid_cap_share"));
            _chartChange(ChartCollectionLo_cap, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "lo_cap"));
            _chartChange(ChartCollectionOptions, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "options"));
            _chartChange(ChartCollectionFutures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "futures"));
            _chartChange(ChartCollectionLeveraged_ETF, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "leveraged_ETF"));
            _chartChange(ChartCollectionMutual_funds, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "mutual_funds"));
            _chartChange(ChartCollectionResidential_properties, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "residential_properties"));
            _chartChange(ChartCollectionCommercial_property, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "commercial_property"));
            _chartChange(ChartCollectionClassics_pictures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "classics_pictures"));
            _chartChange(ChartCollectionModern_pictures, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "modern_pictures"));
            _chartChange(ChartCollectionMarks, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "marks"));
            _chartChange(ChartCollectionWine, userDAL.GetInvestmentDetails.ChartInfoOneActive(client, dateFrom, todate, "wine"));

            #endregion
            //...........Заполнение уровня отклонения от идеального портфеля..............
            #region
            var tempTatal = (totalTools);

            PercentPortfelDeviation = new ObservableCollection<model.Chart>();
            PercentPortfelDeviation.Add(new model.Chart()
            {
                chartDate = DateTime.Now.ToString(),
                chartVal = Convert.ToDouble(badcases / tempTatal * 100)
            });

            var idealPInt = (badcases / (AllPortfelSumminUSD) * 100);
            idealPInt = (idealPInt < 0) ? 0 : idealPInt;
            idealP = idealPInt.ToString("N1") + "%";
            #endregion
            //...........Заполнение отклонения Difference [Critical-]......................
            DifferText(idealPInt);
            //...........Заполнение Круговой диаграммы с риск уровнями...................
            #region
            RiskActivesCollection = new ObservableCollection<model.Diagramm>();
            try
            {
                for (int i = 0; i < RiskActives.Length; i++)
                {
                if (RiskActives[i] != 0)
                {
                    RiskActivesCollection.Add(new model.Diagramm()
                    {
                        Name = RiskID[i],
                        Value = RiskActives[i]
                    });
                }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }

            #endregion
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //.............<Заполнение таблицы Inflow>.....................
            #region

            InflowDetailsCollection = new ObservableCollection<InflowTools>();
            DataTable tableIn = userDAL.GetInvestmentDetails.GetInflowDetails(client);
            string Isin;
            for (int i = 0; i < tableIn.Rows.Count; i++)
            {

                Isin = tableIn.Rows[i][0].ToString();
                InflowTools InfloRow = new InflowTools();

                if (Isin == "cash")
                {
                    InfloRow.CashAccount = tableIn.Rows[i][0].ToString();
                    InfloRow.CashAccSumm = Convert.ToDecimal(tableIn.Rows[i][4]).ToString("N2");
                    InfloRow.date = (tableIn.Rows[i][7]).ToString().Remove(11);
                }
                else
                {
                    InfloRow.CashAccount = tableIn.Rows[i][0].ToString();
                    InfloRow.CashAccSumm = Convert.ToDecimal(tableIn.Rows[i][4]).ToString("N2");
                    InfloRow.date = (tableIn.Rows[i][7]).ToString().Remove(11);
                    InfloRow.aqprice = tableIn.Rows[i][5].ToString();
                    InfloRow.countPaper = Convert.ToDecimal(tableIn.Rows[i][6]);
                    InfloRow.Isin = tableIn.Rows[i][2].ToString();
                    InfloRow.security = tableIn.Rows[i][3].ToString();
                }

                InflowDetailsCollection.Add(InfloRow);
            }

            #endregion
            //......................<Заоплнение Outflow>.....................
            #region
            WithdrawDetailsCollection = new ObservableCollection<Withdraw>();
            DataTable table = userDAL.GetInvestmentDetails.OutFlow(client);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                WithdrawDetailsCollection.Add(new Withdraw()
                {
                    Summ = Convert.ToDecimal(table.Rows[i][0]),
                    Date = (table.Rows[i][1]).ToString()
                });
            }
            #endregion
            //..............<Заполнение таблицы CELL Summary>....................
            #region
            try
            {
                Collection = new ObservableCollection<ToolsInvestmentDetailsTotal>();
                Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Cash Account", Balance = CashPort.ToString("N2") });
                Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Market Value of Investments", Balance = (Found - CashPort).ToString("N2") });
                Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Fund Value", Balance = Found.ToString("N2") });
                Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Min Cash Allocation", Balance = MINCash });
                Collection.Add(new ToolsInvestmentDetailsTotal() { Type = "Encashment", Balance = Encasment });

                decimal totalmidCELLTV = 0;
                for (int i = 0; i < InvestCollection.Count; i++)
                {
                    if (InvestCollection[i].SubClassType != "leveraged_ETF" && InvestCollection[i].SubClassType != null)
                    {
                        decimal toolPrice = Convert.ToDecimal(InvestCollection[i].MarkedvalueUSD) + Convert.ToDecimal(InvestCollection[i].profit);
                        int midd = dic.MiddCELLTV(InvestCollection[i].SubClassType);
                        if (midd != 0)
                        {
                            var activeMidd = (toolPrice / 100) * midd;
                            totalmidCELLTV += activeMidd;
                        }
                    }
                }

                for (int i = 0; i < Cash.Length; i++)
                {
                    decimal j = Cash[i];
                    int temp = ((90 + 95) / 2);
                    decimal Ktemp = j / 100 * temp;
                    totalmidCELLTV += Ktemp;
                }

                decimal CELLTV = totalmidCELLTV / AllPortfelSumminUSD * 100;
                LTV = Math.Round(CELLTV).ToString(); //
            }
            catch (IndexOutOfRangeException) { }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            #endregion

            //...........Заполнение диаграммы CurrentPortFel (стоит в конце тк использует InvestCollection ) ...........................
            #region
            CurrentISINs = new ObservableCollection<model.Diagramm>();
            try
            {
                foreach (var item in InvestCollection)
                {
                    if (item.Isin != null)
                        CurrentISINs.Add(new model.Diagramm()
                        {
                            Name = item.Isin,
                            Value = Convert.ToDecimal(item.Percent)
                        });
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message, ex.Source);
            }
            #endregion
            //...........Заполнение таблицы - пояснения для рекомендуемого портфеля  ...........................
            #region
            RecommendTableCollection = new ObservableCollection<model.RecomendedTable>();
                        string className = string.Empty;
                        string subclass = string.Empty;
                        string clas = string.Empty;
                        int risc = -1;
                        string advice = string.Empty;

                        //if (DiagrammIdealCollection.Count > 10)
                        //{
                        try
                        {
                            for (int i = 0; i < InvestCollection.Count; i++)
                            {
                                if (InvestCollection[i].MarkedvalueUSD != null)
                                {
                                    subclass = InvestCollection[i].SubClassType;
                                    Risc_Subclass = dic.IntegerDivide(subclass);
                                    clas = Risc_Subclass.Item2;
                                    risc = Risc_Subclass.Item1;
                                    if (myRisk < risc)
                                        advice = "Sell, does not suits your Risc Profile";
                                    else advice = "Hold";

                                    RecommendTableCollection.Add(new model.RecomendedTable()
                                    {
                                        Type = clas,
                                        Name = InvestCollection[i].Type,
                                        Advice = advice,  // Hold   --  Sell, not suits RP  -- Add to portfolio
                                        Value = InvestCollection[i].MarkedvalueUSD,
                                        Isin = InvestCollection[i].Isin,
                                        Weight = InvestCollection[i].Percent,
                                        RLevel = risc.ToString()

                                    });
                                }
                            }
                        }
                        catch (NullReferenceException) { }
                            //Новые активы
                            decimal markedval = -1;
                            string tempsub = string.Empty;


                            for (int j = 0; j < newgoodclassesnames.Count; j++)
                            {
                                markedval = subClassesBadMarcedValueUSD[j];
                                tempsub = newgoodclassesnames[j].ToString();
                                tempsub = (tempsub == "Cash_Accounts") ? "cash" : tempsub;
                                subclass = dic.IntegerDivide(tempsub).Item2;

                                RecommendTableCollection.Add(new model.RecomendedTable()
                                {
                                    Type = subclass,
                                    Name = newgoodclassesnames[j],
                                    Value = (markedval).ToString("N2"),
                                    Advice = "Add to Portfolio",
                                    Weight = Math.Round((markedval / (AllPortfelSumminUSD)) * 100, 2).ToString("N2"),
                                    RLevel = riskLivelgoodclasses[j]
                                });
                            }



            #endregion
        }
        
        private void DifferText(decimal difference)
        {
            if (difference <= 15)
            {
                DifferenceTermin = "Optimal";
            }
            else if (difference <= 30 && difference > 15)
            {
                DifferenceTermin = "Moderate";
            }
            else if (difference <= 50 && difference > 30)
            {
                DifferenceTermin = "Agressively";
            }
            else if (difference > 50)
            {
                DifferenceTermin = "Critical";
            }
        }
        private void ResetStatement(string client, DateTime dateFrom, DateTime todate)
        {
            OperationsCollection.Clear();
            var tableOp = userDAL.GetInvestmentDetails.StatementOperation(client, dateFrom, todate);
            double money = 0;
            string tempstatementmoney = null;
            try
            {
                for (int i = 0; i < tableOp.Rows.Count; i++)
                {
                    string dat = tableOp.Rows[i][4].ToString();
                    if (dat.Length > 10)
                        dat = dat.Remove(10);
                    tempstatementmoney = tableOp.Rows[i][3].ToString().Replace('.', ',');
                    money = Convert.ToDouble(tempstatementmoney);
                    OperationsCollection.Add(new model.OperationsAll()
                    {
                        Type = tableOp.Rows[i][0].ToString(),
                        isin = tableOp.Rows[i][1].ToString(),
                        value = tableOp.Rows[i][2].ToString(),
                        money = money.ToString("N2"),
                        Aqprice = tableOp.Rows[i][5].ToString(),
                        Units = tableOp.Rows[i][6].ToString(),
                        date = dat
                    });
                }
            }
            catch (Exception)
            {
                BOX.ShowInformation("Statement Error");
            }
        }
    }
   
}
