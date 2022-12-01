using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vtocSqlInterface;


public class tb_Trades
{
    public string Trade_Code;
    public string Pre_Trade_Code;
    public string Paper_Code;
    public string Buyer_Code;
    public string Price_Prim;
    public string Discount;
    public string Price_Final;
    public string TB_Rate;
    public Int32 Data1;
    public Int32 Data2;
    public string Data3;
    public string Data4;

    private sqlInterface mySql;
    private string sqlCmd;

	public tb_Trades()
	{
		
	}
    
    public string Trade_Add()
    {
        //[Trade_Code],[Pre_Trade_Code],[Paper_Code],[Buyer_Code],[Price_Prim],[Discount],[Price_Final],[TB_Rate],[Data1],[Data2],[Data3],[Data4]
        string TCode = DateTime.Now.Ticks.ToString();
        Pre_Trade_Code = Encryption.GetUniqueKey(8);
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"INSERT dbo.Trades VALUES ( '{0}',     '{1}',        '{2}',       '{3}',       {4},      {5},        {6},       {7},   {8},    {9}, N'{10}', N'{11}')",
                                                            TCode, Pre_Trade_Code, Paper_Code, Buyer_Code, Price_Prim, Discount, Price_Final, TB_Rate, Data1, Data2, Data3, Data4);
        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return TCode;
        else return "";        
    }


}