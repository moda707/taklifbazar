<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="USupport.aspx.cs" Inherits="USupport"%>
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
            <li><a href="UAccount.aspx">مالی</a></li>            
          </ul>
          <ul class="nav nav-sidebar">
            <li><a href="USetting.aspx">تنظیمات</a></li>
            <li class="active"><a href="USupport.aspx">پشتیبانی</a></li>
            <li><a href="#">
                <span  class="badge pull-left">4</span>
                پیام ها</a></li>
            <li><a href="#">خروج</a></li>
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
                        <div id="TblCnt" runat="server">

                        </div>                            
                        <table class="table">
                            <tr>
                                <td style="text-align:right;">
                                    <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:US_Search('1');" runat="server">
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
                      <button class="btn btn-default" type="button" onclick="javascript:document.getElementById('AddNewPanel').style.display=''">
                          <span class="glyphicon glyphicon-plus"></span>
                      </button> ثبت درخواست جدید 
                  </div>
                  <table class="table" style="display:none;" id="AddNewPanel">
                      <tr>
                          <td>
                              <table class="table">
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">عنوان</span></h5>
                                      </td>
                                      <td>
                                          <input type="text" class="form-control" id="txtFTitle" runat="server" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">دسته</span></h5>
                                      </td>
                                      <td>
                                          <select id="slcField" runat="server" class="form-control" style="width:100px; font-size:9pt;">
                                                <option value="0">خرید</option>
                                                <option value="1">فروش</option>                                                
                                                <option value="2">تسویه</option> 
                                            </select> 
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">فوریت</span></h5>
                                      </td>
                                      <td>
                                          <select id="slcPriority" runat="server" class="form-control" style="width:100px; font-size:9pt;">
                                                <option value="0">خیلی فوری</option>
                                                <option value="1">فوری</option>
                                              <option value="2">معمولی</option>
                                            </select> 
                                      </td>
                                  </tr>                                  
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">شرح</span></h5>
                                      </td>
                                      <td>
                                          <textarea runat="server" style="width:100%; min-height:100px;" id="txtdescription" dir="rtl"></textarea>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                        <td colspan="2" style="text-align:center;">
                            <asp:Button ID="btnSubmitReq" runat="server" CssClass="btn btn-default" Text="ثبت درخواست" OnClick="btnSubmitReq_Click" />                            
                        </td>
                      </tr>
                  </table>
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
    </div>
</asp:Content>