<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="UserView.aspx.cs" Inherits="UserView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/dashboard.css" rel="stylesheet"/>
    <script src="js/jquery.min.js"></script>    
    <script src="js/bootstrap.min.js"></script>
    <script src="js/docs.min.js"></script>
    <script src="js/MJScript.js"></script>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/Scrollbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <div class="row placeholders">
        <% if((LoginClass)Session["LC"]!=null && ((LoginClass)Session["LC"]).U_Type == User_Type.Admin){ %>
        <div class="col-xs-12 col-sm-12 placeholder" align="center">
            <asp:Button ID="btnSuspend" runat="server" CssClass="btn btn-danger" Text="تعلیق" />
            <asp:Button ID="btnActivate" runat="server" CssClass="btn btn-info" Text="رفع تعلیق" />
            <button class="btn btn-warning" onclick="">ارسال پیام</button>
        </div>
        <%} %>
        <div class="col-xs-12 col-sm-6 placeholder">
            <div class="panel panel-default">
                <div class="panel-heading">مشخصات</div>                    
                <table class="table">
                    <tr>
                        <td style="width:70%;">
                            <table class="table">
                                <tr>
                                    <td>
                                        <h4><span id="txtName" runat="server"></span></h4>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="text-right">شماره تماس: </span><span id="txtMobile" runat="server"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="text-left">Email: </span><span id="txtEmail" runat="server"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    <span class="text-right">تعداد کل پروژه ها: <% = txtProjCount %></span>
                                                </td>
                                                <td>
                                                    <span class="text-right">موجودی حساب : <% = txtAccBal %> ریال</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span class="text-right">جمع مبلغ فروش : <% = txtTotalSellPrice %> ریال</span>
                                                </td>
                                                <td>
                                                    <span class="text-right">جمع تعداد فروش : <% = txtTotalSellCount %></span>
                                                </td>
                                            </tr>                        
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>                              
                            <div class="panel panel-default">
                                <img class="img-thumbnail" alt="تصویر" src="<% = txtProfilePic %>" />
                                <div class="panel-footer" style="text-align:left; direction:ltr;">
                                    <div style="background-image:url('images/star-gold2.png'); text-align:left; background-repeat:repeat-x; width:50px; height:19px;"></div>
                                </div>
                            </div>
                              
                        </td>
                    </tr>                      
                </table>                  
                    </div>
            </div>                      
            
        <div class="col-xs-12 col-sm-6 placeholder">
            <div class="panel panel-default">
                <div class="panel-heading">تکلیف ها</div>
                <div class="panel-body">
                    <div class="scrollbar" id="TblCnt" runat="server" style="max-height:500px;">

                    </div>
                </div>
            </div>                      
        </div>        
    </div>
</asp:Content>

