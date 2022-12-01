<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SupportView.aspx.cs" Inherits="SupportView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
	<link href="rtl/css/bootstrap-rtl.min.css" rel="stylesheet"/>
    <link href="http://fonts.googleapis.com/earlyaccess/droidarabicnaskh.css" rel="stylesheet" />
    
    <script src="js/jquery.min.js"></script>	
	<script src="js/bootstrap.min.js"></script>
    <script src="js/MJScript.js"></script>
    <script src="js/docs.min.js"></script> 
    <link href="css/Scrollbar.css" rel="stylesheet" />
	 
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;" id="FullPanel">
        <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
        <table class="table">
            <tr>
                <td>
                    <span id="txtPre_Code" runat="server"></span>
                </td>
                <td>
                    <span id="txtTarikh" runat="server"></span>
                </td>
                <td>
                    <span id="txtUser" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <select id="slcField" runat="server" class="form-control" style="width:100px; font-size:9pt;">
                        <option value="0">خرید</option>
                        <option value="1">فروش</option>                                                
                        <option value="2">تسویه</option> 
                    </select>
                </td>
                <td>
                    <select id="slcPriority" runat="server" class="form-control" style="width:130px; font-size:9pt;">
                        <option value="0">خیلی فوری</option>
                        <option value="1">فوری</option>
                        <option value="2">معمولی</option>
                    </select>
                </td>
                <td>
                    <% = Status %>                    
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div  style="border-radius: 5px 5px 5px 5px;border: 1px solid lightgray;">
                    <span class="h5">عنوان: </span><span id="txtTitle" runat="server"></span>
                    </div>
                </td>                
            </tr>
            <tr>
                <td colspan="3">
                    <div class="scrollbar" style="max-height:220px; overflow-y:scroll;">
                    <span id="txtDescription" runat="server"></span>
                        </div>
                </td>                
            </tr>
            <tr>
                <td colspan="3">
                    <textarea runat="server" style="width:100%; min-height:100px;" id="txtreply" dir="rtl"></textarea>
                </td>                
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnReply" runat="server" CssClass="btn btn-primary" OnClick="btnReply_Click" Text="ارسال" Width="130px" />
                    <% if(((LoginClass)Session["LC"]).U_Type == User_Type.Admin){ %>
                    <asp:Button ID="btnInProgress" runat="server" CssClass="btn btn-info" OnClick="btnInProgress_Click" Text="در حال بررسی" Width="130px" />
                    <%} %>
                </td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
