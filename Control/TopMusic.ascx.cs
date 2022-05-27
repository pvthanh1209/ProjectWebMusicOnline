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
    public partial class TopMusic : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=Musicweb;User ID=sa;Password=1234$");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadTopMusic();
            }
        }

        public void loadTopMusic()
        {
            string sql = "select top 10 * from Music ORDER BY LuotXem Desc";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TopMusic__.DataSource = ds;
            TopMusic__.DataBind();
            con.Close();
        }
    }
}