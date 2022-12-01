using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class USetting : System.Web.UI.Page
{
    public string txtEmail;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            
        }

    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        FillForm();
    }

    protected void FillForm()
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        Users CurU = new Users(User_Code);
        txtEmail = CurU.Email;
        txtMobile.Text = CurU.Mobile;
        txtaddress.Value = CurU.Address;
        txtPhone.Value = CurU.Phone;
        if (CurU.MobileVerification == 1)
        {
            lblMobileVerification.InnerHtml = "<span class=\"text-success\" style=\"font-size:9pt;\">شماره تائید شده است</span>";
        }
        else
            lblMobileVerification.InnerHtml = "<span class=\"text-danger\" style=\"font-size:9pt;\">شماره تائید نشده است  </span> <button class=\"btn btn-success\" type=\"button\" id=\"btnMobileVerificationForm\" onclick=\"javascript:USMobileVerification();\">تائید شماره</button>";

        txtAccountNum.Value = CurU.B_Account;
        txtCardNum.Value = CurU.B_Cardnumber;
        slcBankName.SelectedIndex = (int)CurU.B_Name;
        txtAccOwner.Value = CurU.B_AccOwner;
        slcSettlement.SelectedIndex = (int)CurU.B_Settlement;

        if (CurU.EmailRecieve == "1")
        {
            chkEmail.Checked = true;
        }
        else
            chkEmail.Checked = false;

        if (CurU.SMSRecieve == "1")
            chkSMS.Checked = true;
        else
            chkSMS.Checked = false;
    }
    protected void btnSaveGeneral_Click(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        Users CurU = new Users(User_Code);

        if (txtMobile.Text != CurU.Mobile)
        {
            CurU.Mobile = txtMobile.Text;
            CurU.MobileVerification = 0;
        }

        CurU.Address = txtaddress.Value;

        CurU.Phone = txtPhone.Value;


        CurU.User_Update();
        LC = new LoginClass(CurU);
        Session["LC"] = LC;
        FillForm();        
    }

    protected void btnSaveFinance_Click(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        Users CurU = new Users(User_Code);

        CurU.B_Account = txtAccountNum.Value;
        CurU.B_Cardnumber = txtCardNum.Value;
        CurU.B_Name = (Bank_Name)(Convert.ToInt32(slcBankName.Items[slcBankName.SelectedIndex].Value));
        CurU.B_AccOwner = txtAccOwner.Value;
        CurU.B_Settlement = (Settlement_Type)(Convert.ToInt32(slcSettlement.Items[slcSettlement.SelectedIndex].Value));

        CurU.User_Update();
        LC = new LoginClass(CurU);
        Session["LC"] = LC;
        FillForm();
        
    }

    protected void btnSavePass_Click(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        Users CurU = new Users(User_Code);

        if (Encryption.Encrypt(txtprevPass.Value, SharedDataInfo.SecurityKey) == CurU.Password)
        {
            if (txtNewPass.Value.Trim() == txtNewPassConfirm.Value.Trim())
            {
                CurU.Password = Encryption.Encrypt(txtNewPass.Value.Trim(), SharedDataInfo.SecurityKey);
            }
        }

        if (chkEmail.Checked)
            CurU.EmailRecieve = "1";
        else
            CurU.EmailRecieve = "0";

        if (chkSMS.Checked)
            CurU.SMSRecieve = "1";
        else
            CurU.SMSRecieve = "0";

        CurU.User_Update();
        LC = new LoginClass(CurU);
        Session["LC"] = LC;
        FillForm();
        
    }

    protected void btnSubmitVerificationCode_Click(object sender, EventArgs e)
    {
        //Check Code
        string Code = txtVerificationCode.Value;
        string MainCode = (string)Session["MC"];

        if (Code.Trim() == MainCode.Trim())
        {
            LoginClass LC = (LoginClass)Session["LC"];
            string User_Code = LC.User_Code;

            Users CurU = new Users(User_Code);
            CurU.Mobile = txtMobile.Text;
            CurU.MobileVerification = 1;
            LC = new LoginClass(CurU);
            Session["LC"] = LC;

            Session.Remove("MC");
        }
        else
        {
            //Error, Not match
            string jScript = "document.getElementById(\"lblMessage\").innerHTML = \"کد وارد شده معتبر نیست.\"; $(\"#lblMessage\").fadeIn(); $(\"#lblMessage\").fadeOut(3000);";//document.getElementById(\"SVC\").style.display = 'none';";
            //lblMobileVerification.Disabled = false;
            ClientScript.RegisterStartupScript(this.GetType(), "", jScript, true);
        }

    }
}