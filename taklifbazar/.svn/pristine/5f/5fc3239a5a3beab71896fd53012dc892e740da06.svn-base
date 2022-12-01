using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vtocSqlInterface;


public class tb_Transactions
{
    public int RN;
    public string Transaction_Code;
    public string Trade_Code;
    public string User_Code;
    public Transaction_Type Trans_Type;
    public string Trans_Subject;
    public string Amount;
    public InOut_Type InOut; //In:1; Out:0
    public CurrentAccount_Type CurAcc_Type;
    public string User_IP;
    public Bank_Name BN_Portal;
    public string BN_Source;
    public string AccBalance;

    private sqlInterface mySql;
    private string sqlCmd;

    public tb_Transactions()
	{
		
	}

    public string Transaction_Add()
    {
        string TCode = DateTime.Now.Ticks.ToString();
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"INSERT dbo.Transactions VALUES ('{0}', '{1}', '{2}', {3}, N'{4}', {5}, {6}, {7}, '{8}', {9}, N'{10}', {11}, {12}, {13}, '{14}', '{15}')", TCode, Trade_Code, User_Code, ((int)Trans_Type).ToString(), Trans_Subject, Amount, ((int)CurAcc_Type).ToString(), ((int)InOut).ToString(), User_IP, ((int)BN_Portal).ToString(), BN_Source, AccBalance, 0, 0, "", "");
        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return TCode;
        else return "";    
    }

    public static List<tb_Transactions> LoadByUser(string UCode)
    {
        List<tb_Transactions> S = new List<tb_Transactions>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd1 = "SELECT T.*  FROM [PaperBank].[dbo].[Transactions] T WHERE T.User_Code = '" + UCode + "' ORDER BY T.Transaction_Code DESC";

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    tb_Transactions newTR = new tb_Transactions();
                    newTR.RN = i; i++;
                    newTR.Transaction_Code = r[0].ToString();
                    newTR.Trade_Code = r[1].ToString();
                    newTR.User_Code = r[2].ToString();
                    newTR.Trans_Type = (Transaction_Type)(Convert.ToInt32(r[3].ToString()));
                    newTR.Trans_Subject = r[4].ToString();
                    newTR.Amount = r[5].ToString();
                    newTR.CurAcc_Type = (CurrentAccount_Type)(Convert.ToInt32(r[6].ToString()));
                    newTR.InOut = (InOut_Type)(Convert.ToInt32(r[7].ToString()));
                    newTR.User_IP = r[8].ToString();
                    newTR.BN_Portal = (Bank_Name)(Convert.ToInt32(r[9].ToString()));
                    newTR.BN_Source = r[10].ToString();
                    newTR.AccBalance = r[11].ToString();
                    S.Add(newTR);
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

public enum Transaction_Type{
    Buy = 0,
    Sell = 1,
    Settle = 2,
    Add = 3,
    Trade = 4
}

public enum CurrentAccount_Type{
    Local = 0,
    Bank = 1
}

public enum InOut_Type
{
    Out = 0,
    In = 1
}