using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class Top : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = null;
            if (Request.QueryString.HasKeys())
            {
                act = Request.QueryString["T"].ToString();
            }
            switch (act)
            {
                case "Album":
                    album();
                    break;
                default:
                    break;
            }
        }

        public void album()
        {
            string sql = "select * from Album";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Album__.DataSource = ds;
            Album__.DataBind();
            data.closeDB();
        }
    }
}