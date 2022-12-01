using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SupportManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<tb_SupportRequest> SC = tb_SupportRequest.LoadByUser("", Support_List_Type.All);
            int t = 5;            
            int PageNumb = 1;
            int PageCount = SC.Count / t + 1;
            int tCount = SC.Count;
            SC = SC.Take(t).ToList();

  
            string C = "";
            if (SC.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>کد</th><th>تاریخ</th><th>ساعت</th><th>کاربر</th><th>عنوان</th><th>دسته</th><th>اولویت</th><th>وضعیت</th><th></th></tr></thead><tbody>";
                foreach (tb_SupportRequest a in SC)
                {
                    Int64 TR_Code = Convert.ToInt64(a.Support_Code);
                    DateTime D = new DateTime(TR_Code);

                    string Tarikh = DateConversion.DateTimeToPersian(D);
                    string Saat = D.Hour.ToString() + ":" + D.Minute;

                    C += "<tr><td>" + a.Pre_Support_Code + "</td><td>" + Tarikh + "</td><td>" + Saat + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "');\">" + a.User_Name + "</a></td><td>" + a.Subject.Substring(0, Math.Min(a.Subject.Length, 25)).ToString() + "</td><td>" + tb_SupportRequest.GetFieldName(a.Fields) + "</td><td>" + tb_SupportRequest.GetPriorityName(a.Priority) + "</td><td><span" + tb_SupportRequest.GetSatusNamelbl(a.Status) + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:ResponseSU('" + Encryption.Encrypt(a.Support_Code, SharedDataInfo.SecurityKey) + "');\">نمایش</button></td></tr>";
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
                    PG += "<li><a href=\"javascript:Ad_SU_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:Ad_SU_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}