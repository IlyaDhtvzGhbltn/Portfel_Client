using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using model = Custodian.Model.VisualModels;

namespace Custodian.DALs.InterfaceService
{
    public class TagToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var txt = value as Syncfusion.UI.Xaml.Charts.LineSegment;
            model.Chart item = txt.Item as model.Chart;

            if (item.chartVal.ToString().Contains("-"))
            {
                return "pack://application:,,,/Resources/activeDown.png";
            }
            else return "pack://application:,,,/Resources/activeUp.png";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
