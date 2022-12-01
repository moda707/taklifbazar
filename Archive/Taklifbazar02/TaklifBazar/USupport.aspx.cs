using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class USupport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        List<tb_SupportRequest> LSR = tb_SupportRequest.LoadByUser(User_Code, Support_List_Type.All);

        int t = 5;
        int PageNumb = 1;
        int PageCount = LSR.Count / t + 1;
        if ((LSR.Count / t) * t == LSR.Count) PageCount--;
        int tCount = LSR.Count;
        LSR = LSR.Take(t).ToList();

        string C = "";
        if (LSR.Count > 0)
        {
            C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th style=\"width:80px;\">تاریخ</th><th style=\"width:80px;\">ساعت</th><th>عنوان</th><th style=\"width:110px;\">دسته</th><th style=\"width:100px;\">ضرورت</th><th style=\"width:120px;\">وضعیت</th><th style=\"width:50px;\"></th></tr></thead><tbody>";
            foreach (tb_SupportRequest a in LSR)
            {
                Int64 TR_Code = Convert.ToInt64(a.Support_Code);
                DateTime D = new DateTime(TR_Code);

                string Tarikh = DateConversion.DateTimeToPersian(D);
                string Saat = D.Hour.ToString() + ":" + D.Minute;

                C += "<tr><td>" + a.Pre_Support_Code + "</td><td>" + Tarikh + "</td><td>" + Saat + "</td><td>" + a.Subject + "</td><td>" + tb_SupportRequest.GetFieldName(a.Fields) + "</td><td>" + tb_SupportRequest.GetPriorityName(a.Priority) + "</td><td><span" + tb_SupportRequest.GetSatusNamelbl(a.Status) + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:SupportDet('" + Encryption.Encrypt(a.Support_Code, SharedDataInfo.SecurityKey) + "')\">نمایش</button></td></tr>";
            }
            C += "</tbody></table>";
        }
        else
        {
            C = "موردی یافت نشد.";
        }
        TblCnt.InnerHtml = C;

        string PG = "<ul class=\"pagination\">";


        PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";

        for (var i = 1; i <= PageCount; i++)
        {
            if (i == 1)
            {
                PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:US_Search('" + i + "');\">" + i + "</a></li>";
            }
        }

        if (PageCount == 1)
        {
            PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
        }
        else
        {
            PG += "<li><a href=\"javascript:US_Search('2');\">«</a></li>";
        }


        PaginationPanel.InnerHtml = PG;
    }

    protected void btnSubmitReq_Click(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        tb_SupportRequest SR = new tb_SupportRequest();
        SR.Subject = txtFTitle.Value;
        SR.Fields = (Support_Fields)(Convert.ToInt32(slcField.Items[slcField.SelectedIndex].Value));
        SR.Priority = (Support_Prioroty)(Convert.ToInt32(slcPriority.Items[slcPriority.SelectedIndex].Value));
        SR.User_Code = User_Code;
        string Desc = txtdescription.Value.Replace(Environment.NewLine, "<br/>");
        Desc = Desc.Replace("'","-");
        Desc = Desc.Replace("\"","-");

        string Tarikh = DateConversion.DateTimeToPersian(DateTime.Now);
        DateTime d = DateTime.Now;
        string Saat = d.Hour + ":" + d.Minute;
        string str = "تاریخ: " + Tarikh + " ساعت: " + Saat + "\t\t |پاسخگو: محسن دستپاک" + "<br/><br/>";
        Desc = str + Desc;

        SR.Description = Desc;
        SR.Status = Support_Status.Submitted;
        SR.Pre_Support_Code = Encryption.GetUniqueKeyNum(6);

        SR.Support_Add();

    }
}