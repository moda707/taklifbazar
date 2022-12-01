using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for Admin_TransactionClass
/// </summary>
public class Admin_TransactionClass
{
    public string Transaction_Code;
    public string Trade_Code;
    public string User_Code;
    public string Pre_User_Code;
    public string User_Name;
    public string Subject;
    public string Amount;
    public CurrentAccount_Type CurAccType;
    public InOut_Type InOut;
    public Bank_Name BN_Portal;
    public string BN_Source;
    public Transaction_Type Trans_Type;


	public Admin_TransactionClass()
	{
		
	}

    public static List<Admin_TransactionClass> LoadByUser(string _User_Code, Transaction_List_ShowType _TLS)
    {
        List<Admin_TransactionClass> S = new List<Admin_TransactionClass>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            List<SqlParameter> parameters = new List<SqlParameter>();
            var User_Code = new SqlParameter("@User_Code", SqlDbType.NVarChar);
            User_Code.Value = _User_Code;
            parameters.Add(User_Code);


            string WhStr = "";
            string WhStr1 = "";
            if (_User_Code != "") WhStr1 = " T.User_Code = @User_Code  ";

            string WhStr2 = "";
            switch (_TLS)
            {
                case Transaction_List_ShowType.FromTB:
                    WhStr2 = " T.InOut = 1 AND T.Trans_Type = 1 ";
                    break;
                case Transaction_List_ShowType.ToTB:
                    WhStr2 = " T.InOut = 0 AND T.Trans_Type = 0 ";
                    break;
            }

            if (WhStr1 != "")
            {
                if (WhStr2 != "")
                {
                    WhStr = "WHERE " + WhStr1 + " AND " + WhStr2;
                }
                else
                {
                    WhStr = "WHERE " + WhStr1;
                }
            }
            else
            {
                if(WhStr2 != "")
                {
                    WhStr = "WHERE " + WhStr2;
                }
            }

            sqlCmd1 = String.Format(@"SELECT T.Transaction_Code, T.Trade_Code, T.User_Code, ISNULL((F.FFName + ' ' + F.FLName),' ') Name, T.Amount, T.Trans_Subject, T.CurAccount_Type, T.InOut, T.BN_Portal, T.BN_Source, T.Trans_Type, F.Pre_User_Code FROM [dbo].[Transactions] T LEFT JOIN [dbo].[Users] F ON F.User_Code = T.User_Code {0}", WhStr);



            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1,parameters.ToArray());            
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Admin_TransactionClass newHW = new Admin_TransactionClass();
                    newHW.Transaction_Code = r[0].ToString();
                    newHW.Trade_Code = r[1].ToString();
                    newHW.User_Code = r[2].ToString();
                    newHW.User_Name = r[3].ToString();
                    newHW.Amount = r[4].ToString();
                    newHW.Subject = r[5].ToString();
                    newHW.CurAccType = (CurrentAccount_Type)(Convert.ToInt32(r[6].ToString()));
                    newHW.InOut = (InOut_Type)(Convert.ToInt32(r[7].ToString()));
                    newHW.BN_Portal = (Bank_Name)(Convert.ToInt32(r[8].ToString()));
                    newHW.BN_Source = r[9].ToString();
                    newHW.Trans_Type = (Transaction_Type)(Convert.ToInt32(r[10].ToString()));
                    newHW.Pre_User_Code = r[11].ToString();

                    S.Add(newHW);
                }

            }

            return S;
        }
        catch (Exception e)
        {
            return null;
        }
    }


}

public enum Transaction_List_ShowType
{
    All = 0,
    ToTB = 1,
    FromTB = 2
}