<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="UAccount.aspx.cs" Inherits="UAccount"%>
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
              <li><a href="UBuy.aspx">خریدها</a></li>
            <li class="active"><a href="UAccount.aspx">مالی</a></li>            
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
          <h1 class="page-header">مالی</h1>
          <div class="row placeholders">
            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                    <div class="panel-heading">گردش مالی</div>
                    <div class="panel-body" id="FullPanel">
                        <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                        <table style="width:100%;">
                            <tr>
                                <td style="width:100px;">
                                    <h5>مانده حساب : </h5>
                                </td>
                                <td style="width:200px;">
                                    <h5><span id="txtAccBal" runat="server"></span> ریال</h5>
                                </td>
                                <td>

                                </td>
                                <td style="width:20px;">
                                    <button class="btn btn-default" type="button" title="Print" onclick="javascript:PrintContent('TblCnt');"><span class="glyphicon glyphicon-print"></span></button>
                                    
                                </td>
                            </tr>
                        </table>
                        <div id="TblCnt" runat="server">

                        </div>                            
                        <table class="table">
                            <tr>
                                <td style="text-align:right;">
                                    <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:UA_Search('1');" runat="server">
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
            
              <div class="col-xs-12 col-sm-12 placeholder">
                  <div class="panel panel-default">
                      <div class="panel-heading">
                          <button class="btn btn-default" type="button" onclick="javascript:document.getElementById('RequestSettlement').style.display=''">
                              <span class="glyphicon glyphicon-plus"></span>
                          </button> درخواست تسویه حساب اضطراری 
                      </div>
                      <div class="panel-body"">
                         
                      <table class="table" style="display:none;" id="RequestSettlement">
                          <tr>
                              <td style="width:110px;">
                                  <h5>موارد پیشنهادی:</h5>
                              </td>
                              <td>
                                  <h6>مبلغ مورد درخواست : </h6>
                                  <select class="form-control" style="width:100px;" id="slcPercent" runat="server" onchange="javascript:SettlementRequest();">
                                      <option value="25">25%</option>
                                      <option value="50">50%</option>
                                      <option value="75">75%</option>
                                      <option value="100">100%</option>                                      
                                  </select>
                                  <h6>زمان مورد درخواست : </h6>
                                  <select class="form-control" style="width:130px; font-size:9pt;" id="slcSettlDate" runat="server" onchange="javascript:SettlementRequest();">
                                      <option value="1">یک روز کاری</option>
                                      <option value="2">دو روز کاری</option>
                                      <option value="3">سه روز کاری</option>
                                  </select>
                              </td>
                              <td>
                                  <table class="table table-striped">
                                      <thead>
                                          <tr>
                                              <th style="width:75%;">
                                                  عنوان
                                              </th>
                                              <th style="width:25%;">
                                                  مبلغ
                                              </th>
                                          </tr>                                          
                                      </thead>
                                      <tbody>
                                          <tr>
                                              <td>
                                                  <span id="txtMainTitle" runat="server"></span>
                                              </td>
                                              <td>
                                                  <span id="txtMainAmount" runat="server"></span>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <span id="txtTB_RateTitle" runat="server"></span>
                                              </td>
                                              <td>
                                                  <span id="txtTB_RateAmount" runat="server"></span>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  دریافتی
                                              </td>
                                              <td>
                                                  <span id="txtTotalAmount" runat="server"></span>
                                              </td>
                                          </tr>
                                      </tbody>
                                  </table>
                              </td>
                          </tr>
                          <tr>
                              <td colspan="3" style="text-align:center;">
                                  <asp:Button runat="server" ID="btnSaveRequest" CssClass="btn btn-default" Text="ثبت درخواست" OnClick="btnSaveRequest_Click" />                                  
                              </td>
                          </tr>
                      </table>
                    </div>
                  </div>                  
              </div>

              <div class="col-xs-12 col-sm-12 placeholder">
                  <div class="panel panel-default">
                      <div class="panel-heading">
                          لیست درخواست های تسویه حساب
                      </div>
                      <div class="panel-body" id="FullPanel1">
                          <div class="WaitingForm" id="WFF1" style="display:none;" tabindex="-1"></div>
                        <div id="TblCnt2" runat="server">

                        </div>                            
                        <table class="table">
                            <tr>
                                <td style="text-align:right;">
                                    <select class="form-control" style="width:75px;" id="SearchShowCount2" onchange="javascript:UASR_Search('1');" runat="server">
                                        <option value="5">5</option>
                                        <option value="10">10</option>
                                        <option value="15">15</option>
                                        <option value="30">30</option>                                    
                                        <option value="All">همه</option>
                                    </select>
                                </td>
                                <td style="text-align:left;">
                                    <div id="PaginationPanel2" runat="server"></div>                                        
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