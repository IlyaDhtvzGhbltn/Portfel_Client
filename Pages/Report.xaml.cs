using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Threading;
using GalaSoft.MvvmLight.Command;
using Custodian.DALs.InterfaceService;
using Custodian.Model;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Custodian.Pages
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {

        public Report()
        {
            InitializeComponent();
            this.Loaded += (s, e) => sInner.AddListboxLegend(iLegend);

            Port_classics_pictures.Click += new RoutedEventHandler(Resize_dynamic);
            Port_commercial_property.Click += new RoutedEventHandler(Resize_dynamic);
            Port_Credit_Linked_Notes.Click += new RoutedEventHandler(Resize_dynamic);
            Port_emerging_markets.Click += new RoutedEventHandler(Resize_dynamic);
            Port_futures.Click += new RoutedEventHandler(Resize_dynamic);
            Port_Hi_cap_share.Click += new RoutedEventHandler(Resize_dynamic);
            Port_investment_bonds.Click += new RoutedEventHandler(Resize_dynamic);
            Port_leveraged_ETF.Click += new RoutedEventHandler(Resize_dynamic);
            Port_lo_cap.Click += new RoutedEventHandler(Resize_dynamic);
            Port_marks.Click += new RoutedEventHandler(Resize_dynamic);
            Port_mid_cap_share.Click += new RoutedEventHandler(Resize_dynamic);
            Port_modern_pictures.Click += new RoutedEventHandler(Resize_dynamic);
            Port_mutual_funds.Click += new RoutedEventHandler(Resize_dynamic);
            Port_options.Click += new RoutedEventHandler(Resize_dynamic);
            Port_residential_properties.Click += new RoutedEventHandler(Resize_dynamic);
            Port_SNCC.Click += new RoutedEventHandler(Resize_dynamic);
            Port_SNGC.Click += new RoutedEventHandler(Resize_dynamic);
            Port_SNRS.Click += new RoutedEventHandler(Resize_dynamic);
            Port_speculation_bonds.Click += new RoutedEventHandler(Resize_dynamic);
            Port_wine.Click += new RoutedEventHandler(Resize_dynamic);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TotalRBTN.IsChecked = true;
            dynamic.Background = Brushes.White;
            CurrentPortfel.Background = Brushes.White;
            //if (MessageBoxResult.Yes == BOX.ShowQuestion("Do you want to open Report?", "Report"))
            if (BOX.ShowQuestion("Do you want to open Report?", "CGAAF Report") == true)
            {
                ReportPDFCreator creator = new ReportPDFCreator((ClientReportVM)this.DataContext, "Report.pdf", CurrentPortfel, RecomendPort, dynamic, Legeng, Convert.ToDouble(ClientReportVM.AllPortfelSumminUSD), true);
                creator.CreateReport();
            }
            else
            {
                ReportPDFCreator creator = new ReportPDFCreator((ClientReportVM)this.DataContext, "Report.pdf", CurrentPortfel, RecomendPort, dynamic, Legeng, Convert.ToDouble(ClientReportVM.AllPortfelSumminUSD), false);
                creator.CreateReport();
                BOX.ShowInformation("Report was created successfully!");
            }
            dynamic.Background = null;
            CurrentPortfel.Background = null;
        } 
 

        private void CloseT(object sender, RoutedEventArgs e)
        {
            if (BOX.ShowQuestion("Do you realy want to close Application ?", "Exit") == true)
                Environment.Exit(0);
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Minimase(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void Maximase(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }
        // Перерисовка графика с историей активов - у грид который нужно перерисовать начальное значение Height должно быть задано числом
        private void Resize_dynamic(object sender, RoutedEventArgs e)
        {
            TTT.ZoomFactor += 1;
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            WindowScroll.ScrollToVerticalOffset(WindowScroll.VerticalOffset + 400);
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {
            WindowScroll.ScrollToVerticalOffset(WindowScroll.VerticalOffset - 400);
        }
    }
 
}
