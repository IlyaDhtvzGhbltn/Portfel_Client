using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
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
using System.Windows.Forms;
using System.Data;
using Custodian.Model;

namespace Custodian
{
    /// <summary>
    /// Логика взаимодействия для AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window
    {
        public AdministrationWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
            time.Interval = 200;
            time.Tick += new EventHandler(newTasks);
            time.Start();
        }
        DataTable newTasksTable = new DataTable();
        int currTasks = 0;

        private void newTasks(object sender, System.EventArgs e)
        {
            newTasksTable = adminDAL.GetOnlyNewTasks();
            int row = newTasksTable.Rows.Count;
            if (currTasks != row)
            {
                int rasniza = (currTasks - row);
                currTasks = newTasksTable.Rows.Count;
                BOX.ShowInformation("You Have are "+ rasniza.ToString() +" new Tasks!");
            }

        }

        #region ИНФОРМАЦИЯ В ШАПКЕ ПОД ПАНЕЛЬЮ МЕНЮ
        // ---------------------ИМЯ АДМИНИСТРАТОРА ......................
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string AdminName = Storage.datasetAdmin.Tables[0].Rows[0][2].ToString() + " " + Storage.datasetAdmin.Tables[0].Rows[0][1].ToString();
                lbl_Name.Content = "Signed in : " + AdminName;
            }
            catch (Exception ex)
            {
                BOX.ShowError(ex.Message, ex.Source);
            }
            Thread ValueCursParce = new Thread(Parse);
            ValueCursParce.Start();

            adminDAL.StartSession(lbl_Name.Content.ToString());
            Storage.EnteredUserID = Storage.datasetAdmin.Tables["AdminInfo"].Rows[0][0].ToString();
        }
        static List<decimal> ValuesTOUSD = new List<decimal>();
        static BrushConverter bc = new BrushConverter();
        Brush red = (Brush)bc.ConvertFrom("#ff0000");
        Brush green = (Brush)bc.ConvertFrom("#006600");

        private void Parse()
        {
            try
            {
                Parser pars = new Parser();
                pars.GetValuesFromSber();

                List<decimal> _values = Parser.Values;
                string GBPtoUSD = String.Format("1 GBP = " + "{0:0.00}", _values[0] / _values[1]);
                ValuesTOUSD.Add(Convert.ToDecimal(_values[0] / _values[1]));

                string EURtoUSD = String.Format("1 EUR = " + "{0:0.00}", _values[2] / _values[1]);
                ValuesTOUSD.Add(Convert.ToDecimal(_values[2] / _values[1]));

                string SGDtoUSD = String.Format("1 SGD = " + "{0:0.00}", _values[3] / _values[1]);
                ValuesTOUSD.Add(Convert.ToDecimal(_values[3] / _values[1]));

                string AUDtoUSD = String.Format("1 SGD = " + "{0:0.00}", _values[4] / _values[1]);
                ValuesTOUSD.Add(Convert.ToDecimal(_values[4] / _values[1]));

                Dispatcher.BeginInvoke
                (System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate ()
                {
                    ParseCurses.Content = GBPtoUSD + " USD \r\n" + EURtoUSD + " USD \r\n" + SGDtoUSD + " USD\r\n" + AUDtoUSD + "USD" ;
                }
                );
            }
            catch (Exception ex)
            {

                BOX.ShowError(ex.Message, ex.Source);
            }
        }
        #endregion 

        #region ДОБАВЛЕНИЕ НОВОГО КЛИЕНТА
        
        private void AddNewClient(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/AddNewClient.xaml",UriKind.Relative);
        }
        #endregion

        /// <summary>
        /// Фрейм с настройками админа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminSettings(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/AdminAccountSettins.xaml", UriKind.Relative);
        }

        private void IsinQuote_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ISINQuote.xaml", UriKind.Relative);
        }

        private void PublickLubrary(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/PublicDocumentAdd.xaml", UriKind.Relative); 
        }

        private void ConvertOperation(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/NewConvertOperation.xaml", UriKind.Relative);
        }

        private void AddCash(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/AddCashAccount.xaml", UriKind.Relative);
        }

        private void GotoCommissinsForm(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ShowAllOperation_AddComissions.xaml", UriKind.Relative);
        }
        /// <summary>
        /// Фрейм с задачами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TasksFrame_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/AdminCanTaskSee.xaml", UriKind.Relative);
        }
        private void ChatClick(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ChatAdmin_Manager.xaml", UriKind.Relative);

        }
        #region ПОКАЗАТЬ ВСЕХ КЛИЕНТОВ
        private void AllclientShow(object sender, RoutedEventArgs e)
        {
            AllClientsTable.ItemsSource = adminDAL.ShowAllClient().DefaultView;
            AllClientsTable.Columns[0].Visibility = Visibility.Hidden;
        }
        #endregion

        #region ВЫБОР ТИПА ОПЕРАЦИИ BYU-SALE-TRANSVER-funding- withdraw

        private void BuyOperation(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/NewByuOperations.xaml", UriKind.Relative);
        }

        private void SaleOperation(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/NewSaleOperation.xaml", UriKind.Relative);
        }

        private void TransferOperation(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/NewTransferOperations.xaml", UriKind.Relative);
        }

        private void FundingOperation(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/NewFundingOperations.xaml", UriKind.Relative);
        }

        private void WithdrawOperation(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/ClientOperations/newWithdrawOperation.xaml", UriKind.Relative);
        }

        private void PrivateDocumentAdd(object sender, RoutedEventArgs e)
        {
            AdminFrame.Source = new Uri("Pages/Admin/PrivateDocumentAdd.xaml", UriKind.Relative);
        }
        #endregion

        #region ВЫХОД
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            exit(e);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            exit(e);
        }
        private void exit(EventArgs e)
        {
            if (BOX.ShowQuestion("Are you wishct to exit now?", "Custodian") == MessageBoxResult.Yes)
            {
                Storage.datasetAdmin.Tables.Clear();
                MainWindow M = new MainWindow();
                this.Hide();
                M.Show();
                adminDAL.EndSession();
            }

        }
        private void exit(System.ComponentModel.CancelEventArgs e)
        {
            if (BOX.ShowQuestion("Are you wishct to exit now?","Custodian") == MessageBoxResult.Yes)
            {
                Storage.datasetAdmin.Tables.Clear();
                MainWindow M = new MainWindow();
                this.Hide();
                M.Show();
                adminDAL.EndSession();
            }
            else
            {
                e.Cancel = true;
            }
        }














        #endregion

   
    }
}
