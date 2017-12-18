using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Custodian;

namespace Custodian.DALs.InterfaceService
{
   public class Page_Location_Visibly
    {

        /// <summary>
        /// Список видимых окон
        /// </summary>
        /// <param name="cw"></param>
        /// <returns></returns>
        internal static List<Grid> GetWinVisibility(ClientWindow cw)
        {
            List<Grid> WinVisibilityCollection = new List<Grid>();
            foreach (Grid gr in cw.cavRoot.Children)
            {
                if (gr.Visibility == System.Windows.Visibility.Visible)
                {
                    WinVisibilityCollection.Add(gr);
                }

            }
            return WinVisibilityCollection;
        }


        /// <summary>
        /// Запомнить расположение окон
        /// </summary>
        /// <param name="CW"></param>
        /// <param name="Win"></param>
        internal static void WinVisibleSettingsSet(ClientWindow CW, List<Grid> Win)
        {
            //System.Drawing.Point point = new System.Drawing.Point(); 
            //foreach (var gr in Win)
            //{
            //    switch (gr.Name)
            //    {
            //        case "_Indictive":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._Indictive));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._Indictive));
            //            Properties.Settings.Default.LTV = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_Investment":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._Investment));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._Investment));
            //            Properties.Settings.Default.InvestDeta = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_Chart":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._Chart));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._Chart));
            //            Properties.Settings.Default.ChartDeta = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_RecomPort":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._RecomPort));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._RecomPort));
            //            Properties.Settings.Default.RecomendPort = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_FondSummary":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._FondSummary));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._FondSummary));
            //            Properties.Settings.Default.FundSumm = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_Details":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._Details));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._Details));
            //            Properties.Settings.Default.Details = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_Current":
            //            point.X = Convert.ToInt32(Canvas.GetLeft(CW._Current));
            //            point.Y = Convert.ToInt32(Canvas.GetTop(CW._Current));
            //            Properties.Settings.Default.CurrPort = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_Library":
            //            //point.X = Convert.ToInt32(Canvas.GetLeft(CW._Library));
            //            //point.Y = Convert.ToInt32(Canvas.GetTop(CW._Library));
            //            Properties.Settings.Default.Library = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_RiscStart":
            //            //point.X = Convert.ToInt32(Canvas.GetLeft(CW._RiscStart));
            //            //point.Y = Convert.ToInt32(Canvas.GetTop(CW._RiscStart));
            //            Properties.Settings.Default.StartRisk = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_RiscHistory":
            //            //point.X = Convert.ToInt32(Canvas.GetLeft(CW._RiscHistory));
            //            //point.Y = Convert.ToInt32(Canvas.GetTop(CW._RiscHistory));
            //            Properties.Settings.Default.HistoryRisk = new System.Drawing.Point(point.X, point.Y);
            //            break;
            //        case "_Tasks":
            //            //point.X = Convert.ToInt32(Canvas.GetLeft(CW._Tasks));
            //            //point.Y = Convert.ToInt32(Canvas.GetTop(CW._Tasks));
            //            Properties.Settings.Default.Task = new System.Drawing.Point(point.X, point.Y);
            //            break;     
            //    }
            //    Properties.Settings.Default.Save();
            //}
        }
        /// <summary>
        /// Установка окон в позиции прошлого сеанса
        /// </summary>
        /// <param name="Window"></param>
        internal static void SetWinVisible(ClientWindow Window)
        {

            //if (Properties.Settings.Default.LTV != new System.Drawing.Point(0, 0))
            //{
            //    Window.Indictive.IsChecked = true;
            //    Canvas.SetLeft(Window._Indictive, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._Indictive, Properties.Settings.Default.Setting.Y);
            //}

            //if (Properties.Settings.Default.InvestDeta != new System.Drawing.Point(0, 0))
            //{
            //    Window.Investment.IsChecked = true;
            //    Canvas.SetLeft(Window._Investment, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._Investment, Properties.Settings.Default.Setting.Y);
            //}

            //if (Properties.Settings.Default.ChartDeta != new System.Drawing.Point(0, 0))
            //{
            //    Window.Chart.IsChecked = true;
            //    Canvas.SetLeft(Window._Chart, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._Chart, Properties.Settings.Default.Setting.Y);
            //}

            //if (Properties.Settings.Default.RecomendPort != new System.Drawing.Point(0, 0))
            //{
            //    Window.RecomPort.IsChecked = true;
            //    Canvas.SetLeft(Window._RecomPort, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._RecomPort, Properties.Settings.Default.Setting.Y);
            //}
            //if (Properties.Settings.Default.FundSumm != new System.Drawing.Point(0, 0))
            //{
            //    Window.FondSummary.IsChecked = true;
            //    Canvas.SetLeft(Window._FondSummary, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._FondSummary, Properties.Settings.Default.Setting.Y);
            //}
            //if (Properties.Settings.Default.Details != new System.Drawing.Point(0, 0))
            //{
            //    Window.Settings.IsChecked = true;
            //    Canvas.SetLeft(Window._Details, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._Details, Properties.Settings.Default.Setting.Y);
            //}

            //if (Properties.Settings.Default.CurrPort != new System.Drawing.Point(0, 0))
            //{
            //    Window.Current.IsChecked = true;
            //    Canvas.SetLeft(Window._Current, Properties.Settings.Default.Setting.X);
            //    Canvas.SetTop(Window._Current, Properties.Settings.Default.Setting.Y);
            //}
            //if (Properties.Settings.Default.Library != new System.Drawing.Point(0, 0))
            //{
            //    //Window.Library.IsChecked = true;
            //    //Canvas.SetLeft(Window._Library, Properties.Settings.Default.Setting.X);
            //    //Canvas.SetTop(Window._Library, Properties.Settings.Default.Setting.Y);
            //}
            //if (Properties.Settings.Default.StartRisk != new System.Drawing.Point(0, 0))
            //{
            //    Window.RiscStart.IsChecked = true;
            //    //Canvas.SetLeft(Window._RiscStart, Properties.Settings.Default.Setting.X);
            //    //Canvas.SetTop(Window._RiscStart, Properties.Settings.Default.Setting.Y);
            //}

            //if (Properties.Settings.Default.HistoryRisk != new System.Drawing.Point(0, 0))
            //{
            //    Window.RiscHistory.IsChecked = true;
            //    //Canvas.SetLeft(Window._RiscHistory, Properties.Settings.Default.Setting.X);
            //    //Canvas.SetTop(Window._RiscHistory, Properties.Settings.Default.Setting.Y);
            //}

            //if (Properties.Settings.Default.Task != new System.Drawing.Point(0, 0))
            //{
            //    Window.Tasks.IsChecked = true;
            //    //Canvas.SetLeft(Window._Tasks, Properties.Settings.Default.Setting.X);
            //    //Canvas.SetTop(Window._Tasks, Properties.Settings.Default.Setting.Y);
            //}

        }


    }
}
