<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="UProjects.aspx.cs" Inherits="UProjects"  MaintainScrollPositionOnPostback="true"%>

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
            <li><a href="UserPortal.aspx">داشبورد</a></li>
            <li class="active"><a href="UProjects.aspx">تکلیف ها</a></li>
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
          <h1 class="page-header">تکلیف ها</h1>
          <div class="row placeholders">
            <div class="col-xs-12 col-sm-12 placeholder">
                <div class="panel panel-default">
                  <div class="panel-heading">لیست تکالیف</div>
                <div class="panel-body">
                    <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
                  <table class="table">                      
                      <tr>
                          <td>
                              <div id="TblCnt" runat="server">

                                </div>                            
                              <table class="table">
                                <tr>
                                    <td style="text-align:right;">
                                        <select class="form-control" style="width:75px;" id="SearchShowCount" onchange="javascript:UP_Search('1');" runat="server">
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
                                   
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content" style="width:100%;text-align:center;">
                        <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="H1">هشدار</h4>
                        </div>
                        <div class="modal-body" style="text-align:justify;">
                            <span id="code" style="display:none;"></span>
                            <h5><span id="ModalMessage"></span></h5>                            
                        </div>                    
                        <div class="modal-footer" style="text-align:center;">
                            <a href="#" class="btn btn-primary" id="btnRYes" onclick="javascript:RemoveHW();" style="width:120px;">بلی</a>
                            <button data-dismiss="modal" class="btn btn-primary" id="btnRNo" style="width:120px;">خیر</button>
                        </div>
                    </div>
                </div>
            </div>
            </div>

            

            <div class="col-xs-12 col-sm-12 placeholder" id="NewProPanel">
                <div class="panel panel-default">
                  <div class="panel-heading">
                      <button class="btn btn-default" type="button" onclick="javascript:AddNewProject()">
                          <span class="glyphicon glyphicon-plus"></span>
                      </button> اضافه کردن تکلیف جدید 
                  </div>
                  <table class="table" id="AddNewPanel" style="display:none;">
                      <tr>
                          <td>
                              <table class="table">
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">عنوان فارسی</span></h5>
                                      </td>
                                      <td>
                                          <input type="text" class="form-control" id="txtFTitle" runat="server" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">عنوان انگلیسی</span></h5>
                                      </td>
                                      <td>
                                          <input type="text" class="form-control" id="txtETitle" style="text-align:left;" runat="server" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">زمینه</span></h5>
                                      </td>
                                      <td>
                                          <div class="input-group" style="width:300px;">
			                                    <input type="text" class="form-control" id="txtfilterterm" onkeyup="javascript: if (event.keyCode == 13) document.getElementById('btnAddSearchTag').click()"/>
			                                    <div class="input-group-btn">
				                                    <input class="btn btn-default" type="button" id="btnAddSearchTag" onclick="javascript: UPAddField();" value="+" />                                    
			                                    </div>
		                                    </div><br />                                          
                                          <div class="container-fluid">
                                              <span id="txtSelectedFields" runat="server" style="display:none;"></span>
                                              <div class="row" id="SelectedFields">
                                                  
                                              </div>                                            
                                          </div>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">خلاصه نمایشی</span></h5>
                                      </td>
                                      <td>
                                          <input type="text" class="form-control" id="txtPDesc" runat="server" />
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">چکیده</span></h5>
                                      </td>
                                      <td>
                                          <textarea style="width:100%; min-height:100px;" id="txtdescription" dir="rtl" runat="server"></textarea>
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <hr />                              
                              <table class="table">
                                  <tr>
                                      <td style="vertical-align:middle; width:15%">
                                          <h5><span class="text-left">فایل</span></h5>
                                      </td>
                                      <td>
                                          <div id="FUPlace">
                                              <div id="FU_1" class="panel panel-default">
                                                  <div class="panel-heading">
                                                      فایل شماره 1 (الزامی)
                                                  </div>
                                                  <table class="table">
                                                      <tr>
                                                          <td style="width:20%; vertical-align:middle;">
                                                              <asp:FileUpload runat="server" ID="FileUploader_1" />
                                                              <asp:RegularExpressionValidator ID="rexp" runat="server" ControlToValidate="FileUploader_1"
                                                                 ErrorMessage="Only .docx, .xlsx, .pptx, .pdf, .zip and .rar"
                                                                 ValidationExpression="(.*\.([Zz][Ii][Pp])|.*\.([Pp][Dd][Ff])|.*\.([Dd][Oo][Cc])|.*\.([Dd][Oo][Cc][Xx])|.*\.([Xx][Ll][Ss])|.*\.([Xx][Ll][Ss][Xx]|.*\.([Pp][Pp][Tt])|.*\.([Pp][Pp][Tt][Xx]))$)"></asp:RegularExpressionValidator>
                                                          </td>
                                                          <td style="width:65%; vertical-align:middle;">
                                                              <input type="text" runat="server" class="form-control" id="FDesc_1" value="توضیح" style="color:gray; font-size:10pt;" onfocus="javascript:ElFo(this, 'توضیح');" onblur="javascript:ElBl(this,'توضیح')" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>
                                              <div id="Div1" class="panel panel-default">
                                                  <div class="panel-heading">
                                                      فایل شماره 2 (اختیاری)
                                                  </div>
                                                  <table class="table">
                                                      <tr>
                                                          <td style="width:20%; vertical-align:middle;">
                                                              <asp:FileUpload runat="server" ID="FileUploader_2" />
                                                          </td>
                                                          <td style="width:65%; vertical-align:middle;">
                                                              <input type="text" runat="server" class="form-control" id="FDesc_2" value="توضیح" style="color:gray; font-size:10pt;" onfocus="javascript:ElFo(this, 'توضیح');" onblur="javascript:ElBl(this,'توضیح')" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>
                                              <div id="Div2" class="panel panel-default">
                                                  <div class="panel-heading">
                                                      فایل شماره 3 (اختیاری)
                                                  </div>
                                                  <table class="table">
                                                      <tr>
                                                          <td style="width:20%; vertical-align:middle;">
                                                              <asp:FileUpload runat="server" ID="FileUploader_3" />
                                                          </td>
                                                          <td style="width:65%; vertical-align:middle;">
                                                              <input type="text" runat="server" class="form-control" id="FDesc_3" value="توضیح" style="color:gray; font-size:10pt;" onfocus="javascript:ElFo(this, 'توضیح');" onblur="javascript:ElBl(this,'توضیح')" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>
                                              <div id="Div3" class="panel panel-default">
                                                  <div class="panel-heading">
                                                      فایل شماره 4 (اختیاری)
                                                  </div>
                                                  <table class="table">
                                                      <tr>
                                                          <td style="width:20%; vertical-align:middle;">
                                                              <asp:FileUpload runat="server" ID="FileUploader_4" />
                                                          </td>
                                                          <td style="width:65%; vertical-align:middle;">
                                                              <input type="text" runat="server" class="form-control" id="FDesc_4" value="توضیح" style="color:gray; font-size:10pt;" onfocus="javascript:ElFo(this, 'توضیح');" onblur="javascript:ElBl(this,'توضیح')" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>
                                              <div id="Div4" class="panel panel-default">
                                                  <div class="panel-heading">
                                                      فایل شماره 5 (اختیاری)
                                                  </div>
                                                  <table class="table">
                                                      <tr>
                                                          <td style="width:20%; vertical-align:middle;">
                                                              <asp:FileUpload runat="server" ID="FileUploader_5" />
                                                          </td>
                                                          <td style="width:80%; vertical-align:middle;">
                                                              <input type="text" runat="server" class="form-control" id="FDesc_5" value="توضیح" style="color:gray; font-size:10pt;" onfocus="javascript:ElFo(this, 'توضیح');" onblur="javascript:ElBl(this,'توضیح')" />
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </div>
                                          </div>                                          
                                      </td>
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr>
                          <td>
                              <hr />
                              <table class="table">
                                  <tr>
                                      <td>
                                          <h5><span class="text-left">نوع فروش : </span></h5>
                                      </td>
                                      <td>
                                          <div class="input-group" style="width:200px;">
                                              <div class="input-group-btn">                                                  
                                              <select class="form-control" runat="server" id="slcSellType" style="font-size:10pt;">
                                                  <option selected="selected" value="0">ساده</option>
                                                  <option value="1">ویژه</option>
                                              </select>
                                              <button class="btn btn-info" data-toggle="modal" data-target="#myModal1">?</button>
                                              </div>    
                                          </div>
                                      </td>
                                      <td>
                                          <h5><span class="text-left">قیمت : </span></h5>
                                      </td>
                                      <td>
                                          <div class="input-group" style="width:250px;">
                                              <input style="direction:ltr;" type="text" class="form-control" runat="server" id="txtPrice" />
                                              <span style="direction:ltr;" class="input-group-addon">ریال</span>
                                          </div>
                                      </td>
                                  </tr>
                              </table>
                              <div class="modal fade" style="text-align:center;" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                  <div class="modal-dialog" style="text-align:center;">
                                    <div class="modal-content" style="width:300px;text-align:center;">
                                      <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="myModalLabel">نوع فروش</h4>
                                      </div>
                                      <div class="modal-body">
                                          <h5>ساده: دریافت 80% فروش</h5><br />
                                          <h5>ویژه: دریافت 65% فروش</h5>
                                      </div>
                                      <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">بستن</button>                                        
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              <hr />
                          </td>
                      </tr>
                      <tr>
                          <td class="text-center">
                              <div class="btn-group">
                                <asp:Button id="btnSave" runat="server" CssClass="btn btn-primary" style="width:250px;" OnClick="btnSave_Click" Text="ثبت پروژه" UseSubmitBehavior="False" />
                              </div>
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



    
        
    
