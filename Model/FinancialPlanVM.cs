using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Input;
using FundContext = Custodian.InterfaceService.EtfData.ETFContext;
using model = Custodian.Model.VisualModels;
namespace Custodian.Model
{
    class FinancialPlanVM : MainVM
    {
        FundContext EtfChartContext { get; set; }

        public ObservableCollection<model.DigitChart> ChartPlpanMax { get; set; }
        public ObservableCollection<model.DigitChart> ChartPlpanMin { get; set; }
        public ObservableCollection<model.DigitChart> ChartPlpanMidl { get; set; }

        //public double GoodScreenAnnotation { get; set; }
        //public double NormalScreenAnnotation { get; set; }
        //public double BadScreenAnnotation { get; set; }

        public int CurrentPRI { get; set; }
        public double CurrentPortfel { get; set; }
        public double Target { get; set; }
        public int TargetTime { get; set; }

        public string OptitmisticResult { get; set; }
        public string NormalResult { get; set; }
        public string PessimisticResult { get; set; }

        public double _X1 { get; set; }
        public double _X2 { get; set; }
        public double MaxY1 { get; set; }
        public double MaxY2 { get; set; }


        public double MidY1 { get; set; }
        public double MidY2 { get; set; }


        public double MinY1 { get; set; }
        public double MinY2 { get; set; }

        public bool IsEnabledTextBoxs { get; set; }

        private double _CurrentPortfel { get; set; }
        private string _CurrentPRI { get; set; }
        
        internal FinancialPlanVM(ClientReportVM ContextModel)
        {
            _CurrentPRI = ContextModel.RiscLev;
            _CurrentPortfel = Convert.ToDouble(ClientReportVM.AllPortfelSumminUSD);
            IsEnabledTextBoxs = true;
            CurrentPRI = 1;
            CurrentPortfel = 1000000;
            Target = 50;
            TargetTime = 5;
            ChartPlpanMin = new ObservableCollection<model.DigitChart>();
            ChartPlpanMidl = new ObservableCollection<model.DigitChart>();
            ChartPlpanMax = new ObservableCollection<model.DigitChart>();
        }


        private ICommand _PortfelData;
        public ICommand InsertCurrentPortfelData
        {
            get
            {
               return _PortfelData ??
                    (
                    _PortfelData = new RelayCommand(()=> 
                    {
                        
                        CurrentPRI = Convert.ToInt32(_CurrentPRI);
                        CurrentPortfel = Math.Round(_CurrentPortfel, 2);
                        IsEnabledTextBoxs = false;
                        NotifyPropertyChanged("CurrentPRI");
                        NotifyPropertyChanged("CurrentPortfel");
                        NotifyPropertyChanged("IsEnabledTextBoxs");
                    })
                    );
            }
        }

        private ICommand _CheckNull;
        public ICommand CheckNull
        {
            get
            {
                return _CheckNull ?? (_CheckNull = new RelayCommand(() => 
                {
                    CurrentPRI = 1;
                    CurrentPortfel = 1000000;
                    IsEnabledTextBoxs = true;
                    NotifyPropertyChanged("CurrentPRI");
                    NotifyPropertyChanged("CurrentPortfel");
                    NotifyPropertyChanged("IsEnabledTextBoxs");

                }));
            }
        }
        private ICommand _FillEtfCollections;
        public ICommand FillEtfCollections
        {
            get
            {
                return _FillEtfCollections ?? (_FillEtfCollections = new RelayCommand(()=> 
                {
                    if (ChartPlpanMin != null)
                    {
                        ChartPlpanMin.Clear();
                        ChartPlpanMax.Clear();
                        ChartPlpanMidl.Clear();
                    }
                    NotifyPropertyChanged("Target");
                    NotifyPropertyChanged("TargetTime");
                    EtfChartContext = new FundContext("Dict.txt", CurrentPRI);
                    var MaxChar = EtfChartContext.MaxFund();
                    var MinChar = EtfChartContext.MinFund();
                    var MiddleChart = EtfChartContext.MiddleFund();

                    ChartPlpanMax.Add(new model.DigitChart { Name = 0, Value =0 });
                    ChartPlpanMin.Add(new model.DigitChart { Name = 0, Value = 0 });
                    ChartPlpanMidl.Add(new model.DigitChart { Name = 0, Value = 0 });

                    for (int i=0; i< MaxChar.PerfPrice.Length; i++)
                    {
                        ChartPlpanMax.Add(new model.DigitChart { Value = MaxChar.PerfPrice[i], Name = i });
                        ChartPlpanMin.Add(new model.DigitChart { Value = MinChar.PerfPrice[i], Name = i });
                        ChartPlpanMidl.Add(new model.DigitChart { Value = MiddleChart.PerfPrice[i], Name = i });
                    }
                    int MAXMASS = MaxChar.PerfPrice.Length - 1;


                    ChartPlpanMax.Add(new model.DigitChart { Value = MaxChar.PerfPrice[MAXMASS], Name = 6 });
                    ChartPlpanMin.Add(new model.DigitChart { Value = MinChar.PerfPrice[MAXMASS], Name = 6 });
                    ChartPlpanMidl.Add(new model.DigitChart { Value = MiddleChart.PerfPrice[MAXMASS], Name = 6 });

                    var one_perc = CurrentPortfel / 100;
                    OptitmisticResult = (CurrentPortfel + (one_perc * MaxChar.PerfPrice[TargetTime])).ToString("N2");
                    PessimisticResult = (CurrentPortfel + (one_perc * MinChar.PerfPrice[TargetTime])).ToString("N2");
                    NormalResult = (CurrentPortfel +  (one_perc * MiddleChart.PerfPrice[TargetTime])).ToString("N2");


                    _X1 = TargetTime - 0.05;
                    _X2 = TargetTime + 0.05;

                    MaxY1 = MaxChar.PerfPrice[TargetTime ] - 10;
                    MaxY2 = MaxChar.PerfPrice[TargetTime ] + 10;

                    MinY1 = MinChar.PerfPrice[TargetTime ] - 10;
                    MinY2 = MinChar.PerfPrice[TargetTime ] + 10;

                    MidY1 = MiddleChart.PerfPrice[TargetTime] - 10;
                    MidY2 = MiddleChart.PerfPrice[TargetTime] + 10;


                    NotifyPropertyChanged("OptitmisticResult");
                    NotifyPropertyChanged("PessimisticResult");
                    NotifyPropertyChanged("NormalResult");

                    NotifyPropertyChanged("_X1");
                    NotifyPropertyChanged("_X2");
                    NotifyPropertyChanged("MaxY1");
                    NotifyPropertyChanged("MaxY2");

                    NotifyPropertyChanged("MinY1");
                    NotifyPropertyChanged("MinY2");

                    NotifyPropertyChanged("MidY1");
                    NotifyPropertyChanged("MidY2");


                }));
            }
        }


    }
}
