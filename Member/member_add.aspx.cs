using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;


public partial class Member_member_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Member da = new Member();

            da.DropDownListBirthday(year, month, day);
            da.DropDownListAddress(city, district);
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {       
        Member da1 = new Member();
        if (da1.Mem_add(account, password, name, sex, year, month, day, phone, cellphone, city, district, address, email) == 1)
        {
            Response.Write("<script>alert('你已經成功加入會員，現在可以進行投票');location.href='/Vote/Index.aspx';</script>");
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        account.Text = "";
        password.Text = "";
        name.Text = "";
        phone.Text = "";
        cellphone.Text = "";
        address.Text = "";
        email.Text = "";

    }
}