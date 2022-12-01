<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="DownloadHW.aspx.cs" Inherits="DownloadHW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/Scrollbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
<div align="center">
    <div class="ViewWin_Norm" style="width:40%;">
        <% if (!String.IsNullOrEmpty(Request.QueryString[0]))
            {
               string QS = Request.QueryString[0].ToString();
               QS = QS.Replace(' ', '+');
               string strURL = Encryption.Decrypt(QS, SharedDataInfo.SecurityKey);
               string[] arrURL = strURL.Split('!');
               Int64 strDT = Convert.ToInt64(arrURL[1]);
               DateTime DT = new DateTime(strDT);
               DateTime DTE = DT.AddDays(ExpireDateDay);
               DateTime NowDT = DateTime.Now;
               if (DTE.Ticks > NowDT.Ticks)
               {
               
               %>        
        <table class="table">
            <thead>
                <tr>
                    <th style="width:15%; text-align:center;">
                        #
                    </th>
                    <th style="width:30%; text-align:center;">
                        عنوان
                    </th>
                    <th style="width:30%; text-align:center;">
                        سایز
                    </th>
                    <th style="width:25%; text-align:center;">
                        دانلود
                    </th>
                </tr>
            </thead>
            <tbody>
                <% = txtFiles %>
            </tbody>
        </table>
        <%}
          else{%>
                <div class="alert alert-info">                
                <h5>لینک تکلیف مورد نظر منقضی شده است و شما دیگر نمی توانید از طریق این لینک به آن دسترسی داشته باشید. لطفا وارد محیط کاربری خود شده و از قسمت خریدها آنرا دریافت فرمایید.</h5>                
            </div><br /> 
               <%}
          }else{ %>
            <div class="alert alert-info">                
                <h5>لینک مورد نظر معتبر نیست!</h5>                
            </div><br />
            <%} %>
    </div>
</div>
</asp:Content>

