using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using vtocSqlInterface;

/// <summary>
/// Summary description for tb_SupportRequest
/// </summary>
public class tb_SupportRequest
{
    //[Support_Code],[Pre_Support_Code],[User_Code],[Operator_Code],[Subject],[Field],[Priority],[Description],[Status],[Result],[Data1],[Data2],[Data3],[Data4]
    public int RN;
    public string Support_Code;
    public string Pre_Support_Code;
    public string User_Code;
    public string User_Name;
    public string Operator_Code;
    public string Subject;
    public Support_Fields Fields;
    public Support_Prioroty Priority;
    public string Description;
    public Support_Status Status;
    public string Result;
    public Int32 Data1;
    public Int32 Data2;
    public string Data3;
    public string Data4;

    private sqlInterface mySql;
    private string sqlCmd;

	public tb_SupportRequest()
	{
		
	}

    public tb_SupportRequest(string S_Code)
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        List<SqlParameter> parameters = new List<SqlParameter>();

        var p = new SqlParameter("@S_Code", SqlDbType.NVarChar);
        p.Value = S_Code;
        parameters.Add(p);

        sqlCmd = "SELECT T.*, (F.FFName + ' ' + F.FLName) User_Name FROM [dbo].[SupportRequest] T LEFT JOIN [dbo].[Users] F ON F.User_Code = T.User_Code WHERE T.Support_Code=@S_Code  ORDER BY T.[Support_Code] DESC";

        DataTable DT = mySql.SqlExecuteReader(sqlCmd,parameters.ToArray());
        int i = 1;
        if (DT.Rows.Count > 0)
        {
            DataRow r = DT.Rows[0];
            //[Support_Code],[User_Code],[Operator_Code],[Subject],[Field],[Priority],[Description],[Status],[Result],[Data1],[Data2],[Data3],[Data4], Name
            tb_SupportRequest newTR = new tb_SupportRequest();
            RN = i; i++;
            Support_Code = r["Support_Code"].ToString();
            User_Code = r["User_Code"].ToString();
            Operator_Code = r["Operator_Code"].ToString();
            Subject = r["Subject"].ToString();
            Fields = (Support_Fields)(Convert.ToInt32(r["Field"].ToString()));
            Priority = (Support_Prioroty)(Convert.ToInt32(r["Priority"].ToString()));
            Description = r["Description"].ToString();
            Status = (Support_Status)(Convert.ToInt32(r["Status"].ToString()));
            Result = r["Result"].ToString();
            Pre_Support_Code = r["Pre_Support_Code"].ToString();
            User_Name = r["User_Name"].ToString();
        }
    }

    public string Support_Add()
    {
        string _Req_Code = DateTime.Now.Ticks.ToString();
        List<SqlParameter> parameters = new List<SqlParameter>();

        var p = new SqlParameter("@Req_Code", SqlDbType.NVarChar);
        p.Value = _Req_Code;
        parameters.Add(p);

        p = new SqlParameter("@Pre_Support_Code", SqlDbType.NVarChar);
        p.Value = Pre_Support_Code;
        parameters.Add(p);

        p = new SqlParameter("@User_Code", SqlDbType.NVarChar);
        p.Value = User_Code;
        parameters.Add(p);

        p = new SqlParameter("@Operator_Code", SqlDbType.NVarChar);
        p.Value = Operator_Code;
        parameters.Add(p);

        p = new SqlParameter("@Subject", SqlDbType.NVarChar);
        p.Value = Subject;
        parameters.Add(p);

        p = new SqlParameter("@Fields", SqlDbType.Int);
        p.Value = (int)Fields;
        parameters.Add(p);

        p = new SqlParameter("@Priority", SqlDbType.Int);
        p.Value = (int)Priority;
        parameters.Add(p);

        p = new SqlParameter("@Description", SqlDbType.NVarChar);
        p.Value = Description;
        parameters.Add(p);

        p = new SqlParameter("@Status", SqlDbType.Int);
        p.Value = (int)Status;
        parameters.Add(p);

        p = new SqlParameter("@Result", SqlDbType.NVarChar);
        p.Value = Result;
        parameters.Add(p);

        p = new SqlParameter("@Data1", SqlDbType.Int);
        p.Value = Data1;
        parameters.Add(p);

        p = new SqlParameter("@Data2", SqlDbType.Int);
        p.Value = Data2;
        parameters.Add(p);

        p = new SqlParameter("@Data3", SqlDbType.NVarChar);
        p.Value = Data3;
        parameters.Add(p);

        p = new SqlParameter("@Data4", SqlDbType.NVarChar);
        p.Value = Data4;
        parameters.Add(p);

        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
        //[Support_Code],[Pre_Support_Code],[User_Code],[Operator_Code],[Subject],[Field],[Priority],[Description],[Status],[Result],[Data1],[Data2],[Data3],[Data4]
        sqlCmd = string.Format(@"INSERT INTO [dbo].[SupportRequest] ([Support_Code],[Pre_Support_Code],[User_Code],[Operator_Code],[Subject],[Field],     [Priority],  [Description], [Status],  [Result], [Data1],[Data2],[Data3],[Data4]) 
                                                                VALUES ({0},            {1},          {2},        {3},      {4},    {5},           {6},        {7},        {8},      {9},  {10},   {11},   {12}, {13})", 
                                                                     "@Req_Code",      "@Pre_Support_Code",  "@User_Code",  "@Operator_Code",  "@Subject", "@Fields", "@Priority", "@Description", "@Status", "@Result",  "@Data1",  "@Data2",   "@Data3",  "@Data4");
        if (mySql.SqlExecuteNonQuery(sqlCmd,parameters.ToArray()))
            return _Req_Code;
        else return "";
    }

    public bool Support_Update()
    {
        List<SqlParameter> parameters = new List<SqlParameter>();

        var p = new SqlParameter("@Description", SqlDbType.NVarChar);
        p.Value = Description;
        parameters.Add(p);

        p = new SqlParameter("@Status", SqlDbType.Int);
        p.Value = (int)Status;
        parameters.Add(p);

        p = new SqlParameter("@Support_Code", SqlDbType.NVarChar);
        p.Value = Support_Code;
        parameters.Add(p);

       
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

        sqlCmd = string.Format(@"UPDATE [dbo].[SupportRequest] SET [Operator_Code] = '{0}' ,[Description] = {1},[Status] = {2} WHERE [Support_Code] = {3}", "0", "@Description", "@Status", "@Support_Code");

        if (mySql.SqlExecuteNonQuery(sqlCmd,parameters.ToArray()))
            return true;
        else return false;
    
    }

    public static List<tb_SupportRequest> LoadByUser(string UCode, Support_List_Type _SLT)
    {
        List<tb_SupportRequest> S = new List<tb_SupportRequest>();
        sqlInterface mySql1;
        string sqlCmd1;
        string WhStr = "";
        string WhStr1 = "";
        string WhStr2 = "";

        List<SqlParameter> parameters = new List<SqlParameter>();

        var p = new SqlParameter("@UCode", SqlDbType.NVarChar);
        p.Value = UCode;
        parameters.Add(p);

        if (UCode != "")
        {
            WhStr1 = " T.User_Code = @UCode ";
        }

        switch (_SLT)
        {
            case Support_List_Type.Waiting:
                WhStr2 = " T.Status !=" + (int)Support_Status.Responsed;
                break;
            case Support_List_Type.VeryImportant:
                WhStr2 = " T.Status !=" + (int)Support_Status.Responsed + " AND T.Priority=" + (int)Support_Prioroty.VeryImportant;
                break;
            case Support_List_Type.Important:
                WhStr2 = " T.Status !=" + (int)Support_Status.Responsed + " AND T.Priority=" + (int)Support_Prioroty.Important;
                break;
            case Support_List_Type.Normal:
                WhStr2 = " T.Status !=" + (int)Support_Status.Responsed + " AND T.Priority=" + (int)Support_Prioroty.Normal;
                break;
        }

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

            sqlCmd1 = "SELECT T.*, (F.FFName + ' ' + F.FLName) User_Name  FROM [dbo].[SupportRequest] T LEFT JOIN [dbo].[Users] F ON F.User_Code = T.User_Code " + WhStr + " ORDER BY T.[Support_Code] DESC";

            DataTable DT = mySql1.SqlExecuteReader(sqlCmd1,parameters.ToArray());
            int i = 1;
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow r in DT.Rows)
                {
                    //[Support_Code],[User_Code],[Operator_Code],[Subject],[Field],[Priority],[Description],[Status],[Result],[Data1],[Data2],[Data3],[Data4], Name
                    tb_SupportRequest newTR = new tb_SupportRequest();
                    newTR.RN = i; i++;
                    newTR.Support_Code = r["Support_Code"].ToString();
                    newTR.User_Code = r["User_Code"].ToString();
                    newTR.Operator_Code = r["Operator_Code"].ToString();
                    newTR.Subject = r["Subject"].ToString();
                    newTR.Fields = (Support_Fields)(Convert.ToInt32(r["Field"].ToString()));
                    newTR.Priority = (Support_Prioroty)(Convert.ToInt32(r["Priority"].ToString()));
                    newTR.Description = r["Description"].ToString();
                    newTR.Status = (Support_Status)(Convert.ToInt32(r["Status"].ToString()));
                    newTR.Result = r["Result"].ToString();
                    newTR.Pre_Support_Code = r["Pre_Support_Code"].ToString();
                    newTR.User_Name = r["User_Name"].ToString();
                    //Data 1,2,3,4
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

    public static string GetFieldName(Support_Fields SF)
    {
        switch (SF)
        {
            case Support_Fields.Buy:
                return "خرید";
            case Support_Fields.Sell:
                return "فروش";
            case Support_Fields.Settlement:
                return "تسویه";
            default:
                return "";
        }
    }

    public static string GetPriorityName(Support_Prioroty SP)
    {
        switch (SP)
        {
            case Support_Prioroty.Important:
                return "مهم";
            case Support_Prioroty.VeryImportant:
                return "خیلی مهم";
            case Support_Prioroty.Normal:
                return "معمولی";
            default:
                return "";
        }
    }

    public static string GetSatusName(Support_Status SS)
    {
        switch (SS)
        {
            case Support_Status.Submitted:
                return "در انتظار پاسخ";
            case Support_Status.Inprogress:
                return "در حال بررسی";
            case Support_Status.Responsed:
                return "پاسخ داده شده";
            default:
                return "";
        }
    }

    public static string GetSatusNamelbl(Support_Status SS)
    {
        switch (SS)
        {
            case Support_Status.Submitted:
                return " class=\"label label-info\">در انتظار پاسخ";
            case Support_Status.Inprogress:
                return " class=\"label label-warning\">در حال بررسی";
            case Support_Status.Responsed:
                return " class=\"label label-success\">پاسخ داده شده";
            default:
                return "";
        }
    }
    
}

public enum Support_Fields
{
    Buy=0,
    Sell=1,
    Settlement=2
}

public enum Support_Prioroty
{
    VeryImportant=0,
    Important=1,
    Normal=2
}

public enum Support_Status
{
    Submitted=0,
    Inprogress=1,
    Responsed=2

}

public enum Support_List_Type
{
    All = 0,
    Waiting = 1,
    VeryImportant = 2,
    Important = 3,
    Normal = 4
}