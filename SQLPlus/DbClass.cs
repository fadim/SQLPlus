using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace SQLPlus
{
   
    class DbClass
    {
        public string DataSource = "localhost";
        public string InitialCatalog = "master";
        public string UserId = "sa";
        public string Password = "123";

        public string CnnStr
        {
            get 
            {
                return    "data source=" + DataSource + ";" +
                          "initial catalog=" + InitialCatalog + ";" +
                          "user id=" + UserId + ";" +
                          "password=" + Password + ";";
            }
        }

        public SqlConnection cnn = new SqlConnection();
        public DbClass()
        {
            cnn.ConnectionString = CnnStr;
        }

        public DataTable Fill(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            if (cnn.State==ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }
        }

    }
}
