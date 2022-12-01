using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SMSService
/// </summary>
public class SMSService
{
    public string FromNum;
    public string[] Recipients;
    public string Body;
    public string Title;

    public string Username;
    public string Password;

    public string SendSMSStatus;
    public string SendSMSRefIDs;

	public SMSService(string myUsername, string myPassword, string myLine)
	{
        Username = myUsername;
        Password = myPassword;
        FromNum = myLine;
	}

    public string SMSSend()
    {
        WebReference.Send sms = new WebReference.Send();
        long[] rec = null;
        byte[] status = null;

        
        int retval = sms.SendSms(Username, Password, Recipients, FromNum, Body, false, "", ref rec, ref status);


        string StringStatus = "";
        switch (retval)
        {
            case 0:
                StringStatus = "نام کاربری و یا رمز عبور اشتباه است";
                break;
            case 1:
                StringStatus = "ارسال با موفقیت انجام شده است";
                break;
            case 2:
                StringStatus = "اعتبار کافی نیست";
                break;
            case 3:
                StringStatus = "محدودیت در ارسال روزانه";
                break;
            case 4:
                StringStatus = "محدودیت در حجم ارسال";
                break;
            case 5:
                StringStatus = "شماره فرستنده معتبر نیست";
                break;
        }

        SendSMSStatus = StringStatus;

        for (int i = 0; i < rec.Length; i++)
        {
            SendSMSRefIDs += rec[i] + " : " + (status[i] == 0 ? "موفق" : "ناموفق") + "<br />";
        }

        return SendSMSStatus;
    }
}