<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Class.master" AutoEventWireup="true" CodeFile="TransactionManagement.aspx.cs" Inherits="Admin_TransactionManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/dashboard.css" rel="stylesheet"/>
    <script src="../js/jquery.min.js"></script>    
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/docs.min.js"></script>
    <script src="../js/MJScript.js"></script>
    <link href="../css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-3 col-md-2 sidebar">
                <ul class="nav nav-sidebar">
                    <li><a href="UserManagement.aspx">کاربران</a></li>
                    <li><a href="ProjectManagement.aspx">تکلیف ها</a></li>
                    <li><a href="SettlementManagement.aspx">تسویه حساب</a></li>
                    <li><a href="TradeManagement.aspx">معاملات</a></li>
                    <li class="active"><a href="TransactionManagement.aspx">تراکنش ها</a></li>
                    <li><a href="SupportManagement.aspx">پشتیبانی</a></li>
                    <li><a href="#">
                        <span  class="badge pull-left">4</span>
                        پیام ها</a></li>
                </ul>
            </div>                 
            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                <h1 class="page-header">تراکنش ها</h1>
                <div class="row placeholders">
                    <div class="col-xs-12 col-sm-12 placeholder">
                        <div class="panel panel-default">
                            <div class="panel-heading">لیست معامله ها</div>
                            <div class="panel-body" id="FullPanel">
                                <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                                <span id="RType" style="display:none;">0</span>
                                <div class="input-group" style="width:200px;" >
                                    <input type="text" class="form-control" id="UCode"/>
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default" onclick="javascript:Ad_TN_Search('1');"><span class="glyphicon glyphicon-search"></span></button>
                                    </div>
                                </div>
                                <table class="table">
                                    <tr>
                                        <td>
                                            <ul class="nav nav-tabs">
                                                <li id="OptAdSU_0" class="active"><a href="#" onclick="javascript:Ad_TN_SetType('0');">همه</a></li>
                                                <li id="OptAdSU_1"><a href="#" onclick="javascript:Ad_TN_SetType('1');">به تکلیف بازار</a></li>
                                                <li id="OptAdSU_2"><a href="#" onclick="javascript:Ad_TN_SetType('2');">از تکلیف بازار</a></li>                                                
                                            </ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="TblCnt" runat="server">

                                            </div>                            
                                            <table class="table">
                                            <tr>
                                                <td style="text-align:right;">
                                                    <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:Ad_TN_Search('1');" runat="server">
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
                                        </td>                          
                                    </tr>                      
                                </table>  
                            </div>                                
                        </div>                      
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

