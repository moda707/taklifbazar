<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="Factor.aspx.cs" Inherits="Factor"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />

    <div align="center">
        <div class="ViewWin_Norm" style="width:40%;">
            <table class="table table-bordered" style="background-color:white;">
                <thead>
                    <tr>
                        <th style="width:80%;">
                            عنوان
                        </th>
                        <th style="width:20%;">
                            مبلغ (ریال)
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <span id="txtTitle" runat="server"></span>                            
                        </td>
                        <td>
                            <span id="txtPrice" runat="server"></span>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            تخفیف با کد : 32452
                        </td>
                        <td>
                            <span id="txtDiscount" runat="server"></span>                            
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom:none; border-left:none;">
                           <h4>جمع کل</h4>
                        </td>
                        <td>
                            <span id="txtTotalCost" runat="server"></span>                            
                        </td>
                    </tr>
                </tbody>
            </table><hr />
            <div align="center">
                <h5><span class="text-left">درگاه پرداخت اینترنتی : </span></h5>
                <select style="font-size:9pt; width:60%;" class="form-control" id="optBankName" runat="server">
                    <option value="0">بانک ملت</option>
                    <option value="1">موسسه اعتباری توسعه</option>
                </select>
            </div><br />
            <% if(((LoginClass)Session["LC"])==null){ %>
            <div class="alert alert-info">                
                <h5>
                شما در تکلیف بازار عضو نیستید، پیشنهاد می شود ابتدا  از <a href="Register.aspx?=<% = Encryption.Encrypt("State=Form", SharedDataInfo.SecurityKey) %>">اینجا</a> عضو شوید.<br /> در غیر اینصورت آدرس ایمیل خود را جهت دریافت لینک تکلیف خریداری شده وارد کنید:</h5>
                <input class="form-control" type="text" id="txtEmail" runat="server" style="width:200px; direction:ltr;" />
                <h6 class="alert alert-danger">در وارد نمودن آدرس ایمیل دقت کنید، زیرا لینک دریافت تکلیف خریداری شده برای غیر اعضا تنها یک بار ارسال می شود.</h6>
            </div><br />
            <%} %>
            <div>
                <asp:Button runat="server" ID="btnPay" CssClass="btn btn-info" OnClick="btnPay_Click" Text="پرداخت" />
                <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" Text="لغو" />
            </div>
            
        </div>
    </div>
</asp:Content>
