<%@ Page Title="تکلیف بازار - نمایش تکلیف" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="ProjView.aspx.cs" Inherits="ProjView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/signin.css" rel="stylesheet" />
    <link href="../css/styles.css" rel="stylesheet" />
    <link href="../css/Scrollbar.css" rel="stylesheet" />
    <link href="../css/staring.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />    
<div align="center">
    <div class="ViewWin_Norm" style="width:40%;">
        <table class="table table-bordered" style="background-color:white;">
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td colspan="5" style="text-align:right;"><h5><% = txtFTitle %></h5></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align:left;"><h5><% = txtETitle %></h5></td>
                        </tr>
                        <tr>
                            <td style="text-align:right;">
                                <span>دسته:</span>
                            </td>                            
                        </tr>
                        <tr>
                            <td>
                                <% = txtFieldsShow %>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align:middle; width:20%;">
                    <table style="width:100%; text-align:center;">
                        <tr>
                            <td style="direction:ltr;">
                                <% if((LoginClass)Session["LC"]==null){ %>
                                <div style="background-image:url('../images/star-gray.png'); text-align:left; background-repeat:repeat-x; width:90px; height:19px;">
                                    <div style="background-image:url('../images/star-gold.png'); text-align:left; background-repeat:repeat-x; width:<% = txtPaper_Rate %>%; height:19px;">
                                    </div>
                                </div>
                                <%}else{ %>
                                <div class="starRating" style="width:90px;">
                                    <div>
                                        <div>
                                            <div>
                                                <div>
                                                    <input id="rating1" type="radio" name="rating" value="1" />
                                                    <label for="rating1"><span>1</span></label>
                                                </div>
                                                <input id="rating2" type="radio" name="rating" value="2" />
                                                <label for="rating2"><span>2</span></label>
                                            </div>
                                            <input id="rating3" type="radio" name="rating" value="3" />
                                            <label for="rating3"><span>3</span></label>
                                        </div>
                                        <input id="rating4" type="radio" name="rating" value="4" checked="checked" />
                                        <label for="rating4"><span>4</span></label>
                                    </div>
                                    <input id="rating5" type="radio" name="rating" value="5" />
                                    <label for="rating5"><span>5</span></label>
                                </div>
                                <%} %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <% = txtDownloadC %>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <span>فروشنده:</span>
                                        </td>
                                        <td>
                                            <span><% = txtOwner_Name %></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span>اعتبار: </span>
                                        </td>
                                        <td style="direction:ltr; text-align:center; width:110px;">
                                            <% if ((LoginClass)Session["LC"] == null)
                                               { %>
                                            <div style="background-image:url('../images/star-gray.png'); text-align:left; background-repeat:repeat-x; width:90px; height:19px;">
                                                <div style="background-image:url('../images/star-gold.png'); text-align:left; background-repeat:repeat-x; width:<% = txtPaper_Rate %>%; height:19px;">
                                                </div>
                                            </div>
                                            <%}else{ %>
                                            <div class="starRating" style="width:90px;">
                                                <div>
                                                    <div>
                                                        <div>
                                                            <div>
                                                                <input id="rating11" type="radio" name="rating1" value="1" />
                                                                <label for="rating11"><span>1</span></label>
                                                            </div>
                                                            <input id="rating12" type="radio" name="rating1" checked="checked" value="2" />
                                                            <label for="rating12"><span>2</span></label>
                                                        </div>
                                                        <input id="rating13" type="radio" name="rating1" value="3" />
                                                        <label for="rating13"><span>3</span></label>
                                                    </div>
                                                    <input id="rating14" type="radio" name="rating1" value="4" />
                                                    <label for="rating14"><span>4</span></label>
                                                </div>
                                                <input id="rating15" type="radio" name="rating1" value="5" />
                                                <label for="rating15"><span>5</span></label>
                                            </div>
                                            <%} %>
                                        </td>
                                    </tr>
                                </table>                                
                            </td>                            
                            <td>
                                <span>قیمت</span>
                            </td>
                            <td>
                                <span><% = txtPrice %></span>
                            </td>
                            <td>
                                <span>ریال</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div class="scrollbar" style="width:100%; height:100px; text-align:right;">
                        <% = txtP_Desc %>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table>
                        <tr>
                            <td>
                                <div class="tooltip-demo">
                                    <button type="button" class="btn btn-primary" data-target="#myModal" id="btnPrev" data-toggle="modal">پیش نمایش</button>
                                </div>
                            </td>
                            <td>
                                <div class="tooltip-demo"> 
                                    <asp:Button ID="btnBuy" runat="server" CssClass="btn btn-success" Text="خرید" OnClick="btnBuy_Click" />                                    
                                </div>
                            </td>
                            <td>
                                <div class="tooltip-demo">
                                    <button type="button" class="btn btn-danger" id="btnReport" data-toggle="tooltip" data-placement="bottom" title="اگر تخلفی در این تکلیف می بینید و یا مشکلی در خریداری این تکلیف دارید کلیک کنید.">گزارش</button>
                                </div>
                            </td>                            
                        </tr>
                    </table>
                    
                </td>                
            </tr>
        </table>
        <div class="modal fade" style="text-align:center;" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog" style="text-align:center;">
                <div class="modal-content" style="width:100%;text-align:center;">
                    <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">فایل های پیش نمایش</h4>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th style="width:15%; text-align:center;">
                                        #
                                    </th>
                                    <th style="width:30%; text-align:center;">
                                        نوع
                                    </th>
                                    <th style="width:30%; text-align:center;">
                                        سایز
                                    </th>
                                    <th style="width:25%; text-align:center;">
                                        دانلود
                                    </th>
                                </tr>
                            </thead>
                            <tbody>                                
                                <% = txtPrevFiles %>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">بستن</button>                                        
                    </div>
                </div>
            </div>
        </div>
    </div>
            </div>
    </asp:Content>
