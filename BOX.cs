using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custodian
{
    class BOX
    {
        internal static void ShowInformation(string messageText)
        {
            MessageBox.Show(messageText, "Custodian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void ShowError(string messageText, string messageCaption)
        {
            MessageBox.Show(messageText, messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
