using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpPostedFile uploads = Request.Files["FileData"];
        string file = System.IO.Path.GetFileName(uploads.FileName);

        try
        {
            uploads.SaveAs("D:\\UploadedUserFiles\\" + file);
        }
        catch
        {
            //exception handling code
        }
    }
}