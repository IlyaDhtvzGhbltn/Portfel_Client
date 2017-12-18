using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Custodian
{
    class adminDAL
    {
        // static string ConnectionString = "User Id=ankoworu_test-01; Password=Gxk!-QWH}]@%;Host=208.88.226.248;Database=ankoworu_test-01; port=3306;Charset=utf8;connection timeout = 15";


        //local : 
        //"User Id=root;Password=root;Host=localhost;Database=custodian; port=3306;Charset=utf8;connection timeout = 15"

        static string ConnectionString = "User Id=root;Password=root;Host=localhost;Database=custodian; port=3306;Charset=utf8;connection timeout = 15";
        #region ПОЛУЧЕНИЕ ТАБЛИЦЫ С ДАННЫМИ АДМИНА ИЛИ НОЛЬ ЕСЛИ НЕВЕРЕН ЛОГИН - ПАРОЛЬ 
        //internal static DataTable Auth(string Login, string Pass)
        //{
        //    string _password = Hash.GetHash(Pass);
        //    using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //    {
        //        string query = @"select * from  administrators where `logIN` = @LOG and `Password` = @PASS";

        //        MySqlCommand comm = new MySqlCommand(query, conn);
        //        comm.Parameters.AddWithValue(@"LOG", Login);
        //        comm.Parameters.AddWithValue(@"PASS", _password);
        //        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //        adapter.SelectCommand = comm;
        //        if (!Storage.datasetAdmin.Tables.Contains("AdminInfo"))
        //        {
        //            DataTable table = Storage.datasetAdmin.Tables.Add("AdminInfo");
        //            try
        //            {
        //                conn.Open();
        //                adapter.Fill(table);
        //                Storage.AdminName = table.Rows[0][0].ToString();
        //                return table;
        //            }
        //            catch (Exception ex)
        //            {
        //                //BOX.ShowError(ex.Message, ex.Source);
        //                Storage.datasetAdmin.Tables.Remove("AdminInfo");
        //                return null;
        //            }
        //        }
        //        else if (Storage.datasetAdmin.Tables.Contains("AdminInfo"))
        //        {
        //            Storage.datasetAdmin.Tables.Remove("AdminInfo");
        //            Auth(Login, Pass);
        //        }
        //    }
        //    return null;
        //}
        #endregion
        #region ДОБАВИТЬ КЛИЕНТА




        internal static void AddNewClient(string FName, string LName, string OrNum, string Sex,
                   string DateofBirth, string Phone, string Mobile, string P_C, string Nation, string Proffession,
                   string Adress, decimal CashAccUSD, decimal CashAccEUR, decimal CashAccGBB, decimal CashAccSGD, decimal CashAccAUD, string mail, string adviser, string tempPass,
                   decimal CashAll, string Comp, string Status)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {

                {
                    System.Security.SecureString tempPASS = new System.Security.SecureString();
                    char[] pass = tempPass.ToCharArray();

                    for (int i = 0; i < pass.Length; i++)
                    {
                        tempPASS.AppendChar(pass[i]);
                    }
                }
                string query = $@"insert into orderholders() values(uuid(),
                '{CashAccUSD.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}',
                '{CashAccEUR.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}',
                '{CashAccGBB.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}',
                '{CashAccSGD.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}',
                '{CashAccAUD.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}', 
                '{OrNum}', '{FName}', '{LName}','{Sex}', '{Nation}','{DateofBirth}',
                '{Phone}', '{Mobile}','{Proffession}','{P_C}','{Adress}','{mail}',
                '{adviser}',now() , '{mail}', '{Hash.GetHash(tempPass)}', 
                '{CashAll.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}',
                '{Comp}','{Status}')";
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
        //public static DataTable ShowAllClient()
        //{
        //    try
        //    {
        //        DataTable clients = Storage.datasetAdmin.Tables.Add("Clients");
        //        MySqlDataAdapter adapter = new MySqlDataAdapter();

        //        using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //        {
        //            string query = "SELECT * FROM orderholders";

        //            try
        //            {
        //                MySqlCommand comm = new MySqlCommand(query, conn);
        //                adapter.SelectCommand = comm;
        //                conn.Open();
        //                adapter.Fill(clients);

        //            }
        //            catch (Exception ex)
        //            {
        //                BOX.ShowError(ex.Message, ex.Source);
        //            }
        //            return clients;
        //        }

        //    }
        //    catch (DuplicateNameException)
        //    {
        //        Storage.datasetAdmin.Tables.Remove("Clients");
        //        ShowAllClient();
        //    }
        //    return Storage.datasetAdmin.Tables["Clients"];
        //}

        //Таблица только с одним клиентом найденным по номеру договора
        public static DataTable GetOneClient(string order)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $"SELECT `Cash Account_USD`,`Cash Account_EUR`,`Cash Account_GBP`, `Cash Account_SGD`,`Cash Account_AUD` FROM orderholders where `Order` = '{order}'";
                try
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    adapter.SelectCommand = comm;
                    conn.Open();
                    adapter.Fill(table);
                    return table;

                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }

        #endregion
        #region СПИСОК ВСЕХ АДВАЙЗЕРОВ
        public static List<string> GetAdvisers(string ID)
        {
            List<string> name = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM administrators where `AdministratorIDNumber`=@_id";
                try
                {
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    conn.Open();
                    comm.Parameters.AddWithValue("@_id", ID);
                    MySqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            name.Add(reader.GetString(1));
                            name.Add(reader.GetString(2));
                        }
                        return name;
                    }
                    else name.Add("CONSULTANT not wound");
                    name.Add("");
                    return name;
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }
        #endregion
        #region СПИСОК НОМЕРОВ ДОГОВОРОВ
        internal static IEnumerable<string> GetOrderNumbers()
        {
            List<string> OrdNumbers = new List<string>();
            string query = "SELECT `Order` FROM orderholders";
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
        #region Обновление Cash Account ВСТАВКА withdraw
        internal static void ResetCashAccount_Withdraw(string id, decimal summ, decimal ost, string DataGetIns)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "update `orderholders` set `Cash Account` = @ost where `Order` = @numer;" + "insert into `activeswichdraw` values(uuid(), @numer, @summ, @DateInstr, now())";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@ost", ost);
                comm.Parameters.AddWithValue("@numer", id);
                comm.Parameters.AddWithValue("@summ", summ);
                comm.Parameters.AddWithValue("@DateInstr", DataGetIns);
                try
                {
                    conn.Open();
                    comm.ExecuteReader();
                    BOX.ShowInformation("Whithdraw Operation Added sucsessfull");
                }
                catch (Exception ex) { BOX.ShowError(ex.Message, ex.Source); }

            }

        }

        #endregion
        #region обновление Cash Account и Cash Allocation ВСТАВКА funding
        // Paper Funding
        internal static void ResetCashAllocationCashAccount_Funding(string id, string security, string isin, string count, string aqprise, string dynamik, DateTime DateGet, string cashAccountAfter, string cashAllocationAfter, string paperName)
        {
            decimal _cashAccount = Convert.ToDecimal(cashAccountAfter);
            decimal _cashAllocation = Convert.ToDecimal(cashAllocationAfter);
            decimal _dynamik = Convert.ToDecimal(dynamik);
            decimal _aqprise = Convert.ToDecimal(aqprise);
            decimal _count = Convert.ToDecimal(count);

            using (MySqlConnection conn = new MySqlConnection(ConnectionString)) //PurPrice = Dynamik = CashAmount
            {
                string query = "update `orderholders` set `Cash Account` = @CashAcc  where `Order` = @numer;" +

                    "insert into `activesfunding` (`OperationID`, `Order`, `Security`, `Isin`,`CashAmount`,`AqPrice`,`CountPaper`, `DateGetInst`,`Date`,`TitlePaper`) " +
                    "" +
                    "values(uuid(), @numer, @_security, @_isin, @_PurPrice, @_aqprice, @_count, @_dateGetInst, now(),@_title)";
                MySqlCommand comm = new MySqlCommand(query, conn);

                comm.Parameters.AddWithValue("@numer", id);
                comm.Parameters.AddWithValue("@CashAcc", _cashAccount.ToString("0.00", CultureInfo.GetCultureInfo("en-US")));
                comm.Parameters.AddWithValue("@_security", security);
                comm.Parameters.AddWithValue("@_isin", isin);
                comm.Parameters.AddWithValue("@_PurPrice", _dynamik.ToString("0.00", CultureInfo.GetCultureInfo("en-US")));
                comm.Parameters.AddWithValue("@_aqprice", _aqprise.ToString("0.00", CultureInfo.GetCultureInfo("en-US")));
                comm.Parameters.AddWithValue("@_count", _count.ToString("0.00", CultureInfo.GetCultureInfo("en-US")));
                comm.Parameters.AddWithValue("@_dateGetInst", DateGet.ToString("yyyy.MM.dd"));
                comm.Parameters.AddWithValue("@_title", paperName);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    BOX.ShowInformation("Funding update Sucsessfull");

                }
                catch (Exception e) { BOX.ShowError(e.Message, e.Source); }
            }
        }
        // Only Money Funding
        internal static void ResetCashAllocationCashAccount_Funding(string id, string Security, string cashAccount, string cashAllocation, string Summ, string DateGetInst)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                decimal _cashAccount = Convert.ToDecimal(cashAccount);
                decimal _cashAllocation = Convert.ToDecimal(cashAllocation);
                string query = "update `orderholders` set `Cash Account` = @CashAcc  where `Order` = @numer;"
                    +
                 "insert into `activesfunding` (`OperationID`, `Order`, `Security`,`CashAmount`,`Date`,`DateGetInst`) values(uuid(), @numer, @_security, @_Summ, @_dategetInst, now())";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@numer", id);

                comm.Parameters.AddWithValue("@CashAcc", _cashAccount.ToString("0.00", CultureInfo.GetCultureInfo("en-US")));

                comm.Parameters.AddWithValue("@_security", Security);
                comm.Parameters.AddWithValue("@_Summ", Summ);
                comm.Parameters.AddWithValue("@_dategetInst", DateGetInst);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    BOX.ShowInformation("Funding update Sucsessfull");
                }
                catch (Exception ex) { BOX.ShowError(ex.Message, ex.Source); }

            }

        }

        #endregion
        #region ДОБАВЛЕНИЕ АКТИВА
        //If you're reading this now, 
        //then you are work in my place now.
        //.......
        //Fuuuuuuuuu, ebat ty lox !!!!!
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
        internal static void AddNewInstruction(string NumbersOrders, string Security,
            string isin, decimal Money, decimal Count,
            decimal AqPrice, string DatePicer, string AdminID, string paperName, decimal cashafteroperm)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string query = String.Format(@"insert into activesb  values (uuid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',now(),'{8}','{9}')",
                                    NumbersOrders, Security, isin, "USD",
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
        internal static void AddPlatformActive(string Order, string PlatformName, string Money, string Date, string AdminID, decimal cashafter, string value)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string _admin = AdminID.Trim(sign);
                string query = "insert into activest () values (uuid(),@order,@platform,@money,@dateinst,now(), @AdminID,@_value)";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@order", Order);
                comm.Parameters.AddWithValue("@platform", PlatformName);
                comm.Parameters.AddWithValue("@money", Money);
                comm.Parameters.AddWithValue("@dateinst", Date);
                comm.Parameters.AddWithValue("@AdminID", _admin);
                comm.Parameters.AddWithValue("@_value", value);
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
 //       internal static DataTable GetActivesForSale(string Order)
 //       {
 //           using (MySqlConnection conn = new MySqlConnection(ConnectionString))
 //           {
 //               DataTable table = new DataTable("Sale");
 //               string query =
 //      @"SELECT  `PaperType`,`Isin`,`Title`,  sum(col1)-coalesce(sum(col2),0)
 //FROM (
 //       SELECT `PaperType`,`Isin`,`Title`, `CountPaper` AS col1, 0 AS col2
 //         FROM activesb where OrderNumber = @order
 //         UNION all
 //       SELECT 0,`Isin`,`Title`, 0 AS col1, `CountPaper` AS col2
 //         FROM activessale where OrderNumber = @order
 // )X
 //GROUP BY `Isin`";

 //               MySqlCommand comm = new MySqlCommand(query, conn);
 //               comm.Parameters.AddWithValue(@"order", Order);
 //               try
 //               {
 //                   conn.Open();
 //                   MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
 //                   if (!Storage.datasetAdmin.Tables.Contains("Sale"))
 //                   {
 //                       adapter.Fill(table);
 //                       Storage.datasetAdmin.Tables.Add(table);
 //                   }
 //                   else
 //                   {
 //                       adapter.Fill(table);
 //                       Storage.datasetAdmin.Tables.Remove("Sale");
 //                       Storage.datasetAdmin.Tables.Add(table);
 //                   }
 //               }
 //               catch (Exception ex)
 //               {
 //                   BOX.ShowError(ex.Message, ex.Source);
 //               }
 //               return table;
 //           }
 //       }
        #endregion


        internal static void AddNewSale(string OrderNumber, decimal CountToSale, decimal CashAccountNew,
            string Isin, string Title, string DateGetInst, string Admin, decimal AqPrise, string Type, decimal summ)
        {
            string thisAdmin = Admin.Trim(sign);
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {

                string query = "insert into activessale values(uuid(),@_orderN, @_isin, @_title, @_countPapeToSale, @_AqPrise, @_dateGInst,now(),@_admin,@_type, @_summ, @_value)";

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
                comm.Parameters.AddWithValue("@_type", Type);
                comm.Parameters.AddWithValue("@_summ", summ);
                comm.Parameters.AddWithValue("@_value", "USD");
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
        }
        #endregion

        #region ИЗМЕНЕНИЕ cash account клиента
        internal static void CashAccountReset(decimal NewCashAccount, string Client)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string updateComm = @"update orderholders set `Cash Account` = @NewCash where `Order` =@_client";
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
                string query = "insert into loggs (`SessionID`,`adminName`,`SessionStart`) values (@guid, @admin, now()); ";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@admin", admin);
                comm.Parameters.AddWithValue("@guid", Storage.sessionGuid);
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
        internal static void EndSession()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = @"update loggs set `SessionEnd` =  now() where `SessionID` = @SessionUUID ";
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
                string query = "Select `Quote`,`Title` from isin_quote where `ISIN` = @_isin;";
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
        //internal static void GetISINTable()
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //    {
        //        string query = "select * from isin_quote";
        //        MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
        //        try
        //        {
        //            conn.Open();
        //            if (Storage.datasetAdmin.Tables.Contains("ISIN"))
        //            {
        //                Storage.datasetAdmin.Tables.Remove("ISIN");
        //                DataTable table = Storage.datasetAdmin.Tables.Add("ISIN");
        //                adapter.Fill(table);
        //            }
        //            else
        //            {
        //                DataTable table = Storage.datasetAdmin.Tables.Add("ISIN");
        //                adapter.Fill(table);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            BOX.ShowError(ex.Message, ex.Source);
        //        }
        //    }
        //}
        //internal static void UpdateISIN()
        //{
        //    using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //    {
        //        MySqlDataAdapter adapter = new MySqlDataAdapter();
        //        string queryUpp = "update isin_quote set `Quote`= @Quote, `Title`= @Title where `ISIN`=@ISIN";
        //        MySqlCommand updatecomm = new MySqlCommand(queryUpp, conn);

        //        updatecomm.Parameters.Add(@"Quote", MySqlDbType.VarChar, 10, "Quote");
        //        updatecomm.Parameters.Add(@"title", MySqlDbType.VarChar, 10, "Title");

        //        MySqlParameter parametr = updatecomm.Parameters.Add(@"ISIN", MySqlDbType.VarChar, 10, "ISIN");
        //        parametr.SourceVersion = DataRowVersion.Original;
        //        try
        //        {
        //            adapter.UpdateCommand = updatecomm;
        //            conn.Open();
        //            adapter.Update(Storage.datasetAdmin.Tables["ISIN"]);
        //            BOX.ShowInformation("ISIN Parameters successful update!");
        //        }
        //        catch (Exception ex)
        //        {
        //            BOX.ShowError(ex.Message, ex.Source);
        //        }

        //    }
        //}
        internal static void InsertNewISIN(string isin, string quote, string title)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string queryINSERT = "insert into isin_quote values(@_isin, @_quote ,@_title)";
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
        //internal static void SetNewPass(string newPass)
        //{
        //    string hash = Hash.GetHash(newPass);
        //    using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        //    {
        //        string query = @"update administrators set `Password` = @_newpass where `AdministratorIDNumber` = @_adminID; ";
        //        MySqlCommand comm = new MySqlCommand(query, conn);
        //        comm.Parameters.AddWithValue("@_newpass", hash);
        //        comm.Parameters.AddWithValue("@_adminID", Storage.EnteredUserID);
        //        try
        //        {
        //            conn.Open();
        //            comm.BeginExecuteNonQuery();
        //            Auth(Storage.datasetAdmin.Tables["AdminInfo"].Rows[0][4].ToString(), newPass);
        //            BOX.ShowInformation("New Password Sucsessful set");
        //        }
        //        catch (Exception ex)
        //        {
        //            BOX.ShowError(ex.Message, ex.Source);
        //        }
        //    }
        //}

        internal static void SetNewLogin(string newLogg)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                {
                    string query = @"update administrators set `LogIN` = @login where `AdministratorIDNumber` = @ID;";
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

        internal static void SetNewMail(string newMail)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                {
                    string query = @"update administrators set `Email` = @newMail where `AdministratorIDNumber` = @ID;";
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.Parameters.AddWithValue("@newMail", newMail);
                    comm.Parameters.AddWithValue("@ID", Storage.EnteredUserID);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        BOX.ShowInformation("Mail Sucsessful Update");
                    }
                    catch (Exception ex)
                    {
                        BOX.ShowError(ex.Message, ex.Source);
                    }
                }

            }

        }
        #endregion
        #region ВЕРНУТЬ СТРОКУ С ДАННЫМИ КЛИЕНТА ПО ДОГОВОРУ ИЛИ null ЕСЛИ КЛИЕНТА НЕТ
        /// <summary>
        /// Возвращает таблицу с информацией о клиенте из БД по номеру договора.
        /// Возвращает null если клиента с таким номером не существует.
        /// </summary>
        /// <param name="number">Номер договора клиента</param>
        /// <returns></returns>
        internal static DataTable OldNumberOrder(string number)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = "select * from orderholders where `Order` = @_number";
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.Parameters.AddWithValue("@_number", number);
                try
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                    adapter.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }
        #endregion
        #region КОНВЕРТАЦИЯ ВАЛЮТЫ 

        public static void AddConvertOperation(string valueFrom, string valueTo, 
            decimal countFrom, decimal countTo, 
            string order, string date, decimal kurs)
        {
            Char[] Chrink = { 'C','a','s','h',' ','A','c', 'c', 'o', 'u', 'n','t','_' };
            string ValueFromName = valueFrom.Trim(Chrink);
            string ValueToName = valueTo.Trim(Chrink);


            string updateQueryTo = $"update `orderholders` set `{valueFrom}` = '{countFrom.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}' where `Order` = '{order}';";

            string updateQueryFrom = $"update `orderholders` set `{valueTo}` = '{countTo.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}' where `Order` = '{order}';";

            string insertQuery = $"insert into  `convertoperation` values " +
                $"(uuid(), " +
                $"'{order}', " +
                $"'{ValueFromName}', " +
                $"'{ValueToName}', " +
                $"{kurs.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}, " +
                $"'{date}'," +
                $" CURDATE(), " +
                $"'{countFrom.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}'," +
                $"'{countTo.ToString("0.00", CultureInfo.GetCultureInfo("en-US"))}'); ";

            string resultQuery = updateQueryFrom + updateQueryTo + insertQuery;
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlCommand comm = new MySqlCommand(resultQuery,conn);
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
        #region ДОБАВЛЕНИЕ ИЛИ ПРИБАВКА К CASH ACCOUNT
        public static void AddNewCashAccount(string order, string USDNew, string EURNew, string GBPNew,string SGDNew, string AUDNew, string Date, string adviser, string AddUSD, string AddEUR, string AddGBP, string AddSGD, string AddAUD )
        {
            decimal newusd = Convert.ToDecimal(USDNew);
            decimal neweur = Convert.ToDecimal(EURNew);
            decimal newgbp = Convert.ToDecimal(GBPNew);
            decimal newsgd = Convert.ToDecimal(SGDNew);
            decimal newaud = Convert.ToDecimal(AUDNew);

            decimal Addnewusd = Convert.ToDecimal(AddUSD);
            decimal Addneweur = Convert.ToDecimal(AddEUR);
            decimal Addnewgbp = Convert.ToDecimal(AddGBP);
            decimal Addnewsgd = Convert.ToDecimal(AddSGD);
            decimal Addnewaud = Convert.ToDecimal(AddAUD);

            string USD = newusd.ToString("0.00",CultureInfo.GetCultureInfo("en-US"));
            string EUR = neweur.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string GBP = newgbp.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string SGD = newsgd.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string AUD = newaud.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));

            string addUSD = Addnewusd.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string addEUR = Addneweur.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string addGBP = Addnewgbp.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string addSGD = Addnewsgd.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));
            string addAUD = Addnewaud.ToString("0.00", CultureInfo.GetCultureInfo("en-US"));

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string updatecomm = $"update orderholders set `Cash Account_USD` = '{USD}',  `Cash Account_EUR`= '{EUR}', `Cash Account_GBP`= '{GBP}' ,`Cash Account_SGD`= '{SGD}',`Cash Account_AUD`= '{AUD}' where `Order`= '{order}'; ";

                string insertcomm = $"insert into `addcashaccountoperations` values(uuid(),'{order}', {addUSD},{addEUR},{addGBP},{addSGD},{addAUD}, '{Date}', now(),'{adviser}'); ";

                string query = updatecomm + insertcomm;
                MySqlCommand comm = new MySqlCommand(query, conn);
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
        #region ПОИСК ПО ЗАДАЧАМ
        internal static DataTable GetTasks(string Admin)
        {
            string query = "";

            switch (Admin)
            {
                case null:
                    query = "SELECT * FROM tasks";
                    break;
                default:
                    query = $"SELECT * FROM tasks where ClientOrder = '{Admin}'";
                    break;
            }
            
            DataTable table = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    comm.ExecuteNonQuery();
                    return table;
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }


        internal static DataTable GetOnlyNewTasks()
        {
            string  query = "SELECT * FROM tasks where `Status` = 'Received' ";
            DataTable table = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    comm.ExecuteNonQuery();
                    return table;
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }
        #endregion
        #region АПДЕЙТ СТАТУСА ЗАДАЧИ
        internal static void updateStatus(string order, string status)
        {
            string query = $"update tasks set `Status` = '{status}' where `ClientOrder` = '{order}'; ";

            if (status == "Closed")
            {
                query = $"update tasks set `Status` = '{status}', `DataOut`= now() where `ClientOrder` = '{order}'; ";
            }

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
                    BOX.ShowError(ex.Message, ex.Source);
                }
            }
        }
        #endregion
        #region ПОЛУЧИТЬ ТАБЛИЦУ КЛИЕНТОВ У КОТОРЫХ МЕНЕДЖЕР ТЕКУЩИЙ ПОЛЬЗОВАТЕЛЬ
        internal static DataTable ALLMYClient(string AdminID)
        {
            string    query = $"select * from  `orderholders` where `Adviser` = '{AdminID}'";
            DataTable table = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    comm.ExecuteNonQuery();
                    return table;
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }

        #endregion
        #region ДЛЯ ЧАТИКА С КЛИЕНТАМИ

        /// <summary>
        /// ВОЗВРАЩАЕТ ИНФОРМАЦИЮ О КЛИЕНТЕ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal static DataTable KlientInfo(string order)
        {
            DataTable table = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $@"select  `Cash Account_USD`, `Cash Account_EUR`, `Cash Account_GBP`, `Cash Account_SGD`, `Cash Account_AUD`, `Order`, `First Name`, `Last Name`, `Sex`, `Nationality`, `Date of Birth`, `Phone`, `Mobile`, `Profession`, `Person\Company`, `Registered address`, `Email`, `Date of Registration`, `Cash allocation`, `Company`, `Status` from orderholders where `Order` ='{order}' ";
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);

                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }
            }
        }
        /// <summary>
        /// ПОЛУЧИТЬ ТАБЛИЦУ С ПЕРЕПИСКОЙ КОНКРЕТНОГО АДМИНА С КОНКРЕТНЫМ КЛИЕНТОМ
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        internal static DataTable AdminClientChat(string admin, string client)
        {
            DataTable table = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string query = $@"select `TEXT`, `DATEMESS` from messengers where `FROM`='{client}' and `TO`='{admin}' 
                                  union
                                 select `TEXT`, `DATEMESS` from messengers where `FROM`= '{admin}' and `TO`= '{client}'";
                MySqlCommand comm = new MySqlCommand(query,conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(comm);
                try
                {
                    conn.Open();
                    adapter.Fill(table);
                    return table;

                }
                catch (Exception ex)
                {
                    BOX.ShowError(ex.Message, ex.Source);
                    return null;
                }

            }
        }

        /// <summary>
        /// ОТПРАВИТЬ СООБЩЕНИЕ КЛИЕНТУ ОТ АДМИНА(МАНАГЕРА)
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="client"></param>
        /// <param name="text"></param>
        internal static void SendToClientMessFromAdmin(string admin, string client, string text)
        {
            string query = $"insert into messengers  values('{admin}','{client}','{text}',now()); ";
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
                    BOX.ShowError(ex.Message, ex.Source);
                }

            }
        }


        #endregion

    }
}
