using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MusicWebOnline.Control
{
    public partial class TheLoai : System.Web.UI.UserControl
    {
        //string strCon = @"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=Musicweb;User ID=sa;Password=1234$";
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=Musicweb;User ID=sa;Password=1234$");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadTheLoai();
            }
        }

        public void loadTheLoai()
        {
            string sql = "select * from TheLoai ORDER BY TenTheLoai Desc";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ChuDe__.DataSource = ds;
            ChuDe__.DataBind();
            con.Close();
        }
    }
}