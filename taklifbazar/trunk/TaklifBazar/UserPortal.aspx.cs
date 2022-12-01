using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vtocSqlInterface;

public partial class UserPortal : System.Web.UI.Page
{
    public string txtProfilePic;
    public string txtProjCount;
    public string txtAccBal;
    public string txtTotalSellPrice;
    public string txtTotalSellCount;

    private sqlInterface mySql;
    private string sqlCmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        if (LC ==null || LC.User_Code =="G")
        {
            //Log Error

            //Redirect to the default page
            Response.Redirect("Default.aspx");
        }
        else
        {
            
            UPortalClass UPC = new UPortalClass(LC);
            txtProfilePic = UPC.ProfilePic;
            txtEmail.InnerHtml = UPC.CurUser.Email;
            txtMobile.InnerHtml = UPC.CurUser.Mobile;
            txtName.InnerHtml = UPC.CurUser.FFName + " " + UPC.CurUser.FLName;

            mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

            sqlCmd = string.Format(@"DECLARE @Code BIGINT = {0} SELECT ISNULL((SELECT T.Amount FROM dbo.Financial_Acc T WHERE T.User_Code = @Code),0) AccBall, COUNT(T1.Download_C) ProjCount, SUM(T1.Download_C) SellCount, ISNULL((SELECT SUM(T2.Amount) FROM dbo.Transactions T2 WHERE T2.User_Code = @Code AND T2.Trans_Type = 1),0) SellPrice FROM dbo.PaperList T1 WHERE T1.Owner_Code = @Code", UPC.CurUser.User_Code);
            DataTable DT = mySql.SqlExecuteReader(sqlCmd);
            if (DT.Rows.Count > 0)
            {
                txtAccBal = DT.Rows[0][0].ToString();
                txtProjCount = DT.Rows[0][1].ToString();
                txtTotalSellCount = DT.Rows[0][2].ToString();
                txtTotalSellPrice = DT.Rows[0][3].ToString();
            }
        }

    }
    
}