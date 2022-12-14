using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for tb_FinancialAcc
/// </summary>
public class tb_FinancialAcc
{
    public string User_Code;
    public string Amount;
    public string LastTransaction;

    private sqlInterface mySql;
    private string sqlCmd;

	public tb_FinancialAcc()
	{
		
	}

    public tb_FinancialAcc(string UCode)
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
        sqlCmd = string.Format(@"SELECT * FROM [dbo].[Financial_Acc] T WHERE T.User_Code='{0}'", UCode);

        DataTable tmpDT = new DataTable();
        tmpDT = mySql.SqlExecuteReader(sqlCmd);
        if (tmpDT.Rows.Count > 0)
        {
            User_Code = UCode;
            Amount = tmpDT.Rows[0][1].ToString();
            LastTransaction = tmpDT.Rows[0][2].ToString();            
        }        
    }

    public bool Update()
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"UPDATE [dbo].[Financial_Acc] SET [Amount] = {0},[LastTransaction] = '{1}',[Data1] = {2},[Data2] = {3},[Data3] = '{4}',[Data4] = '{5}' WHERE [User_Code] = '{6}'", Amount, LastTransaction, 0, 0, "", "", User_Code);

        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return true;
        else return false;
    }

    public bool Add(string UCode)
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"INSERT dbo.Financial_Acc VALUES ('{0}', 0, '', 0, 0, '', '')", UCode);
        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return true;
        else return false;
    }


}