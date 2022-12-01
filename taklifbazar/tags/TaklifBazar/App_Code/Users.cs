using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vtocSqlInterface;


/// <summary>
/// Summary description for Enums
/// </summary>
public class Users
{
    public string User_Code;
    public string Pre_User_Code;
    public string FFName;
    public string FLName;
    public string EFName;
    public string ELName;
    public string Province;
    public string City;
    public string Address;
    public string Phone;
    public string Mobile;
    public User_Education Education;
    public User_Field Field;
    public User_Job Job;
    public string Username;
    public string Email;
    public string Password;
    public string EmailRecieve;
    public string SMSRecieve;
    public string B_Account;
    public string B_Cardnumber;
    public Bank_Name B_Name;
    public string B_AccOwner;
    public Settlement_Type B_Settlement;
    public string RegisterDate;
    public int EmailVerification;
    public int MobileVerification;
    public string LastActivityDate;
    public string LastActivityIP;
    public double Credit1;
    public double Credit2;
    public string Credit3;
    public string Credit4;
    public double Data1;
    public double Data2;
    public string Data3;
    public string Data4;
    public User_Type U_Type;
    public User_Access U_Access;
    public User_Status U_Status;

    //[User_Code],[Pre_User_Code],[FFName],[FLName],[EFName],[ELName],[Province],[City],[Address],[Phone],[Mobile],[Education],[Field],[Job],[Username],[Email],[Password],[EmailRecieve],[SMSRecieve],[B_Account],[B_Cardnumber],[B_Name],[B_AccOwner],[B_Settlement],[RegisterDate],[EmailVerification],[MobileVerification],[U_Type],[U_Access],[U_Status],[LastActivityDate],[LastActivityIP],[Credit1],[Credit2],[Credit3],[Credit4],[Data1],[Data2],[Data3],[Data4]

    private sqlInterface mySql;
    private string sqlCmd;

	public Users()
	{
		
	}

    public Users(string UCode)
    {
        //[User_Code],[Pre_User_Code],[FFName],[FLName],[EFName],[ELName],[Province],[City],[Address],[Phone],[Mobile],[Education],[Field],[Job],[Username],[Email],[Password],[EmailRecieve],[SMSRecieve],[B_Account],[B_Cardnumber],[B_Name],[B_AccOwner],[B_Settlement],[RegisterDate],[EmailVerification],[MobileVerification],[U_Type],[U_Access],[U_Status],[LastActivityDate],[LastActivityIP],[Credit1],[Credit2],[Credit3],[Credit4],[Data1],[Data2],[Data3],[Data4]
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
        sqlCmd = string.Format(@"SELECT * FROM PaperBank.[dbo].[Users] T WHERE T.User_Code='{0}'", UCode);

        User_Code = UCode;
        DataTable tmpDT = new DataTable();
        tmpDT = mySql.SqlExecuteReader(sqlCmd);
        Pre_User_Code = tmpDT.Rows[0]["Pre_User_Code"].ToString();
        FFName = tmpDT.Rows[0]["FFName"].ToString();
        FLName = tmpDT.Rows[0]["FLName"].ToString();
        EFName = tmpDT.Rows[0]["EFName"].ToString();
        ELName = tmpDT.Rows[0]["ELName"].ToString();

        Province = tmpDT.Rows[0]["Province"].ToString();
        City = tmpDT.Rows[0]["City"].ToString();
        Address = tmpDT.Rows[0]["Address"].ToString();
        Phone = tmpDT.Rows[0]["Phone"].ToString();
        Mobile = tmpDT.Rows[0]["Mobile"].ToString();

        Education = (User_Education)tmpDT.Rows[0]["Education"];
        Field = (User_Field)tmpDT.Rows[0]["Field"];
        Job = (User_Job)tmpDT.Rows[0]["Job"];

        Username = tmpDT.Rows[0]["Username"].ToString();
        Email = tmpDT.Rows[0]["Email"].ToString();
        Password = tmpDT.Rows[0]["Password"].ToString();
        EmailRecieve = tmpDT.Rows[0]["EmailRecieve"].ToString();
        SMSRecieve = tmpDT.Rows[0]["SMSRecieve"].ToString();

        B_Account = tmpDT.Rows[0]["B_Account"].ToString();
        B_Cardnumber = tmpDT.Rows[0]["B_Cardnumber"].ToString();
        B_Name = (Bank_Name)tmpDT.Rows[0]["B_Name"];
        B_AccOwner = tmpDT.Rows[0]["B_AccOwner"].ToString();
        B_Settlement = (Settlement_Type)tmpDT.Rows[0]["B_Settlement"];

        RegisterDate = tmpDT.Rows[0]["RegisterDate"].ToString();
        EmailVerification = (int)tmpDT.Rows[0]["EmailVerification"];
        MobileVerification = (int)tmpDT.Rows[0]["MobileVerification"];
        LastActivityDate = tmpDT.Rows[0]["LastActivityDate"].ToString();
        LastActivityIP = tmpDT.Rows[0]["LastActivityIP"].ToString();
        try
        {
            Credit1 = (double)tmpDT.Rows[0]["Credit1"];
            Credit2 = (double)tmpDT.Rows[0]["Credit2"];
            Credit3 = tmpDT.Rows[0]["Credit3"].ToString();
            Credit4 = tmpDT.Rows[0]["Credit4"].ToString();
            Data1 = (double)tmpDT.Rows[0]["Data1"];
            Data2 = (double)tmpDT.Rows[0]["Data2"];
            Data3 = tmpDT.Rows[0]["Data3"].ToString();
            Data4 = tmpDT.Rows[0]["Data4"].ToString();
        }
        catch (Exception e2)
        {

        }
        U_Type = (User_Type)tmpDT.Rows[0]["U_Type"];
        U_Access = (User_Access)tmpDT.Rows[0]["U_Access"];
        U_Status = (User_Status)tmpDT.Rows[0]["U_Status"];


    }

    public string User_Add()
    {
        string UCode="";
        try
        {
            
            mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
            UCode = DateTime.Now.Ticks.ToString();
            Pre_User_Code = Encryption.GetUniqueKey(10);
            sqlCmd = string.Format(@"INSERT dbo.Users VALUES ('{0}', '{1}',       N'{2}', N'{3}', '{4}',  '{5}',  N'{6}',  N'{7}', N'{8}', '{9}', '{10}',      {11},        {12},      {13},    '{14}',  '{15}', N'{16}',    '{17}',       '{18}',     '{19}',      '{20}',        {21},     N'{22}',        {23},            '{24}',          {25},              {26},             {27},          {28},        {29},          '{30}',          '{31}',      {32},     {33},  N'{34}', N'{35}',  {36},  {37}, N'{38}',N'{39}')",
                                                            UCode, Pre_User_Code, FFName, FLName, EFName, ELName, Province, City, Address, Phone, Mobile, (int)Education, (int)Field, (int)Job, Username, Email, Password, EmailRecieve, SMSRecieve, B_Account, B_Cardnumber, (int)B_Name, B_AccOwner, (int)B_Settlement, RegisterDate, EmailVerification, MobileVerification, (int)U_Type, (int)U_Access, (int)U_Status, LastActivityDate, LastActivityIP, Credit1, Credit2, Credit3, Credit4, Data1, Data2, Data3, Data4);
            if (mySql.SqlExecuteNonQuery(sqlCmd))
            {
                return UCode;
            }
            else
                return "";
        }
        catch (Exception e)
        {
            return "";
        }        
    }

    public bool User_Update()
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
        sqlCmd = string.Format(@"UPDATE [dbo].[Users] SET [FFName] = N'{0}',[FLName] = N'{1}',[EFName] = '{2}',[ELName] = '{3}',[Province] = N'{4}',[City] = N'{5}',[Address] = N'{6}',[Phone] = '{7}',[Mobile] = '{8}',[Education] = {9},[Field] = {10},[Job] = {11},[Username] = '{12}',[Email] = '{13}',[Password] = N'{14}',[EmailRecieve] = '{15}',[SMSRecieve] = '{16}',[B_Account] = {17},[B_Cardnumber] = '{18}',[B_Name] = {19},[B_AccOwner] = N'{20}',[B_Settlement] = {21},[RegisterDate] = '{22}',[EmailVerification] = {23},[MobileVerification] = {24},[LastActivityDate] = '{25}',[LastActivityIP] = '{26}',[Credit1] = {27},[Credit2] = {28},[Credit3] = '{29}',[Credit4] = '{30}',[Data1] = {31},[Data2] = {32},[Data3] = '{33}',[Data4] = '{34}', [U_Type] = {35},[U_Access] = {36}, [U_Status] = {37}
	                            WHERE User_Code = '{38}'", FFName, FLName, EFName, ELName, Province, City, Address, Phone, Mobile, ((int)Education), ((int)Field), ((int)Job), Username, Email, Password, EmailRecieve, SMSRecieve, B_Account, B_Cardnumber, ((int)B_Name), B_AccOwner, ((int)B_Settlement), RegisterDate, EmailVerification, MobileVerification, LastActivityDate, LastActivityIP, Credit1, Credit2, Credit3, Credit4, Data1, Data2, Data3, Data4, ((int)U_Type), ((int)U_Access), (int)U_Status, User_Code);
        return mySql.SqlExecuteNonQuery(sqlCmd);
    }

    public bool User_Remove()
    {
        mySql = new sqlInterface(SharedDataInfo.ServerName, SharedDataInfo.DataBaseName, SharedDataInfo.UserName, SharedDataInfo.Password);
        sqlCmd = "DELETE FROM [dbo].[Users] WHERE User_Code='" + User_Code + "'";
        if (mySql.SqlExecuteNonQuery(sqlCmd))
        {
            return true;
        }
        else
            return false;
    }

    

}

public enum User_Type
{
    General = 0,
    Admin = 1
}

public enum User_Access
{
    Full = 0
}

public enum User_Education
{
    Rahnamayi = 0,
    Dabirestan = 1,
    Diplom = 2,
    FogheDiplom = 3,
    Karshenasi = 4,
    Arshad = 5,
    PhD = 6,
    DoktoraHerfei = 7
}

public enum User_Field
{
    All = 0
}

public enum User_Job
{
    UStudent = 0,
    HStudent = 1,
    Employee = 2,
    Researcher = 3,
    Unemployed = 4
}

public enum Settlement_Type
{
    Monthly = 0,
    HalfMonth = 1,
    Weekly = 2,
    Daily = 3
}

public enum Bank_Name
{
    Mellat = 0,
    Melli = 1,
    Tejarat = 2,
    Parsian = 3,
    Pasargad = 4
}

public enum User_Status
{
    Registered = 0,
    Active = 1,
    Suspended = 2,
    Deleted = 3
}
