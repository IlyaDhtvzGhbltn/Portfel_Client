using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using static Custodian.Model.ClientReportVM;

namespace Custodian.DALs.InterfaceService
{
    class CellToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = value as ToolsInvestmentDetails;
            if (targetType != typeof(Brush))
            {
                return null;
            }
            try
            {
                if (cell.Type.ToLower() == "cash" || cell.Type.ToLower() == "transfer")
                {
                    var color = Color.FromRgb(26,26,26);
                    return new SolidColorBrush(color); 
                }
                if (cell.profit.Contains("-"))
                {
                    return Brushes.Red;
                }
                if (!cell.profit.Contains("-"))
                {
                    return Brushes.Green;
                }
            }
            catch (Exception ex) { }
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
