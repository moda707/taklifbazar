using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vtocSqlInterface;

public partial class ProjView : System.Web.UI.Page
{
    public string txtFTitle;
    public string txtETitle;
    public string txtFieldsShow;
    public string txtDownloadC;
    public string txtPaper_Rate;
    public string txtOwner_Rate;
    public string txtOwner_Name;
    public string txtPrice;
    public string txtP_Desc;
    public string txtPrevFiles;

    private sqlInterface mySql;
    private string sqlCmd;

    public Homework HW;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString[0]))
                {
                    string QS = Request.QueryString[0].ToString();
                    QS = QS.Replace(' ', '+');
                    string DecQS = Encryption.Decrypt(QS, SharedDataInfo.SecurityKey);
                    string Paper_Code = DecQS;
                    HW = new Homework(Paper_Code);

                    txtFTitle = HW.TF_Name;
                    txtETitle = HW.TE_Name;
                    txtDownloadC = DownloadShow(HW.Download_C);
                    txtPaper_Rate = HW.Paper_Rate.ToString();
                    txtP_Desc = HW.P_Desc;

                    string[] Fields = HW.Fields.Split('!');
                    txtFieldsShow = " ";
                    foreach (string a in Fields)
                    {
                        txtFieldsShow += "<span class=\"label label-info\">" + a + "</span>  ";
                    }

                    txtPrice = NumericClass.int2Currency(HW.Price);

                    Users OwnerUser = new Users(HW.Owner_Code);                    
                    txtOwner_Name = OwnerUser.FFName + " " + OwnerUser.FLName;
                    txtOwner_Rate = "62";// OwnerUser.Credit1.ToString();

                    //Files
                    mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

                    sqlCmd = "SELECT T.*  FROM [PaperBank].[dbo].[FileList] T WHERE T.Paper_Code = '" + HW.Paper_Code + "'";
                    txtPrevFiles = "";
                    DataTable DT = mySql.SqlExecuteReader(sqlCmd);
                    List<FilesDetail> FList = new List<FilesDetail>();
                    int i=1;
                    foreach (DataRow r in DT.Rows)
                    {
                        string script = "javascript:RedirectDownload('" + Encryption.Encrypt(r[12].ToString(),SharedDataInfo.SecurityKey) + "');";
                        txtPrevFiles += "<tr><td style='width:15%; vertical-align:middle;'>" + i + "</td>";
                        txtPrevFiles += "<td align='center' style='vertical-align:middle;width:30%;'><img style='width:25px;' class='img-responsive' src='" + GetFileTypePic((File_Type)Convert.ToInt16(r[2].ToString())) + "' /></td>";
                        txtPrevFiles += "<td style='vertical-align:middle;width:30%;'>" + r[3].ToString() + "</td>";
                        txtPrevFiles += "<td style='vertical-align:middle;width:25%;' align='center'><img onclick=\"" + script + "\" id='btnFileDl_" + i + "' runat='server' style='width:25px; cursor:pointer;' src='images/pdf.png' class='img-responsive' /></td></tr>";
                                                
                        i++;
                    }

                    Session["CurHW"] = HW;
                }
            }
            catch (Exception e1)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    private string DownloadShow(int D)
    {
        return D.ToString();
    }

    private string GetFileSize()
    {
        return "";
    }

    private string GetFileTypePic(File_Type a)
    {
        switch (a)
        {
            case File_Type.Word:
                return "images/MS-Word-icon.png";
            case File_Type.Excel:
                return "images/Excel-icon.png";
            case File_Type.PowerPoint:
                return "images/PowerPoint-icon.png";
            case File_Type.PDF:
                return "images/MS-Word-icon.png";
            case File_Type.Unknown:
                return "";
            default:
                return "";
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        Session["HW2Buy"] = Session["CurHW"];
        Session["CurHW"] = null;
        Response.Redirect("Factor.aspx");
    }
}