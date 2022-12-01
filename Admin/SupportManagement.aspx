<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Class.master" AutoEventWireup="true" CodeFile="SupportManagement.aspx.cs" Inherits="Admin_SupportManagement" %>

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
                    <li><a href="TransactionManagement.aspx">تراکنش ها</a></li>
                    <li class="active"><a href="SupportManagement.aspx">پشتیبانی</a></li>
                    <li><a href="#">
                        <span  class="badge pull-left">4</span>
                        پیام ها</a></li>
                </ul>
            </div>  
                           
            <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                <h1 class="page-header">پشتیبانی</h1>
                <div class="row placeholders">
                    <div class="col-xs-12 col-sm-12 placeholder">
                        <div class="panel panel-default">
                            <div class="panel-heading">لیست درخواست ها</div>
                            <div class="panel-body" id="FullPanel">
                                <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                                <table class="table">
                                    <tr>
                                        <td>
                                            <ul class="nav nav-tabs">
                                                <li id="OptAdSU_0" class="active"><a href="#" onclick="javascript:Ad_SU_SetType('0');">همه</a></li>
                                                <li id="OptAdSU_1"><a href="#" onclick="javascript:Ad_SU_SetType('1');">در انتظار پاسخ</a></li>
                                                <li id="OptAdSU_2"><a href="#" onclick="javascript:Ad_SU_SetType('2');">خیلی فوری</a></li>
                                                <li id="OptAdSU_3"><a href="#" onclick="javascript:Ad_SU_SetType('3');">فوری</a></li>
                                                <li id="OptAdSU_4"><a href="#" onclick="javascript:Ad_SU_SetType('4');">معمولی</a></li>
                                            </ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="display:none;" id="RType">0</span>
                                            <div id="TblCnt" runat="server">

                                            </div>                            
                                            <table class="table">
                                            <tr>
                                                <td style="text-align:right;">
                                                    <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:Ad_SU_Search('1');" runat="server">
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
                <div class="modal fade" style="text-align:center;" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog" style="text-align:center;">
                    <div class="modal-content" style="width:100%;text-align:center;">
                        <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">درخواست پشتیبانی</h4>
                        </div>
                        <div class="modal-body">
                            <iframe style="width:100%; border:none;" seamless="seamless" id="DetFrame" onload="javascript:this.style.height = this.contentWindow.document.body.scrollHeight + 5 + 'px';">

                            </iframe>
                        </div>                    
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>

</asp:Content>

