using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Custodian.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для ISINQuote.xaml
    /// </summary>
    public partial class ISINQuote : Page
    {
        public ISINQuote()
        {
            InitializeComponent();
        }
        #region ПРОСМОТРЕТЬ ТАБЛИЦУ QUOTE ИЛИ ПОМЕНЯТЬ ЕЁ

        private void InsertORUpdateISIN(object sender, RoutedEventArgs e)
        {
            adminDAL.GetISINTable();
            DGIsinQuote.ItemsSource = Storage.datasetAdmin.Tables["ISIN"].DefaultView;
        }
        #endregion


        #region СОХРАНИТЬ ИЗМЕНЕНИЯ и ВСТАВИТЬ НОВЫЕ СТРОКИ В ISIN
        private void SaveISINChanges(object sender, RoutedEventArgs e)
        {
            adminDAL.UpdateISIN();
            adminDAL.GetISINTable();
            DGIsinQuote.ItemsSource = Storage.datasetAdmin.Tables["ISIN"].DefaultView;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            adminDAL.InsertNewISIN(ISIN.Text, Quote.Text, TitleISIN.Text);
        }
        #endregion
        #region Поиск по таблице ISIN
        private void ISINsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                for (int i = 0; i < DGIsinQuote.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)DGIsinQuote.ItemContainerGenerator.ContainerFromIndex(i);
                    TextBlock cellContent = DGIsinQuote.Columns[0].GetCellContent(row) as TextBlock;
                    if (cellContent != null && cellContent.Text.Equals(ISINsearch.Text))
                    {
                        object item = DGIsinQuote.Items[i];
                        DGIsinQuote.SelectedItem = item;
                        DGIsinQuote.ScrollIntoView(item);
                        row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        break;
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion
    }
}
