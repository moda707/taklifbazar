using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;


/// <summary>
/// Summary description for EmailService
/// </summary>
public class EmailService
{
    public string To;
    public string From;
    public string Subject;
    public string Body;
    
	public EmailService(string myTo, string myFrom, string mySubject, string myBody)
	{
        To = myTo;
        From = myFrom;
        Subject = mySubject;
        Body = myBody;
	}

    public bool SendEmail()
    {
        try
        {
            //Send Email            
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(From);
            mailMessage.To.Add(new MailAddress(To));

            
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = Subject;
            mailMessage.Body = Body;

            SmtpClient smtpClient = new SmtpClient();
            //System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("info@taklifbazar.com", "177282523Mm!");
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("moh.dastpak@gmail.com", "177282523m");
            smtpClient.Host = "smtp.gmail.com";// "144.76.1.202";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = myCredential;
            smtpClient.ServicePoint.MaxIdleTime = 1;            
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            mailMessage.Dispose();            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

}