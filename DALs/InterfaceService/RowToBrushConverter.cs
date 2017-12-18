using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Data;
using static Custodian.Model.ClientReportVM;
using static Custodian.Model.VisualModels;

namespace Custodian.DALs.InterfaceService
{
    class RowToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = value as RecomendedTable;
            if (targetType != typeof(Brush))
            {
                return null;
            }
            try
            {
                if (cell.Advice == "Hold")
                {
                    return Brushes.Orange;
                }
                else if (cell.Advice == "Sell, does not suits your Risc Profile")
                    return Brushes.Red;
                else if (cell.Advice == "Add to Portfolio")
                    return Brushes.Green;
            }
            catch (NullReferenceException) {}

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
