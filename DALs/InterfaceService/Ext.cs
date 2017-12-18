using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

/* Глобальные методы расширения */

namespace Custodian.DALs.InterfaceService
{
    public static class Ext
    {
        internal static Dictionary<object, System.Windows.Media.Brush> CurPortBrush = new Dictionary<object, System.Windows.Media.Brush>();

        public static void AddListboxLegend(this ChartSeries series, ItemsControl targetListbox)
        {
            var source = series.ItemsSource as IEnumerable<object>;
            if (source == null) return;
            var colors = series.ColorModel?.CustomBrushes;
            if (colors == null) return;
            int i = -1;
            var max = colors.Count;
            var dic = source.ToDictionary(x => x, x => colors[++i % max]);
            targetListbox.ItemsSource = dic;

            if (targetListbox.Name == "iLegend")
                CurPortBrush = dic;
        }
        public static decimal ListElementSumm(this List<decimal> Collection )
        {
            decimal summ = 0;
            foreach (var item in Collection)
            {
                summ += item;
            }
            return summ;
        } 

    }


}
