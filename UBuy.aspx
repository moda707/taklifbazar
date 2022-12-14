<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="UBuy.aspx.cs" Inherits="UBuy"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/dashboard.css" rel="stylesheet"/>
    <script src="js/jquery.min.js"></script>    
    <script src="js/bootstrap.min.js"></script>
    <script src="js/docs.min.js"></script>
    <script src="js/MJScript.js"></script>
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
          <ul class="nav nav-sidebar">
            <li><a href="UserPortal.aspx">داشبورد</a></li>
            <li><a href="UProjects.aspx">تکلیف ها</a></li>
            <li class="active"><a href="UBuy.aspx">خریدها</a></li>
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
          <h1 class="page-header">خریدها</h1>
          <div class="row placeholders">
            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                    <div class="panel-heading">لیست خریداری شده ها</div>
                    <div class="panel-body" id="FullPanel">
                        <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                        <table style="width:100%;">
                            <tr>
                                <td style="width:150px;">
                                    <h5>جمع مبلغ خرید شما : </h5>
                                </td>
                                <td style="width:80px;">
                                    <h5><%=txtTotalBuy %> ریال</h5>
                                </td>
                                <td>

                                </td>
                                <td style="width:20px;">
                                    <button class="btn btn-default" type="button" title="Print" onclick="javascript:PrintContent('TblCnt');"><span class="glyphicon glyphicon-print"></span></button>
                                    
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div id="TblCnt" runat="server">

                    </div>
                    <table class="table">
                        <tr>
                            <td style="text-align:right;">
                                <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:UB_Search('1');" runat="server">
                                    <option value="5">5</option>
                                    <option value="10">10</option>
                                    <option value="15">15</option>
                                    <option value="30">30</option>                                    
                                    <option value="All">همه</option>
                                </select>
                            </td>
                            <td style="text-align:left;">
                                <div id="PaginationPanel" runat="server"></div>                                        
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