using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SettlementView : System.Web.UI.Page
{
    public string txtUser_Rate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((LoginClass)Session["LC"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (((LoginClass)Session["LC"]).U_Type == User_Type.Admin)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(Request.QueryString[0]))
                        {
                            string S_Code = Request.QueryString[0].ToString();
                            S_Code = S_Code.Replace(' ', '+');
                            S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

                            tb_SettlementRequest SR = new tb_SettlementRequest(S_Code);
                            txtPre_Code.InnerHtml = SR.Pre_Req_Code;
                            DateTime D = new  DateTime(Convert.ToInt64(SR.Req_Code));
                            txtTarikh.InnerHtml = DateConversion.DateTimeToPersian(D) + "-" + D.Hour + ":" + D.Minute.ToString("00");
                            txtUser.InnerHtml = SR.User_Name;
                            txtAccBal.InnerHtml = NumericClass.int2Currency(Convert.ToInt32(SR.AccBal));
                            txtAmount.InnerHtml = NumericClass.int2Currency(Convert.ToInt32(SR.Amount));
                            DateTime D2 = new DateTime(Convert.ToInt64(SR.Settle_Date));
                            txtSettleDate.InnerHtml = DateConversion.DateTimeToPersianDay(D2) + " " + DateConversion.DateTimeToPersian(D2);
                            txtDescription.InnerHtml = SR.Subject;
                            txtTransNum.Value = SR.Trans_Num;



                        }
                    }
                    catch (Exception e2)
                    {

                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        string S_Code = Request.QueryString[0].ToString();
        S_Code = S_Code.Replace(' ', '+');
        S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

        tb_SettlementRequest SR = new tb_SettlementRequest(S_Code);

        SR.Trans_Num = txtTransNum.Value;
        SR.Status = SettlementReq_Status.Paied;
        SR.SR_Update();

        tb_Transactions TR = new tb_Transactions();
        //From User Virtual Account to User Real Account
        TR.User_Code = SR.User_Code;
        TR.Trans_Type = Transaction_Type.Settle;
        TR.InOut = InOut_Type.Out;
        TR.CurAcc_Type = CurrentAccount_Type.Bank;
        TR.BN_Source = SR.Trans_Num;
        TR.Amount = SR.Amount;
        TR.Trans_Subject = "تسویه حساب طی تراکنش شماره " + SR.Trans_Num;

        tb_FinancialAcc FA_User = new tb_FinancialAcc(SR.User_Code);
        FA_User.Amount = (Convert.ToInt32(FA_User.Amount) - Convert.ToInt32(SR.Amount)).ToString();
        TR.AccBalance = FA_User.Amount;

        FA_User.LastTransaction = TR.Transaction_Add();

        FA_User.Update();


        //From User Virtual Account to TB Acount : For User

        TR = new tb_Transactions();
        TR.User_Code = SR.User_Code;
        TR.Trans_Type = Transaction_Type.Settle;
        TR.InOut = InOut_Type.Out;
        TR.CurAcc_Type = CurrentAccount_Type.Local;
        TR.BN_Source = "0";
        TR.Amount = (((int)(SR.AccBal * Convert.ToInt32(SR.Amount_Percent) / 100.0)) - Convert.ToInt32(SR.Amount)).ToString();
        TR.Trans_Subject = "پرداخت " + SR.TB_Rate + "% کارمز بابت تسویه پیش از موعد";
        FA_User.Amount = (Convert.ToInt32(FA_User.Amount) - Convert.ToInt32(TR.Amount)).ToString();
        TR.AccBalance = FA_User.Amount;
        FA_User.LastTransaction = TR.Transaction_Add();
        FA_User.Update();

        //From User Virtual Account to TB Acount : For TB
        TR = new tb_Transactions();        
        TR.User_Code = "0";
        TR.Trans_Type = Transaction_Type.Settle;
        TR.InOut = InOut_Type.In;
        TR.CurAcc_Type = CurrentAccount_Type.Local;
        TR.BN_Source = SR.User_Code;
        TR.Amount = (((int)(SR.AccBal * Convert.ToInt32(SR.Amount_Percent) / 100.0)) - Convert.ToInt32(SR.Amount)).ToString();
        TR.Trans_Subject = "دریافت " + SR.Amount_Percent + "% کارمز بابت تسویه پیش از موعد";

        tb_FinancialAcc FA_TB = new tb_FinancialAcc("0");
        FA_TB.Amount = (Convert.ToInt32(FA_TB.Amount) + Convert.ToInt32(TR.Amount)).ToString();

        TR.AccBalance = FA_TB.Amount;
        FA_TB.LastTransaction = TR.Transaction_Add();
        FA_TB.Update();
                
        ClientScript.RegisterStartupScript(this.GetType(), "", "parent.window.location.href = 'Admin/SettlementManagement.aspx';", true);
    }
    protected void btnInprogress_Click(object sender, EventArgs e)
    {
        string S_Code = Request.QueryString[0].ToString();
        S_Code = S_Code.Replace(' ', '+');
        S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

        tb_SettlementRequest SR = new tb_SettlementRequest(S_Code);

        SR.Status = SettlementReq_Status.Inprogress;
        SR.SR_Update();
        ClientScript.RegisterStartupScript(this.GetType(), "", "parent.window.location.href = 'Admin/SettlementManagement.aspx';", true);
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        string S_Code = Request.QueryString[0].ToString();
        S_Code = S_Code.Replace(' ', '+');
        S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

        tb_SettlementRequest SR = new tb_SettlementRequest(S_Code);
        SR.Status = SettlementReq_Status.Rejected;
        SR.SR_Update();
        ClientScript.RegisterStartupScript(this.GetType(), "", "parent.window.location.href = 'Admin/SettlementManagement.aspx';", true);
    }
}