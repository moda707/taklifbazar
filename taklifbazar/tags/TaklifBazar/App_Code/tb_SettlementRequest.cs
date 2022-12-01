using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for tb_SettlementRequest
/// </summary>
public class tb_SettlementRequest
{
    //[Req_Code],[Pre_Req_Code],[User_Code],[Subject],[Amount_Percent],[Amount],[Settl_Date],[TB_Rate],[Status],[AccBal],[Trans_Num],[B_Cardnumber],[Data1],[Data2],[Data3],[Data4]
    public int RN;
    public string Req_Code;
    public string Pre_Req_Code;
    public string User_Code;
    public string User_Name;
    public string Subject;
    public string Amount_Percent;
    public string Amount;
    public string Settle_Date;
    public int TB_Rate;
    public SettlementReq_Status Status;
    public Int32 AccBal;
    public string Trans_Num;
    public string B_Cardnumber;
    public Int32 Data1;
    public Int32 Data2;
    public string Data3;
    public string Data4;


    private sqlInterface mySql;
    private string sqlCmd;

	public tb_SettlementRequest()
	{
		
	}

    public tb_SettlementRequest(string Code)
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = "SELECT T.*, (F.FFName + ' ' + F.FLName) User_Name  FROM [PaperBank].[dbo].[Settlement_Request] T LEFT JOIN [PaperBank].[dbo].[Users] F ON F.User_Code = T.User_Code WHERE T.Req_Code='" + Code + "'";

        DataTable DT = mySql.SqlExecuteReader(sqlCmd);
        int i = 1;
        if (DT.Rows.Count > 0)
        {
            DataRow r = DT.Rows[0];

            //[Req_Code],[Pre_Req_Code],[User_Code],[Subject],[Amount_Percent],[Amount],[Settl_Date],[TB_Rate],  [Status],  [AccBal],[Trans_Num],[B_Cardnumber],[Data1],[Data2],[Data3],[Data4]
                        
            Req_Code = r[0].ToString();
            Pre_Req_Code = r[1].ToString();
            User_Code = r[2].ToString();
            Subject = r[3].ToString();
            Amount_Percent = r[4].ToString();
            Amount = r[5].ToString();
            Settle_Date = r[6].ToString();
            TB_Rate = Convert.ToInt32(r[7].ToString());
            Status = (SettlementReq_Status)(Convert.ToInt32(r[8].ToString()));
            AccBal = Convert.ToInt32(r[9].ToString());
            Trans_Num = r[10].ToString();
            B_Cardnumber = r[11].ToString();
            User_Name = r[16].ToString();

        }
    }

    public string SR_Add()
    {
        string _Req_Code = DateTime.Now.Ticks.ToString();

        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"INSERT INTO [dbo].[Settlement_Request] ([Req_Code],[Pre_Req_Code],[User_Code],[Subject],[Amount_Percent],[Amount],[Settl_Date],[TB_Rate],  [Status],  [AccBal],[Trans_Num],[B_Cardnumber],[Data1],[Data2],[Data3],[Data4]) 
                                                                   VALUES ('{0}',     '{1}',       '{2}',      N'{3}',        {4},          {5},       '{6}',     {7},        {8},       '{9}',     '{10}',      '{11}',     {12},   {13},  '{14}', '{15}')", 
                                                                        _Req_Code, Pre_Req_Code,  User_Code,   Subject,  Amount_Percent,   Amount,  Settle_Date, TB_Rate,  (int)Status,  AccBal,   Trans_Num,  B_Cardnumber,  Data1,  Data2,  Data3,  Data4);
        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return _Req_Code;
        else return "";
    }

    public bool SR_Update()
    {
        //
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"UPDATE [dbo].[Settlement_Request] SET [Status] = {0}, [Trans_Num] = '{1}' WHERE Req_Code = '{2}'", (int)Status, Trans_Num, Req_Code);

        if (mySql.SqlExecuteNonQuery(sqlCmd))
            return true;
        else return false;        
    }

    public static List<tb_SettlementRequest> LoadByUser(string UCode, Settlement_List_Tpe _SLT)
    {
        List<tb_SettlementRequest> S = new List<tb_SettlementRequest>();
        sqlInterface mySql1;
        string sqlCmd1;
        string WhStr = "";
        string WhStr1 = "";
        string WhStr2 = "";

        if (UCode != "") WhStr1 = " T.User_Code = '" + UCode + "'";

        if (_SLT != Settlement_List_Tpe.All) WhStr2 = " T.Status = " + (int)_SLT;

        if (WhStr1 != "")
        {
            if (WhStr2 != "")
            {
                WhStr = " WHERE " + WhStr1 + " AND " + WhStr2;
            }
            else
            {
                WhStr = " WHERE " + WhStr1;
            }
        }
        else
        {
            if (WhStr2 != "")
            {
                WhStr = " WHERE " + WhStr2;
            }
        }

        try
        {
            mySql1 = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd1 = "SELECT T.*, (F.FFName + ' ' + F.FLName)  FROM [PaperBank].[dbo].[Settlement_Request] T LEFT JOIN [PaperBank].[dbo].[Users] F ON F.User_Code = T.User_Code " + WhStr + " ORDER BY T.[Req_Code] DESC";

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1);
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    //[Req_Code],[User_Code],[Subject],[Amount_Percent],[Amount],[Settl_Date],[TB_Rate],[Status],[Data1],[Data2],[Data3],[Data4]
                    tb_SettlementRequest newTR = new tb_SettlementRequest();                    
                    newTR.Req_Code = r[0].ToString();
                    newTR.Pre_Req_Code = r[1].ToString();
                    newTR.User_Code = r[2].ToString();
                    newTR.Subject = r[3].ToString();
                    newTR.Amount_Percent = r[4].ToString();
                    newTR.Amount = r[5].ToString();
                    newTR.Settle_Date = r[6].ToString();
                    newTR.TB_Rate = Convert.ToInt32(r[7].ToString());
                    newTR.Status = (SettlementReq_Status)(Convert.ToInt32(r[8].ToString()));
                    newTR.AccBal = Convert.ToInt32(r[9].ToString());
                    newTR.Trans_Num = r[10].ToString();
                    newTR.B_Cardnumber = r[11].ToString();                    
                    newTR.User_Name = r[16].ToString();
                    
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

    public static string GetSRStatusName(SettlementReq_Status SRS)
    {
        switch (SRS)
        {
            case SettlementReq_Status.Submitted:
                return "ثبت شده";
            case SettlementReq_Status.Canceled:
                return "لغو شده";
            case SettlementReq_Status.Inprogress:
                return "درحال انجام";
            case SettlementReq_Status.Paied:
                return "پرداخت شده";
            case SettlementReq_Status.Rejected:
                return "برگشت داده شده";
            default:
                return "";

        }
    }

    public static string GetSRStatusNamelbl(SettlementReq_Status SRS)
    {
        switch (SRS)
        {
            case SettlementReq_Status.Submitted:
                return " class=\"label label-info\">ثبت شده";
            case SettlementReq_Status.Canceled:
                return " class=\"label label-default\">لغو شده";
            case SettlementReq_Status.Inprogress:
                return " class=\"label label-warning\">درحال انجام";
            case SettlementReq_Status.Paied:
                return " class=\"label label-success\">پرداخت شده";
            case SettlementReq_Status.Rejected:
                return " class=\"label label-danger\">برگشت داده شده";
            default:
                return "";

        }
    }
}

public enum SettlementReq_Status
{
    Submitted = 0,
    Paied = 1,
    Rejected = 2,
    Canceled = 3,
    Inprogress = 4
}

public enum Settlement_List_Tpe
{
    Submitted = 0,
    Paied = 1,
    Rejected = 2,
    Canceled = 3,
    Inprogress = 4,
    All = 5
}