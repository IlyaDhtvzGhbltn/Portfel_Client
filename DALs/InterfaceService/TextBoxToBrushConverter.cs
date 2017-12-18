using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using static Custodian.Model.ClientReportVM;
using static Custodian.Model.VisualModels;

namespace Custodian.DALs.InterfaceService
{
    public class TextBoxToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush))
            {
                return null;
            }
            var txt = value as Syncfusion.UI.Xaml.Charts.LineSegment;
            Chart item = txt.Item as Chart;
            if (item.chartVal<0)
            {
                return Brushes.Red;
            }
            else
                return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
