using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TradeManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {  
            List<Admin_TradeClass> ATC = Admin_TradeClass.LoadByBuyerSeller("", "");
            int t = 5;
            int PageNumb = 1;
            int PageCount = ATC.Count / t + 1;
            int tCount = ATC.Count;
            ATC = ATC.Take(t).ToList();
            
            string C = "";
            if (ATC.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>تاریخ</th><th>ساعت</th><th>تکلیف</th><th>فروشنده</th><th>خریدار</th><th>قیمت</th><th></th></tr></thead><tbody>";
                foreach (Admin_TradeClass a in ATC)
                {
                    Int64 TR_Code = Convert.ToInt64(a.Trade_Code);
                    DateTime D = new DateTime(TR_Code);

                    string Tarikh = DateConversion.DateTimeToPersian(D);
                    string Saat = D.Hour.ToString("00") + ":" + D.Minute.ToString("00");
                    if (a.Pre_Paper_Code == "") a.Pre_Paper_Code = "111";

                    C += "<tr><td>" + Tarikh + "</td><td>" + Saat + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:HWDetAd('" + Encryption.Encrypt(a.Paper_Code,SharedDataInfo.SecurityKey) + "');\">" + a.Pre_Paper_Code + "</td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Encryption.Encrypt(a.Seller_Code, SharedDataInfo.SecurityKey) + "')\">" + a.Seller_Name + "</a></td><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Encryption.Encrypt(a.Buyer_Code, SharedDataInfo.SecurityKey) + "')\">" + a.Buyer_Name + "</a></td><td>" + NumericClass.int2Currency(Convert.ToInt32(a.Price)) + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"HWDet_" + a.Trade_Code + "\" onclick=\"javascript:ShowHWDet('" + Encryption.Encrypt(a.Trade_Code, SharedDataInfo.SecurityKey) + "');\">جزئیات</button></td></tr>";
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
                    PG += "<li><a href=\"javascript:Ad_TD_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:Ad_TD_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}