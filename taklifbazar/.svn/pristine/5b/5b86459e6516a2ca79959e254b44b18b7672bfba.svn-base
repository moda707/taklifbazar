using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GroupView : System.Web.UI.Page
{
    public string GV;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString[0]))
                {
                    //string Mode = Request.QueryString[0].ToString();

                    //if (Mode == "-1")
                    {
                        string q = Request.QueryString[0].ToString();
                        string[] Tags = q.Substring(2,q.Length-2).Split(' ');
                        AllTags.InnerHtml = Request.QueryString[0].ToString().Replace(" " ,"!!");
                        HWShowClass HWSC = new HWShowClass();
                        List<Homework> LSH = Homework.SearchByTag(Tags, ViewType.News, 1, 8);
                        

                        string GV = txtGV.InnerHtml;
                        foreach (Homework a in LSH)
                        {
                            GV += "<div class=\"col-xs-6 col-sm-3\"><div class=\"thumbnail\" align=\"center\"><img src=\"images/MS-Word-icon.png\" class=\"img-thumbnail\" /><div class=\"caption text-right\"><div style=\"height:60px;\"><h3>" + a.TF_Name + "</h3>";
                            GV += "</div><div class=\"scrollbar\" style=\"height:100px;\"><p>" + a.P_Desc + "</p></div></div><p><a href=\"#\" class=\"btn btn-primary\">خرید</a> <a href=\"ProjView.aspx?=" + Encryption.Encrypt("ID=" + a.Paper_Code, SharedDataInfo.SecurityKey) + "\" class=\"btn btn-default\">مشاهده</a></p></div></div>";
                        }
                        txtGV.InnerHtml = GV;

                        if (LSH.Count == 8)
                        {
                            morebtn.InnerHtml = "<input style=\"width:100%;\" type=\"button\" id=\"btnMore\" class=\"btn btn-default\" value=\"نمایش بیشتر\" onclick=\"javascript: ShowMore();\" />";
                        }
                    }
                    //else
                    //{
                    //    try
                    //    {
                    //        ViewType T = (ViewType)Convert.ToInt16(Mode);


                    //    }
                    //    catch (Exception e3)
                    //    {
                    //        Response.Redirect("Default.aspx");
                    //    }
                    //}
                }
                else
                {
                    Response.Redirect("../TB/Home");
                }
            }
            catch (Exception e2)
            {
                Response.Redirect("../TB/Home");
            }
        }
    }
}