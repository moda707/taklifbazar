using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SupportView : System.Web.UI.Page
{
    public string Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((LoginClass)Session["LC"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString[0]))
                {
                    string S_Code = Request.QueryString[0].ToString();
                    S_Code = S_Code.Replace(' ', '+');
                    S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

                    tb_SupportRequest SR = new tb_SupportRequest(S_Code);
                    txtPre_Code.InnerHtml = "#" + SR.Pre_Support_Code;
                    txtTarikh.InnerHtml = DateConversion.DateTimeToPersian(new DateTime(Convert.ToInt64(SR.Support_Code)));
                    txtUser.InnerHtml = SR.User_Name;
                    slcField.SelectedIndex = (int)(SR.Fields);
                    
                    slcPriority.SelectedIndex = (int)(SR.Priority);
                    
                    Status = "<span " + tb_SupportRequest.GetSatusNamelbl(SR.Status) + "</span>";
                    txtTitle.InnerHtml = SR.Subject;
                    txtDescription.InnerHtml = SR.Description;
                    
                    LoginClass LC = (LoginClass)Session["LC"];

                    if (LC.U_Type == User_Type.Admin)
                    {
                        slcField.Disabled = false;
                        slcPriority.Disabled = false;
                    }
                    else
                    {
                        slcField.Disabled = true;
                        slcPriority.Disabled = true;
                    }
                     
                }
            }
            catch (Exception e2)
            {

            }
        }
    }
    protected void btnReply_Click(object sender, EventArgs e)
    {
        
        string r = txtreply.Value;
        if (r.Trim() != "")
        {
            r = r.Replace(Environment.NewLine, "<br/>");
            r = r.Replace("'", "-");
            r = r.Replace("\"", "-");

            string S_Code = Request.QueryString[0].ToString();
            S_Code = S_Code.Replace(' ', '+');
            S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

            string Tarikh = DateConversion.DateTimeToPersian(DateTime.Now);
            DateTime d = DateTime.Now;
            string Saat = d.Hour + ":" + d.Minute;
            string str = "تاریخ: " + Tarikh + " ساعت: " + Saat + "\t\t |پاسخگو: محسن دستپاک" + "<br/><br/>";
            str = str + r + "<hr/>";

            str = str + txtDescription.InnerHtml;

            tb_SupportRequest SR = new tb_SupportRequest(S_Code);
            SR.Description = str;
            LoginClass LC = (LoginClass)Session["LC"];

            if (LC.U_Type == User_Type.Admin)
                SR.Status = Support_Status.Responsed;
            else
                SR.Status = Support_Status.Submitted;

            SR.Operator_Code = "0";

            SR.Support_Update();

            ClientScript.RegisterStartupScript(this.GetType(), "", "window.parent.$('#myModal').modal('hide');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('متن پیام را وارد کنید.');", true);
        }
    }

    protected void btnInProgress_Click(object sender, EventArgs e)
    {
        string S_Code = Request.QueryString[0].ToString();
        S_Code = S_Code.Replace(' ', '+');
        S_Code = Encryption.Decrypt(S_Code, SharedDataInfo.SecurityKey);

        tb_SupportRequest SR = new tb_SupportRequest(S_Code);
        SR.Status = Support_Status.Inprogress;

        SR.Support_Update();

        ClientScript.RegisterStartupScript(this.GetType(), "", "window.parent.$('#myModal').modal('hide');", true);
    }
}