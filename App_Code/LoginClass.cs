using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginClass
/// </summary>
public class LoginClass
{
    public string User_Code;
    public string FFName;
    public string FLName;
    public string EFName;
    public string ELName;
    
    public string Mobile;    
    public string Username;
    public string Email;
    public double Rate;
    public User_Type U_Type;

    public string EntranceTime;
    public string LastActivityTime;
    public string IP;

	public LoginClass()
	{
        User_Code = "0";
	}

    public LoginClass(Users U)
    {
        User_Code = U.User_Code;
        FFName = U.FFName;
        FLName = U.FLName;
        EFName = U.EFName;
        ELName = U.ELName;

        Mobile = U.Mobile;
        Username = U.Username;
        Email = U.Email;
        U_Type = U.U_Type;
        EntranceTime = DateTime.Now.Ticks.ToString();
        LastActivityTime = EntranceTime;
        IP = IPUtility.GetUser_IP();
    }

}

