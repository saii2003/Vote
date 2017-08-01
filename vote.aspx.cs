using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
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
                    LinkButton1.Text = "登入";
                    LinkButton1.PostBackUrl = "~/index.aspx";
                }
                else
                {
                    Label1.Text = Session["name"].ToString();
                    LinkButton1.Text = "登出";
                }
                Vote votes = new Vote();
                votes.vote_item(RadioButtonList1, Server.HtmlEncode(Request.QueryString["id"].ToString()), Server.HtmlEncode(Request.QueryString["id"].ToString()), Label2, Label3, Label4);
            }
            if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")), Convert.ToDateTime(Label4.Text)) >= 0)
            {
                Response.Redirect("vote_ends.aspx?id=" + Request.QueryString["id"].ToString());
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Vote votes1 = new Vote();
        if (Session["m_id"] == null)
        {
            Response.Write("<script>alert('請先登入');</script>");
        }
        else
        {
            if (RadioButtonList1.SelectedValue == "")
            {
                Response.Write("<script>alert('請選擇投票項目');</script>");
            }
            else
            {

                if (votes1.voted(Session["m_id"].ToString(), Request.QueryString["id"].ToString()) == 1)
                {
                    Response.Write("<script>alert('你已經投過票');</script>");

                }
                else
                {
                    Vote votes2 = new Vote();
                    Vote votes3 = new Vote();
                    votes2.insert_voted(Session["m_id"].ToString(), Request.QueryString["id"].ToString());
                    votes3.vote_update(Request.QueryString["id"].ToString(), RadioButtonList1.SelectedItem.Text.ToString());
                    Response.Redirect("~/vote_ends.aspx?id=" + Server.UrlEncode(Request.QueryString["id"].ToString()));
                }
            }
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/vote_ends.aspx?id=" +Server.UrlEncode(Request.QueryString["id"].ToString()));
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/vote.aspx?id=" + Server.UrlEncode(Request.QueryString["id"].ToString()));
    }
}