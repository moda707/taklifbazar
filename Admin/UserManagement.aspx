<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Class.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="Admin_UserManagement" %>

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
                         <li class="active"><a href="UserManagement.aspx">کاربران</a></li>
                         <li><a href="ProjectManagement.aspx">تکلیف ها</a></li>
                         <li><a href="SettlementManagement.aspx">تسویه حساب</a></li>
                         <li><a href="TradeManagement.aspx">معاملات</a></li>
                         <li><a href="TransactionManagement.aspx">تراکنش ها</a></li>
                         <li><a href="SupportManagement.aspx">پشتیبانی</a></li>
                         <li><a href="#">
                             <span  class="badge pull-left">4</span>
                             پیام ها</a></li>
                    </ul>                     
                 </div>
                 
                 <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
                    <h1 class="page-header">کاربرها</h1>
                    <div class="row placeholders">
                        <div class="col-xs-12 col-sm-12 placeholder">
                            <div class="panel panel-default">
                                <div class="panel-heading">لیست کاربران</div>
                                <div class="panel-body" id="FullPanel">
                                    <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <div class="btn-toolbar" role="toolbar">
                                                    <div class="input-group" style="width:300px;">
			                                            <input type="text" class="form-control" id="txtfilterterm" onkeyup="searchKeyPress(event);"/>
			                                            <div class="input-group-btn">
				                                            <input class="btn btn-default" type="button" id="btnAddSearchTag" onclick="javascript: SearchTagAdd();" value="+" />                                    
			                                            </div>
		                                            </div><span style="display:none;" id="OB">0</span><span style="display:none;" id="OT">0</span>
                                                    <div class="btn-group" data-toggle="buttons">
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options" id="option1" value="0" onchange="javascript:Ad_P_SetOrders(this.value, -1); Ad_U_Search(1);"/> تاریخ
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options" id="option2" value="1" onchange="javascript:Ad_P_SetOrders(this.value, -1); Ad_U_Search(1);"/> نام
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options" id="Radio3" value="2" onchange="javascript: Ad_P_SetOrders(this.value, -1); Ad_U_Search(1);"/> تعداد تکلیف
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options" id="Radio4" value="3" onchange="javascript: Ad_P_SetOrders(this.value, -1); Ad_U_Search(1);"/> فروش
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options" id="Radio5" value="4" onchange="javascript: Ad_P_SetOrders(this.value, -1); Ad_U_Search(1);"/> خرید
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options" id="Radio6" value="5" onchange="javascript: Ad_P_SetOrders(this.value, -1); Ad_U_Search(1);"/> موجودی
                                                        </label>
                                                    </div>
                                                    <div class="btn-group" data-toggle="buttons">
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options1" id="Radio1" value="0" onchange="javascript: Ad_P_SetOrders(-1, this.value); Ad_U_Search(1);" /><span class="glyphicon glyphicon-sort-by-attributes-alt"></span>
                                                        </label>
                                                        <label class="btn btn-default">
                                                            <input type="radio" name="options1" id="Radio2" value="1" onchange="javascript: Ad_P_SetOrders(-1, this.value); Ad_U_Search(1);"/><span class="glyphicon glyphicon-sort-by-attributes"></span>
                                                        </label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="container-fluid">
                                                    <span id="AllTags" style="display:none;"></span>
                                                    <div class="row" id="SelectedTags" style="margin:15px;">
                                                                                                                                
                                                    </div>                                            
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                                
                                                <div id="TblCnt" runat="server">

                                                </div>                            
                                                <table class="table">
                                                <tr>
                                                    <td style="text-align:right;">
                                                        <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:Ad_U_Search('1');" runat="server">
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

