using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Custodian
{
    class BOX
    {
        internal static void ShowInformation(string messageText)
        {
            System.Windows.Forms.MessageBox.Show(messageText, "Custodian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void ShowError(string messageText, string messageCaption)
        {
            System.Windows.Forms.MessageBox.Show(messageText, messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        internal static MessageBoxResult ShowQuestion(string mess, string header)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show(mess, header, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result;
        }
    }
}
