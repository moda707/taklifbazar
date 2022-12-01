using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vtocSqlInterface;


public partial class Download : System.Web.UI.Page
{
    public int ExpireDateDay = 7;
    public int ExpireDateMinute = 3;
    public string txtFiles;
    
    private sqlInterface mySql;
    private string sqlCmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!String.IsNullOrEmpty(Request.QueryString[0]))
            {
                string QS = Request.QueryString[0].ToString();
                QS = QS.Replace(' ', '+');
                string strURL = Encryption.Decrypt(QS, SharedDataInfo.SecurityKey);
                string[] arrURL = strURL.Split('!');

                DateTime d = new DateTime(Convert.ToInt64(arrURL[1]));
                if (d.AddMinutes(ExpireDateMinute).Ticks > DateTime.Now.Ticks)
                {
                    string filename = arrURL[0].Substring(arrURL[0].LastIndexOf('/') + 1);

                    // get the file bytes to download to the browser
                    byte[] fileBytes = System.IO.File.ReadAllBytes(MapPath(arrURL[0]));
                    // NOTE: You could also read the file bytes from a database as well.

                    // download this file to the browser
                    Download_File(filename, fileBytes);
                }
                else
                {
                    //Link is Expired
                }


                




            }
        }
        catch (Exception e2)
        {
            Response.Redirect("Default.aspx");
        }
 
        
    }

    public void Download_File(string sFileName, byte[] fileBytes)
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        context.Response.Clear();
        context.Response.ClearHeaders();
        context.Response.ClearContent();
        context.Response.AppendHeader("content-length", fileBytes.Length.ToString());
        context.Response.ContentType = GetMimeTypeByFileName(sFileName);
        context.Response.AppendHeader("content-disposition", "attachment; filename=" + sFileName);
        context.Response.BinaryWrite(fileBytes);

        // use this instead of response.end to avoid thread aborted exception (known issue):
        // http://support.microsoft.com/kb/312629/EN-US
        context.ApplicationInstance.CompleteRequest();
    }

    public string GetMimeTypeByFileName(string sFileName)
    {
        string sMime = "application/octet-stream";

        string sExtension = System.IO.Path.GetExtension(sFileName);
        if (!string.IsNullOrEmpty(sExtension))
        {
            sExtension = sExtension.Replace(".", "");
            sExtension = sExtension.ToLower();

            if (sExtension == "xls" || sExtension == "xlsx")
            {
                sMime = "application/ms-excel";
            }
            else if (sExtension == "doc" || sExtension == "docx")
            {
                sMime = "application/msword";
            }
            else if (sExtension == "ppt" || sExtension == "pptx")
            {
                sMime = "application/ms-powerpoint";
            }
            else if (sExtension == "rtf")
            {
                sMime = "application/rtf";
            }
            else if (sExtension == "zip")
            {
                sMime = "application/zip";
            }
            else if (sExtension == "mp3")
            {
                sMime = "audio/mpeg";
            }
            else if (sExtension == "bmp")
            {
                sMime = "image/bmp";
            }
            else if (sExtension == "gif")
            {
                sMime = "image/gif";
            }
            else if (sExtension == "jpg" || sExtension == "jpeg")
            {
                sMime = "image/jpeg";
            }
            else if (sExtension == "png")
            {
                sMime = "image/png";
            }
            else if (sExtension == "tiff" || sExtension == "tif")
            {
                sMime = "image/tiff";
            }
            else if (sExtension == "txt")
            {
                sMime = "text/plain";
            }
        }

        return sMime;
    }

    
}