using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MusicWebOnline.Control
{
    public partial class TopVideo : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=Musicweb;User ID=sa;Password=1234$");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadTopVideo();
            }
        }

        public void loadTopVideo()
        {
            string sql = "select top 10 * FROM Video ORDER BY LuotXem DESC";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TopVideo__.DataSource = ds;
            TopVideo__.DataBind();
            con.Close();
        }
    }
}