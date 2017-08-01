using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["name"] == null)
        {
            LinkButton2.Visible = false;
        }
        else
        {
            LinkButton2.Visible = true;
        }

        if (Session["m_id"] == null)
        {
            Label1.Text = "訪客!";
            LinkButton1.Visible = false;
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            Button1.Enabled = true;
        }
        else
        {
            Label1.Text = Session["name"].ToString();
            LinkButton1.Text = "登出";
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            Button1.Enabled = false;
        }
        Vote title = new Vote();
        title.voteTitle(Label3);

        Vote votes = new Vote();
        GridView2.DataSource =votes.votes();
        GridView2.DataBind();
        if (!Page.IsPostBack)
        {
            Vote index = new Vote();
            index.vote_item_index(RadioButtonList1);
        }
       
        
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Vote votes = new Vote();
        Response.Redirect("~/vote_ends.aspx?id=" + votes.vote_id());
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //投票題目ID
        string id = ((Label)GridView2.Rows[0].FindControl("Label4")).Text.ToString();
        if (Session["m_id"] == null)
        {
            Response.Write("<script>alert('請登入才能投票!')</script>");
            
        }
        else
        {
            Vote votes1 = new Vote();
            if (RadioButtonList1.SelectedValue == "")
            {
                Response.Write("<script>alert('請選擇投票項目')</script>");
            }
            else
            {
                if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")), Convert.ToDateTime(((Label)GridView2.Rows[0].FindControl("Label5")).Text.ToString())) >= 0)
                {
                    Response.Write("<script>alert('已經投票結束!');location.href='vote_ends.aspx?id=" + id+"';</script>");
                }
                else
                {
                    if (votes1.voted(Session["m_id"].ToString(), ((Label)GridView2.Rows[0].FindControl("Label4")).Text.ToString()) == 1)
                    {

                        Response.Write("<script>alert('你已經投過票了!'); location.href='vote_ends.aspx?id=" + id + "';</script>");


                    }
                    else
                    {
                        Vote votes2 = new Vote();
                        Vote votes3 = new Vote();
                        Vote voteId = new Vote();
                        Vote voteId1 = new Vote();
                        votes2.vote_update(id, RadioButtonList1.SelectedValue.ToString());
                        votes3.vote_update(voteId.vote_id(), RadioButtonList1.SelectedItem.Text.ToString());
                        Response.Redirect("~/vote_ends.aspx?id=" + voteId1.vote_id());
                    }
                }
            }
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MemberDA da = new MemberDA();
        if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrEmpty(TextBox2.Text))
        {
           
            if (da.mem_Login(TextBox1.Text, TextBox2.Text) == 1)
            {
                Session["m_id"] = da.m_id.ToString();
                Session["name"] = da.name.ToString();
                Session["birthday"] = da.birthday.ToString();
                Session["phone"] = da.phone.ToString();
                Session["cellphone"] = da.cellphone.ToString();
                Session["city"] = da.city.ToString();
                Session["district"] = da.district.ToString();
                Session["address"] = da.address.ToString();
                Session["email"] = da.email.ToString();
                Response.Redirect("~/index.aspx");

            }
            else
            {
                Response.Write("<script>alert('帳號密碼錯誤!')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('請輸入帳號密碼!')</script>");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("~/index.aspx");
    }
}