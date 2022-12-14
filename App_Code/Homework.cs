using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using vtocSqlInterface;

/// <summary>
/// Summary description for Homework
/// </summary>
/// 
[Serializable]
public class Homework
{
    public int RN;
    public string Paper_Code;
    public string Pr_Paper_Code;
    public string Owner_Code;
    public string Uploade_Date;
    public string TF_Name;
    public string TE_Name;
    public string P_Desc;
    public string Fields;
    public int Audience;
    public string Abstract;
    public Sell_Type ST;
    public Int32 Price;
    public int FeesPercent;
    public int T_Word_C;
    public int T_Char_C;    
    public P_Status Status;    
    public string LastModifiedDate;
    public int Download_C;
    public int Paper_Rate;

    private sqlInterface mySql;
    private string sqlCmd;

    //DataBase Fields PaperList: 0:[Paper_Code],1:[Owner_Code],2:[Upload_Date],3:[TF_Name],4:[TE_Name],5:[P_Desc],6:[Fields],7:[Audience],8:[Abstract],9:[Sell_Type],10:[Price],11:[FeesPercent],12:[T_Word_C],13:[T_Char_C],14:[Status],15:[LastModifiedDate],16:[Download_C],17:[Paper_Rate],18:[Data1],19:[Data2],20:[Data3],21:[Data4]

	public Homework()
	{
		
	}

    public Homework(string Code)
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = "SELECT TOP(1) T.*  FROM [PaperBank].[dbo].[PaperList] T WHERE T.Paper_Code = '" + Code + "'";

        DataTable DT = mySql.SqlExecuteReader(sqlCmd);
        DataRow r = DT.Rows[0];
        Paper_Code = Code;        
        Pr_Paper_Code = 
        Owner_Code = r[1].ToString();
        Uploade_Date = r[2].ToString();
        TF_Name = r[3].ToString();
        TE_Name = r[4].ToString();
        P_Desc = r[5].ToString();
        Fields = r[6].ToString();
        Audience = Convert.ToInt16(r[7].ToString());
        Abstract = r[8].ToString();
        ST = (Sell_Type)(Convert.ToInt16(r[9].ToString()));
        Price = Convert.ToInt32(r[10].ToString());
        FeesPercent = Convert.ToInt16(r[11].ToString());
        T_Word_C = Convert.ToInt16(r[12].ToString());
        T_Char_C = Convert.ToInt16(r[13].ToString());
        Status = (P_Status)Convert.ToInt16(r[14].ToString());
        LastModifiedDate = r[15].ToString();
        Download_C = Convert.ToInt16(r[16].ToString());
        Paper_Rate = Convert.ToInt16(r[17].ToString());
    }

    public bool HW_Add()
    {
        try
        {
            mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd = string.Format(@"INSERT PaperBank.dbo.PaperList VALUES ('{0}', '{1}', '{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}', N'{8}', {9}, {10}, {11}, {12}, {13}, {14}, '{15}', {16}, 0, 0, 0, '{17}', '')",
                                                            Paper_Code, Owner_Code, Uploade_Date, TF_Name, TE_Name, P_Desc, Fields, Audience, Abstract, (int)ST, Price, FeesPercent, T_Word_C, T_Char_C, (int)Status, LastModifiedDate, Download_C, Pr_Paper_Code);

            if (mySql.SqlExecuteNonQuery(sqlCmd))
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    //public static bool HW_Update(string HW_Code, string myTF_Name = "/!?", string myTE_Name = "/!?", string myP_Desc = "/!?", string myFields = "/!?", int myAudience = -1, string myAbstract = "/!?", Sell_Type myST = Sell_Type.Normal, Int32 myPrice = -1, int myFeesPercent = -1, int myT_Word_C = -1, int myT_Char_C = -1, P_Status myStat = P_Status.Submitted, string myLastModifiedDate = "/!?", int myDownload_C = -1, int myPaper_Rate = -1)
    public bool HW_Update()
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"UPDATE [dbo].[PaperList] SET [TF_Name] = N'{0}', [TE_Name] = '{1}', [P_Desc] = N'{2}', [Fields] = '{3}', [Audience] = {4}, [Abstract] = N'{5}', [Sell_Type] = {6}, [Price] = {7}, [FeesPercent] = {8}, [T_Word_C] = {9}, [T_Char_C] = {10}, [Status] = {11}, [LastModifiedDate] = '{12}', [Download_C] = {13}, [Paper_Rate] = {14} WHERE Paper_Code = '{15}'", TF_Name, TE_Name, P_Desc, Fields, Audience, Abstract, ((int)ST).ToString(), Price, FeesPercent, T_Word_C, T_Char_C, ((int)Status).ToString(), LastModifiedDate, Download_C,Paper_Rate, Paper_Code);
        
        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return true;
        else return false;        
    }
        

    public static List<Homework> SearchByOwner(string Owner_Code)
    {
        List<Homework> S = new List<Homework>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd1 = "SELECT T.*  FROM [PaperBank].[dbo].[PaperList] T WHERE  T.Status!=4 AND T.Owner_Code = '" + Owner_Code + "' ORDER BY T.Upload_Date DESC";

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Homework newHW = new Homework();
                    newHW.RN = i; i++;
                    newHW.Paper_Code = r[0].ToString();
                    newHW.Owner_Code = r[1].ToString();
                    newHW.Uploade_Date = r[2].ToString();
                    newHW.TF_Name = r[3].ToString();
                    newHW.TE_Name = r[4].ToString();
                    newHW.P_Desc = r[5].ToString();
                    newHW.Fields = r[6].ToString();
                    newHW.Audience = Convert.ToInt32(r[7].ToString());
                    newHW.Abstract = r[8].ToString();
                    newHW.ST = (Sell_Type)(Convert.ToInt32(r[9].ToString()));
                    newHW.Price = Convert.ToInt32(r[10].ToString());
                    newHW.FeesPercent = Convert.ToInt32(r[11].ToString());
                    newHW.T_Word_C = Convert.ToInt32(r[12].ToString());
                    newHW.T_Char_C = Convert.ToInt32(r[13].ToString());
                    newHW.Status = (P_Status)Convert.ToInt32(r[14].ToString());
                    newHW.LastModifiedDate = r[15].ToString();
                    newHW.Download_C = Convert.ToInt32(r[16].ToString());
                    newHW.Paper_Rate = Convert.ToInt32(r[17].ToString());
                    newHW.Pr_Paper_Code = r[20].ToString();
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

    public static List<Homework> SearchByOwnerAndTag(string Owner_Code, string Tags)
    {
        List<Homework> S = new List<Homework>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            string tmpTags = "";
            if (Tags == "")
            {
                tmpTags = "";
            }
            else
            {                
                string[] STags = Tags.Substring(0,Tags.Length-1).Split('!');
                tmpTags = "AND (";
                foreach (string k in STags)
                {
                    tmpTags += "(T.TF_Name LIKE N'%" + k + "%' OR T.TE_Name LIKE '%" + k + "%' OR T.P_Desc Like N'%" + k + "%' OR T.Abstract LIKE N'%" + k + "%') OR";
                }
                tmpTags = tmpTags.Substring(0, tmpTags.Length - 2);
                tmpTags += ")";

            }

            sqlCmd1 = "SELECT T.*  FROM [PaperBank].[dbo].[PaperList] T WHERE T.Owner_Code = '" + Owner_Code + "'" + tmpTags + " AND  T.Status!=4  ORDER BY T.Upload_Date DESC";

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Homework newHW = new Homework();
                    newHW.RN = i; i++;
                    newHW.Paper_Code = r[0].ToString();
                    newHW.Owner_Code = r[1].ToString();
                    newHW.Uploade_Date = r[2].ToString();
                    newHW.TF_Name = r[3].ToString();
                    newHW.TE_Name = r[4].ToString();
                    newHW.P_Desc = r[5].ToString();
                    newHW.Fields = r[6].ToString();
                    newHW.Audience = Convert.ToInt32(r[7].ToString());
                    newHW.Abstract = r[8].ToString();
                    newHW.ST = (Sell_Type)(Convert.ToInt16(r[9].ToString()));
                    newHW.Price = Convert.ToInt32(r[10].ToString());
                    newHW.FeesPercent = Convert.ToInt16(r[11].ToString());
                    newHW.T_Word_C = Convert.ToInt32(r[12].ToString());
                    newHW.T_Char_C = Convert.ToInt32(r[13].ToString());
                    newHW.Status = (P_Status)Convert.ToInt16(r[14].ToString());
                    newHW.LastModifiedDate = r[15].ToString();
                    newHW.Download_C = Convert.ToInt16(r[16].ToString());
                    newHW.Paper_Rate = Convert.ToInt16(r[17].ToString());
                    newHW.Pr_Paper_Code = r[20].ToString();
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

    //public static List<Homework> SearchByType(ViewType T, int c)
    //{
    //    //List<Homework> S = new List<Homework>();
    //    //sqlInterface mySql1;
    //    //string sqlCmd1;

    //    //try
    //    //{
    //    //    mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            
    //    //    string OrderBy = " ORDER BY ";

    //    //    switch (T)
    //    //    {
    //    //        case ViewType.Bests:
    //    //            OrderBy += "T.Paper_Rate DESC";
    //    //            break;
    //    //        case ViewType.Hottests:
    //    //            OrderBy += "T.Download_C DESC";
    //    //            break;
    //    //        case ViewType.News:
    //    //            OrderBy += "T.Upload_Date ASC";
    //    //            break;
    //    //        case ViewType.Frees:
    //    //            OrderBy += "T.Price ASC";
    //    //            break;
    //    //    }

    //    //    sqlCmd1 = "SELECT T.*  FROM [PaperBank].[dbo].[PaperList] T WHERE  T.Status!=4 " + OrderBy;

    //    //    DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
    //    //    int i = 1;
    //    //    if (DT.Rows.Count > 0)
    //    //    {
    //    //        for (i = StartAt; i <= Math.Min(DT.Rows.Count, StartAt + Count - 1); i++)
    //    //        {
    //    //            DataRow r = DT.Rows[i - 1];
    //    //            Homework newHW = new Homework();
    //    //            newHW.RN = i;
    //    //            newHW.Paper_Code = r[0].ToString();
    //    //            newHW.Owner_Code = r[1].ToString();
    //    //            newHW.Uploade_Date = r[2].ToString();
    //    //            newHW.TF_Name = r[3].ToString();
    //    //            newHW.TE_Name = r[4].ToString();
    //    //            newHW.P_Desc = r[5].ToString();
    //    //            newHW.Fields = r[6].ToString();
    //    //            newHW.Audience = Convert.ToInt32(r[7].ToString());
    //    //            newHW.Abstract = r[8].ToString();
    //    //            newHW.ST = (Sell_Type)(Convert.ToInt32(r[9].ToString()));
    //    //            newHW.Price = Convert.ToInt32(r[10].ToString());
    //    //            newHW.FeesPercent = Convert.ToInt32(r[11].ToString());
    //    //            newHW.T_Word_C = Convert.ToInt32(r[12].ToString());
    //    //            newHW.T_Char_C = Convert.ToInt32(r[13].ToString());
    //    //            newHW.Status = (P_Status)Convert.ToInt32(r[14].ToString());
    //    //            newHW.LastModifiedDate = r[15].ToString();
    //    //            newHW.Download_C = Convert.ToInt16(r[16].ToString());
    //    //            newHW.Paper_Rate = Convert.ToInt16(r[17].ToString());
    //    //            newHW.Pr_Paper_Code = r[20].ToString();
    //    //            S.Add(newHW);
    //    //        }

    //    //    }

    //    //    return S;
    //    //}
    //    //catch (Exception e)
    //    //{
    //    //    return null;
    //    //}
    //}

    public static List<Homework> SearchByTag(string[] T, ViewType OrderType, int StartAt, int Count)
    {
        
        List<Homework> S = new List<Homework>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            string tmpTags = "";

            if (T !=null && T.Length > 0)
            {
                tmpTags = " AND (";
                foreach (string k in T)
                {
                    tmpTags += "(T.TF_Name LIKE N'%" + k + "%' OR T.TE_Name LIKE '%" + k + "%' OR T.P_Desc Like N'%" + k + "%' OR T.Abstract LIKE N'%" + k + "%') OR";
                }
                tmpTags = tmpTags.Substring(0, tmpTags.Length - 2);
                tmpTags += ")";
            }

            string Whstr = "";

            string OrderBy = " ORDER BY ";
            string D;
            switch (OrderType)
            {
                case ViewType.Bests:
                    OrderBy += "T.Paper_Rate DESC";
                    break;
                case ViewType.BestsofMonth:
                    OrderBy += "T.Paper_Rate DESC";

                    D = DateTime.Now.AddMonths(-1).Ticks.ToString();
                    Whstr = " AND T.Upload_Date >= " + D;
                    break;
                case ViewType.BestsofWeek:
                    OrderBy += "T.Paper_Rate DESC";

                    D = DateTime.Now.AddDays(-7).Ticks.ToString();
                    Whstr = " AND T.Upload_Date >= " + D;
                    break;
                case ViewType.Hottests:
                    OrderBy += "T.Download_C DESC";
                    break;
                case ViewType.HottestsofMonth:
                    OrderBy += "T.Download_C DESC";
                    
                    D = DateTime.Now.AddMonths(-1).Ticks.ToString();
                    Whstr = " AND T.Upload_Date >= " + D;
                    break;
                case ViewType.HottestsofWeek:
                    OrderBy += "T.Download_C DESC";

                    D = DateTime.Now.AddDays(-7).Ticks.ToString();
                    Whstr = " AND T.Upload_Date >= " + D;
                    break;
                case ViewType.News:
                    OrderBy += "T.Upload_Date DESC";
                    break;
                case ViewType.Frees:
                    OrderBy += "T.Upload_Date DESC";
                    Whstr = " AND T.Price = 0";
                    break;
            }

            sqlCmd1 = "SELECT T.*  FROM [PaperBank].[dbo].[PaperList] T WHERE  T.Status!=4 " + tmpTags + Whstr + OrderBy;

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                for (i = StartAt; i <= Math.Min(DT.Rows.Count, StartAt + Count - 1); i++)
                {
                    DataRow r = DT.Rows[i - 1];
                    Homework newHW = new Homework();
                    newHW.RN = i;
                    newHW.Paper_Code = r[0].ToString();
                    newHW.Owner_Code = r[1].ToString();
                    newHW.Uploade_Date = r[2].ToString();
                    newHW.TF_Name = r[3].ToString();
                    newHW.TE_Name = r[4].ToString();
                    newHW.P_Desc = r[5].ToString();
                    newHW.Fields = r[6].ToString();
                    newHW.Audience = Convert.ToInt32(r[7].ToString());
                    newHW.Abstract = r[8].ToString();
                    newHW.ST = (Sell_Type)(Convert.ToInt32(r[9].ToString()));
                    newHW.Price = Convert.ToInt32(r[10].ToString());
                    newHW.FeesPercent = Convert.ToInt32(r[11].ToString());
                    newHW.T_Word_C = Convert.ToInt32(r[12].ToString());
                    newHW.T_Char_C = Convert.ToInt32(r[13].ToString());
                    newHW.Status = (P_Status)Convert.ToInt32(r[14].ToString());
                    newHW.LastModifiedDate = r[15].ToString();
                    newHW.Download_C = Convert.ToInt16(r[16].ToString());
                    newHW.Paper_Rate = Convert.ToInt16(r[17].ToString());
                    newHW.Pr_Paper_Code = r[20].ToString();
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

    public static List<Homework> SearchByBuyer(string Buyer_Code)
    {
        List<Homework> S = new List<Homework>();
        sqlInterface mySql1;
        string sqlCmd1;

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd1 = "SELECT F.* FROM [PaperBank].[dbo].[Trades] T LEFT JOIN dbo.PaperList F ON F.Paper_Code = T.Paper_Code WHERE  F.Status!=4 AND T.Buyer_Code = " + Buyer_Code;

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    Homework newHW = new Homework();
                    newHW.RN = i; i++;
                    newHW.Paper_Code = r[0].ToString();
                    newHW.Owner_Code = r[1].ToString();
                    newHW.Uploade_Date = r[2].ToString();
                    newHW.TF_Name = r[3].ToString();
                    newHW.TE_Name = r[4].ToString();
                    newHW.P_Desc = r[5].ToString();
                    newHW.Fields = r[6].ToString();
                    newHW.Audience = Convert.ToInt16(r[7].ToString());
                    newHW.Abstract = r[8].ToString();
                    newHW.ST = (Sell_Type)(Convert.ToInt16(r[9].ToString()));
                    newHW.Price = Convert.ToInt32(r[10].ToString());
                    newHW.FeesPercent = Convert.ToInt16(r[11].ToString());
                    newHW.T_Word_C = Convert.ToInt32(r[12].ToString());
                    newHW.T_Char_C = Convert.ToInt32(r[13].ToString());
                    newHW.Status = (P_Status)Convert.ToInt16(r[14].ToString());
                    newHW.LastModifiedDate = r[15].ToString();
                    newHW.Download_C = Convert.ToInt32(r[16].ToString());
                    newHW.Paper_Rate = Convert.ToInt16(r[17].ToString());
                    newHW.Pr_Paper_Code = r[20].ToString();
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


public enum Sell_Type{
    Normal,
    Special
}

public enum P_Status
{
    Submitted = 0,
    Confirmed = 1,
    NotConfirmed = 2,
    Suspended = 3,
    Deleted = 4
}

public enum ViewType
{
    News = 0,
    Bests = 1,
    Frees = 2,
    Hottests = 3,
    BestsofWeek = 4,
    BestsofMonth = 5,
    HottestsofWeek = 6,
    HottestsofMonth = 7
}

