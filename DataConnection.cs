using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MusicWebOnline
{
    public class DataConnection
    {
        string strCon = @"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=Musicweb;User ID=sa;Password=1234$";


        public SqlConnection conn = new SqlConnection();

        public void connDB()
        {
            conn.ConnectionString = strCon;
            conn.Open();
        }

        public void closeDB()
        {
            if (conn.State == ConnectionState.Open)
            { conn.Close(); }
        }

        public DataTable getDT(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                connDB();
                SqlDataAdapter Adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                Adapter.Fill(dt);
            }
            catch (System.Exception)
            {
                dt = null;
            }
            finally
            {
                closeDB();
            }

            return dt;
        }
    }
}