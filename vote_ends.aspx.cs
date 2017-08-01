using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vote_ends : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("~/index.aspx");
        }
        else
        {
            if (Session["m_id"] == null)
            {
                Label1.Text = "訪客!";
                LinkButton1.Visible = false;
            }
            else
            {
                Label1.Text = Session["name"].ToString();
                LinkButton1.Text = "登出";
            }
            Vote votes = new Vote();
            votes.vote_end(Request.QueryString["id"].ToString(), Request.QueryString["id"].ToString(), Label2, Label3, Label4, Label5, Label6);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/vote_ends.aspx?id=" + Request.QueryString["id"].ToString());
    }
}