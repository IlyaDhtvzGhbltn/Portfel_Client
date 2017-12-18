using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Custodian.Model;
using Syncfusion.UI.Xaml.Charts;
using Custodian.DALs.InterfaceService;

namespace Custodian.Pages
{
    partial class Current_PortfelVm
    {
        public Current_PortfelVm()
        {
            InitializeComponent();
            DataContext = MainWindow.reportVM;
            this.Loaded += (s, e) => sInner.AddListboxLegend(iLegend);
        }

    }


}
