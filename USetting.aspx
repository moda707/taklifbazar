<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="USetting.aspx.cs" Inherits="USetting"%>
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
            <li class="active"><a href="USetting.aspx">تنظیمات</a></li>
              <li><a href="USupport.aspx">پشتیبانی</a></li>
            <li><a href="#">
                <span  class="badge pull-left">4</span>
                پیام ها</a></li>
            <li><a href="#">خروج</a></li>
          </ul>          
        </div>
        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
          <h1 class="page-header">تنظیمات</h1>
          <div class="row placeholders">
            <div class="col-xs-12 col-sm-6 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">اطلاعات تماس</div>
                    <div class="panel-body" id="FullPanel">
                        <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                  <table class="table">
                      <tr>
                          <td style="width:100px;">
                              <h5><span class="text-right">Email : </span></h5>
                          </td>
                          <td>
                              <h6><span class="text-right"><% = txtEmail %></span></h6>
                          </td>
                          <td>

                          </td>
                      </tr>
                      <tr>
                          <td>
                              <h5><span class="text-left">شماره همراه : </span></h5>
                          </td>
                          <td style="width:180px;">
                              <div class="input-group">
                                  <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                  
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick="javascript: document.getElementById('ContentPlaceHolder1_btnSaveGeneral').disabled=''; document.getElementById('ContentPlaceHolder1_txtMobile').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                          </td>
                          <td>
                              <span id="lblMobileVerification" runat="server">                                  
                              </span>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <h5><span class="text-left">آدرس : </span></h5>
                          </td>
                          <td colspan="2">
                              <div class="input-group">
                                  <input type="text" class="form-control" id="txtaddress" runat="server" disabled="disabled" value="" />
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick=" document.getElementById('ContentPlaceHolder1_btnSaveGeneral').disabled=''; document.getElementById('ContentPlaceHolder1_txtaddress').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                          </td>
                      </tr>                             
                      <tr>
                          <td>
                              <h5><span class="text-left">تلفن : </span></h5>
                          </td>
                          <td colspan="2">
                              <div class="input-group" style="width:200px;">
                                  <input type="text" class="form-control" runat="server" id="txtPhone" disabled="disabled" value="" />
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick=" document.getElementById('ContentPlaceHolder1_btnSaveGeneral').disabled='';document.getElementById('ContentPlaceHolder1_txtPhone').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                          </td>                          
                      </tr>
                      <tr>
                          <td colspan="3" style="text-align:center;">
                              <asp:Button ID="btnSaveGeneral" runat="server" CssClass="btn btn-default" Text="ذخیره" OnClick="btnSaveGeneral_Click" Enabled="false" />                              
                          </td>
                      </tr>
                  </table>                  
                        </div>
              </div>                      
            </div>

            <div class="col-xs-12 col-sm-6 placeholder">
                <div class="panel panel-default">
                    <div class="panel-heading">اطلاعات مالی</div>
                    <table class="table">
                        <tr>
                            <td>
                                <span class="text-right">شماره حساب : </span>
                            </td>
                            <td>
                                <div class="input-group" style="width:200px;">
                                  <input type="text" class="form-control" style="direction:ltr;" runat="server" id="txtAccountNum" disabled="disabled" value="" />
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick="document.getElementById('ContentPlaceHolder1_btnSaveFinance').disabled='';document.getElementById('ContentPlaceHolder1_txtAccountNum').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="text-right">شماره کارت : </span>
                            </td>
                            <td>
                                <div class="input-group" style="width:250px;">
                                  <input type="text" class="form-control" style="direction:ltr;" id="txtCardNum" runat="server" disabled="disabled" value="" />
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick="document.getElementById('ContentPlaceHolder1_btnSaveFinance').disabled='';document.getElementById('ContentPlaceHolder1_txtCardNum').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="text-right">نام بانک : </span>
                            </td>
                            <td>
                                <div class="input-group" style="width:250px;">
                                  <select class="form-control" disabled="disabled" id="slcBankName" runat="server">
                                    <option value="0" selected="selected">بانک ملت</option>
                                    <option value="1">بانک ملی</option>
                                    <option value="2">موسسه توسعه</option>
                                  </select>
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick="document.getElementById('ContentPlaceHolder1_btnSaveFinance').disabled='';document.getElementById('ContentPlaceHolder1_slcBankName').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="text-right">نام صاحب حساب : </span>
                            </td>
                            <td>
                                <div class="input-group" style="width:250px;">
                                  <input type="text" class="form-control" id="txtAccOwner" disabled="disabled" runat="server" value="" />
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick="document.getElementById('ContentPlaceHolder1_btnSaveFinance').disabled='';document.getElementById('ContentPlaceHolder1_txtAccOwner').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="text-right">تسویه حساب : </span>
                            </td>
                            <td>
                                <div class="input-group" style="width:250px;">
                                  <select class="form-control" disabled="disabled" runat="server" id="slcSettlement">
                                    <option value="0" selected="selected">ماهیانه</option>
                                    <option value="1">نیمه ماه (کسر 1%)</option>
                                    <option value="2">هفتگی (کسر 2%)</option>
                                    <option value="3">روزانه (کسر 5%)</option>                                    
                                  </select>
                                  <div class="input-group-btn">
                                      <button class="btn btn-default" type="button" onclick="document.getElementById('ContentPlaceHolder1_btnSaveFinance').disabled='';document.getElementById('ContentPlaceHolder1_slcSettlement').disabled = '';"><i class="glyphicon glyphicon-refresh"></i></button>
                                  </div>
                              </div><br />
                            </td>
                        </tr>
                        <tr>
                          <td colspan="3" style="text-align:center;">
                              <asp:Button ID="btnSaveFinance" runat="server" CssClass="btn btn-default" Text="ذخیره" OnClick="btnSaveFinance_Click" Enabled="false" />                              
                          </td>
                      </tr>                        
                    </table>                    
                </div>                      
            </div>

            <div class="col-xs-12 col-sm-6 placeholder">
                <div class="panel panel-default">
                    <div class="panel-heading">تنظیمات کاربری</div>
                    <table class="table">
                        <tr>
                            <td>
                                <span class="text-right">تغییر رمز ورود : </span>
                            </td>
                            <td>
                                <table class="table">
                                    <tr>
                                        <td>
                                            رمز قبلی : 
                                        </td>
                                        <td>
                                            <input type="password" class="form-control" id="txtprevPass" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            رمز جدید : 
                                        </td>
                                        <td>
                                            <input type="password" class="form-control" id="txtNewPass" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            تکرار رمز : 
                                        </td>
                                        <td>
                                            <input type="password" class="form-control" id="txtNewPassConfirm" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkEmail" runat="server" checked="checked" /> دریافت ایمیل صورت حساب ماهیانه
                                    </label>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <input type="checkbox" id="chkSMS" runat="server" checked="checked" /> دریافت پیامک صورت حساب ماهیانه
                                    </label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                          <td colspan="3" style="text-align:center;">
                              <asp:Button ID="btnSavePass" runat="server" CssClass="btn btn-default" Text="ذخیره" OnClick="btnSavePass_Click"/>                              
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