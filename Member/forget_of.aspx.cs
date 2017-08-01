using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forget_of : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mail"] == null)
        {
            Response.Redirect("~/index.aspx");
        }
        else
        {
            Label1.Text = Session["mail"].ToString().Replace(Session["mail"].ToString().Substring(3, 4), "****");
            Session.RemoveAll();

        }
    }
}