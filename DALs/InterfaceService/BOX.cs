using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Custodian
{
    class BOX //: System.Windows.Forms.MessageBox
    {

    
        internal static void ShowInformation(string messageText)
        {
            ShowWind window = new ShowWind(messageText);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }
        internal static bool ShowInformation(int risclevel)
        {
            string PRI = "P" + risclevel;
            Change_PRI window = new Change_PRI(PRI);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
            bool ret = window.ConfirmN;
            return ret;
        }


        internal static void ShowError(string messageText, string messageCaption)
        {
            ShowWind window = new ShowWind(messageText);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
        }


        internal static bool ShowQuestion(string mess, string header)
        {
            ShowWind window = new ShowWind(mess, header);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.ShowDialog();
            bool ret = (bool)window.DialogResult;
            return ret;

        }
    }
}
