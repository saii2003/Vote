using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forget_pw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Member da = new Member();
        if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
        {
            if (da.forget_pw(TextBox1.Text, TextBox2.Text, "http://localhost/Vote/Member/new_pw.aspx") == 1)
            {
                Session["mail"] = TextBox2.Text;
                Response.Redirect("~/Member/forget_of.aspx");
            }
            else
            {
                Response.Write("<script>alert('資料輸入錯誤!');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('請輸入帳號和電子郵件!');</script>");
        }
    }
}