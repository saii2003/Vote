using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vote_add : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
           Response.Redirect("~/index.aspx");
        }

        Label2.Text = DateTime.Now.ToString("yyyy/MM/dd");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Vote voteid = new Vote();
        int id = 0;
        id = Convert.ToInt32(voteid.voteid());
 
        if (TextBox1.Text == "" && TextBox2.Text == "")
        {
            Response.Write("<script>alert('標題和日期不能空白！')</script>");
        }
        else
        {
            Vote voteadd = new Vote();
            Vote votedadd = new Vote();
            voteadd.vote_add(TextBox1.Text, Label2.Text, TextBox2.Text);
            for (int i = 3; i <= 10; i++)
            {
                TextBox tb = (TextBox)Page.FindControl("TextBox" + i);
                if (tb.Text != "")
                {
                    if (votedadd.vote_d_add(id, Server.HtmlEncode(tb.Text)) != 0)
                    {
                        Response.Write("<script>alert('新增投票項目成功!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('新增投票項目失敗!');</script>");
                    }
                    
                }
            }
            
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }
    }
}