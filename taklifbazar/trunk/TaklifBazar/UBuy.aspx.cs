using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UBuy : System.Web.UI.Page
{
    public string txtTotalBuy;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            LoginClass LC = (LoginClass)Session["LC"];
            string Buyer_Code = LC.User_Code;            
            List<Homework> LHW = Homework.SearchByBuyer(Buyer_Code);
            int t = 5;            
            int PageNumb = 1;
            int PageCount = LHW.Count / t + 1;
            int tCount = LHW.Count;
            LHW = LHW.Take(t).ToList();
            txtTotalBuy = NumericClass.int2Currency(LHW.Sum(x => x.Price));
            
            string C = "";
            if (LHW.Count > 0)
            {
                
                C = "<table class=\"table table-striped\"><thead><tr><th>#</th><th>عنوان</th><th style=\"width:70px;\">قیمت</th><th style=\"width:40px;\"></th></tr></thead><tbody>";
                foreach (Homework a in LHW)
                {
                    string Name = a.TF_Name;
                    if (Name.Trim() == "") Name = a.TE_Name;
                    C += "<tr><td>" + a.RN + "</td><td>" + Name + "</td><td>" + NumericClass.int2Currency(Convert.ToInt32(a.Price)) + "</td><td><button type=\"button\" class=\"btn btn-link\" id=\"UB_HWDet_" + a.RN + "\" onclick=\"javascript:ShowHWDet('" + a.Paper_Code + "');\">جزئیات</button></td></tr>";
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
                    PG += "<li><a href=\"javascript:UB_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:UB_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}