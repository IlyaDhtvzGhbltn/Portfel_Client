using Custodian.DALs.InterfaceService;
using Syncfusion.UI.Xaml.Charts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Custodian.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecomendPortfel.xaml
    /// </summary>
    public partial class RecomendPortfel : UserControl
    {
        public RecomendPortfel()
        {
            InitializeComponent();
            this.Loaded += (s, e) => doughnutSeries.AddListboxLegend(dLegend);
        }
    }
}
