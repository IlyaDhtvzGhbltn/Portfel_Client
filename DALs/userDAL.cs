using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using Custodian.InterfaceService;
using System.Threading;
using Custodian.DALs.InterfaceService;
using System.Data.SqlTypes;

namespace Custodian
{
    #region
    class userDAL
    {

        private static bool ErrorMessageCount = false;
        static string ConnectionString = "User Id=cgaaf_user; Password=Gxk!-QWH}]@%; Host=castle-familyoffice.com;Database=cgaaf_db;port=3306;Charset=utf8;connection timeout = 15";
        
        #region основная форма
        /// <summary>
        /// Получить таблицу с данными клиента
        /// </summary>
        /// <param name="log">Логин</param>
        /// <param name="pass">Пароль</param>
        /// <returns></returns>
        internal static DataTable GetClientInfo(string log, string pass)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"select * from order_holders where `login` = @login and `password` = @pass;";
                
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@login", log);
                comm.Parameters.AddWithValue("@pass", pass);
                adapter.SelectCommand = comm;
                try
                {
                    DataTable table = Storage.datasetKlient.Tables.Add("ClientInfo");
                    conn.Open();
                    adapter.Fill(table);
                    ClientFundingSumm(table);
                    ClientCashAllPluss(table.Rows[0][6].ToString()); //Передает идентификатор клиента (номер договора)  в ClientCashAllPluss
                    return table;
                }
                catch (DuplicateNameException)
                {
                    Storage.datasetKlient.Tables.Remove("ClientInfo");
                    GetClientInfo(log, pass);
                }
                catch (MySqlException) { BOX.ShowInformation("Internet Connection Failed"); }
                catch (Exception ex)
                {
                    //BOX.ShowError(er.Message, er.Source);
                    Logger.WriteLog(ex.Message, ex.Source);
                    return null;
                }
            }
            return null;
        }

 
        private static void ClientCashAllPluss(string ID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"SELECT sum(Sum) FROM activesfunding where `OrderNumber`=@_id;";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@_id", ID);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Storage.AllPluss = reader.GetDecimal(0);
                        }
                    }
                }
                catch (SqlNullValueException) { }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }

            }
        }
 

        private static void ClientFundingSumm(DataTable client)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "select sum(Sum) from activesfunding where `Order` = @Order;";
                string ID_order = client.Rows[0][6].ToString();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@Order", ID_order);
                try
                {
                    conn.Open();
                }
                catch (SqlNullValueException) { }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }


            }


        } 


        /// <summary>
        /// Сохраняет новый пароль пользователя
        /// </summary>
        /// <param name="order">Номер договора</param>
        /// <param name="nPass">Новый пароль</param>
        internal static void SaveNewKlientPass(string order, string nPass)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string Query = "update orderholders set `password` = @newPass where `order` = @Korder;";
                MySqlCommand comm = new MySqlCommand(Query, conn);
                comm.Parameters.AddWithValue("@Korder", order);
                comm.Parameters.AddWithValue("@newPass", Hash.GetHash(nPass));
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    BOX.ShowInformation("Your password has been successfully updated.");
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }
            }
        }
        /// <summary>
        /// Получает ТЕКУЩЕЕ у клиента количество бумаг в - Storage.CURRENTCountforISIN и ISIN'ы этих бумаг в - Storage.CURRENTisin
        /// </summary>
        /// <param name="order">Номер договора</param>
        internal static void GetIsinQouteCURRENTKlient(string order) 
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query
                         = $@"SET sql_mode = ''; SELECT  `ISIN`, sum(col1)-coalesce(sum(col2),0), `Money`, `Value`
                           FROM 
                           ( 
                           SELECT `ISIN`,`value`, `money`,  `count_paper` AS col1, 0 AS col2 FROM actives_buy where order_client = '{order}' 
                           UNION all 
                           SELECT `Isin`, 0, 0, 0 AS col1, `count_paper` AS col2 FROM actives_sale where order_client = '{order}' )X 
                           GROUP BY `ISIN`";
                MySqlCommand comm = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(1) != "0,00")
                            {
                                Storage.CURRENTisin.Add(reader.GetString(0));
                                Storage.BuyPrice.Add(reader.GetDecimal(2));
                                Storage.valueActive.Add(reader.GetString(3));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }

            }

        }
        /// <summary>
        /// Получает сумму SAXO + IB и записывает в Storage.SAXO_IB
        /// </summary>
        /// <param name="order">Номер договора</param>
        internal static void GetSaxoIB(string order)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"SELECT sum(transfer_summ) FROM actives_transfer WHERE order_client= @Norder";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@Norder", order);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            Storage.SAXO_IB = reader.GetDecimal(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }
            }
        }

        /// <summary>
        /// Добавляет строку с результатами риск-тестирования в БД
        /// </summary>
        /// <param name="order">Номер договора клиента</param>
        /// <param name="result">Результат тестирования (пример. -'1')</param>
        internal static void AddRiskTest(string order, int result)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"insert into risk_test_results values ('{order}', {result}, now())";
                MySqlCommand comm = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }

            }
        }

        /// <summary>
        /// Возвращает таблицу с заданиями которые клиент когда либо давал
        /// </summary>
        /// <param name="order">Номер договора клиента</param>
        /// <returns></returns>
        internal static DataTable GetAllTasks(string order)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"select `id`, `data_in`, `data_out`, `status`,`comment` from tasks where `client_order` = '{order}'";
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query,conn);
                DataTable table = new DataTable();
                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                    return null;
                }
            }
        }

        internal static int AddTask(string clientOrder, string admin_managerID, int byu=0, int sale = 0, int transf = 0, int convert = 0, int inflow = 0, int outflow = 0)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                int indexreturn = 0;
                string query = $"insert into `tasks` (`id`,`client_order`, `admin_manager_ID`, `data_in`, `status`, `buy`, `sale`, `transfer`, `converter`, `inflow`, `outflow`) " +
                    $"values (null,'{clientOrder}','{admin_managerID}',now(),'Received', '{byu}', '{sale}','{transf}','{convert}','{inflow}', '{outflow}');";
                MySqlCommand comm = new MySqlCommand(query, conn);
                string queryResult = $"select `id` from `tasks` where `client_order`= '{clientOrder}' ORDER by data_in DESC LIMIT 1";
                MySqlCommand commresult = new MySqlCommand(queryResult, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    MySqlDataReader reader = commresult.ExecuteReader();
                    while (reader.Read())
                    {
                        indexreturn = reader.GetInt32(0);
                    }

                    return indexreturn;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                    return -1;
                }
            }
        }


        internal static void AddDocumentTask(string number, string mainDoc, string ftpMain)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {

                string queryMain = $"insert into `tasks_documents` values('{number}','{mainDoc}','{ftpMain}');";
                MySqlCommand comm = new MySqlCommand(queryMain, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }
            }
        }


        internal static void AddDocumentTask(string number, string mainDoc, string TermDoc, string ftpMain, string ftpTerm)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                
                string queryMain = $"insert into `tasks_documents` values('{number}','{mainDoc}','{ftpMain}');";
                string queryTerm = $"insert into `tasks_documents` values('{number}','{TermDoc}','{ftpTerm}');";

                string query = queryMain + queryTerm;
                MySqlCommand comm = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }

            }
        }


        internal static DataTable GetRiskTestResult(string order)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"SELECT * FROM risk_test_results where `order_client`='{order}';";
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                    return null;
                }
            }

        }
        #endregion

        #region Acces
        /// <summary>
        /// Получает текущий статус жесткого диска
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal int GetHardwareData(string HddID)
        {
            int result = 0;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"SELECT `hardware_acces`.`status` FROM `hardware_acces` WHERE hardware_id = '{HddID}';";
                try
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = 1;
                        while (reader.Read())
                        {
                            result += reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }
            }
            return result;
        }

        /// <summary>
        /// Устанавливает 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="hardware"></param>
        internal void SetFalseHardvareAcces(string hardware, string order)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"INSERT INTO hardware_acces(`hardware_id`, `order_client`, `status`) VALUES ('{hardware}','{order}',0)";
                try
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    conn.Open();
                    comm.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }
            }

        }

        #endregion

        #region Отправка сообщения об успешном логировании/выходе

        public void InsertLoginEvent(string PCName, string Order)
        {
            string query = $"INSERT INTO history_of_visits(PC_name, order_client, enter_date_time) VALUES('{PCName}', '{Order}', NOW())";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }
            }
        }


        #endregion

        #region ДЛЯ ЧАТИКА
        internal static DataTable AdviserInfo(string numberAdviser)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"select `id`,`first_name`,`last_name`,`e_mail` from administrators where `id` = '{numberAdviser}'";
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                DataTable table = new DataTable();
                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                    return null;
                }

            }
        }
        /// <summary>
        /// ОТОСЛАТЬ СООБЩЕНИЕ В БД и НУЖНОМУ АДРЕСАТУ
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="text"></param>
        internal static void SendMail(string from, string to, string text, string ftppath = null)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                
                string query = $"insert into messengers (`from`, `to`, `text`, `message_date`, `path`) value('{from}','{to}','{text}',now(),'{ftppath}')";
                MySqlCommand comm = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex.Message, ex.Source);
                }

            }
        }
       
        public static DataTable chatTable = new DataTable();
        internal async static void ReturnChat(string from, string to)
        {
            try
            {
                await GetDataChat(from, to);
            }
            catch (TaskCanceledException) { }
        }

        private static Task GetDataChat(string from, string to)
        {
            return Task.Run(()=>
            {
              
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = $"SELECT  `text`,`message_date`,`from`,`path` FROM messengers WHERE(`from` = '{from}' and `to` = '{to}') or (`from` = '{to}' and `to` = '{from}') or (`From` = 'System' and `to`='{from}') LIMIT 100";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable table = new DataTable();
                    try
                    {
                        
                        conn.Open();
                        adapter.Fill(table);
                        chatTable = table;
                    }
                    catch (Exception ex)
                    {
                            System.Windows.Application.Current.Dispatcher.Invoke(()=>
                            {
                                if (ErrorMessageCount == false)
                                {
                                    ErrorMessageCount = true;
                                    BOX.ShowError("Internet Connect Failed!", "Error");
                                }
                            });
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                    return null;
                }
            });
        }
        #endregion

        #region ПОДКЛАСС
        /// <summary>
        /// Подкласс для заполнения формы ПОРТФЕЛЬ и ОТЧЕТ клиента
        /// </summary>
        internal static class GetInvestmentDetails
        {
            static string ConnectionString =
                "User Id=cgaaf_user; Password=Gxk!-QWH}]@%; Host=castle-familyoffice.com;Database=cgaaf_db;port=3306;Charset=utf8;connection timeout = 15";
        

            //"User Id=root;Password=root;Host=localhost;Database=custodian; port=3306;Charset=utf8;connection timeout = 15";
            //User Id=ankoworu_test-01;Password = Gxk!-QWH}]@%;Host=208.88.226.248;Database=ankoworu_test-01;port=3306;Charset=utf8;connection timeout = 15

            /// <summary>
            /// Возвращает 2 строки -Saxo + IB c колонкой +сумма всех трансферов+
            /// </summary>
            /// <param name="order"></param>
            internal static DataTable GetInvestmentSaxoIb(string order)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query =   $@"SET sql_mode = '';
select  `platform_type`,`value`, sum(transfer_summ),`get_inst_date` from actives_transfer where `order_client`='{order}' group by `platform_type`";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }

            }


            /// <summary>
            /// Возвращает таблицу активов (куплено минус продано)
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            /// 
            internal static DataTable CurrActives(string order)
            {
                string query = $@"SET sql_mode = '';
SELECT  `ISIN`,`aq_price`, sum(col1)-coalesce(sum(col2),0), SUM(money), `value`,`get_inst_date`, `title` ,`type`                
FROM                        
(                        
    SELECT `ISIN`, `type`,`title`,`value`,`aq_price`,`get_inst_date`, `money`, `count_paper` AS col1, 0 AS col2 
    FROM actives_buy where order_client = '{order}'                  
    UNION all                      
    SELECT `ISIN`, 0,0,0, 0, 0,0, 0 AS col1, `count_paper` AS col2 FROM actives_sale where order_client = '{order}'
)X                 
GROUP BY `ISIN`
UNION all 
SELECT ISIN, summ, sum(col1)-coalesce(sum(col2),0),  summ, value, regist_inst_date, title, type 
FROM 
(
    SELECT ISIN, summ, `count_paper` AS col1, 0 AS col2,  value, regist_inst_date,  'cash' as title, type  
    FROM 
    actives_inflow WHERE actives_inflow.order_client='{order}'
    UNION all 
    SELECT 
    Isin,0, 0 AS col1, `count_paper` AS col2  , 0, 0, 0, 0
    FROM
    actives_outflow WHERE actives_outflow.order_client = '{order}'
)x GROUP BY ISIN";

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand comm = new MySqlCommand(query,conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable table = new DataTable();
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }
            /// <summary>
            /// Возвращает подробную историю (все продажи + все покупки) операций по ISIN в одной таблице
            /// </summary>
            /// <param name="Order"></param>
            /// <param name="isin"></param>
            /// <returns></returns>
            internal static DataTable GetByu_Sale_ActivesTotal(string Order, string isin)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    DataTable Actives = new DataTable();
                    string quote = $@"SELECT * from
                                            (
                                            select
                                            'Byu Operation ',`title`,`ISIN`,`value`,`count_paper`,`aq_price`,`get_inst_date`
                                            FROM actives_buy 
                                            where `order_client` = '{Order}' and `ISIN` = '{isin}'
                                            union
                                            Select
                                            'Sale Operation ',`title`,`ISIN`,`value`,`count_paper`,`aq_value`,`get_inst_date` 
                                            FROM actives_sale 
                                            where `order_client` =  '{Order}' and `ISIN` = '{isin}'
                                            ) b";
                    MySqlCommand comm = new MySqlCommand(quote, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    try
                    {
                        conn.Open();
                        adapter.Fill(Actives);
                        return Actives;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                    return null;
                }
            }

            /// <summary>
            /// Возврашает DataTable сподробной информацией об операциях трансфера в SAXo IB
            /// </summary>
            /// <param name="order"></param>
            /// <param name="S_I"></param>
            /// <returns></returns>
            internal static DataTable GetSaxo_IB_ActivesTotal(string order, string S_I)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = @"SELECT 
                                            'Transfer',`platform_type`,`transfer_summ`,`get_inst_date`,`value`
                                            FROM actives_transfer
                                            where order_client=@_order and platform_type=@_type";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.Parameters.AddWithValue("@_order", order);
                    comm.Parameters.AddWithValue("@_type", S_I);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    try
                    {
                        conn.Open();
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }

            /// <summary>
            /// Получить все операции Inflow
            /// </summary>
            /// <param name="order"></param>
            internal static DataTable GetInflowDetails(string order)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = $@"SELECT `type`,`summ`,`ISIN`,`security`,`summ`,`aq_price`,`count_paper`,`regist_inst_date`  FROM `actives_inflow` WHERE `order_client`= '{order}' ";

                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable table = new DataTable();
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }
        
            /// <summary>
            /// Все операции Outflow
            /// </summary>
            /// <param name="order"></param>
            internal static DataTable OutFlow(string order)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = @"SELECT `outflow_summ`, `date_operation`
                                         FROM actives_outflow
                                         where `order_client` = @_order";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.Parameters.AddWithValue("@_order", order);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    var table = new DataTable();
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        return table;

                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }


            /// <summary>
            /// Возвращает таблицу с историей риск-тестирования
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            internal static DataTable GetHistory(string order)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = $"SELECT * FROM risk_test_results where order_client = '{order}';";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    try
                    {
                        conn.Open();
                        DataTable table = Storage.datasetKlient.Tables.Add("RiscInfo");

                        adapter.Fill(table);
                        return table;

                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }
            /// <summary>
            /// Возвращает таблицу всех операций по клиенту - выписку
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            internal static DataTable StatementOperation(string order, DateTime from, DateTime  to)
            {
                string datefrom = SQLDateConverter.DateConverer(from);
                string dateto = SQLDateConverter.DateConverer(to.AddDays(1));
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = $@"SELECT * FROM (SELECT 'Buy Operation', `Isin`,`value`,`money`,`get_inst_date`, actives_buy.aq_price, actives_buy.count_paper 
FROM `actives_buy` WHERE `order_client`='{order}'     
and `actives_buy`.`regist_inst_date` >= '{datefrom} ' and `actives_buy`.`regist_inst_date` <= '{dateto}'           
      UNION  ALL

SELECT
  			        'Divident ', 
					dividends_history.ISIN,
					dividends_history.currency, 
                    dividends.cash,
                    dividends_history.date,
					dividends_history.price_for_one_asset, 
                    dividends_history.ticket
    				from dividends_history
					JOIN dividends on
    				dividends.id_dividends_history = dividends_history.id WHERE dividends.order_client = '{order}'
                    and  dividends_history.date >= '{datefrom}' and dividends_history.date <= '{dateto}'
                    UNION ALL

               SELECT  'Sale Operation', `ISIN`,`value`,`summ`,`regist_inst_date`,  actives_sale.aq_value, actives_sale.count_paper FROM `actives_sale` WHERE `order_client`='{order}'  
and  actives_sale.get_inst_date  >= '{datefrom}' and actives_sale.get_inst_date <= '{dateto} '             
    UNION  ALL


          SELECT  'Inflow Operation', `Isin`,`value`,`summ`,`regist_inst_date`, '','' FROM `actives_inflow` WHERE `order_client`='{order}'   
and `actives_inflow`.`date` >= '{datefrom} ' and `actives_inflow`.`date` <= '{dateto} '        
         UNION  ALL


               SELECT  'Transfer Operation', `platform_type`,`Value`,`transfer_summ`,`get_inst_date`,'',''  FROM `actives_transfer` WHERE `order_client`='{order}'   
and actives_transfer.get_inst_date >= '{datefrom} ' and actives_transfer.get_inst_date <= '{dateto} '             
    UNION  ALL


               SELECT  'Outflow Operation', `ISIN`,`value`, `outflow_summ`,`date_operation` ,'','' FROM `actives_outflow` WHERE `order_client`='{order}'   
and `actives_outflow`.`date_registr` >= '{datefrom} '  and `actives_outflow`.`date_registr` <= '{dateto} '               
   UNION  ALL


               SELECT  'Dealing Comission ', operation_commission.ISIN, operation_commission.cash_account_type, operation_commission.commission, operation_commission.date, '','' FROM 
`operation_commission` WHERE operation_commission.client_order = '{order}'                  and operation_commission.date >= '{datefrom} '  and operation_commission.date <= '{dateto} '                
  Union  ALL


               SELECT  'Brokerage Commission of', `operation`, `cash_account_type`,`commission`,`date`, '',''  FROM `broker_commission`  WHERE `order_client`='{order}'    
and broker_commission.date  >= '{datefrom} '  AND broker_commission.date <= '{dateto} '              
    UNION  ALL


 SELECT  'Convert Operations', CONCAT('FROM ', colfrom, ' TO ', colto), CONCAT('From ',colfrvalue), CONCAT('To ',colltovalue),`date_get_instruction`   , '',''  
from (SELECT  `value_from` as colfrom ,`value_to` as colto ,`date_create_operation`, `count_value_from` as colfrvalue,`count_value_to` as colltovalue, `date_get_instruction`  
FROM `convert_operation`  WHERE `order_client` ='{order}'                
and convert_operation.date_get_instruction >= '{datefrom} ' and convert_operation.date_get_instruction <= '{dateto} ' )y)x order by `get_inst_date`


";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }


//..........................Графики и таблицы в отчете.....................

            /// <summary>
            /// Возвращает данные для Chart Графика в отчете - Полный портфель
            /// </summary>
            /// <param name="order"></param>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            internal static Dictionary<DateTime, double> ChartInfoPortfell(string order, DateTime min, DateTime max)
            {
                string fromDate = SQLDateConverter.DateConverer(min);
                string toDate = SQLDateConverter.DateConverer(max);

                var ChartPortfell = new Dictionary<DateTime, double>();
                ChartPortfell.Add(Convert.ToDateTime("1111-11-11"), StartInflo());
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
            string query =
            $@"SELECT  paper.date,	paper.investment_bonds + paper.speculation_bonds + paper.Credit_Linked_Notes + paper.SNGC + paper.SNCC + paper.SNRS 
            + paper.Hi_cap_share + paper.emerging_markets + paper.mid_cap_share + paper.lo_cap + paper.options + paper.futures +
            paper.leveraged_ETF + paper.mutual_funds + paper.residential_properties + paper.commercial_property + paper.classics_pictures +
            paper.modern_pictures + paper.marks + paper.wine
            + 
            cash_accounts.CA_USD+ cash_accounts.CA_EUR+ cash_accounts.CA_GBP + cash_accounts.CA_SGD+cash_accounts.CA_AUD+cash_accounts.cash_allocation 
            FROM paper 
            JOIN cash_accounts on 
            paper.date = cash_accounts.date
            WHERE 
(cash_accounts.date >= '{fromDate}' and cash_accounts.date <= '{toDate}') and cash_accounts.order_client = '{order}' and paper.order  = '{order}' ORDER BY date
";

                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            ChartPortfell.Add(reader.GetDateTime(0), reader.GetDouble(1));
                        }
                    }
                    catch (System.ArgumentException) { }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                }
                return ChartPortfell;
            }

            /// <summary>
            /// Возвращает начальные Inflow Клиента - т.е. сумму всех активов которые изначально введены в фонд
            /// </summary>
            /// <returns></returns>
            public static double StartInflo()
            {
                double nullInflo = 0;
                var client = Storage.datasetKlient.Tables["ClientInfo"].Rows[0][6].ToString();
                var registrationdate = Convert.ToDateTime(Storage.datasetKlient.Tables["ClientInfo"].Rows[0][19]);
                var sqlDate = SQLDateConverter.DateConverer(registrationdate);
                var sqlDateend = SQLDateConverter.DateConverer(registrationdate.AddDays(1));

                string query = $@"SELECT Sum(actives_inflow.summ) FROM actives_inflow WHERE actives_inflow.order_client = 
                                    '{client}' AND actives_inflow.date >= '{sqlDate}' AND actives_inflow.date <= '{sqlDateend}'" ;
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader reader = comm.ExecuteReader();
                        if (!reader.IsClosed)
                        {
                            while(reader.Read())
                            nullInflo = reader.GetDouble(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                    return nullInflo;
                }

            }


            internal static double PortfelActiveInTime(DateTime date, string order)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    var _SQldate = SQLDateConverter.DateConverer(date);
                    string query = $@"SELECT  paper.investment_bonds + paper.speculation_bonds + 
            paper.Credit_Linked_Notes + paper.SNGC + paper.SNCC + paper.SNRS 
            + paper.Hi_cap_share + paper.emerging_markets + paper.mid_cap_share + paper.lo_cap + 
            paper.options + paper.futures +
            paper.leveraged_ETF + paper.mutual_funds + paper.residential_properties + 
            paper.commercial_property + paper.classics_pictures +
            paper.modern_pictures + paper.marks + paper.wine
            +
            cash_accounts.CA_USD + cash_accounts.CA_EUR + cash_accounts.CA_GBP + cash_accounts.CA_SGD + 
            cash_accounts.CA_AUD + cash_accounts.cash_allocation
            FROM paper
            JOIN cash_accounts on
            paper.date = cash_accounts.date
            WHERE
            (cash_accounts.date = '{_SQldate}') and cash_accounts.order_client = '{order}' and paper.order = '{order}' ";
                    double TotalPort = 0;
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            TotalPort = Convert.ToDouble(reader.GetString(0));
                        }
                        return TotalPort;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                    return 0.00000000001;
                }
            }
            /// <summary>
            /// Возвращает данные для Chart Графика в отчете - только один актив
            /// </summary>
            /// <param name="order"></param>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            internal  static Dictionary<DateTime, double> ChartInfoOneActive(string order, DateTime min, DateTime max, string activname)
            {
                string fromDate = SQLDateConverter.DateConverer(min);
                string toDate = SQLDateConverter.DateConverer(max);

                var ChartPortfell = new Dictionary<DateTime, double>();
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = $@"SELECT  paper.{activname} as `value`, paper.date 
                                FROM  paper 
                                WHERE  
                                (paper.date >= '{fromDate}' and paper.date <= '{toDate}') and paper.order = '{order}'  ORDER BY date";

                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        MySqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            ChartPortfell.Add(reader.GetDateTime(1), Convert.ToDouble(reader.GetDecimal(0)));
                        }
                    }
                    catch (System.ArgumentException) { }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                    return ChartPortfell;
                }
            }

            /// <summary>
            /// Возвращает исторические данные о состоянии счета на сегодня или вчера
            /// </summary>
            /// <param name="order"></param>
            /// <param name="NowDate"></param>
            /// <returns></returns>
            internal static DataTable GetToolsCurrentPrice(string order, DateTime NowDate)
            {
               // string ConnectStr = "User Id=root;Password=root;Host=localhost;Database=custodian; port=3306;Charset=utf8;connection timeout = 15";
                string _date = SQLDateConverter.DateConverer(NowDate);

                string query = $@"SELECT 
                                `investment_bonds`,
                                `speculation_bonds`,
                                `Credit_Linked_Notes`,
                                `SNGC`,
                                `SNCC`,
                                `SNRS`,
                                `Hi_cap_share`,
                                `emerging_markets`,
                                `mid_cap_share`,
                                `lo_cap`,
                                `options`,
                                `futures`,
                                `leveraged_ETF`,
                                `mutual_funds`,
                                `residential_properties`,
                                `commercial_property`,
                                `classics_pictures`,
                                `modern_pictures`,
                                `marks`,
                                `wine`
                            FROM
                                paper
                            WHERE
                                `order` = '{order}'
                                    AND date = '{_date}'; ";
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    DataTable RowValues = new DataTable();
                    adapter.Fill(RowValues);
                    return RowValues;
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                        return null;
                    }
                }
            }



            //.................................

            #endregion

            #region История скачивания документов
            public static void WriteDocumentName(string documentname, string clientorder)
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = $@"INSERT INTO History_of_Downloads(`document` , `date_download`, `order_client`) VALUES ('{documentname}' , NOW(), '{clientorder}')";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex.Message, ex.Source);
                    }
                }
                  
            }

        #endregion

        }
    }   

    #endregion
   
}


