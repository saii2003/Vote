<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vote.aspx.cs" Inherits="vote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投票區</title>
    <link href="Styles/index.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #contain1,#content1,#cheader
        {
            margin: 0px auto;
            width: 1000px;
        }
        .style3
        {
            width: 100%;
        }
        #cheader
        {
            font-family: 微軟正黑體;
            font-size: 25px;
            color: #FFFFFF;
            background-color: #6699FF;
            font-weight: 800;
            line-height: 35px;
            text-indent: 20px;
        }
        .title
        {
            color: #333333;
            font-size: 25px;
            font-weight: 900;
            line-height: 35px;
            text-indent: 15px;
        }
        .item
        {
            line-height: 30px;
            text-indent: 15px;
            font-size: 18px;
            color: #333333;
        }
        #cheader
        {
            font-family: 新細明體;
            margin-top: 10px;
            width: 990px;
        }
     
        .title
        {
 
            font-size: 20px;
            text-indent: 20px;
        }
        .item
        {

            text-indent: 20px;
        }
        .item
        {
            text-indent: 20px;
        }

        .style4
        {
            font-size: 25px;
            font-weight: 900;
            text-indent: 20px;
            color: #FFFFFF;
            height: 1px;
            font-family: 新細明體;
            line-height: 40px;
            background-color: #6699FF;
        }
        .style4
        {
            line-height: 30px;
        }
       
        #content1
        {
            padding: 10px;
        }
    </style>
</head>
<body>
  <form id="form1" runat="server">
    <div id="top">你好，<asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            ForeColor="White">LinkButton</asp:LinkButton>
    </div>
    <div id="header"> <a href="index.aspx">會員投票系統</a></div>
    <div id="content1">
    
        <table class="style3">
            <tr>
                <td class="header">
                    投票</td>
            </tr>
            <tr>
                <td class="title">
                    題目：<asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="item">
                    投票日期：<asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="item">
                    結束日期：<asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="item">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="item" style="text-align: right">
                    <asp:Button ID="Button1" runat="server" Text="投票" Height="30px" 
                        onclick="Button1_Click" Width="80px" />
                    <asp:Button ID="Button2" runat="server" Text="結果" Height="30px" Width="80px" 
                        onclick="Button2_Click1" />
                </td>
            </tr>
        </table>
    
    </div>
    <div id="footer">
        
        Copyright © 2015 saii2003@hotmail.com&nbsp; All rights reserved.
        <br />
        測試網頁<br />
        </div>
    </form>
</body>
</html>
