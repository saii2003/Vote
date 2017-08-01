<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_add.aspx.cs" Inherits="Member_member_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>加入會員</title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <style type="text/css">
        .style3
        {
            width: 98%;
        }
        .style3
        {
            font-family: 微軟正黑體;
            color: #333333;
            line-height: 35px;
            text-indent: 15px;
        }
        #content
        {
            padding: 10px;
            margin-bottom: 10px;
        }
        #content
        {
            padding-left: 25px;
        }
        .title
        {
            background-color: #6699FF;
            color: #FFFFFF;
            font-size: 22px;
            font-weight: 900;
            font-family: 新細明體;
        }
        .style3
        {
            height: 490px;
        }
        #content
        {
            background-color: #FFFFFF;
            padding: 10px;
        }
        .style4
        {
            width: 97px;
        }
        .style5
        {
            width: 664px;
        }
        .style3
        {
            margin: 0px auto 0px auto;
        }
        .style4
        {
            letter-spacing: 2px;
        }
    </style>
</head>
<body>
<script type="text/javascript">
    $(function () {
        $('#check').click(function () {
            $.ajax({
                url: 'WebService2.asmx/HelloWorld',
                type:'post',
                dataType: 'xml',
                

                success: function (xml) {
                    alert($(xml));

                }
            });
        });
    });

</script>






        <form id="form1" runat="server">
    <div id="top">
    </div>
    <div id="header"><a href="../index.aspx">會員投票系統</a></div>
    <div id="content">
        <table class="style3">
            <tr>
                <td colspan="2" class="title">
                    申請會員</td>
            </tr>
            <tr>
                <td class="style4">
                    帳號：</td>
                <td class="style5">
                    <asp:TextBox ID="account" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    密碼：</td>
                <td class="style5" >
                    <asp:TextBox ID="password" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    姓名：</td>
                <td class="style5">
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    性別：</td>
                <td class="style5">
                    <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    生日：</td>
                <td class="style5">
                    <asp:DropDownList ID="year" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="month" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="day" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    電話：</td>
                <td class="style5">
                    <asp:TextBox ID="phone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    手機：</td>
                <td class="style5">
                    <asp:TextBox ID="cellphone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    地址：</td>
                <td class="style5">
                    <asp:DropDownList ID="city" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="district" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="address" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    電子郵件：</td>
                <td class="style5">
                    <asp:TextBox ID="email" runat="server" Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="Button1" runat="server" Height="30px" Text="確定" Width="80px" 
                        onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Height="30px" Text="取消" Width="80px" 
                        onclick="Button2_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    <div id="footer">
        
        Copyright © 2015 saii2003@hotmail.com&nbsp; All rights reserved.
        <br />
        測試網頁</div></form>
        
</body>
</html>
