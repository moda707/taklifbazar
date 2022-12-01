using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UAccount : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        #region Account
        List<tb_Transactions> LTRN = tb_Transactions.LoadByUser(User_Code);

        int t = 5;
        int PageNumb = 1;
        int PageCount = LTRN.Count / t + 1;
        if ((LTRN.Count / t) * t == LTRN.Count) PageCount--;

        int tCount = LTRN.Count;
        LTRN = LTRN.Take(t).ToList();

        tb_FinancialAcc FA_U = new tb_FinancialAcc(User_Code);
        txtAccBal.InnerHtml = NumericClass.int2Currency(Convert.ToInt32(FA_U.Amount));

        string C = "";
        if (LTRN.Count > 0)
        {
            C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th style=\"width:80px;\">تاریخ</th><th style=\"width:80px;\">زمان</th><th>شرح</th><th style=\"width:100px;\">مبلغ گردش</th><th style=\"width:100px;\">مانده</th></tr></thead><tbody>";
            foreach (tb_Transactions a in LTRN)
            {
                Int64 TR_Code = Convert.ToInt64(a.Transaction_Code);
                DateTime D = new DateTime(TR_Code);

                string Tarikh = DateConversion.DateTimeToPersian(D);
                string Saat = D.Hour.ToString() + ":" + D.Minute;

                string Am;
                if (a.InOut == InOut_Type.In)
                {
                    Am = "<span class=\"text-success\">" + NumericClass.int2Currency(Convert.ToInt32(a.Amount)) + "+</span>";
                }
                else
                {
                    Am = "<span class=\"text-danger\">" + NumericClass.int2Currency(Convert.ToInt32(a.Amount)) + "-</span>";
                }

                C += "<tr><td><h6>" + a.RN + "</h6></td><td><h6>" + Tarikh + "</h6></td><td><h6>" + Saat + "</h6></td><td><h6>" + a.Trans_Subject + "</h6></td><td><h6>" + Am + "</h6></td><td><h6>" + NumericClass.int2Currency(Convert.ToInt32(a.AccBalance)) + "</h6></td></tr>";
            }
            C += "</tbody></table>";
        }
        else
        {
            C = "موردی یافت نشد.";
        }
        TblCnt.InnerHtml = C;

        string PG = "<ul class=\"pagination\">";


        PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";

        for (var i = 1; i <= PageCount; i++)
        {
            if (i == 1)
            {
                PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:UA_Search('" + i + "');\">" + i + "</a></li>";
            }
        }

        if (PageCount == 1)
        {
            PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
        }
        else
        {
            PG += "<li><a href=\"javascript:UA_Search('2');\">«</a></li>";
        }


        PaginationPanel.InnerHtml = PG;
        #endregion

        #region Settlement_Request
        Int32 AccBal = Convert.ToInt32(txtAccBal.InnerHtml.Replace(",", ""));
        int RP = Convert.ToInt32(slcPercent.Items[slcPercent.SelectedIndex].Value);
        int RD = Convert.ToInt32(slcSettlDate.Items[slcSettlDate.SelectedIndex].Value);

        int TB_RatePercent = TB_Calc.TB_Rate4SettlementRequest(AccBal, RP, RD);
        string TB_SettlDate = TB_Calc.SettlementDate4SettlementRequest(DateTime.Now, RD);
        txtMainTitle.InnerHtml = "درخواست تسویه " + RP + "% از کل موجودی در تاریخ " + TB_SettlDate;

        Int32 MAF = TB_Calc.SettlementAmount4SettlementRequest(AccBal, RP);
        txtMainAmount.InnerHtml = NumericClass.int2Currency(MAF);

        txtTB_RateTitle.InnerHtml = "کسر " + TB_RatePercent + "% از مبلغ درخواستی";
        txtTB_RateAmount.InnerHtml = ((Int32)(TB_RatePercent * MAF / 100.0)).ToString() + "-";
        txtTotalAmount.InnerHtml = ((Int32)(MAF * (100 - TB_RatePercent) / 100.0)).ToString();


        //Load List
        List<tb_SettlementRequest> LSR = tb_SettlementRequest.LoadByUser(User_Code, Settlement_List_Tpe.All);

        PageNumb = 1;
        PageCount = LSR.Count / t + 1;
        if ((LSR.Count / t) * t == LSR.Count) PageCount--;

        tCount = LSR.Count;
        LSR = LSR.Take(t).ToList();


        C = "";
        if (LSR.Count > 0)
        {
            C = "<table class=\"table table-striped\"><thead><tr><th style=\"width:30px;\">#</th><th style=\"width:80px;\">تاریخ</th><th style=\"width:80px;\">زمان</th><th>شرح</th><th style=\"width:110px;\">وضعیت</th><th style=\"width:30px;\"></th></tr></thead><tbody>";
            foreach (tb_SettlementRequest a in LSR)
            {
                DateTime D = new DateTime(Convert.ToInt64(a.Req_Code));

                C += "<tr><td>" + a.Pre_Req_Code + "</td><td>" + DateConversion.DateTimeToPersian(D) + "</td><td>" + D.Hour + ":" + D.Minute + "</td><td>" + a.Subject + "</td><td><span" + tb_SettlementRequest.GetSRStatusNamelbl(a.Status) + "</span></td>";
                if (a.Status == SettlementReq_Status.Submitted)
                {
                    C += "<td><button type=\"button\" class=\"btn btn-link\" onclick=\"javascript:CancleSRShow('" + Encryption.Encrypt(a.Req_Code, SharedDataInfo.SecurityKey) + "')\">لغو</button></td></tr>";
                }else
                    C += "<td></td></tr>";
            }
            C += "</tbody></table>";
        }//
        else
        {
            C = "موردی یافت نشد.";
        }
        TblCnt2.InnerHtml = C;

        PG = "<ul class=\"pagination\">";


        PG += "<li class=\"disabled\"><a href=\"#\">»</a></li>";

        for (var i = 1; i <= PageCount; i++)
        {
            if (i == 1)
            {
                PG += "<li class=\"active\"><a href=\"#\">" + i + " <span class=\"sr-only\">(current)</span></a></li>";
            }
            else
            {
                PG += "<li><a href=\"javascript:UASR_Search('" + i + "');\">" + i + "</a></li>";
            }
        }

        if (PageCount == 1)
        {
            PG += "<li class=\"disabled\"><a href=\"#\">«</a></li>";
        }
        else
        {
            PG += "<li><a href=\"javascript:UASR_Search('2');\">«</a></li>";
        }


        PaginationPanel2.InnerHtml = PG;

        #endregion
    }

    protected void btnSaveRequest_Click(object sender, EventArgs e)
    {
        LoginClass LC = (LoginClass)Session["LC"];
        string User_Code = LC.User_Code;

        Int32 AccBal = Convert.ToInt32(txtAccBal.InnerHtml.Replace(",",""));
        int RP = Convert.ToInt32(slcPercent.Items[slcPercent.SelectedIndex].Value);
        int RD = Convert.ToInt32(slcSettlDate.Items[slcSettlDate.SelectedIndex].Value);
        tb_SettlementRequest SR = new tb_SettlementRequest();
        List<tb_SettlementRequest> SL = tb_SettlementRequest.LoadByUser(User_Code, Settlement_List_Tpe.All).OrderByDescending(x => x.Req_Code).ToList();
        DateTime ND;

        if (SL.Count == 0)
        {
            SR.User_Code = User_Code;
            SR.TB_Rate = TB_Calc.TB_Rate4SettlementRequest(AccBal, RP, RD);
            SR.Amount_Percent = RP.ToString();

            SR.Amount = ((int)((AccBal * RP / 100.0) * ((100.0 - SR.TB_Rate) / 100.0))).ToString();
            SR.AccBal = AccBal;

            ND = DateTime.Now.AddDays(RD);
            SR.Settle_Date = ND.Ticks.ToString();
            SR.Subject = "درخواست " + SR.Amount_Percent + "% از کل موجودی به ارزش " + NumericClass.int2Currency(Convert.ToInt32(SR.Amount)) + " ریال برای تاریخ " + TB_Calc.SettlementDate4SettlementRequest(DateTime.Now, RD); ;
            SR.Status = SettlementReq_Status.Submitted;
            SR.Pre_Req_Code = Encryption.GetUniqueKeyNum(6);

            SR.Req_Code = SR.SR_Add();
        }
        else
        {
            tb_SettlementRequest S1 = SL[0];
            
            switch (S1.Status)
            {
                case SettlementReq_Status.Canceled:
                    SR.User_Code = User_Code;

                    SR.TB_Rate = TB_Calc.TB_Rate4SettlementRequest(AccBal, RP, RD);

                    SR.Amount_Percent = RP.ToString();

                    SR.Amount = ((int)((AccBal * RP / 100.0) * ((100.0 - SR.TB_Rate) / 100.0))).ToString();
                    SR.AccBal = AccBal;

                    ND = DateTime.Now.AddDays(RD);
                    SR.Settle_Date = ND.Ticks.ToString();
                    SR.Subject = "درخواست " + SR.Amount_Percent + "% از کل موجودی به ارزش " + NumericClass.int2Currency(Convert.ToInt32(SR.Amount)) + " ریال برای تاریخ " + TB_Calc.SettlementDate4SettlementRequest(DateTime.Now, RD); ;
                    SR.Status = SettlementReq_Status.Submitted;
                    SR.Pre_Req_Code = Encryption.GetUniqueKeyNum(6);

                    SR.Req_Code = SR.SR_Add();
                    break;
                case SettlementReq_Status.Inprogress:
                    lblErrors.InnerHtml = "امکان ثبت درخواست جدید وجود ندارد. منتظر انجام فرایند درخواست قبلی باشید.";
                    ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('lblErrorsDiv').style.display = 'block';$('#lblErrorsDiv').fadeOut(10000);", true);
                    break;
                case SettlementReq_Status.Paied:
                case SettlementReq_Status.Rejected:
                    if (DateConversion.CompareDate(DateTime.Now, new DateTime(Convert.ToInt64(S1.Req_Code)), 0))
                    {
                        lblErrors.InnerHtml = "برای هر روز تنها یک درخواست می توان ثبت کرد.";
                        ClientScript.RegisterStartupScript(this.GetType(), "", "document.getElementById('lblErrorsDiv').style.display = 'block';$('#lblErrorsDiv').fadeOut(10000);", true);
                    }
                    else
                    {
                        SR.User_Code = User_Code;

                        SR.TB_Rate = TB_Calc.TB_Rate4SettlementRequest(AccBal, RP, RD);

                        SR.Amount_Percent = RP.ToString();

                        SR.Amount = ((int)((AccBal * RP / 100.0) * ((100.0 - SR.TB_Rate) / 100.0))).ToString();
                        SR.AccBal = AccBal;

                        ND = DateTime.Now.AddDays(RD);
                        SR.Settle_Date = ND.Ticks.ToString();
                        SR.Subject = "درخواست " + SR.Amount_Percent + "% از کل موجودی به ارزش " + NumericClass.int2Currency(Convert.ToInt32(SR.Amount)) + " ریال برای تاریخ " + TB_Calc.SettlementDate4SettlementRequest(DateTime.Now, RD); ;
                        SR.Status = SettlementReq_Status.Submitted;
                        SR.Pre_Req_Code = Encryption.GetUniqueKeyNum(6);

                        SR.Req_Code = SR.SR_Add();
                    }
                    break;
                case SettlementReq_Status.Submitted:
                    S1.Status = SettlementReq_Status.Canceled;
                    S1.SR_Update();
                    SR.User_Code = User_Code;

                    SR.TB_Rate = TB_Calc.TB_Rate4SettlementRequest(AccBal, RP, RD);

                    SR.Amount_Percent = RP.ToString();

                    SR.Amount = ((int)((AccBal * RP / 100.0) * ((100.0 - SR.TB_Rate) / 100.0))).ToString();
                    SR.AccBal = AccBal;

                    ND = DateTime.Now.AddDays(RD);
                    SR.Settle_Date = ND.Ticks.ToString();
                    SR.Subject = "درخواست " + SR.Amount_Percent + "% از کل موجودی به ارزش " + NumericClass.int2Currency(Convert.ToInt32(SR.Amount)) + " ریال برای تاریخ " + TB_Calc.SettlementDate4SettlementRequest(DateTime.Now, RD); ;
                    SR.Status = SettlementReq_Status.Submitted;
                    SR.Pre_Req_Code = Encryption.GetUniqueKeyNum(6);

                    SR.Req_Code = SR.SR_Add();
                    break;
            }

        }
        
    }

    
}