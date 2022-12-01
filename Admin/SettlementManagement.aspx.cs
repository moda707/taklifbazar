using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SettlementManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<tb_SettlementRequest> SC = tb_SettlementRequest.LoadByUser("", Settlement_List_Tpe.All);
            int t = 5;            
            
            int PageNumb = 1;
            int PageCount = SC.Count / t + 1;
            int tCount = SC.Count;
            SC = SC.Take(t).ToList();

            string C = "";
            if (SC.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>کد</th><th>تاریخ</th><th>ساعت</th><th>کاربر</th><th>عنوان</th><th>مقدار</th><th>وضعیت</th><th></th></tr></thead><tbody>";
                foreach (tb_SettlementRequest a in SC)
                {
                    Int64 TR_Code = Convert.ToInt64(a.Req_Code);
                    DateTime D = new DateTime(TR_Code);

                    string Tarikh = DateConversion.DateTimeToPersian(D);
                    string Saat = D.Hour.ToString() + ":" + D.Minute.ToString("00");

                    C += "<tr><td>" + a.Pre_Req_Code + "</td><td>" + Tarikh + "</td><td>" + Saat + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "');\">" + a.User_Name + "</a></td><td>" + a.Subject + "</td><td>" + NumericClass.int2Currency(Convert.ToInt32(a.Amount)) + "</td><td><span" + tb_SettlementRequest.GetSRStatusNamelbl(a.Status) + "</span></td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:SettleDetAd('" + Encryption.Encrypt(a.Req_Code, SharedDataInfo.SecurityKey) + "');\">بررسی</button></td></tr>";
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

            for (var i = 1; i <=PageCount; i++)
            {
                if (i == 1)
                {
                    PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
                }
                else
                {
                    PG += "<li><a href=\"javascript:Ad_SL_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:Ad_SL_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}