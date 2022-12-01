using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for Admin_UserClass
/// </summary>
public class Admin_UserClass
{
    public int RN;
    public string User_Code;
    public string FFName;
    public string FLName;
    public string EFName;
    public string ELName;
    public int HW_Count;
    public Int32 HW_Sell;
    public Int32 HW_Buy;
    public Int32 AccBal;



	public Admin_UserClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Admin_UserClass> LoadUsers(string[] Tags, User_List_OrderBy OB, List_OrderType OT)
    {
        List<Admin_UserClass> SU = new List<Admin_UserClass>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            List<SqlParameter> parameters = new List<SqlParameter>();
            var i = 0;

            bool HasTag = false;
            if (Tags != null)
                if (Tags.Length > 0 && Tags[0].Trim() != "") HasTag = true;

            string WhereStr = "";
            if (HasTag)
            {
                WhereStr = " WHERE (";
                foreach (string a in Tags)
                    if (a.Trim() != "")
                    {
                        var p = new SqlParameter("@k" + i, SqlDbType.NVarChar);
                        p.Value = a;
                        parameters.Add(p);

                        WhereStr = "(T0.FFName + ' ' + T0.FLName) LIKE '%' + @k"+i+" + '%' OR (T0.EFName + ' ' + T0.ELName) LIKE '%' + @k"+i+" + '%' OR T0.User_Code LIKE '%' + @k"+i+" + '%' OR ";
                        i++;
                    }
                WhereStr = WhereStr.Substring(0, WhereStr.Length - 3);
                WhereStr += ") ";
            }
            string OrderByStr = "";
            switch (OB)
            {
                case User_List_OrderBy.Date:
                    OrderByStr = "ORDER BY T0.User_Code ";
                    break;
                case User_List_OrderBy.Name:
                    OrderByStr = "ORDER BY (T0.FFName + ' ' + T0.FLName) ";
                    break;
                case User_List_OrderBy.AccBal:
                    OrderByStr = "ORDER BY AccBal ";
                    break;
                case User_List_OrderBy.HW_Buy:
                    OrderByStr = "ORDER BY HW_Buy ";
                    break;
                case User_List_OrderBy.HW_Count:
                    OrderByStr = "ORDER BY HW_Count ";
                    break;
                case User_List_OrderBy.HW_Sell:
                    OrderByStr = "ORDER BY HW_Sell ";
                    break;                    
            }

            switch (OT)
            {
                case List_OrderType.Asc:
                    OrderByStr += "ASC";
                    break;
                case List_OrderType.Desc:
                    OrderByStr += "DESC";
                    break;
            }

            sqlCmd1 = String.Format(@"SELECT T0.User_Code, T0.FFName, T0.FLName, T0.EFName, T0.ELName, T1.Amount AccBal, T2.HW_Count, T3.HW_Sell, T4.HW_Buy
                                        FROM [dbo].[Users] T0
                                        LEFT JOIN [dbo].[Financial_Acc] T1 ON T1.User_Code = T0.User_Code
                                        LEFT JOIN (SELECT R.Owner_Code UCode, COUNT(R.Download_C) HW_Count FROM [dbo].[PaperList] R GROUP BY R.Owner_Code) T2 ON T2.UCode = T0.User_Code
                                        LEFT JOIN (SELECT SUM(K.Amount) HW_Sell, K.User_Code FROM [dbo].[Transactions] K WHERE K.Trans_Type=1 GROUP BY K.User_Code) T3 ON T3.User_Code = T0.User_Code
                                        LEFT JOIN (SELECT SUM(K.Amount) HW_Buy, K.User_Code FROM [dbo].[Transactions] K WHERE K.Trans_Type=0 GROUP BY K.User_Code) T4 ON T4.User_Code = T0.User_Code
                                        {0}
                                        {1}", WhereStr, OrderByStr);

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1,parameters.ToArray());
            i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Admin_UserClass newTR = new Admin_UserClass();
                    newTR.RN = i; i++;
                    newTR.User_Code = r[0].ToString();
                    newTR.FFName = r[1].ToString();
                    newTR.FLName = r[2].ToString();
                    newTR.EFName = r[3].ToString();
                    newTR.ELName = r[4].ToString();
                    newTR.AccBal = Convert.ToInt32(r[5].ToString());
                    newTR.HW_Count = Convert.ToInt32(r[6].ToString());
                    newTR.HW_Sell = Convert.ToInt32(r[7].ToString());
                    newTR.HW_Buy = Convert.ToInt32(r[8].ToString());
                    
                    SU.Add(newTR);
                }

            }

            return SU;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}

public enum User_List_OrderBy
{
    Date = 0,
    Name = 1,
    HW_Count = 2,
    HW_Sell = 3,
    HW_Buy = 4,
    AccBal = 5
}

