<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettlementView.aspx.cs" Inherits="SettlementView" %>

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
                    <span id="txtPre_Code" runat="server">Us23h2jG</span>
                </td>
                <td>
                    <span id="txtTarikh" runat="server"></span>
                </td>
                <td>
                    <span id="txtUser" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td colspan="3">                    
                    <span id="txtDesc" runat="server"></span>
                </td>
            </tr>
            <tr>
                <td >
                    <span id="txtAccBal" runat="server"></span>
                </td>
                <td>
                    <span id="txtAmount" runat="server"></span>
                </td>
                <td>
                    <span id="txtSettleDate" runat="server"></span>
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
                <td>
                    <span>شماره تراکنش: </span>
                </td> 
                <td colspan="2">
                    <input class="form-control" runat="server" id="txtTransNum" type="text" style="direction:ltr; width:250px;" />
                </td>               
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnPay" runat="server" CssClass="btn btn-success" OnClick="btnPay_Click" Text="پرداخت" Width="130px" />
                    <asp:Button ID="btnInprogress" runat="server" CssClass="btn btn-warning" OnClick="btnInprogress_Click" Text="در حال انجام" Width="130px" />
                    <asp:Button ID="btnReject" runat="server" CssClass="btn btn-danger" OnClick="btnReject_Click" Text="رد درخواست" Width="130px" />
                </td>
            </tr>
        </table>

    </div>
    </form>
</body>
</html>
