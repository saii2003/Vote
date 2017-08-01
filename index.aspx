<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>會員投票系統</title>
    <link href="Styles/index.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <div id="top">你好，<asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" ForeColor="White" 
            PostBackUrl="~/vote_add.aspx">新增投票項目</asp:LinkButton>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
            ForeColor="White"></asp:LinkButton>
    </div>
    <div id="header">
        會員投票系統</div>
    <div id="content">
    <div id="left">
        <div>
            
            <div id="vote">
            <div id="voteh" title="會員投票系統">
                歷史投票</div>
                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="g2" ShowHeader="False" style="text-align: left" GridLines="None" 
                    AllowPaging="True" onpageindexchanging="GridView2_PageIndexChanging" 
                    PageSize="12">
                     <Columns>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:HyperLink ID="HyperLink3" runat="server" Text='<%# Eval("vote_title") %>' 
                                     NavigateUrl='<%# "vote.aspx?id="+Eval("vote_id") %>' CssClass="vote_title"></asp:HyperLink>
                                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("vote_id") %>' 
                                     Visible="False"></asp:Label>
                             </ItemTemplate>
                             <ItemStyle CssClass="vote1" />
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("vote_date","{0:d}") %>'></asp:Label>
                                 ~<asp:Label ID="Label5" runat="server" Text='<%# Eval("vote_over","{0:d}") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle CssClass="vote2" />
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 總票數：<asp:Label ID="Label6" runat="server" ForeColor="#FF3300" 
                                     Text='<%# Eval("rank") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle CssClass="vote3" />
                         </asp:TemplateField>
                     </Columns>
                </asp:GridView>
            </div>
           
        </div>
    </div>
    <div id="right">
        <div id="login">
            <table class="style1">
                <tr>
                    <td class="header" colspan="3">
                        會員登入</td>
                </tr>
                <tr>
                    <td class="t1">
                        帳號</td>
                    <td class="t2">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td class="t3" rowspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button" Height="60px" 
                            Text="登入" Width="50px" onclick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="t1">
                        密碼</td>
                    <td class="t2">
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="footer" colspan="3">
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl="~/Member/member_add.aspx">申請帳號</asp:HyperLink>
&nbsp;
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl="~/Member/forget_pw.aspx">忘記密碼</asp:HyperLink>
                    &nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="right2">
            <table class="style2">
                <tr>
                    <td class="voteheader">
                        最新投票</td>
                </tr>
                <tr>
                    <td class="title">
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="item">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="vfooter">
                        <asp:Button ID="Button2" runat="server" Text="投票" onclick="Button2_Click" 
                            Height="30px" Width="80px" />
                        <asp:Button ID="Button3" runat="server" Text="結果" onclick="Button3_Click" 
                            Height="30px" Width="80px" />
                    </td>
                </tr>
            </table>
    </div>
    </div>
    
    </div>
    <div id="footer">
        
        Copyright © 2015 saii2003@hotmail.com&nbsp; All rights reserved.
        <br />
        測試網頁</div>
        </form>
        


</body>
</html>
