using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        List<SqlParameter> parameters = new List<SqlParameter>();

        var p = new SqlParameter("@TCode", SqlDbType.NVarChar);
        p.Value = TCode;
        parameters.Add(p);

        p = new SqlParameter("@Pre_Trade_Code", SqlDbType.NVarChar);
        p.Value = Pre_Trade_Code;
        parameters.Add(p);

        p = new SqlParameter("@Paper_Code", SqlDbType.NVarChar);
        p.Value = Paper_Code;
        parameters.Add(p);

        p = new SqlParameter("@Buyer_Code", SqlDbType.NVarChar);
        p.Value = Buyer_Code;
        parameters.Add(p);

        p = new SqlParameter("@Price_Prim", SqlDbType.NVarChar);
        p.Value = Price_Prim;
        parameters.Add(p);

        p = new SqlParameter("@Discount", SqlDbType.NVarChar);
        p.Value = Discount;
        parameters.Add(p);

        p = new SqlParameter("@Price_Final", SqlDbType.NVarChar);
        p.Value = Price_Final;
        parameters.Add(p);

        p = new SqlParameter("@TB_Rate", SqlDbType.NVarChar);
        p.Value = TB_Rate;
        parameters.Add(p);

        p = new SqlParameter("@Data1", SqlDbType.NVarChar);
        p.Value = Data1;
        parameters.Add(p);

        p = new SqlParameter("@Data2", SqlDbType.NVarChar);
        p.Value = Data2;
        parameters.Add(p);

        p = new SqlParameter("@Data3", SqlDbType.NVarChar);
        p.Value = Data3;
        parameters.Add(p);

        p = new SqlParameter("@Data4", SqlDbType.NVarChar);
        p.Value = Data4;
        parameters.Add(p);

        sqlCmd = string.Format(@"INSERT dbo.Trades VALUES ( {0},     {1},        {2},       {3},       {4},      {5},        {6},       {7},   {8},    {9}, {10}, {11})",
                                                            "@TCode", "@Pre_Trade_Code", "@Paper_Code", "@Buyer_Code", "@Price_Prim", "@Discount", "@Price_Final", "@TB_Rate", "@Data1", "@Data2", "@Data3", "@Data4");
        if (mySql.SqlExecuteNonQuery(sqlCmd,parameters.ToArray()))
            return TCode;
        else return "";        
    }


}