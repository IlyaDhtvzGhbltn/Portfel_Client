using Custodian.InterfaceService;
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
using System.Windows.Shapes;

namespace Custodian
{
    /// <summary>
    /// Логика взаимодействия для Change_PRI.xaml
    /// </summary>
    public partial class Change_PRI : Window
    {
        public Change_PRI()
        {
            InitializeComponent();
        }
        public bool ConfirmN { get; set; }

        public Change_PRI(string risc)
        {
            InitializeComponent();
            PRI.Content = risc;
            LargeText.Text = GetDescription(risc);
        }
        private static string GetDescription(string risc)
        {
            string description = string.Empty;
            switch (risc)
            {
                case "P1" :
                    description = @"Risk profile : Safety. 
RT: You prefer investments with negligible price
movements which can normally be sold within a week
or promise to repay what you invest within a year.
IO: This investor rating is suitable for investors that aim
to protect capital and accept returns in line with savings
accounts. 
PRI : Very Low.
Description : Negligible risk of loss and high certainty of being able
to obtain a price at which the product can be
liquidated daily.
";
                    break;
                case "P2":
                    description = @"Risk profile : Conservative.
RT: You can tolerate investments with limited
negative price movements which can normally be sold
within a week for a price that is close to the recent
market average.
IO: This investor rating is suitable for investors that aim
primarily for regular income returns along with some
capital appreciation as a secondary option.
PRI : Low.
Description : Some risk of loss reasonably high certainty of being
able to obtain a price at which the product can be
liquidated quickly.";
                    break;
                case "P3":
                    description = @"Risk profile : Moderate.
RT: You can tolerate investments with moderate
negative price movements which can normally be sold
within a week for a price that is close to the recent
market average.
IO: This investor rating is suitable for investors that aim
for both regular income returns and capital
appreciation.
PRI : Moderate.
Description : Material risk of loss associated with fairly volatile
markets, mitigated by reasonably high certainty of
being able to obtain a price at which the product can
be liquidated quickly under normal market
conditions.";
                    break;
                case "P4":
                    description = @"RT: Aggressive.
RT: You can tolerate investments with substantial
negative price movements that may have a small risk of
losing their entire value and may be difficult to sell or
may only be sold at a price below the recent market
average.
IO: This investor rating is suitable for investors that aim
primarily for capital appreciation and no or little regular
income returns.
PRI :  Moderately High.
Description : Significant risk of loss associated with higher volatility
markets, the possibility of material event risks such as
extreme market price changes, greater risk of
corporate failure, and erratic liquidity conditions
mitigated by reasonable certainty of being able to
obtain a price at which the product can be liquidated
within a reasonable timeframe under normal market
conditions.";
                    break;
                case "P5":
                    description = @"RT: Very Aggressive.
RT: You can tolerate investments with substantial
negative price movements that may have a small risk of
losing their entire value and may be difficult to sell or
may only be sold at a price below the recent market
average.
IO: This investor rating is suitable for investors that aim
primarily for capital appreciation and no or little regular
income returns.
PRI :  High.
Description : Very significant risk of loss associated with strategy
and event risks, erratic price and liquidity conditions
and/or products with extended redemptions terms.";
                    break;
                case "P6":
                    description = @"RT: Specialized Investing.
RT: You can tolerate investments with substantial
negative price movements which may have a significant
risk of losing their entire value and may be difficult or
impossible to sell over an extended period.
IO: This investor rating is suitable for investors that seek
aggressive capital appreciation over time with
investments that may require an extended period to
liquidate
PRI :  Very High.
Description : Subject to high event risk, material
Uncertainty on the realizable value of assets and lack
of redemption rights, therefore very significant risk of
loss in the event of a forced sale.";
                    break;
            }



            return description;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Agree_Click(object sender, RoutedEventArgs e)
        {
            ConfirmN = true;
            this.Close();
        }

        private void GetMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            DownloadFromFTP PRIdownload = new DownloadFromFTP();
            PRIdownload.DownloadFile("ftp://cgaaf_ftp@castle-familyoffice.com/Documents/BrochuresClient/%7CInvestment%20Risk%20Notice.pdf", "List of Possible Risks.pdf");
        }
    }
}
