using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vtocSqlInterface;

public partial class UserView : System.Web.UI.Page
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
        if (!String.IsNullOrEmpty(Request.QueryString[0]))
        {
            string QS = Request.QueryString[0].ToString();
            QS = QS.Replace(' ', '+');

            string UCode = Encryption.Decrypt(QS, SharedDataInfo.SecurityKey);
            Users U = new Users(UCode);
            UPortalClass UPC = new UPortalClass(new LoginClass(U));
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



            List<Homework> LHW = Homework.SearchByOwner(UCode);
            int t = 5;
            HWShowClass HWSC = new HWShowClass();
            HWSC.AllHW = LHW;
            HWSC.ToShowHW = LHW;
            HWSC.PageNumb = 1;
            HWSC.PageCount = LHW.Count / t + 1;
            HWSC.tCount = LHW.Count;


            string C = "";
            if (HWSC.ToShowHW.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>قیمت</th><th>فروش</th></tr></thead><tbody>";
                foreach (Homework a in HWSC.ToShowHW)
                {
                    C += "<tr><td>" + a.Pr_Paper_Code + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:ShowHWDet('" + Encryption.Encrypt(a.Pr_Paper_Code, SharedDataInfo.SecurityKey) + "');\">" + a.TF_Name + "</button></td><td>" + a.Price + "</td><td>" + a.Download_C + "</td></tr>";
                }
                C += "</tbody></table>";
            }
            else
            {
                C = "موردی یافت نشد.";
            }
            TblCnt.InnerHtml = C;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}