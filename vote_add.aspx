<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vote_add.aspx.cs" Inherits="vote_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增投票項目</title>
    <link href="Styles/index.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style3
        {
            font-family: 微軟正黑體;
            color: #333333;
            font-size: 18px;
            line-height: 30px;
            text-indent: 10px;
            
        }
        .style4
        {
        }
        .style5
        {
            font-size: medium;
        }
        .style3
        {
            width: 789px;
            margin: 10px 10px 50px 10px;
        }
        #content
        {
        }
        .style3
        {
            margin: 10px 10px 10px 50px;
        }
        .style3
        {
            height: 479px;
        }
        #content1
        {
            margin: 0px auto 0px auto;
        }
        #content
        {
            background-color: #FFFFFF;
            border-radius:5px;
        }
        #content
        {
            padding-top: 12px;
        }
        .style3
        {
            margin: 0px auto 0px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
    </div>
    <div id="header"><a href="index.aspx">會員投票系統-新增投票項目</a></div>

    <div id="content">
    
        <table class="style3" align="center">
            <tr>
                <td class="style4" colspan="2">
                    投票名稱：<asp:TextBox ID="TextBox1" runat="server" Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    投票日期：<asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2">
                    結束日期：<asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                    <span class="style5">格式ex:2012/09/01</span></td>
            </tr>
            <tr>
                <td colspan="2">
                    投票項目：</td>
            </tr>
            <tr>
                <td class="style4">
                    1.　<asp:TextBox 
                        ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    2.　<asp:TextBox ID="TextBox4" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    3.　<asp:TextBox ID="TextBox5" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    4.　<asp:TextBox ID="TextBox6" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    5.　<asp:TextBox ID="TextBox7" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    6.　<asp:TextBox ID="TextBox8" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    7.　<asp:TextBox ID="TextBox9" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    8.　<asp:TextBox 
                        ID="TextBox10" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="Button1" runat="server" Text="新增" onclick="Button1_Click" 
                        Height="30px" Width="80px" />
                    <asp:Button ID="Button2" runat="server" Text="取消" Height="30px" Width="80px" />
                </td>
            </tr>
        </table>
    
    </div>
    <div id="footer">
        
        Copyright © 2015 saii2003@hotmail.com&nbsp; All rights reserved.
        <br />
        測試網頁</div>
    </form>
</body>
</html>
