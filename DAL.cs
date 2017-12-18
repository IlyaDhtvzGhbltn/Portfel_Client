using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Custodian
{
    class DAL
    {

        static string ConnectionString = "User Id=root;Password=root;Host=localhost;Database=custodian; port=3306;Charset=utf8;connection timeout = 15";



        #region ПОЛУЧЕНИЕ ТАБЛИЦЫ С ДАННЫМИ АДМИНА ИЛИ НОЛЬ ЕСЛИ НЕВЕРЕН ЛОГИН - ПАРОЛЬ 
        internal static DataTable Auth(string Login, string Pass)
        {
            string _password = Hash.GetHash(Pass);
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"select * from  administrators where `logIN` = @LOG and `Password` = @PASS";

                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue(@"LOG", Login);
                comm.Parameters.AddWithValue(@"PASS", _password);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = comm;
                if (!Storage.dataset.Tables.Contains("AdminInfo"))
                {
                    DataTable table = Storage.dataset.Tables.Add("AdminInfo");
                    try
                    {
                        conn.Open();
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                        Storage.dataset.Tables.Remove("AdminInfo");
                        return null;
                    }
                }
                else if (Storage.dataset.Tables.Contains("AdminInfo"))
                {
                    Storage.dataset.Tables.Remove("AdminInfo");
                    Auth(Login, Pass);
                }
                }
            return null;
            }
        #endregion
        #region ДОБАВИТЬ КЛИЕНТА
        internal static void AddNewClient(string FName, string LName, string OrNum, string Sex,
            string DateofBirth, string Phone, string Mobile, string P_C, string Nation, string Proffession,
            string Adress, string CashAcc, string CashValue, string mail, string adviser)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $@"insert into custodian.orderholders() values(uuid(), '{CashAcc}', '{CashValue}', '{OrNum}', '{FName}',
                             '{LName}', '{Sex}', '{Nation}','{DateofBirth}','{Phone}', '{Mobile}','{Proffession}','{P_C}','{Adress}','{mail}' , '{adviser}',now()); ";
                MySqlCommand comm = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    BOX.ShowInformation("New Client was successfully added!");
                    
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }

            }
        }
        #endregion
        #region ТАБЛИЦА СО ВСЕМИ КЛИЕНТАМИ

        public static DataTable ShowAllClient()
        {
            try
            {
                DataTable clients = Storage.dataset.Tables.Add("Clients");
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM orderholders";

                    try
                    {
                        MySqlCommand comm = new MySqlCommand(query, conn);
                        adapter.SelectCommand = comm;
                        conn.Open();
                        adapter.Fill(clients);

                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                    }
                    return clients;
                }

            }
            catch (DuplicateNameException)
            {
                Storage.dataset.Tables.Remove("Clients");
                ShowAllClient();
            }
            return Storage.dataset.Tables["Clients"];
        }
        #endregion
        #region СПИСОК ВСЕХ АДВАЙЗЕРОВ
        public static List<string> GetAdvisers()
        {
            List<string> advisers = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM custodian.administrators where `Level` =2";
                try
                {
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            advisers.Add(reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString());
                        }
                        else
                        {
                            advisers.Add("Advisers List is Empty");
                        }

                    }
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }


            }

            return advisers;
        }
        #endregion
        #region СПИСОК НОМЕРОВ ДОГОВОРОВ
        internal static IEnumerable<string> GetOrderNumbers()
        {
            List<string> OrdNumbers = new List<string>();
            string query = "SELECT `Order` FROM custodian.orderholders";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OrdNumbers.Add(reader.GetString(0));
                        }
                    }
                    else
                    {
                        OrdNumbers.Add("Clients list is Empty");
                    }
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }


            return OrdNumbers;
        }

        #endregion
        #region ДОБАВЛЕНИЕ АКТИВА

        //<----------получение имени администратора обрезать лишнее------------>
        static char[] sign = { 'S', 'i', 'g', 'n', 'e', 'd', ' ', 'i', 'n', ':', ' ' };
        #region КУПИТЬ
        /// <summary>
        ///  Добавить строку о покупке
        /// </summary>
        /// <param name="NumbersOrders">Номер договора</param>
        /// <param name="OperationType">Тип операции - продажа.покупка.трансфер</param>
        /// <param name="Security">Тип ценной бумаги</param>
        /// <param name="isin">ISIN код</param>
        /// <param name="value">Валюта</param>
        /// <param name="Money">Всего денег потрачено</param>
        /// <param name="Count">Всего бумаг куплено</param>
        /// <param name="AqPrice">Стоимость одной бумаги</param>
        /// <param name="DatePicer">Дата совершения сделки</param>
        /// <param name="AdminID">Имя Фамилия админа</param>
        /// <param name="paperName">Название бумаги</param>
        /// <param name="cashafteroperm">Остаток после операции</param>
        internal static void AddNewInstruction(string NumbersOrders, string OperationType, string Security,
            string isin, string value, decimal Money, decimal Count,
            decimal AqPrice, string DatePicer, string AdminID, string paperName, decimal cashafteroperm)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string query = String.Format(@"insert into custodian.activesb  values (uuid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',now(),'{9}','{10}')",
                                    NumbersOrders, OperationType, Security, isin, value,
                                    Money.ToString("0.00", CultureInfo.GetCultureInfo("en-US")),
                                    Count.ToString("0.00", CultureInfo.GetCultureInfo("en-US")),
                                    AqPrice.ToString("0.00", CultureInfo.GetCultureInfo("en-Us")),
                                    DatePicer, AdminID.Trim(sign), paperName);


                    MySqlCommand comm = new MySqlCommand(query, conn);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    CashAccountReset(cashafteroperm, NumbersOrders);
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }

            }
        }
        #endregion
        #region ТРАНСФЕР
        internal static void AddPlatformActive(string Order, string PlatformName, string Money, string Date, string AdminID, decimal cashafter)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string _admin = AdminID.Trim(sign);
                string query = "insert into custodian.activest () values (uuid(),@order,@platform,@money,@dateinst,now(), @AdminID)";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@order", Order);
                comm.Parameters.AddWithValue("@platform", PlatformName);
                comm.Parameters.AddWithValue("@money", Money);
                comm.Parameters.AddWithValue("@dateinst", Date);
                comm.Parameters.AddWithValue("@AdminID", _admin);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    CashAccountReset(cashafter, Order);
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        #endregion
        #region ПРОДАЖА
        #region Получить активы доступные для продажи (купленные - проданные)
        internal static DataTable GetActivesForSale(string Order)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                DataTable table = new DataTable("Sale");
                string query =
       @"SELECT  `PaperType`,`Isin`,`Title`,  sum(col1)-coalesce(sum(col2),0)
 FROM (
        SELECT `PaperType`,`Isin`,`Title`, `CountPaper` AS col1, 0 AS col2
          FROM activesb where OrderNumber = @order
          UNION all
        SELECT 0,`IsinSalePaper`,`Title`, 0 AS col1, `CountPaper` AS col2
          FROM activessale where OrderNumber = @order
  )X
 GROUP BY `Title`";

                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue(@"order", Order);
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    if (!Storage.dataset.Tables.Contains("Sale"))
                    {
                        adapter.Fill(table);
                        Storage.dataset.Tables.Add(table);
                    }
                    else
                    {
                        adapter.Fill(table);
                        Storage.dataset.Tables.Remove("Sale");
                        Storage.dataset.Tables.Add(table);
                    }
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
                return table;
            }
        }
        #endregion
         
        internal static void AddNewSale(string OrderNumber, decimal CountToSale, decimal CashAccountNew,
            string Isin, string Title, string DateGetInst, string Admin, decimal AqPrise)
        {
            string thisAdmin = Admin.Trim(sign);
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "insert into custodian.activessale values(uuid(),@_orderN, @_isin, @_title, @_countPapeToSale, @_AqPrise, @_dateGInst,now(),@_admin)";
                MySqlCommand comm = new MySqlCommand(query, conn);
                string convertDecimalCountSale = CountToSale.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
                string convertDecimalAqPrise = AqPrise.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));

                comm.Parameters.AddWithValue("@_orderN", OrderNumber);
                comm.Parameters.AddWithValue("@_isin", Isin);
                comm.Parameters.AddWithValue("@_title", Title);
                comm.Parameters.AddWithValue("@_countPapeToSale", convertDecimalCountSale);
                comm.Parameters.AddWithValue("@_AqPrise", convertDecimalAqPrise);
                comm.Parameters.AddWithValue("@_dateGInst", DateGetInst);
                comm.Parameters.AddWithValue("@_admin", thisAdmin);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    CashAccountReset(CashAccountNew, OrderNumber);
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
            //CashAccountReset(CashAccountNew, OrderNumber);
        }
        #endregion

        #region ИЗМЕНЕНИЕ cash account клиента
        internal static void CashAccountReset(decimal NewCashAccount, string Client)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string updateComm = @"update custodian.orderholders set `Cash Account` = @NewCash where `Order` =@_client";
                MySqlCommand comm = new MySqlCommand(updateComm, conn);
                comm.Parameters.AddWithValue("@NewCash", NewCashAccount);
                comm.Parameters.AddWithValue("@_client", Client);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    BOX.ShowInformation("Instruction successfully added");
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        #endregion
        #endregion
        #region ЗАПИСЬ ЛОГОВ СЕССИИ

        internal static void StartSession(string Admin)
        {
            string admin = Admin.Trim(sign);
            Storage.sessionGuid = Guid.NewGuid().ToString();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "insert into custodian.loggs (`SessionID`,`adminName`,`SessionStart`) values (@guid, @admin, now()); ";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@admin", admin);
                comm.Parameters.AddWithValue("@guid", Storage.sessionGuid);
                try
                {
                    conn.OpenAsync();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        internal static void EndSession()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"update custodian.loggs set `SessionEnd` =  now() where `SessionID` = @SessionUUID ";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SessionUUID", Storage.sessionGuid);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        #endregion
        #region МЕТОДЫ ДЛЯ ПОЛУЧЕНИЯ ТЕКУЩИХ КОТИРОВОК ИЗ бд ИЛИ независимых источников
        internal static List<string> GetQuoteForISIN(string ISIN)
        {
            List<string> Quote = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "Select `Quote`,`Title` from custodian.isin_quote where `ISIN` = @_isin;";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue(@"_isin", ISIN);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    if (!reader.HasRows)
                    {
                        Quote.Add("ISIN not Found");
                    }
                    else
                    {
                        Quote.Add(reader.GetValue(0).ToString());
                        Quote.Add(reader.GetValue(1).ToString());
                    }
                }
                catch (MySqlException)
                {
                    BOX.ShowError("Connection Error", "Custodian");
                }
            }
            return Quote;
        }
        #endregion
        #region РАБОТА С ISIN ТАБЛИЦЕЙ
        internal static void GetISINTable()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "select * from custodian.isin_quote";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                try
                {
                    conn.Open();
                    if (Storage.dataset.Tables.Contains("ISIN"))
                    {
                        Storage.dataset.Tables.Remove("ISIN");
                        DataTable table = Storage.dataset.Tables.Add("ISIN");
                        adapter.Fill(table);
                    }
                    else
                    {
                        DataTable table = Storage.dataset.Tables.Add("ISIN");
                        adapter.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        internal static void UpdateISIN()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string queryUpp = "update custodian.isin_quote set `Quote`= @Quote, `Title`= @Title where `ISIN`=@ISIN";
                MySqlCommand updatecomm = new MySqlCommand(queryUpp, conn);

                updatecomm.Parameters.Add(@"Quote", MySqlDbType.VarChar, 10, "Quote");
                updatecomm.Parameters.Add(@"title", MySqlDbType.VarChar, 10, "Title");

                MySqlParameter parametr = updatecomm.Parameters.Add(@"ISIN", MySqlDbType.VarChar, 10, "ISIN");
                parametr.SourceVersion = DataRowVersion.Original;
                try
                {
                    adapter.UpdateCommand = updatecomm;
                    conn.Open();
                    adapter.Update(Storage.dataset.Tables["ISIN"]);
                    BOX.ShowInformation("ISIN Parameters successful update!");
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }

            }
        }
        internal static void InsertNewISIN(string isin, string quote, string title)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string queryINSERT = "insert into custodian.isin_quote values(@_isin, @_quote ,@_title)";
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                try
                {
                    MySqlCommand command = new MySqlCommand(queryINSERT, conn);
                    command.Parameters.AddWithValue(@"_isin", isin);
                    command.Parameters.AddWithValue(@"_quote", quote);
                    command.Parameters.AddWithValue(@"_title", title);
                    adapter.InsertCommand = command;

                    conn.Open();
                    adapter.InsertCommand.ExecuteNonQuery();
                    BOX.ShowInformation("ISIN Parameters successful add!");
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }

            }
        }


        #endregion
        #region УСТАНОВКА НОВОГО ПАРОЛЯ - ЛОГИНА - МАЙЛА
        internal static void SetNewPass(string newPass)
        {
            string hash = Hash.GetHash(newPass);
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"use Custodian;
                                update administrators set `Password` = @_newpass where `AdministratorIDNumber` = @_adminID; ";
                MySqlCommand comm = new MySqlCommand(query,conn);
                comm.Parameters.AddWithValue("@_newpass", hash);
                comm.Parameters.AddWithValue("@_adminID", Storage.EnteredUserID);
                try
                {
                    conn.OpenAsync();
                    comm.BeginExecuteNonQuery();
                    Auth(Storage.dataset.Tables["AdminInfo"].Rows[0][4].ToString(), newPass);
                    BOX.ShowInformation("New Password Sucsessful set");
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        
        internal static void SetNewLogin(string newLogg, bool client_admin)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                if (client_admin == false)
                {
                    string query = @"update Custodian.orderholders set `LogIN` = '@login' where `PersonalIDNumber` = '@ID';";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.Parameters.AddWithValue("@login", newLogg);
                    comm.Parameters.AddWithValue("@ID", Storage.EnteredUserID);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        BOX.ShowInformation("Login Sucsessful Update");
                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                    }
                }
                if (client_admin == true)
                {
                    string query = @"update Custodian.administrators set `LogIN` = @login where `AdministratorIDNumber` = @ID;";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.Parameters.AddWithValue("@login", newLogg);
                    comm.Parameters.AddWithValue("@ID", Storage.EnteredUserID);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        BOX.ShowInformation("Login Sucsessful Update");
                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                    }
                }

            }
        }
        #endregion
    }
}
