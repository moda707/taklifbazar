using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            List<Admin_UserClass> AUC = Admin_UserClass.LoadUsers(null, User_List_OrderBy.Date, List_OrderType.Desc);
            int t = 5;            
            int PageNumb = 1;
            int PageCount = AUC.Count / t + 1;
            int tCount = AUC.Count;
            AUC = AUC.Take(t).ToList();

            string C = "";
            if (AUC.Count > 0)
            {

                C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th>نام</th><th style=\"width:90px;\">تعداد تکلیف</th><th style=\"width:90px;\">فروش</th><th style=\"width:90px;\">خرید</th><th style=\"width:90px;\">موجودی</th><th style=\"width:40px;\"></th></tr></thead><tbody>";
                foreach (Admin_UserClass a in AUC)
                {
                    string Name = a.FFName + " " + a.FLName;
                    C += "<tr><td>" + a.RN + "</td><td>" + Name + "</td><td>" + a.HW_Count + "</td><td>" + a.HW_Sell + "</td><td>" + a.HW_Buy + "</td><td>" + a.AccBal + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"Ad_U_Det_" + a.RN + "\" onclick=\"javascript:UserDetAd('" + Encryption.Encrypt(a.User_Code, SharedDataInfo.SecurityKey) + "');\">جزئیات</button></td></tr>";
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
                    PG += "<li><a href=\"javascript:Ad_U_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:Ad_U_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}