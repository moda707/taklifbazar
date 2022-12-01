<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="UserPortal.aspx.cs" Inherits="UserPortal"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/dashboard.css" rel="stylesheet"/>
    <script src="js/jquery.min.js"></script>    
    <script src="js/bootstrap.min.js"></script>
    <script src="js/docs.min.js"></script>
    <script src="js/MJScript.js"></script>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
          <ul class="nav nav-sidebar">
            <li class="active"><a href="UserPortal.aspx">داشبورد</a></li>
            <li><a href="UProjects.aspx">تکلیف ها</a></li>
            <li><a href="UBuy.aspx">خریدها</a></li>
            <li><a href="UAccount.aspx">مالی</a></li>            
          </ul>
          <ul class="nav nav-sidebar">
            <li><a href="USetting.aspx">تنظیمات</a></li>
            <li><a href="USupport.aspx">پشتیبانی</a></li>
            <li><a href="#">
                <span  class="badge pull-left">4</span>
                پیام ها</a></li>
            <li><a href="#">خروج</a></li>
          </ul>          
        </div>

        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h1 class="page-header">داشبورد</h1>
          <div class="row placeholders">
            <div class="col-xs-12 col-sm-6 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">مشخصات</div>                    
                  <table class="table">
                      <tr>
                          <td style="width:400px;">
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
                    <div class="panel-heading">اطلاعات آماری</div>
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
                </div>                      
            </div>
          </div>
        </div>
        </div>
      </div>    
</asp:Content>