﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


public partial class DoAction1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string QS_Action = Request.QueryString["Action"].ToString();
        List<FieldProp> FP = new List<FieldProp>();
        XDocument xml = new XDocument();
        string Res = "";
        string Count1;
        string Page1;
        string Code = "";

        LoginClass LC = new LoginClass();
        LC = (LoginClass)Session["LC"];

        switch (QS_Action)
        {

            case "SendSMS":

                string ModeS = Request.QueryString["Mode"].ToString();

                switch (ModeS)
                {
                    case "Verification":
                        string[] Rc = new string[1];
                        Rc[0] = Request.QueryString["Rc"].ToString();
                        Random k = new Random();
                        Code = k.Next(1000, 10000).ToString();
                        string Body = "**تکلیف بازار** \n کد : " + Code;

                        string Result = SendVerificationCodeSMS(Rc, Body);
                        xml = XDocument.Parse("<CATALOG><STATE>" + Result + "</STATE></CATALOG>");
                        Session["MC"] = Code;
                        Response.Write(xml);
                        break;

                }
                break;
            case "FindFields":
                string Val = Request.QueryString["Value"].ToString();
                string strFields = FindFields(Val);
                xml = XDocument.Parse(strFields);
                Response.Write(xml);
                break;
            case "AddField":
                try
                {
                    Code = Request.QueryString["Code"].ToString();
                    string tName = Code.Split('!')[1];
                    Code = Code.Split('!')[0];


                    try
                    {
                        FP = (List<FieldProp>)Session["FPL"];
                    }
                    catch (Exception e2)
                    {
                    }

                    if (FP == null)
                    {
                        FP = new List<FieldProp>();
                    }

                    if (FP.FindAll(x => x.Code == Code).Count() == 0)
                    {
                        FP.Add(new FieldProp(Code, tName, 0));
                        Session["FPL"] = FP;
                        xml = XDocument.Parse("<CATALOG><STATE>true</STATE></CATALOG>");
                        Response.Write(xml);
                    }
                    else
                    {
                        xml = XDocument.Parse("<CATALOG><STATE>false</STATE></CATALOG>");
                        Response.Write(xml);
                    }

                }
                catch (Exception e21)
                {
                    xml = XDocument.Parse("<CATALOG><STATE>false</STATE></CATALOG>");
                    Response.Write(xml);
                }
                break;
            case "RemoveField":
                FP = (List<FieldProp>)Session["FPL"];
                Code = Request.QueryString["Code"].ToString();
                try
                {
                    FP.Remove(FP.First(x => x.Code == Code));
                    Session["FPL"] = FP;

                    xml = XDocument.Parse("<CATALOG><STATE>true</STATE></CATALOG>");
                    Response.Write(xml);
                }
                catch (Exception e3)
                {
                    xml = XDocument.Parse("<CATALOG><STATE>false</STATE></CATALOG>");
                    Response.Write(xml);
                }
                break;
            case "RemoveHW":
                Code = Request.QueryString["Code"].ToString();
                Code = Code.Replace(' ', '+');
                Code = Encryption.Decrypt(Code, SharedDataInfo.SecurityKey);
                HWShowClass HWSC1 = (HWShowClass)Session["UP_SHW"];
                HWSC1.AllHW.Remove(HWSC1.AllHW.First(x => x.Paper_Code == Code));
                HWSC1.tCount -= 1;
                Session["UP_SHW"] = HWSC1;

                Homework h = new Homework(Code);
                h.Status = P_Status.Deleted;
                bool t = h.HW_Update();
                if (t)
                    xml = XDocument.Parse("<CATALOG><STATE>true</STATE></CATALOG>");
                else
                    xml = XDocument.Parse("<CATALOG><STATE>false</STATE></CATALOG>");
                Response.Write(xml);
                break;
            case "SearchHW":
                string tt = Request.QueryString["Value"].ToString();
                string tCount = Request.QueryString["Count"].ToString();
                string Owner_Code = LC.User_Code;
                Res = DoSearchHW(Owner_Code, tt, tCount);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "UP_Search":
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoUPSearch(LC.User_Code, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "US_Search":
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoUSSearch(LC.User_Code, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "UA_Search":
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoUASearch(LC.User_Code, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "UASR_Search":
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoUASRSearch(LC.User_Code, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "UB_Search":
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoUBSearch(LC.User_Code, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);                
                break;
            case "Ad_SU_Search":
                string v = Request.QueryString["rt"].ToString();
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoSUSearch(v, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "Ad_SL_Search":
                v = Request.QueryString["rt"].ToString();
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoSLSearch(v, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "Ad_P_Search"://Search, Order, Pagination
                string[] Tags = Request.QueryString["Tags"].ToString().Split('!');
                Project_List_OrderBy OB = (Project_List_OrderBy) Convert.ToInt32(Request.QueryString["ob"].ToString());
                List_OrderType OT = (List_OrderType)Convert.ToInt32(Request.QueryString["ot"].ToString());
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoProjectSearch(Tags, OB, OT, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "Ad_U_Search"://Search, Order, Pagination
                Tags = Request.QueryString["Tags"].ToString().Split('!');
                User_List_OrderBy OB1 = (User_List_OrderBy)Convert.ToInt32(Request.QueryString["ob"].ToString());
                OT = (List_OrderType)Convert.ToInt32(Request.QueryString["ot"].ToString());
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoUserSearch(Tags, OB1, OT, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "Ad_TD_Search":
                string Seller = Request.QueryString["Seller"].ToString();
                string Buyer = Request.QueryString["Buyer"].ToString();
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoTDSearch(Seller, Buyer, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "Ad_TN_Search":
                string User_Code = Request.QueryString["UCode"].ToString();
                string rt = Request.QueryString["rt"].ToString();
                Page1 = Request.QueryString["P"].ToString();
                Count1 = Request.QueryString["C"].ToString();
                Res = DoTNSearch(User_Code, rt, Page1, Count1);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "ShowMore":
                int _StartAt = Convert.ToInt32(Request.QueryString[1].ToString());
                string[] _Tags = Request.QueryString[2].ToString().Split('!');
                ViewType _VT = (ViewType)Convert.ToInt32(Request.QueryString[3].ToString());
                List<Homework> HWSC = Homework.SearchByTag(_Tags, _VT, _StartAt, 8);
                if (HWSC.Count == 8)
                    Res = HW2XML(HWSC, "", "");
                else
                    Res = HW2XML(HWSC, "All", "");
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "GV_Order":
                _Tags = Request.QueryString[1].ToString().Split('!');
                _VT = (ViewType)Convert.ToInt32(Request.QueryString[2].ToString());
                HWSC = Homework.SearchByTag(_Tags, _VT, 1, 8);
                if (HWSC.Count == 8)
                    Res = HW2XML(HWSC, "", "");
                else
                    Res = HW2XML(HWSC, "All", "");
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
            case "SettlementRequest":
                Int32 AccBal = Convert.ToInt32(Request.QueryString["AB"].ToString().Replace(",",""));
                int RP = Convert.ToInt32(Request.QueryString["RP"].ToString());
                int RD = Convert.ToInt32(Request.QueryString["RD"].ToString());
                Res = SettlementRequest(AccBal, RP, RD);
                xml = XDocument.Parse(Res);
                Response.Write(xml);
                break;
        }
    }

    private string SendVerificationCodeSMS(string[] Recipient, string Body)
    {
        //Send SMS
        SMSService SMS = new SMSService(SharedDataInfo.SMSServiceUsername, SharedDataInfo.SMSServicePassword, SharedDataInfo.SMSServiceLine);
        SMS.Recipients = Recipient;
        SMS.Body = Body;
        return SMS.SMSSend();
    }

    private string FindFields(string t)
    {
        string XMLPack = "";
        XMLPack = "<CATALOG>";
        XMLPack += "<Field>";
        XMLPack += "<Code>11</Code>";
        XMLPack += "<Name>TagName1</Name>";
        XMLPack += "</Field>";

        XMLPack += "<Field>";
        XMLPack += "<Code>12</Code>";
        XMLPack += "<Name>TagName2</Name>";
        XMLPack += "</Field>";

        XMLPack += "<Field>";
        XMLPack += "<Code>13</Code>";
        XMLPack += "<Name>TagName3</Name>";
        XMLPack += "</Field>";

        XMLPack += "<Field>";
        XMLPack += "<Code>14</Code>";
        XMLPack += "<Name>TagName4</Name>";
        XMLPack += "</Field>";

        XMLPack += "</CATALOG>";

        return XMLPack;
    }

    private string DoProjectSearch(string[] _Tags, Project_List_OrderBy _OB, List_OrderType _OT, string _P, string _C)
    {
        List<Admin_ProjectClass> AP = Admin_ProjectClass.SearchByTag(_Tags, _OB, _OT);
        int cc;
        if (_C == "All") cc = AP.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = AP.Count / cc + 1;
        AP = AP.Skip(lower).Take(cc).ToList();

        return Ad_P2XML(AP, PC.ToString(), _P);
    } //Project for Admin

    private string DoUserSearch(string[] _Tags, User_List_OrderBy _OB, List_OrderType _OT, string _P, string _C)
    {
        List<Admin_UserClass> AP = Admin_UserClass.LoadUsers(_Tags, _OB, _OT);
        int cc;
        if (_C == "All") cc = AP.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = AP.Count / cc + 1;        
        AP = AP.Skip(lower).Take(cc).ToList();

        return Ad_U2XML(AP, PC.ToString(), _P);
    }

    public string DoSearchHW(string Owner_Code, string AllTags, string strCount)
    {
        List<Homework> LHW= Homework.SearchByOwnerAndTag(Owner_Code, AllTags);;
        
       

        int TC = 0;

        if (strCount == "All")
        {
            TC = LHW.Count;
        }
        else
        {
            TC = Convert.ToInt16(strCount);// Math.Min(Convert.ToInt16(strCount), LHW.Count);
        }

        List<Homework> ShowLHW = LHW.Take(TC).ToList();

        HWShowClass HWSC = new HWShowClass();
        HWSC.AllHW = LHW;
        HWSC.ToShowHW = ShowLHW;
        HWSC.PageNumb = 1;
        HWSC.PageCount = (int)(LHW.Count / TC) + 1;
        HWSC.tCount = LHW.Count;

        Session["UP_SHW"] = HWSC; //UProject_Searched Homework

        return HW2XML(ShowLHW,HWSC.PageCount.ToString(),"1");
        
    }

    public string DoUPSearch(string UCode, string _P, string _C) //Support for user
    {
        List<Homework> LSR = Homework.SearchByOwner(UCode);
        int cc;
        if (_C == "All") cc = LSR.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = LSR.Count / cc + 1;
        LSR = LSR.Skip(lower).Take(cc).ToList();

        return HW2XML(LSR, PC.ToString(), PN.ToString());
    }

    public string DoUBSearch(string UCode, string _P, string _C)
    {
        List<Homework> LH = Homework.SearchByBuyer(UCode);
        int cc;
        if (_C == "All") cc = LH.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int upper = Math.Min((PN - 1) * cc + (cc - 1), LH.Count);
        int PC = LH.Count / cc + 1;
        LH = LH.Skip(lower).Take(cc).ToList();

        return HW2XML(LH, PC.ToString(), PN.ToString());
    } //Buy for user

    public string DoTDSearch(string _Seller, string _Buyer, string _P, string _C)
    {
        List<Admin_TradeClass> ATC = Admin_TradeClass.LoadByBuyerSeller(_Buyer, _Seller);
        int cc;
        if (_C == "All") cc = ATC.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = ATC.Count / cc + 1;
        ATC = ATC.Skip(lower).Take(cc).ToList();
        return Ad_TD2XML(ATC, PC.ToString(), PN.ToString());
    } //TD for Admin

    public string DoTNSearch(string _User_Code, string _rt, string _P, string _C)
    {
        List<Admin_TransactionClass> ATC = Admin_TransactionClass.LoadByUser(_User_Code, (Transaction_List_ShowType)Convert.ToInt32(_rt));

        int cc;
        if (_C == "All") cc = ATC.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;        
        int PC = ATC.Count / cc + 1;
        ATC = ATC.Skip(lower).Take(cc).ToList();

        return Ad_TN2XML(ATC, PC.ToString(), PN.ToString());
    } //TN for Admin

    public string DoSUSearch(string V, string _P, string _C) //Support for Admin
    {        
        List<tb_SupportRequest> LSR = tb_SupportRequest.LoadByUser("", (Support_List_Type)Convert.ToInt32(V));
        int cc;
        if (_C == "All") cc = LSR.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = LSR.Count / cc + 1;
        LSR = LSR.Skip(lower).Take(cc).ToList();

        return SU2XML(LSR, PC.ToString(), PN.ToString());
    }

    public string DoUSSearch(string UCode, string _P, string _C) //Support for user
    {
        List<tb_SupportRequest> LSR = tb_SupportRequest.LoadByUser(UCode, Support_List_Type.All);
        int cc;
        if (_C == "All") cc = LSR.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = LSR.Count / cc + 1;
        LSR = LSR.Skip(lower).Take(cc).ToList();

        return SU2XML(LSR, PC.ToString(), PN.ToString());
    }

    public string DoUASearch(string UCode, string _P, string _C)
    {
        List<tb_Transactions> LTN = tb_Transactions.LoadByUser(UCode);
        int cc;
        if (_C == "All") cc = LTN.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int upper = Math.Min((PN - 1) * cc + (cc - 1), LTN.Count);
        int PC = LTN.Count / cc + 1;
        LTN = LTN.Skip(lower).Take(cc).ToList();

        return TR2XML(LTN, PC.ToString(), PN.ToString());
    } //TN for Users

    public string DoUASRSearch(string UCode, string _P, string _C) //Settlement for Users
    {
        List<tb_SettlementRequest> LSR = tb_SettlementRequest.LoadByUser(UCode, Settlement_List_Tpe.All);
        int cc;
        if (_C == "All") cc = LSR.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int upper = Math.Min((PN - 1) * cc + (cc - 1), LSR.Count);
        int PC = LSR.Count / cc + 1;
        LSR = LSR.Skip(lower).Take(cc).ToList();

        return SR2XML(LSR, PC.ToString(), PN.ToString());
    }

    public string DoSLSearch(string V, string _P, string _C) //Settlement for Admin
    {
        List<tb_SettlementRequest> LSR = tb_SettlementRequest.LoadByUser("", (Settlement_List_Tpe)Convert.ToInt32(V));
        int cc;
        if (_C == "All") cc = LSR.Count; else cc = Convert.ToInt16(_C);
        int PN = Convert.ToInt16(_P);
        int lower = (PN - 1) * cc;
        int PC = LSR.Count / cc + 1;
        LSR = LSR.Skip(lower).Take(cc).ToList();

        return SR2XML(LSR, PC.ToString(), PN.ToString());
    }

    public string HW2XML(List<Homework> HW, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        foreach (Homework a in HW)
        {
            XMLPack += "<Homework>";
            XMLPack += "<RN>" + a.RN + "</RN>";
            XMLPack += "<Paper_Code>" + Encryption.Encrypt(a.Paper_Code,SharedDataInfo.SecurityKey) + "</Paper_Code>";
            XMLPack += "<Owner_Code>" + Encryption.Encrypt(a.Owner_Code,SharedDataInfo.SecurityKey) + "</Owner_Code>";
            XMLPack += "<Upload_Date>" + a.Uploade_Date + "</Upload_Date>";
            XMLPack += "<TF_Name>" + a.TF_Name + "</TF_Name>";
            XMLPack += "<TE_Name>" + a.TE_Name + "</TE_Name>";
            XMLPack += "<P_Desc>" + a.P_Desc + "</P_Desc>";
            XMLPack += "<Fields>" + a.Fields + "</Fields>";
            XMLPack += "<Audience>" + a.Audience + "</Audience>";
            XMLPack += "<Abstract>" + a.Abstract + "</Abstract>";
            XMLPack += "<ST>" + ((int)a.ST).ToString() + "</ST>";
            XMLPack += "<Price>" + NumericClass.int2Currency(Convert.ToInt32(a.Price)) + "</Price>";
            XMLPack += "<FeesPercent>" + a.FeesPercent + "</FeesPercent>";
            XMLPack += "<T_Word_C>" + a.T_Word_C + "</T_Word_C>";
            XMLPack += "<T_Char_C>" + a.T_Char_C + "</T_Char_C>";
            XMLPack += "<Status>" + ((int)a.Status).ToString() + "</Status>";
            XMLPack += "<LastModifiedDate>" + a.LastModifiedDate + "</LastModifiedDate>";
            XMLPack += "<Download_C>" + a.Download_C + "</Download_C>";
            XMLPack += "</Homework>";
        }
        XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
        XMLPack += "</CATALOG>";

        

        return XMLPack;
    }

    public string TR2XML(List<tb_Transactions> TR, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        foreach (tb_Transactions a in TR)
        {
            XMLPack += "<Transaction>";
            XMLPack += "<RN>" + a.RN + "</RN>";
            XMLPack += "<Transaction_Code>" + a.Transaction_Code + "</Transaction_Code>";
            XMLPack += "<Trade_Code>" + a.Trade_Code + "</Trade_Code>";
            XMLPack += "<User_Code>" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "</User_Code>";
            XMLPack += "<Trans_Type>" + ((int)a.Trans_Type).ToString() + "</Trans_Type>";
            XMLPack += "<Trans_Subject>" + a.Trans_Subject + "</Trans_Subject>";
            XMLPack += "<Amount>" + NumericClass.int2Currency(Convert.ToInt32(a.Amount)) + "</Amount>";
            XMLPack += "<InOut>" + ((int)a.InOut).ToString() + "</InOut>";
            XMLPack += "<CurAcc_Type>" + ((int)a.CurAcc_Type).ToString() + "</CurAcc_Type>";
            XMLPack += "<User_IP>" + a.User_IP + "</User_IP>";
            XMLPack += "<BN_Portal>" + ((int)a.BN_Portal).ToString() + "</BN_Portal>";
            XMLPack += "<BN_Source>" + a.BN_Source + "</BN_Source>";
            XMLPack += "<AccBalance>" + NumericClass.int2Currency(Convert.ToInt32(a.AccBalance)) + "</AccBalance>";
            
            Int64 TR_Code = Convert.ToInt64(a.Transaction_Code);
            DateTime D = new DateTime(TR_Code);
            string Tarikh = DateConversion.DateTimeToPersian(D);
            string Saat = D.Hour.ToString() + ":" + D.Minute.ToString("00");
            XMLPack += "<Tarikh>" + Tarikh + "</Tarikh>";
            XMLPack += "<Saat>" + Saat + "</Saat>";            
            XMLPack += "</Transaction>";
        }
        XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
        XMLPack += "</CATALOG>";



        return XMLPack;
    }

    public string SR2XML(List<tb_SettlementRequest> SR, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        foreach (tb_SettlementRequest a in SR)
        {
            XMLPack += "<SR>";
            XMLPack += "<RN>" + a.RN + "</RN>";

            XMLPack += "<Req_Code>" + Encryption.Encrypt(a.Req_Code,SharedDataInfo.SecurityKey) + "</Req_Code>";
            if (a.Pre_Req_Code == "") a.Pre_Req_Code = "123";
            XMLPack += "<Pre_Req_Code>" + a.Pre_Req_Code + "</Pre_Req_Code>";
            XMLPack += "<User_Code>" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "</User_Code>";
            XMLPack += "<User_Name>" + a.User_Name + "</User_Name>";

            Int64 SR_Code = Convert.ToInt64(a.Req_Code);
            DateTime D = new DateTime(SR_Code);
            string Tarikh = DateConversion.DateTimeToPersian(D);
            string Saat = D.Hour.ToString() + ":" + D.Minute.ToString("00");
            XMLPack += "<Tarikh>" + Tarikh + "</Tarikh>";
            XMLPack += "<Saat>" + Saat + "</Saat>";
            if (a.Subject == "") a.Subject = "خالی";
            XMLPack += "<Subject>" + a.Subject + "</Subject>";
            XMLPack += "<Amount>" + NumericClass.int2Currency(Convert.ToInt32(a.Amount)) + "</Amount>";
            XMLPack += "<Status>" + tb_SettlementRequest.GetSRStatusNamelbl(a.Status) + "</Status>";
            
            XMLPack += "</SR>";
        }
        XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
        XMLPack += "</CATALOG>";
        return XMLPack;
    }
    
    public string SU2XML(List<tb_SupportRequest> SU, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        foreach (tb_SupportRequest a in SU)
        {
            XMLPack += "<SU>";
            XMLPack += "<Support_Code>" + Encryption.Encrypt(a.Support_Code, SharedDataInfo.SecurityKey) + "</Support_Code>";
            if (a.Pre_Support_Code == "") a.Pre_Support_Code = "1111";
            XMLPack += "<Pre_Support_Code>" + a.Pre_Support_Code + "</Pre_Support_Code>";
            XMLPack += "<User_Code>" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "</User_Code>";
            XMLPack += "<User_Name>" + a.User_Name + "</User_Name>";
            Int64 SR_Code = Convert.ToInt64(a.Support_Code);
            DateTime D = new DateTime(SR_Code);
            string Tarikh = DateConversion.DateTimeToPersian(D);
            string Saat = D.Hour.ToString() + ":" + D.Minute.ToString("00");
            XMLPack += "<Tarikh>" + Tarikh + "</Tarikh>";
            XMLPack += "<Saat>" + Saat + "</Saat>";
            if (a.Subject == "") a.Subject = "خالی";
            XMLPack += "<Subject>" + a.Subject.Substring(0,Math.Min(25, a.Subject.Length)) + "</Subject>";
            XMLPack += "<Field>" + tb_SupportRequest.GetFieldName(a.Fields) + "</Field>";
            XMLPack += "<Priority>" + tb_SupportRequest.GetPriorityName(a.Priority) + "</Priority>";
            XMLPack += "<Status>" + tb_SupportRequest.GetSatusNamelbl(a.Status) + "</Status>";

            XMLPack += "</SU>";
        }
        XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
        XMLPack += "</CATALOG>";
        return XMLPack;
    }

    public string Ad_U2XML(List<Admin_UserClass> AUC, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        foreach (Admin_UserClass a in AUC)
        {
            XMLPack += "<AUC>";
            XMLPack += "<RN>" + a.RN + "</RN>";
            XMLPack += "<User_Code>" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "</User_Code>";
            XMLPack += "<Name>" + a.FFName + " " + a.FLName + "</Name>";
            XMLPack += "<HW_Count>" + a.HW_Count + "</HW_Count>";
            XMLPack += "<HW_Sell>" + a.HW_Sell + "</HW_Sell>";
            XMLPack += "<HW_Buy>" + a.HW_Buy + "</HW_Buy>";
            XMLPack += "<HW_AccBal>" + a.AccBal + "</HW_AccBal>";

            XMLPack += "</AUC>";
        }
        XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
        XMLPack += "</CATALOG>";
        return XMLPack;
    }

    public string Ad_P2XML(List<Admin_ProjectClass> APC, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        foreach (Admin_ProjectClass a in APC)
        {
            XMLPack += "<APC>";
            XMLPack += "<RN>" + a.RN + "</RN>";
            XMLPack += "<Paper_Code>" + Encryption.Encrypt(a.Paper_Code, SharedDataInfo.SecurityKey) + "</Paper_Code>";
            if (a.Pre_Paper_Code == "") a.Pre_Paper_Code = "U312uk12";
            XMLPack += "<Pre_Paper_Code>" + a.Pre_Paper_Code + "</Pre_Paper_Code>";
            XMLPack += "<TitleName>" + a.TitleName + "</TitleName>";
            XMLPack += "<Download_C>" + a.Download_C + "</Download_C>";
            XMLPack += "<Price>" + a.Price + "</Price>";
            XMLPack += "<Paper_Rate>" + a.Paper_Rate + "</Paper_Rate>";
            XMLPack += "<Owner_Code>" + Encryption.Encrypt(a.Owner_Code, SharedDataInfo.SecurityKey) + "</Owner_Code>";
            if (a.Owner_Name == "") a.Owner_Name = "نامعلوم";
            XMLPack += "<Owner_Name>" + a.Owner_Name + "</Owner_Name>";

            XMLPack += "</APC>";
        }
        XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
        XMLPack += "</CATALOG>";
        return XMLPack;
    }

    public string Ad_TD2XML(List<Admin_TradeClass> ATDC, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        if (ATDC != null)
        {

            foreach (Admin_TradeClass a in ATDC)
            {
                XMLPack += "<APC>";
                XMLPack += "<Trade_Code>" + a.Trade_Code + "</Trade_Code>";

                DateTime D = new DateTime(Convert.ToInt64(a.Trade_Code));
                string Tarikh = DateConversion.DateTimeToPersian(D);
                string Saat = D.Hour.ToString() + ":" + D.Minute.ToString("00");
                XMLPack += "<Tarikh>" + Tarikh + "</Tarikh>";
                XMLPack += "<Saat>" + Saat + "</Saat>";
                XMLPack += "<Paper_Code>" + Encryption.Encrypt(a.Paper_Code, SharedDataInfo.SecurityKey) + "</Paper_Code>";
                if (a.Pre_Paper_Code == "") a.Pre_Paper_Code = "U312uk12";
                XMLPack += "<Pre_Paper_Code>" + a.Pre_Paper_Code + "</Pre_Paper_Code>";
                XMLPack += "<Seller_Code>" + Encryption.Encrypt(a.Seller_Code,SharedDataInfo.SecurityKey) + "</Seller_Code>";
                XMLPack += "<Seller_Name>" + a.Seller_Name + "</Seller_Name>";
                XMLPack += "<Buyer_Code>" + Encryption.Encrypt(a.Buyer_Code,SharedDataInfo.SecurityKey) + "</Buyer_Code>";
                XMLPack += "<Buyer_Name>" + a.Buyer_Name + "</Buyer_Name>";
                XMLPack += "<Price>" + NumericClass.int2Currency(Convert.ToInt32(a.Price)) + "</Price>";

                XMLPack += "</APC>";
            }
            XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
            XMLPack += "</CATALOG>";
            return XMLPack;
        }
        else
        {
            XMLPack += "</CATALOG>";
            return XMLPack;
        }
    }

    public string Ad_TN2XML(List<Admin_TransactionClass> ATNC, string C, string P)
    {
        string XMLPack = "";
        XMLPack += "<CATALOG>";
        if (ATNC != null)
        {

            foreach (Admin_TransactionClass a in ATNC)
            {
                XMLPack += "<APC>";
                XMLPack += "<Transaction_Code>" + a.Transaction_Code + "</Transaction_Code>";
                XMLPack += "<User_Code>" + Encryption.Encrypt(a.User_Code,SharedDataInfo.SecurityKey) + "</User_Code>";
                
                if (a.User_Code == "0") a.User_Name = "تکلیف بازار"; else if (a.User_Code == "G") a.User_Name = "میهمان";

                XMLPack += "<User_Name>" + a.User_Name + "</User_Name>";
                if (a.Pre_User_Code == "") a.Pre_User_Code = "1234";
                XMLPack += "<Pre_User_Code>" + a.Pre_User_Code + "</Pre_User_Code>";

                DateTime D = new DateTime(Convert.ToInt64(a.Transaction_Code));
                string Tarikh = DateConversion.DateTimeToPersian(D);
                string Saat = D.Hour.ToString() + ":" + D.Minute.ToString("00");
                XMLPack += "<Tarikh>" + Tarikh + "</Tarikh>";
                XMLPack += "<Saat>" + Saat + "</Saat>";
                XMLPack += "<Subject>" + a.Subject + "</Subject>";

                string FromTo = "";
                if (a.InOut == InOut_Type.Out)
                {
                    FromTo = "واریز به حساب ";
                    switch (a.Trans_Type)
                    {
                        case Transaction_Type.Buy:
                            FromTo += "تکلیف بازار";
                            break;
                        case Transaction_Type.Sell:
                            FromTo += "کاربر شماره " + a.BN_Source;
                            break;
                        case Transaction_Type.Settle:
                            FromTo += " شماره " + a.BN_Source;
                            break;
                    }
                }
                else
                {
                    FromTo = "واریز از حساب ";
                    switch (a.Trans_Type)
                    {
                        case Transaction_Type.Buy:
                            if (a.CurAccType == CurrentAccount_Type.Local)
                                FromTo += "کاربر شماره " + a.BN_Source;
                            else
                                FromTo += "کاربر میهمان -" + a.BN_Portal.ToString();
                            break;
                        case Transaction_Type.Sell:
                            FromTo += "تکلیف بازار";
                            break;
                        case Transaction_Type.Add:
                            FromTo += " شماره " + a.BN_Portal.ToString();
                            break;
                    }
                }
                XMLPack += "<FromTo>" + FromTo + "</FromTo>";
                XMLPack += "<Amount>" + NumericClass.int2Currency(Convert.ToInt32(a.Amount)) +"</Amount>";
                
                XMLPack += "</APC>";
            }
            XMLPack += String.Format(@"<Pagination><Count>{0}</Count><Page>{1}</Page></Pagination>", C, P);
            XMLPack += "</CATALOG>";
            return XMLPack;
        }
        else
        {
            XMLPack += "</CATALOG>";
            return XMLPack;
        }
    }

    public string SettlementRequest(Int32 AccBal, int _RP, int _RD)
    {
        int TB_RatePercent = TB_Calc.TB_Rate4SettlementRequest(AccBal, _RP, _RD);
        string TB_SettlDate = TB_Calc.SettlementDate4SettlementRequest(DateTime.Now, _RD);
        string MT = "درخواست تسویه " + _RP + "% از کل موجودی در تاریخ " + TB_SettlDate;

        Int32 MAF = TB_Calc.SettlementAmount4SettlementRequest(AccBal, _RP);
        string MA = NumericClass.int2Currency(MAF);

        string TBT = "کسر " + TB_RatePercent + "% از مبلغ درخواستی";
        string TBA = ((Int32)(TB_RatePercent * MAF / 100.0)).ToString() + "-";

        string TA = ((Int32)(MAF * (100 - TB_RatePercent) / 100.0)).ToString();

        string XMLPack = "";
        XMLPack += "<CATALOG>";

        XMLPack += "<SR>";
        XMLPack += "<MT>" + MT + "</MT>";
        XMLPack += "<MA>" + MA + "</MA>";
        XMLPack += "<TBT>" + TBT + "</TBT>";
        XMLPack += "<TBA>" + TBA + "</TBA>";
        XMLPack += "<TA>" + TA + "</TA>";        
        XMLPack += "</SR>";
        XMLPack += "</CATALOG>";

        return XMLPack;
    }
}

