using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for Admin_TradeClass
/// </summary>
public class Admin_TradeClass
{
    public string Trade_Code;
    public string Paper_Code;
    public string Pre_Paper_Code;
    public string Seller_Code;
    public string Seller_Name;
    public string Buyer_Code;
    public string Buyer_Name;
    public string Price;


	public Admin_TradeClass()
	{
		
	}

    public static List<Admin_TradeClass> LoadByBuyerSeller(string _Buyer_Code, string _Seller_Code)
    {
        List<Admin_TradeClass> S = new List<Admin_TradeClass>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            List<SqlParameter> parameters = new List<SqlParameter>();
            var Buyer_Code  = new SqlParameter("@Buyer_Code", SqlDbType.NVarChar);
            Buyer_Code.Value = _Buyer_Code;
            parameters.Add(Buyer_Code);

            var Seller_Code = new SqlParameter("@Seller_Code", SqlDbType.NVarChar);
            Seller_Code.Value = _Seller_Code;
            parameters.Add(Seller_Code);

            string WHStr = "";
            if (_Buyer_Code != "" || _Seller_Code != "")
            {
                WHStr = " WHERE ";

                if (_Buyer_Code.Trim() != "")
                {
                    if (_Seller_Code.Trim() != "")
                    {
                        WHStr += " M.User_Code = @Buyer_Code AND N.User_Code @Seller_Code ";
                    }
                    else
                    {
                        WHStr += " M.User_Code = @Buyer_Code ";
                    }
                }
                else
                {
                    WHStr += " N.User_Code = @Seller_Code ";
                }
            }

            sqlCmd1 = String.Format(@"SELECT T.Trade_Code, T.Paper_Code, T.Data3, N.User_Code SellerCode, (N.FFName + ' ' + N.FLName) SellerName, M.User_Code BuyerCode, (M.FFName + ' ' + M.FLName) BuyerName, T.Price_Final  FROM [dbo].Trades T
                                    LEFT JOIN [dbo].[PaperList] F ON F.Paper_Code = T.Paper_Code
                                    LEFT JOIN [dbo].[Users] N ON N.User_Code = F.Owner_Code
                                    LEFT JOIN [dbo].[Users] M ON M.User_Code = T.Buyer_Code
                                    {0}", WHStr);

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1,parameters.ToArray());
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Admin_TradeClass newHW = new Admin_TradeClass();                    
                    newHW.Trade_Code = r[0].ToString();
                    newHW.Paper_Code = r[1].ToString();
                    newHW.Pre_Paper_Code = r[2].ToString();
                    newHW.Seller_Code = r[3].ToString();
                    newHW.Seller_Name = r[4].ToString();
                    newHW.Buyer_Code = r[5].ToString();
                    newHW.Buyer_Name = r[6].ToString();
                    newHW.Price = r[7].ToString();
                    
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