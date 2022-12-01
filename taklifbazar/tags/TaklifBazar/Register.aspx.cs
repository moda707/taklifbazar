﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vtocSqlInterface;



public partial class Register : System.Web.UI.Page
{
    public string StrMobileNumber;
    public string mmc;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString[0]))
            {
                string QS = Request.QueryString[0].ToString();
                QS = QS.Replace(' ', '+');
                string DecQS = Encryption.Decrypt(QS, SharedDataInfo.SecurityKey);

                string StrState = "";
                string StrID = "";


                if (DecQS.Contains("&"))//has ID
                {
                    StrState = DecQS.Split('&')[0].Replace("State=", "");
                    StrID = DecQS.Split('&')[1].Replace("ID=", "");
                }
                else
                {
                    StrState = DecQS.Replace("State=", "");
                }


                switch (StrState)
                {
                    case "":

                        break;
                    case "FormSent":

                        break;
                    case "EmailVerified":
                        if (StrID == "")
                        {
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            Users newUser = new Users(StrID);                            

                            StrMobileNumber = newUser.Mobile;
                            mmc = RandomKey.GetUniqueKey(16);
                        }


                        break;
                    case "MobileVerified":

                        break;
                }
            }
            else
            {
                Response.Redirect("Register.aspx?=" + Encryption.Encrypt("State=Form", SharedDataInfo.SecurityKey));
            }
            //Query=''
            //Register Form

            //Query='FormSent'
            //

            //Query = 'EmailVerified'

            //SMSverification

            //Query = 'Mobile Verified'

            //Account is ready

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            Users newUser = new Users();

            newUser.FFName = txtFFName.Value;
            newUser.FLName = txtFLName.Value;
            newUser.EFName = txtEFName.Value;
            newUser.ELName = txtELName.Value;

            newUser.Province = Ostan.Items[Ostan.SelectedIndex].Text;
            newUser.City = Shahrestan.Value;
            newUser.Address = txtAddress.Value;
            newUser.Phone = txtPhone.Value;
            newUser.Mobile = "09" + txtMobile.Value;

            newUser.Education = (User_Education)(Convert.ToInt16(optEducation.Items[optEducation.SelectedIndex].Value));
            newUser.Field = (User_Field)(Convert.ToInt16(optField.Items[optField.SelectedIndex].Value));
            newUser.Job = (User_Job)(Convert.ToInt16(optJob.Items[optJob.SelectedIndex].Value));

            newUser.Username = txtUsername.Value;
            newUser.Email = txtEmail.Value;
            newUser.Password = Encryption.Encrypt(txtPass.Value, SharedDataInfo.SecurityKey);
            newUser.EmailRecieve = chkMail1.Value;
            newUser.SMSRecieve = chkSMS1.Value;

            newUser.B_Account = txtAccount.Value;
            newUser.B_Cardnumber = txtCardnumber.Value;
            newUser.B_Name = (Bank_Name)(Convert.ToInt16(optBankName.Items[optBankName.SelectedIndex].Value));
            if (txtAccOwner.Value.Trim() != "")
                newUser.B_AccOwner = txtAccOwner.Value;
            else
                newUser.B_AccOwner = txtFFName.Value + ' ' + txtFLName.Value;



            newUser.B_Settlement = (Settlement_Type)(Convert.ToInt16(optSettlement.Items[optSettlement.SelectedIndex].Value));

            newUser.RegisterDate = DateTime.Now.Ticks.ToString();
            newUser.EmailVerification = 0;
            newUser.MobileVerification = 0;
            newUser.LastActivityDate = DateTime.Now.Ticks.ToString();
            newUser.LastActivityIP = "";

            newUser.Credit1 = 0;
            newUser.Credit2 = 0;
            newUser.Credit3 = "";
            newUser.Credit4 = "";

            newUser.Data1 = 0;
            newUser.Data2 = 0;
            newUser.Data3 = "";
            newUser.Data4 = "";

            newUser.U_Type = User_Type.Admin;
            newUser.U_Access = User_Access.Full;
            newUser.U_Status = User_Status.Active;

            string UserCode = newUser.User_Add();

            if (UserCode != "")
            {
                //Send Email
                string EmailBody = "<div><table style=\"width:100%; direction:rtl; text-align:right;\"><tr><td style=\"text-align:left;\">Logo</td></tr><tr><td><img src=\"\" style=\"width:100%; height:200px;\" alt=\"تکلیف بازار\" /></td></tr><tr><td><span style=\"font-family:'Droid Arabic Naskh',serif; font-size:14pt; font-weight:bold; color: #3366CC;\">دوست عزیز سلام،</span><br /><span style=\"font-family:'Droid Arabic Naskh',serif; font-size:12pt;\">ورود شما را به «تکلیف بازار» خوش آمد می گوئیم و از شما درخواست می کنیم تا با کلیک کردن بر روی لینک زیر فرایند عضویت را به اتمام برسانید</span><br /><span>";
                EmailBody += "http://www.taklifbazar.com/Register.aspx?=" + Encryption.Encrypt("State=EmailVerified&ID=" + UserCode, SharedDataInfo.SecurityKey);
                EmailBody += "</span><br /><span style=\"font-family:'Droid Arabic Naskh',serif; font-size:12pt;\">با سپاس فراوان</span><br /><a href=\"http:\\www.taklifbazar.com\"><img src=\"\" style=\"width:40px; height:40px;\" alt=\"تکلیف بازار\" /></a></td></tr></table></div>";

                EmailService ES = new EmailService(txtEmail.Value, "info@taklifbazar.com", "تکمیل فرایند عضویت", EmailBody);
                if (ES.SendEmail())
                {
                    //Server.Transfer("Register\\" + Encryption.Encrypt("State=FormSent", SharedDataInfo.SecurityKey));
                    Response.Redirect("Register.aspx?=" + Encryption.Encrypt("State=FormSent", SharedDataInfo.SecurityKey));
                }
                else
                {
                    //Error Send Email
                }
            }
            else
            {
                //Error Add to Database
            }


        }
        else
        {
            //Error Recaptcha
        }
    }
    
    protected void btnSubmitVerificationCode_Click(object sender, EventArgs e)
    {
        //Check Code
        string Code = txtVerificationCode.Value;
        string MainCode = (string)Session["MC"];
        
        if (Code.Trim() == MainCode.Trim())
        {
            Response.Redirect("Register.aspx?=" + Encryption.Encrypt("State=MobileVerified",SharedDataInfo.SecurityKey));
        }
        else
        {
            //Error, Not match
        }
        
    }
}
