<%@ Page Title="" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="DownloadHW.aspx.cs" Inherits="DownloadHW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/Scrollbar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
<div align="center">
    <div class="ViewWin_Norm" style="width:40%;">
        <% if (!String.IsNullOrEmpty(Request.QueryString[0]))
            { %>        
        <table class="table">
            <thead>
                <tr>
                    <th style="width:15%; text-align:center;">
                        #
                    </th>
                    <th style="width:30%; text-align:center;">
                        عنوان
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
                <% = txtFiles %>
            </tbody>
        </table>
        <% } %>
    </div>
</div>
</asp:Content>

