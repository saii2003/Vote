using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Vote 的摘要描述
/// </summary>
public class Vote:DBbase
{
    
    public string _vote_title;

    private string vote_title
    {
        get { return _vote_title; }
        set { _vote_title = value; }
    }

   
    public void voteTitle(Label title)//首頁投票標題
    {
       
        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select top 1 vote_title From vote order by vote_id desc ");
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                title.Text = dr["vote_title"].ToString();
            }
        }
        dr.Close();
        dr.Dispose();
        cmd.Dispose();
        Dispose();
        
    }
    public DataTable votes()
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = SqlCmd("select vote.vote_id,vote.vote_title,vote.vote_date,vote.vote_over,sum(vote_detail.vote_rank) as rank from vote,vote_detail where vote.vote_id=vote_detail.vote_id group by vote.vote_id,vote_title,vote_date,vote_over order by vote.vote_id desc");
        dt.Load(cmd.ExecuteReader());
        dt.Dispose();
        cmd.Dispose();
        Dispose();
        return dt;
    }
    public DataTable rank()
    {
        
        DataTable dt =new DataTable();
        SqlCommand cmd = SqlCmd("select sum(vote_rank)as rank from vote_detail group by vote_id order by vote_id desc");
        dt.Load(cmd.ExecuteReader());
        dt.Dispose();
        cmd.Dispose();
        Dispose();
        return dt;
       
       
        
    }
    public void vote_item_index(RadioButtonList rbl)
    {
        string id = "";
        SqlDataReader dr1;
        SqlCommand votecmd = SqlCmd("Select top 1 vote_id from vote order by vote_id desc");
        dr1=votecmd.ExecuteReader();
        if (dr1.HasRows)
        {
            while (dr1.Read())
            {
                id = dr1["vote_id"].ToString();
            }
        }
        dr1.Dispose();
        dr1.Close();
        votecmd.Dispose();
        

        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select vote_id,vote_item From vote_detail where vote_id=@vote_id");
        cmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = id;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                rbl.Items.Add(dr["vote_item"].ToString());
            }
        }
        dr.Dispose();
        dr.Close();
        cmd.Dispose();
        Dispose();
        Dispose();


    }
    #region 投票項目
    public void vote_item(RadioButtonList rbl,string id,string vote_id,Label title,Label date,Label over)
    {

        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select vote.vote_title,vote.vote_date,vote.vote_over,vote_detail.vote_id,vote_detail.vote_item,vote_detail.vote_rank From vote,vote_detail where vote.vote_id=vote_detail.vote_id and vote.vote_id=@voteid and vote_detail.vote_id=@vote_id  ");
        cmd.Parameters.Add("@voteid", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = vote_id;
        
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                DateTime vote_date = DateTime.Parse(dr["vote_date"].ToString());
                DateTime vote_over = DateTime.Parse(dr["vote_over"].ToString());
                title.Text = dr["vote_title"].ToString();
                date.Text = vote_date.ToString("yyyy/MM/dd");
                over.Text = vote_over.ToString("yyyy/MM/dd");
           
                rbl.Items.Add(dr["vote_item"].ToString());
            }
        }
        dr.Dispose();
        dr.Close();
        cmd.Dispose();
        Dispose();


    }
    #endregion
    public void vote_update(string id,string item)
    {
        SqlDataReader dr;
        int rank = 0;
        SqlCommand rankcmd = SqlCmd("Select vote_rank from vote_detail where vote_id=@vote_id and vote_item=@vote_item");
        rankcmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = id;
        rankcmd.Parameters.Add("@vote_item", SqlDbType.NVarChar, 50).Value = item;
        dr = rankcmd.ExecuteReader();
        if(dr.HasRows)
        {
            while(dr.Read())
            {
                rank = Convert.ToInt32(dr["vote_rank"].ToString());
            }
        }
        dr.Close();
        dr.Dispose();
        rankcmd.Dispose();
        

        SqlCommand cmd = SqlCmd("update vote_detail set vote_rank=@vote_rank where vote_id=@vote_id and vote_item=@vote_item");
        cmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@vote_item", SqlDbType.NVarChar, 50).Value = item;
        cmd.Parameters.Add("@vote_rank", SqlDbType.Int).Value = rank + 1;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        Dispose();
        Dispose();
    }
    public void vote_end(string id,string vote_id,Label title,Label date,Label over,Label items,Label total)//投票結果
    {
        float vote_total = 0;//總投票數

        SqlDataReader rankdr;
        SqlCommand rankcmd = SqlCmd("Select vote_rank From vote_detail where vote_id=@vote_id");
        rankcmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = id;
        rankdr = rankcmd.ExecuteReader();
        if (rankdr.HasRows)
        {
            while (rankdr.Read())
            {
                vote_total += (int)rankdr["vote_rank"];
                total.Text = vote_total.ToString();
            }
        }
        rankdr.Close();
        rankdr.Dispose();
        rankcmd.Dispose();
        
       

        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select vote.vote_title,vote.vote_date,vote.vote_over,vote_detail.vote_id,vote_detail.vote_item,vote_detail.vote_rank From vote,vote_detail where vote.vote_id=vote_detail.vote_id and vote.vote_id=@voteid and vote_detail.vote_id=@vote_id order by vote_detail.vote_rank desc ");
        cmd.Parameters.Add("@voteid", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = vote_id;

        int item = 1;//項目
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                DateTime vote_date=DateTime.Parse(dr["vote_date"].ToString());
                DateTime vote_over = DateTime.Parse(dr["vote_over"].ToString());
                title.Text = dr["vote_title"].ToString();
                date.Text = vote_date.ToString("yyyy/MM/dd");
                over.Text = vote_over.ToString("yyyy/MM/dd");
                
                float percent = Convert.ToInt32(dr["vote_rank"].ToString()) / vote_total;//得票數/總票數=投票百分比
                items.Text += "<p>" + item + ". &nbsp" + dr["vote_item"].ToString();
                items.Text += "&nbsp&nbsp<img src='Photo/sum06.gif' height='15' width='" + string.Format("{0:p}", percent/2) + "'>";
                items.Text += "&nbsp&nbsp" + string.Format("{0:p}", percent) + "&nbsp&nbsp (" + Convert.ToInt32(dr["vote_rank"].ToString()) + "票)";
                item++;
                
                
                
            }
        }
        dr.Dispose();
        dr.Close();
        cmd.Dispose();
        Dispose();
        Dispose();
        Dispose();
        
    }
    public string vote_id()
    {
        string id = "";
        SqlDataReader dr;
        SqlCommand cmd = SqlCmd("Select top 1 vote_id From vote order by vote_id desc");
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                id = dr["vote_id"].ToString();
            }
        }
        dr.Dispose();
        dr.Close();
        cmd.Dispose();
        Dispose();
        return id;
    }
    //寫入已投票會員資料
    public int insert_voted(string m_id, string vote_id)
    {
        int voted = 0;
        SqlCommand cmd = SqlCmd("insert into voted(m_id,vote_id)values(@m_id,@vote_id)");
        cmd.Parameters.Add("@m_id", SqlDbType.Int).Value = m_id;
        cmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = vote_id;
        voted = Convert.ToInt32(cmd.ExecuteNonQuery());
        cmd.Dispose();
        Dispose();
        return voted;
    }
    //限制會員投票
    public int voted(string m_id, string vote_id)
    {
        int voted = 0;
        SqlCommand cmd = SqlCmd("Select Count(*) from voted where m_id=@m_id and vote_id=@vote_id");
        cmd.Parameters.Add("@m_id", SqlDbType.Int).Value = m_id;
        cmd.Parameters.Add("@vote_id", SqlDbType.Int).Value = vote_id;
        voted = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Dispose();
        Dispose();
        return voted;
    }

    //新增投票題目
    public int vote_add(string name, string date, string over)
    {
        int add = 0;
        SqlCommand cmd = SqlCmd("Insert into vote(vote_title,vote_date,vote_over)values(@title,@date,@over)");
        cmd.Parameters.Add("@title", SqlDbType.NVarChar, 50).Value = name;
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
        cmd.Parameters.Add("@over", SqlDbType.DateTime).Value = over;
        add = cmd.ExecuteNonQuery();
        cmd.Dispose();
        Dispose();
        return add;
    }
    public string voteid()
    {
        SqlDataReader dr;
        string id = "";
        SqlCommand cmd = SqlCmd("select top 1 vote_id From vote order by vote_id desc");
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                id = dr["vote_id"].ToString();
            }
        }
        dr.Close();
        dr.Dispose();
        cmd.Dispose();
        Dispose();
        return id;
    }
    //新增投票項目
    public int vote_d_add(int id, string item)
    {
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString);
        conn.Open();
        int add = 0;
        SqlCommand cmd = new SqlCommand("Insert into vote_detail(vote_id,vote_item,vote_rank)values(@id,@item,@rank)",conn);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id + 1;
        cmd.Parameters.Add("@item", SqlDbType.NVarChar, 50).Value = item;
        cmd.Parameters.Add("@rank", SqlDbType.Int).Value = 0;
        add = cmd.ExecuteNonQuery();
        conn.Dispose();
        cmd.Dispose();
        return add;

    }
}