using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestPage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "mail.taklifbazar.com"; 
            client.EnableSsl = false;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("info@taklifbazar.com", "177282523Mm!");
            // client.Credentials = new System.Net.NetworkCredential("info@yourdomain.com", "password");

            var messageBody = string.Format(" neveshte mored nazar inja bashad");
            var subject = "Subject";
            var recipient = "moh.dastpak@gmail.com";
            MailMessage mm = new MailMessage("info@taklifbazar.com", recipient, subject, messageBody);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}