using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Configuration;

/// <summary>
/// 資料庫基本連線設定
/// </summary>
public class DBbase
{
    private SqlConnection publicConnection = null;

        public DBbase()
        {
            publicConnection = getConnection();
        }
        public SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["VoteConnectionString"].ConnectionString);
            conn.Open();
            return conn;

        }
        public SqlCommand SqlCmd(string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, publicConnection);
            return cmd;

        }
        public void Dispose()
        {
            if (publicConnection.State == ConnectionState.Open)
            {
                publicConnection.Close();
                publicConnection.Dispose();
            }
        }
    
}