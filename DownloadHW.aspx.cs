using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vtocSqlInterface;

public partial class DownloadHW : System.Web.UI.Page
{
    public double ExpireDateDay = 7;
    public double ExpireDateMinute = 3;
    public string txtFiles;

    private sqlInterface mySql;
    private string sqlCmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString[0]))
        {
            string QS = Request.QueryString[0].ToString();
            QS = QS.Replace(' ', '+');
            string strURL = Encryption.Decrypt(QS, SharedDataInfo.SecurityKey);
            string[] arrURL = strURL.Split('!');

            string Paper_Code = arrURL[0];
            Int64 strDT = Convert.ToInt64(arrURL[1]);
            DateTime DT = new DateTime(strDT);
            DateTime DTE = DT.AddDays(ExpireDateDay);
            DateTime NowDT = DateTime.Now;
            if (DTE.Ticks > NowDT.Ticks)
            {
                //Files
                mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);

                sqlCmd = "SELECT T.*  FROM [PaperBank].[dbo].[FileList] T WHERE T.Paper_Code = '" + Paper_Code + "'";
                txtFiles = "";
                DataTable DT1 = mySql.SqlExecuteReader(sqlCmd);
                List<FilesDetail> FList = new List<FilesDetail>();
                int i = 1;
                foreach (DataRow r in DT1.Rows)
                {
                    string script = "javascript:RedirectDownload('" + Encryption.Encrypt(r[10].ToString() + "!" + DateTime.Now.Ticks.ToString(), SharedDataInfo.SecurityKey) + "');";
                    txtFiles += "<tr><td style='width:15%; vertical-align:middle;'>" + i + "</td>";
                    txtFiles += "<td align='center' style='vertical-align:middle;width:30%;'><span>" + r[4].ToString() + "</span></td>";
                    txtFiles += "<td style='vertical-align:middle;width:30%;'>" + r[3].ToString() + "</td>";
                    txtFiles += "<td style='vertical-align:middle;width:25%;' align='center'><img onclick=\"" + script + "\" id='btnFileDl_" + i + "' runat='server' style='width:25px; cursor:pointer;' src='" + GetFileTypePic((File_Type)Convert.ToInt16(r[2].ToString())) + "' class='img-responsive' /></td></tr>";

                    i++;
                }
            }
            else
            {
                //Link is Expired
            }
        }
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
}