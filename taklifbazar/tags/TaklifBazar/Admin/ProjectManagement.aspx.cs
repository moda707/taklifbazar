using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProjectManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            string[] Tags = null;
            List<Admin_ProjectClass> LHW = Admin_ProjectClass.SearchByTag(Tags, Project_List_OrderBy.News, List_OrderType.Desc);
            int t = 5;            
            int PageNumb = 1;
            int PageCount = LHW.Count / t + 1;
            int tCount = LHW.Count;
            LHW = LHW.Take(t).ToList();                       

            string C = "";
            if (LHW.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th>فروشنده</th><th>امتیاز</th><th>فروش</th><th>قیمت</th><th></th></tr></thead><tbody>";
                foreach (Admin_ProjectClass a in LHW)
                {
                    C += "<tr><td>" + a.Pre_Paper_Code + "</td><td>" + a.TitleName + "</td><td>" + a.Owner_Name + "</td><td>" + a.Paper_Rate + "</td><td>" + a.Download_C + "</td><td>" + a.Price + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:HWDetAd('" + Encryption.Encrypt(a.Paper_Code,SharedDataInfo.SecurityKey) + "');\">جزئیات</button></td></tr>";
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
                    PG += "<li><a href=\"javascript:Ad_P_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:Ad_P_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}