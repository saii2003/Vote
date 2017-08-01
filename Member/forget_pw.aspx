<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forget_pw.aspx.cs" Inherits="forget_pw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link href="../Styles/index.css" rel="stylesheet" type="text/css" />

    <title>忘記密碼</title>
    <style type="text/css">
        #content
        {
            margin-bottom: 10px;
        }
        .style3
        {
            width: 100%;
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
        .style4
        {
            width: 104px;
        }
        td
        {
            line-height: 45px;
        }
        #content1
        {
            margin: 0px auto 0px auto;
            padding: 10px;
            width: 1000px;
            box-raduis:5px;
        }
        .style5
        {
            height: 22px;
            line-height: 30px;
            color: #FF0000;
        }
        .style5
        {
            line-height: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
    </div>
    <div id="header"> <a href="../index.aspx">會員投票系統</a></div>
    <div id="containt">
    <div id="content1">
        <table class="style3">
            <tr>
                <td colspan="2" class="title">
                    &nbsp;&nbsp;
                    忘記密碼</td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    請輸入下面資料取的新得密碼。</td>
            </tr>
            <tr>
                <td class="style4">
                    帳號：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="340px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    電子郵件：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="339px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="送出" onclick="Button1_Click" 
                        style="width: 40px" />
                </td>
            </tr>
        </table>
    
    </div>
    </div>
    <div id="footer">
        
        Copyright © 2015 saii2003@hotmail.com&nbsp; All rights reserved.
        <br />
        測試網頁</div>
        </form>
</body>
</html>
