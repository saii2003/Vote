using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Member_new_pw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["checkId"] == null)
        {
            Response.Redirect("~/index.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
        {
            Response.Write("<script>alert('請輸入資料');</script>");
        }
        else
        {
            if (TextBox1.Text != TextBox2.Text)
            {
                Response.Write("<script>alert('新密碼和確認新密碼不一樣');</script>");
            }
            else
            {
                MemberDA da = new MemberDA();
                if (da.update_new_pw(Request.QueryString["checkId"].ToString(), FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox1.Text, "MD5")) == 1)
                {
                    Response.Write("<script>alert('新密碼設定成功');location.href='/Vote/index.aspx'</script>");
                }

            }
        }
    }
}