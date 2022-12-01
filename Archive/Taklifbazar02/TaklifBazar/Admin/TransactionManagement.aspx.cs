using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TransactionManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<Admin_TransactionClass> ATC = Admin_TransactionClass.LoadByUser("", Transaction_List_ShowType.All);
            int t = 5;            
            int PageNumb = 1;
            int PageCount = ATC.Count / t + 1;
            int tCount = ATC.Count;
            ATC = ATC.Take(t).ToList();

            string C = "";
            if (ATC.Count > 0)
            {
                C = "<table class=\"table table-striped\"><thead><tr><th>کاربر</th><th>تاریخ</th><th>ساعت</th><th>موضوع</th><th>از/به</th><th>مقدار</th><th></th></tr></thead><tbody>";
                foreach (Admin_TransactionClass a in ATC)
                {
                    Int64 TR_Code = Convert.ToInt64(a.Transaction_Code);
                    DateTime D = new DateTime(TR_Code);

                    string Tarikh = DateConversion.DateTimeToPersian(D);
                    string Saat = D.Hour.ToString() + ":" + D.Minute;

                    string FromTo = "";
                    if (a.InOut == InOut_Type.Out)
                    {
                        FromTo = "واریز به حساب ";
                        switch (a.Trans_Type)
                        {
                            case Transaction_Type.Buy:
                                FromTo += "تکلیف بازار";
                                break;
                            case Transaction_Type.Sell:
                                FromTo += "کاربر شماره " + a.BN_Source;
                                break;
                            case Transaction_Type.Settle:
                                FromTo += " شماره " + a.BN_Source;
                                break;
                        }
                    }
                    else
                    {
                        FromTo = "واریز از حساب ";
                        switch (a.Trans_Type)
                        {
                            case Transaction_Type.Buy:
                                if (a.CurAccType == CurrentAccount_Type.Local)
                                    FromTo += "کاربر شماره " + a.BN_Source;
                                else
                                    FromTo += "کاربر میهمان -" + a.BN_Portal.ToString();
                                break;
                            case Transaction_Type.Sell:
                                FromTo += "تکلیف بازار";
                                break;
                            case Transaction_Type.Add:
                                FromTo += " شماره " + a.BN_Portal.ToString();
                                break;
                        }
                    }

                    C += "<tr><td><a href=\"#\" class=\"btn btn-link\" onclick=\"javascript:UserDetAd('" + Encryption.Encrypt(a.User_Code, SharedDataInfo.SecurityKey) + "')\">" + a.User_Name + "</a></td><td>" + Tarikh + "</td><td>" + Saat + "</td><td>" + a.Subject + "</td><td>" + FromTo + "</td><td>" + a.Amount + "</td><td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:ShowHWDet('" + Encryption.Encrypt(a.Transaction_Code, SharedDataInfo.SecurityKey) + "');\">جزئیات</button></td></tr>";
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
                    PG += "<li><a href=\"javascript:Ad_TN_Search('" + i + "');\">" + i + "</a></li>";
                }
            }

            if (PageCount == 1)
            {
                PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:Ad_TN_Search('2');\">«</a></li>";
            }


            PaginationPanel.InnerHtml = PG;
        }
    }
}