<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vote_ends.aspx.cs" Inherits="vote_ends" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投票結果</title>
    <link href="Styles/index.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .title
        {
            font-family: 微軟正黑體;
            font-size: 20px;
            color: #333333;
            font-weight: 900;
            line-height: 30px;
            text-indent: 15px;
        }
        .date
        {
            font-family: 微軟正黑體;
            font-size: 16px;
            color: #333333;
            line-height: 30px;
            text-indent: 15px;
        }
        .item
        {
            font-family: 微軟正黑體;
            color: #333333;
            font-weight: 18;
            text-indent: 15px;
        }
        td
        {
            padding-right: 20px;
        }
        #content1
        {
            margin: 0px auto 0px auto;
            padding: 10px;
            width: 1000px;
            box-raduis:5px;
        }
        .title
        {
            background-color: #ACD6FF;
        }
        .style4
        {
            font-family: 微軟正黑體;
            font-size: 16px;
            color: #333333;
            line-height: 30px;
            text-indent: 15px;
            width: 822px;
        }
        .style5
        {
            line-height: 30px;
            text-indent: 15px;
            font-family: 微軟正黑體;
            color: #333333;
            font-weight: 18;
        }
        .style6
        {
            width: 822px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">你好，<asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click"></asp:LinkButton>
    </div>
    <div id="header"> <a href="index.aspx">會員投票系統</a></div>
    <div id="content1">
        <table class="style3">
            <tr>
                <td class="header" colspan="2" 
                    
                    style="color: #FFFFFF; font-weight: 900; font-family: 新細明體">
                    題目：<asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    投票期間：<asp:Label ID="Label3" runat="server"></asp:Label>
                    ~<asp:Label ID="Label4" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td style="text-align: right">
                    總票數：<asp:Label ID="Label6" runat="server" 
                        ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    &nbsp;
                    </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/index.aspx">回首頁</asp:HyperLink>
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
