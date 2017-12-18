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

namespace Custodian.Dynamics_Controls
{
    /// <summary>
    /// Логика взаимодействия для FilesNameControll.xaml
    /// </summary>
    public partial class FilesNameControll : UserControl
    {
        public FilesNameControll()
        {
            InitializeComponent();
        }
        public FilesNameControll(string elementname)
        {
            InitializeComponent();
            Cont = elementname;
            filename.Content = Cont;
        }
        public string Cont { get; set; }

    }
}
