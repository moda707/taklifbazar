﻿<%@ Page Title="جستجو" Language="C#" MasterPageFile="~/Class.master" AutoEventWireup="true" CodeFile="GroupView.aspx.cs" Inherits="GroupView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="http://localhost:23524/css/signin.css" rel="stylesheet" />
    <link href="http://localhost:23524/css/full-slider.css" rel="stylesheet"/>
    <link href="http://localhost:23524/css/Scrollbar.css" rel="stylesheet"/>
	<link href="http://localhost:23524/css/styles.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <br />
<div align="center" id="FullPanel">
    <span style="display:none;" id="AllTags" runat="server"></span>
    <div class="WaitingForm" id="WFF" style="display:none;" tabindex="-1"></div>
    <div class="btn-group" data-toggle="buttons">
        <label class="btn btn-default">
        <input type="radio" name="options" id="option0" onchange="javascript:GV_Order('0');"/> جدیدترین
        </label>
        <label class="btn btn-default">
        <input type="radio" name="options" id="option1" onchange="javascript:GV_Order('1');"/> برترین
        </label>
        <label class="btn btn-default">
        <input type="radio" name="options" id="option3" onchange="javascript:GV_Order('3');"/> پرطرفدارترین
        </label>
        <label class="btn btn-default">
        <input type="radio" name="options" id="option2" onchange="javascript:GV_Order('2');"/> رایگان
        </label>
    </div>
    <div class="GroupView" style="width:50%;" id="TagsShow" runat="server">
        
    </div>
    <div class="GroupView" style="width:90%;">
                       
        <div class="row">
            <div id="txtGV" runat="server">

            </div>                
        </div> 
        <div id="morebtn" runat="server">                
        </div>   
            
    </div>
</div>
</asp:Content>
    