//  This file is property of ArzeshPardazArian Investment Consulting Co. Tehran, Iran.
//  Written By Saeed Beyty, in Portfolio Management and AloTrading Department.                 
/// Version: 5.3.5 2012-06-19 13:04


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace vtocSqlInterface
{

    public class PersianConversions
    {
        public static void ReplaceWithCorrectPersianKY(ref DataSet ds)
        {
            foreach (DataTable table in ds.Tables)
            {
                table.TableName = ReplaceWithCorrectPersianKY(table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        if (column.DataType.Equals(typeof(string)))
                        {
                            //MessageBox.Show("blip");
                            row[column] = ReplaceWithCorrectPersianKY(row[column].ToString());
                        }
                    }
                }

            }
        }


        /// <summary>
        /// replace "Kaf" and "Ya" in arabic alphabet with persian replacements
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public static string ReplaceWithCorrectPersianKY(string p)
        {
            //"ی"
            //1610 and 1609 must be replaced with 1740
            // "ک"
            // 1603 must be replaced with 1705
            return p.Replace(Convert.ToChar(1610), Convert.ToChar(1740)).Replace(Convert.ToChar(1609), Convert.ToChar(1740)).Replace(Convert.ToChar(1603), Convert.ToChar(1705)).Trim();
        }

        public static void ReplaceCodalSymbolsWithTseSymbols(ref DataSet ds, sqlInterface mySqlinterface)
        {
            //var mySqlinterface = new sqlInterface( Properties.Settings.Default.DatabaseServer, Properties.Settings.Default.DatabaseName, Properties.Settings.Default.DatabaseUserName, Properties.Settings.Default.DatabasePassword);
            foreach (DataTable table in ds.Tables)
            {

                //look for "symbol" or similar in tables
                bool found = false;
                string symbolContainingColumnName = string.Empty;
                foreach (DataColumn clmn in table.Columns)
                {
                    if (clmn.ColumnName.ToLower().Equals("symbol") || clmn.ColumnName.ToLower().Equals("companysymbol"))
                    {
                        symbolContainingColumnName = clmn.ColumnName;
                        found = true;
                        break;
                    }
                }
                //look for "Name" or similar in tables
                found = false;
                string companyNameContainingColumnName = string.Empty;
                foreach (DataColumn clmn in table.Columns)
                {
                    if (clmn.ColumnName.ToLower().Equals("name") || clmn.ColumnName.ToLower().Equals("companyname"))
                    {
                        companyNameContainingColumnName = clmn.ColumnName;
                        found = true;
                        break;
                    }
                }

                //look for "ParentRef" or similar in tables
                found = false;
                string ParentRefContainingColumnName = string.Empty;
                foreach (DataColumn clmn in table.Columns)
                {
                    if (clmn.ColumnName.ToLower().Equals("parentref"))
                    {
                        ParentRefContainingColumnName = clmn.ColumnName;
                        found = true;
                        break;
                    }
                }


                table.TableName = PersianConversions.ReplaceWithCorrectPersianKY(table.TableName);
                foreach (DataRow row in table.Rows)
                {

                    string CodalSymbol = string.Empty;
                    if (symbolContainingColumnName.Length > 0)
                        CodalSymbol = row[symbolContainingColumnName].ToString();

                    string CodalCompanyName = string.Empty;
                    if (companyNameContainingColumnName.Length > 0)
                        CodalCompanyName = row[companyNameContainingColumnName].ToString();

                    string CodalParentRef = string.Empty;
                    if (ParentRefContainingColumnName.Length > 0)
                        CodalParentRef = row[ParentRefContainingColumnName].ToString();


                    string sqlCmd = string.Format(@"SELECT TOP(1) * FROM 
                                            CODALData.dbo.fn_MapCodal2TseSymbols(N'{0}',N'{1}',N'{2}') ", CodalSymbol, CodalCompanyName, CodalParentRef);

                    var myDt = mySqlinterface.SqlExecuteReader(sqlCmd,new SqlParameter[0]);
                    if (myDt != null && myDt.Rows.Count > 0)
                    {

                        var myTseSymbol = string.Empty;
                        var myTseCompanyName = string.Empty;
                        var myTseParentRef = string.Empty;

                        if (myDt.Columns.Contains("TseSymbol"))
                            myTseSymbol = myDt.Rows[0]["TseSymbol"].ToString();
                        if (myDt.Columns.Contains("TseCompanyName"))
                            myTseCompanyName = myDt.Rows[0]["TseCompanyName"].ToString();
                        if (myDt.Columns.Contains("TseParentref"))
                            myTseParentRef = myDt.Rows[0]["TseParentref"].ToString();

                        if (myTseSymbol.Length > 0)
                        {
                            if (symbolContainingColumnName.Length > 0) row[symbolContainingColumnName] = myTseSymbol;
                            if (companyNameContainingColumnName.Length > 0) row[companyNameContainingColumnName] = myTseCompanyName;
                            if (ParentRefContainingColumnName.Length > 0) row[ParentRefContainingColumnName] = myTseParentRef;
                        }
                    }
                }
            }
        }


    }

    public class DateHelper
    {
        public static int DateToInt(DateTime myDate)
        {
            try
            {
                int y = myDate.Year; int m = myDate.Month; int d = myDate.Day;
                if (y <= 3000 && y >= 1000 && m <= 12 && m >= 1 && d <= 31 && d >= 1)
                    return myDate.Year * 10000 + myDate.Month * 100 + myDate.Day;
                else
                    return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        } 

        public static DateTime DateFromInt(int DEven, int HEven = 0)
        {
            try
            {
                if (DEven < 19000101) DEven = 19000101;
                if (DEven > 30010101) DEven = 30010101;
                if (HEven < 0) HEven = 0;
                if (HEven > 245959) HEven = 245959;

                int Year = (int)(Math.Floor(DEven / 10000.0));
                int tmp = DEven - Year * 10000;
                int Month = (int)(Math.Floor(tmp / 100.0));
                int Day = tmp - Month * 100;

                int Hour = 0;
                int Minute = 0;
                int Second = 0;
                if (HEven > 0)
                {
                    Hour = (int)(Math.Floor(HEven / 10000.0));
                    int tmp2 = HEven - Hour * 10000;
                    Minute = (int)(Math.Floor(tmp2 / 100.0));
                    Second = tmp2 - Minute * 100;
                }
                return (new DateTime(Year, Month, Day, Hour, Minute, Second));
            }
            catch (Exception e)
            {
                //throw;
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }
        }






    }
   
    public class sqlInterface
    {




        private string _connString;
        private List<Tuple<DateTime, string>> _MessageLog;

        public bool logToFile = false;
        public sqlInterface(string conn)
        {
            _connString = conn;
            _MessageLog = new List<Tuple<DateTime, string>>();

        }



        public sqlInterface(int connectionNumber)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;

            int dotOccurance = path.LastIndexOf(".");
            if (dotOccurance < 0)
                dotOccurance = path.Length - 1;
            path = path.Substring(0, dotOccurance+1);
            path = path + "dat";
            path = path.Replace(@"file:///", "");


            Settings2File mySettings = new Settings2File(path);

            //string serverName = mySettings.get(connectionNumber.ToString() + "DatabaseServer", "sql-srv");
            //string databaseName = mySettings.get(connectionNumber.ToString() + "DatabaseName", "TseTrade");
            //string userName = mySettings.get(connectionNumber.ToString() + "DatabaseUsername", "***");
            //string password = mySettings.get(connectionNumber.ToString() + "DatabasePassword", "****");

            string serverName = mySettings.get(connectionNumber.ToString() + "DatabaseServer", "-");
            string databaseName = mySettings.get(connectionNumber.ToString() + "DatabaseName", "-");
            string userName = mySettings.get(connectionNumber.ToString() + "DatabaseUsername", "-");
            string password = mySettings.get(connectionNumber.ToString() + "DatabasePassword", "-");

            string connString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", serverName, databaseName, userName, password);
            _connString = connString;
            


        }

        #region logging functions
        public static void log(string e)
        {
            // get call stack
            var stackTrace = new System.Diagnostics.StackTrace();

            // get calling method name
            string callingFunction = stackTrace.GetFrame(1).GetMethod().Name;



            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;

            int dotOccurance = path.LastIndexOf(".");
            if (dotOccurance < 0)
                dotOccurance = path.Length - 1;
            path = path.Substring(0, dotOccurance + 1);
            path = path.Substring(0, path.Length - 1) + "_"+DateTime.Now.Date.ToString("yyyy-MM-dd") + @".";
            path = path + "log";
            path = path.Replace(@"file:///", ""); 
            var mySettings = new Settings2File(path);
            mySettings.set(@"@"+DateTime.Now.ToString()+": Function:"+callingFunction," Message:"+e);
            mySettings.Save();
        }

        public static void log()
        {
            log("-");
        }

        public List<Tuple<DateTime, string>> pipeMessages()
        {
            List<Tuple<DateTime, string>> tmp = new List<Tuple<DateTime, string>>(_MessageLog);
            _MessageLog.Clear();
            return tmp;
        }

        private void AddtoLog(string p)
        {
            if (_MessageLog == null)
                _MessageLog = new List<Tuple<DateTime, string>>();
            _MessageLog.Add(new Tuple<DateTime, string>(DateTime.Now, p));
            if (_MessageLog.Count() > 1000)
                _MessageLog.RemoveAt(0);

            if (logToFile)
                log(p);
        }

        #endregion

        public sqlInterface (string SettingsfileName, string connectionName)
        {
            try
            {


            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            path = path.Replace("file:\\", "");
            Settings2File mySettings = new Settings2File(path + "\\" + SettingsfileName);

            //mySettings.set(connectionName + "DatabaseServer", "sql-srv");
            //mySettings.set(connectionName + "DatabaseName", "TseTrade");
            //mySettings.set(connectionName + "DatabaseUsername", "sa");
            //mySettings.set(connectionName + "DatabasePassword", "******");

            string serverName = mySettings.get(connectionName+"DatabaseServer", "-");
            string databaseName = mySettings.get(connectionName+"DatabaseName", "-");
            string userName = mySettings.get(connectionName+"DatabaseUsername", "-");
            string password = mySettings.get(connectionName+"DatabasePassword", "-");

            string connString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", serverName, databaseName, userName, password);

            _connString = connString;

            }
            catch (Exception e)
            {
                AddtoLog(e.Source + ": " + e.Message);
                //throw;
            }
        }

        public sqlInterface(string serverName, string databaseName, string userName, string password)
        {

            string connString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", serverName, databaseName, userName, password);
            _connString = connString;
            _MessageLog = new List<Tuple<DateTime, string>>();
        }

        public string GetConnectionString()
        {
            return _connString;
        }

        public object SqlExecuteScalar(string queryString)
        {
            //ExecuteNonQuery
            //string connetionString = sqlGetConnectionString();
            object result = new object();
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryString, new SqlConnection(_connString)))
                {
                    cmd.Connection.Open();
                    result = cmd.ExecuteScalar();
                    cmd.Connection.Close();
                }
            }
            catch (Exception e)
            {
                AddtoLog(e.Message);
                result = null;
                //throw;
            }
            return result;
        }

        public DataTable SqlExecuteReader(string queryString,SqlParameter[] parameters, int timeoutValue=0)
        {
            //string connetionString = sqlGetConnectionString();
            //ExecuteReader            
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryString, new SqlConnection(_connString)))
                {
                    cmd.Parameters.AddRange(parameters);
                    foreach (SqlParameter p in parameters)
                    {
                        if (p.Value == null)
                            p.Value = DBNull.Value;
                    }
                    if (timeoutValue > 0)
                        cmd.CommandTimeout = timeoutValue;
                    cmd.Connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //dt.Clear();
                    dt.Load(rdr);
                    //dataGridViewRetrivedData.DataSource = dt;
                    rdr.Close();
                    cmd.Connection.Close();
                    //dt.Rows[i]["TracingNo"]
                }
            }
            catch (Exception e)
            {
                AddtoLog(e.Message);
                dt = null;
                //throw;
            }
            return dt;
        }

        public bool SqlExecuteNonQuery(string queryString,SqlParameter[] parameters, int timeoutValue=0)
        {
            bool result = false;
            //string connetionString = sqlGetConnectionString();
            try
            {
                using (SqlCommand cmd = new SqlCommand(queryString, new SqlConnection(_connString)))
                {
                    cmd.Parameters.AddRange(parameters);
                    foreach (SqlParameter p in parameters)
                    {
                        if (p.Value==null)
                            p.Value = DBNull.Value;
                    }
                    if (timeoutValue > 0)
                        cmd.CommandTimeout = timeoutValue;
                    cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    result = true;
                }
            }
            catch (Exception e)
            {
                AddtoLog(e.Message);
                result = false;
                //throw;
            }
            return result;
        }



        public object ParseDataRow(DataRow rw,DataColumnCollection cols,string colName,object defaultVal,object outVal)
        {
            try
            {


                if (cols.Contains(colName))
                {
                    Type T = typeof(string);
                    if (outVal!=null)
                        T = outVal.GetType();

                    string sVal = rw[colName].ToString();

                    if (sVal.Length==0)
                        return  (defaultVal);


                    if (T == typeof(string))
                        return sVal;
                    else if (T == typeof(int))
                    {
                        int outValInt;
                        if (int.TryParse(sVal, out outValInt)) return outValInt; else return defaultVal;
                        
                    }
                    else if (T == typeof(long))
                    {
                        long outValLong;
                        if (long.TryParse(sVal, out outValLong)) return outValLong; else return defaultVal;
                    }
                    else if (T == typeof(decimal))
                    {
                        decimal outValDecimal;
                        if (decimal.TryParse(sVal, out outValDecimal)) return outValDecimal; else return defaultVal;
                    }
                    else if (T == typeof(double))
                    {
                        double outValDouble;
                        if (double.TryParse(sVal, out outValDouble)) return outValDouble; else return defaultVal;
                    }
                    else if (T == typeof(float))
                    {

                        float outValFloat;
                        if (float.TryParse(sVal, out outValFloat)) return outValFloat; else return defaultVal;

                    }
                    else if (T == typeof(DateTime))
                    {
                        DateTime outValDateTime=new DateTime();
                        if (DateTime.TryParse(sVal, out outValDateTime)) return outValDateTime; else return defaultVal;
                    }

                    else
                    {
                        return rw[colName].ToString();
                    }

                }
                else
                {
                    return defaultVal;
                }
            }
            catch (Exception e)
            {

                sqlInterface.log(e.Source.ToString()+":"+e.Message.ToString());
                return defaultVal;
                //throw;
            }
        }




        
        public bool AddDataToDatabse(DataTable dt, string databaseTableName, Tuple<string, object>[] coloumnsToAdd, bool Replace = false)
        {

            try
            {

                int cnt = 0;
                // columns added at vtoc, can not add information  to data. so we don't need to include them in condition string.
                // in this manner, we can omit the repeatitive data (with the same info, and just different time-stamp)
                List<string> columnsNotToIncludeInCondition = new List<string>();
                foreach (Tuple<string, object> ent in coloumnsToAdd)
                {
                    string coloumnName = ent.Item1.ToString();

                    object coloumnVal = ent.Item2;
                    Type coloumnType = coloumnVal.GetType();
                    if (coloumnName.Length > 0)
                    {
                        columnsNotToIncludeInCondition.Add(coloumnName);
                        cnt++;

                        dt.Columns.Add(coloumnName, coloumnType);
                        foreach (DataRow rw in dt.Rows)
                            rw[coloumnName] = coloumnVal;
                    }
                    AddtoLog("Coloumn Named " + coloumnName + " added to " + databaseTableName);
                }

                //return AddDataToDatabse(dt, databaseTableName, columnsNotToIncludeInCondition, Replace);
                return AddDataToDatabse2(dt, databaseTableName, true, new List<string>(),new List<string>());//, columnsNotToIncludeInCondition);

            }
            catch (Exception e)
            {

                throw;
            }
        }
        /*
        public bool AddDataToDatabse(DataTable dt, string dabaseTableName, bool Replace = false)
        {
            List<string> columnsNotToIncludeInCondition = new List<string>();
            return (AddDataToDatabse(dt, dabaseTableName, columnsNotToIncludeInCondition, Replace));
        }
        
        
        public bool AddDataToDatabse(DataTable dt, string dabaseTableName, List<string> columnsNotToIncludeInCondition, bool Replace = false)
        {
            try
            {

                bool updateContentsWasSuccessful = false;

                string thissqlcmd = string.Empty;
                DataTable myTableSchema = CompareAndUpdateTablesReturnFinalSchema(dt, dabaseTableName);
                // in case it returns multiple rows (which is unusual), we need to process all the rows:

                // if Replace==true, clear all data first
                if (Replace)
                {
                    thissqlcmd = "DELETE FROM [dbo].[" + dabaseTableName + "]";
                    SqlExecuteNonQuery(thissqlcmd);
                }

                foreach (DataRow tmpRW in dt.Rows)
                {
                    //AddtoLog(" Adding new row to table named: " + dabaseTableName);

                    // add this new statement to database
                    // INSERT INTO table_name (column1, column2, column3,...)
                    // VALUES (value1, value2, value3,...)
                    // BUILD SQL INSERT INTO systax from schemaTable
                    #region build SQL INSERT command, and execute it
                    string valStr = "";
                    string parStr = "";
                    string ConditionStr = "";
                    //string ConditionParStr = "";
                    foreach (DataRow SchemaRW in myTableSchema.Rows)
                    {
                        string DataType = SchemaRW["DataTypeName"].ToString();
                        string DataName = SchemaRW["ColumnName"].ToString();

                        bool excludeThisDataNameFromCondition = columnsNotToIncludeInCondition.Contains(DataName);

                        if (tmpRW[DataName].ToString().Length > 0)
                        // in some cases, the contents were empty "ToString().Length<0", so don't bother adding this tmpRW[DataName] to quiert in this case.
                        {
                            if (DataType.Contains("char"))
                            {
                                valStr += "N'" + tmpRW[DataName] + "', ";

                                if (excludeThisDataNameFromCondition == false) ConditionStr += "[" + DataName + "]" + "= N'" + tmpRW[DataName] + "' AND ";
                            }
                            else if (DataType.Contains("bit"))
                            {
                                if (tmpRW[DataName].ToString() == "false")
                                {
                                    valStr += "0, ";
                                    if (excludeThisDataNameFromCondition == false) ConditionStr += "[" + DataName + "]" + "=0 AND ";
                                }
                                else
                                {
                                    valStr += " 1, ";
                                    if (excludeThisDataNameFromCondition == false) ConditionStr += "[" + DataName + "]" + "= 1 AND ";
                                }
                            }
                            else
                            {

                                    valStr += "N'" + tmpRW[DataName] + "', ";
                                    if (excludeThisDataNameFromCondition == false) ConditionStr += "[" + DataName + "]" + "= N'" + tmpRW[DataName] + "' AND ";
                            }

                            parStr += "[" + DataName + "], ";
                            //valStr=valStr.Replace(":",")
                        }
                        //}

                    }
                    valStr = valStr.TrimEnd(',', ' ');
                    parStr = parStr.TrimEnd(',', ' ');
                    //ConditionStr=ConditionStr.TrimEnd(',',' ');
                    ConditionStr = ConditionStr.Remove(ConditionStr.Length - 4);

                    thissqlcmd = "IF NOT EXISTS (SELECT * FROM  [dbo].[" + dabaseTableName + "] WHERE " + ConditionStr + ")"
                                                                + "\n BEGIN"
                                                                + "\n INSERT INTO [dbo].[" + dabaseTableName + "] (" + parStr + ") "
                                                                + "\n VALUES (" + valStr + ")"
                                                                + "\n END";
                    SqlExecuteNonQuery(thissqlcmd);
                    updateContentsWasSuccessful = true;
                    #endregion build SQL INSERT command, and execute it
                } //foreach (DataRow tmpRW in myTb.Rows)

                AddtoLog(dt.Rows.Count + " rows of data added to " + dabaseTableName + " in database");
                return updateContentsWasSuccessful;

            }
            catch (Exception e)
            {
                AddtoLog(e.Message);
                throw;
                return false;
            }
        }
        */

        public static DataTable ConvertDictionaryToDataTable(Dictionary<string, string> input)
        {
            DataTable dt = new DataTable();
            foreach (KeyValuePair<string, string> keyValuePair in input)
            {
                if (!dt.Columns.Contains(keyValuePair.Key))
                    dt.Columns.Add(keyValuePair.Key);
            }

            DataRow dr=dt.NewRow();

            foreach (KeyValuePair<string, string> keyValuePair in input)
            {
                dr[keyValuePair.Key] = keyValuePair.Value;
            }
            //dt.ImportRow(dr);
            dt.Rows.Add(dr);
            return dt;
        }
        
        public bool AddDataToDatabse2(DataRow receivedDRW, string databaseTableName,bool useUniqueIndexKeysForUpdateInsertCondition, List<string> columnsToInsertUpdateIfValuesChanged, List<string> columnsNotToIncludeInCondition, bool OnlyInsert = false, string databaseName = "", string schemaName = "")
        {

            DataTable dt=new DataTable();
            if (receivedDRW != null)
            {
                var dt2 = receivedDRW.Table;
                return (AddDataToDatabse2(dt2, databaseTableName, useUniqueIndexKeysForUpdateInsertCondition,columnsToInsertUpdateIfValuesChanged, columnsNotToIncludeInCondition, OnlyInsert, databaseName, schemaName));
            }
            else
                return false;
        }

        public bool AddDataToDatabse2(DataTable receivedDt, string databaseTableName,bool useUniqueIndexKeysForUpdateInsertCondition, List<string> columnsToInsertUpdateIfValuesChanged,List<string> columnsNotToIncludeInCondition, bool OnlyInsert = false,string databaseName="",string schemaName="")
        {
            try
            {
                if (receivedDt == null || receivedDt.Rows.Count == 0 || receivedDt.Columns.Count == 0)
                    return false;

                DataTable myTableSchema = CompareAndUpdateTablesReturnFinalSchema(receivedDt, databaseTableName,
                                                                                  databaseName, schemaName);


                if (myTableSchema == null)
                    return false;

                bool updateContentsWasSuccessful = false;

                // convert  columnsNotToIncludeInCondition to lowerCase
                for (int i = 0; i < columnsNotToIncludeInCondition.Count; i++)
                {
                    columnsNotToIncludeInCondition[i] = columnsNotToIncludeInCondition[i].ToLower().Trim();
                }


                // build columnsToInsertUpdateIfValuesChanged: if useUniqueIndexKeysForUpdateInsertCondition==true, use unique index keys, else use the input list 
                if (useUniqueIndexKeysForUpdateInsertCondition==true)
                {
                    var l1=GetUniqueIndexKeys(databaseTableName, databaseName, schemaName);
                    if (l1.Count > 0)
                    {
                        columnsToInsertUpdateIfValuesChanged.Clear();
                        columnsToInsertUpdateIfValuesChanged.AddRange(l1);
                    }
                }

                if (columnsToInsertUpdateIfValuesChanged.Count > 0)
                {
                    for (int i = 0; i < columnsToInsertUpdateIfValuesChanged.Count; i++)
                    {
                        columnsToInsertUpdateIfValuesChanged[i] = columnsToInsertUpdateIfValuesChanged[i].ToLower().Trim();
                    }
                }
                else
                    // if columnsToInsertUpdateIfValuesChanged is emtpy, assume all columns should be inserted (except for those which are in  "columnsNotToIncludeInCondition")
                {
                    foreach (DataRow _SchemaRW in myTableSchema.Rows)
                    {
                        columnsToInsertUpdateIfValuesChanged.Add(_SchemaRW["ColumnName"].ToString().ToLower().Trim());
                    }
                }

                string databaseNameM=string.Empty;
                string schemaNameM=string.Empty;
                if (databaseName.Length > 1)
                    databaseNameM = "[" + databaseName + "].";
                else databaseNameM = "";

                if (schemaName.Length > 1)
                    schemaNameM = "[" + schemaName + "].";
                else schemaNameM = "[dbo].";




                foreach (DataRow tmpRW in receivedDt.Rows)
                {
                    // for each row in received table, build the INSERT/UPDATE SQL statement.
                    // BUILD SQL INSERT INTO systax from schemaTable

                    #region build SQL INSERT command, and execute it

                    string valStr = string.Empty;
                    string updateStr = string.Empty;
                    string parStr = string.Empty;
                    string ConditionStr = string.Empty;

                    foreach (DataRow SchemaRW in myTableSchema.Rows)
                    {
                        string DataType = SchemaRW["DataTypeName"].ToString();
                        string DataName = SchemaRW["ColumnName"].ToString();

                        bool IncludeThisColumnNameInExistingConditionTest =
                            columnsToInsertUpdateIfValuesChanged.Contains(DataName.ToLower());
                        IncludeThisColumnNameInExistingConditionTest = IncludeThisColumnNameInExistingConditionTest &&
                                                                       !columnsNotToIncludeInCondition.Contains(
                                                                           DataName.ToLower());

                        if (tmpRW[DataName].ToString().Length > 0)
                            // in some cases, the contents were empty "ToString().Length<0", so don't bother adding this tmpRW[DataName] to quiery in this case.
                        {
                            if (DataType.Contains("char"))
                            {
                                string myStr = "N'" + tmpRW[DataName] + "', ";
                                valStr += myStr;
                                updateStr += "[" + DataName + "]=" + myStr;
                                if (IncludeThisColumnNameInExistingConditionTest)
                                    ConditionStr += "[" + DataName + "]" + "= N'" + tmpRW[DataName] + "' AND ";
                            }
                            else if (DataType.Contains("bit"))
                            {
                                if (tmpRW[DataName].ToString() == "false")
                                {
                                    const string myStr = "0, ";
                                    valStr += myStr;
                                    updateStr += "[" + DataName + "]=" + myStr;
                                    if (IncludeThisColumnNameInExistingConditionTest)
                                        ConditionStr += "[" + DataName + "]" + "= 0 AND ";
                                }
                                else
                                {
                                    const string myStr = " 1, ";
                                    valStr += myStr;
                                    updateStr += "[" + DataName + "]=" + myStr;
                                    if (IncludeThisColumnNameInExistingConditionTest)
                                        ConditionStr += "[" + DataName + "]" + "= 1 AND ";
                                }
                            }
                            else
                            {

                                string myStr = "N'" + tmpRW[DataName] + "', ";
                                valStr += myStr;
                                updateStr += "[" + DataName + "]=" + myStr;
                                if (IncludeThisColumnNameInExistingConditionTest)
                                    ConditionStr += "[" + DataName + "]" + "= N'" + tmpRW[DataName] + "' AND ";
                            }

                            parStr += "[" + DataName + "], ";
                        }

                    }
                    valStr = valStr.TrimEnd(',', ' ');
                    parStr = parStr.TrimEnd(',', ' ');
                    updateStr = updateStr.Trim(',', ' ');
                    //ConditionStr=ConditionStr.TrimEnd(',',' ');
                    if (ConditionStr.Length>=4)
                        ConditionStr = ConditionStr.Remove(ConditionStr.Length - 4);


                    string thissqlcmd = string.Empty;
                    if (OnlyInsert)
                    {
                        thissqlcmd = "IF NOT EXISTS"
                                     + " (SELECT * FROM  " + databaseNameM + schemaNameM + "[" + databaseTableName +
                                     "] WHERE " +
                                     ConditionStr + ")"
                                     + "\n  BEGIN"
                                     + "\n   INSERT INTO " + databaseNameM + schemaNameM + "[" + databaseTableName + "] (" +
                                     parStr + ") "
                                     + "\n   VALUES (" + valStr + ")"
                                     + "\n  END";
                    }
                    else // insert and also update if already exists
                    {
                        thissqlcmd = "IF NOT EXISTS"
                                     + " (SELECT * FROM " + databaseNameM + schemaNameM + "[" + databaseTableName +
                                     "] WHERE " +
                                     ConditionStr + ")"
                                     + "\n  BEGIN"
                                     + "\n   INSERT INTO " + databaseNameM + schemaNameM + "[" + databaseTableName + "] (" +
                                     parStr + ") "
                                     + "\n   VALUES (" + valStr + ")"
                                     + "\n  END"
                                     + "\n ELSE"
                                     + "\n  BEGIN"
                                     + "\n   UPDATE " + databaseNameM + schemaNameM + "[" + databaseTableName + "]"
                                     + "\n   SET " + updateStr
                                     + "\n   WHERE " + ConditionStr
                                     + "\n  END";
                    }

                    SqlExecuteNonQuery(thissqlcmd,new SqlParameter[0]);
                    updateContentsWasSuccessful = true;

                    #endregion build SQL INSERT command, and execute it
                } //foreach (DataRow tmpRW in myTb.Rows)

                AddtoLog(receivedDt.Rows.Count + " rows of data added to " + databaseTableName + " in database");
                return updateContentsWasSuccessful;

            }
            catch (Exception e)
            {
                AddtoLog(e.Message);
                //throw;
                return false;
            }
        }

        // Uses the table received (from web-service) and gets its name
        // if such a table does not exist in database, create one
        // if table exists, checks for columns. if there is a column in received table but not in database table, add that column to database table.
        // finally returns a data-table schema to be used for replacing the related data, only columns within receivedTable are returned.
        
        private DataTable CompareAndUpdateTablesReturnFinalSchema(DataTable receivedTable, string existingTableName,string databaseName="",string schemaName="")
        {
            try
            {

                // for a table in database, the data schema is derived, containing the type and name of columns
                // for a data table received (from web-service), the rw contains the name of column.
                // this function has to check and see if all columns in rw exist in database table, and if not, add it with appropriate data type.
                // the return value, contains the number of added columns.
                // first check to see if such table exists in database, and create it if not:

                # region Creat databaseTableName table if does not exist on database

                string databaseNameM = string.Empty;
                string schemaNameM = string.Empty;
                if (databaseName.Length > 0)
                    databaseNameM = "[" + databaseName + "].";
                else databaseNameM = "";

                if (schemaName.Length > 0)
                    schemaNameM = "[" + schemaName + "].";
                else schemaNameM = "[dbo].";

                string thissqlcmd = string.Format(
                                @"IF NOT EXISTS (SELECT * FROM {1}{2}sysobjects WHERE NAME=N'{0}') 
                                     BEGIN
                                        CREATE TABLE {1}{2}[{0}]
                                            ([id] [bigint] IDENTITY(1,1) NOT NULL,
                                                CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED 
                                                (
	                                                [id] ASC
                                                )
                                        ) ON [PRIMARY]                                        
                                     END", existingTableName,databaseNameM,schemaNameM);
                SqlExecuteNonQuery(thissqlcmd,new SqlParameter[0]);

                #endregion

                // then fetch a row from Statements table in database to get the table schema:

                #region get Table schema

                DataTable databaseTableSchema = null;
                try
                {
                    using (
                        SqlCommand cmd = new SqlCommand("SELECT TOP(1) * FROM "+databaseNameM+schemaNameM+"[" + existingTableName + "]",
                                                        new SqlConnection(_connString)))
                    {
                        cmd.Connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        databaseTableSchema = rdr.GetSchemaTable();

                        rdr.Close();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception e)
                {
                    AddtoLog(e.Message);
                }

                #endregion

                // now "databaseTableSchema" contains table schema in database

                // check to see if all rows from web-service exists in database table (tb is the table retrieved from web-service)
                string receivedTableColumnNames = "";
                //webserviceTB.DataSet.Tables[0].Columns[0].data

                #region add coloumns if not exist in table

                foreach (DataColumn clm in receivedTable.Columns)
                {
                    
                    string receivedTableColumnName = clm.ColumnName;
                    Type receivedTableColumnType = clm.DataType;
                    receivedTableColumnNames += "[" + receivedTableColumnName + "], ";
                    // check all columns in database table, to see if any one matches with this column in table from web-service
                    bool found = false;
                    foreach (DataRow SchemaRW in databaseTableSchema.Rows)
                    {
                        if (SchemaRW["ColumnName"].ToString().ToLower() == receivedTableColumnName.ToLower())
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        // not found; it is a new column, so add this to the table in database.
                        string sqlDBdataType = ConvertSqlToType(receivedTableColumnType);
                        thissqlcmd = "ALTER TABLE "+databaseNameM+schemaNameM+"[" + existingTableName + "] ADD [" + receivedTableColumnName +"] " + sqlDBdataType;
                        SqlExecuteNonQuery(thissqlcmd,new SqlParameter[0]);
                        AddtoLog("added column named: " + receivedTableColumnName + "of type " + sqlDBdataType + " to " +
                                 existingTableName + " table");
                    }

                }

                #endregion

                receivedTableColumnNames = receivedTableColumnNames.TrimEnd(',', ' ');
                // get final schema to return:

                #region get Table schema

                DataTable FinalSchema = new DataTable("Schema");
                try
                {
                    using (
                        SqlCommand cmd =
                            new SqlCommand(
                                "SELECT TOP (1) " + receivedTableColumnNames + " FROM "+databaseNameM+schemaNameM+"[" + existingTableName +"]",
                                new SqlConnection(_connString)))
                    {
                        cmd.Connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        FinalSchema = rdr.GetSchemaTable();

                        rdr.Close();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception e)
                {
                    AddtoLog(e.Message);

                }

                #endregion

                return FinalSchema;

            }
            catch (Exception e)
            {
                AddtoLog(e.Source.ToString()+": "+e.Message.ToString());
                return null;
                //throw;// log(e.Message);
            }
        }

        private List<string> GetUniqueIndexKeys(string databaseTableName, string databaseName = "", string schemaName = "")
        {
            try
            {
                string databaseNameM = string.Empty;
                string schemaNameM = string.Empty;
                if (databaseName.Length > 0)
                    databaseNameM = "[" + databaseName + "].";
                else databaseNameM = "";

                if (schemaName.Length > 0)
                    schemaNameM = "[" + schemaName + "].";
                else schemaNameM = "[dbo].";

                string thissqlcmd = string.Format(
                    @" IF EXISTS (SELECT * FROM {0}{1}sysobjects WHERE NAME=N'{2}')
	            BEGIN
		            EXEC {0}{1}sp_helpindex N'{2}'
	            END",
                    databaseNameM, schemaNameM, databaseTableName);
                DataTable myDt4123 = SqlExecuteReader(thissqlcmd,new SqlParameter[0]);
                string listOfIndexKeys = string.Empty;
                if (myDt4123 != null && myDt4123.Rows.Count > 0 && myDt4123.Columns.Contains("index_description") &&
                    myDt4123.Columns.Contains("index_keys"))
                {
                    foreach (DataRow _row in myDt4123.Rows)
                    {
                        if (_row["index_description"].ToString().ToLower().Contains("unique") &&
                            !(_row["index_description"].ToString().ToLower().Contains("primary key")))
                        {
                            listOfIndexKeys = _row["index_keys"].ToString();
                            break;
                        }
                    }
                }

                if (listOfIndexKeys.Length < 1)
                    return new List<string>();
                else
                {
                    return (listOfIndexKeys.Trim().TrimEnd(',').Split(',').ToList());

                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }
        }

        private static string ConvertSqlToType(System.Type columnDataType)
        {
            try
            {

                
                //SqlDbType sqlDbType;
                string sqlDbType;
                switch (columnDataType.UnderlyingSystemType.Name.ToLower())
                {
                    case "int32":
                        sqlDbType = "int";
                        break;
                    case "int64":
                        sqlDbType = "bigint";
                        break;
                    case "string":
                        sqlDbType = "nvarchar(512)";
                        break;
                    case "byte":
                        sqlDbType = "tinyint";
                        break;
                    case "bit":
                        sqlDbType = "bit";
                        break;
                    case "bool":
                        sqlDbType = "bit";
                        break;
                    case "decimal":
                        sqlDbType = "decimal(20,4)";
                        break;
                    case "double":
                        sqlDbType = "real";
                        break;
                    case "float":
                        sqlDbType = "float";
                        break;
                    case "date":
                        sqlDbType = "date";
                        break;
                    case "datetime":
                        sqlDbType = "datetime";
                        break;
                    case "unsignedbyte":
                        sqlDbType = "tinyint";
                        break;
                    case "unsignedint":
                        sqlDbType = "smallint";
                        break;
                    case "short":
                        sqlDbType = "smallint";
                        break;
                    case "base64Binary":
                        sqlDbType = "binary";
                        break;



                    default:
                        sqlDbType = "nvarchar(MAX)";
                        break;
                }
                return sqlDbType;
            }



            catch (Exception e)
            {
                //AddtoLog(e.Source.ToString() + ": " + e.Message.ToString());
                return "nvarchar(MAX)";
                //throw;
            }
        }

    }

    public class Settings2File
    {
        private Dictionary<String, String> list;
        private String filename;

        public Settings2File(String file)
        {
            reload(file);
        }

        public String get(String field, String defValue)
        {
            return (get(field) == null) ? (defValue) : (get(field));
        }
        public String get(String field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

        public void set(String field, Object value)
        {
            if (!list.ContainsKey(field))
                list.Add(field, value.ToString());
            else
                list[field] = value.ToString();
        }

        public void Save()
        {
            Save(this.filename);
        }

        public void Save(String filename)
        {
            try
            {


                
                this.filename = filename;

                if (!System.IO.File.Exists(filename))
                    System.IO.File.Create(filename);

                System.IO.StreamWriter file = new System.IO.StreamWriter(filename);

                foreach (String prop in list.Keys.ToArray())
                    if (!String.IsNullOrWhiteSpace(list[prop]))
                        file.WriteLine(prop + "=" + list[prop]);

                file.Close();
            }
            catch (Exception e)
            {
                //AddtoLog(e.Source.ToString() + ": " + e.Message.ToString());
                //throw;
            }
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(String filename)
        {
            try
            {
              

                this.filename = filename;
                list = new Dictionary<String, String>();

                if (System.IO.File.Exists(filename))
                    loadFromFile(filename);
                else
                    System.IO.File.Create(filename);

            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void loadFromFile(String file)
        {
            foreach (String line in System.IO.File.ReadAllLines(file))
            {
                if ((!String.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    String key = line.Substring(0, index).Trim();
                    String value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    try
                    {
                        //ignore dublicates
                        list.Add(key, value);
                    }
                    catch { }
                }
            }
        }


    }
}
