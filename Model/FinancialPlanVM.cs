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

        public ObservableCollection<model.Chart> ChartPlpanMax { get; set; }
        public ObservableCollection<model.Chart> ChartPlpanMin { get; set; }
        public ObservableCollection<model.Chart> ChartPlpanMidl { get; set; }

        public double GoodScreenAnnotation { get; set; }
        public double NormalScreenAnnotation { get; set; }
        public double BadScreenAnnotation { get; set; }

        public int CurrentPRI { get; set; }
        public double CurrentPortfel { get; set; }
        public double Target { get; set; }
        public double TargetTime { get; set; }

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
            ChartPlpanMin = new ObservableCollection<model.Chart>();
            ChartPlpanMidl = new ObservableCollection<model.Chart>();
            ChartPlpanMax = new ObservableCollection<model.Chart>();
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

                    ChartPlpanMax.Add(new model.Chart { chartDate = "0", chartVal =0 });
                    ChartPlpanMin.Add(new model.Chart { chartDate = "0", chartVal = 0 });
                    ChartPlpanMidl.Add(new model.Chart { chartDate = "0", chartVal = 0 });

                    for (int i=0; i< TargetTime; i++)
                    {
                        ChartPlpanMax.Add(new model.Chart { chartVal = MaxChar.PerfPrice[i], chartDate = model.EtfDates[i] });
                        ChartPlpanMin.Add(new model.Chart { chartVal = MinChar.PerfPrice[i], chartDate = model.EtfDates[i] });
                        ChartPlpanMidl.Add(new model.Chart { chartVal = MiddleChart.PerfPrice[i], chartDate = model.EtfDates[i] });

                       
                    }
                }));
            }
        }


    }
}
