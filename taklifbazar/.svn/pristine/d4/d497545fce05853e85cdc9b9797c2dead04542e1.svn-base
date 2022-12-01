using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for UPortalClass
/// </summary>
public class UPortalClass
{
    public LoginClass CurUser;
    public string ProfilePic;
    public int ProjCount;
    public Int32 FAcc;
    public int SellCount;
    public Int32 SellPriceCount;

    private sqlInterface mySql;
    private string sqlCmd;

	public UPortalClass(LoginClass LC)
	{
        CurUser = LC;

        //Get Profile Pic
        ProfilePic = "images/avatar.jpg";

        //Get HomeWorks info
        //SELECT COUNT(T.Owner_Code)  FROM [PaperBank].[dbo].[PaperList] T WHERE T.Owner_Code='111' AND T.Status = 0(should be 1)
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = "SELECT COUNT(T.Owner_Code)  FROM [PaperBank].[dbo].[PaperList] T WHERE T.Owner_Code='" + LC.User_Code + "' AND T.Status = " +((int)P_Status.Submitted).ToString();

        ProjCount = Convert.ToInt16(mySql.SqlExecuteReader(sqlCmd).Rows[0][0].ToString());
        
        //Get Sell information
        //Get from Factors Table, Number of Sells and the accumulated amount of sells
        SellCount = 0;
        SellPriceCount = 0;

        //Get From FinancialAccount Table, the Account Balance
        FAcc = 0;

	}

    public UPortalClass(string UCode)
    {
        //Get Profile Pic
        ProfilePic = "images/avatar.jpg";

        //Get HomeWorks info
        //SELECT COUNT(T.Owner_Code)  FROM [PaperBank].[dbo].[PaperList] T WHERE T.Owner_Code='111' AND T.Status = 0(should be 1)
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = "SELECT COUNT(T.Owner_Code)  FROM [PaperBank].[dbo].[PaperList] T WHERE T.Owner_Code='" + UCode + "' AND T.Status = " + ((int)P_Status.Submitted).ToString();

        ProjCount = Convert.ToInt16(mySql.SqlExecuteReader(sqlCmd).Rows[0][0].ToString());

        //Get Sell information
        //Get from Factors Table, Number of Sells and the accumulated amount of sells
        SellCount = 0;
        SellPriceCount = 0;

        //Get From FinancialAccount Table, the Account Balance
        FAcc = 0;

        
    }

    public UPortalClass()
    {

    }
}