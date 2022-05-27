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
    public partial class ChuDe : System.Web.UI.Page
    {
        DataConnection data = new DataConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            Tentheloai();
            DisPlayMusic();
        }

        public void Tentheloai()
        {
            string matheloai = Request.QueryString["L"].ToString();
            string Theloai = null;
            string sql = "select * from TheLoai where MaTheLoai='" + matheloai + "'";
            data.connDB();
            SqlCommand cmd = new SqlCommand(sql, data.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Theloai = dr["TenTheLoai"].ToString();
            }
            Label1.Text = "Thể loại " + Theloai;
            data.closeDB();
        }
        public void DisPlayMusic()
        {
            string matheloai = Request.QueryString["L"].ToString();
            string sql = "select * from Music Where MaTheLoai='" + matheloai + "'";
            data.connDB();
            SqlDataAdapter da = new SqlDataAdapter(sql, data.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList5.DataSource = ds;
            DataList5.DataBind();
            data.closeDB();
        }
    }
}