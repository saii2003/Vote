using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

/// <summary>
/// 會員頁面相關類別
/// </summary>
public class MemberDA:DBbase
{
	public MemberDA()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    
    public string _m_id;
    public string _name;
    public string _sex; 
    public string _birthday;
    public string _phone;
    public string _cellphone;
    public string _city;
    public string _district;
    public string _address;
    public string _email;



    public string m_id
    {
        get { return _m_id; }
        set { _m_id = value; }
    }
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string sex
    {
        get { return _sex; }
        set { _sex = value; }
    }
    public string birthday
    {
        get { return _birthday; }
        set { _birthday = value; }
    }
    public string phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    public string cellphone
    {
        get { return _cellphone; }
        set { _cellphone = value; }
    }
    public string city
    {
        get { return _city; }
        set { _city = value; }
    }
    public string district
    {
        get { return _district; }
        set { _district = value; }
    }
    public string address
    {
        get { return _address; }
        set { _address = value; }
    }
    public string email
    {
        get { return _email; }
        set { _email = value; }
    }

    public int mem_Login(string account, string password)//會員登入
    {
        int allow = 0;
        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select * From Member Where account=@account And password=@password");
        cmd.Parameters.Add("@account", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(account);
        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5"));
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            allow = 1;
            while (dr.Read())
            {

                this.m_id = dr["m_id"].ToString();
                this.name = dr["name"].ToString();
                this.sex = dr["sex"].ToString();
                this.birthday = dr["birthday"].ToString();
                this.phone = dr["phone"].ToString();
                this.cellphone = dr["cellphone"].ToString();
                this.city = dr["city"].ToString();
                this.district = dr["district"].ToString();
                this.address = dr["address"].ToString();
                this.email = dr["email"].ToString();

            }
        }
        dr.Close();
        dr.Dispose();
        cmd.Dispose();
        Dispose();
        return allow;
    }

    //申請會員
    public int Mem_add(TextBox account, TextBox password, TextBox name, RadioButtonList sex, DropDownList year, DropDownList month, DropDownList day, TextBox phone, TextBox cellphone, DropDownList city, DropDownList district, TextBox address, TextBox email)
    {
        //帳號是否重複
        int account_allow = 0;//帳號是否允許
        SqlCommand acc_cmd = SqlCmd("Select count(account) from member where account=@account");
        acc_cmd.Parameters.Add("@account", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(account.Text.ToString());
        account_allow = Convert.ToInt32(acc_cmd.ExecuteScalar());
        acc_cmd.Dispose();
        Dispose();
        //加入會員
        int add = 0;
        if (!string.IsNullOrEmpty(account.Text) || !string.IsNullOrEmpty(password.Text) || !string.IsNullOrEmpty(phone.Text) || !string.IsNullOrEmpty(cellphone.Text) || !string.IsNullOrEmpty(address.Text) || !string.IsNullOrEmpty(email.Text))
        {
            if (account_allow == 0)
            {
                SqlCommand cmd = SqlCmd("Insert into member(account,password,name,sex,birthday,phone,cellphone,city,district,address,email)Values(@account,@password,@name,@sex,@birthday,@phone,@cellphone,@city,@district,@address,@email)");
                cmd.Parameters.Add("@account", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(account.Text.ToString());
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text.ToString(), "MD5"));
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 20).Value = HttpContext.Current.Server.HtmlEncode(name.Text.ToString());
                cmd.Parameters.Add("@sex", SqlDbType.NVarChar, 10).Value = sex.SelectedValue;
                cmd.Parameters.Add("@birthday", SqlDbType.DateTime).Value = year.SelectedValue.ToString() + "/" + month.SelectedValue.ToString() + "/" + day.SelectedValue.ToString();
                cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(phone.Text.ToString());
                cmd.Parameters.Add("@cellphone", SqlDbType.NVarChar).Value = HttpContext.Current.Server.HtmlEncode(cellphone.Text.ToString());
                cmd.Parameters.Add("@city", SqlDbType.NVarChar, 10).Value = city.SelectedItem.Text.ToString();
                cmd.Parameters.Add("@district", SqlDbType.NVarChar, 10).Value = district.SelectedItem.Text.ToString();
                cmd.Parameters.Add("@address", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(address.Text.ToString());
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = HttpContext.Current.Server.HtmlEncode(email.Text.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Dispose();
                add = 1;
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('帳號已經使用過');</script>");
            }
        }
        else
        {
            HttpContext.Current.Response.Write("<script>alert('會員資料請勿空白');</script>");
        }
        
        return add;

    }
    //忘記密碼
    public int forget_pw(string account, string email,string url)
    {
        int ok = 0;
        string check_account="";
        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select account,password from member where account=@account and email=@email");
        cmd.Parameters.Add("@account", SqlDbType.NVarChar, 50).Value = account;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                ok = 1;
                check_account = dr["password"].ToString();
                //寄送新密碼
                MailMessage mail = new MailMessage("saii2003@yahoo.com.tw", email, "會員投票系統-新密碼", "請點選下列連結輸入新的密碼<p><a href='" + url + "?checkId=" + check_account + "'>" + url + "?check=" + check_account + "</a>");
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("your mail account", "your mail password");
                client.Host = "msa.hinet.net";
                client.Send(mail);
            }
        }
        dr.Dispose();
        dr.Close();
        cmd.Dispose();
        Dispose();
        return ok; 
    }
    //設定新密碼
    public int update_new_pw(string checkId, string password)
    {
        int result = 0;
        SqlCommand cmd = SqlCmd("update member set password=@password where password=@checkId");
        cmd.Parameters.Add("@checkId", SqlDbType.NVarChar, 50).Value = checkId;
        cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        Dispose();
        result = 1;
        return result;
    }
    public void DropDownListBirthday(DropDownList year,DropDownList month,DropDownList day)//dropDownLint日期
    {

        for (int y = 1911; y <=Convert.ToInt32(DateTime.Now.Year.ToString()); y++)
        {
            year.Items.Add(new ListItem(y.ToString(), y.ToString()));
        }
        for (int m = 1; m <= 12; m++)
        {
            month.Items.Add(new ListItem(m.ToString(), m.ToString()));
        }
        for (int d = 1; d <= 31; d++)
        {
            day.Items.Add(new ListItem(d.ToString(), d.ToString()));
        }
    }
    public void DropDownListAddress(DropDownList city,DropDownList district)
    {

        if (city.Items.Count == 0)
        {
            city.Items.Add(new ListItem("台北市", "1"));
            city.Items.Add(new ListItem("新北市", "2"));
            city.Items.Add(new ListItem("宜蘭縣", "3"));
            city.Items.Add(new ListItem("基隆市", "4"));
            city.Items.Add(new ListItem("桃園縣", "5"));
            city.Items.Add(new ListItem("新竹縣市", "6"));
            city.Items.Add(new ListItem("苗栗縣", "7"));
            city.Items.Add(new ListItem("台中市", "8"));
            city.Items.Add(new ListItem("彰化縣", "9"));
            city.Items.Add(new ListItem("南投縣", "10"));
            city.Items.Add(new ListItem("雲林縣", "11"));
            city.Items.Add(new ListItem("嘉義縣市", "12"));
            city.Items.Add(new ListItem("台南市", "13"));
            city.Items.Add(new ListItem("高雄市", "14"));
            city.Items.Add(new ListItem("屏東縣", "15"));
            city.Items.Add(new ListItem("台東縣", "16"));
            city.Items.Add(new ListItem("花蓮縣", "17"));
            city.Items.Add(new ListItem("澎湖縣", "18"));
            city.Items.Add(new ListItem("金門縣", "19"));
            city.Items.Add(new ListItem("連江縣", "20"));
        }
        
        switch(city.SelectedItem.Value)
        {
            case "1":
                
                district.Items.Clear();
                district.Items.Add(new ListItem("中正區","1"));
                district.Items.Add(new ListItem("大同區","2"));
                district.Items.Add(new ListItem("中山區","3"));
                district.Items.Add(new ListItem("松山區","4"));
                district.Items.Add(new ListItem("大安區","5"));
                district.Items.Add(new ListItem("萬華區","6"));
                district.Items.Add(new ListItem("信義區","7"));
                district.Items.Add(new ListItem("士林區", "8"));
                district.Items.Add(new ListItem("北投區", "9"));
                district.Items.Add(new ListItem("內湖區", "10"));
                district.Items.Add(new ListItem("南港區", "11"));
                district.Items.Add(new ListItem("文山區", "12"));

                break;
            case "2":
                district.Items.Clear();
                district.Items.Add(new ListItem("萬里區", "1"));
                district.Items.Add(new ListItem("金山區", "2"));
                district.Items.Add(new ListItem("板橋區", "3"));
                district.Items.Add(new ListItem("汐止區", "4"));
                district.Items.Add(new ListItem("深坑區", "5"));
                district.Items.Add(new ListItem("石碇區", "6"));
                district.Items.Add(new ListItem("萬芳區", "7"));
                district.Items.Add(new ListItem("平溪區", "8"));
                district.Items.Add(new ListItem("雙溪區", "9"));
                district.Items.Add(new ListItem("貢寮區", "10"));
                district.Items.Add(new ListItem("新店區", "11"));
                district.Items.Add(new ListItem("坪林區", "12"));
                district.Items.Add(new ListItem("烏來區", "13"));
                district.Items.Add(new ListItem("永和區", "14"));
                district.Items.Add(new ListItem("中和區", "15"));
                district.Items.Add(new ListItem("土城區", "16"));
                district.Items.Add(new ListItem("三峽區", "17"));
                district.Items.Add(new ListItem("樹林區", "18"));
                district.Items.Add(new ListItem("鶯歌區", "19"));
                district.Items.Add(new ListItem("三重區", "20"));
                district.Items.Add(new ListItem("新莊區", "21"));
                district.Items.Add(new ListItem("泰山區", "22"));
                district.Items.Add(new ListItem("林口區", "23"));
                district.Items.Add(new ListItem("蘆洲區", "24"));
                district.Items.Add(new ListItem("五股區", "25"));
                district.Items.Add(new ListItem("八里區", "26"));
                district.Items.Add(new ListItem("淡水區", "27"));
                district.Items.Add(new ListItem("三芝區", "28"));
                district.Items.Add(new ListItem("石碇區", "29"));
                break;
            case "3":
                district.Items.Clear();
                district.Items.Add(new ListItem("宜蘭市", "1"));
                district.Items.Add(new ListItem("頭城鎮", "2"));
                district.Items.Add(new ListItem("礁溪鄉", "3"));
                district.Items.Add(new ListItem("壯圍鄉", "4"));
                district.Items.Add(new ListItem("員山鄉", "5"));
                district.Items.Add(new ListItem("羅東鄉", "6"));
                district.Items.Add(new ListItem("三星鄉", "7"));
                district.Items.Add(new ListItem("大同鄉", "8"));
                district.Items.Add(new ListItem("五結鄉", "9"));
                district.Items.Add(new ListItem("冬山鄉", "10"));
                district.Items.Add(new ListItem("蘇澳鄉", "11"));
                district.Items.Add(new ListItem("南澳鄉", "12"));
                break;
            case "4":
                district.Items.Clear();
                district.Items.Add(new ListItem("仁愛區", "1"));
                district.Items.Add(new ListItem("信義區", "2"));
                district.Items.Add(new ListItem("中正區", "3"));
                district.Items.Add(new ListItem("中山區", "4"));
                district.Items.Add(new ListItem("安樂區", "5"));
                district.Items.Add(new ListItem("暖暖區", "6"));
                district.Items.Add(new ListItem("七堵區", "7"));
                
                break;
            case "5":
                district.Items.Clear();
                district.Items.Add(new ListItem("中壢市", "1"));
                district.Items.Add(new ListItem("平鎮市", "2"));
                district.Items.Add(new ListItem("龍潭鄉", "3"));
                district.Items.Add(new ListItem("楊梅市", "4"));
                district.Items.Add(new ListItem("新屋鄉", "5"));
                district.Items.Add(new ListItem("觀音鄉", "6"));
                district.Items.Add(new ListItem("桃園市", "7"));
                district.Items.Add(new ListItem("龜山鄉", "8"));
                district.Items.Add(new ListItem("八德市", "9"));
                district.Items.Add(new ListItem("大溪鎮", "10"));
                district.Items.Add(new ListItem("復興鄉", "11"));
                district.Items.Add(new ListItem("大園鄉", "12"));
                district.Items.Add(new ListItem("蘆竹鄉", "13"));
                break;
            case "6":
                district.Items.Clear();
                district.Items.Add(new ListItem("新竹市", "1"));
                district.Items.Add(new ListItem("竹北市", "2"));
                district.Items.Add(new ListItem("湖口鄉", "3"));
                district.Items.Add(new ListItem("新豐鄉", "4"));
                district.Items.Add(new ListItem("新埔鎮", "5"));
                district.Items.Add(new ListItem("關西鎮", "6"));
                district.Items.Add(new ListItem("芎林鄉", "7"));
                district.Items.Add(new ListItem("寶山鄉", "8"));
                district.Items.Add(new ListItem("竹東鎮", "9"));
                district.Items.Add(new ListItem("五峰鎮", "10"));
                district.Items.Add(new ListItem("衡山鄉", "11"));
                district.Items.Add(new ListItem("尖石鄉", "12"));
                district.Items.Add(new ListItem("北埔鄉", "13"));
                district.Items.Add(new ListItem("峨嵋鄉", "14"));
                break;
            case "7":
                district.Items.Clear();
                district.Items.Add(new ListItem("竹南鎮", "1"));
                district.Items.Add(new ListItem("頭分鎮", "2"));
                district.Items.Add(new ListItem("三灣鄉", "3"));
                district.Items.Add(new ListItem("南庄鄉", "4"));
                district.Items.Add(new ListItem("獅潭鄉", "5"));
                district.Items.Add(new ListItem("後龍鎮", "6"));
                district.Items.Add(new ListItem("通宵鎮", "7"));
                district.Items.Add(new ListItem("苑裡鎮", "8"));
                district.Items.Add(new ListItem("苗栗市", "9"));
                district.Items.Add(new ListItem("造橋鄉", "10"));
                district.Items.Add(new ListItem("頭屋鄉", "11"));
                district.Items.Add(new ListItem("公館鄉", "12"));
                district.Items.Add(new ListItem("大湖鄉", "13"));
                district.Items.Add(new ListItem("泰安鄉", "14"));
                district.Items.Add(new ListItem("銅鑼鄉", "15"));
                district.Items.Add(new ListItem("三義鄉", "16"));
                district.Items.Add(new ListItem("西湖鄉", "17"));
                district.Items.Add(new ListItem("卓蘭鎮", "18"));
                break;
            case "8":
                district.Items.Clear();
                district.Items.Add(new ListItem("中區", "1"));
                district.Items.Add(new ListItem("東區", "2"));
                district.Items.Add(new ListItem("南區", "3"));
                district.Items.Add(new ListItem("西區", "4"));
                district.Items.Add(new ListItem("北區", "5"));
                district.Items.Add(new ListItem("北屯區", "6"));
                district.Items.Add(new ListItem("西屯區", "7"));
                district.Items.Add(new ListItem("南屯區", "8"));
                district.Items.Add(new ListItem("太平區", "9"));
                district.Items.Add(new ListItem("大里區", "10"));
                district.Items.Add(new ListItem("霧峰區", "11"));
                district.Items.Add(new ListItem("烏日區", "12"));
                district.Items.Add(new ListItem("豐原區", "13"));
                district.Items.Add(new ListItem("后里區", "14"));
                district.Items.Add(new ListItem("石岡區", "15"));
                district.Items.Add(new ListItem("東勢區", "16"));
                district.Items.Add(new ListItem("和平區", "17"));
                district.Items.Add(new ListItem("新社區", "18"));
                district.Items.Add(new ListItem("潭子區", "19"));
                district.Items.Add(new ListItem("大雅區", "20"));
                district.Items.Add(new ListItem("神岡區", "21"));
                district.Items.Add(new ListItem("大肚區", "22"));
                district.Items.Add(new ListItem("沙鹿區", "23"));
                district.Items.Add(new ListItem("龍井區", "24"));
                district.Items.Add(new ListItem("梧棲區", "25"));
                district.Items.Add(new ListItem("清水區", "26"));
                district.Items.Add(new ListItem("大甲區", "27"));
                district.Items.Add(new ListItem("外埔區", "28"));
                district.Items.Add(new ListItem("大安區", "29"));
                break;
            case "9":
                district.Items.Clear();
                district.Items.Add(new ListItem("彰化市", "1"));
                district.Items.Add(new ListItem("芬園鄉", "2"));
                district.Items.Add(new ListItem("花壇鄉", "3"));
                district.Items.Add(new ListItem("秀水鄉", "4"));
                district.Items.Add(new ListItem("鹿港鎮", "5"));
                district.Items.Add(new ListItem("福興鄉", "6"));
                district.Items.Add(new ListItem("線西鄉", "7"));
                district.Items.Add(new ListItem("和美鎮", "8"));
                district.Items.Add(new ListItem("伸港鄉", "9"));
                district.Items.Add(new ListItem("員林鎮", "10"));
                district.Items.Add(new ListItem("社頭鄉", "11"));
                district.Items.Add(new ListItem("永靖鄉", "12"));
                district.Items.Add(new ListItem("埔心鄉", "13"));
                district.Items.Add(new ListItem("溪湖鎮", "14"));
                district.Items.Add(new ListItem("大村鄉", "15"));
                district.Items.Add(new ListItem("埔鹽鄉", "16"));
                district.Items.Add(new ListItem("田中鎮", "17"));
                district.Items.Add(new ListItem("北斗鎮", "18"));
                district.Items.Add(new ListItem("田尾鎮", "19"));
                district.Items.Add(new ListItem("埤頭鄉", "20"));
                district.Items.Add(new ListItem("溪洲鄉", "21"));
                district.Items.Add(new ListItem("竹塘鄉", "22"));
                district.Items.Add(new ListItem("二林鎮", "23"));
                district.Items.Add(new ListItem("大城鄉", "24"));
                district.Items.Add(new ListItem("芳苑鄉", "25"));
                district.Items.Add(new ListItem("二水鄉", "26"));
                break;
            case "10":
                district.Items.Clear();
                district.Items.Add(new ListItem("南投市", "1"));
                district.Items.Add(new ListItem("中寮鄉", "2"));
                district.Items.Add(new ListItem("草屯鎮", "3"));
                district.Items.Add(new ListItem("國姓鄉", "4"));
                district.Items.Add(new ListItem("埔里鎮", "5"));
                district.Items.Add(new ListItem("仁愛鄉", "6"));
                district.Items.Add(new ListItem("名間鄉", "7"));
                district.Items.Add(new ListItem("集集鎮", "8"));
                district.Items.Add(new ListItem("水田鄉", "9"));
                district.Items.Add(new ListItem("魚池鄉", "10"));
                district.Items.Add(new ListItem("信義鄉", "11"));
                district.Items.Add(new ListItem("竹山鄉", "12"));
                district.Items.Add(new ListItem("鹿谷鄉", "13"));
                break;
            case "11":
                district.Items.Clear();
                district.Items.Add(new ListItem("斗南鎮", "1"));
                district.Items.Add(new ListItem("大埤鄉", "2"));
                district.Items.Add(new ListItem("虎尾鎮", "3"));
                district.Items.Add(new ListItem("土庫鄉", "4"));
                district.Items.Add(new ListItem("褒忠鄉", "5"));
                district.Items.Add(new ListItem("東勢鄉", "6"));
                district.Items.Add(new ListItem("臺西鄉", "7"));
                district.Items.Add(new ListItem("崑背鄉", "8"));
                district.Items.Add(new ListItem("麥寮鄉", "9"));
                district.Items.Add(new ListItem("斗六鄉", "10"));
                district.Items.Add(new ListItem("林內鄉", "11"));
                district.Items.Add(new ListItem("古坑鄉", "12"));
                district.Items.Add(new ListItem("莿桐鄉", "13"));
                district.Items.Add(new ListItem("西螺鎮", "14"));
                district.Items.Add(new ListItem("二崙鄉", "15"));
                district.Items.Add(new ListItem("北港鎮", "16"));
                district.Items.Add(new ListItem("水林鄉", "17"));
                district.Items.Add(new ListItem("湖口鄉", "18"));
                district.Items.Add(new ListItem("四湖鄉", "19"));
                district.Items.Add(new ListItem("元長鄉", "20"));
                break;
            case "12":
                district.Items.Clear();
                district.Items.Add(new ListItem("嘉義市", "1"));
                district.Items.Add(new ListItem("番路鄉", "2"));
                district.Items.Add(new ListItem("梅山鄉", "3"));
                district.Items.Add(new ListItem("竹崎鄉", "4"));
                district.Items.Add(new ListItem("阿里山鄉", "5"));
                district.Items.Add(new ListItem("中埔鄉", "6"));
                district.Items.Add(new ListItem("大埔鄉", "7"));
                district.Items.Add(new ListItem("水上鄉", "8"));
                district.Items.Add(new ListItem("鹿草鄉", "9"));
                district.Items.Add(new ListItem("太保市", "10"));
                district.Items.Add(new ListItem("朴子鄉", "11"));
                district.Items.Add(new ListItem("東石鄉", "12"));
                district.Items.Add(new ListItem("六腳鄉", "13"));
                district.Items.Add(new ListItem("新港鎮", "14"));
                district.Items.Add(new ListItem("民雄鄉", "15"));
                district.Items.Add(new ListItem("大林鎮", "16"));
                district.Items.Add(new ListItem("溪口鄉", "17"));
                district.Items.Add(new ListItem("義竹鄉", "18"));
                district.Items.Add(new ListItem("布袋鎮", "19"));
                break;
            case "13":
                district.Items.Clear();
                district.Items.Add(new ListItem("中西區", "1"));
                district.Items.Add(new ListItem("東區", "2"));
                district.Items.Add(new ListItem("南區", "3"));
                district.Items.Add(new ListItem("北區", "4"));
                district.Items.Add(new ListItem("安平區", "5"));
                district.Items.Add(new ListItem("安南區", "6"));
                district.Items.Add(new ListItem("永康區", "7"));
                district.Items.Add(new ListItem("歸仁區", "8"));
                district.Items.Add(new ListItem("新化區", "9"));
                district.Items.Add(new ListItem("玉井區", "10"));
                district.Items.Add(new ListItem("楠西區", "11"));
                district.Items.Add(new ListItem("南化區", "12"));
                district.Items.Add(new ListItem("仁德區", "13"));
                district.Items.Add(new ListItem("關廟區", "14"));
                district.Items.Add(new ListItem("龍崎區", "15"));
                district.Items.Add(new ListItem("官田區", "16"));
                district.Items.Add(new ListItem("麻豆區", "17"));
                district.Items.Add(new ListItem("佳里區", "18"));
                district.Items.Add(new ListItem("西港區", "19"));
                district.Items.Add(new ListItem("七股區", "20"));
                district.Items.Add(new ListItem("將軍區", "21"));
                district.Items.Add(new ListItem("學甲區", "22"));
                district.Items.Add(new ListItem("北門區", "23"));
                district.Items.Add(new ListItem("左鎮區", "24"));
                district.Items.Add(new ListItem("新營區", "25"));
                district.Items.Add(new ListItem("後壁區", "26"));
                district.Items.Add(new ListItem("白河區", "27"));
                district.Items.Add(new ListItem("東山區", "28"));
                district.Items.Add(new ListItem("六甲區", "29"));
                district.Items.Add(new ListItem("下營區", "30"));
                district.Items.Add(new ListItem("鹽水區", "31"));
                district.Items.Add(new ListItem("柳營區", "32"));
                district.Items.Add(new ListItem("善化區", "33"));
                district.Items.Add(new ListItem("大內區", "34"));
                district.Items.Add(new ListItem("山上區", "35"));
                district.Items.Add(new ListItem("新市區", "36"));
                district.Items.Add(new ListItem("安定區", "37"));
                break;
            case "14":
                district.Items.Clear();
                district.Items.Add(new ListItem("新興區", "1"));
                district.Items.Add(new ListItem("前金區", "2"));
                district.Items.Add(new ListItem("苓雅區", "3"));
                district.Items.Add(new ListItem("鹽埕區", "4"));
                district.Items.Add(new ListItem("鼓山區", "5"));
                district.Items.Add(new ListItem("旗津區", "6"));
                district.Items.Add(new ListItem("前鎮區", "7"));
                district.Items.Add(new ListItem("三民區", "8"));
                district.Items.Add(new ListItem("楠梓區", "9"));
                district.Items.Add(new ListItem("小港區", "10"));
                district.Items.Add(new ListItem("左營區", "11"));
                district.Items.Add(new ListItem("仁武區", "12"));
                district.Items.Add(new ListItem("大社區", "13"));
                district.Items.Add(new ListItem("岡山區", "14"));
                district.Items.Add(new ListItem("路竹區", "15"));
                district.Items.Add(new ListItem("阿蓮區", "16"));
                district.Items.Add(new ListItem("田寮區", "17"));
                district.Items.Add(new ListItem("燕巢區", "18"));
                district.Items.Add(new ListItem("橋頭區", "19"));
                district.Items.Add(new ListItem("梓官區", "20"));
                district.Items.Add(new ListItem("彌陀區", "21"));
                district.Items.Add(new ListItem("永安區", "22"));
                district.Items.Add(new ListItem("湖內區", "23"));
                district.Items.Add(new ListItem("鳳山區", "24"));
                district.Items.Add(new ListItem("大寮區", "25"));
                district.Items.Add(new ListItem("林園區", "26"));
                district.Items.Add(new ListItem("鳥松區", "27"));
                district.Items.Add(new ListItem("大樹區", "28"));
                district.Items.Add(new ListItem("旗山區", "29"));
                district.Items.Add(new ListItem("美濃區", "30"));
                district.Items.Add(new ListItem("六龜區", "31"));
                district.Items.Add(new ListItem("內門區", "32"));
                district.Items.Add(new ListItem("杉林區", "33"));
                district.Items.Add(new ListItem("甲仙區", "34"));
                district.Items.Add(new ListItem("桃源區", "35"));
                district.Items.Add(new ListItem("那瑪夏區", "36"));
                district.Items.Add(new ListItem("茂林區", "37"));
                district.Items.Add(new ListItem("茄萣區", "37"));
                break;
            case "15":
                district.Items.Clear();
                district.Items.Add(new ListItem("屏東市", "1"));
                district.Items.Add(new ListItem("三地門鄉", "2"));
                district.Items.Add(new ListItem("霧臺鄉", "3"));
                district.Items.Add(new ListItem("瑪家鄉", "4"));
                district.Items.Add(new ListItem("九如鄉", "5"));
                district.Items.Add(new ListItem("里港鄉", "6"));
                district.Items.Add(new ListItem("高樹鄉", "7"));
                district.Items.Add(new ListItem("鹽埔鄉", "8"));
                district.Items.Add(new ListItem("長治鄉", "9"));
                district.Items.Add(new ListItem("麟洛鄉", "10"));
                district.Items.Add(new ListItem("竹田鄉", "11"));
                district.Items.Add(new ListItem("內埔鄉", "12"));
                district.Items.Add(new ListItem("萬丹鄉", "13"));
                district.Items.Add(new ListItem("潮州鎮", "14"));
                district.Items.Add(new ListItem("泰武鄉", "15"));
                district.Items.Add(new ListItem("來義鄉", "16"));
                district.Items.Add(new ListItem("萬巒鄉", "17"));
                district.Items.Add(new ListItem("崁頂鄉", "18"));
                district.Items.Add(new ListItem("新埤鄉", "19"));
                district.Items.Add(new ListItem("南州鄉", "20"));
                district.Items.Add(new ListItem("林邊鄉", "21"));
                district.Items.Add(new ListItem("東港鎮", "22"));
                district.Items.Add(new ListItem("琉球鄉", "23"));
                district.Items.Add(new ListItem("佳冬鄉", "24"));
                district.Items.Add(new ListItem("新園鄉", "25"));
                district.Items.Add(new ListItem("枋寮鄉", "26"));
                district.Items.Add(new ListItem("枋山鄉", "27"));
                district.Items.Add(new ListItem("春日鄉", "28"));
                district.Items.Add(new ListItem("獅子鄉", "29"));
                district.Items.Add(new ListItem("車城鄉", "30"));
                district.Items.Add(new ListItem("牡丹鄉", "31"));
                district.Items.Add(new ListItem("恆春鎮", "32"));
                district.Items.Add(new ListItem("滿洲鄉", "33"));

                break;
            case "16":
                district.Items.Clear();
                district.Items.Add(new ListItem("臺東市", "1"));
                district.Items.Add(new ListItem("綠島鄉", "2"));
                district.Items.Add(new ListItem("蘭嶼鄉", "3"));
                district.Items.Add(new ListItem("延平鄉", "4"));
                district.Items.Add(new ListItem("卑南鄉", "5"));
                district.Items.Add(new ListItem("鹿野鄉", "6"));
                district.Items.Add(new ListItem("關山鎮", "7"));
                district.Items.Add(new ListItem("海瑞鄉", "8"));
                district.Items.Add(new ListItem("池上鄉", "9"));
                district.Items.Add(new ListItem("冬河鄉", "10"));
                district.Items.Add(new ListItem("成功鄉", "11"));
                district.Items.Add(new ListItem("長濱鄉", "12"));
                district.Items.Add(new ListItem("太麻里鄉", "13"));
                district.Items.Add(new ListItem("金峰鄉", "14"));
                district.Items.Add(new ListItem("大武鄉", "15"));
                district.Items.Add(new ListItem("達仁鄉", "16"));
                break;
            case "17":
                district.Items.Clear();
                district.Items.Add(new ListItem("花蓮市", "1"));
                district.Items.Add(new ListItem("新城鄉", "2"));
                district.Items.Add(new ListItem("秀林鄉", "3"));
                district.Items.Add(new ListItem("吉安鄉", "4"));
                district.Items.Add(new ListItem("壽豐鄉", "5"));
                district.Items.Add(new ListItem("鳳林鎮", "6"));
                district.Items.Add(new ListItem("光復鄉", "7"));
                district.Items.Add(new ListItem("豐濱鄉", "8"));
                district.Items.Add(new ListItem("瑞穗鄉", "9"));
                district.Items.Add(new ListItem("萬榮鄉", "10"));
                district.Items.Add(new ListItem("玉里鄉", "11"));
                district.Items.Add(new ListItem("卓溪鄉", "12"));
                district.Items.Add(new ListItem("富里鄉", "13"));
                break;
            case "18":
                district.Items.Clear();
                district.Items.Add(new ListItem("馬公市", "1"));
                district.Items.Add(new ListItem("西嶼鄉", "2"));
                district.Items.Add(new ListItem("望安鄉", "3"));
                district.Items.Add(new ListItem("七美鄉", "4"));
                district.Items.Add(new ListItem("白沙鄉", "5"));
                district.Items.Add(new ListItem("湖西鄉", "6"));
                break;
            case "19":
                district.Items.Clear();
                district.Items.Add(new ListItem("金沙鎮", "1"));
                district.Items.Add(new ListItem("金湖鎮", "2"));
                district.Items.Add(new ListItem("金寧鎮", "3"));
                district.Items.Add(new ListItem("金城鎮", "4"));
                district.Items.Add(new ListItem("烈嶼鄉", "5"));
                district.Items.Add(new ListItem("烏坵鄉", "6"));
                break;
            case "20":
                district.Items.Clear();
                district.Items.Add(new ListItem("金沙鎮", "1"));
                district.Items.Add(new ListItem("金湖鎮", "2"));
                district.Items.Add(new ListItem("金寧鎮", "3"));
                district.Items.Add(new ListItem("金城鎮", "4"));
                district.Items.Add(new ListItem("烈嶼鄉", "5"));
                district.Items.Add(new ListItem("烏坵鄉", "6"));
                break;
            case "21":
                district.Items.Clear();
                district.Items.Add(new ListItem("南竿鄉", "1"));
                district.Items.Add(new ListItem("北竿鄉", "2"));
                district.Items.Add(new ListItem("莒光鄉", "3"));
                district.Items.Add(new ListItem("東引鄉", "4"));
                break;

        }

        Dispose();
    }

}