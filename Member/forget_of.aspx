<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forget_of.aspx.cs" Inherits="forget_of" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新密碼</title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #content
        {
            margin-bottom: 10px;
        }
        #content
        {
            margin-top: 10px;
        }
        #content
        {
            border: 1px solid #CCCCCC;
            width: 990px;
        }
        .title
        {
            background-color: #97C0FF;
            font-size: 20px;
            font-family: 新細明體;
            color: #FFFFFF;
            font-weight: 900;
        }
        td
        {
            line-height: 30px;
            text-indent: 20px;
        }
        td
        {
            line-height: 45px;
        }
        #content
        {
            line-height: 50px;
            text-align: center;
            font-size: 20px;

            font-family: 新細明體;
        }
        .lab
        {
            color: #FF6666;
        }
        #content1
        {
            background-color: #FFFFFF;
            margin: 0px auto 0px auto;
            width: 1000px;
            text-align: center;
            font-size: 20px;
            line-height: 100px;
            box-raduis:5px;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
    <div id="top">
    </div>
    <div id="header">會員投票系統</div>
    <div id="containt">
    <div id="content1">
     
        已經密碼傳送到你的<asp:Label 
            ID="Label1" runat="server" CssClass="lab"></asp:Label>
        信箱!<a href="../index.aspx">回首頁</a></div>
    </div>
    <div id="footer">
        
        Copyright © 2015 saii2003@hotmail.com&nbsp; All rights reserved.
        <br />
        測試網頁</div>
        </form>
</body>
</html>
